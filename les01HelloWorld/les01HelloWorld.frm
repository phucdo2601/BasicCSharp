VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5430
   ClientLeft      =   8025
   ClientTop       =   3510
   ClientWidth     =   7755
   LinkTopic       =   "Form1"
   ScaleHeight     =   5430
   ScaleWidth      =   7755
   Begin VB.CommandButton btnSum 
      Caption         =   "Sum"
      Height          =   735
      Left            =   720
      TabIndex        =   4
      Top             =   1920
      Width           =   1575
   End
   Begin VB.TextBox txtNum2 
      Height          =   375
      Left            =   1800
      TabIndex        =   3
      Top             =   1080
      Width           =   1575
   End
   Begin VB.TextBox txtNum1 
      Height          =   615
      Left            =   1800
      TabIndex        =   0
      Top             =   240
      Width           =   1575
   End
   Begin VB.Label lblResult 
      Height          =   975
      Left            =   3840
      TabIndex        =   5
      Top             =   360
      Width           =   2295
   End
   Begin VB.Label lblNum2 
      Caption         =   "Number 2:"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1080
      Width           =   1095
   End
   Begin VB.Label lblNum1 
      Caption         =   "Number 1:"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   360
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Text1_Change()

End Sub

Private Sub btnSum_Click()
    Dim num1 As Integer
    Dim num2 As Integer
    Dim sum As Integer
    
    num1 = txtNum1.Text
    num2 = txtNum2.Text
    sum = num1 + num2
    
    lblResult.Caption = sum
    
End Sub
