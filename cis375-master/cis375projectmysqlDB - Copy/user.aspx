<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="cis375projectmysqlDB.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="75px">
    <p style="height: 10">
        <asp:TextBox ID="name" runat="server" BackColor="Silver" BorderColor="Silver" 
            BorderStyle="None"></asp:TextBox>
    </p>
        <asp:Button ID="searchBT" runat="server" Text="Search" BackColor="#999999" 
            BorderStyle="Groove" Font-Bold="True" onclick="searchBT_Click" />
        <asp:Button ID="listitemBT" runat="server" Text="List Item" BackColor="#999999" 
            BorderStyle="Groove" Font-Bold="True" onclick="listitemBT_Click" />

    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="525px" BorderColor="Black" 
        BorderStyle="Groove">
        Seller Information:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="30px"></asp:TextBox>
        &nbsp; Total number of items<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="31px"></asp:TextBox>
        &nbsp;Total number of unsold items<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="31px"></asp:TextBox>
        &nbsp;Total number of items in progress<br />
        <div style="height: 200px; width: 1667px;">
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>"
                SelectCommand="SELECT title, category, description, enddate, item.price, buyitnow FROM user,item,listed WHERE user.iduser = item.iduser AND item.itemid = listed.itemid AND user.iduser = @iduser">
                <SelectParameters>
                    <asp:ControlParameter name="iduser" ControlID="userIdStorage" PropertyName="Text" />
                </SelectParameters> 
                
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" Width="" 
                DataSourceID="SqlDataSource2" AllowPaging="True" BackColor="White" 
                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                GridLines="Vertical">
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
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
