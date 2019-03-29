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
    public partial class CreateStudentForm : Form
    {
        private StudentList students;
        private Library library;

        public CreateStudentForm(StudentList studentList, Library newLibrary)
        {
            library = newLibrary;
            students = studentList;
            InitializeComponent();
        }

        private void CreateStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            bool ready = true;

            if (firstNameTextBox.Text.Length < 1 || lastNameTextBox.Text.Length < 1 || ageTextBox.Text.Length < 1 || passwordTextBox.Text.Length < 1 || reenterPasswordTextBox.Text.Length < 1)
            {
                errorMessageLabel.Text = "Make sure you fill in all the boxes!";
                ready = false;
            }

            if (!firstNameTextBox.Text.All(char.IsLetter))
            {
                errorMessageLabel.Text = "First name must only contain letters!";
                ready = false;
            }

            if (!lastNameTextBox.Text.All(char.IsLetter))
            {
                errorMessageLabel.Text = "Last name must only contain letters!";
                ready = false;
            }

            try
            {
                Convert.ToInt32(ageTextBox.Text);
            }
            catch
            {
                errorMessageLabel.Text = "Age must be an integer!";
                ready = false;
            }

            if (passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                errorMessageLabel.Text = "Passwords do not match!";
                ready = false;
            }            

            if (ready)
            {
                students.addStudent(firstNameTextBox.Text, lastNameTextBox.Text, Convert.ToInt32(ageTextBox.Text), passwordTextBox.Text, library);
                //proceed
                PlaylistEditorForm newForm = new PlaylistEditorForm(students, students.getStudents()[students.getCount() - 1], library);
                this.Close();
                newForm.Show();
            }
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            updateUsernamePreviewLabel();
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            updateUsernamePreviewLabel();
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            updateUsernamePreviewLabel();
        }

        private void updateUsernamePreviewLabel()
        {
            if (firstNameTextBox.Text.Length > 0 && lastNameTextBox.Text.Length > 0 && ageTextBox.Text.Length > 0)
            {
                UsernamePreviewLabel.Text = firstNameTextBox.Text[0].ToString().ToUpper() + lastNameTextBox.Text[0].ToString().ToUpper() + ageTextBox.Text.ToString() + students.getCount().ToString();
            }
        }
    }
}

