<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerPlanPayment.aspx.cs" Inherits="CustomerPlanPayment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomerPlanPayment</title>
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
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        }

        .form-container {
            width: 100%;
            max-width: 500px;
            padding: 30px;
            background-color: rgba(59, 130, 246, 0.2);
            border-radius: 12px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            text-align: center;
            margin-bottom: 40px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            CustomerPlanPayment
        </div>

        <div class="form-container">
            <!-- Mobile Number Input -->
            <asp:TextBox ID="TextBoxMobile" runat="server" placeholder="Enter Mobile Number" />

            <!-- Plan ID Input -->
            <asp:TextBox ID="TextBoxPlanID" runat="server" placeholder="Enter Plan ID" />

            <!-- Payment Amount Input -->
            <asp:TextBox ID="TextBoxAmount" runat="server" placeholder="Enter Payment Amount" />

            <!-- Payment Method Input -->
            <asp:TextBox ID="TextBoxPaymentMethod" runat="server" placeholder="Enter Payment Method" />

            <!-- Label for error or success message -->
            <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" />

            <!-- Submit Button -->
            <asp:Button ID="ButtonSubmit" runat="server" Text="Process Payment" CssClass="submit-btn" OnClick="ButtonSubmit_Click" />

            <!-- Return to Dashboard Button -->
            <a href="CustomerDashboard.aspx">
                <button type="button" class="return-btn">Return to Customer Dashboard</button>
            </a>
        </div>
    </form>
</body>
</html>
