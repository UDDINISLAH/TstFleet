<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="TstFleet.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        .card {
            box-shadow: 0 4px 8px 0 rgb(0 0 0);
            max-width: 380px;
            margin: auto;
            text-align: center;
            font-family: arial;
            padding: 15px;
        }

        .h3, h3 {
            font-size: 21px;
        }

        .title {
            color: grey;
            font-size: 18px;
        }

        button {
            border: none;
            outline: 0;
            display: inline-block;
            padding: 8px;
            color: white;
            background-color: #000;
            text-align: center;
            cursor: pointer;
            width: 100%;
            font-size: 18px;
        }

        a {
            text-decoration: none;
            font-size: 22px;
            color: black;
        }

        i, span {
            display: inline-table;
            color: white;
            font-variant: all-petite-caps;
        }

        button:hover, a:hover {
            opacity: 0.7;
        }
        /*.cardd {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            padding: 16px;
            text-align: center;
            background-color: #f1f1f1;
            margin-top: 7%;
        }*/
    </style>

    <div class="cardd">
        <h2 style="text-align: center; text-align: center; font-size: xxx-large; color: black; font-variant: all-petite-caps;">User Profile</h2>
        <div class="card">
            <img src="../images/img_avatar.png" alt="John" style="width: 100%" />
            <div style="background-color: #d01f27; color: #ffffff;">
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Label1"></asp:Label>(<asp:Label ID="Label2" runat="server"></asp:Label>)</h3>
                <h4>
                    <asp:Label ID="Label4" runat="server"></asp:Label></h4>
                <h4>
                    <asp:Label ID="Label3" runat="server"></asp:Label></h4>
                <h4>
                    <asp:Label ID="Label5" runat="server"></asp:Label></h4>
                <h4>
                    <asp:Label ID="Label6" runat="server"></asp:Label></h4>
                <h4>
                    <asp:Label ID="Label7" runat="server"></asp:Label></h4>
                <h4>
                    <asp:Label ID="Label8" runat="server"></asp:Label></h4>
            </div>
        </div>
    </div>
</asp:Content>
