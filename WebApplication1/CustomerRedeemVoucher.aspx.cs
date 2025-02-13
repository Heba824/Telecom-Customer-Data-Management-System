using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerRedeemVoucher : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MessageLabel.Text = string.Empty; // Clear any previous messages
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string mobileInput = TextBoxMobile.Text.Trim();
        string voucherInput = TextBoxVoucherID.Text.Trim();

        // Validate inputs
        if (mobileInput.Length != 11 || !int.TryParse(voucherInput, out int voucherID))
        {
            MessageLabel.Text = "Please enter a valid 11-digit mobile number and numeric Voucher ID.";
            return;
        }

        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Redeem_voucher_points", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@mobile_num", mobileInput);
                    cmd.Parameters.AddWithValue("@voucher_id", voucherID);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Execute the stored procedure

                    MessageLabel.Text = "Voucher redeemed successfully!";
                }
            }
            catch (SqlException ex)
            {
                MessageLabel.Text = $"An error occurred: {ex.Message}";
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
