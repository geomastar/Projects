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
    public partial class Form1 : Form
    {
        private Library library;
        private StudentList students;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Library library = new Library();
            students = new StudentList(library);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LogInForm newForm = new LogInForm(students, library);
            this.Hide();
            newForm.Show();
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            CreateStudentForm newForm = new CreateStudentForm(students, library);
            this.Hide();
            newForm.Show();
        }
    }
}
