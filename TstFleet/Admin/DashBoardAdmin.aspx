<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DashBoardAdmin.aspx.cs" Inherits="TstFleet.DashBoardAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Bootstrap -->
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
        media="screen" />
    <!-- Bootstrap -->
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=datepicker]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm-dd-yyyy",
                language: "tr",
                todayHighlight: true,
                endDate: "today",
                autoclose: true,
                orientation: "up"
            });
        });
    </script>
    <style>
        .navbar {
            position: fixed;
            padding: 3px 0px;
            border-radius: 0;
        }

        .mydatagrid {
            width: 100%;
            border: solid 5px black;
            min-width: 80%;
        }

        .header {
            background-color: #646464;
            font-family: Arial;
            color: White;
            border: none 0px transparent;
            height: 25px;
            text-align: center;
            font-size: 12px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            border: none 0px transparent;
        }

            .rows:hover {
                background-color: #ff8000;
                font-family: Arial;
                color: #fff;
                text-align: left;
            }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: transparent;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
            text-align-last: center;
            background: content-box;
            border: solid;
        }

        .mydatagrid th {
            padding: 5px;
        }

        table > tbody > tr > th {
            text-align: center;
            background: #d01f27;
            color: #ffffff;
            border: 2px solid #ededed;
        }
    </style>
    <div>
        <p style="color: black; font-size: large; text-align-last: center; margin-top: 5%;">
            Select Date
            <asp:TextBox ID="datepicker" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:Button ID="btnSubmit" class="btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
        </p>
    </div>
    <div class="container" style="width: 1475px">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive" style="background-color: whitesmoke; margin-top: 2%; box-shadow: 0 0 8px #000000;">
                    <div style="font-family: ui-monospace; padding: 5px 25px 0px 25px; background: darkcyan; color: black;">
                        <h4 style="border: ridge; width: fit-content;">Filters To Select
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Country_Changed">
                            <asp:ListItem Text="Select All" Value=""></asp:ListItem>
                            <asp:ListItem Text="Pick" Value="Pick"></asp:ListItem>
                            <asp:ListItem Text="Drop" Value="Drop"></asp:ListItem>
                        </asp:DropDownList>
                        </h4>
                    </div>
                    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="true" PageSize="50">
                        <Columns>
                            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />
                            <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly='true' />
                            <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" ReadOnly='true' />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Emp_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                            <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop/Pickup" ReadOnly='true' />
                            <asp:BoundField DataField="Time" HeaderText="Office Time" ReadOnly='true' />

                            <asp:TemplateField HeaderText="PickupTime" ItemStyle-Width="30">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PickupTime") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" type="time" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cab No">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CabNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Driver Info">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Driver_Info") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Emp Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpsts" runat="server" Text='<%# Eval("Emp_Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>







