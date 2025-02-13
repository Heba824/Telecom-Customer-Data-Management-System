<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        /* Gradient background with shades of blue */
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            background: linear-gradient(135deg, #1E3A8A, #3B82F6, #93C5FD); /* Shades of blue */
            height: 100vh; /* Full viewport height */
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        /* Back button styling */
        .back-button {
            position: absolute;
            top: 10px;
            left: 10px;
            padding: 10px 15px;
            background-color: #4f97d1;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            font-size: 14px;
            transition: background-color 0.3s ease;
        }

        .back-button:hover {
            background-color: #0069d9;
        }

        /* Login container styles with blended background */
        .login-container {
            width: 300px;
            padding: 30px;
            background-color: rgba(255, 255, 255, 0.85); /* Light white with transparency */
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            opacity: 0; /* Start with hidden */
            transform: translateY(-20px); /* Start above the page */
            animation: popUp 0.5s forwards; /* Add pop-up animation */
        }

        /* Animation for the pop-up effect */
        @keyframes popUp {
            to {
                opacity: 1; /* Make the container visible */
                transform: translateY(0); /* Move it to the original position */
            }
        }

        h2 {
            color: #333;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Button styling with a color that fits the background */
        .btn-login {
            width: 100%;
            padding: 15px;
            background-color: #4f97d1; /* Slightly darker blue than the background */
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-login:hover {
            background-color: #0069d9; /* A bit darker blue for hover effect */
        }

        /* Label for error message */
        .error-message {
            color: red;
            font-size: 14px;
        }
        
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <!-- Back button to main page -->
        <a class="back-button" href="Login.aspx">Back to Main Page</a>

        <div class="login-container">
            <h2>Admin Login</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
            <div>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" placeholder="Username" />
            </div>
            <div>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" placeholder="Password" />
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn-login" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>