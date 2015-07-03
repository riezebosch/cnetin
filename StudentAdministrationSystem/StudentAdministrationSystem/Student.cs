using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdministrationSystem
{
    public class Student
    {

        public Student(int number, string name, Cursus course)
        {
            this.Number = number;
            this.Name = name;
            this.CurrentlyFollowingCourse = course;
        }
        public string Name { get; set; }

        public int Number { get; set; }

        public Cursus CurrentlyFollowingCourse { get; set; }
    }
}
