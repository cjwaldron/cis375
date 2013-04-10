<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="cis375projectmysqlDB.search" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server" 
            style="margin-left:100px; margin-top:30px; margin-bottom:30px;" 
            Height="32px" Width="944px">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                style="margin-right: 10px;">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Selected="True"></asp:ListItem>
                <asp:ListItem>Sports</asp:ListItem>
                <asp:ListItem>Clothes</asp:ListItem>
                <asp:ListItem>Books</asp:ListItem>
                <asp:ListItem>Games</asp:ListItem>
                
            </asp:DropDownList>
            Search By Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="KeywordTB" runat="server" style="margin-right: 10px;" 
                Width="164px"></asp:TextBox>
            Search by keyword
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                style="margin-right: 10px;" Text="Search" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                style="margin-right: 10px;" Text="All Items" />
            
         </asp:Panel>
            <asp:Panel ID="Panel3" runat="server"  ScrollBars="Vertical" 
                style="margin-top:30px; margin-right: 17px;"  Visible="false">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" GridLines="Vertical" >
                    <AlternatingRowStyle BackColor="#DCDCDC"/>
                    <Columns>
                       <asp:TemplateField HeaderText="View Item" >
                            <ItemTemplate>
                            <asp:Button ID="Gridview1Btn" runat="server" 
                            Text="See Item" CommandArgument="GridBtn"
                            onclick="Gridview1Btn_Click"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT item.itemid, item.title, item.category, item.description, item.enddate, item.price, item.buyitnow FROM item, listed WHERE item.itemid = listed.itemid">
                </asp:SqlDataSource>
            </asp:Panel>


            <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto" Visible="false">
                    <asp:GridView ID="GridView2" runat="server" 
                    DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#999999" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:TemplateField HeaderText="View Item" >
                            <ItemTemplate>
                            <asp:Button ID="Gridview2Btn" runat="server" 
                            Text="See Item" CommandArgument="GridBtn"
                            onclick="GridView2Btn_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT itemid, title, category, description, enddate, price, buyitnow FROM item WHERE (category = ?)">
                    <SelectParameters>
                    <asp:ControlParameter name="category" ControlID="DropDownList1" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                    </asp:SqlDataSource>
            </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <br />
        <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
               <asp:TemplateField HeaderText="View Item" >
                            <ItemTemplate>
                            <asp:Button ID="Gridview3Btn" runat="server" 
                            Text="See Item" CommandArgument="GridBtn"
                            onclick="GridView3Btn_Click"/>
                            </ItemTemplate>
               </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
            ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
            SelectCommand="SELECT itemid, title, category, description, enddate, price, buyitnow FROM item WHERE MATCH (title,description) AGAINST(@description)">
            <SelectParameters>
                <asp:ControlParameter  ControlID="keywordTB" Name="title"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="keywordTB" Name="description"
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
    </asp:Panel>
</asp:Content>
