using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;

public partial class CustomerConsumption : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize data or handle any backend logic here.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDashboard.aspx");
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
            hello.Text = "Please fill in all.";
            GridView1.Visible = false;
            return;
        }

        // Check if date format is valid
        DateTime parsedDateTime;
        bool isValidDateTime = DateTime.TryParse(input2, out parsedDateTime);

        if (!isValidDateTime)
        {
            hello.Text = "Please enter a valid date format.";
            GridView1.Visible = false;
            return;
        }

        DateTime parsedDateTime2;
        bool isValidDateTime2 = DateTime.TryParse(input3, out parsedDateTime2);

        if (!isValidDateTime2)
        {
            hello.Text = "Please enter a valid date format.";
            GridView1.Visible = false;
            return;
        }

        // Clear the hello label and fetch data
        SqlCommand java = new SqlCommand("SELECT * FROM dbo.Consumption(@Plan_name, @start_date, @end_date)", conn);
        java.CommandType = CommandType.Text;
        java.Parameters.AddWithValue("@Plan_name", input1);
        java.Parameters.AddWithValue("@start_date", input2);
        java.Parameters.AddWithValue("@end_date", input3);



        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(java);
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
            hello.Text = "";
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }
}
