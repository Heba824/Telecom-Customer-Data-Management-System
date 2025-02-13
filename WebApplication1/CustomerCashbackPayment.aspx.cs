using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerCashbackPayment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridName2.Visible = false; // Hide GridView initially
            hello.Text = string.Empty; // Clear any error or success messages
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Connection string from Web.config
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        // Get inputs from the TextBoxes
        string mobileInput = TextBox1.Text.Trim();
        string paymentIdInput = TextBox2.Text.Trim();
        string benefitIdInput = TextBox3.Text.Trim();

        // Validate inputs
        if (!IsValidInput(mobileInput, paymentIdInput, benefitIdInput))
        {
            hello.Text = "Please provide valid inputs: 11-digit mobile number, payment ID, and benefit ID.";
            gridName2.Visible = false;
            return;
        }

        try
        {
            // Call the stored procedure
            using (SqlCommand cmd = new SqlCommand("Payment_wallet_cashback", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobile_num", mobileInput);
                cmd.Parameters.AddWithValue("@payment_id", paymentIdInput);
                cmd.Parameters.AddWithValue("@benefit_id", benefitIdInput);

                conn.Open();

                // Execute the stored procedure and populate a DataTable with the results
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        // Bind data to GridView
                        gridName2.DataSource = dt;
                        gridName2.DataBind();
                        gridName2.Visible = true; // Show GridView
                        hello.Text = ""; // Clear error messages
                    }
                    else
                    {
                        hello.Text = "No cashback details found for the provided information.";
                        gridName2.Visible = false; // Hide GridView
                    }
                }
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred: " + ex.Message;
            gridName2.Visible = false; // Hide GridView
        }
        finally
        {
            conn.Close(); // Ensure the database connection is closed
        }
    }

    /// <summary>
    /// Validates the input fields.
    /// </summary>
    private bool IsValidInput(string mobile, string paymentId, string benefitId)
    {
        return mobile.Length == 11 && int.TryParse(paymentId, out _) && int.TryParse(benefitId, out _);
    }
}
