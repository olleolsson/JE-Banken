<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLilla.aspx.cs" Inherits="JE_Bank.indexLilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>



    <script>
        $(function () {
            $("#accordion").accordion();
            
        });
    </script>

    <title></title>
</head>
<body>

   

    <link href="StyleSheetFragor.css" rel="stylesheet" />
                <form runat="server">


                    <div id="accordion">

  <h3>Fråga 1</h3>
      
    <div>
 
  <fieldset>
    <p>Vilken stad ligger i England?</p>
    <label for="radio-1">New York</label>
    <input type="radio" name="radio-1" id="radio-1"/>
    <label for="radio-2">Paris</label>
    <input type="radio" name="radio-1" id="radio-2"/>
    <label for="radio-3">London</label>
    <input type="radio" name="radio-1" id="radio-3"/>
  </fieldset>
        
  </div>
  <h3>Fråga 2</h3>
  <div>
 
  </div>
        
  <h3>Fråga 3</h3>
  <div>
    <p>
    Nam enim risus, molestie et, porta ac, aliquam ac, risus. Quisque lobortis.
    Phasellus pellentesque purus in massa. Aenean in pede. Phasellus ac libero
    ac tellus pellentesque semper. Sed ac felis. Sed commodo, magna quis
    lacinia ornare, quam ante aliquam nisi, eu iaculis leo purus venenatis dui.
    </p>
    <ul>
      <li>List item one</li>
      <li>List item two</li>
      <li>List item three</li>
    </ul>
  </div>
  <h3>Fråga 4</h3>
  <div>
    <p>
    Cras dictum. Pellentesque habitant morbi tristique senectus et netus
    et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in
    faucibus orci luctus et ultrices posuere cubilia Curae; Aenean lacinia
    mauris vel est.
    </p>
    <p>
    Suspendisse eu nisl. Nullam ut libero. Integer dignissim consequat lectus.
    Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
    inceptos himenaeos.
    </p>
  </div>
</div>

    <div id="allafrågor" runat="server">

        <div class="frågeruta" runat="server">
            <div class="frågenummer" id="fråga1" runat="server">Fråga 1</div>
            <div class="frågan" runat="server">Vad är meningen med livet?</div>


            <div class="svarsalternativ" runat="server">1
                <asp:RadioButton ID="rbtn1" GroupName="fråga1" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">2
                <asp:RadioButton ID="rbtn2" GroupName="fråga1" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">3
                <asp:RadioButton ID="rbtn3" GroupName="fråga1" runat="server" />
            </div>

            <div class="svarsalternativ" runat="server">
                <asp:RadioButton ID="rbtn4" GroupName="fråga1" Text="42" runat="server" />

            </div>    

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
