using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TstFleet
{
    public partial class DashBoardAdmin : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        string dte,dtxt;
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string a = DateTime.Now.ToString("dd/MM/yyyy");
                datepicker.Text = a.Replace('-', '/');
                //string a = DateTime.Now.ToString("dd-MM-yyyy");
                //datepicker.Text = a.Replace('-', '/');
                // datepicker.Text = DateTime.Now.AddDays(-1).ToString("MM-dd-yyyy");
                gvbind();
            }
            else
            {
                dte = datepicker.Text;//26/09/2021
                var fooArray = dte.Split('-');
                string aa = fooArray[2] + '/' + fooArray[1] + '/' + fooArray[0];
                datepicker.Text = aa;
                gvbind();
            }
        }

        protected void gvbind()
        {
            // string EmpId = Session["Employee_ID"].ToString();
            //GridView1.Columns[9].Visible = false;
            //string DateTom = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
            //string str = "";
          //  dtxt = datepicker.Text;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Date='" + DateTom + "' And Status='" + str + "' order by Preference", con);
            // SqlCommand cmd = new SqlCommand("Select * from Employee_Request ORDER BY Date DESC", con);
            string dastr;
            dastr = "select * from Employee_Request where date='" + datepicker.Text + "' ORDER BY CONVERT(DATETIME,date,103) asc";
            da = new SqlDataAdapter(dastr, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
           // datepicker.Text = dtxt;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
    }
}