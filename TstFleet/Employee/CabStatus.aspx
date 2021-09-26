<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="CabStatus.aspx.cs" Inherits="TstFleet.CabStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Welcome:
     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </h3>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <%-- <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />--%>
                            <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                            <%--<asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" ReadOnly='true' />--%>
                            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="true" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                            <asp:BoundField DataField="PickupTime" HeaderText="Pickup Time" ReadOnly="true" />

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblsts" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cab Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Eval("Emp_Status")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCities" runat="server">
                                        <asp:ListItem Text="In The Cab" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="Cab Cancel" Value="No"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                           <asp:CommandField HeaderText="Confirmation" ShowEditButton="true" EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>"
CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>"/>
                               <%--  <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />--%>
                        </Columns>

                    </asp:GridView>
                    <div>
                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
