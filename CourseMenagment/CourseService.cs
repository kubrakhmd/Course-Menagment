
using System;
using System.Collections.Generic;
using CourseMenagment;

namespace CourseManagement
{
    internal class CourseService
    {
        public static List<Group> Groups = new List<Group>();
        public static List<Student> Students = new List<Student>(); 

        private static int pGroupCounter = 127;
        private static int sGroupCounter = 334;
        private static int dGroupCounter = 101;

        private int Limit;

        public bool CanAddStudent() => Students.Count < Limit;
        public void CreateGroup()
        {
            Console.WriteLine("Qrup kateqoriyasını seçin:");
            Console.WriteLine("1. Programming");
            Console.WriteLine("2. Design");
            Console.WriteLine("3. System Administration");

            int categoryChoice;
            while (!int.TryParse(Console.ReadLine(), out categoryChoice) || categoryChoice < 1 || categoryChoice > 3)
            {
                Console.WriteLine("Yanlış seçim. Yenidən cəhd edin.");
            }

            string groupNo = categoryChoice switch
            {
                1 => $"P{pGroupCounter++}",
                2 => $"D{sGroupCounter++}",
                3 => $"S{dGroupCounter++}",
                _ => throw new InvalidOperationException("Invalid category choice")
            };

            Console.WriteLine($"Yeni qrup nömrəsi: {groupNo}");

            Console.Write("Qrup online-dirmi? (true/false): ");
            bool isOnline;
            while (!bool.TryParse(Console.ReadLine(), out isOnline))
            {
                Console.Write("Yanlış giriş. Qrup online-dirmi? (true/false): ");
            }

            Groups.Add(new Group(groupNo, categoryChoice switch
            {
                1 => "Programming",
                2 => "Design",
                3 => "System Administration",
                _ => throw new InvalidOperationException("Invalid category choice")
            }, isOnline));

            Console.WriteLine("Qrup uğurla yaradıldı.");
        }
        public static void DisplayGroups(Group group)
        {
            if (Groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup mövcud deyil.");
                return;
            }

            Console.WriteLine("Mövcud qruplar:");
            Console.WriteLine("--------------------");
            foreach (var groups in Groups)
            {
                Console.WriteLine($"Nömrə: {groups.No}, Kateqoriya: {groups.Category}, Tələbə sayı: {groups.Students.Count}/{groups.Limit}");


            }
            Console.WriteLine("--------------------");
        }

        public bool AddStudent(Student student)
        {
            Group group = null;

            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].No == student.GroupNo)
                {
                    group = Groups[i];
                    break;
                }
            }

            if (group != null && group.CanAddStudent())
            {
                group.Students.Add(student);
                return true;
            }

            return false;
        }

        public void EditGroup()
        {
            Console.Write("Dəyişmək istədiyiniz qrup nömrəsini daxil edin: ");
            string oldNo = Console.ReadLine();

            Group group = null;
            foreach (var g in Groups)
            {
                if (g.No == oldNo)
                {
                    group = g;
                    break;
                }
            }

            if (group == null)
            {
                Console.WriteLine("Belə qrup tapılmadı.");
                return;
            }

            Console.Write("Yeni qrup nömrəsini daxil edin: ");
            string newNo = Console.ReadLine();

            if (Groups.Exists(g => g.No == newNo))
            {
                Console.WriteLine("Bu nömrəli qrup artıq mövcuddur.");
                return;
            }

            group.No = newNo;
            Console.WriteLine("Qrup nömrəsi uğurla dəyişdirildi.");
        }

        public void DisplayStudentsInGroup()
        {
            Console.Write("Hansı qrupdakı tələbələri görmək istəyirsiniz? (Qrup nömrəsini daxil edin): ");
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

            if (group == null)
            {
                Console.WriteLine("Belə qrup tapılmadı.");
                return;
            }

            Console.WriteLine("Tələbələr:");
            foreach (var student in group.Students)
            {
                Console.WriteLine($"{student.Name} {student.Surname}");
            }
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine("Bütün tələbələr:");
            foreach (var student in Students)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, Qrup: {student.GroupNo}, Online: {student.IsOnline}");
            }
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

        internal void DisplayGroup()
        {
            
        }
    }
}

