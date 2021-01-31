<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurDetayi.aspx.cs" Inherits="OyunlarWebForms.BaModels.TurDetayi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="Tür Detayi"></asp:Label>
        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lAdi" runat="server" Text="Adı:"></asp:Label>
        &nbsp;
        <asp:Label ID="lblAdi" runat="server"></asp:Label>
        </p>
    <p>
        <asp:ImageButton ID="ibDüzenle" runat="server" Height="48px" ImageUrl="~/BaFiles/edit.png" OnClick="ibDüzenle_Click" Width="48px" />
&nbsp;&nbsp;
        <asp:ImageButton ID="ibSil" runat="server" Height="48px" ImageUrl="~/BaFiles/delete.png" Width="48px" OnClick="ibSil_Click" />
        </p>
    <p>
    <asp:Label ID="lblBilgi" runat="server" BorderColor="#CE5D5A"></asp:Label>
    </p>
</asp:Content>
