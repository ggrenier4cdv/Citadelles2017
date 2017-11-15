<%@ page language="C#" autoeventwireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COMMISSION</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default6.aspx">RETOUR</a>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ORDRE"
                DataSourceID="SqlDataSource1" OnRowUpdated="GridView1_RowUpdated" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="ORDRE" HeaderText="ORDRE" ReadOnly="True" SortExpression="ORDRE" />
                    <asp:BoundField DataField="NOTE" HeaderText="NOTE" ItemStyle-Font-Bold=true ReadOnly="True" SortExpression="NOTE" />
                    <asp:BoundField DataField="ECARTTYPE" HeaderText="ECARTTYPE" ReadOnly="True" SortExpression="ECARTTYPE" />
                    <asp:BoundField DataField="MEDAILLE" HeaderText="MEDAILLE" ReadOnly="True"
                        SortExpression="MEDAILLE" />
                  
                    <asp:BoundField DataField="JURY" HeaderText="JURY" ReadOnly="True" SortExpression="JURY" />
                    
                    <asp:TemplateField HeaderText="JURE1" SortExpression="JURE1">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" Width="35" MaxLength="5" runat="server" Text='<%# Bind("JURE1") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("JURE1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JURE2" SortExpression="JURE2">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" Width="35" MaxLength="5" runat="server" Text='<%# Bind("JURE2") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("JURE2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JURE3" SortExpression="JURE3">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" Width="35" MaxLength="5" runat="server" Text='<%# Bind("JURE3") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("JURE3") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JURE4" SortExpression="JURE4">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" Width="35" MaxLength="5" runat="server" Text='<%# Bind("JURE4") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("JURE4") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="JURE5" SortExpression="JURE5">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" Width="35" MaxLength="5" runat="server" Text='<%# Bind("JURE5") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("JURE5") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:BoundField DataField="JOUR" HeaderText="JOUR" ReadOnly="True" SortExpression="JOUR" />
                    <asp:BoundField DataField="SERIE" HeaderText="SERIE" ReadOnly="True" SortExpression="SERIE" />
                    <asp:BoundField DataField="RANG" HeaderText="RANG" ReadOnly="True" SortExpression="RANG" />
                    <asp:BoundField DataField="CATEGORIE" HeaderText="CATEGORIE" ReadOnly="True" SortExpression="CATEGORIE" />
                    <asp:BoundField DataField="PAYS" HeaderText="PAYS" ReadOnly="True" SortExpression="PAYS" />
                    <asp:BoundField DataField="APPELLATION" HeaderText="APPELLATION" ReadOnly="True"
                        SortExpression="APPELLATION" />
                    <asp:BoundField DataField="MILLESIME" HeaderText="MILLESIME" ReadOnly="True" SortExpression="MILLESIME" />
                    <asp:BoundField DataField="FIRME" HeaderText="FIRME" ReadOnly="True" SortExpression="FIRME" />
                    <asp:BoundField DataField="NOM" HeaderText="NOM" ReadOnly="True" SortExpression="NOM" />
                    <asp:BoundField DataField="CRU OU MARQUE" HeaderText="CRU OU MARQUE" ReadOnly="True"
                        SortExpression="CRU OU MARQUE" />
                    <asp:BoundField DataField="CAB" HeaderText="CAB" ReadOnly="True" SortExpression="CAB" />
                    <asp:BoundField DataField="VOLUME" HeaderText="VOLUME" ReadOnly="True" SortExpression="VOLUME" />
                    <asp:BoundField DataField="CEPAGE" HeaderText="CEPAGE" ReadOnly="True" SortExpression="CEPAGE" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <EditRowStyle BackColor=OrangeRed Font-Bold=true />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT ORDRE, NOTE, ECARTTYPE, CASE WHEN NOTE >= [OR] THEN 'OR' WHEN NOTE >= [ARGENT] AND NOTE < [OR] THEN 'ARGENT' WHEN NOTE >= [BRONZE] AND NOTE < [ARGENT] THEN 'BRONZE' ELSE '' END AS MEDAILLE, JURY, JURE1, JURE2, JURE3, JURE4, JURE5, JOUR, SERIE, RANG, [PRECALCUL].CATEGORIE, PAYS, APPELLATION, MILLESIME, FIRME, NOM, PRENOM, [CRU OU MARQUE], CAB, [NUMERO OXY], VOLUME, CEPAGE FROM [PRECALCUL], SEUIL_BY_CATEG SEUIL WHERE [PRECALCUL].CATEGORIE = SEUIL.CATEGORIE  AND ([PRECALCUL].[CATEGORIE] = @CATEGORIE) ORDER BY [NOTE] DESC"
                UpdateCommand="UPDATE PRECALCUL SET JURE1=@JURE1, JURE2=@JURE2, JURE3=@JURE3, JURE4=@JURE4, JURE5=@JURE5 WHERE ORDRE=@ORDRE UPDATE PRECALCUL SET NOTE = (SELECT AVG(CAST(JURE1 AS FLOAT)) FROM (SELECT JURE1 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE1 <> -1 UNION ALL SELECT JURE2 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE2 <> -1 UNION ALL SELECT JURE3 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE3 <> -1 UNION ALL SELECT JURE4 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE4 <> -1 UNION ALL SELECT JURE5 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE5 <> -1) TAB), ECARTTYPE = (SELECT ROUND(STDEV(CAST(JURE1 AS FLOAT)),2) FROM (SELECT JURE1 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE1 <> -1 UNION ALL SELECT JURE2 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE2 <> -1 UNION ALL SELECT JURE3 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE3 <> -1 UNION ALL SELECT JURE4 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE4 <> -1 UNION ALL SELECT JURE5 FROM PRECALCUL WHERE ORDRE=@ORDRE AND JURE5 <> -1) TAB) WHERE ORDRE=@ORDRE">
                <SelectParameters>
                    <asp:QueryStringParameter Name="CATEGORIE" QueryStringField="CATEGORIE" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
