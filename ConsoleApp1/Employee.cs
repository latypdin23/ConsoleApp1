using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        private string name;
        private int age;
        public Employee()
        {

        }
        public Employee(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return $" { name} в возрасте {age} лет";
        }
    }
}
