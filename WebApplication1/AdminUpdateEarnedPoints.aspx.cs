using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminUpdateEarnedPoints : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any logic you want to load when the page loads can be added here.
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string mobileInput = TextBox1.Text.Trim();

        // Validate the mobile number
        if (mobileInput.Length != 11)
        {
            hello.Text = "Please enter a valid 11-digit mobile number.";
            gridName2.Visible = false; // Make sure the grid is hidden if input is invalid
            LabelMessage.Visible = false; // Hide success message if input is invalid
            return;
        }

        hello.Text = ""; // Clear the error message

        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                // Create a command for the stored procedure
                SqlCommand proc = new SqlCommand("Total_Points_Account", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                proc.Parameters.AddWithValue("@mobile_num", mobileInput);

                // Open the connection and execute the stored procedure
                conn.Open();
                proc.ExecuteNonQuery();

                // Retrieve updated points and show it in GridView
                SqlCommand fetchCommand = new SqlCommand(
                    "SELECT mobileNo, points FROM customer_account WHERE mobileNo = @mobile_num", conn);
                fetchCommand.Parameters.AddWithValue("@mobile_num", mobileInput);

                SqlDataReader reader = fetchCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();

                // Bind the result to the GridView
                gridName2.DataSource = dt;
                gridName2.DataBind();

                // Show GridView only if there are records
                gridName2.Visible = dt.Rows.Count > 0;

                if (dt.Rows.Count == 0)
                {
                    hello.Text = "No records found for the given mobile number.";
                    LabelMessage.Visible = false; // Hide success message if no records found
                }
                else
                {
                    // Display success message
                    LabelMessage.CssClass = "success-message";
                    LabelMessage.Text = "Earned points successfully updated for the provided mobile number.";
                    LabelMessage.Visible = true; // Make sure the success message is visible
                }
            }
            catch (SqlException ex)
            {
                hello.Text = "Database error: " + ex.Message;
                LabelMessage.Visible = false; // Hide success message on error
            }
            catch (Exception ex)
            {
                hello.Text = "An error occurred: " + ex.Message;
                LabelMessage.Visible = false; // Hide success message on error
            }
        }
    }
}
