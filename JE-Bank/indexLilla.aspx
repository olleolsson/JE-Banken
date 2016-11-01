<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLilla.aspx.cs" Inherits="JE_Bank.indexLilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="StyleSheetFragor.css" rel="stylesheet" />
    <form id="form1" runat="server">
        
    <asp:Panel id="allafragar" runat="server">
        <asp:Panel class="frågeruta" runat="server">
            <asp:Panel class="frågenummer" id="fraga1" runat="server"></asp:Panel>
            <asp:Panel class="frågan" runat="server">Vad är meningen med livet?</asp:Panel>
            
            
                
            <asp:Panel class="svarsalternativ" runat="server">1
                <asp:RadioButton ID="RButton1" runat="server" GroupName="1"/>
            </asp:Panel>

            <asp:Panel class="svarsalternativ" runat="server">2
                <asp:RadioButton ID="RButton2" runat="server" GroupName="1"/>
            </asp:Panel>

            <asp:Panel class="svarsalternativ" runat="server">3
                <asp:RadioButton ID="RButton3" runat="server" GroupName="1" />
            </asp:Panel>

            <asp:Panel class="svarsalternativ" runat="server">42
                
    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="1" />
            </asp:Panel>  
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>  
                     
        </asp:Panel>

            <div class="frågeruta" runat="server">
            <div class="frågenummer" id="fråga2" runat="server">Fråga 1</div>
            <div class="frågan" runat="server">Vad är meningen med livet?</div>
            <div class="svarsalternativ" runat="server">1</div>
            <div class="svarsalternativ" runat="server">2</div>
            <div class="svarsalternativ" runat="server">3</div>
            <div class="svarsalternativ" runat="server">42</div>                     
        </div>

    </asp:Panel>
    </form> 

    


</body>
</html>
