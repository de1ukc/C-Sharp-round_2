using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace lab_9
{
    public class LAB9_Domain
    {
        [Serializable]
        public class Airport
        {
            public string airportName;

            public string AirportName
            {
                get => airportName;
                set => airportName = value;
            }

            public int lineCounter;

            public int LineCounter
            {
                get => lineCounter;
                set => lineCounter = value;
            }
            public List<Airline> airlinesList  { get; set; } = new List<Airline>(){};

            public Airport()
            {
            }

            public Airport(string airportName)
            {
                this.airportName = airportName;
            }

            public Airport(string airportName, string lineName,int length,int width) // : base() как сослаться на верхний конструктор через base (не на стандартный)
            {
                this.airportName = airportName;
                airlinesList.Add(new Airline(lineName,length,width));
                lineCounter++;
            }

            public Airport(string airportName, List<Airline> arr)
            {
                this.airportName = airportName;
                airlinesList = arr;
                lineCounter = arr.Count;
            }
        }
        
        [Serializable]
        public class Airline
        {
           
            public string lineName;
            
            public int length;
           
            public int width;

            public Airline()
            {
            }

            public Airline(string lineName,int length,int width)
            {
                this.lineName = lineName;
                this.length = length;
                this.width = width;
            }
        }
        
        public interface ISerializer
        {
            IEnumerable<Airport> DeSerializeByLINQ(string fileName);
            IEnumerable<Airport> DeSerializeXML(string fileName);
            IEnumerable<Airport> DeSerializeJSON(string fileName);
            void SerializeByLINQ(IEnumerable<Airport> port, string fileName);
            void SerializeXML(IEnumerable<Airport> port, string fileName);
            void SerializeJSON(IEnumerable<Airport> port, string fileName);
        }

    }
}