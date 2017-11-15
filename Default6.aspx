<%@ page language="C#" autoeventwireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONSULTATION</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default.aspx">MENU</a>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Afficher %Degust" Width="150px"  OnClick="Button2_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Afficher Seuils" Width="150px" OnClick="Button3_Click" />
            <br />
            <table border="0" width="85%" align=center>
            <tr valign=top><td align=center>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/IMAGE.gif" />
                <br />
            <table border="0" align=center>
                <tr style="background-color: Gold">
                    <td>
                         Citadelles d'Or :
                    </td>
                    <!--td align="center">
                        <asp:TextBox ID="OR" runat="server" Text="" Width="60px" />
                    </td-->
                    <td align="center">
                        <asp:Label ID="pOR" runat="server" Text="" Width="60px"   />
                    </td>
                    <td align="center">
                        <asp:Label ID="nbOR" runat="server" Text="" Width="60px"  />
                    </td>
                </tr>
                <tr style="background-color: Silver">
                    <td>
                        Citadelles d'Argent :
                    </td>
                    <!--td align="center">
                        <asp:TextBox ID="ARGENT" runat="server" Text="" Width="60px" />
                    </td-->
                    <td align="center">
                        <asp:Label ID="pARGENT" runat="server" Text="" Width="60px" />
                    </td>
                    <td align="center">
                        <asp:Label ID="nbARGENT" runat="server" Text="" Width="60px" />
                    </td>
                </tr>
                <!--tr style="background-color: #CD7F32">
                    <td>
                        Seuil Citadelles de Bronze :
                    </td>
                    <td>
                        <asp:TextBox ID="BRONZE" runat="server" Text="" Visible="false"/>
                    </td>
                    <td>
                        <asp:Label ID="pBRONZE" runat="server" Text="" />
                    </td>
                    <td>
                        <asp:Label ID="nbBRONZE" runat="server" Text="" />
                    </td>
                </tr-->
                <tr>
                    <!--td align="center">
                        <asp:Button ID="Button1" runat="server" Text="Mise à Jour" OnClick="Button1_Click" /><br />
                    </td-->
                    <td align="center"> Médailles
                     </td>
                    <td align="center">
                <asp:Label ID="pMedailles" runat="server" Text=""              
                
                   />
                    </td>
                    <td align="center">
                <asp:Label ID="nbMedailles" runat="server" Text=""              
                
                   />
                    </td>
                    </tr>
                <tr>
                    <!--td align="center">
                    </td-->
                    <td align="center"> TOTAL
                     </td>
                    <td align="center">
                    </td>
                    <td align="center">
                <asp:Label ID="nbTOTAL" runat="server" Text=""              
                
                   />
                    </td>
                    </tr>
            </table>
        </div>
        </td><td align=center>
                    <!--asp:BoundField DataField="NbBronze" ItemStyle-Width="50px" ItemStyle-BackColor="#CD7F32" HeaderText=" C. Br " SortExpression="NbBronze" /-->
                    <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False"
                         OnRowDataBound="RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="PRIX SPECIAUX" SortExpression="PRIX" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Button Width="100%" ID="LinkButton1" runat="server" PostBackUrl="~/Default8b.aspx" CommandName="PRIX"
                                        CommandArgument='<%# Eval("PRIX") %>' Text='<%# Eval("PRIX") %>' />
                                    <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NbOr" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Gold HeaderText=" Or " SortExpression="NbOr" />
                            <asp:BoundField DataField="NbArgent" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Silver HeaderText=" Argent " SortExpression="NbArgent" />
                            <asp:BoundField DataField="None" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=White HeaderText=" Aucune " SortExpression="None" />
                            <asp:BoundField DataField="TOTAL" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="White" ItemStyle-BackColor="Black" HeaderText=" Total " SortExpression="None" />
                            <asp:BoundField DataField="PoucentMedaille" HeaderText="% Medaille" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentMedaille" />
                            <asp:BoundField DataField="PoucentDegust" HeaderText="% Degust" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentDegust" Visible="false" ReadOnly="true"  />

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
</td></tr></table><hr />
         <table border="0" width="85%" align="center">
            <tr>

                <td valign="top" align="center">
                     <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
                        OnRowDataBound="RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="PAYS" SortExpression="PAYS" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Button Width="100%" ID="LinkButton1" runat="server" PostBackUrl="~/Default7.aspx" CommandName="PAYS"
                                        CommandArgument='<%# Eval("PAYS") %>' Text='<%# Eval("PAYS") %>' />
                                    <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NbOr" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Gold HeaderText=" Or " SortExpression="NbOr" />
                            <asp:BoundField DataField="NbArgent" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Silver HeaderText=" Argent " SortExpression="NbArgent" />
                            <asp:BoundField DataField="None" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=White HeaderText=" Aucune " SortExpression="None" />
                            <asp:BoundField DataField="TOTAL" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="White" ItemStyle-BackColor="Black" HeaderText=" Total " SortExpression="None" />
                            <asp:BoundField DataField="PoucentMedaille" HeaderText="% Medaille" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentMedaille" />
                            <asp:BoundField DataField="PoucentDegust" HeaderText="% Degust" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentDegust" Visible="false" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                </td>
                <td valign="top" align="center">

                <asp:Table runat="server" border="0" align="center" id="TableSeuil" Visible="false">
                <asp:TableRow style="background-color: Gold" HorizontalAlign="Center">
                    <asp:TableCell>
                         Seuil Or :
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="SeuilOR" runat="server" Text="" Width="60px" />
                    </asp:TableCell>
                    <asp:TableCell>
                         % Or :
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="PourcentOr" runat="server" Text="" Width="60px" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow style="background-color: Silver" HorizontalAlign="Center">
                    <asp:TableCell>
                        Seuil Argent :
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="SeuilARGENT" runat="server" Text="" Width="60px" />
                    </asp:TableCell>
                    <asp:TableCell>
                         % Médaillé (Or+Argent) :
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="PourcentArgent" runat="server" Text="" Width="60px" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="ButtonSeuil_Click" runat="server" Text="MaJ de TOUS les Seuils" OnClick="ButtonSeuil_Click_Click" />
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="ButtonPourcent_Click" runat="server" Text="MaJ de TOUS les Seuils" OnClick="ButtonPourcent_Click_Click" />
                    </asp:TableCell>
                </asp:TableRow>
  
                </asp:Table>

                    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" 
                        OnRowDataBound="RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowEditing="GridView2_RowEditing" OnRowUpdated="GridView2_RowUpdated" OnRowCancelingEdit="GridView2_RowCancelingEdit">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ButtonType="Button" UpdateText="Sauv." EditText="Modifier Seuils" CancelText="Ann."/>
                            <asp:TemplateField HeaderText="CATEGORIE" SortExpression="CATEGORIE" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button Width="100%" ID="LinkButton1" runat="server" PostBackUrl="~/Default8.aspx" CommandName="CATEGORIE"
                                        CommandArgument='<%# Eval("CATEGORIE") %>' Text='<%# Eval("CATEGORIE") %>' />
                                </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("CATEGORIE") %>'></asp:Label>
                                  </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cit. d'OR" SortExpression="OR" ItemStyle-HorizontalAlign="Center"  Visible="false">
                                  <EditItemTemplate>
                                  <asp:TextBox ID="TextBoxOR" Width="35" MaxLength="5" runat="server" Text='<%# Bind("OR") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                  <asp:Label ID="LabelOR" runat="server" Text='<%# Bind("OR") %>'></asp:Label>
                                  </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cit. D'AR" SortExpression="ARGENT" ItemStyle-HorizontalAlign="Center" Visible="false" >
                                  <EditItemTemplate>
                                  <asp:TextBox ID="TextBoxAR" Width="35" MaxLength="5" runat="server" Text='<%# Bind("ARGENT") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                  <asp:Label ID="LabelAR" runat="server" Text='<%# Bind("ARGENT") %>'></asp:Label>
                                  </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NbOr" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Gold HeaderText=" Or " SortExpression="NbOr" ReadOnly="true" />
                            <asp:BoundField DataField="NbArgent" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=Silver HeaderText=" Argent " SortExpression="NbArgent" ReadOnly="true"  />
                            <asp:BoundField DataField="None" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor=White HeaderText=" Aucune " SortExpression="None" ReadOnly="true"  />
                            <asp:BoundField DataField="TOTAL" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="White" ItemStyle-BackColor="Black" HeaderText=" Total " SortExpression="None" ReadOnly="true"  />
                            <asp:BoundField DataField="PoucentMedaille" HeaderText="% Medaille" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentMedaille" ReadOnly="true"  />
                            <asp:BoundField DataField="PoucentDegust" HeaderText="% Degust" ItemStyle-HorizontalAlign="Center" SortExpression="PoucentDegust" Visible="false" ReadOnly="true"  />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle BackColor="OrangeRed" Font-Bold="true" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT TMP.PAYS, SUM(TMP.NbOr) As NbOr, SUM(TMP.NbArgent) As NbArgent, SUM(TMP.NbBronze) As NbBronze, SUM(TMP.None) As None, SUM(1) As Total, CAST( SUM(TMP.NbOr+TMP.NbArgent+TMP.NbBronze)*100 / SUM(1) AS VARCHAR(255)) + '%' As PoucentMedaille, CAST(SUM(1)*100 / (SELECT COUNT(*) FROM LISTE_VINS LV WHERE LV.PAYS= TMP.PAYS      ) AS VARCHAR(255)) + '%' As PoucentDegust FROM (SELECT PR.PAYS, CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent, CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL WHERE PR.CATEGORIE = SEUIL.CATEGORIE) TMP GROUP BY TMP.PAYS ORDER BY TMP.PAYS" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT PR.CATEGORIE, SEUIL.[OR], SEUIL.[ARGENT], SEUIL.[BRONZE], SUM(CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END) AS NbOr, SUM(CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END) AS NbArgent, SUM(CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END) AS NbBronze, SUM(CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END) AS None, SUM(1) As Total, CAST(SUM(CASE WHEN NOTE >= SEUIL.[BRONZE] THEN 1 ELSE 0 END)*100 / SUM(1) AS VARCHAR(255)) + '%' As PoucentMedaille, CAST(SUM(1)*100 / (SELECT COUNT(*) FROM LISTE_VINS LV WHERE LV.CATEGORIE= PR.CATEGORIE      ) AS VARCHAR(255)) + '%' As PoucentDegust FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL WHERE PR.CATEGORIE = SEUIL.CATEGORIE GROUP BY PR.CATEGORIE, SEUIL.[OR], SEUIL.[ARGENT], SEUIL.[BRONZE] ORDER BY PR.CATEGORIE"
            UpdateCommand="UPDATE SEUIL_BY_CATEG SET [OR]=REPLACE(@OR,',','.'), [ARGENT]=REPLACE(@ARGENT,',','.'), [BRONZE]=REPLACE(@ARGENT,',','.') WHERE CATEGORIE=@CATEGORIE" />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT TMP.[PRIX SPECIAUX] AS PRIX, SUM(TMP.NbOr) As NbOr, SUM(TMP.NbArgent) As NbArgent, SUM(TMP.NbBronze) As NbBronze, SUM(TMP.None) As None, SUM(1) As Total, CAST( SUM(TMP.NbOr+TMP.NbArgent+TMP.NbBronze)*100 / SUM(1) AS VARCHAR(255)) + '%' As PoucentMedaille, CAST( SUM(1)*100 / MAX(TOTALVins) AS VARCHAR(255)) + '%' As PoucentDegust FROM ( SELECT 'FIJEV' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent, CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.FIJEV IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.FIJEV IS NOT NULL UNION ALL SELECT 'HN_MALBEC' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent,CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.HN_MALBEC IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.HN_MALBEC IS NOT NULL UNION ALL SELECT 'HS_MALBEC' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent, CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.HS_MALBEC IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.HS_MALBEC IS NOT NULL UNION ALL SELECT 'HN_CAB_SAUV' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent,CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.HN_CAB_SAUV IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.HN_CAB_SAUV IS NOT NULL UNION ALL SELECT 'HS_CAB_SAUV' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent, CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.HS_CAB_SAUV IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.HS_CAB_SAUV IS NOT NULL UNION ALL SELECT 'SOMMELIER' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent,CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.SOMMELIER IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.SOMMELIER IS NOT NULL UNION ALL SELECT 'VINOFED' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent,CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.VINOFED IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.VINOFED IS NOT NULL UNION ALL SELECT 'DUAD' AS [PRIX SPECIAUX], CASE WHEN PR.NOTE >= SEUIL.[OR] THEN 1 ELSE 0 END AS NbOr, CASE WHEN PR.NOTE >= SEUIL.[ARGENT] AND PR.NOTE < SEUIL.[OR] THEN 1 ELSE 0 END AS NbArgent, CASE WHEN PR.NOTE >= SEUIL.[BRONZE] AND PR.NOTE < SEUIL.[ARGENT] THEN 1 ELSE 0 END AS NbBronze, CASE WHEN PR.NOTE < SEUIL.[BRONZE] THEN 1 ELSE 0 END AS None,(SELECT COUNT(1) FROM LISTE_VINS LV WHERE LV.DUAD IS NOT NULL ) AS TOTALVins FROM PRECALCUL PR, SEUIL_BY_CATEG SEUIL, LISTE_VINS LV  WHERE PR.CATEGORIE = SEUIL.CATEGORIE AND PR.ORDRE = LV.ORDRE  AND LV.DUAD IS NOT NULL)TMP GROUP BY TMP.[PRIX SPECIAUX] ORDER BY TMP.[PRIX SPECIAUX]"/>
   </form>
</body>
</html>
