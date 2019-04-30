using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab09
{
    [Serializable]
    public class BSc : Student
    {
        public BSc(string name, string surname, int no) : base(name, surname, no)
        {

        }

        public BSc()
        {

        }

    }
}
