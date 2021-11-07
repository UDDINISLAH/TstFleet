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

        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string str, UserName, Password, Employee_ID, Address, Email_Address, Department, Bussines_Unit, Mobile_Number, Gender;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {          
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("select * from Employee where Email_Address=@Email_Address", con);
            
            cmd.Parameters.AddWithValue("@Email_Address", TextBox1.Text);        
            
            cmd.Parameters.AddWithValue("", TextBox2.Text);
            // cmd.Parameters.AddWithValue("word", TextBox2.Text);

            if (TextBox1.Text != null && TextBox2.Text != null)
            {
                if (TextBox1.Text=="ADMIN" && TextBox2.Text=="1234")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int RowCount = dt.Rows.Count;
                    for (int i = 0; i < RowCount; i++)
                    {
                        Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                        Session["Employee_ID"] = Employee_ID;

                        UserName = dt.Rows[i]["Employee_Name"].ToString();
                        Session["Employee_Name"] = UserName;

                        Address = dt.Rows[i]["Permanent_Address"].ToString();
                        Session["Permanent_Address"] = Address;

                        Email_Address = dt.Rows[i]["Email_Address"].ToString();
                        Session["Email_Address"] = Email_Address;

                        Department = dt.Rows[i]["Department"].ToString();
                        Session["Department"] = Department;

                        Bussines_Unit = dt.Rows[i]["Bussines_Unit"].ToString();
                        Session["Bussines_Unit"] = Bussines_Unit;

                        Mobile_Number = dt.Rows[i]["Mobile_Number"].ToString();
                        Session["Mobile_Number"] = Mobile_Number;

                        Gender = dt.Rows[i]["Gender"].ToString();
                        Session["Gender"] = Gender;

                        if (Email_Address != null)
                        {
                            //Session["Employee_Name"] = UserName;
                            if (dt.Rows[i]["Is_Employee"].ToString() == "Employee")
                                Response.Redirect("Employee/CabStatus.aspx");
                            // Response.Redirect("~/Admin/Admin.aspx");
                            else
                                Response.Redirect("Admin/ScheduleCab.aspx");
                        }
                    }
                }
               else if (TextBox1.Text == "USER" && TextBox2.Text == "1234")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int RowCount = dt.Rows.Count;
                    for (int i = 0; i < RowCount; i++)
                    {
                        Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                        Session["Employee_ID"] = Employee_ID;

                        UserName = dt.Rows[i]["Employee_Name"].ToString();
                        Session["Employee_Name"] = UserName;

                        Address = dt.Rows[i]["Permanent_Address"].ToString();
                        Session["Permanent_Address"] = Address;

                        Email_Address = dt.Rows[i]["Email_Address"].ToString();
                        Session["Email_Address"] = Email_Address;

                        Department = dt.Rows[i]["Department"].ToString();
                        Session["Department"] = Department;

                        Bussines_Unit = dt.Rows[i]["Bussines_Unit"].ToString();
                        Session["Bussines_Unit"] = Bussines_Unit;

                        Mobile_Number = dt.Rows[i]["Mobile_Number"].ToString();
                        Session["Mobile_Number"] = Mobile_Number;

                        Gender = dt.Rows[i]["Gender"].ToString();
                        Session["Gender"] = Gender;

                        if (Email_Address != null)
                        {
                            //Session["Employee_Name"] = UserName;
                            if (dt.Rows[i]["Is_Employee"].ToString() == "Employee")
                                Response.Redirect("Employee/CabStatus.aspx");
                            // Response.Redirect("~/Admin/Admin.aspx");
                            else
                                Response.Redirect("Admin/ScheduleCab.aspx");
                        }
                    }
                }
                else
                {
                    using (DirectoryEntry entry1 = new DirectoryEntry())
                    {
                        entry1.Username = TextBox1.Text;//"sanjay.kumar1";
                        entry1.Password = TextBox2.Text;//"India@24x7";

                        DirectorySearcher searcher = new DirectorySearcher(entry1);
                        searcher.Filter = "(&(objectClass=user)(objectCategory=person))";

                        try
                        {
                            searcher.FindOne();
                            // usr = db.CovidUsers.SingleOrDefault(u => u.User_Name == user + "@republicworld.com");
                            //Session["UserName"] = entry1.Username;
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            int RowCount = dt.Rows.Count;
                            for (int i = 0; i < RowCount; i++)
                            {
                                Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                                Session["Employee_ID"] = Employee_ID;

                                UserName = dt.Rows[i]["Employee_Name"].ToString();
                                Session["Employee_Name"] = UserName;

                                Address = dt.Rows[i]["Permanent_Address"].ToString();
                                Session["Permanent_Address"] = Address;

                                Email_Address = dt.Rows[i]["Email_Address"].ToString();
                                Session["Email_Address"] = Email_Address;

                                Department = dt.Rows[i]["Department"].ToString();
                                Session["Department"] = Department;

                                Bussines_Unit = dt.Rows[i]["Bussines_Unit"].ToString();
                                Session["Bussines_Unit"] = Bussines_Unit;

                                Mobile_Number = dt.Rows[i]["Mobile_Number"].ToString();
                                Session["Mobile_Number"] = Mobile_Number;

                                Gender = dt.Rows[i]["Gender"].ToString();
                                Session["Gender"] = Gender;

                                if (Email_Address != null)
                                {
                                    //Session["Employee_Name"] = UserName;
                                    if (dt.Rows[i]["Is_Employee"].ToString() == "Employee")
                                        Response.Redirect("Employee/CabStatus.aspx");
                                    // Response.Redirect("~/Admin/Admin.aspx");
                                    else
                                        Response.Redirect("Admin/ScheduleCab.aspx");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Session["UserName"] = user;

                            Session["error_msg"] = ex.Message;
                            Label1.Text = ex.Message;

                            //return Json(1);
                        }
                    }
                }   
            }
            

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox1.Focus();
        }
    }
}