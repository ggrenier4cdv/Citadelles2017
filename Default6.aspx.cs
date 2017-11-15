using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default6 : Page, IRequiresSessionState
{
    //protected TextBox ARGENT;
    //protected TextBox BRONZE;
    //protected Button Button1;
    //protected HtmlForm form1;
    //protected GridView GridView1;
    //protected GridView GridView2;
    //protected TextBox OR;
    //protected Label pARGENT;
    //protected Label pBRONZE;
    //protected Label pOR;
    //protected SqlDataSource SqlDataSource1;
    //protected SqlDataSource SqlDataSource2;

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Columns[6].Visible = !GridView1.Columns[6].Visible;
        GridView2.Columns[9].Visible = !GridView2.Columns[9].Visible;
        GridView3.Columns[6].Visible = !GridView3.Columns[6].Visible;
        if (GridView1.Columns[6].Visible == true)
            Button2.Text = "Masquer %Degust";
        else
            Button2.Text = "Afficher %Degust";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              //  this.OR.Text = this.OR.Text.Replace(',', '.');
              //  this.ARGENT.Text = this.ARGENT.Text.Replace(',', '.');
              //  this.BRONZE.Text = this.BRONZE.Text.Replace(',', '.');
                connection.Open();
                command.Connection = connection;
             //   command.CommandText = "UPDATE SEUIL SET [OR] ='" + this.OR.Text + "', ARGENT='" + this.ARGENT.Text + "', BRONZE='" + this.BRONZE.Text + "'";
             //   command.ExecuteNonQuery().ToString();
             //       command.CommandText = "SELECT [OR] FROM SEUIL";
             //       this.OR.Text = command.ExecuteScalar().ToString();
             //       command.CommandText = "SELECT ARGENT FROM SEUIL";
             //       this.ARGENT.Text = command.ExecuteScalar().ToString();
             //       command.CommandText = "SELECT BRONZE FROM SEUIL";
             //       this.BRONZE.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL";
                    this.pOR.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL";
                    this.pARGENT.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL";
                    this.pBRONZE.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL";
                    this.pMedailles.Text = command.ExecuteScalar().ToString();

                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL";
                    this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL";
                    this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL";
                    this.nbBRONZE.Text = command.ExecuteScalar().ToString() + " vins";
                 //   this.nbBRONZE.Text = this.nbARGENT.Text;
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL";
                    this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                    this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";
               
                connection.Close();
                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.GridView3.DataBind();
            //    this.OR.Text = this.OR.Text.Replace('.', ',');
            //    this.ARGENT.Text = this.ARGENT.Text.Replace('.', ',');
            //    this.BRONZE.Text = this.BRONZE.Text.Replace('.', ',');
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
           //         command.CommandText = "SELECT [OR] FROM SEUIL";
           //         this.OR.Text = command.ExecuteScalar().ToString();
           //         command.CommandText = "SELECT ARGENT FROM SEUIL";
           //         this.ARGENT.Text = command.ExecuteScalar().ToString();
           //         command.CommandText = "SELECT BRONZE FROM SEUIL";
           //         this.BRONZE.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.pOR.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.pARGENT.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.pBRONZE.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.pMedailles.Text = command.ExecuteScalar().ToString();

                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.nbBRONZE.Text = command.ExecuteScalar().ToString() + " vins";
                 //   this.nbBRONZE.Text = this.nbARGENT.Text;
                    command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                    this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                    command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                    this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";

                    connection.Close();
                }
            }
        }
      //  this.OR.Text = this.OR.Text.Replace('.', ',');
      //  this.ARGENT.Text = this.ARGENT.Text.Replace('.', ',');
      //  this.BRONZE.Text = this.BRONZE.Text.Replace('.', ',');
    }

    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Alternate) || (e.Row.RowState == DataControlRowState.Normal)))
        {
            Button button1 = (Button) e.Row.FindControl("LinkButton1");
            string postBackUrl = button1.PostBackUrl;
            button1.PostBackUrl = postBackUrl + "?" + ((Button) e.Row.FindControl("LinkButton1")).CommandName + "=" + ((Button) e.Row.FindControl("LinkButton1")).CommandArgument;
        }
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.Columns[2].Visible = true;
        GridView2.Columns[3].Visible = true;
        TableSeuil.Visible = !GridView2.Columns[3].Visible;
        Button3.Text = "Masquer Seuils";

    }
    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        GridView2.Columns[2].Visible = false;
        GridView2.Columns[3].Visible = false;
        TableSeuil.Visible = GridView2.Columns[3].Visible;
        Button3.Text = "Afficher Seuils";

        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pOR.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pARGENT.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pMedailles.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";
                connection.Close();
                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.GridView3.DataBind();
            }
        }
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.Columns[2].Visible = false;
        GridView2.Columns[3].Visible = false;
        TableSeuil.Visible = GridView2.Columns[3].Visible;
        Button3.Text = "Afficher Seuils";

        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pOR.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pARGENT.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pMedailles.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";
                connection.Close();
                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.GridView3.DataBind();
            }
        }
    }
   

    protected void Button3_Click(object sender, EventArgs e)
 {
        GridView2.Columns[2].Visible = !GridView2.Columns[2].Visible;
        GridView2.Columns[3].Visible = !GridView2.Columns[3].Visible;
        TableSeuil.Visible = GridView2.Columns[3].Visible;

        if (GridView2.Columns[2].Visible == true)
            Button3.Text = "Masquer Seuils";
        else
            Button3.Text = "Afficher Seuils";
    }
    protected void ButtonSeuil_Click_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                this.SeuilOR.Text = this.SeuilOR.Text.Replace(',', '.');
                this.SeuilARGENT.Text = this.SeuilARGENT.Text.Replace(',', '.');
 
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE SEUIL_BY_CATEG SET [OR] ='" + this.SeuilOR.Text + "', ARGENT='" + this.SeuilARGENT.Text + "', BRONZE='" + this.SeuilARGENT.Text + "'";
                   command.ExecuteNonQuery().ToString();


                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.pOR.Text = command.ExecuteScalar().ToString();
                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.pARGENT.Text = command.ExecuteScalar().ToString();

                   command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.pMedailles.Text = command.ExecuteScalar().ToString();

                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";

                   command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                   this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                   command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                   this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";
                   connection.Close();

                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.GridView3.DataBind();

                this.SeuilOR.Text = this.SeuilOR.Text.Replace('.', ',');
                this.SeuilARGENT.Text = this.SeuilARGENT.Text.Replace('.', ',');
            }
        }
    }
    protected void ButtonPourcent_Click_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                this.SeuilOR.Text = this.SeuilOR.Text.Replace(',', '.');
                this.SeuilARGENT.Text = this.SeuilARGENT.Text.Replace(',', '.');

                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE SEUIL_BY_CATEG SET [OR] ='" + this.SeuilOR.Text + "', ARGENT='" + this.SeuilARGENT.Text + "', BRONZE='" + this.SeuilARGENT.Text + "'";
                command.CommandText = "MERGE INTO SEUIL_BY_CATEG USING (select TMP1.CATEGORIE, min(TMP2.note) SEUIL_OR, min(TMP1.note) SEUIL_AR FROM (select CATEGORIE, note, RANK() OVER (PARTITION BY CATEGORIE ORDER BY note desc)*100.00 / COUNT(*) OVER (PARTITION BY CATEGORIE) POURCENT from PRECALCUL) TMP1, (select CATEGORIE, note, RANK() OVER (PARTITION BY CATEGORIE ORDER BY note desc)*100.00 / COUNT(*) OVER (PARTITION BY CATEGORIE) POURCENT from PRECALCUL) TMP2 WHERE TMP1.POURCENT < " + this.PourcentArgent.Text + " AND TMP1.CATEGORIE = TMP2.CATEGORIE AND TMP2.POURCENT < " + this.PourcentOr.Text + " GROUP BY TMP1.CATEGORIE) TO_UPDATE ON (SEUIL_BY_CATEG.CATEGORIE = TO_UPDATE.CATEGORIE) WHEN MATCHED THEN UPDATE SET SEUIL_BY_CATEG.[OR] = TO_UPDATE.SEUIL_OR, SEUIL_BY_CATEG.ARGENT = TO_UPDATE.SEUIL_AR, SEUIL_BY_CATEG.BRONZE = TO_UPDATE.SEUIL_AR;";
                command.ExecuteNonQuery().ToString();
                


                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pOR.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pARGENT.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '%' FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.pMedailles.Text = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbOR.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= ARGENT AND NOTE < [OR] THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbARGENT.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE AND NOTE < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";

                command.CommandText = "SELECT CAST(SUM(CASE WHEN NOTE >= BRONZE THEN 1 ELSE 0 END) AS VARCHAR(255)) FROM PRECALCUL, SEUIL_BY_CATEG WHERE PRECALCUL.CATEGORIE = SEUIL_BY_CATEG.CATEGORIE";
                this.nbMedailles.Text = command.ExecuteScalar().ToString() + " vins";
                command.CommandText = "SELECT CAST(SUM(1) AS VARCHAR(255)) FROM PRECALCUL";
                this.nbTOTAL.Text = command.ExecuteScalar().ToString() + " vins";
                connection.Close();

                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.GridView3.DataBind();

                this.SeuilOR.Text = this.SeuilOR.Text.Replace('.', ',');
                this.SeuilARGENT.Text = this.SeuilARGENT.Text.Replace('.', ',');
            }
        }
    }
}

