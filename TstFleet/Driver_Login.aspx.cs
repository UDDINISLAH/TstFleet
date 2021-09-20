using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace TstFleet
{
    public partial class Driver_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str, UserName, Driver_name;
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            if (TextBox1.Text != null)
            {
                SqlCommand cmd = new SqlCommand("select * from Driver_detail", con);
                cmd.Parameters.AddWithValue("@Mobile", TextBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int RowCount = dt.Rows.Count;

                for (int i = 0; i < RowCount; i++)
                {
                    UserName = dt.Rows[i]["Mobile"].ToString();
                    Driver_name = dt.Rows[i]["Driver_Name"].ToString();
                    // Session["UserName"].ToString();

                    if (UserName != TextBox1.Text)
                    {
                       Label1.Text = "Driver Detail does not exist";
                            
                    }
                    else
                    {
                        Session["UserName"] = TextBox1.Text;
                        Session["Driver_name"] = Driver_name;
                        Response.Redirect("Driver.aspx");
                    }
                }
            }
     
        }
    }
}