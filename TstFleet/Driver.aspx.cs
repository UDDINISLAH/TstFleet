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
    public partial class Driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Sessiontxt.Text = "Welcome" + Session["Driver_name"].ToString();
            }
        }

        protected void Cab_model_TextChanged(object sender, EventArgs e)
        {

        }
        string strConnString =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
           // "Data Source=172.16.102.78;Initial Catalog=Fleet_IU;uid=sa;pwd=s0l@rnoida;";
        SqlCommand com;

        protected void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Insert into Driver_detail values(@DriverName,@Mobile,@Email,@Address,@cab_model,@Cab_number)";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@DriverName", txt_DriverName.Text);
            com.Parameters.AddWithValue("@Mobile", txt_Mobile.Text);
            com.Parameters.AddWithValue("@Email", Email.Text);
            com.Parameters.AddWithValue("@Address", Address.Text);
            com.Parameters.AddWithValue("@cab_model", Cab_model.Text);
            com.Parameters.AddWithValue("@Cab_number", cab_number.Text);
            
            
                con.Open();
            com.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Successfully Registered!!!";
            clear();
        }
        private void clear()
        {
            txt_DriverName.Text = "";
            txt_Mobile.Text="";
            Email.Text = "";
            Address.Text = "";
            Cab_model.Text = "";
            cab_number.Text = "";

           
        }
    }
    }
