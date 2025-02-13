using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerServicePlans : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand accountLog = new SqlCommand("SELECT * FROM allServicePlans", conn);
        accountLog.CommandType = CommandType.Text;
        conn.Open();
        SqlDataReader reader = accountLog.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        reader.Close();
        conn.Close();
        gridName.DataSource = dt;
        gridName.DataBind();
    }
}