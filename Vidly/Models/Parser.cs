using System;
using System.Collections.Generic;
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
        public List<Vehicle> ParseGetLastVehicleData(string url)
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(url);
            }
            catch (Exception exception)
            {

                throw exception;
            }

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
                myVehiclesList.Add(myVehicle);
            }
            return myVehiclesList;

        }


        public List<Vehicle> ParseRawVehicleData(string url)
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/nodes/response/node");

            foreach (XmlNode node in nodes)
            {
                Vehicle myVehicle = new Vehicle();
                myVehicle.latitude = Double.Parse(node.SelectSingleNode("Latitude").InnerText);
                myVehicle.longitude = Double.Parse(node.SelectSingleNode("Longitude").InnerText);
                myVehicle.timestamp = node.SelectSingleNode("timestamp").InnerText;
                myVehicle.objectName = url;
                myVehiclesList.Add(myVehicle);
            }
            return myVehiclesList;
        }
    }
}