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
        string dte,dtxt,aa;
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string DateTom = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        string DateToday = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
        string drppck;
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                //gvbind();
                gvbinddte();
            }
        }

        protected void gvbind()
        {
            string dtt = Request.Form[datepicker.UniqueID];
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            string dastr;
            //dastr = "select * from Employee_Request where Date between  '" + DateToday + "' and '" + DateTom + "' order by Date desc";
            //   dastr = "Select* from Employee_Request where Date >='" + DateToday + "'union all select* from Employee_Request where Date ='" + DateTom + "' order by id Desc";
            dastr = "select * from Employee_Request where Emp_date = '" + DateToday + "' or Emp_date='" + DateTom + "'  order by Emp_date desc";
            da = new SqlDataAdapter(dastr, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            datepicker.Text = dtxt;
           // ViewState["Data"] = dt;
        }

        protected void gvbinddte()
        {
            string abdte = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
            datepicker.Text = abdte;
            string dtt = Request.Form[datepicker.UniqueID];
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            DataSet ds;
            //SqlCommand cmd = new SqlCommand("SELECT Employee_Request.ID, Employee_Request.Employee_ID,Employee_Request.Employee_Name,Employee_Request.Gender,Employee_Request.Mobile_Number,Employee.Permanent_Address,Employee_Request.Date,Employee_Request.Drop_Pickup, Employee_Request.Time, Employee_Request.PickupTime, Employee_Request.CabNo, Employee_Request.Driver_Info, Employee_Request.Emp_Status FROM Employee INNER JOIN Employee_Request ON Employee.Employee_ID = Employee_Request.Employee_ID where date ='" + dt + "' order by Date desc", con);
            if (string.IsNullOrEmpty(dtt) || dtt ==null)
            {
                SqlCommand cmd = new SqlCommand("SELECT* FROM Employee_Request where Emp_date ='" + abdte + "' order by Date desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(dt);
                da.Fill(ds);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT* FROM Employee_Request where Emp_date ='" + dtt + "' order by Date desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(dt);
                da.Fill(ds);
            }          
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
            datepicker.Text = dtt;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            gvbinddte();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbinddte();
        }

        protected void Country_Changed(object sender, EventArgs e)
        {
            gvbinddte();
            drppck = ddlCountry.SelectedItem.Value;
            DataView dataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(drppck))
            {
                dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
            }
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }
}