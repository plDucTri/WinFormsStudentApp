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
    public partial class DepartmentsWForm : System.Web.UI.Page
    {
        private readonly DepartmentService _departmentService = new DepartmentService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            List<Department> departments = _departmentService.GetAllDepartments();
            gvDepartments.DataSource = departments;
            gvDepartments.DataBind();
        }

        private void ClearFields()
        {
            txtDepartmentID.Text = "";
            txtDepartmentName.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Department d = new Department
                {
                    DepartmentName = txtDepartmentName.Text.Trim()
                };
                _departmentService.AddDepartment(d);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Department added.";
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
                int id = int.Parse(txtDepartmentID.Text.Trim());
                Department d = _departmentService.GetDepartment(id);
                if (d != null)
                {
                    txtDepartmentName.Text = d.DepartmentName;
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Department not found.";
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
                Department d = new Department
                {
                    DepartmentID = int.Parse(txtDepartmentID.Text.Trim()),
                    DepartmentName = txtDepartmentName.Text.Trim()
                };
                _departmentService.UpdateDepartment(d);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Department updated.";
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
                int id = int.Parse(txtDepartmentID.Text.Trim());
                _departmentService.DeleteDepartment(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Department deleted.";
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