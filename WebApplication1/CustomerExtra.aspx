<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerExtra.aspx.cs" Inherits="CustomerExtra" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Extra Amount for Last Payment</title>
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
        }

        .title {
            font-size: 36px;
            font-weight: bold;
            color: #1E3A8A;
            margin-bottom: 20px;
            text-align: center;
            margin-top: 0;
        }

        .return-button {
            padding: 15px 30px;
            font-size: 18px;
            background: linear-gradient(135deg, #3B82F6, #93C5FD);
            color: white;
            border: none;
            border-radius: 12px;
            cursor: pointer;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
            transition: background 0.3s ease, box-shadow 0.3s ease, transform 0.2s ease;
            margin-bottom: 20px;
        }

        .return-button:hover {
            background: linear-gradient(135deg, #2563EB, #60A5FA);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3);
            transform: translateY(-3px);
        }

        .form-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 100%;
        }

        .form-group {
            margin-bottom: 15px;
            display: flex;
            flex-direction: column;
            gap: 5px;
            width: 50%;
        }

        .form-group label {
            font-size: 16px;
            font-weight: bold;
            color: #1E3A8A;
        }

        .form-group input {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 5px;
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

        .message {
            margin-top: 10px;
            color: red;
            font-weight: bold;
            text-align: center;
        }

        .output-label {
            margin-top: 15px;
            font-size: 18px;
            color: #1E40AF;
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <!-- Return to Customer Dashboard Button -->
            <asp:Button ID="ReturnButton" runat="server" CssClass="return-button" Text="Return to Customer Dashboard" OnClick="ReturnButton_Click" />

            <div class="title">Extra Amount for Last Payment</div>
            <div class="form-container">
                <div class="form-group">
                    <label for="MobileNumber">Mobile Number</label>
                    <asp:TextBox ID="MobileNumber" runat="server" placeholder="Enter mobile number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="PlanName">Plan Name</label>
                    <asp:TextBox ID="PlanName" runat="server" placeholder="Enter plan name"></asp:TextBox>
                </div>
                <asp:Button ID="ShowExtraAmount" runat="server" CssClass="show-details" Text="Show Extra Amount" OnClick="ShowExtraAmount_Click" />
                <asp:Label ID="OutputLabel" runat="server" CssClass="output-label"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
