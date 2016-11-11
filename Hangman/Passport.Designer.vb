<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Passport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Passport))
        Me.LblInstructions = New System.Windows.Forms.Label()
        Me.BtnContinue = New System.Windows.Forms.Button()
        Me.PBoxFace = New System.Windows.Forms.PictureBox()
        Me.BtnChangeFace = New System.Windows.Forms.Button()
        Me.PBoxGranted = New System.Windows.Forms.PictureBox()
        Me.LblBirth = New System.Windows.Forms.Label()
        Me.RBtnM = New System.Windows.Forms.RadioButton()
        Me.RBtnF = New System.Windows.Forms.RadioButton()
        Me.TboxName = New System.Windows.Forms.TextBox()
        Me.TimerContinue = New System.Windows.Forms.Timer(Me.components)
        Me.LblInfo = New System.Windows.Forms.Label()
        CType(Me.PBoxFace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBoxGranted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblInstructions
        '
        Me.LblInstructions.AutoSize = True
        Me.LblInstructions.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstructions.Location = New System.Drawing.Point(25, 11)
        Me.LblInstructions.MaximumSize = New System.Drawing.Size(250, 52)
        Me.LblInstructions.Name = "LblInstructions"
        Me.LblInstructions.Size = New System.Drawing.Size(245, 42)
        Me.LblInstructions.TabIndex = 0
        Me.LblInstructions.Text = "Your name and sex are required for registration with the Ministry of Labour."
        Me.LblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnContinue
        '
        Me.BtnContinue.Enabled = False
        Me.BtnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnContinue.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnContinue.Location = New System.Drawing.Point(100, 411)
        Me.BtnContinue.Name = "BtnContinue"
        Me.BtnContinue.Size = New System.Drawing.Size(96, 23)
        Me.BtnContinue.TabIndex = 1
        Me.BtnContinue.Text = "Continue >"
        Me.BtnContinue.UseVisualStyleBackColor = True
        '
        'PBoxFace
        '
        Me.PBoxFace.BackColor = System.Drawing.Color.Transparent
        Me.PBoxFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PBoxFace.Location = New System.Drawing.Point(44, 266)
        Me.PBoxFace.Name = "PBoxFace"
        Me.PBoxFace.Size = New System.Drawing.Size(64, 59)
        Me.PBoxFace.TabIndex = 2
        Me.PBoxFace.TabStop = False
        '
        'BtnChangeFace
        '
        Me.BtnChangeFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChangeFace.Font = New System.Drawing.Font("Constantia", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChangeFace.Location = New System.Drawing.Point(39, 329)
        Me.BtnChangeFace.Name = "BtnChangeFace"
        Me.BtnChangeFace.Size = New System.Drawing.Size(75, 23)
        Me.BtnChangeFace.TabIndex = 3
        Me.BtnChangeFace.Text = "Change face"
        Me.BtnChangeFace.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnChangeFace.UseVisualStyleBackColor = True
        '
        'PBoxGranted
        '
        Me.PBoxGranted.BackColor = System.Drawing.Color.Transparent
        Me.PBoxGranted.BackgroundImage = CType(resources.GetObject("PBoxGranted.BackgroundImage"), System.Drawing.Image)
        Me.PBoxGranted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PBoxGranted.Location = New System.Drawing.Point(78, 111)
        Me.PBoxGranted.Name = "PBoxGranted"
        Me.PBoxGranted.Size = New System.Drawing.Size(143, 72)
        Me.PBoxGranted.TabIndex = 4
        Me.PBoxGranted.TabStop = False
        Me.PBoxGranted.Visible = False
        '
        'LblBirth
        '
        Me.LblBirth.AutoSize = True
        Me.LblBirth.BackColor = System.Drawing.Color.Transparent
        Me.LblBirth.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBirth.Location = New System.Drawing.Point(159, 260)
        Me.LblBirth.Name = "LblBirth"
        Me.LblBirth.Size = New System.Drawing.Size(14, 14)
        Me.LblBirth.TabIndex = 5
        Me.LblBirth.Text = "0"
        '
        'RBtnM
        '
        Me.RBtnM.AutoSize = True
        Me.RBtnM.BackColor = System.Drawing.Color.Transparent
        Me.RBtnM.Location = New System.Drawing.Point(162, 274)
        Me.RBtnM.Name = "RBtnM"
        Me.RBtnM.Size = New System.Drawing.Size(34, 17)
        Me.RBtnM.TabIndex = 6
        Me.RBtnM.TabStop = True
        Me.RBtnM.Text = "M"
        Me.RBtnM.UseVisualStyleBackColor = False
        '
        'RBtnF
        '
        Me.RBtnF.AutoSize = True
        Me.RBtnF.BackColor = System.Drawing.Color.Transparent
        Me.RBtnF.Location = New System.Drawing.Point(202, 273)
        Me.RBtnF.Name = "RBtnF"
        Me.RBtnF.Size = New System.Drawing.Size(31, 17)
        Me.RBtnF.TabIndex = 6
        Me.RBtnF.TabStop = True
        Me.RBtnF.Text = "F"
        Me.RBtnF.UseVisualStyleBackColor = False
        '
        'TboxName
        '
        Me.TboxName.Location = New System.Drawing.Point(160, 290)
        Me.TboxName.MaxLength = 15
        Me.TboxName.Name = "TboxName"
        Me.TboxName.Size = New System.Drawing.Size(100, 20)
        Me.TboxName.TabIndex = 7
        '
        'TimerContinue
        '
        '
        'LblInfo
        '
        Me.LblInfo.AutoSize = True
        Me.LblInfo.BackColor = System.Drawing.Color.Transparent
        Me.LblInfo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfo.Location = New System.Drawing.Point(159, 311)
        Me.LblInfo.MaximumSize = New System.Drawing.Size(91, 56)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(0, 14)
        Me.LblInfo.TabIndex = 5
        '
        'Passport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BackgroundImage = Global.Hangman.My.Resources.Resources.Passport
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(300, 461)
        Me.Controls.Add(Me.TboxName)
        Me.Controls.Add(Me.RBtnF)
        Me.Controls.Add(Me.RBtnM)
        Me.Controls.Add(Me.LblInfo)
        Me.Controls.Add(Me.LblBirth)
        Me.Controls.Add(Me.PBoxGranted)
        Me.Controls.Add(Me.BtnChangeFace)
        Me.Controls.Add(Me.PBoxFace)
        Me.Controls.Add(Me.BtnContinue)
        Me.Controls.Add(Me.LblInstructions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Passport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Passport"
        CType(Me.PBoxFace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBoxGranted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblInstructions As System.Windows.Forms.Label
    Friend WithEvents BtnContinue As System.Windows.Forms.Button
    Friend WithEvents PBoxFace As System.Windows.Forms.PictureBox
    Friend WithEvents BtnChangeFace As System.Windows.Forms.Button
    Friend WithEvents PBoxGranted As System.Windows.Forms.PictureBox
    Friend WithEvents LblBirth As System.Windows.Forms.Label
    Friend WithEvents RBtnM As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnF As System.Windows.Forms.RadioButton
    Friend WithEvents TboxName As System.Windows.Forms.TextBox
    Friend WithEvents TimerContinue As System.Windows.Forms.Timer
    Friend WithEvents LblInfo As System.Windows.Forms.Label
End Class
