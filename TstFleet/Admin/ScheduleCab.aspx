<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ScheduleCab.aspx.cs" Inherits="TstFleet.ScheduleCab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </script>
    <style>
        html, body {
            font-family: Verdana,sans-serif;
            font-size: 13px;
            line-height: 1.5;
        }
   .HiddenCol{display:none;}   
    </style>
    <h1>Welcome Admin......!!</h1>

    <div class="container" style="width: max-content;">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />
                            <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly='true' />
                            <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" ReadOnly='true' />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                            <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop/Pickup" ReadOnly='true' />
                            <asp:BoundField DataField="Time" HeaderText="Office Time" ReadOnly='true'/>

                            <asp:TemplateField HeaderText="PickupTime" ItemStyle-Width="30" >
                                <ItemTemplate>
                                   <asp:Label ID="Label4" runat="server" Text='<%# Bind("PickupTime") %>'></asp:Label> 
                                </ItemTemplate>
                                 <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" type="time" runat="server"></asp:TextBox>
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
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CabNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Driver Info">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Driver_Info") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Emp Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpsts" runat="server" Text='<%# Eval("Emp_Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:CommandField ButtonType="Link" ShowEditButton="true" EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" />
                          <%--  <asp:CommandField HeaderText="Update" ShowEditButton="true" />--%>
                            <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />--%>
                        </Columns>
                    </asp:GridView>
                    <asp:Button Text="Formating" runat="server" OnClick="UpdatePreference" />
                </div>
            </div>          
        </div>
    </div>
</asp:Content>
