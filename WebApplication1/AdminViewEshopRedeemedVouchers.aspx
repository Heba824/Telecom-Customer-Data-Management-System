<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminViewEshopRedeemedVouchers.aspx.cs" Inherits="AdminViewEshopRedeemedVouchers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin View E-shop Redeemed Vouchers</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #1E3A8A, #3B82F6, #93C5FD);
            margin: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .main {
            width: 100%;
            padding: 20px;
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 20px;
        }

        .title {
            font-size: 36px;
            font-weight: bold;
            color: #1E3A8A;
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.2);
        }

        .show-details {
            padding: 15px 30px;
            font-size: 20px;
            background: linear-gradient(135deg, #3B82F6, #93C5FD);
            color: white;
            border: none;
            border-radius: 12px;
            cursor: pointer;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
            transition: background 0.3s ease, box-shadow 0.3s ease, transform 0.2s ease;
        }

        .show-details:hover {
            background: linear-gradient(135deg, #2563EB, #60A5FA);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3);
            transform: translateY(-3px);
        }

        .return-dashboard {
            padding: 15px 30px;
            font-size: 18px;
            background: linear-gradient(135deg, #3B82F6, #93C5FD);
            color: white;
            border: none;
            border-radius: 12px;
            cursor: pointer;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
            transition: background 0.3s ease, box-shadow 0.3s ease, transform 0.2s ease;
        }

        .return-dashboard:hover {
            background: linear-gradient(135deg, #0F766E, #0284C7);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3);
            transform: translateY(-3px);
        }

        .grid-container {
            width: 100%;
            overflow-x: auto;
            display: none; /* Initially hidden */
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        table th, table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        table th {
            background-color: #3B82F6;
            color: white;
        }
    </style>
</head>
<body>
    <div class="main">
        <!-- Return to Dashboard Button -->
        <button class="return-dashboard" onclick="window.location.href='AdminDashboard.aspx'">Return to Admin Dashboard</button>

        <!-- Title for the page -->
        <div class="title">Admin View E-shop Redeemed Vouchers</div>

        <!-- Show Details button centered below the title -->
        <button class="show-details" id="btnShowDetails" onclick="showGrid()">Show Details</button>

        <!-- Hidden Grid -->
        <form id="form1" runat="server">
            <div id="gridContainer" class="grid-container">
                <asp:GridView ID="gridEshopVouchers" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            </div>
        </form>
    </div>

    <script>
        function showGrid() {
            document.getElementById('gridContainer').style.display = 'block'; // Show the grid when the button is clicked
        }
    </script>
</body>
</html>
