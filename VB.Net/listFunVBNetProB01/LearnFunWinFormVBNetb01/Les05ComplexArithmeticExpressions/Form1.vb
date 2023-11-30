Public Class Form1
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim decPrice As Decimal
        Dim iQuantity As Integer
        Dim decDiscount As Decimal
        Dim decTotalCost As Decimal
        Dim decPostage As Decimal

        decPrice = 7
        iQuantity = 10
        decDiscount = 3
        decPostage = 2

        decTotalCost = (decPrice - decDiscount) * iQuantity + decPostage
        MsgBox(decTotalCost)


        'BO(DM)(AS) - Bracket Order Divsion Multiplication Addition Substraction
        'Please execute my dear aunt PE(MD)AS - Parentheses Exponentitation Multiplication Division Addition Substraction

        Dim iResult As Integer
        iResult = 10 - 5 + 2
        MsgBox(iResult)

        iResult = 10 + 5 - 2
        MsgBox(iResult)

        iResult = 10 - 5 + 2
        MsgBox(iResult)


    End Sub
End Class
