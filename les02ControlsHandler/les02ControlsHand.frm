VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5985
   ClientLeft      =   8055
   ClientTop       =   2505
   ClientWidth     =   10095
   LinkTopic       =   "Form1"
   ScaleHeight     =   5985
   ScaleWidth      =   10095
   Begin VB.CommandButton btnSubmit 
      BackColor       =   &H008080FF&
      Cancel          =   -1  'True
      Caption         =   "Exit"
      Height          =   735
      Left            =   2520
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   3720
      Width           =   2415
   End
   Begin VB.TextBox txtRemarks 
      Height          =   1755
      Left            =   2760
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   4
      Top             =   1560
      Width           =   3015
   End
   Begin VB.TextBox txtRoleNo 
      Height          =   375
      Left            =   2760
      MaxLength       =   10
      TabIndex        =   1
      Top             =   960
      Width           =   1455
   End
   Begin VB.Label lblRemarks 
      Caption         =   "REMARKS:"
      Height          =   495
      Left            =   1320
      TabIndex        =   3
      Top             =   1560
      Width           =   1215
   End
   Begin VB.Label lblRoleNo 
      Caption         =   "Role No:"
      Height          =   495
      Left            =   1320
      TabIndex        =   2
      Top             =   960
      Width           =   1215
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BackColor       =   &H00C0E0FF&
      Caption         =   "School MarkSheet"
      BeginProperty Font 
         Name            =   "Roman"
         Size            =   15.75
         Charset         =   255
         Weight          =   700
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   360
      Left            =   3360
      TabIndex        =   0
      Top             =   240
      Width           =   2385
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
