using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    public class Track
    {
        private string title;
        private double length;
        private string artist;
        private string album;
        private string URL;

        public Track(string theTitle, double theLength, string theArtist, string theAlbum)
        {
            title = theTitle;
            length = theLength;
            artist = theArtist;
            album = theAlbum;
            URL =
                //@"H:\My Documents\Computer science\github projects repo\Projects\music\music\library\" + title + @".mp3";
                @"C:\Users\geodu\OneDrive\Documents\Work\Computer science\Code\GitHub projects\Projects\music\music\library\" + title + @".mp3";
        }

        #region getters
        public string getTitle()
        {
            return title;
        }
        public double getLength()
        {
            return length;
        }
        public string getArtist()
        {
            return artist;
        }
        public string getAlbum()
        {
            return album;
        }
        public string getURL()
        {
            return URL;
        }
        #endregion getters

    }
}
