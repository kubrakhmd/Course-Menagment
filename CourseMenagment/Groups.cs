using System.Text.RegularExpressions;

namespace CourseManagement
{
    using System;
    using System.Collections.Generic;

public class Group
{
    public string No { get; set; } // P127, S334 və s.
    public string Category { get; set; } // Programming, Design, System Administration
    public bool IsOnline { get; set; }
    public int Limit { get; private set; }
        public object Students { get; internal set; }

        public Group(string no, string category, bool isOnline)
    {
        No = no;
        Category = category;
        IsOnline = isOnline;
        Limit = isOnline ? 15 : 10; // Onlayn üçün 15, offline üçün 10
    }

    public void GetGroupInfo()
    {
        Console.WriteLine($"Qrup No: {No}, Kateqoriya: {Category}, Onlayn: {(IsOnline ? "Bəli" : "Xeyr")}, Tələbə sayı: {Students.Count}/{Limit}");
    }

    public bool AddStudent(Student student)
    {
        if (Students.Count < Limit)
        {
            Students.Add(student);
            return true;
        }
        Console.WriteLine("Bu qrupda tələbə limiti dolub.");
        return false;
    }

        internal bool CanAddStudent()
        {
            throw new NotImplementedException();
        }
    }


}