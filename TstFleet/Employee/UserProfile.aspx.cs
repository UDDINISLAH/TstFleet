using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TstFleet
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee_ID"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Label2.Text = Session["Employee_ID"].ToString();
            Label1.Text = Session["Employee_Name"].ToString();
            Label3.Text = Session["Mobile_Number"].ToString();
            Label4.Text = Session["Permanent_Address"].ToString();
            Label5.Text = Session["Email_Address"].ToString();
            Label6.Text = Session["Department"].ToString();
            Label7.Text = Session["Bussines_unit"].ToString();
            Label8.Text = Session["Gender"].ToString();
        }
    }
}