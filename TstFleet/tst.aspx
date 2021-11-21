<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tst.aspx.cs" Inherits="TstFleet.tst" %>

<html lang="en">
<head runat="server">
    <title>R Bharat</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" />
    <link href="../css/w3.css" rel="stylesheet" />
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

        html, body {
            min-height: 100%;
            background: linear-gradient(-20deg, rgb(255, 255, 255) 50%, #d01f27 50%);
        }

        .login-page {
            width: 360px;
            padding: 16% 0 0;
            margin: auto;
        }

        .form {
            position: relative;
            z-index: 1;
            background: #212529;
            max-width: 360px;
            margin: 0 auto 100px;
            padding: 45px;
            text-align: center;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

            .form input {
                font-family: "Roboto", sans-serif;
                outline: 0;
                background: #f2f2f2;
                width: 100%;
                border: 0;
                margin: 0 0 15px;
                padding: 15px;
                box-sizing: border-box;
                font-size: 16px;
                font-weight: bolder;
            }

            .form button {
                font-family: "Roboto", sans-serif;
                text-transform: uppercase;
                outline: 0;
                background: #4caf50;
                width: 100%;
                border: 0;
                padding: 15px;
                color: #ffffff;
                font-size: 16px;
                -webkit-transition: all 0.3 ease;
                transition: all 0.3 ease;
                cursor: pointer;
            }

                .form button:hover,
                .form button:active,
                .form button:focus {
                    background: #43a047;
                }

            .form .message {
                margin: 15px 0 0;
                color: #b3b3b3;
                font-size: 20px;
            }

                .form .message a {
                    color: #4caf50;
                    text-decoration: none;
                }

            .form .register-form {
                display: none;
            }

        .container {
            position: relative;
            z-index: 1;
            max-width: 300px;
            margin: 0 auto;
        }

            .container:before,
            .container:after {
                content: "";
                display: block;
                clear: both;
            }

            .container .info {
                margin: 50px auto;
                text-align: center;
            }

                .container .info h1 {
                    margin: 0 0 15px;
                    padding: 0;
                    font-size: 36px;
                    font-weight: 300;
                    color: #1a1a1a;
                }

                .container .info span {
                    color: #4d4d4d;
                    font-size: 12px;
                }

                    .container .info span a {
                        color: #000000;
                        text-decoration: none;
                    }

                    .container .info span .fa {
                        color: #ef3b3a;
                    }

        body {
            background-color: #fafafa;
            font-family: "Roboto", sans-serif;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }

        @media only screen and (max-width: 600px) {
            body {
                width: 360px;
                padding: 32% 0 0;
                margin: auto;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="wrapper">
                <!-- Sidebar Holder -->
                <nav id="sidebar">
                    <div class="sidebar-header" style="height: 60px;">
                    </div>

                    <ul class="list-unstyled components">
                        <li class="active">
                            <a href="DashBoardAdmin.aspx">
                                <i class="glyphicon glyphicon-home"></i>
                                Dashboard
                            </a>
                        </li>
                        <li class="active">
                            <a href="ScheduleCab.aspx">
                                <i class="glyphicon glyphicon-briefcase"></i>
                                Schedule Cab
                            </a>
                        </li>
                        <li class="active">
                            <a href="Setting.aspx">
                                <i class="glyphicon glyphicon-briefcase"></i>
                                User Settings
                            </a>
                        </li>
                        <li class="active">
                            <a href="AddDriver.aspx">
                                <i class="glyphicon glyphicon-briefcase"></i>
                                Add Driver
                            </a>
                        </li>
                    </ul>
                </nav>
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header" style="width: 270px;">
                            <div style="float: left; width: 84%">
                                <h3>
                                    <a href="#">
                                        <img src="../images/Republic_TV.jpg" width="24%" style="padding: 0 5px 0 5px;" />Republic Fleet
                                    </a>
                                </h3>
                            </div>

                            <div style="float: right; width: 15%; padding-top: 0px;">
                                <button type="button" id="sidebarCollapse" class="btn btn-info navbar-btn">
                                    <i class="glyphicon glyphicon-align-left"></i>
                                </button>
                            </div>
                        </div>
                        <div class="nav navbar-nav navbar-right">
                            <div class="menu-content" style="border: outset;">
                                <%-- <asp:Button ID="Button22" class="btn btn-default btn-flat" runat="server" Text="LogOut" OnClick="Button1_Click" />--%>
                                <a href="../Login.aspx" id="Button22" class="btn btn-default btn-flat">
                                    <img src="../images/6.png" style="height: 40px;" />LogOut</a>
                            </div>
                        </div>
                    </div>
                </nav>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="username" required></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="password" required></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Log In" Style="color: white; background-color: #43a047;" />
                <asp:Label ID="Label1" runat="server" Text="" Style="display: inline-block; color: #ef0e0e; font-size: x-large; font-weight: bold;"></asp:Label>
                <%--   <p class="message">For Driver <a href="Driver_Login.aspx">Driver Login</a></p>--%>
                <p class="message">*<a href="EmpReg.aspx">Employee Registration</a></p>
            </div>
        </div>
    </form>
    <!-- jQuery CDN -->
    <script src="js/jquery-1.12.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
</body>
</html>
