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
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtExamCode = New System.Windows.Forms.TextBox()
        Me.btnGetGrade = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(67, 44)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(171, 16)
        Me.lblCode.TabIndex = 0
        Me.lblCode.Text = "Enter the examination code:"
        '
        'txtExamCode
        '
        Me.txtExamCode.Location = New System.Drawing.Point(259, 44)
        Me.txtExamCode.Name = "txtExamCode"
        Me.txtExamCode.Size = New System.Drawing.Size(232, 22)
        Me.txtExamCode.TabIndex = 1
        '
        'btnGetGrade
        '
        Me.btnGetGrade.Location = New System.Drawing.Point(146, 116)
        Me.btnGetGrade.Name = "btnGetGrade"
        Me.btnGetGrade.Size = New System.Drawing.Size(167, 52)
        Me.btnGetGrade.TabIndex = 2
        Me.btnGetGrade.Text = "Get Grade"
        Me.btnGetGrade.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGetGrade)
        Me.Controls.Add(Me.txtExamCode)
        Me.Controls.Add(Me.lblCode)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCode As Label
    Friend WithEvents txtExamCode As TextBox
    Friend WithEvents btnGetGrade As Button
End Class
