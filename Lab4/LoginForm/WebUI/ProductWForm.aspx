<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductWForm.aspx.cs" Inherits="WebUI.ProductWForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; top: 10px; right: 15px; 
            font-size: 20px; font-weight: bold; color: #555;">
            Developed by Pham Le Duc Tri
        </div>
        <div>
            <h2>Product Management</h2>

            <asp:Label ID="lblProductID" runat="server" Text="Product ID:"></asp:Label>
            <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <br />
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/MainWForm.aspx" Text="Back to Main Menu"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
