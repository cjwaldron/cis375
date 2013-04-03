<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="cis375projectmysqlDB.item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="1200px">
        <asp:Image ID="Image1" runat="server" Height="236px" Width="236px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" Height="235px" Width="236px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image3" runat="server" Height="236px" Width="236px" />
        <br />
        <asp:TextBox ID="titleTB" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="categoryTB" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="priceTB" runat="server"></asp:TextBox>
        <asp:Button ID="bidBT" runat="server" Text="BID" Width="100px" />
        <br />
        <br />
        <asp:TextBox ID="descriptionTB" runat="server" Height="132px" Width="379px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="buyitnowTB" runat="server"></asp:TextBox>
        <asp:Button ID="buyitnowBT" runat="server" ForeColor="Red" Text="BUY IT NOW" 
            Width="100px" />
        <br />
        <br />
        <asp:TextBox ID="startdateTB" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="enddateTB" runat="server"></asp:TextBox>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
