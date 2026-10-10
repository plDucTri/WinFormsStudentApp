<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWForm.aspx.cs" Inherits="WebUI.MainWForm" %>

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
            <h2>Main Menu</h2>

            <asp:Label ID="lblWelcome" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
            <br /><br />

            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
                      StaticDisplayLevels="2" BackColor="#FFFBFF" 
                      BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px">
                <Items>
                    <asp:MenuItem Text="Customers" NavigateUrl="~/CustomerWForm.aspx" />
                    <asp:MenuItem Text="Products" NavigateUrl="~/ProductWForm.aspx" />
                    <asp:MenuItem Text="Suppliers" NavigateUrl="~/SupplierWForm.aspx" />
                    <asp:MenuItem Text="Logout" NavigateUrl="~/LoginWForm.aspx" />
                </Items>
            </asp:Menu>

            <br /><br />
            <asp:Label ID="lblInfo" runat="server" Text="Select a module from the menu above."></asp:Label>
        </div>
    </form>
</body>
</html>
