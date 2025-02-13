using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerHighestVoucher : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any page load logic can go here if needed.
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        // Get the input Mobile Number
        string mobileInput = TextBoxMobile.Text;

        if (string.IsNullOrWhiteSpace(mobileInput) || mobileInput.Length != 11)
        {
            LabelMessage.Text = "Please enter a valid 11-digit Mobile Number.";
            GridViewVoucher.Visible = false; // Hide the GridView on invalid input
            return;
        }

        LabelMessage.Text = ""; // Clear any previous error messages

        // Database connection and procedure execution
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("Account_Highest_Voucher", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobile_num", mobileInput);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                // Rename the column
                if (dt.Columns.Count > 0)
                {
                    dt.Columns[0].ColumnName = "Voucher ID with Highest Value";
                }

                // Bind data to the GridView
                GridViewVoucher.DataSource = dt;
                GridViewVoucher.DataBind();
                GridViewVoucher.Visible = dt.Rows.Count > 0; // Show only if data exists
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}