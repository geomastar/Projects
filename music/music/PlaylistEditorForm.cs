using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace music
{
    public partial class PlaylistEditorForm : Form
    {
        private Student student;
        private Library library;

        public PlaylistEditorForm(Student theStudent, Library theLibrary)
        {
            student = theStudent;
            library = theLibrary;
            InitializeComponent();
        }

        private void PlaylistEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void addMusicButton_Click(object sender, EventArgs e)
        {

        }

        private void removeMusicButton_Click(object sender, EventArgs e)
        {

        }

        private void endButton_Click(object sender, EventArgs e)
        {

        }
    }
}
