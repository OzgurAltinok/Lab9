using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
    [Serializable]
    public class University
    {
        private string name;
        private List<Student> students;


        public University(string name)
        {
            this.Name = name;
            this.Students = students;
        }

        public University()
        {

        }

        public List<Student> Students { get { return students; } set { students = value; } }
        public string Name { get { return name; } set { name = value; } }

        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public Student SearchStudent(string name)
        {
            return Students.First(x => x.Name == name);
        }


        public Student SearchStudent(int no)
        {
            return Students.First(x => x.No == no);
        }

    }
}
