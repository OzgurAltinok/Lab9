using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
    public class StudentNotFound : Exception
    {
        public StudentNotFound()
        {

        }

        public StudentNotFound(string name):base(String.Format("{0} Adlı ogrenci bulunamadi", name))
        {

        }

        public StudentNotFound(int no) : base(String.Format("{0} Numarali ogrenci bulunamadi", no))
        {

        }
    }
}
