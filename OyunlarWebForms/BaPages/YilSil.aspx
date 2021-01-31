<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YilSil.aspx.cs" Inherits="OyunlarWebForms.BaPages.YilSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Yıl Sil" Font-Bold="True"></asp:Label>
        &nbsp;</p>
    <p>
        <asp:Label ID="label11" runat="server" Text="Değeri:"></asp:Label>
        &nbsp;<asp:Label ID="lblDegeri" runat="server"></asp:Label>
        &nbsp;</p>
    <p>
        Yıl kaydını silmek istiyor musunuz?&nbsp;</p>
    <p>
        <asp:Button ID="btnEvet" runat="server" BackColor="Green" OnClick="btnEvet_Click" Text="Evet" />
        &nbsp;<asp:Button ID="btnHayir" runat="server" BackColor="Red" OnClick="btnHayir_Click" Text="Hayır" />
        </p>
    <asp:Label ID="lblBilgi" runat="server" BorderColor="#CE5D5A"></asp:Label>
</asp:Content>
