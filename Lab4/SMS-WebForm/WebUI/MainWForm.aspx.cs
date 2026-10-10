using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class MainWForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                    lblWelcome.Text = "Welcome, " + Session["Username"].ToString() + "!";
                else
                    lblWelcome.Text = "Welcome!";
            }
        }
    }
}