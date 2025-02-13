using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminViewCashbackTransactionsPerWalletDetails : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // Ensure data binding happens only once
        {
            // Define connection string
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            // Define SQL command to get data from the Num_of_cashback view
            SqlCommand accountLog = new SqlCommand("SELECT * FROM Num_of_cashback", conn);
            accountLog.CommandType = CommandType.Text;

            // Open connection, execute query, and load data into DataTable
            conn.Open();
            SqlDataReader reader = accountLog.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();

            // Bind the data to the GridView
            if (dt.Rows.Count > 0)
            {
                gridCashbackTransactions.DataSource = dt;
                gridCashbackTransactions.DataBind();
            }
            else
            {
                // Handle empty data case
                gridCashbackTransactions.Visible = false; // Optionally hide or show a message
            }
        }
    }
}


