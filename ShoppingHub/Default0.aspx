<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default0.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
        </p>
    <p>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                catlink:
                <asp:Label ID="catlinkLabel" runat="server" Text='<%# Eval("catlink") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ShoppingHubCS %>" 
            SelectCommand="SELECT [catlink] FROM [category]"></asp:SqlDataSource>
    </p>
</asp:Content>
