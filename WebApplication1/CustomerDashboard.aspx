<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDashboard.aspx.cs" Inherits="CustomerDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #1E3A8A, #3B82F6, #93C5FD);
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            min-height: 100vh;
        }

        .header {
            width: 100%;
            background-color: #1E3A8A;
            color: white;
            text-align: center;
            padding: 20px;
            font-size: 24px;
            font-weight: bold;
            border-bottom: 4px solid white;
        }

        .container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
            gap: 20px;
            padding: 20px;
            width: 80%;
            margin-top: 30px;
        }

        .card {
            background-color: rgba(255, 255, 255, 0.8);
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
            cursor: pointer;
            transition: transform 0.3s ease, background-color 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
            background-color: #f0f4f8;
        }

        .card h3 {
            font-size: 18px;
            color: #333;
            margin-bottom: 15px;
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
    </style>
</head>
<body>
    <a class="back-button" href="Login.aspx">Back to Main Page</a>
    <div class="header">
        Customer Dashboard
    </div>

    <div class="container">
        <div class="card" onclick="window.location.href='CustomerServicePlans.aspx'">
            <h3>View Service Plans</h3>
        </div>

          <div class="card" onclick="window.location.href='CustomerShops.aspx'">
            <h3>View Shops</h3>
        </div>


        <div class="card" onclick="window.location.href='CustomerConsumption.aspx'">
            <h3>View SMS, Minutes & Internet Consumption</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerUnsubscribed.aspx'">
            <h3>View Unsubscribed Plans</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerActivePlans.aspx'">
            <h3>Active Plan Usage This Month</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerCashback.aspx'">
            <h3>Cashback Transactions</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerActiveBenefits.aspx'">
            <h3>View Active Benefits</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerUnresolved.aspx'">
            <h3>Unresolved Tickets</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerHighestVoucher.aspx'">
            <h3>Voucher with Highest Value</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerRemaining.aspx'">
            <h3>Remaining Amount for Last Payment</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerExtra.aspx'">
            <h3>Extra Amount for Last Payment</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerTop.aspx'">
            <h3>Top 10 Payments</h3>
        </div>

        <div class="card" onclick="window.location.href='Customer5Months.aspx'">
            <h3>Plans Subscribed in Past 5 Months</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerPlanPayment.aspx'">
            <h3>Renew Plan Subscription</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerCashbackPayment.aspx'">
            <h3>Cashback Amount from Payment</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerBalancePayment.aspx'">
            <h3>Recharge Balance</h3>
        </div>

        <div class="card" onclick="window.location.href='CustomerRedeemVoucher.aspx'">
            <h3>Redeem Voucher</h3>
        </div>
    </div>

    <div class="footer">
        &copy; 2024 Customer Dashboard | All Rights Reserved
    </div>
</body>
</html>

