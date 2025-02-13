using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CustomerExtra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize data or handle any backend logic here.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDashboard.aspx");
    }

    protected void ShowExtraAmount_Click(object sender, EventArgs e)
    {
        // Get database connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        // Retrieve input values
        string mobileNumber = MobileNumber.Text.Trim();
        string planName = PlanName.Text.Trim();

        // Validate inputs
        if (string.IsNullOrWhiteSpace(mobileNumber) || string.IsNullOrWhiteSpace(planName))
        {
            OutputLabel.Text = "Please fill in all fields.";
            return;
        }

        if (mobileNumber.Length != 11)
        {
            OutputLabel.Text = "Mobile number must be 11 digits.";
            return;
        }

        try
        {
            // Call the function
            SqlCommand cmd = new SqlCommand("SELECT dbo.Extra_plan_amount(@mobile_num, @plan_name)", conn);
            cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
            cmd.Parameters.AddWithValue("@plan_name", planName);

            conn.Open();
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                OutputLabel.Text = "Extra Amount: " + result.ToString();
            }
            else
            {
                OutputLabel.Text = "No data found.";
            }
        }
        catch (Exception ex)
        {
            OutputLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}