using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerCashback : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hide the grid initially
        if (!IsPostBack)
        {
            GridView1.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string nationalID = texty1.Text.Trim();

        // Validate if National ID is numeric
        if (!int.TryParse(nationalID, out _))
        {
            hello.Text = "Please enter a valid National ID.";
            GridView1.Visible = false; // Hide grid if input is invalid
            return;
        }

        hello.Text = ""; // Clear the error message

        // Use parameterized query to prevent SQL injection
        string query = "SELECT * FROM dbo.Cashback_Wallet_Customer(@NID)";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@NID", int.Parse(nationalID));

        try
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Check if data is returned
            if (dt.Rows.Count == 0)
            {
                hello.Text = "No cashback transactions found.";
                GridView1.Visible = false;
            }
            else
            {
                hello.Text = ""; // Clear any previous message
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred: " + ex.Message;
            GridView1.Visible = false;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDashboard.aspx");
    }
}
