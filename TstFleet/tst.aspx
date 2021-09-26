<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tst.aspx.cs" Inherits="TstFleet.tst" %>

<html lang="en">
<head>
  <meta charset="utf-8">
  <title>datepicker demo</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.12.4.js"></script>
  <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body>
 <form id="form1" runat="server">
      <asp:TextBox ID="datepicker" runat="server" autocomplete="off" class="date_control" AutoPostBack="true"></asp:TextBox>
 
 </form>

<script>
$( "#datepicker" ).datepicker();
</script>
 
</body>
</html>