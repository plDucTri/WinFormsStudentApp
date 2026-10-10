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
    public partial class ProductWForm : System.Web.UI.Page
    {
        private readonly ProductService _productService = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductGrid();
            }
        }

        private void BindProductGrid()
        {
            List<Product> products = _productService.GetAllProducts();
            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        private void ClearFields()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = txtProductName.Text.Trim(),
                    Quantity = int.Parse(txtQuantity.Text.Trim()),
                    Price = int.Parse(txtPrice.Text.Trim())
                };

                _productService.AddProduct(product);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product added successfully.";
                ClearFields();
                BindProductGrid();
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
                int id = int.Parse(txtProductID.Text.Trim());
                Product product = _productService.GetProduct(id);

                if (product != null)
                {
                    txtProductName.Text = product.ProductName;
                    txtQuantity.Text = product.Quantity.ToString();
                    txtPrice.Text = product.Price.ToString();
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Product not found.";
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
                Product product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text.Trim()),
                    ProductName = txtProductName.Text.Trim(),
                    Quantity = int.Parse(txtQuantity.Text.Trim()),
                    Price = int.Parse(txtPrice.Text.Trim())
                };

                _productService.UpdateProduct(product);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product updated successfully.";
                ClearFields();
                BindProductGrid();
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
                int id = int.Parse(txtProductID.Text.Trim());
                _productService.DeleteProduct(id);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product deleted successfully.";
                ClearFields();
                BindProductGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}