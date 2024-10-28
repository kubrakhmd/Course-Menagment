using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseMenagment
{
    internal class Group
    {
        public string No { get; set; }
        public GroupCategory Category { get; set; }
        public bool IsOnline { get; set; }
        private int limit;
        public int Limit
        {
            get
            {
                return IsOnline ? 15 : 10;
            }
        }

        public List<Student> Students { get; set; }

        public Group(string no, GroupCategory category, bool isOnline)
        {
            No = no;
            Category = category;
            IsOnline = isOnline;
            Students = new List<Student>();
        }

        public Group(string groupNo, string v, bool isOnline)
        {
            this.groupNo = groupNo;
            this.v = v;
            IsOnline = isOnline;
        }

        public bool AddStudent(Student student)
        {
            if (Students.Count < Limit)
            {
                Students.Add(student);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{No} ({Category}, {(IsOnline ? "Online" : "Offline")}, Students: {Students.Count}/{Limit})";
        }
        static int pGroupCounter = 127;
        static int sGroupCounter = 334;
        static int dGroupCounter = 101;
        private string groupNo;
        private string v;


        public bool CanAddStudent()
        {
            return Students.Count < (IsOnline ? 15 : 10);
        }
    }
}
