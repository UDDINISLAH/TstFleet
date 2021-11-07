<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="CabStatus.aspx.cs" Inherits="TstFleet.CabStatus" %>

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
            $('[id*=txtDate]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd-mm-yyyy",
                language: "tr",
                todayHighlight: true,
                endDate: "today",
                autoclose: true,
                orientation: "up"
            });
        });
    </script>
    <%--<div class="cal" style="">
        <p style="color: black; font-size: large; margin-left: -56%;">
            Select Date
            <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" Style="margin: 28px 0; box-sizing: border-box; width: 37%; padding: 1px;"></asp:TextBox>
            <asp:Button ID="btnSubmit" class="btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </p>
    </div>--%>
    <%--<div>
        <h3><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3> 
    </div>--%>
    <%--  <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive" style="background-color: #fff; box-shadow: 0 0 8px #000000;">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                            <asp:BoundField DataField="Time" HeaderText="OfficeTime" ReadOnly="true" />
                            <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop/Pickup" ReadOnly="true" />
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
                            <asp:CommandField HeaderText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" ShowEditButton="true" EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>"
                                CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" />
                            <%--  <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <div class="container">
        <div class="row">
            <div class="colums">
                <asp:Panel ID="Panel1" runat="server" visible="false">
                    <div class="card">
                        <div style="width: auto; margin: auto; color: black;">
                            <h1>Request Status for Pickup</h1>                         
                            <asp:Label ID="Label1" runat="server" Style="font-size: x-large; font-weight: bolder; background: yellow;border-style: solid;"></asp:Label>

                            <div class="grid-container">
                                <div>Office Time</div>
                                <div>Cab Time</div>
                                <div>Status</div>
                                <div>My Status</div>
                                <div>Cab No</div>
                                <div>Driver Info</div>
                                <div>
                                    <asp:Label ID="TextBox1" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox2" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox3" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox4" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbl1" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbl2" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                            </div>

                            <div style="font-size: XX-LARGE;">
                                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="YES" Visible="false" OnClick="Button1_Click" Style="font-size: 20PX;" />
                                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="No" Visible="false" OnClick="Button2_Click" Style="font-size: 20PX;" />
                            </div>

                            <div class="grid-container" style="width: fit-content;margin: auto;margin-top: 5px;">
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                    <Columns>
                                        <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="Emp_Status" HeaderText="Employee Status" />
                                        <asp:BoundField DataField="PickupTime" HeaderText="Pickup Time" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="Panel2" runat="server" visible="false">
                    <div class="card">
                        <div style="width: auto; margin: auto; color: black;">
                            <h1>Request Status for Drop</h1>
                            <asp:Label ID="Label2" runat="server" Style="font-size: x-large; font-weight: bolder; background: yellow;border-style: solid;"></asp:Label>

                           <div class="grid-container">
                                <div>Office Time</div>
                                <div>Cab Time</div>
                                <div>Status</div>
                                <div>My Status</div>
                                <div>Cab No</div>
                                <div>Driver Info</div>
                                <div>
                                    <asp:Label ID="TextBox5" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox6" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox7" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="TextBox8" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbl3" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbl4" runat="server" Style="text-align: center;"></asp:Label>
                                </div>
                              <%--  <div>
                                    <asp:Label ID="lbl5" runat="server" Style="text-align: center;"></asp:Label>
                                </div>--%>
                            </div>
                            <div style="font-size: XX-LARGE;">
                                <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="YES" Visible="false" OnClick="Button3_Click" Style="font-size: 20PX;" />
                                <asp:Button ID="Button4" class="btn btn-danger" runat="server" Text="No" Visible="false" OnClick="Button4_Click" Style="font-size: 20PX;" />
                            </div>

                           <div class="grid-container" style="width: fit-content;margin: auto;margin-top: 5px;"">
                                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                        <Columns>
                                            <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" />
                                            <asp:BoundField DataField="Emp_Status" HeaderText="Employee Status" />
                                            <asp:BoundField DataField="PickupTime" HeaderText="Pickup Time" />
                                        </Columns>
                                    </asp:GridView>                               
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <style>
        .table-bordered > thead > tr > th, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > tbody > tr > td, .table-bordered > tfoot > tr > td {
            border: 1px solid #6a6a6a;
        }

        input[type=text] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
        }

        .grid-container {
            display: grid;
            grid-template-columns: auto auto auto auto auto auto;
            grid-gap: 2px;
            background-color: #365770;
            padding: 8px;
        }

            .grid-container > div {
                background-color: rgba(255, 255, 255, 0.8);
                border: 1px solid black;
                text-align: center;
                font-size: 21px;
            }

        * {
            box-sizing: border-box;
        }

        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        /* Float four columns side by side */
        .column {
            float: left;
            width: 100%;
            padding: 0 10px;
        }

        /* Remove extra left and right margins, due to padding */
        .row {
            margin: 0 -5px;
        }

            /* Clear floats after the columns */
            .row:after {
                content: "";
                display: table;
                clear: both;
            }
        /* Style the counter cards */
        .card {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            padding: 16px;
            text-align: center;
            background-color: #f1f1f1;
            margin-top: 1%;
        }

        .cal {
            padding: 0% 42% 0% 44%;
        }
        /* Responsive columns */
        @media screen and (max-width: 600px) {
            .column {
                width: 100%;
                display: block;
                margin-bottom: 20px;
            }

            .card {
                padding: 0px;
            }

            .grid-container > div {
                font-size: 15px;
            }

            .cal {
                padding: 0% 19% 0% 37%;
            }
        }
    </style>
</asp:Content>
