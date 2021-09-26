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
                string tomrrowdate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
                TextBox7.Text = tomrrowdate.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            if (RadioButtonList1.SelectedValue == "Drop")
            {
                using (var sqlCommand = new SqlCommand("SELECT * FROM Employee_Request WHERE ([Date] = '" + TextBox7.Text + "') and Employee_ID ='" + TextBox1.Text + "'and Drop_Pickup ='" + RadioButtonList1.SelectedValue + "'", con))
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
                        string status = "UnAssigned";
                        SqlCommand com = new SqlCommand("Insert into Employee_Request(Drop_Pickup,Employee_ID,Employee_Name,Mobile_Number,Address,Email_Address,Department,Date,Bussines_unit,Time,Gender,Status) values (@Drop_Pickup,@Employee_ID,@Employee_Name,@Mobile_Number,@Address,@Email_Address,@Department,@Date,@Bussines_unit,@Time,@Gender,@Status)", con);
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
                        com.Parameters.AddWithValue("Status", status);
                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
                            Send_email();
                            Response.Write("<script>alert('Cab Drop Requisted Succesfully');</script>");

                            // lblmsg.Text = "Record Inserted Succesfully into the Database";
                            // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        }
                        con.Close();
                        TextBox3.Text = "";
                        // DropDownList1.SelectedValue = "";
                        //  RadioButtonList1.SelectedValue = "";
                        //TextBox1.Focus();
                    }
                }
            }
            if (RadioButtonList1.SelectedValue == "Pickup")
            {
                using (var sqlCommand = new SqlCommand("SELECT * FROM Employee_Request WHERE ([Date] = '" + TextBox7.Text + "') and Employee_ID ='" + TextBox1.Text + "'and Drop_Pickup ='" + RadioButtonList1.SelectedValue + "'", con))
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
                        string status = "UnAssigned";
                        SqlCommand com = new SqlCommand("Insert into Employee_Request(Drop_Pickup,Employee_ID,Employee_Name,Mobile_Number,Address,Email_Address,Department,Date,Bussines_unit,Time,Gender,Status) values (@Drop_Pickup,@Employee_ID,@Employee_Name,@Mobile_Number,@Address,@Email_Address,@Department,@Date,@Bussines_unit,@Time,@Gender,@Status)", con);
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
                        com.Parameters.AddWithValue("Status", status);
                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
                            Send_email();
                            Response.Write("<script>alert('Cab Pickup Requisted Succesfully');</script>");

                            // lblmsg.Text = "Record Inserted Succesfully into the Database";
                            // lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        }
                        con.Close();
                        TextBox3.Text = "";
                        // DropDownList1.SelectedValue = "";
                        //  RadioButtonList1.SelectedValue = "";
                        //TextBox1.Focus();
                    }
                }
            }
        }

        private void Send_email()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("select * from Employee_Request ", con);
            cmd.Parameters.AddWithValue("@Employee_ID", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Date", TextBox7.Text);

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
                if (Emp_ID == TextBox1.Text && reporting_date == TextBox7.Text)
                {
                    items = items + "<tr><td style='border: solid 1px black'>" + Session["Employee_ID"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Employee_Name"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Department"].ToString() + "</td><td style='border: solid 1px black'>" + Session["Address"].ToString() + "</td><td style='border: solid 1px black'>" + drop + "</td><td style='border: solid 1px black'>" + reporting_date + "</td><td style='border: solid 1px black'>" + time + "</td></tr>";

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

                    catch
                    {

                    }




                }

            }
        }
    }
}