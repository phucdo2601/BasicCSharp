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

    Private Sub btnDataType_Click(sender As Object, e As EventArgs) Handles btnDataType.Click
        Dim stMake As String
        Dim stModel As String
        Dim iDoors As Integer
        Dim stColour As String
        Dim bTaxed As Boolean
        Dim iEngineSize As Integer
        Dim decPrice As Decimal
        Dim dtDateRegistered As Date

        stMake = "test-make-b01"
        stModel = "test-model-b01"
        iDoors = 3
        stColour = "test-color-b01"
        bTaxed = True
        iEngineSize = 134
        decPrice = 8888.88
        dtDateRegistered = #4/23/2022#

        MsgBox(dtDateRegistered)
        MsgBox(dtDateRegistered & vbNewLine & stMake & vbNewLine & decPrice)

    End Sub
End Class
