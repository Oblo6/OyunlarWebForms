<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurDuzenle.aspx.cs" Inherits="OyunlarWebForms.BaPages.TurDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Tür Düzenle" Font-Bold="True"></asp:Label>
        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lAdi" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtAdi" runat="server" Width="206px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;<asp:Button ID="btnKaydet" runat="server" BackColor="#CE5D5A" OnClick="btnKaydet_Click" Text="Kaydet" />
        &nbsp;
        <asp:Button ID="btnDetay" runat="server" BackColor="#CE5D5A" OnClick="btnDetay_Click" Text="Detay" />
        </p>
    <p>
    <asp:Label ID="lblBilgi" runat="server" BorderColor="#CE5D5A"></asp:Label>
    </p>
</asp:Content>
