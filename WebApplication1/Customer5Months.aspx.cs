
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

public partial class Customer5Months : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This can be used to initialize page-specific data if needed.
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string mobileNo = textMobileNo.Text.Trim();

        if (string.IsNullOrEmpty(mobileNo) || mobileNo.Length != 11)
        {
            hello.Text = "Please enter a valid 11-digit Mobile Number.";
            hello.ForeColor = System.Drawing.Color.Red;
            return;
        }

        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Define a query to call the table-valued function
                string query = "SELECT * FROM dbo.Subscribed_plans_5_months(@MobileNo)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameter to the query
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.Char, 11)).Value = mobileNo;

                    // Use SqlDataAdapter to fill the DataTable with the results
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Check if any data was returned
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        hello.Text = "Subscribed plans for the past 5 months:";
                        hello.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        GridView1.Visible = false;
                        hello.Text = "No subscribed plans found for the given mobile number.";
                        hello.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred while retrieving data. Please try again later.";
            hello.ForeColor = System.Drawing.Color.Red;
            // Log the exception details (optional)
            // Example: LogError(ex);
        }
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDashboard.aspx");
    }
}