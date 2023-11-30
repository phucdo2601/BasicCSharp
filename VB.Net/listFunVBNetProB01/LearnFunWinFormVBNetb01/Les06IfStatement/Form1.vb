Public Class Form1
    Private Sub btnGreet_Click(sender As Object, e As EventArgs) Handles btnGreet.Click
        Dim stCountry As String

        stCountry = txtAnwser.Text.Trim.ToUpper

        If stCountry = "USA" Then
            MsgBox("This country is USA")
            MsgBox("test-str-digit-b01")
            MsgBox("test-str-digit-b012")

        ElseIf stCountry = "CHINA" Then
            MsgBox("This country is CHINA")
            MsgBox("test-str-digit-b02")
            MsgBox("test-str-digit-b013")
        ElseIf stCountry = "JAPAN" Then
            MsgBox("This country is JAPAN")
            MsgBox("test-str-digit-b03")
            MsgBox("test-str-digit-b015")

        Else
            MsgBox("Hello there, This is greetting message!")
        End If
    End Sub
End Class
