using System;
using DevTools.Test.Services.Persons;
using DevTools.Test.Services.Students;
using DevTools.Test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //StudentService data = new StudentService("directori","student");
            //var student = data.Add();
            //var t = data.Create(student);
            //Console.WriteLine(t);

            Student student1 = new Student("soko", "koko", DateTime.Parse("2009/10/11"),
                "21s2678");
            Student student2 = new Student("sisiko", "sisi", DateTime.Parse("2010/4/12"),
                "2319wtwu");

            ICollection<Student> list = new List<Student>();
            list.Add(student1);
            list.Add(student2);

            Design design = new Design();
            var t = design.GetMultiDimArrayFrom<Student>(list);
            Console.WriteLine($" {t.Length}");
            Console.WriteLine($" {t.Length} , {list.Count}");

            for (int i = 0; i < (list.Count + 1); i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.WriteLine($"   {t[i, j]}");
                }
            }


            List<string> list2 = new List<string> { "Id", "CreateAt", "UpdateAt" };

            var s = design.GetMultiDimArrayFrom<Student>(list, list2);
            Console.WriteLine($" {s.Length}");
            for (int i = 0; i < (list.Count + 1); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"   {s[i, j]}");
                }
            }
        }

        
    }
}






