<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsWForm.aspx.cs" Inherits="WebUI.StudentsWForm" %>

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
            <h2>Student Management</h2>

            <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label>
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblStudentName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox><br />

            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblYearOfEnroll" runat="server" Text="Year of Enroll:"></asp:Label>
            <asp:TextBox ID="txtYearOfEnroll" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblMajor" runat="server" Text="Major:"></asp:Label>
            <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblGPA" runat="server" Text="GPA:"></asp:Label>
            <asp:TextBox ID="txtGPA" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <br />
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/MainWForm.aspx" Text="Back to Main Menu"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
