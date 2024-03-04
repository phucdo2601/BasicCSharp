Public Class TestVar
    Public Shared Sub Main()
        Dim empObj As New Employee()
        Dim firstName As String = empObj.SetFirstName("Toan")
        Dim lastName As String = empObj.SetLastName("Test Update-l-name-b02")

        Dim fullName As String = empObj.DisplayFullname()

        Console.WriteLine("My fullname is " + fullName)

    End Sub
End Class
