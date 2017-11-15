<%@ page language="C#" autoeventwireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IMPORTATION FICHIER EXCEL : LISTE VINS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="Default.aspx">MENU</a>
        <br />
        <br />
     <asp:FileUpload ID="FileUpload1" runat="server" />
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="importer 'lectureoptique.csv'" OnClick="Button1_Click" />             
        <br /><hr /><br />
        <asp:Button ID="Button2" runat="server" Text="Purge saisie optique" OnClick="Button2_Click" />             
    </div>
    </form>
</body>
</html>
