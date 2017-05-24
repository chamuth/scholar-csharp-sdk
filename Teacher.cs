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

        public static Classes GetClasses(string username)
        {
            return new Request<Classes>("teacher/" + username + "/classes").Send();
        }
    }
}
