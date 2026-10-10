<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEnrollmentsWForm.aspx.cs" Inherits="WebUI.StudentEnrollmentsWForm" %>

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
            <h2>Student Enrollments</h2>

            <asp:Label ID="lblSelectCourse" runat="server" Text="Select Course:"></asp:Label>
            <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="true"
                              OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
            </asp:DropDownList>
            <br /><br />

            <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label>
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvEnrollments" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="true"></asp:GridView>
            <br />
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/MainWForm.aspx" Text="Back to Main Menu"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
