using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerUnresolved : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any page load logic can go here if needed.
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        // Get the input National ID
        string nationalIDInput = TextBoxNID.Text;

        if (string.IsNullOrWhiteSpace(nationalIDInput) || !int.TryParse(nationalIDInput, out int nationalID))
        {
            LabelMessage.Text = "Please enter a valid National ID.";
            GridViewTickets.Visible = false; // Hide the GridView on invalid input
            return;
        }

        LabelMessage.Text = ""; // Clear any previous error messages

        // Database connection and procedure execution
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("Ticket_Account_Customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NID", nationalID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                // Rename the column
                if (dt.Columns.Count > 0)
                {
                    dt.Columns[0].ColumnName = "Number of Technical Support Tickets for this Account";
                }

                // Bind data to the GridView
                GridViewTickets.DataSource = dt;
                GridViewTickets.DataBind();
                GridViewTickets.Visible = dt.Rows.Count > 0; // Show only if data exists
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}