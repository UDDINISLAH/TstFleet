using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TstFleet
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string EmpId = Session["Employee_ID"].ToString();
            //if (EmpId==null)
            //{
            //    Response.Redirect("../Login.aspx");
            //}
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../Login.aspx");
        }
    }
}