<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="DashBoardEmp.aspx.cs" Inherits="TstFleet.DashBoardEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--   <div>
        <h3><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3> 
    </div>--%>
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
            font-size: 16px;
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
                color: black;
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

        i, span {
            display: revert;
            color: black;
        }
    </style>
    <div style="padding: 0% 38% 3% 40%;">
        <p style="color: black; font-size: large; margin-left: -56%;">
            Select Date
            <asp:TextBox ID="datepicker" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:Button ID="btnSubmit" class="btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
        </p>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive" style="background-color: #fff; box-shadow: 0 0 8px #000000;">
                    <div style="font-family: ui-monospace; padding: 5px 25px 0px 25px; background: darkcyan; color: black;">
                        <h4 style="border: ridge; width: fit-content;">Filters To Select
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Country_Changed">
                            <asp:ListItem Text="Select All" Value=""></asp:ListItem>
                            <asp:ListItem Text="Pick" Value="Pick"></asp:ListItem>
                            <asp:ListItem Text="Drop" Value="Drop"></asp:ListItem>
                        </asp:DropDownList>
                        </h4>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AllowSorting="true" PageSize="50" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />
                            <%--   <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                            <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" ReadOnly='true' />
                            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="true" />--%>
                            <asp:BoundField DataField="Emp_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                            <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop_Pickup" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Time">
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
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblsts" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--   <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" DeleteText="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>"
                                CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" />--%>
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
