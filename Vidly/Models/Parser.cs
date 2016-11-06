using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Vidly.Utils;

namespace Vidly.Models
{
    public class Parser
    {

        //parsing data 
        public List<Vehicle> ParseGetLastVehicleData()
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            string url = "https://apps.oskando.ee/seeme/Api/Vehicles/getLastData?key=proovitoo1";
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/nodes/response/node");

            foreach (XmlNode node in nodes)
            {
                Vehicle myVehicle = new Vehicle();
                myVehicle.address = node.SelectSingleNode("address").InnerText;
                myVehicle.objectId = Int32.Parse(node.SelectSingleNode("objectId").InnerText);
                myVehicle.latitude = Double.Parse(node.SelectSingleNode("latitude").InnerText);
                myVehicle.longitude = Double.Parse(node.SelectSingleNode("longitude").InnerText);
                myVehicle.objectName = node.SelectSingleNode("objectName").InnerText;
                myVehicle.timestamp =  node.SelectSingleNode("timestamp").InnerText;
                myVehicle.timeDifference = Helper.ConvertStringToTimeDifference(node.SelectSingleNode("timestamp").InnerText);
                myVehicle.speed = Double.Parse(node.SelectSingleNode("speed").InnerText);
                myVehiclesList.Add(myVehicle);
            }

            return myVehiclesList;

        }



        //parsing Raw data for poligon 
        public List<Vehicle> ParseRawVehicleData(string url)
        {
            List<Vehicle> myVehiclesList = new List<Vehicle>();
            //string url = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1041&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
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