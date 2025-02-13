using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminCashbackAmountDetails : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize data or handle any backend logic here.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void CheckButton_Click(object sender, EventArgs e)
    {
        // Fetch inputs from the TextBox controls
        string walletIdInput = walletID.Text.Trim(); // walletID refers to the ASP.NET control
        string planIdInput = planID.Text.Trim();

        // Validate inputs
        if (string.IsNullOrWhiteSpace(walletIdInput) || string.IsNullOrWhiteSpace(planIdInput))
        {
            messageLabel.Text = "Both Wallet ID and Plan ID must be provided.";
            return;
        }

        // Check if inputs are numeric
        if (!int.TryParse(walletIdInput, out int walletIdParsed) || !int.TryParse(planIdInput, out int planIdParsed))
        {
            messageLabel.Text = "Wallet ID and Plan ID must be numeric.";
            return;
        }

        // Database connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        try
        {
            // Query the database function
            SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_Cashback_Amount(@walletID, @planID)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@walletID", walletIdParsed); // Use the parsed variable
            cmd.Parameters.AddWithValue("@planID", planIdParsed);

            conn.Open();

            // Execute the function and display the result
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                messageLabel.Text = $"The total cashback amount is: {result} ";
            }

            else 
            {
                messageLabel.Text = $"No cashback amount found for the given Wallet ID and Plan ID.";
            }
        }
        catch (Exception ex)
        {
            messageLabel.Text = "Error: " + ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}

