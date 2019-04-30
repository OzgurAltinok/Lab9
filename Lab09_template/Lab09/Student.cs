using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab09
{
    [XmlInclude(typeof(BSc))]
    [XmlInclude(typeof(MSc))]
    [XmlInclude(typeof(PhD))]
    [Serializable]
    public abstract class Student
    {
        //Sadece get methodları olacak.
        private string name;
        private string surname;
        private int no;

        protected Student(string name, string surname, int no)
        {
            this.Name = name;
            this.Surname = surname;
            this.No = no;
        }

        protected Student()
        {

        }

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public int No { get { return no; } set { no = value; } }

        public override string ToString()
        {
            return "Ad:" + Name + " Soyad:" + Surname + " No:" + No + " Tip: " + this.GetType().Name;
        }

    }
}
