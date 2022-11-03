using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ToysLib;

namespace lastLab_11
{
    public class SecondTaskStart
    {
        public static void Start()
        {
            const string fileName = "D:/Sharp-Round-2/lab_11/lastLab_11/lastLab_11/fuck.txt";
            Thread thisTread = Thread.CurrentThread;
            thisTread.Name = "Async Main";
            if (thisTread.IsAlive)
                Console.WriteLine("Threat has been started");
            Console.WriteLine(thisTread.Name);
            
            List<Toy> toys = new List<Toy>();
            
            for (int i = 0; i < 10; i++) 
                toys.Add(new Toy());

            foreach (var VARIABLE in toys)
            {
                Console.WriteLine(VARIABLE.Statistic);
            }
            
            MemoryStream st = new MemoryStream();
            
            StreamService tool = new StreamService();

            Tuple<MemoryStream,StreamService,string> tuple = new Tuple<MemoryStream,StreamService,string>(st,tool,fileName);
            
            Thread FirstThread = new Thread(new ParameterizedThreadStart(FirstStream));
            //FirstThread.Start(tuple);
                
           /* Thread SecondThread = new Thread(new ParameterizedThreadStart(SecondStream));
            SecondThread.Start(tuple);
            */
        }
        public static void FirstStream(object obj)
        {
            Console.WriteLine("******************************");
            var tuple = (Tuple<MemoryStream,StreamService,string>)obj;
            Console.WriteLine("The first stream has been started!");
            
            tuple.Item2.WriteToStream(tuple.Item1);
            tuple.Item2.CopyFromStream(tuple.Item1,tuple.Item3);
            
            Console.WriteLine("The first stream has Finished!");
            Console.WriteLine("******************************");
            Thread.Sleep(400);
        }
        
        public static void SecondStream(object obj)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>");
            var tuple = (Tuple<MemoryStream,StreamService>)obj;
            Console.WriteLine("The second stream has been started!");
            Console.WriteLine("The second stream has Finished!");
            Console.WriteLine("<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>");
            Thread.Sleep(400);
        }
    }
}