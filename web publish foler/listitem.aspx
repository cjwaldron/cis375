<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="listitem.aspx.cs" Inherits="cis375projectmysqlDB.listitem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <asp:Panel ID="Panel1" runat="server" >
        <asp:ListBox ID="ListBox1" runat="server" Height="97px" Width="93px"> 
            
            <asp:ListItem>Sports</asp:ListItem>
            <asp:ListItem>Clothes</asp:ListItem>
            <asp:ListItem>Books</asp:ListItem>
            <asp:ListItem>Games</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>
        &nbsp; Choose a category
        <asp:Panel ID="Panel4" style="float:right; margin-right:10px;" runat="server" Height="31px" 
            >
            <asp:Button ID="Button2" runat="server" style="float:right; margin-right:10px;" 
                Text="Upload" Width="81px" onclick="Button2_Click" />
        </asp:Panel>
        <asp:FileUpload ID="FileUpload1" style="float:right" runat="server" 
            Height="24px" Width="278px" />
        <asp:Label ID="Label2" runat="server" style="float:right; margin-right:10px;" 
            Text="Add Photos"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp; Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Include Buy It Now   " />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp; Buy It Now Price<br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp; Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Height="100px" Width="578px"></asp:TextBox>
        &nbsp;<br /> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
        Description&nbsp; (max of 300 characters)<br />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set End Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
            Height="37px" Width="381px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Height="70px" Width="431px" 
            Visible="false" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        <br />
    </asp:Panel>
</asp:Content>
