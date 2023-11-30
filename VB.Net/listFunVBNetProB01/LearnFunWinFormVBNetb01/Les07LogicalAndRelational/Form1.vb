Public Class Form1
    Private Sub btnGetGrade_Click(sender As Object, e As EventArgs) Handles btnGetGrade.Click
        Dim iScore As Integer
        iScore = txtExamCode.Text

        If iScore < 0 Or iScore > 100 Then
            MsgBox("That is not valid score. Enter a number between 0 and 100")
            'exit when the program excute this signtag, the program will be exit 
            Exit Sub
        End If

        If iScore >= 50 Then
            MsgBox("pass")

        Else
            MsgBox("Not Pass")
        End If


        MsgBox("all done")
    End Sub
End Class
