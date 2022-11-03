using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static lab_9.LAB9_Domain;
using  System.Xml.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace lab_9
{
    public class Serializer : ISerializer
    {
       public IEnumerable<Airport> DeSerializeByLINQ(string fileName)
       {
           XDocument xdoc = XDocument.Load(fileName);

           var ans = from xe in xdoc.Element("Airports").Elements("Airport")
               select new Airport()
               {
                   airportName = xe.Element("name").Value,
                   airlinesList = (from a in xdoc.Element("Airports").Elements("Airport")
                           select new Airline()
                           {
                               lineName = a.Element("ИмяВПП").Value,
                               length = Convert.ToInt32(a.Element("LineLen").Value),
                               width = Convert.ToInt32(a.Element("LineWid").Value)
                           }).ToList()
               };
           return ans;
       }

        public IEnumerable<Airport> DeSerializeXML(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Airport>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
               var ans = (List<Airport>)formatter.Deserialize(fs);
               return ans;
            }
        }

        public IEnumerable<Airport> DeSerializeJSON(string fileName)
        {
            using (FileStream fs = new FileStream(fileName,FileMode.Open))
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                var ans = JsonSerializer.DeserializeAsync<List<Airport>>(fs,options).Result;
                return ans;
            }
        }

        public void SerializeByLINQ(IEnumerable<Airport> port, string fileName)
        {
            XDocument doc = new XDocument();
            
            List<XElement> AirPort = new List<XElement>();
            int i = 0;
            foreach (var airport in port)
            {
                //AirPort.Add(new XElement(airport.airportName));
                AirPort.Add(new XElement("Airport"));
                foreach (var airline in airport.airlinesList)
                {
                    //XAttribute portName = new XAttribute("name",airport.airportName);
                    XElement portName = new XElement("name",airport.airportName);
                    XElement lineNAme = new XElement("ИмяВПП", airline.lineName.ToString());
                    XElement lineLen = new XElement("LineLen", airline.length);
                    XElement lineWid = new XElement("LineWid", airline.width);
                    AirPort[i].Add(portName);
                    AirPort[i].Add(lineNAme);
                    AirPort[i].Add(lineLen);
                    AirPort[i].Add(lineWid);
                }
                i++;
            }
            
            XElement Airports = new XElement("Airports");
            foreach (var VARIABLE in AirPort)
            {
                Airports.Add(VARIABLE);
            }
            doc.Add(Airports);
            doc.Save(fileName);
            
        }

        public void SerializeXML(IEnumerable<Airport> port, string fileName)
        {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Airport>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    formatter.Serialize(fs,port.ToList());
                }
        }

        public void SerializeJSON(IEnumerable<Airport> port, string fileName)
        {
            using (FileStream fs = new FileStream(fileName,FileMode.Create))
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                JsonSerializer.SerializeAsync<List<Airport>>(fs,port.ToList(),options).Wait();
            }
        }
    }
}