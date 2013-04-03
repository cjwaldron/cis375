<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="cis375projectmysqlDB.search" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server" 
            style="margin-left:100px; margin-top:30px; margin-bottom:30px;" 
            Height="32px" Width="94px">
            <asp:Button ID="Button1" runat="server" Text="All Items" 
                style="margin-right: 10px;" onclick="Button1_Click" /> 
            
         </asp:Panel>
            <asp:Panel ID="Panel3" runat="server"  ScrollBars="Auto" 
                style="margin-top:30px; margin-right: 17px;"  Visible="false" 
                Height="250px">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="Cancel" Text="See Item" ButtonType="Button" />
                        <asp:ImageField>
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT itemid, title, category, description, enddate, price, buyitnow FROM item">
                </asp:SqlDataSource>
                
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server" Height="250px" ScrollBars="Auto">
                <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 10px;" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged"  AutoPostBack="true" >
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Sports</asp:ListItem>
                    <asp:ListItem>Clothes</asp:ListItem>
                    <asp:ListItem>Books</asp:ListItem>
                    <asp:ListItem>Computer</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                Search By Category<br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cis375projectConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:cis375projectConnectionString2.ProviderName %>" 
                    
                    SelectCommand="SELECT title, category, itemid, description, enddate, price, buyitnow FROM item WHERE (category = ?)">
                    <SelectParameters>
                    <asp:ControlParameter name="category" ControlID="DropDownList1" PropertyName="SelectedValue" Type="String" />
                     </SelectParameters> 
                </asp:SqlDataSource>
                <asp:GridView ID="GridView2" runat="server" 
                    DataSourceID="SqlDataSource2"   Heigth="250px">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" Text="See Item" />
                        <asp:ImageField>
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>



            </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" Height="250px">
        Search by keyword
        <asp:TextBox ID="KeywordTB" runat="server" style="margin-right: 10px;" 
                Width="164px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Search" 
                style="margin-right: 10px;" onclick="Button2_Click" />
        <br />
        <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="See Item" />
                <asp:ImageField>
                </asp:ImageField>
            </Columns>
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
