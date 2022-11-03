using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static lab_9.LAB9_Domain;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            const string LINQtoXMLPath = "D:/Rider_LABS/SEM_3/LAB_9/lab_9/lab_9/Airports.xml";
            const string JSONPath = "D:/Rider_LABS/SEM_3/LAB_9/lab_9/lab_9/Airports.json";
            const string XMLPath = "D:/Rider_LABS/SEM_3/LAB_9/lab_9/lab_9/AirportsXML.xml";
            Airline line3 = new Airline("BigStan",2800,42);
            Airline line4 = new Airline("LOnDon",5000,67);
            Airline line1 = new Airline("Berlin-FIRST",3000,70);
            Airline line2 = new Airline("Reichstag",2750,63);
            
            List<Airport> a= new List<Airport>();
            List<Airline> buff = new List<Airline>();
            
            buff.Add(line3);
            buff.Add(line4);
            
            Airport Minsk = new Airport("Minsk","ВПП-1",1500,50);
            Minsk.airlinesList.Add(new Airline("ВПП-2",2000,40));
            Minsk.airlinesList.Add(new Airline("ВПП-3",1980,51));
            Minsk.lineCounter += 2;
            
            Airport Berlin = new Airport("Berlin");
            Berlin.airlinesList.Add(line1);
            Berlin.airlinesList.Add(line2);
            Berlin.lineCounter += 2;
            
            Airport London = new Airport("London",buff);
            a.Add(Minsk);
            a.Add(Berlin);
            a.Add(London);
            
            Serializer tools = new Serializer();
          /*  
            tools.SerializeByLINQ(a,LINQtoXMLPath);
            var LINQans = tools.DeSerializeByLINQ( LINQtoXMLPath);

           foreach (var VARIABLE in ans)
           {
               Console.WriteLine(VARIABLE.airportName);
               foreach (var airline in VARIABLE.airlinesList)
               {
                   Console.WriteLine(airline.lineName);
               }
           }
           */
           Console.WriteLine("AAAAAAAAAAAAAAAAAAAAA");
           tools.SerializeJSON(a,JSONPath);
           var JSONans = tools.DeSerializeJSON(JSONPath);

           foreach (var VARIABLE in JSONans)
           {
               Console.WriteLine(VARIABLE.airportName);
               foreach (var airline in VARIABLE.airlinesList)
               {
                   Console.WriteLine(airline.lineName);
               }
           }
           
           
           Console.WriteLine("BBBBBBBBBBBBBBBBBB");
          tools.SerializeXML(a,XMLPath);
           var XMLAns = tools.DeSerializeXML(XMLPath);
           
           foreach (var VARIABLE in XMLAns)
           {
               Console.WriteLine(VARIABLE.airportName);
               foreach (var airline in VARIABLE.airlinesList)
               {
                   Console.WriteLine(airline.lineName);
               }
           }
           
        }
    }
}