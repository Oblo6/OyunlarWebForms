<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurSil.aspx.cs" Inherits="OyunlarWebForms.BaPages.TurSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Tür Sil" Font-Bold="True"></asp:Label>
        &nbsp;</p>
    <p>
        <asp:Label ID="lAdi" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:Label ID="lblAdi" runat="server"></asp:Label>
        &nbsp;</p>
    <p>
        Tür kaydını silmek istiyor musunuz?&nbsp;</p>
    <p>
        <asp:Button ID="btnEvet" runat="server" BackColor="#CE5D5A" OnClick="btnEvet_Click" Text="Evet" />
        &nbsp;<asp:Button ID="btnHayir" runat="server" BackColor="#CE5D5A" OnClick="btnHayir_Click" Text="Hayır" />
        </p>
</asp:Content>
