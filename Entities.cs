using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar
{
    public class Teacher
    {
        public int error { get; set; }
        public Information information { get; set; }

        public static Teacher GetInformation(string username)
        {
            return new Request<Teacher>("teacher/" + username).Send();
        }
    }

    public class Information
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }

    public sealed class Student
    {
        public class Verify
        {
            public int error { get; set; }
            public string message { get; set; }
        }

        public static Verify VerifyStudent(string username, string password)
        {
            return new Request<Verify>("student/verify/u=" + username + "&p" + password).Send();
        }
    }
    public class Class
    {
        public enum Grade
        {
            Grade1, Grade2, Grade3, Grade4, Grade5, Grade6, Grade7, Grade8, Grade9, OneYearToOL, TwoYearsToOL, OneYearToAL, TwoYearsToAL
        }

        public sealed class ClassInformation
        {
            public int error { get; set; }
            public Information information { get; set; }

            public class Information
            {
                public string name { get; set; }
                public string description { get; set; }
                public string category { get; set; }
                public string grade { get; set; }
                public string days { get; set; }
                public string time { get; set; }
                public string duration { get; set; }
                public string teacher { get; set; }
            }
        }

        public static ClassInformation GetInformation(int index)
        {
            return new Request<ClassInformation>("class/" + index.ToString()).Send();
        }

        public static ClassSearch SearchByTeacher(string teacher)
        {
            return new Request<ClassSearch>("class/search/teacher/" + teacher).Send();
        }

        public static ClassSearch SearchByCategory(int category)
        {
            return new Request<ClassSearch>("class/search/category/" + category.ToString()).Send();
        }

        public static ClassSearch SearchByGrade(Grade grade)
        {
            string _grade = "";

            switch (grade)
            {
                case Grade.Grade1:
                    _grade = "Grade 1";
                    break;
                case Grade.Grade2:
                    _grade = "Grade 2";
                    break;
                case Grade.Grade3:
                    _grade = "Grade 3";
                    break;
                case Grade.Grade4:
                    _grade = "Grade 4";
                    break;
                case Grade.Grade5:
                    _grade = "Grade 5";
                    break;
                case Grade.Grade6:
                    _grade = "Grade 6";
                    break;
                case Grade.Grade7:
                    _grade = "Grade 7";
                    break;
                case Grade.Grade8:
                    _grade = "Grade 8";
                    break;
                case Grade.Grade9:
                    _grade = "Grade 9";
                    break;
                case Grade.OneYearToOL:
                    _grade = (DateTime.Now.Year + 1).ToString() + " Ordinary Level";
                    break;
                case Grade.TwoYearsToOL:
                    _grade = (DateTime.Now.Year + 2).ToString() + " Ordinary Level";
                    break;
                case Grade.OneYearToAL:
                    _grade = (DateTime.Now.Year + 1).ToString() + " Advanced Level";
                    break;
                case Grade.TwoYearsToAL:
                    _grade = (DateTime.Now.Year + 2).ToString() + " Advanced Level";
                    break;
            }

            return new Request<ClassSearch>("class/search/grade/" + _grade).Send();
        }

        public static ClassSearch SearchByGrade(string grade)
        {
            return new Request<ClassSearch>("class/search/grade/" + grade.Replace(" ", "%20")).Send();
        }

        public sealed class ClassSearch
        {
            public int error { get; set; }
            public string[] results { get; set; }
        }

    }
}
