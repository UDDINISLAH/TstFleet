<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddDriver.aspx.cs" Inherits="TstFleet.AddDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
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
    <div class="testbox">
        <div class="colums">
            <div class="item">
                <label for="fname">Driver Name<span>*</span></label>
                <asp:TextBox ID="txt_DriverName" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="lname">Mobile<span>*</span></label>
                <asp:TextBox ID="txt_Mobile" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="address1">Email Address<span>*</span></label>
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="address2">Driver Address<span>*</span></label>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="state">Cab Model<span>*</span></label>
                <asp:TextBox ID="Cab_model" runat="server"></asp:TextBox>
            </div>
            <div class="item">
                <label for="zip">Cab Number<span>*</span></label>
                <asp:TextBox ID="cab_number" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_register" class="btn-primary" runat="server" Text="Submit" OnClick="btn_register_Click" />
    <div>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    <div style="padding: 2%;">
        <div class="table-responsive" style="background-color: #fff; box-shadow: 0 0 8px #000000;">
            <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AllowSorting="true" PageSize="50" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Driver_Name" HeaderText="Driver Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Driver_Address" HeaderText="Driver Address" />
                    <asp:BoundField DataField="Cab_model" HeaderText="Cab Model" />
                    <asp:BoundField DataField="Cab_Number" HeaderText="Cab Number" />
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                        EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" DeleteText="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>"
                        CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" ControlStyle-BackColor="transparent" />
                </Columns>
            </asp:GridView>
            <div>
                <asp:Label ID="lblresult" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
