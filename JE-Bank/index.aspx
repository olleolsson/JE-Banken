<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="JE_Bank.index"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="allafrågor" runat="server"></div>
    <link href="StyleSheetFragor.css" rel="stylesheet" />
    <asp:Button ID="btnRätta" runat="server" Text="Rätta och skicka in!" OnClick="btnRätta_Click" />
    <p id="ptagg" runat="server"></p>
</asp:Content>
