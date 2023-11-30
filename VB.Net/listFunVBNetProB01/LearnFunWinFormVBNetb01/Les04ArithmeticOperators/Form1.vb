Public Class Form1
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim iNumber0ne As Double
        Dim iNumberTwo As Double
        Dim iResult As Double

        iNumber0ne = txtNumOne.Text
        iNumberTwo = txtNumTwo.Text

        iResult = iNumber0ne + iNumberTwo

        MsgBox(iResult)

        iResult = iNumber0ne - iNumberTwo

        MsgBox(iResult)

        iResult = iNumber0ne * iNumberTwo

        MsgBox(iResult)

        iResult = iNumber0ne / iNumberTwo

        MsgBox(iResult)

        iResult = iNumber0ne ^ iNumberTwo

        MsgBox(iResult)

        'Chia lay phan nguyen
        iResult = iNumber0ne \ iNumberTwo

        MsgBox(iResult)

        iResult = iNumber0ne Mod iNumberTwo

        MsgBox(iResult)



    End Sub
End Class
