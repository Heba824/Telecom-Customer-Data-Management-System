using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminRemoveBenefits : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any logic you want to load when the page loads can be added here.
    }

    protected void ButtonRemove_Click(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileInput = TextBoxMobileNumber.Text;
        string planIDInput = TextBoxPlanID.Text;

        // Validate mobile number length and Plan ID
        if (mobileInput.Length != 11 || string.IsNullOrEmpty(planIDInput))
        {
            LabelMessage.Text = "Please enter a valid 11-digit mobile number and Plan ID.";
            gridName2.Visible = false;  // Hide the grid if input is invalid
            return;
        }

        LabelMessage.Text = ""; // Clear any error message

        // Prepare and execute stored procedure
        SqlCommand proc = new SqlCommand("Benefits_Account", conn);
        proc.CommandType = CommandType.StoredProcedure;
        proc.Parameters.AddWithValue("@mobile_num", mobileInput);
        proc.Parameters.AddWithValue("@plan_id", Convert.ToInt32(planIDInput));

        try
        {
            conn.Open();
            int rowsAffected = proc.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                LabelMessage.Text = "Benefit successfully removed.";
                LabelMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelMessage.Text = "No benefit found for the given mobile number and plan ID.";
                LabelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = "An error occurred: " + ex.Message;
            LabelMessage.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            conn.Close();
        }

        // Hide the GridView after performing the operation
        gridName2.Visible = false;
    }
}