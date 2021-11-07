<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Driver_Login.aspx.cs" Inherits="TstFleet.Driver_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

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
           background-color:#fafafa;
            font-family: "Roboto", sans-serif;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>  
    
     <link rel="stylesheet" href="css/bootstrap.min.css" />
    <!-- Our Custom CSS -->
    <link rel="stylesheet" href="css/styles.css" />
    <link rel="stylesheet" href="css/w3.css" />  
        <div class="wrapper">
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
            <div class="login-page">
                <div class="form">        
                      <asp:TextBox ID="TextBox1" runat="server"  placeholder="Mobile Number" ></asp:TextBox>
                      <%-- <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="password"></asp:TextBox> --%>             
                     <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" style="color: white;background-color: #43a047;"/>
                     <p class="message">For Employee/Admin <a href="Login.aspx">Employee/ADMIN</a></p>  
                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                </div>
            </div>
        </div>
     </div>
  



</asp:Content>
