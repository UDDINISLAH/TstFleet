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
    public partial class Setting : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string status, Gendr, Is_Employee;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                Dropdownbind();
            }
        }

        public void Dropdownbind()
        {
            SqlConnection con = new SqlConnection(str);
            string com = "Select ID, Employee_Name + ' - ' + Employee_ID  as new  from Employee";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "new";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataBind();
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            // SqlCommand cmd = new SqlCommand("select * from Employee where id = '" + DropDownList1.SelectedValue + "'", con);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Employee where id = '" + DropDownList2.SelectedValue + "'", con);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            ;
            SqlDataReader DR1 = cmd1.ExecuteReader();
            if (DR1.Read())
            {
                TextBox1.Text = DR1["Employee_Name"].ToString();
                TextBox2.Text = DR1["Employee_ID"].ToString();
                TextBox3.Text = DR1["Mobile_Number"].ToString();
                TextBox4.Text = DR1["Email_Address"].ToString();
                TextBox5.Text = DR1["Department"].ToString();
                TextBox6.Text = DR1["Gender"].ToString();
                TextBox7.Text = DR1["Permanent_Address"].ToString();
                TextBox8.Text = DR1["Bussines_Unit"].ToString();
                Label1.Text = "Record Found";
            }
            else
            {
                Label1.Text = "Record Not Found";
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("update Employee set Employee_Name=@Employee_Name, Employee_ID=@Employee_ID, Mobile_Number=@Mobile_Number,Email_Address=@Email_Address,Department=@Department,Gender=@Gender,Permanent_Address=@Permanent_Address,Bussines_Unit=@Bussines_Unit where Employee_ID=@Employee_ID", con);
                //SqlCommand cmd1 = new SqlCommand("update Employee_Request set Address=@Address where Employee_ID=@Employee_ID", con);
                con.Open();

                cmd.Parameters.AddWithValue("@Employee_Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Employee_ID", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Mobile_Number", TextBox3.Text);
                cmd.Parameters.AddWithValue("@Email_Address", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Department", TextBox5.Text);
                cmd.Parameters.AddWithValue("@Gender", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Permanent_Address", TextBox7.Text);
                cmd.Parameters.AddWithValue("@Bussines_Unit", TextBox8.Text);
                cmd.ExecuteNonQuery();
                Label1.Text = ("Record Updated Successfully");
                con.Close();
            }
            else
            {
                Label1.Text = ("Record Not Found");
            }
            Dropdownbind();
        }
    }
}