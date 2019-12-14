using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StudentService ss = new StudentService();
            ss.Add(new student() { Name = "Artem", LastName = "Lomanyuk", Age = 20 });
            ss.Add(new student() { Name = "Petro", LastName = "Petrenko", Age = 22 });
            
            int[] arr = { 1, 2, 3, 4 };
            foreach (var item in ss.Students)
            {
                item.AddMarks("C#", arr);
                for (int i = 0; i < arr.Length; i++)
                    arr[i]++;
                item.AddMarks("C++", arr);
            }
            foreach (var item in ss.Students)
            {
                Console.WriteLine(item);
            }
            ss.BestStudent();
            ss.Save();
            Console.WriteLine("Hello world");
            ss.SaveJSON();
        }
    }
}
