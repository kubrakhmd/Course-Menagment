using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMenagment
{
    internal static class Helper
    {
     

        public static string Capitalize(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input[1..].ToLower();
        }
         public static void CreateStudent()
        {
            Console.Write("Tələbənin adını daxil edin: ");
            var name = Console.ReadLine();
            Console.Write("Tələbənin soyadını daxil edin: ");
            var surname = Console.ReadLine();
            Console.Write("Tələbənin qrup nömrəsini daxil edin: ");
            var groupNo = Console.ReadLine();
            Console.Write("Tələbənin tipini daxil edin (zəmanətli/zəmanətsiz): ");
            var type = Console.ReadLine();

            var student = new Student(name, surname, groupNo, type);
            // Add student to a list or perform further actions
        }
    }



}

