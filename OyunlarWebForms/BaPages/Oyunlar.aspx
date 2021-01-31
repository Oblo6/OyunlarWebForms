<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Oyunlar.aspx.cs" Inherits="OyunlarWebForms.BaPages.Oyunlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:LinkButton ID="lbYeni" runat="server" OnClick="lbYeni_Click">Yeni Oyun</asp:LinkButton>
    <br />
    <br />
    Oyun Listesi
    <br />
    <br />
    <asp:GridView ID="gvOyunlar" runat="server" Width="420px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" />
            <asp:BoundField DataField="Adi" HeaderText="Oyun Adı" />
            <asp:BoundField DataField="Maliyeti" HeaderText="Oyun Maliyeti" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Kazanci" HeaderText="Oyun Kazancı" />
            <asp:BoundField DataField="KarZarar" HeaderText="Kar Zarar" DataFormatString="{0:C2}" />
            <asp:BoundField DataField="YilDegeri" HeaderText="Oyun Yılı" />
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
    <asp:Button ID="btnDetay" runat="server" Text="Detay" BackColor="#CE5D5A" OnClick="btnDetay_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDuzenle" runat="server" Text="Düzenle" BackColor="#CE5D5A" OnClick="btnDuzenle_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSil" runat="server" Text="Sil" BackColor="#CE5D5A" OnClick="btnSil_Click" />
    <br />
    <asp:Label ID="lblBilgi" runat="server" BorderColor="#CE5D5A"></asp:Label>
    <br />
    <asp:Panel ID="pDetay" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Oyun Detayı"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lAdi" runat="server" Text="Adı:"></asp:Label>
        <asp:Label ID="lblAdi" runat="server"></asp:Label>
        <br />
        Maliyeti:<asp:Label ID="lblMaliyeti" runat="server"></asp:Label>
        <br />
        Kazancı:<asp:Label ID="lblKazanci" runat="server"></asp:Label>
        <br />
        Yılı:<asp:Label ID="lblYili" runat="server"></asp:Label>
        <br />
        Oyun Türleri:
        <asp:Label ID="lblTurleri" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pYeni" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="lblYeni" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Yeni Oyun"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lAdi0" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtAdiYeni" runat="server" Width="350px"></asp:TextBox>
        <br />
        Maliyeti:<asp:TextBox ID="txtMaliyetiYeni" runat="server" Width="200px"></asp:TextBox>
        <br />
        Kazancı:<asp:TextBox ID="txtKazanciYeni" runat="server" Width="200px"></asp:TextBox>
        <br />
        Yılı:<asp:DropDownList ID="ddlYiliYeni" runat="server" Height="26px" Width="175px">
        </asp:DropDownList>
        <br />
        Oyun Türleri:<asp:ListBox ID="lbTürleri" runat="server" Height="53px" SelectionMode="Multiple" Width="217px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnKaydetYeni" runat="server" BackColor="#CE5D5A" OnClick="btnKaydetYeni_Click" Text="Kaydet" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTemizleYeni" runat="server" BackColor="#CE5D5A" OnClick="btnTemizleYeni_Click" Text="Temizle" />
    </asp:Panel>
    <asp:Panel ID="pDuzenle" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="lblYeni0" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Oyun Düzenle"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lAdi1" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtAdiDuzenle" runat="server" Width="350px"></asp:TextBox>
        <br />
        Maliyeti:<asp:TextBox ID="txtMaliyetiDuzenle" runat="server" Width="200px"></asp:TextBox>
        <br />
        Kazancı:<asp:TextBox ID="txtKazanciDuzenle" runat="server" Width="200px"></asp:TextBox>
        <br />
        Yılı:<asp:DropDownList ID="ddlYiliDuzenle" runat="server" Height="26px" Width="121px">
        </asp:DropDownList>
        <br />
        Otun Türleri:
        <asp:CheckBoxList ID="cblTurleriDuzenle" runat="server">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="btnKaydetDuzenle" runat="server" BackColor="#CE5D5A" OnClick="btnKaydetDuzenle_Click" Text="Kaydet" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTemizleDüzenle" runat="server" BackColor="#CE5D5A" Text="Temizle" OnClick="btnTemizleDüzenle_Click" />
    </asp:Panel>
    <br />
    </asp:Content>
