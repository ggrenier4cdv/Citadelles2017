<%@ page language="C#" autoeventwireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IMPORTATION FICHIER CSV : SAISIE OPTIQUE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <a href="Default.aspx">MENU</a>
        <br />
        <br />
            Nb Fiches déjà importées : <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            Nb Echantillons déjà importés : <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Importer" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nb Fiches ajoutées :" Visible="false"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Nb Echantillons ajoutées :" Visible="false"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
        
        </div>
    </form>
</body>
</html>
