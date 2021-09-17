using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.DirectoryServices;

namespace TstFleet
{
    public partial class Loginn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=172.16.102.78;Initial Catalog=Fleet_IU;uid=sa;pwd=s0l@rnoida;");
            //SqlCommand cmd = new SqlCommand("select * from Employee where Employee_Name=@Employee_Name", con);
            //cmd.Parameters.AddWithValue("@Employee_Name", TextBox1.Text);
            //cmd.Parameters.AddWithValue("", TextBox2.Text);
            //cmd.Parameters.AddWithValue("word", TextBox2.Text);

            if (TextBox1.Text != null && TextBox2.Text != null)
            {
                using (DirectoryEntry entry1 = new DirectoryEntry())
                {
                    entry1.Username = TextBox1.Text;//"sanjay.kumar1";
                    entry1.Password = TextBox2.Text;//"India@24x7";

                    DirectorySearcher searcher = new DirectorySearcher(entry1);
                    searcher.Filter = "(&(objectClass=user)(objectCategory=person))";

                    try
                    {  //islah   
                        string Emp, Adm, aa, bb;
                        searcher.FindOne();
                        // usr = db.CovidUsers.SingleOrDefault(u => u.User_Name == user + "@republicworld.com");
                        Session["UserName"] = entry1.Username;
                        aa = entry1.Username;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select * from Employee where Email_Address='"+ aa + "' AND active=0 ", con);

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("WelcomeAdmin.aspx");
                        }
                        else
                        {
                            Response.Redirect("WelcomeEmployee.aspx");
                        }
                        con.Close();
                        //Session["UserEmailID"] = usr.User_Name;
                        //Session["OfficeLocation"] = usr.Office_Location;
                        //Session["EmpID"] = usr.Employee_ID;
                        //return Json(usr, JsonRequestBehavior.AllowGet);

                    }
                    catch (Exception ex)
                    {
                        // Session["UserName"] = user;

                        Session["error_msg"] = ex.Message;
                       // Label1.Text = ex.Message;

                        //return Json(1);


                    }
                }
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                //con.Open();
                //int i = cmd.ExecuteNonQuery();
                ////con.Close();
                //if (dt.Rows.Count > 0)
                //{
                //    Response.Redirect("RegistrationForm.aspx");
                //}
                //else
                //{
                //    Label1.Text = "Your username and word is incorrect";
                //}


                //if (dt.Rows.Count > 0)
                //{
                //    Response.Redirect("Redirectform.aspx");
                //}
                //else
                //{
                //    Label1.Text = "Your username and word is incorrect";
                //    Label1.ForeColor = System.Drawing.Color.Red;

                //}
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}