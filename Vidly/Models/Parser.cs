using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Xml;
using Vidly.Utils;

namespace Vidly.Models
{
    public class Parser
    {

       /// <summary>
        /// ParseGetLastVehicleData() takes url paramter and returns to Home Conroller List<Vehicle>, 
        /// only adds neccessary information to Vehicle object 
        /// 
        /// 
        /// ParseRawVehicleData() takes urlparameter and returns to Vehicles Controller List<Vehicle>,
        /// 
        /// 
       /// </summary>
       /// <param name="url"></param>
       /// <returns></returns>
       /// 
       
        public List<Vehicle> ParseGetLastVehicleData(string url)
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            XmlDocument doc = new XmlDocument();

           
                doc.Load(url);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/nodes/response/node");

            foreach (XmlNode node in nodes)
            {
                Vehicle myVehicle = new Vehicle();
                myVehicle.address = node.SelectSingleNode("address").InnerText;
                myVehicle.latitude = Double.Parse(node.SelectSingleNode("latitude").InnerText);
                myVehicle.longitude = Double.Parse(node.SelectSingleNode("longitude").InnerText);
                myVehicle.objectName = node.SelectSingleNode("objectName").InnerText;
                myVehicle.timestamp =  Helper.TrimOffTimeZone(node.SelectSingleNode("timestamp").InnerText);
                myVehicle.timeDifference = Helper.ConvertStringToTimeDifference(node.SelectSingleNode("timestamp").InnerText);
                myVehicle.speed = Double.Parse(node.SelectSingleNode("speed").InnerText);
                myVehicle.ObjectId = Int32.Parse(node.SelectSingleNode("objectId").InnerText);
                myVehiclesList.Add(myVehicle);
            }
            return myVehiclesList;

        }



        public List<Vehicle> ParseRawVehicleData(string date, ArrayList objectIdArray)
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            foreach (var outData in objectIdArray)
            {              
                XmlDocument doc = new XmlDocument();
                doc.Load(Helper.UrlCreator(date, outData.ToString()));
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/nodes/response/node");

                foreach (XmlNode node in nodes)
                {
                    Vehicle myVehicle = new Vehicle();
                    myVehicle.latitude = Double.Parse(node.SelectSingleNode("Latitude").InnerText);
                    myVehicle.longitude = Double.Parse(node.SelectSingleNode("Longitude").InnerText);
                    myVehicle.timestamp = node.SelectSingleNode("timestamp").InnerText;
                    myVehicle.ObjectId = Int32.Parse(outData.ToString());
                    myVehiclesList.Add(myVehicle);
                }
            }

            return myVehiclesList;
        }

    }
}