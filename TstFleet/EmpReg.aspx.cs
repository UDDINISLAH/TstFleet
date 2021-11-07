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
    public partial class EmpReg : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string status, Gendr, Is_Employee;

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            using (var sqlCommand = new SqlCommand("SELECT * FROM Employee WHERE Email_Address ='" + TextBox4.Text + "'", con))
            {
                status = "True";
                Is_Employee = "Employee";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    Response.Write("<script>alert('User Already Registered');</script>");
                    reader.Dispose();
                }
                else
                {
                    reader.Dispose();
                    SqlCommand com = new SqlCommand("Insert into Employee(Employee_ID,Permanent_Address,Employee_Name,Email_Address,Mobile_Number,Department,Gender,Bussines_unit,Active,Is_Employee) values (@Employee_ID,@Address,@Employee_Name,@Email_Address,@Mobile_Number,@Department,@Gender,@Bussines_unit,@Active,@Is_Employee)", con);
                    com.Parameters.AddWithValue("Employee_ID", TextBox1.Text);
                    com.Parameters.AddWithValue("Address", TextBox2.Text);
                    com.Parameters.AddWithValue("Employee_Name", TextBox3.Text);
                    com.Parameters.AddWithValue("Email_Address", TextBox4.Text);
                    com.Parameters.AddWithValue("Mobile_Number", TextBox5.Text);
                    com.Parameters.AddWithValue("Department", TextBox6.Text);
                    com.Parameters.AddWithValue("Gender", DropDownList1.SelectedValue);
                    com.Parameters.AddWithValue("Bussines_unit", DropDownList2.SelectedValue);
                    com.Parameters.AddWithValue("Active", status);
                    com.Parameters.AddWithValue("Is_Employee", Is_Employee); 
                    int kk = com.ExecuteNonQuery();
                    if (kk != 0)
                    {
                        Response.Write("<script>alert('Employee Registered Succesfully');</script>");
                        //lblmsg.Text = "Record Inserted Succesfully into the Database";
                        //lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                    }
                    con.Close();
                    //form1.Visible = false;
                    //Image1.Visible = true;
                }
            }          
        }
    }
}