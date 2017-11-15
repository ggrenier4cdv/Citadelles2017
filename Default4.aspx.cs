using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default4 : Page, IRequiresSessionState
{
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G_S1.Visible = false;
        this.G_S2.Visible = false;
        this.G_S3.Visible = false;
        this.G_D1.Visible = false;
        this.G_D2.Visible = false;
        this.G_D3.Visible = false;
        this.G_L1.Visible = false;
        this.G_L2.Visible = false;
        this.G_L3.Visible = false;
        switch (this.DropDownList1.SelectedValue)
        {
            case "ALL":
                this.G_S1.Visible = true;
                this.G_S2.Visible = true;
                this.G_S3.Visible = true;
                this.G_D1.Visible = true;
                this.G_D2.Visible = true;
                this.G_D3.Visible = true;
                this.G_L1.Visible = true;
                this.G_L2.Visible = true;
                this.G_L3.Visible = true;
                return;

            case "J1":
                this.G_S1.Visible = true;
                this.G_S2.Visible = true;
                this.G_S3.Visible = true;
                return;

            case "J2":
                this.G_D1.Visible = true;
                this.G_D2.Visible = true;
                this.G_D3.Visible = true;
                return;

            case "J3":
                this.G_L1.Visible = true;
                this.G_L2.Visible = true;
                this.G_L3.Visible = true;
                return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

