<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="JE_Bank.logIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnLogIn1" runat="server" OnClick="btnLogIn1_Click" Text="Användare 1" />
    <asp:Button ID="btnLogIn2" runat="server" OnClick="btnLogIn2_Click" Text="Användare 2" />
    <asp:Button ID="btnLogIn3" runat="server" OnClick="btnLogIn3_Click" Text="Användare 3" />
    <asp:Button ID="btnLogIn4" runat="server" OnClick="btnLogIn4_Click" Text="Användare 4" />
    <asp:Button ID="btnAdmin" runat="server" OnClick="btnAdmin_Click" Text="Admin" />
</asp:Content>
