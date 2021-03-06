﻿using System;
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
    public partial class LogInForm : Form
    {
        private StudentList students;
        private Library library;

        public LogInForm(StudentList studentList, Library newLibrary)
        {
            library = newLibrary; 
            students = studentList;
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int index = students.searchList(usernameTextBox.Text);

            if (index > -1)
            {
                if (students.getStudents()[index].checkPassword(passwordTextBox.Text))
                {
                    //proceed
                    PlaylistEditorForm newForm = new PlaylistEditorForm(students, students.getStudents()[index], library);
                    this.Close();
                    newForm.Show();
                }
                else
                {
                    //wrong password
                    errorMessageLabel.Text = "Incorrect Password!";
                }
            }
            else
            {
                //wrong username
                errorMessageLabel.Text = "Incorrect Username!";
            }
        }
    }
}
