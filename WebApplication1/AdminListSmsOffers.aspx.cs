using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class AdminListSmsOffers : Page
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

        string input1 = texty1.Text.Trim();

        // Check if the field is empty
        if (string.IsNullOrWhiteSpace(input1))
        {
            hello.Text = "Please enter a mobile number.";
            GridView1.Visible = false;
            return;
        }

        try
        {
            // Clear the hello label and fetch data using the Account_SMS_Offers function
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Account_SMS_Offers(@mobile_num)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mobile_num", input1);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Check if data is returned
            if (dt.Rows.Count == 0)
            {
                hello.Text = "No SMS offers found.";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
                hello.Text = "SMS offers listed below.";
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
}