<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutputTesting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutputTesting))
        Me.txtOutput = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.AutoScrollMinSize = New System.Drawing.Size(25, 15)
        Me.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.FoldingIndicatorColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtOutput.Language = FastColoredTextBoxNS.Language.VB
        Me.txtOutput.Location = New System.Drawing.Point(0, 0)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.PreferredLineWidth = 0
        Me.txtOutput.Size = New System.Drawing.Size(525, 383)
        Me.txtOutput.TabIndex = 0
        '
        'frmOutputTesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 383)
        Me.Controls.Add(Me.txtOutput)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOutputTesting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Output - Used for testing only"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtOutput As FastColoredTextBoxNS.FastColoredTextBox
End Class
