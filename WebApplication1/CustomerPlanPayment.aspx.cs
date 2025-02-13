using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerPlanPayment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LabelMessage.Text = string.Empty; // Clear messages on initial load
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        // Connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileInput = TextBoxMobile.Text.Trim();
        string planIdInput = TextBoxPlanID.Text.Trim();
        string amountInput = TextBoxAmount.Text.Trim();
        string paymentMethodInput = TextBoxPaymentMethod.Text.Trim();

        // Validate inputs
        if (mobileInput.Length != 11 || !int.TryParse(planIdInput, out int planId) || !decimal.TryParse(amountInput, out decimal amount) || string.IsNullOrWhiteSpace(paymentMethodInput))
        {
            LabelMessage.Text = "Please provide valid input for all fields.";
            return;
        }

        try
        {
            using (SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobile_num", mobileInput);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethodInput);
                cmd.Parameters.AddWithValue("@plan_id", planId);

                conn.Open();
                cmd.ExecuteNonQuery();

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Payment processed successfully.";
            }
        }
        catch (Exception ex)
        {
            LabelMessage.ForeColor = System.Drawing.Color.Red;
            LabelMessage.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}
