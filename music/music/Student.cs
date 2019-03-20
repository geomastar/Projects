using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    class Student
    {
        string firstName;
        string lastName;
        int age;
        string username;
        string password;
        Playlist musicCollection;

        public Student(string newFirstName, string newLastName, int newAge, string newPassword, string newPasswordReentered)
        {
            firstName = newFirstName;
            lastName = newLastName;
            age = newAge;

            username = createUsername(newFirstName, newLastName, newAge);

            musicCollection = new Playlist(); 
        }

        private string createUsername(string theFirstName, string theLastName, int theAge)
        {
            string theUserName;
            theUserName = theFirstName[0] + theLastName[0] + theAge.ToString();
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
    }
}
