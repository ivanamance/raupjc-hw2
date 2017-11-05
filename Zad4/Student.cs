using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            Student s = (Student)obj;
            if (s.Jmbag == Jmbag)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Int32.Parse(Jmbag);
        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            if (obj1.Jmbag == obj2.Jmbag)
                return true;
            return false;
        }

        public static bool operator !=(Student obj1, Student obj2)
        {

            return !obj1.Equals(obj2);
        }

        void Case1()
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Luka ", jmbag :" 3274272 "),
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");

            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
        }
        void Case2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
        }
        void Case3()
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Luka ", jmbag :" 3274272 "),
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
        }
        
    }

    public enum Gender
    {
        Male,
        Female
    }

   
}
