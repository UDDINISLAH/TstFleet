<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ScheduleCab.aspx.cs" Inherits="TstFleet.ScheduleCab" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>

   <script type="text/javascript">     
        $(function () {
            $("[id*=GridView1]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });
       function openModal() {
         // debugger
        $('#myModal').modal('show');
    }
    </script>

    <style>
        html, body {
            font-family: Verdana,sans-serif;
            font-size: 13px;
            line-height: 1.5;
        }

        .HiddenCol {
            display: none;
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

        .navbar {
            position: fixed;
            min-height: 50px;
            margin-bottom: 20px;
            border: 1px solid transparent;
            padding: 0px 0px;
        }

        .close {
            float: right;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #000;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: 1.2;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container" style="width: 100%;">
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
                        <%--  <div>
                            Search Customer:
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" />
                        </div>--%>
                        <div>
                            <h1 style="text-align: -WEBKIT-CENTER; color: BLACK; font-variant: all-petite-caps; margin-top: -46px;">Cab Requisite<asp:Button ID="Button1" runat="server" Text="Export Excel" OnClick="Button1_Click" CssClass="btn btn-primary" Style="margin-top: -2%; margin-left: auto; display: -WEBKIT-BOX; font-size: large; background: #cf1f27; color: black; font-weight: bolder; border: outset;" /></h1>
                        </div>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AllowSorting="true" PageSize="50" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Employee_ID" HeaderText="Emp ID" ReadOnly="true" />
                            <asp:BoundField DataField="Employee_Name" HeaderText="Emp Name" ReadOnly="true" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly='true' />
                            <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile" ReadOnly='true' />
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lbladd" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtadd" runat="server" Text='<%# Eval("Address") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Emp_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Emp Status">
                                <ItemTemplate>
                                    <asp:Label ID="DropPickup" runat="server" Text='<%# Eval("Drop_Pickup")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Time" HeaderText="OfficeTime" ReadOnly='true' />
                            <asp:TemplateField HeaderText="PickupTime" ItemStyle-Width="30">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PickupTime") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" type="time" runat="server" Text='<%# Bind("PickupTime") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" ItemStyle-Width="30">
                                <HeaderStyle CssClass="HiddenCol" />
                                <ItemStyle HorizontalAlign="Right" CssClass="HiddenCol" />
                                <ItemTemplate>
                                    <input type="hidden" name="LocationId" value='<%# Eval("Id") %>' />
                                </ItemTemplate>
                                <FooterStyle CssClass="HiddenCol" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cab No">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="" CssClass="btn btn-info"  OnClientClick="openModal();return false;" OnClick="Display" >
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CabNo") %>' Style="background-color: #fbff00; color: #000000;"></asp:Label>
                                    </asp:LinkButton>
                                    <%--   <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cab_Number") %>'></asp:Label>--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Driver Info">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Driver_Info") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Emp Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpsts" runat="server" Text='<%# Eval("Emp_Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--    <asp:TemplateField HeaderText="Pay">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Pay Now" CssClass="btn btn-info" OnClick="Display"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" Visible="true" EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" ControlStyle-BackColor="transparent" />

                            <%--  <asp:CommandField HeaderText="Update" ShowEditButton="true" />--%>
                            <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />--%>
                        </Columns>
                    </asp:GridView>
                    <%--  <asp:Button ID="allo" Text="Allow Dragging" CssClass="btn btn-primary" runat="server" OnClick="Dragging_Click" Style="margin: 1%; padding: 12PX; display: -WEBKIT-BOX;" />--%>
                    <asp:Button Text="Update Order" CssClass="btn btn-primary" runat="server" OnClick="UpdatePreference" Style="margin: 1%; padding: 12PX; display: -WEBKIT-BOX;" />
                </div>
            </div>
        </div>
    </div>
    <div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: max-content; background: darkslategray;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title" style="background: #d01f27; font-size: x-large; text-align: -webkit-center; color: aliceblue;">Cab Status oF Employee</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group" style="background: yellowgreen; font-size: x-large; text-align: -webkit-center;">
                                <asp:Label ID="lblstudent" runat="server" Text="Cab No: "></asp:Label>
                                <asp:Label ID="lblstudentid" runat="server" Text="" Style="background: yellow; color: black; border-style: DOUBLE;"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:GridView ID="GridView2" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" DataKeyNames="id">
                                    <Columns>
                                        <asp:BoundField DataField="Employee_ID" HeaderText="Emp ID" />
                                        <asp:BoundField DataField="Employee_Name" HeaderText="Emp Name" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="PickupTime" HeaderText="PickupTime" />
                                        <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop Pickup" />
                                        <asp:BoundField DataField="Driver_Info" HeaderText="Driver Info" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%--      <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Time"></asp:Label>
                                <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblAmount" runat="server" Text="Time"></asp:Label>
                                <asp:TextBox ID="txtAmount" runat="server" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter Amount"></asp:TextBox>
                            </div>--%>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--  <asp:Button ID="btnSave" runat="server" Text="Pay" CssClass="btn btn-info" />--%>
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- <div class="container">
        <h2>Modal Example</h2>
        <!-- Trigger the modal with a button -->
        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal1">Open Modal</button>

        <!-- Modal -->
        <div class="modal fade" id="myModal1" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                   <div class="modal-content" style="width: max-content; background: darkslategray;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title" style="background: #d01f27; font-size: x-large; text-align: -webkit-center; color: aliceblue;">Cab Status oF Employee</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group" style="background: yellowgreen; font-size: x-large; text-align: -webkit-center;">
                                <asp:Label ID="Label1" runat="server" Text="Cab No: "></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="" Style="background: yellow; color: black; border-style: DOUBLE;"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:GridView ID="GridView2" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" DataKeyNames="id">
                                    <Columns>
                                        <asp:BoundField DataField="Employee_ID" HeaderText="Emp ID" />
                                        <asp:BoundField DataField="Employee_Name" HeaderText="Emp Name" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="PickupTime" HeaderText="PickupTime" />
                                        <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop Pickup" />
                                        <asp:BoundField DataField="Driver_Info" HeaderText="Driver Info" />
                                    </Columns>
                                </asp:GridView>
                            </div>                         
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
