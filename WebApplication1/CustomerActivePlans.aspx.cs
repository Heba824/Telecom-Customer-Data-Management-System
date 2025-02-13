using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerActivePlans : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hide the grid initially
        if (!IsPostBack)
        {
            gridName2.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        string mobileInput = TextBox1.Text.Trim();

        if (mobileInput.Length != 11 || !long.TryParse(mobileInput, out _))
        {
            hello.Text = "Please enter a valid 11-digit mobile number.";
            gridName2.Visible = false; // Hide the grid if input is invalid
            return;
        }

        hello.Text = ""; // Clear the error message

        try
        {
            // Log the mobileInput for debugging
            System.Diagnostics.Debug.WriteLine("Mobile Input: " + mobileInput);

            // Use parameterized query to prevent SQL injection
            string query = "SELECT * FROM dbo.Usage_Plan_CurrentMonth(@mobile_num)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mobile_num", mobileInput);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);

            // Log row count for debugging
            System.Diagnostics.Debug.WriteLine("Row Count: " + dt.Rows.Count);

            // Check if data is returned
            if (dt.Rows.Count == 0)
            {
                hello.Text = "No results found.";
                gridName2.Visible = false;
            }
            else
            {
                hello.Text = "";
                gridName2.DataSource = dt;
                gridName2.DataBind();
                gridName2.Visible = true;
            }
        }
        catch (Exception ex)
        {
            hello.Text = "An error occurred: " + ex.Message;
            System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }

}
