using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminViewSubscribedServicePlans : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any logic to execute on page load can be added here
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        hello.Text = ""; // Clear any existing error message

        // Create and configure the command for the stored procedure
        SqlCommand proc = new SqlCommand("Account_Plan", conn);
        proc.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader reader = proc.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        reader.Close();
        conn.Close();

        // Bind the data to the GridView
        gridName2.DataSource = dt;
        gridName2.DataBind();

        // Make the GridView visible only if data is returned
        gridName2.Visible = dt.Rows.Count > 0;

        if (dt.Rows.Count == 0)
        {
            hello.Text = "No subscribed service plans found.";
        }
    }
}