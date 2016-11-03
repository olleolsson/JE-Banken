<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="JE_Bank.inloggad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnStartaTest" runat="server" Text="Starta Test" OnClick="btnStartaTest_Click" />
        <asp:Button ID="btnHistorik" runat="server" Text="Se historik" OnClick="btnHistorik_Click" />
        <asp:Label ID="lblDatum" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
