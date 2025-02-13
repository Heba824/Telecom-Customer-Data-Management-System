<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerActivePlans.aspx.cs" Inherits="CustomerActivePlans" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Active Plan Usage this Month</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #1E3A8A, #3B82F6, #93C5FD);
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            height: 100%;
            justify-content: flex-start;
        }

        .header {
            width: 100%;
            background-color: #1E3A8A;
            color: white;
            text-align: center;
            padding: 30px 0;
            font-size: 28px;
            font-weight: bold;
            border-bottom: 4px solid #3B82F6;
            margin-bottom: 20px;
        }

        .form-container {
            width: 100%;
            max-width: 500px;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            text-align: center;
            margin-bottom: 40px;
            z-index: 10;
            position: relative;
        }

        .form-container input {
            width: 100%;
            padding: 15px;
            font-size: 16px;
            border-radius: 8px;
            border: 1px solid #ccc;
            margin-bottom: 20px;
            transition: border-color 0.3s ease;
        }

        .form-container input:focus {
            border-color: #3B82F6;
            outline: none;
        }

        .submit-btn, .return-btn {
            width: 100%;
            padding: 15px;
            background-color: #3B82F6;
            color: white;
            font-size: 18px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background 0.3s ease, box-shadow 0.3s ease, transform 0.2s ease;
            margin-bottom: 12px;
        }

        .submit-btn:hover, .return-btn:hover {
            background-color: #2563EB;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            transform: translateY(-3px);
        }

        .footer {
            width: 100%;
            background-color: #1E3A8A;
            color: white;
            text-align: center;
            padding: 10px;
            position: fixed;
            bottom: 0;
        }

        .grid-container {
            width: 100%;
            margin-top: 30px;
            display: block;
            max-width: 100%;
            overflow-y: auto;
            max-height: 400px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .table th {
            background-color: #3B82F6;
            color: white;
        }

        .table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .table tr:hover {
            background-color: #e8f5fd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            Active Plan Usage this Month
        </div>

        <div class="form-container">
            <!-- Mobile Number Input -->
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Mobile Number" />
            
            <!-- Label for error or success message -->
            <asp:Label ID="hello" runat="server" ForeColor="Red" />

            <!-- Submit Button -->
            <asp:Button ID="Button1" runat="server" Text="View Active Plans" CssClass="submit-btn" OnClick="Button1_Click" />
            
            <!-- Return to Dashboard Button -->
            <a href="CustomerDashboard.aspx">
                <button type="button" class="return-btn">Return to Customer Dashboard</button>
            </a>
        </div>

        <!-- Grid for displaying the table from the stored procedure -->
        <div class="grid-container">
            <asp:GridView ID="gridName2" runat="server" AutoGenerateColumns="true" CssClass="table" />
        </div>

    </form>
</body>
</html>
