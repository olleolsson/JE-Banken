<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLilla.aspx.cs" Inherits="JE_Bank.indexLilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="StyleSheetFragor.css" rel="stylesheet" />
    <form id="form1" runat="server">

    <div id="allafrågor" runat="server">

        <div class="frågeruta" runat="server">
            <div class="frågenummer" id="fråga1" runat="server">Fråga 1</div>
            <div class="frågan" runat="server">Vad är meningen med livet?</div>

            
            <div class="svarsalternativ" runat="server">1
                <asp:RadioButton ID="RadioButton1" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">2
                <asp:RadioButton ID="RadioButton2" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">3
                <asp:RadioButton ID="RadioButton3" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">42
                <asp:RadioButton ID="RadioButton4" runat="server" />
            </div>    
                  
            
            <asp:radioButtonList ID="radio1" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" OnSelectedIndexChanged="radio1_SelectedIndexChanged">
            </asp:radioButtonList>  
                <asp:radioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" OnSelectedIndexChanged="radio1_SelectedIndexChanged">
            </asp:radioButtonList>  
                   <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>

            <div class="frågeruta" runat="server">
            <div class="frågenummer" id="fråga2" runat="server">Fråga 1</div>
            <div class="frågan" runat="server">Vad är meningen med livet?</div>
            <div class="svarsalternativ" runat="server">1</div>
            <div class="svarsalternativ" runat="server">2</div>
            <div class="svarsalternativ" runat="server">3</div>
            <div class="svarsalternativ" runat="server">42</div>                     
        </div>


    </div>


    </form>


</body>
</html>
