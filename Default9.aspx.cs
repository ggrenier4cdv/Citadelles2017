using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default9 : Page, IRequiresSessionState
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        if (this.ORDRE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "ORDRE ";
        }
        if (this.MEDAILLE_NUM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CASE WHEN NOTE >= [OR] THEN '1' WHEN NOTE >= [ARGENT] AND NOTE < [OR] THEN '2' WHEN NOTE >= [BRONZE] AND NOTE < [ARGENT] THEN '3' ELSE '' END AS MEDAILLE_NUM ";
        }
        if (this.NOTE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "NOTE ";
        }
        if (this.MEDAILLE_TXT.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CASE WHEN NOTE >= [OR] THEN 'OR' WHEN NOTE >= [ARGENT] AND NOTE < [OR] THEN 'ARGENT' WHEN NOTE >= [BRONZE] AND NOTE < [ARGENT] THEN 'BRONZE' ELSE '' END AS MEDAILLE_TXT ";
        }
      /*  if (this.APPRECIATION.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "APPRECIATION ";
        }*/
        if (this.JURY.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "JURY ";
        }
        if (this.SERIE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "SERIE ";
        }
        if (this.RANG.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "RANG ";
        }
        if (this.CATEGORIE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "[PRECALCUL].CATEGORIE ";
        }
        if (this.PAYS.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "PAYS ";
        }
        if (this.APPELLATION.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "APPELLATION ";
        }
        if (this.MILLESIME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "MILLESIME ";
        }
        if (this.FIRME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "FIRME ";
        }
        if (this.NOM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "NOM ";
        }
        if (this.PRENOM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "PRENOM ";
        }
        if (this.CRU_OU_MARQUE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "[CRU OU MARQUE] ";
        }
        if (this.CAB.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CAB ";
        }
        if (this.NUMERO_OXY.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "[NUMERO OXY] ";
        }
        if (this.VOLUME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "VOLUME ";
        }
        if (this.CEPAGE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CEPAGE ";
        }
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + str + "FROM [PRECALCUL], SEUIL_BY_CATEG SEUIL WHERE [PRECALCUL].CATEGORIE = SEUIL.CATEGORIE ORDER BY [NOTE] DESC", connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "CSV");
            DataTable dt = dataSet.Tables["CSV"];
            this.CreateCSVFile(dt, @"D:\02 - CITADELLES\Export_" + DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-') + ".csv");
            connection.Close();
        }
    }

    public void CreateCSVFile(DataTable dt, string strFilePath)
    {
        StreamWriter writer = new StreamWriter(strFilePath, false);
        int count = dt.Columns.Count;
        for (int i = 0; i < count; i++)
        {
            writer.Write(dt.Columns[i]);
            if (i < (count - 1))
            {
                writer.Write(";");
            }
        }
        writer.Write(writer.NewLine);
        foreach (DataRow row in dt.Rows)
        {
            for (int j = 0; j < count; j++)
            {
                if (!Convert.IsDBNull(row[j]))
                {
                    writer.Write(row[j].ToString());
                }
                if (j < (count - 1))
                {
                    writer.Write(";");
                }
            }
            writer.Write(writer.NewLine);
        }
        writer.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

