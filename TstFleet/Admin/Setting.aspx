<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="TstFleet.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous" />
    <style>
        html, body {
            min-height: 100%;
            /*background: linear-gradient(-20deg, rgb(255, 255, 255) 50%, #0275d8 50%);*/
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
            box-shadow: 0 0 8px #000000;
            margin-left: 16%;
        }

        .banner {
            position: relative;
            height: 300px;
            background: linear-gradient(-20deg, rgb(255, 255, 255) 50%, #0275d8 50%);
            background-size: cover;
            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center;
        }

            .banner::after {
                content: "";
                background-color: rgba(0, 0, 0, 0.2);
                position: absolute;
                width: 100%;
                height: 100%;
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

        /*.btn-block {
            margin-top: 10px;
            text-align: center;
        }

        button {
            width: 150px;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background: #669999;
            font-size: 16px;
            color: #fff;
            cursor: pointer;
        }*/

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
    </style>


    <div class="testbox">
        <div class="colums">
            <div class="item" style="width: auto;margin: inherit;">
                <label for="fname">Select Employe ID<span>*</span></label>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                <asp:Button ID="Button2" class="btn-primary" runat="server" Text="Submit" Style="width: fit-content;" OnClick="Button1_Click1" />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="x-large"></asp:Label>
            </div>
            <div class="item">
                <label for="fname">Full Name<span>*</span></label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="lname">Emp ID<span>*</span></label>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="item">
                <label for="address1">Mobile<span>*</span></label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="address2">Email Address<span>*</span></label>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="state">Department<span>*</span></label>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="zip">Gender<span>*</span></label>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="city">Address<span>*</span></label>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="phone">Channel<span>*</span></label>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_register" class="btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
    <div>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    <%--            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"  
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">  
            <AlternatingRowStyle BackColor="#DCDCDC" />  
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />  
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />  
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />  
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />  
            <SortedAscendingCellStyle BackColor="#F1F1F1" />  
            <SortedAscendingHeaderStyle BackColor="#0000A9" />  
            <SortedDescendingCellStyle BackColor="#CAC9C9" />  
            <SortedDescendingHeaderStyle BackColor="#000065" />  
        </asp:GridView> --%>
</asp:Content>
