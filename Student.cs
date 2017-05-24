using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar
{
    public sealed class Student
    {
        public int error { get; set; }
        public Information information { get; set; }

        public class Verify
        {
            public int error { get; set; }
            public string message { get; set; }
        }

        public static Verify VerifyStudent(string username, string password)
        {
            return new Request<Verify>("student/verify/u=" + username + "&p=" + password).Send();
        }

        public static Student GetInformation(string username)
        {
            return new Request<Student>("student/" + username).Send();
        }

        public static Classes GetClasses(string username)
        {
            return new Request<Classes>("student/" + username + "/classes").Send();
        }
    }
}
