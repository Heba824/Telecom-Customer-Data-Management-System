using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminViewResolvedTickets : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the connection string from the Web.config
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();

        // Create SQL connection and command
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand accountLog = new SqlCommand("SELECT * FROM allResolvedTickets", conn);
        accountLog.CommandType = CommandType.Text;

        try
        {
            conn.Open();
            SqlDataReader reader = accountLog.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();

            // Bind data to the GridView
            gridResolvedTickets.DataSource = dt;
            gridResolvedTickets.DataBind();
        }
        catch (Exception ex)
        {
            // Handle any errors (for debugging purposes, can be expanded for production)
            Response.Write("Error: " + ex.Message);
        }
    }
}

