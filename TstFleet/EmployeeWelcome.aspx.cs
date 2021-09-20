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
                string tomrrowdate = DateTime.Now.AddDays(1).ToString("MM/dd/yyy");
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

                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
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

                        int kk = com.ExecuteNonQuery();
                        if (kk != 0)
                        {
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
    }
}