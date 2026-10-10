using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebUI
{
    public partial class SupplierWForm : System.Web.UI.Page
    {
        private readonly SupplierService _supplierService = new SupplierService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSupplierGrid();
            }
        }

        private void BindSupplierGrid()
        {
            List<Supplier> suppliers = _supplierService.GetAllSuppliers();
            gvSuppliers.DataSource = suppliers;
            gvSuppliers.DataBind();
        }

        private void ClearFields()
        {
            txtSupplierID.Text = "";
            txtSupplierName.Text = "";
            txtProductName.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier
                {
                    SupplierName = txtSupplierName.Text.Trim(),
                    ProductName = txtProductName.Text.Trim()
                };

                _supplierService.AddSupplier(supplier);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Supplier added successfully.";
                ClearFields();
                BindSupplierGrid();
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
                int id = int.Parse(txtSupplierID.Text.Trim());
                Supplier supplier = _supplierService.GetSupplier(id);

                if (supplier != null)
                {
                    txtSupplierName.Text = supplier.SupplierName;
                    txtProductName.Text = supplier.ProductName;
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Supplier not found.";
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
                Supplier supplier = new Supplier
                {
                    SupplierID = int.Parse(txtSupplierID.Text.Trim()),
                    SupplierName = txtSupplierName.Text.Trim(),
                    ProductName = txtProductName.Text.Trim()
                };

                _supplierService.UpdateSupplier(supplier);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Supplier updated successfully.";
                ClearFields();
                BindSupplierGrid();
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
                int id = int.Parse(txtSupplierID.Text.Trim());
                _supplierService.DeleteSupplier(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Supplier deleted successfully.";
                ClearFields();
                BindSupplierGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}