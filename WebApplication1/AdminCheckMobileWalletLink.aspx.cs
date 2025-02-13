using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminCheckMobileWalletLink : Page
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
        string mobileNum = mobileNumber.Text.Trim();
        
        // Check if the mobile number is provided
        if (string.IsNullOrWhiteSpace(mobileNum))
        {
            messageLabel.Text = "Please enter a mobile number.";
            return;
        }

        // Check if the mobile number is valid
        if (mobileNum.Length != 11)
        {
            messageLabel.Text = "Mobile number must be 11 digits.";
            return;
        }

        // Database connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        try
        {
            SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_MobileNo(@mobileNum)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mobileNum", mobileNum);

            conn.Open();

            // Execute the function and check the result
            var result = cmd.ExecuteScalar();
            if (result != null && Convert.ToInt32(result) == 1)
            {
                messageLabel.Text = "The mobile number is linked to a wallet.";
            }
            else
            {
                messageLabel.Text = "The mobile number is not linked to any wallet.";
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
