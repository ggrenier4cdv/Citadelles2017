using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default3 : Page, IRequiresSessionState
{
    //protected Button Button1;
    //protected FileUpload FileUpload1;
    //protected HtmlForm form1;
    //protected Label Label1;
    //protected Label Label2;
    //protected Label Label3;

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            this.FileUpload1.SaveAs(this.FileUpload1.PostedFile.FileName);
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand("DELETE FROM SAISIE_SERIE_TMP BULK INSERT SAISIE_SERIE_TMP FROM '" + this.FileUpload1.PostedFile.FileName + @"' WITH (FIRSTROW = 1, MAXERRORS = 0, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n') INSERT INTO SAISIE_SERIE SELECT DISTINCT * FROM SAISIE_SERIE_TMP WHERE NOT EXISTS (SELECT 1 FROM SAISIE_SERIE WHERE SAISIE_SERIE_TMP.JURE = SAISIE_SERIE.JURE AND SAISIE_SERIE_TMP.NUMERO = SAISIE_SERIE.NUMERO) UPDATE SAISIE_SERIE SET JURY = JURY - ROUND(JURY,-2) WHERE JURY > 100"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery().ToString();
                    connection.Close();
                }
            }
            using (SqlCommand command2 = new SqlCommand("SELECT Count(1) FROM SAISIE_SERIE"))
            {
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();
                    command2.Connection = connection2;
                    int num = int.Parse(this.Label1.Text);
                    this.Label1.Text = command2.ExecuteScalar().ToString();
                    this.Label2.Visible = true;
                    this.Label3.Text = (int.Parse(this.Label1.Text) - num).ToString();
                    connection2.Close();
                }
            }
            using (SqlCommand command2 = new SqlCommand("SELECT Count(DISTINCT NUMERO) FROM SAISIE_SERIE WHERE NUMERO >= 7000"))
            {
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();
                    command2.Connection = connection2;
                    int num = int.Parse(this.Label4.Text);
                    this.Label4.Text = command2.ExecuteScalar().ToString();
                    this.Label5.Visible = true;
                    this.Label6.Text = (int.Parse(this.Label4.Text) - num).ToString();
                    connection2.Close();
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand("SELECT Count(1) FROM SAISIE_SERIE"))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                this.Label1.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }
        using (SqlCommand command = new SqlCommand("SELECT Count(DISTINCT NUMERO) FROM SAISIE_SERIE WHERE NUMERO >= 7000"))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                this.Label4.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }
    }

}

