using System;
using System.IO;
using System.Threading.Tasks;
using ToysLib;

namespace ToysLib
{
    public class Toy
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public (string, int) Statistic 
        { 
            get 
            {
               return (this.Name, this.ID); 
            }
        }

        public Toy()
        {
            Random helper = new Random();
            var a = helper.Next(255);
            Random id = new Random();
            var b = id.Next(999999);
            this.Name = Convert.ToString($"{a} - Name");
            this.ID = b;
        }
    }
}