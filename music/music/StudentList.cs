using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    public class StudentList
    {
        private List<Student> students;
        private StreamReader sr;

        public StudentList(string path)
        {
            students = new List<Student>();

            sr = new StreamReader(path);
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split(',');
                string firstName = line[0];
                string lastName = line[1];
                int age = Convert.ToInt32(line[2]);
                string password = line[3];

                students.Add(new Student(firstName, lastName, age, password, password));
            }
        }

        public int searchList(string username)
        {
            foreach(Student student in students)
            {
                if (student.getUsername() == username)
                {
                    return students.IndexOf(student);
                }
            }

            return -1;
        }


        public List<Student> getStudents()
        {
            return students;
        }
    }
}
