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
    public partial class DashBoardEmp : System.Web.UI.Page
    {
        DataTable dt;
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string DateTom = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
        string DateToday = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
        string drppck;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                gvbinddte();
            }

            //if (Session["Employee_ID"] != null)
            //{
            //    Label1.Text = "Name :" + Session["Employee_Name"].ToString() + "<br/>" + "Address :" + Session["Address"].ToString() + "<br/>" + "Mobile :" + Session["Mobile_Number"].ToString();
            //}
        }

        protected void gvbinddte()
        {
            string EmpId = Session["Employee_ID"].ToString();
            string abdte = DateTime.Now.AddDays(0).ToString("yyyy/MM/dd");
            datepicker.Text = abdte;
            string dtt = Request.Form[datepicker.UniqueID];
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            DataSet ds;
            //SqlCommand cmd = new SqlCommand("SELECT Employee_Request.ID, Employee_Request.Employee_ID,Employee_Request.Employee_Name,Employee_Request.Gender,Employee_Request.Mobile_Number,Employee.Permanent_Address,Employee_Request.Date,Employee_Request.Drop_Pickup, Employee_Request.Time, Employee_Request.PickupTime, Employee_Request.CabNo, Employee_Request.Driver_Info, Employee_Request.Emp_Status FROM Employee INNER JOIN Employee_Request ON Employee.Employee_ID = Employee_Request.Employee_ID where date ='" + dt + "' order by Date desc", con);
            if (string.IsNullOrEmpty(dtt) || dtt == null)
            {
                SqlCommand cmd = new SqlCommand("SELECT* FROM Employee_Request where Employee_ID = '" + EmpId + "'and Emp_date ='" + abdte + "' order by Date desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dt = new DataTable();
                da.Fill(dt);
                da.Fill(ds);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT* FROM Employee_Request where Employee_ID = '" + EmpId + "'and Emp_date ='" + dtt + "' order by Date desc", con);
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

        protected void gvbind()
        {
            string EmpId = Session["Employee_ID"].ToString();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
           // SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and DATE BETWEEN '"+DateToday+ "' and '" + DateTom + "' order by DATE desc", con);
            SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date >='" + DateToday + "'union all select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date ='" + DateTom + "' order by id Desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
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
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstats = (Label)e.Row.FindControl("lblsts");

                if (!string.IsNullOrEmpty(lblstats.Text))
                {
                    if (lblstats.Text == "Allot")
                    {
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
                    }
                }
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            gvbinddte();
            //string EmpId = Session["Employee_ID"].ToString();
            //string dt = Request.Form[txtDate.UniqueID];
            //SqlConnection con = new SqlConnection(strConnString);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID = '" + EmpId + "' and date ='" + dt + "' order by id desc", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //con.Close();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //}
            //else
            //{
            //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //    int columncount = GridView1.Rows[0].Cells.Count;
            //    GridView1.Rows[0].Cells.Clear();
            //    GridView1.Rows[0].Cells.Add(new TableCell());
            //    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            //    GridView1.Rows[0].Cells[0].Text = "No Records Found";
            //}
            //txtDate.Text = dt;
        }


        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(strConnString);
        //    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        //    Label lbldeleteid = (Label)row.FindControl("lblID");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("delete FROM Employee_Request where ID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    gvbind();
        //}
        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    gvbind();
        //}
        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(strConnString);
        //    int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        //    Label lblID = (Label)row.FindControl("lblID");
        //    // string textMobile = (row.FindControl("TextBox1") as TextBox).Text;

        //    string city = (GridView1.Rows[e.RowIndex].FindControl("ddlCities") as DropDownList).SelectedItem.Value;
        //    //TextBox texttime = (TextBox)row.Cells[5].Controls[0];
        //    GridView1.EditIndex = -1;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("update Employee_Request set Time='" + city + "' where ID='" + userid + "'", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    gvbind();
        //}
        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    gvbind();
        //}
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
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