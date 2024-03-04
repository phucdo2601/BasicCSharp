Imports System

Public Class Employee
    Private firstName As String
    Private lastName As String

    Public Property Age As Integer
        Get
            Return Age
        End Get
        Set(value As Integer)
            Age = value
        End Set

    End Property

    Private basSal As Double
    Private yearEx As Integer


    Public Function GetFirstName() As String
        Return firstName
    End Function

    Public Function SetFirstName(fName As String) As String
        firstName = fName
    End Function

    Public Function GetLastName() As String
        Return lastName
    End Function

    Public Function SetLastName(lName As String) As String
        lastName = lName
    End Function

    Public Function DisplayFullname() As String
        Dim fullName As String = ""
        fullName = GetFirstName() + " " + GetLastName()
        Return fullName
    End Function
End Class