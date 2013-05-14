<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProject))
        Me.pctrbxLogo = New System.Windows.Forms.PictureBox()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSample3 = New System.Windows.Forms.Button()
        Me.btnSample2 = New System.Windows.Forms.Button()
        Me.btnSample1 = New System.Windows.Forms.Button()
        Me.lblMore = New System.Windows.Forms.Label()
        Me.btnBlank = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRecent8 = New System.Windows.Forms.Button()
        Me.btnRecent7 = New System.Windows.Forms.Button()
        Me.btnRecent6 = New System.Windows.Forms.Button()
        Me.btnRecent5 = New System.Windows.Forms.Button()
        Me.btnRecent4 = New System.Windows.Forms.Button()
        Me.btnRecent3 = New System.Windows.Forms.Button()
        Me.btnRecent2 = New System.Windows.Forms.Button()
        Me.btnRecent1 = New System.Windows.Forms.Button()
        Me.txtTips = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.chkStartup = New System.Windows.Forms.CheckBox()
        CType(Me.pctrbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pctrbxLogo
        '
        Me.pctrbxLogo.BackgroundImage = Global.Explosive_Game_Maker.My.Resources.Resources.small_logo
        Me.pctrbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pctrbxLogo.Location = New System.Drawing.Point(12, 12)
        Me.pctrbxLogo.Name = "pctrbxLogo"
        Me.pctrbxLogo.Size = New System.Drawing.Size(32, 32)
        Me.pctrbxLogo.TabIndex = 0
        Me.pctrbxLogo.TabStop = False
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogo.Location = New System.Drawing.Point(50, 12)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Size = New System.Drawing.Size(485, 36)
        Me.lblLogo.TabIndex = 1
        Me.lblLogo.Text = "Explosive Game Maker Pre Alpha [EGM]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSample3)
        Me.GroupBox1.Controls.Add(Me.btnSample2)
        Me.GroupBox1.Controls.Add(Me.btnSample1)
        Me.GroupBox1.Controls.Add(Me.lblMore)
        Me.GroupBox1.Controls.Add(Me.btnBlank)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 286)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create New Project"
        '
        'btnSample3
        '
        Me.btnSample3.Location = New System.Drawing.Point(6, 125)
        Me.btnSample3.Name = "btnSample3"
        Me.btnSample3.Size = New System.Drawing.Size(238, 31)
        Me.btnSample3.TabIndex = 7
        Me.btnSample3.Text = "Sample - Dimensions"
        Me.btnSample3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSample3.UseVisualStyleBackColor = True
        '
        'btnSample2
        '
        Me.btnSample2.Location = New System.Drawing.Point(6, 88)
        Me.btnSample2.Name = "btnSample2"
        Me.btnSample2.Size = New System.Drawing.Size(238, 31)
        Me.btnSample2.TabIndex = 6
        Me.btnSample2.Text = "Sample - Drawing Sprites"
        Me.btnSample2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSample2.UseVisualStyleBackColor = True
        '
        'btnSample1
        '
        Me.btnSample1.Location = New System.Drawing.Point(6, 51)
        Me.btnSample1.Name = "btnSample1"
        Me.btnSample1.Size = New System.Drawing.Size(238, 31)
        Me.btnSample1.TabIndex = 5
        Me.btnSample1.Text = "Sample - Key Events"
        Me.btnSample1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSample1.UseVisualStyleBackColor = True
        '
        'lblMore
        '
        Me.lblMore.AutoSize = True
        Me.lblMore.Location = New System.Drawing.Point(20, 225)
        Me.lblMore.Name = "lblMore"
        Me.lblMore.Size = New System.Drawing.Size(117, 15)
        Me.lblMore.TabIndex = 4
        Me.lblMore.Text = "(More coming soon)"
        '
        'btnBlank
        '
        Me.btnBlank.Location = New System.Drawing.Point(6, 22)
        Me.btnBlank.Name = "btnBlank"
        Me.btnBlank.Size = New System.Drawing.Size(238, 23)
        Me.btnBlank.TabIndex = 3
        Me.btnBlank.Text = "Blank EGM Project"
        Me.btnBlank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlank.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRecent8)
        Me.GroupBox2.Controls.Add(Me.btnRecent7)
        Me.GroupBox2.Controls.Add(Me.btnRecent6)
        Me.GroupBox2.Controls.Add(Me.btnRecent5)
        Me.GroupBox2.Controls.Add(Me.btnRecent4)
        Me.GroupBox2.Controls.Add(Me.btnRecent3)
        Me.GroupBox2.Controls.Add(Me.btnRecent2)
        Me.GroupBox2.Controls.Add(Me.btnRecent1)
        Me.GroupBox2.Location = New System.Drawing.Point(278, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 286)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recent Files"
        '
        'btnRecent8
        '
        Me.btnRecent8.Location = New System.Drawing.Point(6, 225)
        Me.btnRecent8.Name = "btnRecent8"
        Me.btnRecent8.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent8.TabIndex = 5
        Me.btnRecent8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent8.UseVisualStyleBackColor = True
        '
        'btnRecent7
        '
        Me.btnRecent7.Location = New System.Drawing.Point(6, 196)
        Me.btnRecent7.Name = "btnRecent7"
        Me.btnRecent7.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent7.TabIndex = 5
        Me.btnRecent7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent7.UseVisualStyleBackColor = True
        '
        'btnRecent6
        '
        Me.btnRecent6.Location = New System.Drawing.Point(6, 167)
        Me.btnRecent6.Name = "btnRecent6"
        Me.btnRecent6.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent6.TabIndex = 5
        Me.btnRecent6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent6.UseVisualStyleBackColor = True
        '
        'btnRecent5
        '
        Me.btnRecent5.Location = New System.Drawing.Point(6, 138)
        Me.btnRecent5.Name = "btnRecent5"
        Me.btnRecent5.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent5.TabIndex = 5
        Me.btnRecent5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent5.UseVisualStyleBackColor = True
        '
        'btnRecent4
        '
        Me.btnRecent4.Location = New System.Drawing.Point(6, 109)
        Me.btnRecent4.Name = "btnRecent4"
        Me.btnRecent4.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent4.TabIndex = 5
        Me.btnRecent4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent4.UseVisualStyleBackColor = True
        '
        'btnRecent3
        '
        Me.btnRecent3.Location = New System.Drawing.Point(6, 80)
        Me.btnRecent3.Name = "btnRecent3"
        Me.btnRecent3.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent3.TabIndex = 5
        Me.btnRecent3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent3.UseVisualStyleBackColor = True
        '
        'btnRecent2
        '
        Me.btnRecent2.Location = New System.Drawing.Point(6, 51)
        Me.btnRecent2.Name = "btnRecent2"
        Me.btnRecent2.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent2.TabIndex = 5
        Me.btnRecent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent2.UseVisualStyleBackColor = True
        '
        'btnRecent1
        '
        Me.btnRecent1.Location = New System.Drawing.Point(6, 22)
        Me.btnRecent1.Name = "btnRecent1"
        Me.btnRecent1.Size = New System.Drawing.Size(238, 23)
        Me.btnRecent1.TabIndex = 5
        Me.btnRecent1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecent1.UseVisualStyleBackColor = True
        '
        'txtTips
        '
        Me.txtTips.Location = New System.Drawing.Point(12, 343)
        Me.txtTips.Multiline = True
        Me.txtTips.Name = "txtTips"
        Me.txtTips.ReadOnly = True
        Me.txtTips.Size = New System.Drawing.Size(516, 98)
        Me.txtTips.TabIndex = 3
        Me.txtTips.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(453, 447)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(246, 446)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(165, 446)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(75, 23)
        Me.btnPrev.TabIndex = 6
        Me.btnPrev.Text = "Previous"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'chkStartup
        '
        Me.chkStartup.AutoSize = True
        Me.chkStartup.Checked = True
        Me.chkStartup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartup.Location = New System.Drawing.Point(12, 449)
        Me.chkStartup.Name = "chkStartup"
        Me.chkStartup.Size = New System.Drawing.Size(147, 19)
        Me.chkStartup.TabIndex = 5
        Me.chkStartup.Text = "Show Tips on Startup?"
        Me.chkStartup.UseVisualStyleBackColor = True
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 475)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.chkStartup)
        Me.Controls.Add(Me.txtTips)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblLogo)
        Me.Controls.Add(Me.pctrbxLogo)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewProject"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Project"
        CType(Me.pctrbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pctrbxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMore As System.Windows.Forms.Label
    Friend WithEvents btnBlank As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRecent8 As System.Windows.Forms.Button
    Friend WithEvents btnRecent7 As System.Windows.Forms.Button
    Friend WithEvents btnRecent6 As System.Windows.Forms.Button
    Friend WithEvents btnRecent5 As System.Windows.Forms.Button
    Friend WithEvents btnRecent4 As System.Windows.Forms.Button
    Friend WithEvents btnRecent3 As System.Windows.Forms.Button
    Friend WithEvents btnRecent2 As System.Windows.Forms.Button
    Friend WithEvents btnRecent1 As System.Windows.Forms.Button
    Friend WithEvents btnSample3 As System.Windows.Forms.Button
    Friend WithEvents btnSample2 As System.Windows.Forms.Button
    Friend WithEvents btnSample1 As System.Windows.Forms.Button
    Friend WithEvents txtTips As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents chkStartup As System.Windows.Forms.CheckBox
End Class
