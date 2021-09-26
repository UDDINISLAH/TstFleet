<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DashBoardAdmin.aspx.cs" Inherits="TstFleet.DashBoardAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(function () {
            // debugger
            $("#datepicker").datepicker({ dateFormat: "dd/mm/yy", maxDate: new Date() });
        });
    </script>

    <div class="container" style="width: max-content;">
        <div class="row">


            <div class="col-md-12">
                <div class="table-responsive">
                    <table style="margin-top: 0px;">
                        <tr>
                            <td style="font-size: 25PX; font-weight: bolder;">Select Date</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="datepicker" runat="server" autocomplete="off" type="date" AutoPostBack="true"></asp:TextBox></td>
                            <%--<td><asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" /></td>--%>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID." ReadOnly="true" />
                            <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" ReadOnly="true" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly='true' />
                            <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile_Number" ReadOnly='true' />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                            <asp:BoundField DataField="Drop_Pickup" HeaderText="Drop/Pickup" ReadOnly='true' />
                            <asp:BoundField DataField="Time" HeaderText="Office Time" ReadOnly='true' />

                            <asp:TemplateField HeaderText="PickupTime" ItemStyle-Width="30">
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
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>







