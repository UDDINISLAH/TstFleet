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
    public partial class ScheduleCab : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
                // gvbindDriver();
            }
        }

        protected void gvbind()
        {
            // string EmpId = Session["Employee_ID"].ToString();
            //GridView1.Columns[9].Visible = false;
            string DateTom = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
            //string str = "";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Date='" + DateTom + "' And Status='" + str + "' order by Preference", con);
            SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Date='" + DateTom + "' order by Preference", con);            
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
            //  TextBox CabNo = (TextBox)row.Cells[5].Controls[0];
            //TextBox DriverInfo = (TextBox)row.Cells[6].Controls[0];

            string PickupTime = (row.FindControl("TextBox1") as TextBox).Text;


            string CabNo = (GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedItem.Value;
            string DriverInfo = (GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList).SelectedItem.Value;
            string sts = "Assigned";
            //TextBox texttime = (TextBox)row.Cells[5].Controls[0];
            GridView1.EditIndex = -1;
            con.Open();
            SqlCommand cmdd = new SqlCommand("update Employee_Request set PickupTime='" + PickupTime + "',CabNo='" + CabNo + "',Driver_Info='" + DriverInfo + "',Status='" + sts + "' where ID='" + userid + "'", con);
            cmdd.ExecuteNonQuery();
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

        protected void UpdatePreference(object sender, EventArgs e)
        {
            int[] locationIds = (from p in Request.Form["LocationId"].Split(',')
                                 select int.Parse(p)).ToArray();
            int preference = 1;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
                foreach (int locationId in locationIds)
            {
                //this.UpdatePreference(locationId, preference);
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Employee_Request SET Preference = @Preference WHERE ID = @Id"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {                            
                                //string status = (GridView1.Rows[row.RowIndex].FindControl("Assignsts") as DropDownList).SelectedItem.Value;                                
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Id", locationId);
                                cmd.Parameters.AddWithValue("@Preference", preference);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                  
                
                preference += 1;
            }
            
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGender = (Label)e.Row.FindControl("lblEmpsts");

                if (!string.IsNullOrEmpty(lblGender.Text))
                {
                    if (lblGender.Text == "Yes")
                    {
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Orange;
                    }
                }
            }
            SqlConnection con = new SqlConnection(strConnString);
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            { 
                    con.Open();
                    DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);
                    DropDownList DropDownList2 = (e.Row.FindControl("DropDownList2") as DropDownList);

                    SqlCommand cmd = new SqlCommand("select * from Driver_Detail", con);
                    //SqlCommand cmd = new SqlCommand("SELECT Cab_Number, CONCAT(Driver_Name, '--(', Mobile, ')')from Driver_Detail)", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "Cab_Number";
                    DropDownList1.DataValueField = "Cab_Number";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Cab Number", "0"));

                    DropDownList2.DataSource = dt;
                    DropDownList2.DataTextField = "Driver_Info";
                    DropDownList2.DataValueField = "Driver_Info";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem("Driver Info", "0"));

                   // DataRowView dr1 = e.Row.DataItem as DataRowView;
                    //DataRowView dr2 = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                   // DropDownList1.SelectedValue = dr1["Cab_Number"].ToString();
                    //DropDownList2.SelectedValue = dr2["Driver_Info"].ToString();
                
            }

        }       
    }
}