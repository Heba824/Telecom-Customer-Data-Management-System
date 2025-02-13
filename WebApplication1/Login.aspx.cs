using System;
using System.Web;
using System.Web.UI;

public partial class Milestone2DB_24 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // No need to handle page load logic for this example
    }

    // Event handler for Customer button
    protected void btnCustomer_Click(object sender, EventArgs e)
    {
        // Redirect to the Customer Login page
        Response.Redirect("CustomerLogin.aspx");
    }

    // Event handler for Admin button
    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        // Redirect to the Admin Login page
        Response.Redirect("AdminLogin.aspx");
    }
}
