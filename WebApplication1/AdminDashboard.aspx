<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to right, #4c6ef5, #2a5298); /* Gradient to match Admin Login page */
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            min-height: 100vh;
        }

        .header {
            width: 100%;
            background-color: rgba(30, 58, 138, 0.9); /* Same color as Admin Login background with opacity */
            color: white;
            text-align: center;
            padding: 20px;
            font-size: 24px;
            font-weight: bold;
            border-bottom: 2px solid #ffffff;
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
            background-color: rgba(255, 255, 255, 0.9); /* Slightly opaque white to match the admin login style */
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
            cursor: pointer;
            transition: transform 0.3s ease, background-color 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
            background-color: rgba(243, 244, 246, 0.8); /* Lighter hover color with opacity */
        }

        .card h3 {
            font-size: 18px;
            color: #333;
            margin-bottom: 15px;
        }

        .card:hover h3 {
            color: #1E3A8A; /* Dark blue for hovered card titles */
        }

        .footer {
            width: 100%;
            background-color: rgba(30, 58, 138, 0.9); /* Same footer color as header */
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
        Admin Dashboard
    </div>


    <div class="container">
        <!-- Card 1: Customer Profiles -->
        <div class="card" onclick="window.location.href='AdminViewCustomerProfiles.aspx'">
            <h3>View Customer Profiles</h3>
        </div>

       <!-- Card 2: Physical Store Redeemed Vouchers -->
        <div class="card" onclick="window.location.href='AdminViewPhysicalStoreRedeemedVouchers.aspx'">
            <h3>View Physical Store Redeemed Vouchers</h3>
        </div>

       <!-- Card 3: Resolved Tickets -->
        <div class="card" onclick="window.location.href='AdminViewResolvedTickets.aspx'">
            <h3>View Resolved Tickets</h3>
        </div>

        <!-- Card 4: Customers with Subscribed Service Plans -->
        <div class="card" onclick="window.location.href='AdminViewSubscribedServicePlans.aspx'">
            <h3>View Customers with Subscribed Service Plans</h3>
        </div>

       <!-- Card 5: Customer Accounts by Plan ID -->
        <div class="card" onclick="window.location.href='AdminListCustomerAccounts.aspx?planId=INPUT_PLAN_ID&date=INPUT_DATE'">
            <h3>List all customer accounts subscribed to the input plan ID on a certain input date.</h3>
        </div>

        <!-- Card 6: Account Usage for Subscribed Plan -->
        <div class="card" onclick="window.location.href='AdminShowTotalUsage.aspx?mobilenumber=INPUT_MOBILE_NUMBER&date=INPUT_START_DATE'">
            <h3>Show the total usage of the input account on each subscribed plan from a given input date.</h3>
        </div>
        >

        <!-- Card 7: Remove Benefits for Plan -->
        <div class="card" onclick="window.location.href='AdminRemoveBenefits.aspx?accountId=INPUT_ACCOUNT_ID&planId=INPUT_PLAN_ID'">
            <h3>Remove all benefits offered to the input account for a certain input plan ID.</h3>
        </div>

        <!-- Card 8: List SMS Offers for Account -->
        <div class="card" onclick="window.location.href='AdminListSmsOffers.aspx?mobilenumber=INPUT_MOBILE_NUMBER'">
            <h3>List all SMS offers for a certain input account.</h3>
        </div>

        <!-- Card 9: View Wallet Details -->
        <div class="card" onclick="window.location.href='AdminViewWalletDetails.aspx'">
            <h3>View Wallet Details</h3>
        </div>

        <!-- Card 10: E-shop Redeemed Vouchers -->
         <div class="card" onclick="window.location.href='AdminViewEshopRedeemedVouchers.aspx'">
            <h3>View E-shop Redeemed Vouchers</h3>
        </div>

        <!-- Card 11: Payment Transaction Details -->
         <div class="card" onclick="window.location.href='AdminViewPaymentTransactionDetails.aspx'">
            <h3>View Payment Transaction Details</h3>
        </div>

        <!-- Card 12: Cashback Transactions per Wallet -->
        <div class="card" onclick="window.location.href='AdminViewCashbackTransactionsPerWalletDetails.aspx'">
            <h3>Cashback Transactions per Wallet</h3>
        </div>

        <!-- Card 13: Accepted Payment Transactions -->
       <div class="card" onclick="window.location.href='AdminAcceptedPaymentTransactionsDetails.aspx?accountId=INPUT_ACCOUNT_ID'">
    <h3>Show the number of accepted payment transactions initiated by the input account during the last year along with the total amount of earned points.</h3>
</div>


        <!-- Card 14: Cashback on Wallet for Plan -->
        <div class="card" onclick="window.location.href='AdminCashbackAmountDetails.aspx?walletId=INPUT_WALLET_ID&planId=INPUT_PLAN_ID'">
    <h3>Cashback Returned per Wallet and Plan</h3>
</div>

        <!-- Card 15: Transaction Amount Average -->
       <div class="card" onclick="window.location.href='AdminAverageSentTransactionAmount.aspx?walletId=INPUT_WALLET_ID&startDate=INPUT_START_DATE&endDate=INPUT_END_DATE'">
    <h3>Average Sent Transaction Amounts</h3>
</div>

       <div class="card" onclick="window.location.href='AdminCheckMobileWalletLink.aspx?mobileNumber=INPUT_MOBILE_NUMBER'">
    <h3>Mobile Number Wallet Link Check</h3>
</div>

        <!-- Card 17: Update Earned Points for Mobile -->
        <div class="card" onclick="window.location.href='AdminUpdateEarnedPoints.aspx?mobileNumber=INPUT_MOBILE_NUMBER'">
    <h3>Update Earned Points</h3>
</div>

    </div>

    <div class="footer">
        &copy; 2024 Admin Dashboard | All Rights Reserved
    </div>

    <script>
        // Function to handle card clicks and trigger actions
        function handleCardClick(action) {
            alert('Card clicked: ' + action); // Placeholder for actual action
            // You can replace the alert with actual navigation or functionality as needed.
            // For example:
            // window.location.href = action + '.aspx';
        }
    </script>

</body>
</html>