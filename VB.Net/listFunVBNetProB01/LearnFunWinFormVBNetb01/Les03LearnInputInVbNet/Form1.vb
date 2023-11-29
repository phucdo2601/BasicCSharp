Public Class Form1
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim sFirstName As String
        sFirstName = InputBox("Please enter your first name")
        MsgBox("Hello " & sFirstName)
    End Sub
End Class
