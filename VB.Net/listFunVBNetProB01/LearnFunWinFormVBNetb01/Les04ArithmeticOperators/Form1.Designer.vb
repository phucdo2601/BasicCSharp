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
        Me.lblNum1 = New System.Windows.Forms.Label()
        Me.lblNum2 = New System.Windows.Forms.Label()
        Me.txtNumOne = New System.Windows.Forms.TextBox()
        Me.txtNumTwo = New System.Windows.Forms.TextBox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNum1
        '
        Me.lblNum1.AutoSize = True
        Me.lblNum1.BackColor = System.Drawing.SystemColors.Control
        Me.lblNum1.Location = New System.Drawing.Point(103, 80)
        Me.lblNum1.Name = "lblNum1"
        Me.lblNum1.Size = New System.Drawing.Size(81, 16)
        Me.lblNum1.TabIndex = 0
        Me.lblNum1.Text = "Number one"
        '
        'lblNum2
        '
        Me.lblNum2.AutoSize = True
        Me.lblNum2.Location = New System.Drawing.Point(103, 125)
        Me.lblNum2.Name = "lblNum2"
        Me.lblNum2.Size = New System.Drawing.Size(65, 16)
        Me.lblNum2.TabIndex = 1
        Me.lblNum2.Text = "Number 2"
        '
        'txtNumOne
        '
        Me.txtNumOne.Location = New System.Drawing.Point(243, 80)
        Me.txtNumOne.Name = "txtNumOne"
        Me.txtNumOne.Size = New System.Drawing.Size(217, 22)
        Me.txtNumOne.TabIndex = 2
        '
        'txtNumTwo
        '
        Me.txtNumTwo.Location = New System.Drawing.Point(243, 125)
        Me.txtNumTwo.Name = "txtNumTwo"
        Me.txtNumTwo.Size = New System.Drawing.Size(217, 22)
        Me.txtNumTwo.TabIndex = 3
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(106, 185)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(175, 55)
        Me.btnCalculate.TabIndex = 4
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.txtNumTwo)
        Me.Controls.Add(Me.txtNumOne)
        Me.Controls.Add(Me.lblNum2)
        Me.Controls.Add(Me.lblNum1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNum1 As Label
    Friend WithEvents lblNum2 As Label
    Friend WithEvents txtNumOne As TextBox
    Friend WithEvents txtNumTwo As TextBox
    Friend WithEvents btnCalculate As Button
End Class
