using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

public partial class CustomerRemaining : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialization logic if needed.
    }

    protected void ReturnButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDashboard.aspx");
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        string mobileNumber = TextBoxMobile.Text.Trim();
        string planName = TextBoxPlanID.Text.Trim();

        if (string.IsNullOrWhiteSpace(mobileNumber) || string.IsNullOrWhiteSpace(planName))
        {
            LabelMessage.Text = "Please fill in all fields.";
            GridViewRemaining.Visible = false;
            return;
        }

        if (mobileNumber.Length != 11 || !long.TryParse(mobileNumber, out _))
        {
            LabelMessage.Text = "Please enter a valid Mobile Number.";
            GridViewRemaining.Visible = false;
            return;
        }

        string connStr = WebConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT dbo.Remaining_plan_amount(@mobile_num, @plan_name) AS RemainingAmount", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
            cmd.Parameters.AddWithValue("@plan_name", planName);

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    LabelMessage.Text = "No data found.";
                    GridViewRemaining.Visible = false;
                }
                else
                {
                    LabelMessage.Text = "";
                    GridViewRemaining.DataSource = dt;
                    GridViewRemaining.DataBind();
                    GridViewRemaining.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}