using BAL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class CustomerWForm : System.Web.UI.Page
    {
        private readonly CustomerService _customerService = new CustomerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomerGrid();
            }
        }

        private void BindCustomerGrid()
        {
            List<Customer> customers = _customerService.GetAllCustomers();
            gvCustomers.DataSource = customers;
            gvCustomers.DataBind();
        }

        private void ClearFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _customerService.AddCustomer(customer);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Customer added successfully.";
                ClearFields();
                BindCustomerGrid();
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
                int id = int.Parse(txtId.Text.Trim());
                Customer customer = _customerService.GetCustomer(id);

                if (customer != null)
                {
                    txtName.Text = customer.Name;
                    txtEmail.Text = customer.Email;
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Customer not found.";
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
                Customer customer = new Customer
                {
                    Id = int.Parse(txtId.Text.Trim()),
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _customerService.UpdateCustomer(customer);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Customer updated successfully.";
                ClearFields();
                BindCustomerGrid();
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
                int id = int.Parse(txtId.Text.Trim());
                _customerService.DeleteCustomer(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Customer deleted successfully.";
                ClearFields();
                BindCustomerGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}