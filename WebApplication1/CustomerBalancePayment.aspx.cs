using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerBalancePayment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LabelMessage.Text = string.Empty; // Clear any messages
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        // Connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        // Get inputs
        string mobileInput = TextBoxMobile.Text.Trim();
        string amountInput = TextBoxAmount.Text.Trim();
        string paymentMethodInput = TextBoxPaymentMethod.Text.Trim();

        // Validate inputs
        if (mobileInput.Length != 11 || !decimal.TryParse(amountInput, out decimal amount) || string.IsNullOrEmpty(paymentMethodInput))
        {
            LabelMessage.Text = "Please enter valid input: 11-digit mobile number, valid amount, and payment method.";
            return;
        }

        try
        {
            // Call the stored procedure
            using (SqlCommand cmd = new SqlCommand("Initiate_balance_payment", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobile_num", mobileInput);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethodInput);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // Execute procedure

                if (rowsAffected > 0)
                {
                    LabelMessage.ForeColor = System.Drawing.Color.Green;
                    LabelMessage.Text = "Balance payment successful!";
                }
                else
                {
                    LabelMessage.ForeColor = System.Drawing.Color.Red;
                    LabelMessage.Text = "Payment failed. Please check the details and try again.";
                }
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            conn.Close(); // Ensure the connection is always closed
        }
    }
}
