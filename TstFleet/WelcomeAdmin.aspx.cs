using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TstFleet
{
    public partial class WelcomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee_Name"] != null || Session["Employee_ID"]!=null)
            {
                Label1.Text = "Welcome" + Session["Employee_Name"].ToString()+Session["Employee_Name"].ToString();
            }
        }
    }
}