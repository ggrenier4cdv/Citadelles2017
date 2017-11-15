using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default7 : Page, IRequiresSessionState
{
    //protected HtmlForm form1;
    //protected GridView GridView1;
    //protected Label Label1;
    //protected SqlDataSource SqlDataSource1;

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        /*using (SqlCommand command = new SqlCommand("UPDATE PRECALCUL SET NOTE=" + e.NewValues[0].ToString().Replace(',', '.') + " WHERE ORDRE=" + e.Keys[0].ToString()))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery().ToString();
                connection.Close();
            }
        }*/
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = base.Request.Params["PAYS"];
        Page.Title = base.Request.Params["PAYS"];
        if (!base.IsPostBack)
        {
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;

                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                    this.pOR.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.pARGENT.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.pMedailles.Text = command.ExecuteScalar().ToString();

                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL WHERE [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                    this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";

                    connection.Close();
                }
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[4].Text == "OR")
            e.Row.Cells[4].BackColor = System.Drawing.Color.Gold;
        else if (e.Row.Cells[4].Text == "ARGENT")
            e.Row.Cells[4].BackColor = System.Drawing.Color.Silver;
        else if (e.Row.Cells[4].Text == "BRONZE")
            e.Row.Cells[4].BackColor = System.Drawing.Color.FromArgb(205,127,50);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                   command.CommandText = "UPDATE [PRECALCUL] SET JURE1 = CASE WHEN JURE1 <> -1 AND JURE1 <> 100 THEN JURE1 + 1 ELSE JURE1 END, JURE2 = CASE WHEN JURE2 <> -1 AND JURE2 <> 100 AND (JURE1 =-1 OR JURE1 = 100) THEN JURE2 + 1 ELSE JURE2 END, JURE3 = CASE WHEN JURE3 <> -1 AND JURE3 <> 100 AND (JURE1 =-1 OR JURE1 = 100) AND (JURE2 =-1 OR JURE2 = 100) THEN JURE3 + 1 ELSE JURE3 END, JURE4 = CASE WHEN JURE4 <> -1 AND JURE4 <> 100 AND (JURE1 =-1 OR JURE1 = 100) AND (JURE2 =-1 OR JURE2 = 100) AND (JURE3 =-1 OR JURE3 = 100) THEN JURE4 + 1 ELSE JURE4 END, JURE5 = CASE WHEN JURE5 <> -1 AND JURE5 <> 100 AND (JURE1 =-1 OR JURE1 = 100) AND (JURE2 =-1 OR JURE2 = 100) AND (JURE3 =-1 OR JURE3 = 100) AND (JURE4 =-1 OR JURE4 = 100) THEN JURE5 + 1 ELSE JURE5 END WHERE ([PAYS] ='" + this.Label1.Text + "')  MERGE INTO PRECALCUL USING (SELECT ORDRE, AVG(CAST([TOTAL] AS FLOAT)) NOTE,ROUND(STDEV(CAST([TOTAL] AS FLOAT)),2) ECARTTYPE FROM ( SELECT ORDRE, JURE1 AS TOTAL FROM [PRECALCUL] WHERE JURE1 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE2 AS TOTAL FROM [PRECALCUL] WHERE JURE2 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE3 AS TOTAL FROM [PRECALCUL] WHERE JURE3 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE4 AS TOTAL FROM [PRECALCUL] WHERE JURE4 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE5 AS TOTAL FROM [PRECALCUL] WHERE JURE5 <> -1 AND [PAYS] ='" + this.Label1.Text + "' ) TMP GROUP BY ORDRE) TO_UPDATE ON (PRECALCUL.ORDRE = TO_UPDATE.ORDRE) WHEN MATCHED THEN UPDATE SET PRECALCUL.NOTE = TO_UPDATE.NOTE , PRECALCUL.ECARTTYPE = TO_UPDATE.ECARTTYPE;";
                   command.ExecuteNonQuery().ToString();

                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.pOR.Text = command.ExecuteScalar().ToString();
                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.pARGENT.Text = command.ExecuteScalar().ToString();
                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.pMedailles.Text = command.ExecuteScalar().ToString();

                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                   this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL WHERE [PAYS] ='" + this.Label1.Text.Replace("'", "''") + "'";
                   this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";

                   connection.Close();

            }
        }
        this.GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [PRECALCUL] SET JURE1 = CASE WHEN JURE1 <> -1 AND JURE1 <> 0 THEN JURE1 - 1 ELSE JURE1 END, JURE2 = CASE WHEN JURE2 <> -1 AND JURE2 <> 0 AND (JURE1 =-1 OR JURE1 = 0) THEN JURE2 - 1 ELSE JURE2 END, JURE3 = CASE WHEN JURE3 <> -1 AND JURE3 <> 0 AND (JURE1 =-1 OR JURE1 = 0) AND (JURE2 =-1 OR JURE2 = 0) THEN JURE3 - 1 ELSE JURE3 END, JURE4 = CASE WHEN JURE4 <> -1 AND JURE4 <> 0 AND (JURE1 =-1 OR JURE1 = 0) AND (JURE2 =-1 OR JURE2 = 0) AND (JURE3 =-1 OR JURE3 = 0) THEN JURE4 - 1 ELSE JURE4 END, JURE5 = CASE WHEN JURE5 <> -1 AND JURE5 <> 0 AND (JURE1 =-1 OR JURE1 = 0) AND (JURE2 =-1 OR JURE2 = 0) AND (JURE3 =-1 OR JURE3 = 0) AND (JURE4 =-1 OR JURE4 = 0) THEN JURE5 - 1 ELSE JURE5 END WHERE ([PAYS] ='" + this.Label1.Text + "')  MERGE INTO PRECALCUL USING (SELECT ORDRE, AVG(CAST([TOTAL] AS FLOAT)) NOTE,ROUND(STDEV(CAST([TOTAL] AS FLOAT)),2) ECARTTYPE FROM ( SELECT ORDRE, JURE1 AS TOTAL FROM [PRECALCUL] WHERE JURE1 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE2 AS TOTAL FROM [PRECALCUL] WHERE JURE2 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE3 AS TOTAL FROM [PRECALCUL] WHERE JURE3 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE4 AS TOTAL FROM [PRECALCUL] WHERE JURE4 <> -1 AND [PAYS] ='" + this.Label1.Text + "' UNION ALL SELECT ORDRE, JURE5 AS TOTAL FROM [PRECALCUL] WHERE JURE5 <> -1 AND [PAYS] ='" + this.Label1.Text + "' ) TMP GROUP BY ORDRE) TO_UPDATE ON (PRECALCUL.ORDRE = TO_UPDATE.ORDRE) WHEN MATCHED THEN UPDATE SET PRECALCUL.NOTE = TO_UPDATE.NOTE , PRECALCUL.ECARTTYPE = TO_UPDATE.ECARTTYPE;";
                command.ExecuteNonQuery().ToString();

                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.pOR.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.pARGENT.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.pMedailles.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE AND [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL WHERE [PAYS] ='" + this.Label1.Text.Replace("'","''") + "'";
                this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";

                connection.Close();

            }
        }
        this.GridView1.DataBind();
    }
}

