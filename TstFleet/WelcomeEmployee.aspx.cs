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
    public partial class WelcomeEmployee : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee_Name"] != null || Session["Employee_ID"] != null)
            {
              //  Label1.Text = "Welcome.." + Session["Employee_Name"].ToString() + Session["Employee_ID"].ToString();
                TextBox1.Text = Session["Employee_ID"].ToString();
                TextBox2.Text = Session["Employee_Name"].ToString();
                TextBox4.Text = Session["Address"].ToString();
                TextBox5.Text = Session["Email_Address"].ToString();
                TextBox6.Text = Session["Department"].ToString();
                TextBox8.Text = Session["Bussines_unit"].ToString();
                string tomrrowdate = DateTime.Now.AddDays(1).ToString("MM/dd/yyy");
                TextBox7.Text = tomrrowdate.ToString();
                if (!IsPostBack)
                {
                    gvbind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection(strConnString);         
            SqlCommand com = new SqlCommand("Insert into Employee_Request(Drop_Pickup,Employee_ID,Employee_Name,Mobile_Number,Address,Email_Address,Department,Date,Bussines_unit,Time,Gender) values (@Drop_Pickup,@Employee_ID,@Employee_Name,@Mobile_Number,@Address,@Email_Address,@Department,@Date,@Bussines_unit,@Time,@Gender)", con);
            com.Parameters.AddWithValue("Drop_Pickup", RadioButtonList1.SelectedValue);
            com.Parameters.AddWithValue("Employee_ID", TextBox1.Text);
            com.Parameters.AddWithValue("Employee_Name", TextBox2.Text);
            com.Parameters.AddWithValue("Mobile_Number", TextBox3.Text);
            com.Parameters.AddWithValue("Address", TextBox4.Text);
            com.Parameters.AddWithValue("Email_Address", TextBox5.Text);
            com.Parameters.AddWithValue("Department", TextBox6.Text);
            com.Parameters.AddWithValue("Date", TextBox7.Text);
            com.Parameters.AddWithValue("Bussines_unit", TextBox8.Text);
            com.Parameters.AddWithValue("Time", DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("Gender", DropDownList2.SelectedValue);
            con.Open();
            int k = com.ExecuteNonQuery();
            if (k != 0)
            {
                Response.Write("<script>alert('Record Inserted Succesfully into the Database');</script>");
                // lblmsg.Text = "Record Inserted Succesfully into the Database";
                // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
           // DropDownList1.SelectedValue = "";
          //  RadioButtonList1.SelectedValue = "";
            //TextBox1.Focus();
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
                //Attribute to show the Plus Minus Button.
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
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