using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class StudentEnrollmentsWForm : System.Web.UI.Page
    {
        private readonly StudentCourseService _studentCourseService = new StudentCourseService();
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolConn"].ConnectionString;

            if (!IsPostBack)
            {
                LoadCourses();
                LoadData();
            }
        }

        private void LoadCourses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCourses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                ddlCourses.DataSource = table;
                ddlCourses.DataTextField = "CourseName";
                ddlCourses.DataValueField = "CourseID";
                ddlCourses.DataBind();

                ddlCourses.Items.Insert(0, new ListItem("-- Select a Course --", "0"));
            }
        }

        private void LoadData()
        {
            if (ddlCourses.SelectedValue != null && ddlCourses.SelectedValue != "0")
            {
                int courseId = Convert.ToInt32(ddlCourses.SelectedValue);
                var enrollments = _studentCourseService.GetEnrollmentsByCourse(courseId);
                gvEnrollments.DataSource = enrollments;
                gvEnrollments.DataBind();
            }
            else
            {
                gvEnrollments.DataSource = null;
                gvEnrollments.DataBind();
            }
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCourses.SelectedValue != "0" && !string.IsNullOrEmpty(txtStudentID.Text))
                {
                    int studentId = int.Parse(txtStudentID.Text.Trim());
                    int courseId = Convert.ToInt32(ddlCourses.SelectedValue);

                    _studentCourseService.AddEnrollment(studentId, courseId);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Enrollment added.";
                    txtStudentID.Text = "";
                    LoadData();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please select a course and enter a student ID.";
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
                if (gvEnrollments.SelectedRow != null && ddlCourses.SelectedValue != "0")
                {
                    int studentId = int.Parse(gvEnrollments.SelectedRow.Cells[1].Text);
                    int newCourseId = Convert.ToInt32(ddlCourses.SelectedValue);

                    _studentCourseService.UpdateEnrollment(studentId, newCourseId);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Enrollment updated.";
                    LoadData();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please select an enrollment row to update.";
                }
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
                if (gvEnrollments.SelectedRow != null)
                {
                    int studentId = int.Parse(gvEnrollments.SelectedRow.Cells[0].Text);
                    _studentCourseService.DeleteEnrollment(studentId);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Enrollment deleted.";
                    LoadData();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please select an enrollment row to delete.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}