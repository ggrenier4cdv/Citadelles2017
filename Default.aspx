<%@ page language="C#" autoeventwireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MENU</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/IMAGE.gif" />
            <br />
            <table>     
                <tr>
                    <td>
                        <a href="Default2.aspx">Intialisation (liste des Vins + purge saisie)</a>
                    </td>
                </tr>                <tr>
                    <td>
                        <a href="Default3.aspx">Importation fichier saisie</a>
                    </td>
                </tr>
                <tr>
                    <td >
                        <a href="Default4.aspx">Vérification d'une série saisie</a>
                    </td>
                </tr>
                <tr>
                    <td >
                        <a href="Default5.aspx">Précalcul</a>
                    </td>
                </tr>
                <tr>
                    <td >
                        <a href="Default6.aspx">Consultation</a>
                    </td>
                </tr>
                <tr>
                    <td >
                        <a href="Default9.aspx">Export CSV</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
