<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSprite
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddSprite))
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.ptrbxSpriteView = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblLoadSprite = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ptrbxSpriteView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(392, 190)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(75, 23)
        Me.btnAccept.TabIndex = 0
        Me.btnAccept.Text = "Okay"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(15, 71)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(129, 23)
        Me.txtName.TabIndex = 2
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(15, 100)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(86, 23)
        Me.btnSelect.TabIndex = 3
        Me.btnSelect.Text = "Select Sprite"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'ptrbxSpriteView
        '
        Me.ptrbxSpriteView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ptrbxSpriteView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ptrbxSpriteView.Location = New System.Drawing.Point(319, 9)
        Me.ptrbxSpriteView.Name = "ptrbxSpriteView"
        Me.ptrbxSpriteView.Size = New System.Drawing.Size(150, 150)
        Me.ptrbxSpriteView.TabIndex = 4
        Me.ptrbxSpriteView.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "png"
        Me.OpenFileDialog1.Filter = "Image Files (*.jpg, *.png, *gif, *bmp) | *.jpg;*.png;*.gif;*.bmp| All Files |*.*"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(12, 126)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(58, 15)
        Me.lblSize.TabIndex = 5
        Me.lblSize.Text = "Size: X: Y: "
        '
        'lblLoadSprite
        '
        Me.lblLoadSprite.AutoSize = True
        Me.lblLoadSprite.Location = New System.Drawing.Point(12, 9)
        Me.lblLoadSprite.Name = "lblLoadSprite"
        Me.lblLoadSprite.Size = New System.Drawing.Size(87, 15)
        Me.lblLoadSprite.TabIndex = 7
        Me.lblLoadSprite.Text = "Select a sprite:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(15, 27)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(126, 23)
        Me.ComboBox1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(311, 190)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Update"
        Me.ToolTip1.SetToolTip(Me.Button1, "Use this if you have changed the sprite's name")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmAddSprite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 225)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lblLoadSprite)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.ptrbxSpriteView)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAccept)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddSprite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Sprite"
        CType(Me.ptrbxSpriteView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents ptrbxSpriteView As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblLoadSprite As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
