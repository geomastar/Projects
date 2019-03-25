using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string username;
        private string password;
        private Playlist musicCollection;

        public Student(string newFirstName, string newLastName, int newAge, string newPassword, int count)
        {
            firstName = newFirstName;
            lastName = newLastName;
            age = newAge;
            password = newPassword;

            username = createUsername(newFirstName, newLastName, newAge, count);

            musicCollection = new Playlist(); 
        }

        private string createUsername(string theFirstName, string theLastName, int theAge, int count)
        {
            string theUserName;
            theUserName = theFirstName[0].ToString().ToUpper() + theLastName[0].ToString().ToUpper() + theAge.ToString() + count.ToString();
            return theUserName;
        }

        public bool checkPassword(string thePassword)
        {
            if (password == thePassword)
            {
                return true;
            }
            else { return false; }
        }

        public string getUsername()
        {
            return username;
        }
    }
}
