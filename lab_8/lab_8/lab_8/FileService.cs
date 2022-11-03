using System;
using System.Collections.Generic;
using System.IO;

namespace lab_8
{
    public class FileService : IFileService
    {
        string path= @"В:\Rider_LABS\SEM_3\LAB_8\lab_8\lab_8\Employee.dat";
        
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName,FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    string age = reader.ReadString();
                    string isMarried = reader.ReadString();
                    yield return new Employee(name,Convert.ToInt32(age),Convert.ToBoolean(isMarried));
                }
            }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName,FileMode.OpenOrCreate)))
            {
                foreach (var empl in data )
                {
                    writer.Write(empl.Name);
                    writer.Write(empl.Age.ToString());
                    writer.Write(empl.IsMarried.ToString());
                }
            }
        }
    }
}