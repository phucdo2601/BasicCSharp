<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblQuesCoun = New System.Windows.Forms.Label()
        Me.txtAnwser = New System.Windows.Forms.TextBox()
        Me.btnGreet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblQuesCoun
        '
        Me.lblQuesCoun.AutoSize = True
        Me.lblQuesCoun.Location = New System.Drawing.Point(53, 58)
        Me.lblQuesCoun.Name = "lblQuesCoun"
        Me.lblQuesCoun.Size = New System.Drawing.Size(168, 16)
        Me.lblQuesCoun.TabIndex = 0
        Me.lblQuesCoun.Text = "What country are you from?"
        '
        'txtAnwser
        '
        Me.txtAnwser.Location = New System.Drawing.Point(243, 58)
        Me.txtAnwser.Name = "txtAnwser"
        Me.txtAnwser.Size = New System.Drawing.Size(297, 22)
        Me.txtAnwser.TabIndex = 1
        '
        'btnGreet
        '
        Me.btnGreet.Location = New System.Drawing.Point(164, 123)
        Me.btnGreet.Name = "btnGreet"
        Me.btnGreet.Size = New System.Drawing.Size(89, 34)
        Me.btnGreet.TabIndex = 2
        Me.btnGreet.Text = "Greeting"
        Me.btnGreet.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGreet)
        Me.Controls.Add(Me.txtAnwser)
        Me.Controls.Add(Me.lblQuesCoun)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblQuesCoun As Label
    Friend WithEvents txtAnwser As TextBox
    Friend WithEvents btnGreet As Button
End Class
