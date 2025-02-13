using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAcceptedPaymentTransactionsDetails : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ensure the GridView is not visible on the initial page load
        if (!IsPostBack)
        {
            gridName2.Visible = false;
            hello.Text = string.Empty; // Clear any previous messages
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Connection string
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileInput = TextBox1.Text.Trim();

        // Validate mobile number length
        if (mobileInput.Length != 11)
        {
            hello.Text = "Please enter a valid 11-digit mobile number.";
            gridName2.Visible = false; // Hide GridView if input is invalid
            return;
        }

        hello.Text = ""; // Clear error message

        try
        {
            // Call the stored procedure
            using (SqlCommand cmd = new SqlCommand("Account_Payment_Points", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobile_num", mobileInput); // Pass the mobile number parameter

                conn.Open();

                // Execute the stored procedure and load the results into a DataTable
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Check if data is available
                    if (dt.Rows.Count > 0)
                    {
                        // Modify the column names in the DataTable to match the GridView's BoundField names
                        DataColumn numberOfTransactions = new DataColumn("NumberOfTransactions", typeof(int));
                        DataColumn totalEarnedPoints = new DataColumn("TotalEarnedPoints", typeof(decimal));

                        dt.Columns.Add(numberOfTransactions);
                        dt.Columns.Add(totalEarnedPoints);

                        // Populate the new columns with the data from the query
                        foreach (DataRow row in dt.Rows)
                        {
                            row["NumberOfTransactions"] = row[0]; // Assuming the first column is count
                            row["TotalEarnedPoints"] = row[1]; // Assuming the second column is sum of points
                        }

                        // Remove the old columns if necessary (optional, depending on how you want to display it)
                        dt.Columns.RemoveAt(0); // Remove the first column
                        dt.Columns.RemoveAt(0); // Remove the second column

                        gridName2.DataSource = dt;
                        gridName2.DataBind();
                        gridName2.Visible = true; // Show GridView if data is found
                        hello.Text = ""; // Clear any error message
                    }
                    else
                    {
                        hello.Text = "No payments found for the given mobile number in the last year.";
                        gridName2.Visible = false; // Hide GridView if no data
                    }
                }
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred: " + ex.Message;
            gridName2.Visible = false; // Hide GridView if there's an error
        }
        finally
        {
            conn.Close(); // Ensure the connection is always closed
        }
    }
}
