using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerActiveBenefits : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Connect to the database using the configured connection string
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        // SQL command to retrieve data from the 'allBenefits' view
        SqlCommand command = new SqlCommand("SELECT * FROM allBenefits", conn);
        command.CommandType = CommandType.Text;

        try
        {
            conn.Open(); // Open the connection
            SqlDataReader reader = command.ExecuteReader(); // Execute the command

            // Load data into a DataTable
            DataTable dt = new DataTable();
            dt.Load(reader);

            // Bind the data to the GridView
            gridName.DataSource = dt;
            gridName.DataBind();
        }
        catch (Exception ex)
        {
            // Optionally handle errors (e.g., log the exception or display an error message)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            conn.Close(); // Ensure the connection is closed
        }
    }
}
