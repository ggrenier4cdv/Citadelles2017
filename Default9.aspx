<%@ page language="C#" autoeventwireup="true" CodeFile="Default9.aspx.cs" Inherits="Default9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EXPORT</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default.aspx">MENU</a>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="ORDRE" runat="server" Checked="true" />ORDRE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="MEDAILLE_NUM" runat="server" Checked="true" />MEDAILLE (1, 2, 3)</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NOTE" runat="server" Checked="true" />NOTE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="MEDAILLE_TXT" runat="server" />MEDAILLE (OR, AREGNT, BRONZE)</td>
                </tr>
                <!-- tr>
                    <td>
                        <asp:CheckBox ID="APPRECIATION" runat="server" />APPRECIATION</td>
                </tr -->
                <tr>
                    <td>
                        <asp:CheckBox ID="JURY" runat="server" />JURY</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="SERIE" runat="server" />SERIE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="RANG" runat="server" />RANG</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CATEGORIE" runat="server" />CATEGORIE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="PAYS" runat="server" />PAYS</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="APPELLATION" runat="server" />APPELLATION</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="MILLESIME" runat="server" />MILLESIME</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="FIRME" runat="server" />FIRME</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NOM" runat="server" />NOM</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="PRENOM" runat="server" />PRENOM</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CRU_OU_MARQUE" runat="server" />CRU OU MARQUE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CAB" runat="server" />CAB</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NUMERO_OXY" runat="server" />NUMERO OXY</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="VOLUME" runat="server" />VOLUME</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CEPAGE" runat="server" />CEPAGE</td>
                </tr>
            </table>
               <asp:Button ID="Button1" runat="server" Text="exporter" OnClick="Button1_Click" />             
 </div>
    </form>
</body>
</html>
