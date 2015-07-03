using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdministrationSystem
{
    public class BeheerTool
    {
        private Student[] students = new Student[10];
        private int volgnr;

        public Cursus NieuweCursus(string code)
        {
            return new Cursus(code);
            
        }

        public Student NieuweStudent(int number, string name, Cursus course)
        {
            return this.students[volgnr++] = new Student(number, name, course);
        }

        public string PrintAll()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < volgnr; i++)
            {
                Student student = students[i];
                string line = string.Format("{0} ({1}): {2}", student.Name, student.Number, student.CurrentlyFollowingCourse.Code);
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
