using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerLogin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // No specific actions on page load for now
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Get the database connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            // Define the SQL command to call the function
            SqlCommand accountLog = new SqlCommand("SELECT dbo.AccountLoginValidation(@mobile_num, @pass)", conn);
            accountLog.CommandType = CommandType.Text;

            // Get user input
            string mobileNo = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(mobileNo) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            // Add parameters for the SQL function
            accountLog.Parameters.AddWithValue("@mobile_num", mobileNo);
            accountLog.Parameters.AddWithValue("@pass", password);

            try
            {
                // Open the database connection
                conn.Open();

                // Execute the SQL function and get the result
                object result = accountLog.ExecuteScalar();

                // Check if the function returned true (1)
                bool isValidUser = (result != DBNull.Value) && Convert.ToBoolean(result);

                if (isValidUser)
                {
                    // Redirect to the Customer Dashboard
                    Response.Redirect("CustomerDashboard.aspx");
                }
                else
                {
                    // Display an error message if credentials are invalid
                    lblMessage.Text = "Invalid mobile number or password.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and display the error message
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}