using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminShowTotalUsage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page load logic if needed
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileNum = texty1.Text.Trim();
        string startDate = texty2.Text.Trim();

        // Validate inputs
        if (string.IsNullOrWhiteSpace(mobileNum) || string.IsNullOrWhiteSpace(startDate))
        {
            hello.Text = "Please fill in all fields.";
            GridView1.Visible = false;
            return;
        }

        DateTime parsedStartDate;
        if (!DateTime.TryParse(startDate, out parsedStartDate))
        {
            hello.Text = "Please enter a valid start date.";
            GridView1.Visible = false;
            return;
        }

        try
        {
            // SQL command to call the function
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Account_Usage_Plan(@mobile_num, @start_date)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mobile_num", mobileNum);
            cmd.Parameters.AddWithValue("@start_date", parsedStartDate);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Check if data is returned
            if (dt.Rows.Count == 0)
            {
                hello.Text = "No usage data found.";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
                hello.Text = "Total usage data found.";
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred: " + ex.Message;
            GridView1.Visible = false;
        }
        finally
        {
            conn.Close();
        }
    }
}