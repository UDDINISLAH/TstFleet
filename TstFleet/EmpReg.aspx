<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpReg.aspx.cs" Inherits="TstFleet.EmpReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <!-- Our Custom CSS -->
    <link rel="stylesheet" href="css/styles.css" />
    <link rel="stylesheet" href="css/w3.css" />
    <style>
        html, body {
            min-height: 115%;
            background: linear-gradient(-20deg, rgb(255, 255, 255) 50%, #d01f27 50%);
        }

        body, div, form, input, select, textarea, label, p {
            padding: 0;
            margin: 0;
            outline: none;
            font-family: Roboto, Arial, sans-serif;
            font-size: 14px;
            color: #666;
            line-height: 22px;
        }

        h1 {
            position: absolute;
            margin: 0;
            font-size: 40px;
            color: #fff;
            z-index: 2;
            line-height: 83px;
        }

        textarea {
            width: calc(100% - 12px);
            padding: 5px;
        }

        .testbox {
            display: flex;
            justify-content: center;
            align-items: center;
            height: inherit;
            padding: 20px;
        }

        form {
            width: 70%;
            /* padding: 0px; */
            border-radius: 6px;
            background: #fff;
            box-shadow: 0 0 8px #669999;
            margin-left: 16%;
        }

        input, select, textarea {
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        input {
            width: calc(100% - 10px);
            padding: 5px;
        }

            input[type="date"] {
                padding: 4px 5px;
            }

        textarea {
            width: calc(100% - 12px);
            padding: 5px;
        }

        .item:hover p, .item:hover i, .question:hover p, .question label:hover, input:hover::placeholder {
            color: #669999;
        }

        .item input:hover, .item select:hover, .item textarea:hover {
            border: 1px solid transparent;
            box-shadow: 0 0 3px 0 #669999;
            color: #669999;
        }

        .item {
            position: relative;
            margin: 10px 0;
        }

            .item span {
                color: red;
            }

        .week {
            display: flex;
            justfiy-content: space-between;
        }

        .colums {
            display: flex;
            justify-content: space-between;
            flex-direction: row;
            flex-wrap: wrap;
        }

            .colums div {
                width: 48%;
            }

        input[type="date"]::-webkit-inner-spin-button {
            display: none;
        }

        .item i, input[type="date"]::-webkit-calendar-picker-indicator {
            position: absolute;
            font-size: 20px;
            color: #a3c2c2;
        }

        .item i {
            right: 1%;
            top: 30px;
            z-index: 1;
        }

        input[type=radio], input[type=checkbox] {
            display: none;
        }

        label.radio {
            position: relative;
            display: inline-block;
            margin: 5px 20px 15px 0;
            cursor: pointer;
        }

        .question span {
            margin-left: 30px;
        }

        .question-answer label {
            display: block;
        }

        label.radio:before {
            content: "";
            position: absolute;
            left: 0;
            width: 17px;
            height: 17px;
            border-radius: 50%;
            border: 2px solid #ccc;
        }

        input[type=radio]:checked + label:before, label.radio:hover:before {
            border: 2px solid #669999;
        }

        label.radio:after {
            content: "";
            position: absolute;
            top: 6px;
            left: 5px;
            width: 8px;
            height: 4px;
            border: 3px solid #669999;
            border-top: none;
            border-right: none;
            transform: rotate(-45deg);
            opacity: 0;
        }

        input[type=radio]:checked + label:after {
            opacity: 1;
        }

        .flax {
            display: flex;
            justify-content: space-around;
        }

        button:hover {
            background: #a3c2c2;
        }

        @media (min-width: 568px) {
            .name-item, .city-item {
                display: flex;
                flex-wrap: wrap;
                justify-content: space-between;
            }

                .name-item input, .name-item div {
                    width: calc(50% - 20px);
                }

                    .name-item div input {
                        width: 97%;
                    }

                    .name-item div label {
                        display: block;
                        padding-bottom: 5px;
                    }
        }

        #content {
            padding: 0px 15px 0px 0px;
            min-height: 60vh;
            transition: all 0.3s;
            width: 100%;
            color: #5f5e5e;
        }

        .message {
            margin: 15px 0 0;
            color: #b3b3b3;
            font-size: 30px;
        }

            .message a {
                color: #4caf50;
                text-decoration: none;
            }
            #wrp{
                margin-top: 20%;
            }
        @media only screen and (max-width: 600px) {
            #wrp {
                margin-top: 40%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper" id="wrp">
            <div id="content">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header" style="width: 250px;">
                            <div style="float: left; width: 84%">
                                <h3>
                                    <a href="#">
                                        <img src="images/Republic_TV.jpg" width="24%" style="padding: 0 5px 0 5px;" />Republic Fleet
                                    </a>
                                </h3>
                            </div>
                        </div>
                    </div>
                </nav>
                <div class="testbox">
                    <div class="colums">
                        <div class="item">
                            <label for="fname">Employee Id<span>*</span></label>
                            <asp:TextBox ID="TextBox1" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="lname">Address<span>*</span></label>
                            <asp:TextBox ID="TextBox2" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="address1">Full Name<span>*</span></label>
                            <asp:TextBox ID="TextBox3" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="address2">Email Address<span>*</span></label>
                            <asp:TextBox ID="TextBox4" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="state">Mobile Number<span>*</span></label>
                            <asp:TextBox ID="TextBox5" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="zip">Department<span>*</span></label>
                            <asp:TextBox ID="TextBox6" runat="server" required></asp:TextBox>
                        </div>
                        <div class="item">
                            <label for="city">Gender<span>*</span></label>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Style="width: calc(100% - 10px);" required>
                                <asp:ListItem Text="" style="visibility: hidden"></asp:ListItem>
                                <asp:ListItem Text="MALE" Value="MALE"></asp:ListItem>
                                <asp:ListItem Text="FEMALE" Value="FEMALE"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="item">
                            <label for="phone">Channel<span>*</span></label>
                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" Style="width: calc(100% - 10px);" required>
                                <asp:ListItem Text="" style="visibility: hidden"></asp:ListItem>
                                <asp:ListItem Text="R BHARAT" Value="RBHARAT"></asp:ListItem>
                                <asp:ListItem Text="REPUBLIC" Value="REPUBLIC"></asp:ListItem>
                                <asp:ListItem Text="R BANGLA" Value="RBANGLA"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <asp:Button ID="Button1" class="btn-primary" runat="server" Text="Register" OnClick="Button1_Click" Style="margin-left: 10%;width: 40%;" />
           <%--     <asp:Button ID="Button2" class="btn btn-warning" runat="server" Text="Login"   Style="margin-left: 1%;width: 40%;" OnClick="Button2_Click" />--%>
                <a href="Login.aspx" class="btn btn-warning" style="margin-left: 0%;width: 40%;">Login</a>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
