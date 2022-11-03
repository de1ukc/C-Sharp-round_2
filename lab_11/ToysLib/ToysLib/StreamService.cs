using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ToysLib
{
    public class StreamService
    {
        public Task WriteToStream(Stream stream)
        {
            List<Toy> toys = new List<Toy>();
            
            for (int i = 0; i < 10; i++) 
                toys.Add(new Toy());

            foreach (var toy in toys)
            {
                
            }

            return default;
        }

        public Task CopyFromStream(Stream stream,string filename)
        {
            return default;
        }

        public async Task<int> GetStatisticsAsync(string fileName,
            Func<Toy, bool> filter)
        {
            return default;
        }
    }
}