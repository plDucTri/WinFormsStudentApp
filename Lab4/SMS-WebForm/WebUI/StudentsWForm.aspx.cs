using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace WebUI
{
    public partial class StudentsWForm : System.Web.UI.Page
    {
        private readonly StudentService _studentService = new StudentService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            List<Student> students = _studentService.GetAllStudents();
            gvStudents.DataSource = students;
            gvStudents.DataBind();
        }

        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtDOB.Text = "";
            txtCity.Text = "";
            txtAge.Text = "";
            txtYearOfEnroll.Text = "";
            txtMajor.Text = "";
            txtGPA.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student
                {
                    StudentName = txtStudentName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtDOB.Text),
                    City = txtCity.Text.Trim(),
                    Age = int.Parse(txtAge.Text.Trim()),
                    YearOfEnroll = int.Parse(txtYearOfEnroll.Text.Trim()),
                    Major = txtMajor.Text.Trim(),
                    GPA = decimal.Parse(txtGPA.Text.Trim())
                };
                _studentService.AddStudent(s);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Student added.";
                ClearFields();
                BindGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtStudentID.Text.Trim());
                Student s = _studentService.GetStudent(id);
                if (s != null)
                {
                    txtStudentName.Text = s.StudentName;
                    txtDOB.Text = s.DateOfBirth.ToString("yyyy-MM-dd");
                    txtCity.Text = s.City;
                    txtAge.Text = s.Age.ToString();
                    txtYearOfEnroll.Text = s.YearOfEnroll.ToString();
                    txtMajor.Text = s.Major;
                    txtGPA.Text = s.GPA.ToString();
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Student not found.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student
                {
                    StudentID = int.Parse(txtStudentID.Text.Trim()),
                    StudentName = txtStudentName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtDOB.Text),
                    City = txtCity.Text.Trim(),
                    Age = int.Parse(txtAge.Text.Trim()),
                    YearOfEnroll = int.Parse(txtYearOfEnroll.Text.Trim()),
                    Major = txtMajor.Text.Trim(),
                    GPA = decimal.Parse(txtGPA.Text.Trim())
                };
                _studentService.UpdateStudent(s);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Student updated.";
                ClearFields();
                BindGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtStudentID.Text.Trim());
                _studentService.DeleteStudent(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Student deleted.";
                ClearFields();
                BindGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}