using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    public class Playlist
    {        
        internal List<Track> collection;

        public Playlist()
        {
            collection = new List<Track>();
        }
        /*
        public Track searchCollection(string title)
        {

        }
        */
        public List<Track> getCollection()
        {
            return collection;
        }        
    }

    public class Library : Playlist
    {
        private string path;
        private StreamReader sr;
        private StreamWriter sw;

        public Library()
        {
            path =
                //@"H:\My Documents\Computer science\github projects repo\Projects\music\music\library.txt";
                @"C:\Users\geodu\OneDrive\Documents\Work\Computer science\Code\GitHub projects\Projects\music\music\library.txt";

            collection = new List<Track>();

            sr = new StreamReader(path);
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split(',');
                string title = line[0];
                double length = Convert.ToDouble(line[1]);
                string artist = line[2];
                string album = line[3];

                collection.Add(new Track(title, length, artist, album));
            }

            sr.Close();
        }
    }
}
