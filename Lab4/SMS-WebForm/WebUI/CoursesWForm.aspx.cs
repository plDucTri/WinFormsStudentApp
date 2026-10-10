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
    public partial class CoursesWForm : System.Web.UI.Page
    {
        private readonly CourseService _courseService = new CourseService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            List<Course> courses = _courseService.GetAllCourses();
            gvCourses.DataSource = courses;
            gvCourses.DataBind();
        }

        private void ClearFields()
        {
            txtCourseID.Text = "";
            txtCourseName.Text = "";
            txtCredits.Text = "";
            txtDepartmentID.Text = "";
            txtInstructorID.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Course c = new Course
                {
                    CourseName = txtCourseName.Text.Trim(),
                    Credits = int.Parse(txtCredits.Text.Trim()),
                    DepartmentID = int.Parse(txtDepartmentID.Text.Trim()),
                    InstructorID = int.Parse(txtInstructorID.Text.Trim())
                };
                _courseService.AddCourse(c);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Course added.";
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
                int id = int.Parse(txtCourseID.Text.Trim());
                Course c = _courseService.GetCourse(id);
                if (c != null)
                {
                    txtCourseName.Text = c.CourseName;
                    txtCredits.Text = c.Credits.ToString();
                    txtDepartmentID.Text = c.DepartmentID.ToString();
                    txtInstructorID.Text = c.InstructorID.ToString();
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Course not found.";
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
                Course c = new Course
                {
                    CourseID = int.Parse(txtCourseID.Text.Trim()),
                    CourseName = txtCourseName.Text.Trim(),
                    Credits = int.Parse(txtCredits.Text.Trim()),
                    DepartmentID = int.Parse(txtDepartmentID.Text.Trim()),
                    InstructorID = int.Parse(txtInstructorID.Text.Trim())
                };
                _courseService.UpdateCourse(c);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Course updated.";
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
                int id = int.Parse(txtCourseID.Text.Trim());
                _courseService.DeleteCourse(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Course deleted.";
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