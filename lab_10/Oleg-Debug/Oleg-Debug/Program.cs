using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oleg_Debug
{
    class Program
    {
        static void Main(string[] args)
        { 
            const string DLLPath = "D:/Sharp-Round-2/lab_10/new lib/Lib/Lib/bin/Release/netcoreapp5.0/Lib.dll";
            const string JsonPath = "D:/Sharp-Round-2/lab_10/Oleg-Debug/Oleg-Debug/shit.json";
            Employee Aleh = new Employee("Aleh",18,true);
            Employee Nikolas = new Employee("Nikolas",19,false);
            Employee Dima = new Employee("Dima",19,false);
            Employee Masha = new Employee("Masha",18,true);
            Employee Dasha = new Employee("Dasha",18,false);
            IEnumerable<Employee> data = new []{Aleh,Dasha,Masha};
            
            
            Assembly asm = Assembly.LoadFrom(DLLPath);
            Type t = asm.GetType("Lib.FileService`1", true, true).MakeGenericType(typeof(Employee)); // почему я не могу указать достать FileService<T>
            object obj = Activator.CreateInstance(t);
            MethodInfo SaveData = t.GetMethod("SaveData");
            MethodInfo ReadFile = t.GetMethod("ReadFile");
            SaveData.Invoke(obj, new Object[] {data,JsonPath});
            var anser = ReadFile.Invoke(obj, new[] {JsonPath}); // почему возвращается Object , а не лист
            var b = anser as List<Employee>;
            foreach (var ppl in b)
            {
                Console.WriteLine(ppl.Name);
                Console.WriteLine(ppl.Age);
                Console.WriteLine(ppl.IsMarried);
                Console.WriteLine();
            }
            //почему всё так деррьмово?
            
        }
    }
}
