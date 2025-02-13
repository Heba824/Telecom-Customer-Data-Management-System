using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerUnsubscribed : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any logic you want to load when the page loads can be added here.
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileInput = TextBox1.Text;

        if (mobileInput.Length != 11)
        {
            hello.Text = "Please enter an 11 digit number.";
            gridName2.Visible = false;  // Make sure the grid is hidden if input is invalid
            return;
        }

        hello.Text = ""; // Clear the error message

        SqlCommand proc = new SqlCommand("Unsubscribed_Plans", conn);
        proc.CommandType = CommandType.StoredProcedure;
        proc.Parameters.AddWithValue("@mobile_num", mobileInput);

        conn.Open();
        SqlDataReader reader = proc.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        reader.Close();
        conn.Close();

        gridName2.DataSource = dt;
        gridName2.DataBind();

        // Make the GridView visible after data binding
        gridName2.Visible = dt.Rows.Count > 0;  // Only show if there is data
    }

}
