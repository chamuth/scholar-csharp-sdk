using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar
{
    public class PaperWritten
    {
        public string error { get; set; }
        public int written { get; set; }
    }

    public class Paper
    {
        public int index { get; set; }
        public string name { get; set; }
        public int duration { get; set; }

        public PaperWritten VerifyWritten(int classindex, int index, string username)
        {
            //class/{classindex}/paper/verify/{index}/u={username}
            return new Request<PaperWritten>("class/" + classindex.ToString() + "/paper/verify/" + index.ToString() + "/u=" + username).Send();
        }
    }
}
