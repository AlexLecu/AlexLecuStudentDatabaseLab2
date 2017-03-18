using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDatabaseV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private Student retrieveStudentInformation()
        {
            Student student = new Student();
            student.ID = Convert.ToInt32(txtStudentID.Text);
            student.Name = txtStudentName.Text;
            student.BirthDate = dtStudentBirthdate.Value;
            student.Address = txtStudentAddress.Text;
            return student;
        }

        private Course retrieveCourseInformation()
        {
            Course course = new Course();
            course.ID = Convert.ToInt32(txtCourseID.Text);
            course.name = txtCourseName.Text;
            course.teacher = txtCourseTeacher.Text;
            if(txtCourseStudyYear.Text.Equals(string.Empty))
            {
                course.studyYear = 0;
            } else course.studyYear = Convert.ToInt32(txtCourseStudyYear.Text);

            return course;
        }

        private void emptyControlsStudent()
        {
            txtStudentID.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            dtStudentBirthdate.Value = DateTime.Now;
            txtStudentAddress.Text = string.Empty;
           // gridStudents.SelectedRows[0].Selected = false;
        }

        private void emptyControlsCourse()
        {
            txtCourseID.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            txtCourseTeacher.Text = string.Empty;
            txtCourseStudyYear.Text = string.Empty;
            // gridStudents.SelectedRows[0].Selected = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(radioButtonStudent.Checked)
            {
                try
                {
                    Student student = retrieveStudentInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.AddStudent(student);
                    emptyControlsStudent();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if (radioButtonCourse.Checked)
            {
                try
                {
                    Course course = retrieveCourseInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.AddCourse(course);
                    emptyControlsCourse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                try
                {
                    Student student = retrieveStudentInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.DeleteStudent(student);
                    emptyControlsStudent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if(radioButtonCourse.Checked)
            {
                try
                {
                    Course course = retrieveCourseInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.DeleteCourse(course);
                    emptyControlsCourse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                try
                {
                    MySQLDBManager db = new MySQLDBManager();

                    gridStudents.DataSource = db.retrieveStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if(radioButtonCourse.Checked)
            {
                try
                {
                    MySQLDBManager db = new MySQLDBManager();

                    gridCourses.DataSource = db.retrieveCourses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(radioButtonStudent.Checked)
            {
                try
                {
                    Student student = retrieveStudentInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.UpdateStudent(student);
                    emptyControlsStudent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if(radioButtonCourse.Checked)
            {
                try
                {
                    Course course = retrieveCourseInformation();

                    MySQLDBManager db = new MySQLDBManager();
                    db.UpdateCourse(course);
                    emptyControlsCourse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
