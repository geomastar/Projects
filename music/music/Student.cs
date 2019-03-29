using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private int count;
        public List<string> tracks;
        private Playlist musicCollection;

        public Student(string newFirstName, string newLastName, int newAge, string newPassword, int newCount, List<string> theTracks, Library library)
        {
            firstName = newFirstName;
            lastName = newLastName;
            age = newAge;
            password = newPassword;
            count = newCount;
            tracks = theTracks;

            username = createUsername(newFirstName, newLastName, newAge, newCount);

            if (tracks.Count > 0)
            {
                if (tracks[0] != "")
                {
                    addPlaylist(library, theTracks);
                }
                else
                {
                    musicCollection = new Playlist();
                }
            }
            else
            {
                musicCollection = new Playlist();
            }
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

        public void addPlaylist(Library library, List<String> tracks)
        {
            musicCollection = new Playlist();

            foreach (string s in tracks)
            {
                musicCollection.getCollection().Add(library.getCollection()[Convert.ToInt32(s)]);
            }
        }

        public void addTrack(string theTrack)
        {
            tracks.Add(theTrack);
        }

        public string getUsername()
        {
            return username;
        }

        public List<string> getTracks()
        {
            return tracks;
        }
        public void setTracks(List<string> theTracks)
        {
            tracks = theTracks;
        }

        public Playlist getPlaylist()
        {
            return musicCollection;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public int getAge()
        {
            return age;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
