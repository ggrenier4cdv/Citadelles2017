using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default8 : Page, IRequiresSessionState
{
    //protected HtmlForm form1;
    //protected GridView GridView1;
    //protected Label Label1;
    //protected SqlDataSource SqlDataSource1;

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = base.Request.Params["CATEGORIE"];
        Page.Title = base.Request.Params["CATEGORIE"];
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[4].Text == "OR")
            e.Row.Cells[4].BackColor = System.Drawing.Color.Gold;
        else if (e.Row.Cells[4].Text == "ARGENT")
            e.Row.Cells[4].BackColor = System.Drawing.Color.Silver;
        else if (e.Row.Cells[4].Text == "BRONZE")
            e.Row.Cells[4].BackColor = System.Drawing.Color.FromArgb(205, 127, 50);
    }
}

