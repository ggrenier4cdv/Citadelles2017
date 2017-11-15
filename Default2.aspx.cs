using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default2 : Page, IRequiresSessionState
{
 //   protected Button Button1;
 //   protected FileUpload FileUpload1;
 //   protected HtmlForm form1;

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
         
            string fileName = FileUpload1.PostedFile.FileName;
            string TempfileLocation = Server.MapPath("~/");
            string FullPath = System.IO.Path.Combine(TempfileLocation, fileName);
            FileUpload1.SaveAs(FullPath);

            string bulkinsert = "BULK INSERT FILE_IMPORT FROM '" + FullPath + "' WITH (FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FullPath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            //string connectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + this.FileUpload1.PostedFile.FileName + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";
            string str2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand("DELETE FROM LISTE_VINS"))
            {
                using (SqlConnection connection = new SqlConnection(str2))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
            using (SqlCommand command = new SqlCommand("DELETE FROM FILE_IMPORT"))
            {
                using (SqlConnection connection = new SqlConnection(str2))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
            using (SqlCommand command = new SqlCommand(bulkinsert))
            {
                using (SqlConnection connection = new SqlConnection(str2))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }

            string listevins = "INSERT INTO [LISTE_VINS] SELECT [NO_ORDRE] ,[JURY]%100 ,[SERIE] , NULL , NULL ,[LBL_CATEGORIE] ,[LBL_PAYS] , NULL ,[CODE_APPELLATION] ,[LBL_APPELLATION] ,[MILLESIME] ,[NOM] , NULL  , NULL ,[CRU] ,[CODE]  , NULL  ,[VOLUME] ,[LBL_CEPAGE] ,([JURY] - [JURY]%100) /100, case WHEN [FIJEV] like '%X%' THEN 'X' else null END, case WHEN [HN_MALBEC] like '%X%' THEN 'X' else null END, case WHEN [HS_MALBEC] like '%X%' THEN 'X' else null END, case WHEN [HN_CAB_SAUV] like '%X%' THEN 'X' else null END, case WHEN [HS_CAB_SAUV] like '%X%' THEN 'X' else null END, case WHEN [SOMMELIER] like '%X%' THEN 'X' else null END,  case WHEN [VINOFED] like '%X%' THEN 'X' else null END, case WHEN [DUAD] like '%X%' THEN 'X' else null END FROM [FILE_IMPORT]";
            using (SqlCommand command = new SqlCommand(listevins))
            {
                using (SqlConnection connection = new SqlConnection(str2))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }

            this.Button1.Text = "'" + fileName + "' importé";
            this.Button1.Enabled = false;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
            string listevins = "DELETE FROM SAISIE_SERIE";
            string str2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 
        using (SqlCommand command = new SqlCommand(listevins))
            {
                using (SqlConnection connection = new SqlConnection(str2))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

 
}

