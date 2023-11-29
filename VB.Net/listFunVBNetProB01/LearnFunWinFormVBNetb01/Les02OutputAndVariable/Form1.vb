Public Class Form1
    Dim testVar As String = "Hello World. Welcome to my channel!"


    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        MsgBox(testVar)

        MessageBox.Show("This is an another message!")



    End Sub

    Private Sub btnVariable_Click(sender As Object, e As EventArgs) Handles btnVariable.Click

        Dim sFirstName As String
        Dim sLastName As String
        sFirstName = "test-first-name-b01"
        sLastName = "t-lastname-b02"
        MsgBox("Hello world and welcome there, " & sFirstName & " " & sLastName & ". I am hero")

        sFirstName = "test-first-name-b01-up"
        sLastName = "t-lastname-b02-up"
        MsgBox("2nd Mess Hello world and welcome there, " & sFirstName & " " & sLastName & ". I am hero")

    End Sub
End Class
