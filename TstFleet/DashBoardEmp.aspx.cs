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
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
                //Attribute to show the Plus Minus Button.
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvbind()
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Employee_Request", con);
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Employee_Request where ID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            gvbind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            TextBox textMobile = (TextBox)row.Cells[2].Controls[0];
            string city = (GridView1.Rows[e.RowIndex].FindControl("ddlCities") as DropDownList).SelectedItem.Value;
            //TextBox texttime = (TextBox)row.Cells[5].Controls[0];
            GridView1.EditIndex = -1;
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee_Request set Mobile_Number='" + textMobile.Text + "',Time='" + city + "' where ID='" + userid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            gvbind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }
    }
}