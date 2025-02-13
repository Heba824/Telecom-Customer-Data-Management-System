using System;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any logic on page load if needed
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Retrieve username and password from the form inputs
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Example hardcoded check, replace with real authentication (database, etc.)
        if (username == "admin" && password == "admin123")
        {
            // Set session for logged-in admin (optional)
            Session["AdminLoggedIn"] = true;

            // Redirect to Admin Dashboard upon successful login
            Response.Redirect("AdminDashboard.aspx");
        }
        else
        {
            // Show error message if login fails
            lblMessage.Text = "Invalid username or password.";
        }
    }
}
