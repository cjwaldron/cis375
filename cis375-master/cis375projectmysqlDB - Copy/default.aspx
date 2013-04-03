<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="cis375projectmysqlDB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="650px">
        <p>
        <asp:LinkButton ID="newUsersBtn" runat="server" BackColor="Blue" 
            BorderColor="#666666" BorderStyle="Groove" ForeColor="Yellow" Height="25px" 
            Width="75px" onclick="newUsersBtn_Click">New Users</asp:LinkButton>
            
        </p>
        <p>
        <asp:TextBox ID="usernameTB" runat="server"  
                style="margin-left: 0px"></asp:TextBox>
            username</p>

        <p>
            <asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
            password
        </p>
        <p>
        
            <asp:Button ID="Button1" runat="server" BackColor="Blue" ForeColor="Yellow" 
                Text="Login" Width="74px" onclick="Button1_Click" />
        
        </p>

    </asp:Panel>
</asp:Content>
