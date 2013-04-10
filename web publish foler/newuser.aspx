<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="cis375projectmysqlDB.newuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
Please fill out the information below and click submit.
</p>
    <asp:Panel ID="Panel1" runat="server" Height="650px" Visible="True">
        <asp:TextBox ID="fnameTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; First Name<br />
        <asp:TextBox ID="lnameTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; Last Name<br />
        <asp:TextBox ID="passwordTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; Password<br />
        <asp:TextBox ID="conpasswordTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; Confirm Password<br />
        <asp:TextBox ID="emailTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; Email
        <br />
        <asp:TextBox ID="conemailTB" runat="server" Width="250px"></asp:TextBox>
        &nbsp; Confirm Email<br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="submit" />
        <br />
        <br />
        <asp:TextBox ID="messageTB" runat="server" Height="91px" Visible="False" 
            Width="375px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            style="height: 29px" Text="OK" Width="115px" />
    </asp:Panel>
</asp:Content>
