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
        private int count;
        private List<Student> students;
        private StreamReader sr;
        private StreamWriter sw;
        private string path;

        public StudentList()
        {
            path = 
                //@"H:\My Documents\Computer science\github projects repo\Projects\music\music\students.txt"
                @"C:\Users\geodu\OneDrive\Documents\Work\Computer science\Code\GitHub projects\Projects\music\music\students.txt";

            students = new List<Student>();

            sr = new StreamReader(path);
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split(',');
                string firstName = line[0];
                string lastName = line[1];
                int age = Convert.ToInt32(line[2]);
                string password = line[3];

                students.Add(new Student(firstName, lastName, age, password, count));

                count++;
            }

            sr.Close();
        }

        public void addStudent(string newFirstName, string newLastName, int newAge, string newPassword)
        {
            sw = new StreamWriter(path, append: true);

            sw.WriteLine("{0},{1},{2},{3}", newFirstName, newLastName, newAge, newPassword);
            sw.Close();

            students.Add(new Student(newFirstName, newLastName, newAge, newPassword, count));

            count++;
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

        public int getCount()
        {
            return count;
        }
    }
}
