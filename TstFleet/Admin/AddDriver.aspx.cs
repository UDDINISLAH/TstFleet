using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TstFleet
{
    public partial class AddDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            //    Sessiontxt.Text = "Welcome" + Session["Driver_name"].ToString();
            //}
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                gvbind();
            }
        }
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand com;
        protected void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Insert into Driver_detail values(@DriverName,@Mobile,@Email,@Address,@cab_model,@Cab_number,@Driver_Info)";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@DriverName", txt_DriverName.Text);
            com.Parameters.AddWithValue("@Mobile", txt_Mobile.Text);
            com.Parameters.AddWithValue("@Email", Email.Text);
            com.Parameters.AddWithValue("@Address", Address.Text);
            com.Parameters.AddWithValue("@cab_model", Cab_model.Text);
            com.Parameters.AddWithValue("@Cab_number", cab_number.Text);
            string DrivernameMobile = txt_DriverName.Text + " " + txt_Mobile.Text;

            com.Parameters.AddWithValue("@Driver_Info", DrivernameMobile);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Successfully Registered!!!";
            clear();
            gvbind();
        }
        private void clear()
        {
            txt_DriverName.Text = "";
            txt_Mobile.Text = "";
            Email.Text = "";
            Address.Text = "";
            Cab_model.Text = "";
            cab_number.Text = "";
        }

        protected void gvbind()
        {
            SqlConnection conn = new SqlConnection(strConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Driver_Detail", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
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
            SqlConnection conn = new SqlConnection(strConnString);
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Driver_Detail where id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConnString);
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox textName = (TextBox)row.Cells[0].Controls[0];
            TextBox Mobile = (TextBox)row.Cells[1].Controls[0];
            TextBox Email = (TextBox)row.Cells[2].Controls[0];
            TextBox Driver_Address = (TextBox)row.Cells[3].Controls[0];
            TextBox Cab_model = (TextBox)row.Cells[4].Controls[0];
            TextBox Cab_Number = (TextBox)row.Cells[5].Controls[0];
            //TextBox textadd = (TextBox)row.FindControl("txtadd");  
            //TextBox textc = (TextBox)row.FindControl("txtc");  
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            SqlCommand cmd = new SqlCommand("update Driver_Detail set Driver_Name='" + textName.Text + "',Mobile='" + Mobile.Text + "',Driver_Address='" + Driver_Address.Text + "',Cab_model='" + Cab_model.Text + "',Cab_Number='" + Cab_Number.Text + "' where id='" + userid + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
            //GridView1.DataBind();  
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
