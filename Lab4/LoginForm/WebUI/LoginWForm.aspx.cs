using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;

namespace WebUI
{
    public partial class LoginWForm : System.Web.UI.Page
    {
        private readonly UserService _userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool isValid = _userService.Login(username, password);

            if (isValid)
            {
                // Redirect to Main Form (Ex 3)
                Response.Redirect("~/MainWForm.aspx");
            }
            else
            {
                lblMessage.Text = "Login failed.";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblMessage.Text = "";
        }
    }
}