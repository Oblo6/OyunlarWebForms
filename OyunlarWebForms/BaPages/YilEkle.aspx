<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YilEkle.aspx.cs" Inherits="OyunlarWebForms.BaPages.YilEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Yıl Ekle" Font-Bold="True"></asp:Label>
        &nbsp;</p>
    <p>
        <asp:Label ID="lAdi" runat="server" Text="Değeri:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtDegeri" runat="server" Width="206px"></asp:TextBox>
        &nbsp;</p>
    <p>
        &nbsp;<asp:Button ID="btnKaydet" runat="server" BackColor="#CE5D5A"  Text="Kaydet" OnClick="btnKaydet_Click" />       
        </p>
    <p>
    <asp:Label ID="lblBilgi" runat="server" BorderColor="#CE5D5A"></asp:Label>
        </p>    
</asp:Content>
