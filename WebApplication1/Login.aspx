<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Milestone2DB_24" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Page</title>
    <style>
        /* General styles */
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin: 0;
            padding: 0;
            height: 100vh; /* Full viewport height */
            background-image: url('dbphoto2.png'); /* Replace with your image path */
            background-size: cover; /* Make the image cover the entire screen */
            background-repeat: no-repeat; /* Prevent tiling */
            background-position: center; /* Center the image */
        }
        
        /* Container for buttons */
        .container {
            margin: auto;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 40%;
            padding: 20px;
            background: rgba(0, 0, 64, 0.8); /* Semi-transparent dark blue window */
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.3);
            color: white;
        }

        /* Header styles */
        h1 {
            color: #add8e6; /* Light blue color */
        }

        /* Button styles */
        .btn {
            display: inline-block;
            margin: 10px;
            padding: 15px 30px;
            font-size: 16px;
            color: white;
            text-align: center;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 150px;
            background: rgba(0, 0, 128, 0.9); /* Match container color */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
            transition: transform 0.3s ease, background 0.3s ease, box-shadow 0.3s ease; /* Smooth transition */
        }

        /* Button Hover Effects */
        .btn:hover {
            transform: scale(1.05); /* Slightly enlarge button */
            background: rgba(0, 0, 160, 0.9); /* Slightly brighter on hover */
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2); /* Soft shadow effect */
        }

        /* Button-specific styles */
        .btn-customer {
            /* Inherits from .btn */
        }

        .btn-admin {
            /* Inherits from .btn */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome</h1>
            <p>Select an option to continue:</p>
            <!-- Buttons -->
            <asp:Button ID="btnCustomer" runat="server" CssClass="btn btn-customer" Text="Customer" OnClick="btnCustomer_Click" />
            <asp:Button ID="btnAdmin" runat="server" CssClass="btn btn-admin" Text="Admin" OnClick="btnAdmin_Click" />
        </div>
    </form>
</body>
</html>
