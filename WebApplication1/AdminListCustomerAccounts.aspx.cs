using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

public partial class AdminListCustomerAccounts : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize data or handle any backend logic here.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string input1 = texty1.Text; // Plan ID
        string input2 = texty2.Text; // Subscription date

        // Check if fields are empty
        if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2))
        {
            hello.Text = "Please fill in all fields.";
            GridView1.Visible = false;
            return;
        }

        // Validate Plan ID
        int planId;
        bool isValidPlanId = int.TryParse(input1, out planId);
        if (!isValidPlanId)
        {
            hello.Text = "Please enter a valid Plan ID.";
            GridView1.Visible = false;
            return;
        }

        // Validate date format
        DateTime parsedDateTime;
        bool isValidDateTime = DateTime.TryParse(input2, out parsedDateTime);
        if (!isValidDateTime)
        {
            hello.Text = "Please enter a valid date.";
            GridView1.Visible = false;
            return;
        }

        // Fetch data using the Account_Plan_date function
        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Account_Plan_date(@sub_date, @plan_id)", conn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@sub_date", parsedDateTime);
        cmd.Parameters.AddWithValue("@plan_id", planId);

        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Check if data is returned
        if (dt.Rows.Count == 0)
        {
            hello.Text = "No customer accounts found for the specified plan and date.";
            GridView1.Visible = false;
        }
        else
        {
            hello.Text = "Customer accounts for Plan ID: " + input1 + " on " + input2;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        conn.Close();
    }
} 