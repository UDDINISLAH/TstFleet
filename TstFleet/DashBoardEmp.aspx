<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="DashBoardEmp.aspx.cs" Inherits="TstFleet.DashBoardEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <asp:GridView ID="GridView1" CssClass="table-responsive" GridLines="None"  runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />
                <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" />
                <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="true" />
                <%--      <asp:BoundField DataField="Email_Address" HeaderText="Email_Address" />  --%>
                <%--  <asp:BoundField DataField="Department" HeaderText="Department" />  --%>
                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                <%--      <asp:BoundField DataField="Bussines_unit" HeaderText="Bussines_unit" />--%>
                <%--    <asp:BoundField DataField="Bussines_unit" HeaderText="Bussines_unit" /> --%>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("Time")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCities" runat="server">
                            <asp:ListItem Text="05:00 AM" Value="05:00 AM"></asp:ListItem>
                            <asp:ListItem Text="06:00 AM" Value="06:00 AM"></asp:ListItem>
                            <asp:ListItem Text="07:00 AM" Value="07:00 AM"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <%--  <asp:BoundField DataField="Gender" HeaderText="Gender" /> --%>
                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        <div>
            <asp:Label ID="lblresult" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
