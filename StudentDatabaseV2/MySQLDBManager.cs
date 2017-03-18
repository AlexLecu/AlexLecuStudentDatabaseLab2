using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentDatabaseV2
{
    public class MySQLDBManager
    {
        private string connString;

        public MySQLDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Student> retrieveStudents()
        {
            IList<Student> studentList = new List<Student>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM student";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.ID = reader.GetInt32("studentID");
                        student.Name = reader.GetString("name");
                        student.BirthDate = reader.GetDateTime("birthdate");
                        student.Address = reader.GetString("address");
                        studentList.Add(student);
                    }
                }
            }

            return studentList;
        }

        public IList<Course> retrieveCourses()
        {
            IList<Course> courseList = new List<Course>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM course";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Course course = new Course();
                        course.ID = reader.GetInt32("courseID");
                        course.name = reader.GetString("name");
                        course.teacher = reader.GetString("teacher");
                        course.studyYear = reader.GetInt32("study_year");
                        courseList.Add(course);
                    }
                }
            }

            return courseList;
        }

        public void AddStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO student(studentID, name, birthdate, address) VALUES(@studentID, @name, @birthdate, @address)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@studentID", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@birthdate", student.BirthDate);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM student WHERE studentID=@studentID";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@studentID", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@birthdate", student.BirthDate);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE student SET name = @name, birthdate = @birthdate, address= @address  WHERE studentID = @studentID;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@studentID", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@birthdate", student.BirthDate);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO course(courseID, name, teacher, study_year) VALUES(@courseID, @name, @teacher, @study_year)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@courseID", course.ID);
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@teacher", course.teacher);
                cmd.Parameters.AddWithValue("@study_year", course.studyYear);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM course WHERE courseID=@courseID";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@courseID", course.ID);
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@teacher", course.teacher);
                cmd.Parameters.AddWithValue("@study_year", course.studyYear);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE course SET name = @name, teacher = @teacher, study_year= @study_year  WHERE courseID = @courseID;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@courseID", course.ID);
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@teacher", course.teacher);
                cmd.Parameters.AddWithValue("@study_year", course.studyYear);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
