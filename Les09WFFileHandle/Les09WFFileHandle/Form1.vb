
Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            lblLastAddedName.Text = "Name: " + txtName.Text
            lblAddedSurname.Text = "Surname: " + txtSurname.Text
            Dim newData As String = txtName.Text + " " + txtSurname.Text
            My.Computer.FileSystem.WriteAllText("Data.txt", newData + Environment.NewLine, True)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLastAddedName.Text = ""
        lblAddedSurname.Text = ""
        Try
            Using fileReader As New StreamReader("Data.txt", Encoding.GetEncoding("UTF-8"))
                Dim Info As String = Nothing
                Dim SplittedInfo() As String
                While fileReader.Peek() <> +1
                    Info = fileReader.ReadLine()
                    SplittedInfo = Split(Info)
                    lblLastAddedName.Text = "Name " + SplittedInfo(0)
                    lblAddedSurname.Text = "Surname " + SplittedInfo(1)



                End While

                fileReader.Close()
                fileReader.Dispose()

            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class
