using System.Collections.Generic;
namespace Oleg_Debug
{
    public class Employee
    {
        private string name;
        private bool isMarried;
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool IsMarried
        {
            get => isMarried;
            set => isMarried = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public Employee()
        {
        }

        public Employee(string name , int age, bool isMarried)
        {
            this.name = name;
            this.age = age;
            this.isMarried = isMarried;
        }
    }
}