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
    public partial class CabStatus : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string DateTom = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        string DateToday = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {                
                    Response.Redirect("../Login.aspx");
                }
                TxtBoxbind();
                StsDrpbind();
                StsPckbind();
            }

            //if (Session["Employee_ID"] != null)
            //{
            //    Label1.Text = "Name :" + Session["Employee_Name"].ToString() + "<br/>" + "Address :" + Session["Address"].ToString() + "<br/>" + "Mobile :" + Session["Mobile_Number"].ToString();
            //}
        }

        //protected void gvbind()
        //{
        //    string DateTom = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        //    string DateToday = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
        //    string EmpId = Session["Employee_ID"].ToString();
        //    SqlConnection con = new SqlConnection(strConnString);
        //    con.Open();
        //    //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and Date = '" + DateTom + "'", con);
        //    SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date between '" + DateToday + "' and '" + DateTom + "'", con); 
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    con.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();

        //    }
        //    else
        //    {
        //        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();
        //        int columncount = GridView1.Rows[0].Cells.Count;
        //        GridView1.Rows[0].Cells.Clear();
        //        GridView1.Rows[0].Cells.Add(new TableCell());
        //        GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
        //        GridView1.Rows[0].Cells[0].Text = "No Records Found";
        //    }
        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblGender = (Label)e.Row.FindControl("lblsts");

        //        if (!string.IsNullOrEmpty(lblGender.Text))
        //        {
        //            if (lblGender.Text == "Allot")
        //            {
        //                e.Row.Cells[4].ForeColor = System.Drawing.Color.Black;
        //                e.Row.Cells[4].BackColor = System.Drawing.Color.Green;
        //            }
        //            else
        //            {
        //                e.Row.Cells[4].ForeColor = System.Drawing.Color.Black;
        //                e.Row.Cells[4].BackColor = System.Drawing.Color.Orange;
        //            }
        //        }
        //    }
        //}

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

        //    string EmpSts = (GridView1.Rows[e.RowIndex].FindControl("ddlCities") as DropDownList).SelectedItem.Value;
        //    //TextBox texttime = (TextBox)row.Cells[5].Controls[0];
        //    GridView1.EditIndex = -1;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("update Employee_Request set Emp_Status='" + EmpSts + "' where ID='" + userid + "'", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    gvbind();
        //}
        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    gvbind();
        //}
        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    gvbind();
        //}
        
        protected void StsPckbind()
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and Date = '" + DateTom + "'", con);
            SqlCommand cmd = new SqlCommand("Select* from Employee_Request where CabNo='" + lbl1.Text + "' and Emp_date ='" + DateTom + "' and Drop_pickup='Pick'", con);
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

        protected void StsDrpbind()
        {
            //String EmpId = Session["Employee_ID"].ToString();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and Date = '" + DateTom + "'", con);
            //SqlCommand cmd1 = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date = '" + DateToday + "' and Drop_Pickup='Pick'", con);
            //SqlDataReader DR1 = cmd1.ExecuteReader();
            //if (DR1.Read())
            //{              
            //    TextBox2.Text = DR1["cabno"].ToString();
            //}
            SqlCommand cmd = new SqlCommand("Select* from Employee_Request where CabNo='" + lbl3.Text + "' and  Emp_date ='" + DateToday + "' and Drop_pickup='Drop'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView2.DataSource = ds;
                GridView2.DataBind();
                int columncount = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView2.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        
        protected void TxtBoxbind()
        {
            string EmpId = Session["Employee_ID"].ToString();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and Date = '" + DateTom + "'", con);
            //SqlCommand cmd1 = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date = '" + DateTom + "' and Drop_Pickup='Pick'", con);
            SqlCommand cmd1 = new SqlCommand("select * from Employee_Request where Employee_ID = '" + EmpId + "' and  Emp_date = cast(getdate() as Date) and Drop_Pickup='Pick'", con);
            SqlDataReader DR1 = cmd1.ExecuteReader();
            if (DR1.Read())
            {
                if (TextBox4.Text!=null)
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }
                Panel1.Visible = true;
                TextBox1.Text = DR1["Time"].ToString();             
                TextBox2.Text = DR1["PickupTime"].ToString();
                TextBox3.Text = DR1["Status"].ToString();
                TextBox4.Text = DR1["Emp_Status"].ToString();
                lbl1.Text = DR1["cabno"].ToString();
                lbl2.Text = DR1["Driver_info"].ToString();
                string dt1 = DR1["Emp_Date"].ToString();
                DateTime theDate = DateTime.Parse(dt1);
                Label1.Text = theDate.ToLongDateString();

                if (TextBox3.Text == "Allot")
                {
                    Button1.Visible = true;
                    Button2.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }             
            }
            con.Close();
            con.Open();
            //SqlCommand cmd2 = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date between '" + DateToday + "' and '" + DateTom + "' and Drop_Pickup='Drop'", con);
            SqlCommand cmd2 = new SqlCommand("select * from Employee_Request where Employee_ID = '" + EmpId + "' and  Emp_date = cast(getdate() as Date) and Drop_Pickup='Drop'", con);
            SqlDataReader DR2 = cmd2.ExecuteReader();
            if (DR2.Read())
            {
                if (TextBox8.Text != null)
                {
                    Button3.Visible = false;
                    Button4.Visible = false;
                }
                Panel2.Visible = true;
                TextBox5.Text = DR2["Time"].ToString();
                TextBox6.Text = DR2["PickupTime"].ToString();
                TextBox7.Text = DR2["Status"].ToString();
                TextBox8.Text = DR2["Emp_Status"].ToString();
                lbl3.Text = DR2["CabNo"].ToString();
                lbl4.Text = DR2["Driver_info"].ToString();
                // lbl5.Text = DR2["Drop_Pickup"].ToString();
                string dt2 = DR2["Emp_Date"].ToString();
                DateTime theDate = DateTime.Parse(dt2);
                Label2.Text = theDate.ToLongDateString();

                if (TextBox7.Text == "Allot")
                {
                    Button3.Visible = true;
                    Button4.Visible = true;
                }
                else
                {
                    Button3.Visible = false;
                    Button4.Visible = false;
                }
            }
            con.Close();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string EmpId = Session["Employee_ID"].ToString();
            // string DrPkp = Session["Drop_Pickup"].ToString();
            string EmpSts = "Yes";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand com = new SqlCommand("update Employee_Request set Emp_Status = '" + EmpSts + "' where Employee_ID = '" + EmpId + "'AND Drop_Pickup='Pick' AND Emp_date = '" + DateTom + "' ", con);
            int kk = com.ExecuteNonQuery();
            if (kk != 0)
            {
                // Response.Write("<script>alert('Employee Registered Succesfully');</script>");
               // TextBox4.Text = System.Drawing.Color.Green; 
              
            }
            con.Close();
            TxtBoxbind();
            StsDrpbind();
            StsPckbind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string EmpId = Session["Employee_ID"].ToString();
            string EmpSts = "No";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand com = new SqlCommand("update Employee_Request set Emp_Status = '" + EmpSts + "' where Employee_ID = '" + EmpId + "'AND Drop_Pickup='Pick' AND Emp_date = '" + DateTom + "'", con);
            int kk = com.ExecuteNonQuery();
            if (kk != 0)
            {
                // Response.Write("<script>alert('Employee Registered Succesfully');</script>");
                // lblmsg.Text = "Record Inserted Succesfully into the Database";
                // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
            TxtBoxbind();
            StsDrpbind();
            StsPckbind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string EmpId = Session["Employee_ID"].ToString();
            // string DrPkp = Session["Drop_Pickup"].ToString();
            string EmpSts = "Yes";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand com = new SqlCommand("update Employee_Request set Emp_Status = '" + EmpSts + "' where Employee_ID = '" + EmpId + "' AND Drop_Pickup='Drop' AND Emp_date = '" + DateToday + "'", con);
            int kk = com.ExecuteNonQuery();
            if (kk != 0)
            {
                // Response.Write("<script>alert('Employee Registered Succesfully');</script>");
                // lblmsg.Text = "Record Inserted Succesfully into the Database";
                // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
            TxtBoxbind();
            StsDrpbind();
            StsPckbind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string EmpId = Session["Employee_ID"].ToString();
            string EmpSts = "No";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand com = new SqlCommand("update Employee_Request set Emp_Status = '" + EmpSts + "' where Employee_ID = '" + EmpId + "' AND Drop_Pickup='Drop' AND Emp_date = '" + DateToday + "'", con);
            int kk = com.ExecuteNonQuery();
            if (kk != 0)
            {
                // Response.Write("<script>alert('Employee Registered Succesfully');</script>");
                // lblmsg.Text = "Record Inserted Succesfully into the Database";
                // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
            TxtBoxbind();
            StsDrpbind();
            StsPckbind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           // string DateToday = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
           // string EmpId = Session["Employee_ID"].ToString();
           //// string dt = Request.Form[txtDate.UniqueID];
           // SqlConnection con = new SqlConnection(strConnString);
           // con.Open();
           // SqlCommand cmd1 = new SqlCommand("Select * from Employee_Request where Employee_ID = '" + EmpId + "' and Date = '" + dt + "' and Drop_Pickup='Pick'", con);
           // SqlDataReader DR1 = cmd1.ExecuteReader();
           // if (DR1.Read())
           // {
           //     Button1.Visible = false;
           //     Button2.Visible = false;               
           //     Panel1.Visible = true;
           //     TextBox1.Text = DR1["Time"].ToString();
           //     TextBox2.Text = DR1["PickupTime"].ToString();
           //     TextBox3.Text = DR1["Status"].ToString();
           //     TextBox4.Text = DR1["Emp_Status"].ToString();
           //     lbl1.Text = DR1["cabno"].ToString();
           //     lbl2.Text = DR1["Driver_info"].ToString();
           //     Label1.Text = " MM-DD-YYYY  " + DR1["Date"].ToString();
           // }            
           // con.Close();
           // con.Open();
           // //SqlCommand cmd2 = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date between '" + DateToday + "' and '" + DateTom + "' and Drop_Pickup='Drop'", con);
           // SqlCommand cmd2 = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date = '" + dt + "' and Drop_Pickup='Drop'", con);
           // SqlDataReader DR2 = cmd2.ExecuteReader();
           // if (DR2.Read())
           // {               
           //     Button3.Visible = false;
           //     Button4.Visible = false;              
           //     Panel2.Visible = true;
           //     TextBox5.Text = DR2["Time"].ToString();
           //     TextBox6.Text = DR2["PickupTime"].ToString();
           //     TextBox7.Text = DR2["Status"].ToString();
           //     TextBox8.Text = DR2["Emp_Status"].ToString();
           //     lbl3.Text = DR2["CabNo"].ToString();
           //     lbl4.Text = DR2["Driver_info"].ToString();
           //     Label2.Text = " MM-DD-YYYY  " + DR2["Date"].ToString();                               
           // }
           // con.Close();
            //txtDate.Text = dt;
        }
    }
}