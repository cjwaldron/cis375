<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="cis375projectmysqlDB.item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="1200px">
        <asp:Image ID="Image1" runat="server" Height="236px" Width="236px" ImageUrl="~/images/photo-2.jpg"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" Height="235px" Width="236px" ImageUrl="~/images/photo-2.jpg" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image3" runat="server" Height="236px" Width="236px" ImageUrl="~/images/photo-2.jpg"/>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" style="margin-left:30px" Text="Price"></asp:Label>
        <asp:Label ID="Label4" runat="server" style="margin-left:55px" Text="Category"></asp:Label>
        <asp:Label ID="Label5" runat="server" style="margin-left:30px" Text="Current Price"></asp:Label>
        <br />
        <asp:TextBox ID="titleTB" runat="server" style="margin-left:10px" Width="85px"></asp:TextBox>
        <asp:TextBox ID="categoryTB" runat="server" style="margin-left:10px" Width="95px"></asp:TextBox>
        <asp:TextBox ID="priceTB" runat="server" style="margin-left:10px" Width="95px"></asp:TextBox>
        <asp:Button ID="bidBT" runat="server" Text="BID" style=" margin-left:20px" Width="100px" 
            onclick="bidBT_Click" />
        <asp:Label ID="Label2" runat="server" Visible="false" Text="Enter Your Bid" style="margin-right:5px; margin-left:10px"></asp:Label>
        <asp:TextBox ID="userBidTB" runat="server" Visible="false" Width="124px" ></asp:TextBox>
        <asp:Button ID="userBidBTN" runat="server" Visible="false" Text="Place Bid" 
            onclick="userBidBTN_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" style="margin-left:50px" Text="Description"></asp:Label>
        <br />
        <asp:TextBox ID="descriptionTB" runat="server" style="margin-left:10px" Height="132px" Width="379px"></asp:TextBox>
        buy it now price
        <asp:TextBox ID="buyitnowTB" runat="server" Width="54px"></asp:TextBox>
        <asp:Button ID="buyitnowBT" runat="server" ForeColor="Red" Text="BUY IT NOW" 
            Width="100px" onclick="buyitnowBT_Click" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" style="margin-left:45px" Text="Start Date"></asp:Label>
        <asp:Label ID="Label9" runat="server" style="margin-left:85px" Text="End Date"></asp:Label>
        <br />
        <asp:TextBox ID="startdateTB" runat="server" style="margin-left:10px" ></asp:TextBox>
        <asp:TextBox ID="enddateTB" runat="server" style="margin-left:10px" ></asp:TextBox>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
