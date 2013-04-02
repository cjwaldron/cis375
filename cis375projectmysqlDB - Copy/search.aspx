<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="cis375projectmysqlDB.search" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="Panel1" runat="server" Height="650px">
        <asp:Panel ID="Panel2" runat="server" 
            style="margin-left:100px; margin-top:30px; margin-bottom:30px;" 
            Height="32px" Width="640px">
            <asp:Button ID="Button1" runat="server" Text="All Items" 
                style="margin-right: 10px;" onclick="Button1_Click" />
              
                
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 10px;" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                <asp:ListItem>Sports</asp:ListItem>
                <asp:ListItem>Clothes</asp:ListItem>
                <asp:ListItem>Books</asp:ListItem>
                <asp:ListItem>Computer</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
            Search by keyword
            <asp:TextBox ID="TextBox1" runat="server" style="margin-right: 10px;" Width="164px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Search" 
                style="margin-right: 10px;" onclick="Button2_Click" />
            <asp:Panel ID="Panel3" runat="server"  ScrollBars="Auto" 
                style="margin-top:30px; margin-right: 17px;" Width="200px" Visible="false">
                <asp:DataList ID="DataList1" runat="server" 
                    DataSourceID="SqlDataSource2" DataKeyField="itemid" 
                    style="margin-right: 17px">
                    <ItemTemplate>
                        itemid:
                        <asp:Label ID="itemidLabel" runat="server" Text='<%# Eval("itemid") %>' />
                        <br />
                        title:
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                        <br />
                        category:
                        <asp:Label ID="categoryLabel" runat="server" Text='<%# Eval("category") %>' />
                        <br />
                        description:
                        <asp:Label ID="descriptionLabel" runat="server" 
                            Text='<%# Eval("description") %>' />
                        <br />
                        startdate:
                        <asp:Label ID="startdateLabel" runat="server" Text='<%# Eval("startdate") %>' />
                        <br />
                        enddate:
                        <asp:Label ID="enddateLabel" runat="server" Text='<%# Eval("enddate") %>' />
                        <br />
                        price:
                        <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                        <br />
                        buyitnow:
                        <asp:Label ID="buyitnowLabel" runat="server" Text='<%# Eval("buyitnow") %>' />
                        <br />
                        iduser:
                        <asp:Label ID="iduserLabel" runat="server" Text='<%# Eval("iduser") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT * FROM  item"></asp:SqlDataSource>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
