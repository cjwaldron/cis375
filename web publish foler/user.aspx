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

        <asp:Button ID="sellersInfoBT" runat="server" BackColor="#999999" 
            BorderStyle="Groove" Font-Bold="True" onclick="sellersInfoBT_Click" 
            Text="Sellers Info" />
        <asp:Button ID="buyersInfoBT" runat="server" BackColor="#999999" 
            BorderStyle="Groove" Font-Bold="True" onclick="buyersInfoBT_Click" 
            Text="Buyers Info" />
    </asp:Panel>
    


    <asp:Panel ID="Panel2" runat="server" Height="525px" Visible="false" BorderColor="Black" 
        BorderStyle="Groove" style="padding:15px">
        Seller Information:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="30px"></asp:TextBox>
        &nbsp; Total number of items<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="31px"></asp:TextBox>
        &nbsp;Total number of unsold items<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="31px"></asp:TextBox>
        &nbsp;Total number of items in progress<br />
        <asp:TextBox ID="TextBox4" runat="server" Width="31px"></asp:TextBox>
        &nbsp;Total amount earned<br />

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>"
                SelectCommand="SELECT title, category, description, enddate, item.price, buyitnow FROM user,item,listed WHERE user.iduser = item.iduser AND item.itemid = listed.itemid AND user.iduser = @iduser">
                <SelectParameters>
                    <asp:ControlParameter name="iduser" ControlID="userIdStorage" PropertyName="Text" />
                </SelectParameters>  
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" Width="492px" 
                DataSourceID="SqlDataSource2" AllowPaging="True" BackColor="White" 
                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                GridLines="Vertical" Height="81px">
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
    </asp:Panel>



            <asp:Panel ID="Panel4" runat="server" Height="525px" Visible="false" BorderColor="Black" 
                 BorderStyle="Groove" Style="padding:15px"> 
               
                <asp:TextBox ID="TextBox5" runat="server" Width="33px"></asp:TextBox>
                &nbsp;Total amount spent<br />
                <asp:TextBox ID="TextBox6" runat="server" Width="33px"></asp:TextBox>
                &nbsp;Total number of items purchased<br />
                <asp:TextBox ID="TextBox7" runat="server" Width="34px"></asp:TextBox>
                &nbsp;Total number of items you have bids on<br />
                <asp:TextBox ID="TextBox8" runat="server" Width="34px"></asp:TextBox>
                &nbsp;Total number of items winning<br />
                <asp:TextBox ID="TextBox9" runat="server" Width="35px"></asp:TextBox>
                &nbsp;Total dollar amount winning items

                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT item.title, item.category, item.description, item.enddate, item.price, item.buyitnow 
                                    FROM item, listed, bids 
                                    WHERE listed.highestbidder = @iduser AND item.itemid=listed.itemid">
                <SelectParameters>
                    <asp:ControlParameter name="iduser" ControlID="userIdStorage" PropertyName="Text" />
                </SelectParameters>
                </asp:SqlDataSource>
                <asp:Label ID="Label2" runat="server" Text="Items you have bids on:"></asp:Label>
                <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource3" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" GridLines="Vertical">
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
                
                <br />
                <asp:Label ID="Label3" runat="server" Text="Purchase History:"></asp:Label>
                <br />

                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT  item.title, item.category, item.description, item.enddate, item.price, item.buyitnow 
                                    FROM item, sold
                                    WHERE (item.iduser = @iduser AND item.itemid = sold.itemid)">
                 <SelectParameters>
                    <asp:ControlParameter name="iduser" ControlID="userIdStorage" PropertyName="Text" />
                </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" DataKeyNames="itemid" DataSourceID="SqlDataSource4" 
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
               
    </asp:Panel>
            <br />
    
</asp:Content>
