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
    public partial class InstructorsWForm : System.Web.UI.Page
    {
        private readonly InstructorService _instructorService = new InstructorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            List<Instructor> instructors = _instructorService.GetAllInstructors();
            gvInstructors.DataSource = instructors;
            gvInstructors.DataBind();
        }

        private void ClearFields()
        {
            txtInstructorID.Text = "";
            txtInstructorName.Text = "";
            txtDepartmentID.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Instructor i = new Instructor
                {
                    InstructorName = txtInstructorName.Text.Trim(),
                    DepartmentID = int.Parse(txtDepartmentID.Text.Trim())
                };
                _instructorService.AddInstructor(i);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Instructor added.";
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
                int id = int.Parse(txtInstructorID.Text.Trim());
                Instructor i = _instructorService.GetInstructor(id);
                if (i != null)
                {
                    txtInstructorName.Text = i.InstructorName;
                    txtDepartmentID.Text = i.DepartmentID.ToString();
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Instructor not found.";
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
                Instructor i = new Instructor
                {
                    InstructorID = int.Parse(txtInstructorID.Text.Trim()),
                    InstructorName = txtInstructorName.Text.Trim(),
                    DepartmentID = int.Parse(txtDepartmentID.Text.Trim())
                };
                _instructorService.UpdateInstructor(i);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Instructor updated.";
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
                int id = int.Parse(txtInstructorID.Text.Trim());
                _instructorService.DeleteInstructor(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Instructor deleted.";
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