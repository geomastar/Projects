using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace music
{
    public partial class PlaylistEditorForm : Form
    {
        private StudentList students;
        private Student student;
        private Library library;

        public PlaylistEditorForm(StudentList theStudents, Student theStudent, Library theLibrary)
        {
            students = theStudents;
            student = theStudent;
            library = theLibrary;
            InitializeComponent();
        }

        private void PlaylistEditorForm_Load(object sender, EventArgs e)
        {
            fillListBoxes();
        }

        private void addMusicButton_Click(object sender, EventArgs e)
        {
            foreach(int indexChecked in libraryCheckedListBox.CheckedIndices)
            {
                student.addTrack(indexChecked.ToString());
                if (student.getPlaylist() != null)
                {
                    student.getPlaylist().getCollection().Add(library.getCollection()[indexChecked]);
                }
                else
                {
                    List<string> newList = new List<string>();
                    newList.Add(indexChecked.ToString());
                    student.addPlaylist(library, newList);
                }
            }

            fillListBoxes();
        }

        private void removeMusicButton_Click(object sender, EventArgs e)
        {
            int adder = 0;

            foreach (int indexChecked in playlistCheckedListBox.CheckedIndices)
            {
                student.getTracks().RemoveAt(indexChecked - adder);
                student.getPlaylist().getCollection().RemoveAt(indexChecked - adder);

                adder++;
            }

            fillListBoxes();
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            students.writeStudentsToFile();

            Application.Exit();
        }

        private void fillListBoxes()
        {
            libraryCheckedListBox.Items.Clear();
            playlistCheckedListBox.Items.Clear();

            foreach (Track t in library.getCollection())
            {
                libraryCheckedListBox.Items.Add(t.getTitle() + ",   " + t.getLength() + ",   " + t.getArtist() + ",   " + t.getAlbum(), 0);
            }

            if (student.getPlaylist() != null)
            {
                foreach (Track t in student.getPlaylist().getCollection())
                {
                    playlistCheckedListBox.Items.Add(t.getTitle() + ",   " + t.getLength() + ",   " + t.getArtist() + ",   " + t.getAlbum(), 0);
                }
            }

            double totalLength = 0;

            foreach(Track t in student.getPlaylist().getCollection())
            {
                totalLength += t.getLength();
            }

            totalLengthLabel.Text = "Total Length: " + totalLength + " minutes";
        }

        private void PlaySelectedButton_Click(object sender, EventArgs e)
        {
            int adder = 0;

            foreach (int indexChecked in playlistCheckedListBox.CheckedIndices)
            {
                if (adder == 0)
                {
                    musicPlayer.URL = student.getPlaylist().getCollection()[indexChecked].getURL();
                    Debug.WriteLine(student.getPlaylist().getCollection()[indexChecked].getURL());
                }

                adder++;
            }
        }
    }
}
