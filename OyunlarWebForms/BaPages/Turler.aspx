<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turler.aspx.cs" Inherits="OyunlarWebForms.BaPages.Turler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:Label ID="lblTurler" runat="server" Font-Bold="True" Font-Size="14pt" Text="Tür Listesi"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lbEkle" runat="server" OnClick="lbEkle_Click">Yeni Tür Ekle</asp:LinkButton>
    <br />
    <br />
    <asp:GridView ID="gvTurler" runat="server" Width="420px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvTurler_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Detay" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" />
            <asp:BoundField DataField="Adi" HeaderText="Tür Adı" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    </p>
</asp:Content>
