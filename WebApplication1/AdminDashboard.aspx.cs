using System;

public partial class AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the admin is logged in (use session or authentication check)
        if (Session["AdminLoggedIn"] == null || (bool)Session["AdminLoggedIn"] == false)
        {
            // Redirect to login page if not logged in
            Response.Redirect("AdminLogin.aspx");
        }
    }
}
