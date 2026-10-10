<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentsWForm.aspx.cs" Inherits="WebUI.DepartmentsWForm" %>

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
            <h2>Department Management</h2>

            <asp:Label ID="lblDepartmentID" runat="server" Text="Department ID:"></asp:Label>
            <asp:TextBox ID="txtDepartmentID" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblDepartmentName" runat="server" Text="Department Name:"></asp:Label>
            <asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <br />
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/MainWForm.aspx" Text="Back to Main Menu"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
