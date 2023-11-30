Public Class Form1
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim sFirstname As String
        Dim sLastname As String
        Dim sGender As String
        Dim sOccupation As String

        sFirstname = txtFirstName.Text.Trim
        sLastname = txtLastName.Text.Trim
        sGender = txtGender.Text.Trim
        sOccupation = lstOccupation.SelectedItem



        MsgBox("Hello " & sFirstname & " " & sLastname & " you are a " & sGender & " " & sOccupation)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstOccupation.Items.Add("Writer")
        lstOccupation.Items.Add("Singer")
        lstOccupation.Items.Add("Actor")
    End Sub
End Class
