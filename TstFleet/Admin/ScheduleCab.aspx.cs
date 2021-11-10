using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Drawing;
using System.Web;
using System.Web.UI.HtmlControls;

namespace TstFleet
{
    public partial class ScheduleCab : System.Web.UI.Page
    {
        DataTable dt;
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string DateTom = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        string DateToday = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
        string drppck;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Employee_ID"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                gvbind();
                // gvbindDriver();
            }
        }

        protected void gvbind()
        {
            // string EmpId = Session["Employee_ID"].ToString();
            //GridView1.Columns[9].Visible = false;          
            //string str = "";
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Date='" + DateTom + "' And Status='" + str + "' order by Preference", con);
            //  SqlCommand cmd = new SqlCommand("Select * from Employee_Request where Date between '" + DateToday + "' and '" + DateTom + "' order by Date desc", con);
            // SqlCommand cmd = new SqlCommand("Select* from Employee_Request where Date ='" + DateToday + "'union all select* from Employee_Request where Date ='" + DateTom + "' order by Preference", con);
            //SqlCommand cmd = new SqlCommand("SELECT Employee_Request.Employee_ID,Employee_Request.Employee_Name,Employee_Request.Gender,Employee_Request.Mobile_Number,Employee.Permanent_Address,Employee_Request.Date,Employee_Request.Drop_Pickup, Employee_Request.Time, Employee_Request.PickupTime, Employee_Request.Id, Employee_Request.CabNo, Employee_Request.Driver_Info, Employee_Request.Emp_Status FROM Employee INNER JOIN Employee_Request ON Employee.Employee_ID = Employee_Request.Employee_ID where Date between '" + DateToday + "' and '" + DateTom + "' order by Preference", con);
            SqlCommand cmd = new SqlCommand("select * from Employee_Request where Emp_date = '" + DateToday + "' or Emp_date='" + DateTom + "' order by Preference", con);
            //SqlCommand cmd = new SqlCommand("Show_Data", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateTom", DateTom);
            cmd.Parameters.AddWithValue("@DateToday", DateToday);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dt = new DataTable();
            da.Fill(dt);

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
            ViewState["Data"] = dt;
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
            drppck = ddlCountry.SelectedItem.Value;
            DataView dataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(drppck))
            {
                dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
            }
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);

            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //  TextBox CabNo = (TextBox)row.Cells[5].Controls[0];
            //TextBox DriverInfo = (TextBox)row.Cells[6].Controls[0];
            string Addr = (row.FindControl("txtadd") as TextBox).Text;
            string PickupTime = (row.FindControl("TextBox1") as TextBox).Text;
            string CabNo = (GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedItem.Value;
            string DriverInfo = (GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList).SelectedItem.Value;
            if (String.IsNullOrEmpty(PickupTime) || String.IsNullOrEmpty(CabNo) || String.IsNullOrEmpty(DriverInfo) || CabNo == "0" || DriverInfo == "0" || PickupTime == "0")
            {
                Response.Write("<script>alert('Please Select All PickupTime,CabNo and DriverInfo');</script>");
            }
            else
            {
                string sts = "Allot";
                //TextBox texttime = (TextBox)row.Cells[5].Controls[0];
                GridView1.EditIndex = -1;
                con.Open();
                SqlCommand cmdd = new SqlCommand("update Employee_Request set Address='" + Addr + "', PickupTime='" + PickupTime + "',CabNo='" + CabNo + "',Driver_Info='" + DriverInfo + "',Status='" + sts + "' where ID='" + userid + "'", con);
                cmdd.ExecuteNonQuery();
                con.Close();
                gvbind();
                drppck = ddlCountry.SelectedItem.Value;
                DataView dataView = dt.DefaultView;
                if (!string.IsNullOrEmpty(drppck))
                {
                    dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
                }
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }

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
            drppck = ddlCountry.SelectedItem.Value;
            DataView dataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(drppck))
            {
                dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
            }
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }

        protected void UpdatePreference(object sender, EventArgs e)
        {
            int[] locationIds = (from p in Request.Form["LocationId"].Split(',')
                                 select int.Parse(p)).ToArray();
            int preference = 1;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            foreach (int locationId in locationIds)
            {
                //this.UpdatePreference(locationId, preference);
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Employee_Request SET Preference = @Preference WHERE ID = @Id"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            //string status = (GridView1.Rows[row.RowIndex].FindControl("Assignsts") as DropDownList).SelectedItem.Value;                                
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", locationId);
                            cmd.Parameters.AddWithValue("@Preference", preference);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            gvbind();
                            drppck = ddlCountry.SelectedItem.Value;
                            DataView dataView = dt.DefaultView;
                            if (!string.IsNullOrEmpty(drppck))
                            {
                                dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
                            }
                            GridView1.DataSource = dataView;
                            GridView1.DataBind();
                            con.Close();
                        }
                    }
                }

                preference += 1;
            }

            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            SqlConnection con = new SqlConnection(strConnString);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                Label lblEmpsts = (Label)e.Row.FindControl("lblEmpsts");
                Label DropPickclr = (Label)e.Row.FindControl("DropPickup");
                //Label CabNmbr = (Label)e.Row.FindControl("Label2");

                //if (!string.IsNullOrEmpty(CabNmbr.Text))
                //{
                //    e.Row.Cells[9].Visible = true;
                //}
                //else
                //{
                //    e.Row.Cells[9].Visible = false;
                //}

                if (DropPickclr.Text == "Pick")
                {
                    e.Row.BackColor = System.Drawing.Color.DeepSkyBlue;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                }
                // Label tme = (Label)e.Row.FindControl("Label4");

                ///   SqlCommand cmdTme = new SqlCommand("Select * from Employee_Request where Date between '" + DateToday + "' and '" + DateTom + "' order by Preference", con);
                //for edit visible
                if (!string.IsNullOrEmpty(lblEmpsts.Text))
                {
                    if (lblEmpsts.Text == "Yes")
                    {
                        e.Row.Cells[13].Visible = false;
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.Cells[13].Visible = false;
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                con.Open();
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("DropDownList1");
                DropDownList ddl2 = (DropDownList)e.Row.FindControl("DropDownList2");
                string sql = "SELECT * FROM Driver_Detail";

                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl1.DataSource = dt;
                        ddl1.DataTextField = "Cab_Number";
                        ddl1.DataValueField = "Cab_Number";
                        ddl1.DataBind();
                        ddl1.Items.Insert(0, new ListItem("Select", "0"));
                        string selectedddl1 = DataBinder.Eval(e.Row.DataItem, "CabNo").ToString();
                        if (selectedddl1 != "" & ddl1.Items.FindByValue(selectedddl1) != null)
                        {
                            ddl1.Items.FindByValue(selectedddl1).Selected = true;
                        }

                        ddl2.DataSource = dt;
                        ddl2.DataTextField = "Driver_Info";
                        ddl2.DataValueField = "Driver_Info";
                        ddl2.DataBind();
                        ddl2.Items.Insert(0, new ListItem("Select", "0"));
                        string selectedddl2 = DataBinder.Eval(e.Row.DataItem, "Driver_Info").ToString();
                        if (selectedddl2 != "" & ddl2.Items.FindByValue(selectedddl2) != null)
                        {
                            ddl2.Items.FindByValue(selectedddl2).Selected = true;
                        }
                    }
                }
                con.Close();
            }
        }

        protected void Country_Changed(object sender, EventArgs e)
        {
            gvbind();
            drppck = ddlCountry.SelectedItem.Value;
            DataView dataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(drppck))
            {
                dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
            }
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "RBharat-" + DateTime.Now + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                gvbind();
                drppck = ddlCountry.SelectedItem.Value;
                DataView dataView = dt.DefaultView;
                if (!string.IsNullOrEmpty(drppck))
                {
                    dataView.RowFilter = "Drop_Pickup = '" + drppck + "'";
                }
                GridView1.DataSource = dataView;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[13].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.DataBind();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;

                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {

                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void Display(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = GridView1.Rows[rowIndex];

            lblstudentid.Text = (row.FindControl("Label2") as Label).Text;
            //lblmonth.Text = (row.FindControl("Label4") as Label).Text; ;
            //txtAmount.Text = (row.FindControl("Label4") as Label).Text;          

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Employee_Request where CabNo ='" + lblstudentid.Text + "' and Emp_Date between '" + DateToday + "' and '" + DateTom + "' order by Date desc", con);
            cmd.Parameters.AddWithValue("@DateTom", DateTom);
            cmd.Parameters.AddWithValue("@DateToday", DateToday);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dt = new DataTable();
            da.Fill(dt);

            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView2.DataSource = ds;
                GridView2.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView2.Rows[0].Cells[0].Text = "No Records Found";
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none","<script>$('#mymodal').modal('show');</script>", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", true);
        }
    

        //private void SearchCustomers()
        //{
        //    using (SqlConnection con = new SqlConnection(strConnString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            //string sql = "SELECT * FROM Employee_Request where Date ='" + DateToday + "'union all select* from Employee_Request where Date ='" + DateTom + "'";
        //            string sql = "SELECT * FROM Employee_Request where Date between '" + DateToday + "' and '" + DateTom + "'";
        //            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
        //            {
        //                sql += "and CabNo LIKE @CabNo + '%'";
        //                cmd.Parameters.AddWithValue("@CabNo", txtSearch.Text.Trim());
        //            }
        //            cmd.CommandText = sql;
        //            cmd.Connection = con;
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                GridView1.DataSource = dt;
        //                GridView1.DataBind();
        //            }
        //        }
        //    }
        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            //SearchCustomers();
        }
    }
}