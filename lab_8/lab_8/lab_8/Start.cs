using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_8
{
    public static class Start
    {
        public static void MainStart()
        {
            string path= @"D:\Rider_LABS\SEM_3\LAB_8\lab_8\lab_8\Employee.dat";
            string path2= @"D:\Rider_LABS\SEM_3\LAB_8\lab_8\lab_8\EmployeeNewDoc.dat";
            string path3 = @"D:\Rider_LABS\SEM_3\LAB_8\lab_8\lab_8\EmployeeNewDocBOCCOC.dat";
            
            Employee Aleh = new Employee("Aleh",18,true);
            Employee Nikolas = new Employee("Nikolas",19,false);
            Employee Dima = new Employee("Dima",19,false);
            Employee Masha = new Employee("Masha",18,true);
            Employee Dasha = new Employee("Dasha",18,false);
            
            FileService tool = new FileService(); // для первого задания
            FileService tool2 = new FileService(); // для второго задания
            
            IEnumerable<Employee> data = new []{Aleh,Nikolas,Dima};
            
            List<Employee> arr = new List<Employee>(){Aleh,Nikolas,Dima,Masha,Dasha};
            List<Employee> ans = new List<Employee>(){};
            
            tool.SaveData(data,path);
            var a = tool.ReadFile(path).GetEnumerator();
            
            Console.WriteLine("****************************************************************************");
            while (a.MoveNext())
            {
                Console.WriteLine(a.Current.Name);
                Console.WriteLine(a.Current.Age);
                Console.WriteLine(a.Current.IsMarried);
            }
            
            if (System.IO.File.Exists(path2) == true)
                System.IO.File.Delete(path2);
            if (System.IO.File.Exists(path3) == true)
                System.IO.File.Delete(path3);
            
            tool2.SaveData(arr,path2);
            
            System.IO.File.Move(path2, path3);
            
            var b = tool2.ReadFile(path3).GetEnumerator();
            while (b.MoveNext())
            {
                ans.Add(new Employee(b.Current.Name,b.Current.Age,b.Current.IsMarried));
            }
            
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("This is a new list now:");
            foreach (var u in ans)
            {
              Console.WriteLine(u.Name);  
              Console.WriteLine(u.Age);
              Console.WriteLine(u.IsMarried);
            }

            var group = from users in ans
                group users by users.Age;
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("This is a groups by Age:");
            foreach (var g in group)
            {
                Console.WriteLine($"Age: {g.Key}");
                foreach (var user in g)
                {
                    Console.WriteLine(user.Name);
                }
                Console.WriteLine();
            }
            
            
            // сортировка по имени с помощтю LINQ и метода Compare
            EmployeeComparer<Employee> buff = new EmployeeComparer<Employee>();
            
            var names = ans.OrderBy(a => a, new EmployeeComparer<Employee>());
            
            Console.WriteLine("HUUIIIIIIIIIi");
            Console.WriteLine(" ");
            foreach (var u in names)
            {
                Console.WriteLine(u.Name);
            }
        }
    }
}