using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAverageSentTransactionAmount : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize data or handle any backend logic here.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string input1 = texty1.Text;
        string input2 = texty2.Text;
        string input3 = texty3.Text;

        // Check if fields are empty
        if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2) || string.IsNullOrWhiteSpace(input3))
        {
            hello.Text = "Please fill in all fields.";
            GridView1.Visible = false;
            return;
        }

        // Check if date format is valid
        DateTime parsedDateTime;
        bool isValidDateTime = DateTime.TryParse(input2, out parsedDateTime);
        if (!isValidDateTime)
        {
            hello.Text = "Please enter a valid start date format.";
            GridView1.Visible = false;
            return;
        }

        DateTime parsedDateTime2;
        bool isValidDateTime2 = DateTime.TryParse(input3, out parsedDateTime2);
        if (!isValidDateTime2)
        {
            hello.Text = "Please enter a valid end date format.";
            GridView1.Visible = false;
            return;
        }

        // Clear the hello label and fetch data using the Wallet_Transfer_Amount function
        SqlCommand cmd = new SqlCommand("SELECT dbo.Wallet_Transfer_Amount(@walletID, @start_date, @end_date)", conn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@walletID", input1);
        cmd.Parameters.AddWithValue("@start_date", input2);
        cmd.Parameters.AddWithValue("@end_date", input3);

        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Check if data is returned
        if (dt.Rows.Count == 0)
        {
            hello.Text = "No results found.";
            GridView1.Visible = false;
        }
        else
        {
            hello.Text = "Average transaction amount: " + dt.Rows[0][0].ToString();
            GridView1.Visible = false;
        }

        conn.Close();
    }
}
