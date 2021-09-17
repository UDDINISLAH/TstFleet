using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TstFleet
{
    public partial class WelcomeEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=172.16.102.78;Initial Catalog=Fleet_IU;uid=sa;pwd=s0l@rnoida;");
            con.Open();
            SqlCommand com = new SqlCommand("Insert into employee values (@Employee_Name,@Employee_ID,@Mobile_Number,@Email_Address,@Business_Unit,@Gender,@Address,@Pin_Code,@Active)", con);
            com.Parameters.AddWithValue("Employee_Name", TextBox1.Text);
            com.Parameters.AddWithValue("Employee_ID", TextBox2.Text);
            com.Parameters.AddWithValue("Mobile_Number", TextBox3.Text);
            com.Parameters.AddWithValue("Email_Address", TextBox5.Text);
           // com.Parameters.AddWithValue("Business_Unit", DropDownList1.SelectedValue);
           // com.Parameters.AddWithValue("Gender", RadioButtonList1.SelectedValue);
            com.Parameters.AddWithValue("Address", TextBox4.Text);
            com.Parameters.AddWithValue("Pin_Code", TextBox6.Text);
            com.Parameters.AddWithValue("Active", "1");
            com.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
           // DropDownList1.SelectedValue = "";
          //  RadioButtonList1.SelectedValue = "";
            TextBox1.Focus();


        }
    }
}