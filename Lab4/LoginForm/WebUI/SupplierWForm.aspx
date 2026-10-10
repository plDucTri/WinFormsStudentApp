<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierWForm.aspx.cs" Inherits="WebUI.SupplierWForm" %>

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
            <h2>Supplier Management</h2>

            <asp:Label ID="lblSupplierID" runat="server" Text="Supplier ID:"></asp:Label>
            <asp:TextBox ID="txtSupplierID" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name:"></asp:Label>
            <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvSuppliers" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <br />
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/MainWForm.aspx" Text="Back to Main Menu"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
