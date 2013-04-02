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
        <asp:TextBox ID="TextBox1" runat="server" Width="32px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="31px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Width="31px"></asp:TextBox>
    </asp:Panel>
</asp:Content>
