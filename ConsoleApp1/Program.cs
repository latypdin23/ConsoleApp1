using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Размер памяти в куче в байтах
            Console.WriteLine("Размер памяти в управляемой куче в байтах: {0}", GC.GetTotalMemory(false));

            Console.WriteLine("КОличество поколений: {0}", GC.MaxGeneration+1);

            Employee employee = new Employee("Дина", 25);
            Console.WriteLine(employee.ToString());

            Console.WriteLine("Объект employee относится к поолению: {0}", GC.GetGeneration(employee));

            Console.WriteLine("Размер памяти в управляемой куче в байтах: {0}", GC.GetTotalMemory(false));

            object[] array = new object[10000000];

            ShowGCStat();

            for(int i=0;i<array.Length;i++)
            {
                array[i] = new object();
            }

            Console.WriteLine("Размер памяти в управляемой куче в байтах: {0}", GC.GetTotalMemory(false));
            array = null;
            Console.WriteLine("Массив построен.");

            ShowGCStat();
            var start = DateTime.Now;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Уборщик отработал\t" + (DateTime.Now - start).TotalMilliseconds+" \n");
            Console.WriteLine("Размер памяти в управляемой куче в байтах: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Объект employee относится к поолению: {0}", GC.GetGeneration(employee));

            ShowGCStat();

            Console.ReadKey();
        }

        private static void ShowGCStat()
        {
            Console.WriteLine("\nПоколение 0 проверялось {0} раз", GC.CollectionCount(0));
            Console.WriteLine("\nПоколение 1 проверялось {0} раз", GC.CollectionCount(1));
            Console.WriteLine("\nПоколение 2 проверялось {0} раз", GC.CollectionCount(2));
        }
    }
}
