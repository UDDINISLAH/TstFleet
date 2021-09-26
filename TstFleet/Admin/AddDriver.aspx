<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddDriver.aspx.cs" Inherits="TstFleet.AddDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center">
            <tr>
                <td colspan="2">
                    <h3>Registration page for Driver</h3>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Driver Name:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_DriverName" runat="server" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mobile:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_Mobile"  runat="server" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Email:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Driver Address:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server"
                        Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Cab Model:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Cab_model" runat="server" Width="150px" OnTextChanged="Cab_model_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Cab Number:" Font-Bold="True" Width="100px" BackColor="#FFFF66" ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="cab_number" runat="server"
                        Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btn_register" runat="server" BackColor="#CCFF99" Text="Register"
                        OnClick="btn_register_Click" />
                </td>
               <%-- <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx"
                        ForeColor="#663300">Click here to Login</asp:HyperLink>
                   </td>--%>
            </tr>

            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td align="center" colspan="2">
                    <asp:TextBox ID="Sessiontxt" runat="server"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
    </div>

</asp:Content>
