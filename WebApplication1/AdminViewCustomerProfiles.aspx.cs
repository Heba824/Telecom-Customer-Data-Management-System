using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminViewCustomerProfiles : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  // Ensure the data is loaded only when the page is initially loaded (not on postback)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand accountLog = new SqlCommand("SELECT * FROM allCustomerAccounts", conn);
            accountLog.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader reader = accountLog.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();

            // Bind data to the correct GridView ID
            gridCustomerProfiles.DataSource = dt;
            gridCustomerProfiles.DataBind();
        }
    }
}

