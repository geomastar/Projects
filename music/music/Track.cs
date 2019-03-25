using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    class Track
    {
        private string title;
        private double length;
        private string artist;
        private string album;

        public Track(string theTitle, double theLength, string theArtist, string theAlbum)
        {
            title = theTitle;
            length = theLength;
            artist = theArtist;
            album = theAlbum;
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
        #endregion getters

    }
}
