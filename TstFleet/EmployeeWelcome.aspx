<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeWelcome.aspx.cs" Inherits="TstFleet.EmployeeWelcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome Employee.....1</h1>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <style>
        body {
            background-color: #eee
        }

        .card-0 {
            min-height: 110vh;
            background: linear-gradient(-20deg, rgb(255, 255, 255) 50%, #0275d8 50%);
            color: white;
            border: 0px
        }

        p {
            font-size: 15px;
            line-height: 25px !important;
            font-weight: 500
        }

        .container {
            padding-top: 100px !important;
            border-radius: 20px
        }

        .btn {
            letter-spacing: 1px
        }

        select:active {
            box-shadow: none !important;
            outline-width: 0 !important
        }

        select:after {
            box-shadow: none !important;
            outline-width: 0 !important
        }

        input,
        textarea {
            padding: 10px 12px 10px 12px;
            border: 1px solid lightgrey;
            border-radius: 0px !important;
            margin-bottom: 5px;
            margin-top: 2px;
            width: 100%;
            box-sizing: border-box;
            color: #2C3E50;
            font-size: 14px;
            letter-spacing: 1px;
            resize: none
        }

            select:focus,
            input:focus {
                box-shadow: none !important;
                border: 1px solid #2196F3 !important;
                outline-width: 0 !important;
                font-weight: 400
            }

        label {
            margin-bottom: 2px;
            font-weight: bolder;
            font-size: 14px
        }

        input:focus,
        textarea:focus {
            -moz-box-shadow: none !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
            border: 1px solid #304FFE;
            outline-width: 0
        }

        button:focus {
            -moz-box-shadow: none !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
            outline-width: 0
        }

        .form-control {
            height: calc(2em + .75rem + 3px)
        }

        .inner-card {
            margin: 79px 0px 70px 0px
        }

        .card-0 {
            margin-top: 100px;
            margin-bottom: 100px
        }

        .card-1 {
            border-radius: 17px;
            color: black;
            box-shadow: 2px 4px 15px 0px rgb(0, 0, 0, 0.5) !important
        }

        #file {
            border: 2px dashed #92b0b3 !important
        }

        .color input {
            background-color: #f1f1f1
        }

        .files:before {
            position: absolute;
            bottom: 60px;
            left: 0;
            width: 100%;
            content: attr(data-before);
            color: #000;
            font-size: 12px;
            font-weight: 600;
            text-align: center
        }

        #file {
            display: inline-block;
            width: 100%;
            padding: 95px 0 0 100%;
            background: url('https://i.imgur.com/VXWKoBD.png') top center no-repeat #fff;
            background-size: 55px 55px
        }
        
    </style>
    <link rel="stylesheet" href=" https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
    <link media="screen" rel="stylesheet" href='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' />
    <div class="container card-0 justify-content-center ">
        <div class="card-body px-sm-4 px-0">
            <div class="row justify-content-center mb-5">
                <div class="col-md-10 col">
                    <h3 class="font-weight-bold ml-md-0 mx-auto text-center text-sm-left">Request For Cab</h3>
                </div>
            </div>
            <div class="row justify-content-center round">
                <div class="col-lg-10 col-md-12 ">
                    <div class="card shadow-lg card-1">
                        <div class="card-body inner-card">
                            <div class="row justify-content-center">
                                <div class="col-lg-5 col-md-6 col-sm-12">
                                    <div style="border-style: solid; width: 21%; margin-top: -16%; margin-bottom: 15px;">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Pickup</asp:ListItem>
                                            <asp:ListItem>Drop</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="form-group">
                                        <label for="Evaluate Budget">Employee Id</label>
                                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="first-name">Full Name</label>
                                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="Mobile-Number">Mobile Number</label>
                                        <asp:TextBox ID="TextBox3" runat="server" required></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail4">Time</label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                            <asp:ListItem Text="Select Time For Pickup" Value="select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="05:00 AM" Value="05:00 AM"></asp:ListItem>
                                            <asp:ListItem Text="06:00 AM" Value="06:00 AM"></asp:ListItem>
                                            <asp:ListItem Text="07:00 AM" Value="07:00 AM"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail4">Gender</label>
                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                            <asp:ListItem Text="Select Gender" Value="select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-5 col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="last-name">Address</label>
                                        <asp:TextBox ID="TextBox4" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="phone">Email Address</label>
                                        <asp:TextBox ID="TextBox5" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="skill">Department</label>
                                        <asp:TextBox ID="TextBox6" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="Company-Name">Date</label>
                                        <asp:TextBox ID="TextBox7" runat="server" ReadOnly='true'></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail4">Channel</label>
                                        <asp:TextBox ID="TextBox8" runat="server" placeholder="Rbharat" ReadOnly='true'></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-md-12 col-lg-10 col-12">
                                    <div class="mb-2 mt-4">
                                        <div class="text-right">
                                            <asp:Button ID="Button1" class="btn btn-primary btn-block" runat="server" Text="Request a Cab" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
