<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        lblName = New Label()
        lblSurname = New Label()
        lblLastAddedName = New Label()
        lblAddedSurname = New Label()
        txtName = New TextBox()
        txtSurname = New TextBox()
        btnSave = New Button()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(39, 36)
        lblName.Name = "lblName"
        lblName.Size = New Size(42, 15)
        lblName.TabIndex = 0
        lblName.Text = "Name:"
        ' 
        ' lblSurname
        ' 
        lblSurname.AutoSize = True
        lblSurname.Location = New Point(39, 77)
        lblSurname.Name = "lblSurname"
        lblSurname.Size = New Size(57, 15)
        lblSurname.TabIndex = 1
        lblSurname.Text = "Surname:"
        ' 
        ' lblLastAddedName
        ' 
        lblLastAddedName.AutoSize = True
        lblLastAddedName.Location = New Point(132, 119)
        lblLastAddedName.Name = "lblLastAddedName"
        lblLastAddedName.Size = New Size(41, 15)
        lblLastAddedName.TabIndex = 2
        lblLastAddedName.Text = "Label3"
        ' 
        ' lblAddedSurname
        ' 
        lblAddedSurname.AutoSize = True
        lblAddedSurname.Location = New Point(132, 179)
        lblAddedSurname.Name = "lblAddedSurname"
        lblAddedSurname.Size = New Size(41, 15)
        lblAddedSurname.TabIndex = 3
        lblAddedSurname.Text = "Label4"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(132, 41)
        txtName.Name = "txtName"
        txtName.Size = New Size(253, 23)
        txtName.TabIndex = 4
        ' 
        ' txtSurname
        ' 
        txtSurname.Location = New Point(132, 77)
        txtSurname.Name = "txtSurname"
        txtSurname.Size = New Size(253, 23)
        txtSurname.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(132, 239)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnSave)
        Controls.Add(txtSurname)
        Controls.Add(txtName)
        Controls.Add(lblAddedSurname)
        Controls.Add(lblLastAddedName)
        Controls.Add(lblSurname)
        Controls.Add(lblName)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblName As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblLastAddedName As Label
    Friend WithEvents lblAddedSurname As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents btnSave As Button

End Class
