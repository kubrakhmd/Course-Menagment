using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMenagment
{
    internal class Student
    {
        private readonly int Limit;
        private static readonly int Count;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string GroupNo { get; set; }
        public string Type { get; set; }
        public IEnumerable<object> Groups { get; private set; }
        public bool IsOnline { get; internal set; }

        public Student(string name, string surname, string groupNo, string type)
        {
            Name = name.Capitalize();
            Surname = surname.Capitalize();
            GroupNo = groupNo;
            Type = type;
        }

        public Student(string? name, string? surname, string? groupNo, bool isOnline, string? type)
        {
            Name = name;
            Surname = surname;
            GroupNo = groupNo;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} (Group: {GroupNo}, Type: {Type})";
        }
        public void CreateStudent()
        {
            Console.Write("Tələbənin adını daxil edin: ");
            string name = Console.ReadLine();

            Console.Write("Tələbənin soyadını daxil edin: ");
            string surname = Console.ReadLine();

            Console.Write("Tələbənin qrup nömrəsini daxil edin: ");
            string groupNo = Console.ReadLine();

            Group group = null;
            foreach (var g in Groups)
            {
                if (g.No == groupNo)
                {
                    group = g;
                    break;
                }
            }

            if (group == null || !group.CanAddStudent())
            {
                Console.WriteLine("Bu qrupa tələbə əlavə etmək mümkün deyil.");
                return;
            }

            Console.Write("Tələbə tipi (zəmanətli/zəmanətsiz): ");
            string type = Console.ReadLine();

            var student = new Student(name, surname, groupNo, group.IsOnline, type);
            Students.Add(student);
            group.Students.Add(student);
            Console.WriteLine("Tələbə uğurla yaradıldı.");

        }
        public bool AddStudent(Student student)
        {
            if (Student.Count < Limit)
            {
                object value = Students.Add(student);
                return true;
            }
            Console.WriteLine("Bu qrupda tələbə limiti dolub.");
            return false;
        }

    }
}

