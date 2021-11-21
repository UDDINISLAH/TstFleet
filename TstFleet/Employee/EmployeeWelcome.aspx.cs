using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;


namespace TstFleet
{
    public partial class EmployeeWelcome : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string Gndr, tomrrowdate, todaydate, name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                if (Session["Employee_Name"] != null || Session["Employee_ID"] != null)
                {
                    //  Label1.Text = "Welcome.." + Session["Employee_Name"].ToString() + Session["Employee_ID"].ToString();
                    TextBox1.Text = Session["Employee_ID"].ToString();
                    TextBox2.Text = Session["Employee_Name"].ToString();
                    TextBox3.Text = Session["Mobile_Number"].ToString();
                    TextBox4.Text = Session["Permanent_Address"].ToString();
                    TextBox5.Text = Session["Email_Address"].ToString();
                    TextBox6.Text = Session["Department"].ToString();
                    TextBox8.Text = Session["Bussines_unit"].ToString();
                    Gndr = Session["Gender"].ToString();
                    gvbind();
                }
            }
            else
            {
                gvbind();
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dttt = Request.Form[datepicker.UniqueID];
            Gndr = Session["Gender"].ToString();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            //TimeSpan start = TimeSpan.Parse("22:00:00"); // 10 PM
            //TimeSpan end = TimeSpan.Parse("13:00:00");   // 2 AM           

            //TimeSpan now = DateTime.Now.TimeOfDay;

            //if ((now > start) && (now < end))
            //{
            //    //match found
            //}



            if (DropDownList2.SelectedValue == "Drop")
            {
               // todaydate = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
               // TextBox7.Text = todaydate.ToString();
                using (var sqlCommand = new SqlCommand("SELECT * FROM Employee_Request WHERE ([Emp_Date] = '" + datepicker.Text + "') and Employee_ID ='" + TextBox1.Text + "'and Drop_Pickup ='" + DropDownList2.SelectedValue + "'", con))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Response.Write("<script>alert('User Can Make Only One Drop Requiste In  Day');</script>");
                        reader.Dispose();
                    }
                    else
                    {
                        reader.Dispose();
                        string status = "--";
                        SqlCommand com = new SqlCommand("Insert into Employee_Request(Drop_Pickup,Employee_ID,Employee_Name,Mobile_Number,Address,Email_Address,Department,Emp_Date,Bussines_unit,Time,Gender,Status) values (@Drop_Pickup,@Employee_ID,@Employee_Name,@Mobile_Number,@Address,@Email_Address,@Department,@Emp_Date,@Bussines_unit,@Time,@Gender,@Status)", con);
                        com.Parameters.AddWithValue("Drop_Pickup", DropDownList2.SelectedValue);
                        com.Parameters.AddWithValue("Employee_ID", TextBox1.Text);
                        com.Parameters.AddWithValue("Employee_Name", TextBox2.Text);
                        com.Parameters.AddWithValue("Mobile_Number", TextBox3.Text);
                        com.Parameters.AddWithValue("Address", TextBox4.Text);
                        com.Parameters.AddWithValue("Email_Address", TextBox5.Text);
                        com.Parameters.AddWithValue("Department", TextBox6.Text);
                        com.Parameters.AddWithValue("Emp_Date", datepicker.Text);
                        com.Parameters.AddWithValue("Bussines_unit", TextBox8.Text);
                        com.Parameters.AddWithValue("Time", DropDownList1.SelectedValue);
                        com.Parameters.AddWithValue("Gender", Gndr);
                        com.Parameters.AddWithValue("Status", status);
                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
                            Send_email();
                            //Response.Write("<script>alert('Cab Drop Requisted Succesfully');</script>");

                            // lblmsg.Text = "Record Inserted Succesfully into the Database";
                            // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        }
                        con.Close();
                    }
                    gvbind();
                }
            }
            if (DropDownList2.SelectedValue == "Pick")
            {
                //tomrrowdate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
                //TextBox7.Text = tomrrowdate.ToString();
                using (var sqlCommand = new SqlCommand("SELECT * FROM Employee_Request WHERE ([Emp_Date] = '" + datepicker.Text + "') and Employee_ID ='" + TextBox1.Text + "'and Drop_Pickup ='" + DropDownList2.SelectedValue + "'", con))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Response.Write("<script>alert('User Can Make Only One Pickup Requiste In A Day');</script>");
                        reader.Dispose();
                    }
                    else
                    {
                        reader.Dispose();
                        string status = "--";
                        SqlCommand com = new SqlCommand("Insert into Employee_Request(Drop_Pickup,Employee_ID,Employee_Name,Mobile_Number,Address,Email_Address,Department,Emp_Date,Bussines_unit,Time,Gender,Status) values (@Drop_Pickup,@Employee_ID,@Employee_Name,@Mobile_Number,@Address,@Email_Address,@Department,@Emp_Date,@Bussines_unit,@Time,@Gender,@Status)", con);
                        com.Parameters.AddWithValue("Drop_Pickup", DropDownList2.SelectedValue);
                        com.Parameters.AddWithValue("Employee_ID", TextBox1.Text);
                        com.Parameters.AddWithValue("Employee_Name", TextBox2.Text);
                        com.Parameters.AddWithValue("Mobile_Number", TextBox3.Text);
                        com.Parameters.AddWithValue("Address", TextBox4.Text);
                        com.Parameters.AddWithValue("Email_Address", TextBox5.Text);
                        com.Parameters.AddWithValue("Department", TextBox6.Text);
                        com.Parameters.AddWithValue("Emp_Date", datepicker.Text);
                        com.Parameters.AddWithValue("Bussines_unit", TextBox8.Text);
                        com.Parameters.AddWithValue("Time", DropDownList1.SelectedValue);
                        com.Parameters.AddWithValue("Gender", Gndr);
                        com.Parameters.AddWithValue("Status", status);
                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
                            Send_email();
                            //Response.Write("<script>alert('Cab Pickup Requisted Succesfully');</script>");

                            // lblmsg.Text = "Record Inserted Succesfully into the Database";
                            // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        }
                        con.Close();
                    }
                    gvbind();
                }
            }
        }

        private void Send_email()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("select * from Employee_Request ", con);
            cmd.Parameters.AddWithValue("@Employee_ID", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Date", datepicker.Text);

            string matter1 = @"<br> Dear Admin,<br><br>We would like to inform you that,Mr: " + Session["Employee_Name"].ToString() + "  has been added a requeste for a cab , details are below.<br>Request ID :-  <b style='color:blue'> </b> <br> ";
            string items = "<table style='transform: scale(0.863344, 0.863344);transform-origin: left top;border: solid 1px black;width:800px;font-size:12.3px;font-weight:620;'><tr><td  style='border: solid 1px black'>Employee_ID</td><td  style='border: solid 1px black'>Employee_Name</td><td  style='border: solid 1px black'>Department</td><td  style='border: solid 1px black'>Address</td><td  style='border: solid 1px black'>PickUp/Drop</td><td  style='border: solid 1px black'>Reporting Date</td><td  style='border: solid 1px black'>Time</td></tr>";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            int RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {

                string Emp_ID = dt.Rows[i]["Employee_ID"].ToString();
                string drop = dt.Rows[i]["Drop_Pickup"].ToString();
                string time = dt.Rows[i]["Time"].ToString();
                //string EMP_ID = dt.Rows[i]["Employee_ID"].ToString();
                string reporting_date = dt.Rows[i]["Date"].ToString();
                if (Emp_ID == TextBox1.Text && reporting_date == datepicker.Text)
                {
                    items = items + "<tr><td style='border: solid 1px black'>" + Session["Employee_ID"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Employee_Name"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Department"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Permanent_Address"].ToString() + "</td><td style='border: solid 1px black'>" + drop + "</td><td style='border: solid 1px black'>" + reporting_date + "</td><td style='border: solid 1px black'>" + time + "</td></tr>";

                    items = items + "</table>";

                    string matter2 = "<br><br>Please let us know if you have any questions.<br><br>Thank you ! <br/></br> | " + HttpContext.Current.Session["Employee_Name"].ToString() + "";
                    string mailBody = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"><HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"></HEAD><BODY><table cellspacing='2' cellpadding='2' width='95%' border='0' align='left'>" + matter1 + items + matter2 + "</table></BODY></HTML>";

                    try
                    {
                        string mee = HttpContext.Current.Session["Employee_Name"].ToString();
                        MailMessage msg = new MailMessage();
                        if (TextBox5.Text != null)
                        {
                            msg.To.Add(new MailAddress(Session["Email_Address"].ToString()));
                            msg.To.Add(new MailAddress("islah.uddin@republicworld.com"));
                            // msg.To.Add(new MailAddress("lochan.kanak@republicworld.com"));

                            msg.From = new MailAddress("israil.ahmad@republicworld.com");
                        }
                        msg.Subject = "Cab Request ";
                        msg.Body = mailBody;
                        msg.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient();
                        client.Port = 25;
                        client.Host = "172.16.2.85";
                        client.EnableSsl = false;
                        client.Send(msg);
                        client.Dispose();

                    }

                    catch (Exception e)
                    {
                        //Response.Write(e);
                    }
                }
            }
        }

        protected void gvbind()
        {
            string DateTom = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            string DateToday = DateTime.Now.AddDays(0).ToString("dd/MM/yyyy");
            string EmpId = Session["Employee_ID"].ToString();
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Employee_ID='" + EmpId + "' and Date = '" + DateTom + "'", con);
            //SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date = '" + DateTom + "' and Drop_Pickup='Pickup'", con);
            // SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date between '" + DateToday + "' and '" + DateTom + "' order by Date Desc", con);
            // SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date ='" + DateToday + "'union all select* from Employee_Request where Employee_ID = '" + EmpId + "' and Date ='" + DateTom + "' order by id Desc", con);
            SqlCommand cmd = new SqlCommand("select * from Employee_Request where Employee_ID = '" + EmpId + "' and  Emp_date >= cast(getdate() as Date) order by Emp_date Asc", con);
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
                        e.Row.Cells[4].Visible = false;
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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aa = DropDownList2.SelectedValue;

            if (aa == "Pick")
            {
                string DateTom = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
              //  TextBox7.Text = DateTom;
                DropDownList1.Items[0].Enabled = true;
                DropDownList1.Items[1].Enabled = true;
                DropDownList1.Items[2].Enabled = true;
                DropDownList1.Items[3].Enabled = true;
                
                DropDownList1.Items[4].Enabled = true;
                DropDownList1.Items[5].Enabled = true;
                DropDownList1.Items[6].Enabled = true;

            }
            else
            {
                string DateToday = DateTime.Now.AddDays(0).ToString("dd/MM/yyyy");
               // TextBox7.Text = DateToday;
                DropDownList1.Items[4].Enabled = true;
                DropDownList1.Items[5].Enabled = true;
                DropDownList1.Items[6].Enabled = true;

                DropDownList1.Items[1].Enabled = true;
                DropDownList1.Items[2].Enabled = true;
                DropDownList1.Items[3].Enabled = true;
            }
        }
        
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            // string textMobile = (row.FindControl("TextBox1") as TextBox).Text;

            string timeupd = (GridView1.Rows[e.RowIndex].FindControl("DropDownList3") as DropDownList).SelectedItem.Value;
            //  string drppck = (GridView1.Rows[e.RowIndex].FindControl("DropDownList4") as DropDownList).SelectedItem.Value;
            //TextBox texttime = (TextBox)row.Cells[5].Controls[0];        
          
            GridView1.EditIndex = -1;
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee_Request set Time='" + timeupd + "' where ID='" + userid + "'", con);
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