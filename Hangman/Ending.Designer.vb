<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ending
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ending))
        Me.LblStats = New System.Windows.Forms.Label()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.BtnPlayAgain = New System.Windows.Forms.Button()
        Me.BtnMainMenu = New System.Windows.Forms.Button()
        Me.PBoxLogo = New System.Windows.Forms.PictureBox()
        Me.TimerLetterAppear = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblStats
        '
        Me.LblStats.AutoSize = True
        Me.LblStats.BackColor = System.Drawing.Color.White
        Me.LblStats.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStats.Location = New System.Drawing.Point(40, 221)
        Me.LblStats.MaximumSize = New System.Drawing.Size(200, 60)
        Me.LblStats.MinimumSize = New System.Drawing.Size(200, 60)
        Me.LblStats.Name = "LblStats"
        Me.LblStats.Size = New System.Drawing.Size(200, 60)
        Me.LblStats.TabIndex = 0
        '
        'LblMessage
        '
        Me.LblMessage.AutoSize = True
        Me.LblMessage.BackColor = System.Drawing.Color.White
        Me.LblMessage.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(40, 51)
        Me.LblMessage.MaximumSize = New System.Drawing.Size(200, 170)
        Me.LblMessage.MinimumSize = New System.Drawing.Size(200, 170)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(200, 170)
        Me.LblMessage.TabIndex = 0
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.BackColor = System.Drawing.Color.White
        Me.LblTitle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(35, 9)
        Me.LblTitle.MaximumSize = New System.Drawing.Size(210, 32)
        Me.LblTitle.MinimumSize = New System.Drawing.Size(210, 32)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(210, 32)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "A Message from the Ministry of Information"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnPlayAgain
        '
        Me.BtnPlayAgain.Enabled = False
        Me.BtnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPlayAgain.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlayAgain.Location = New System.Drawing.Point(96, 336)
        Me.BtnPlayAgain.Name = "BtnPlayAgain"
        Me.BtnPlayAgain.Size = New System.Drawing.Size(89, 23)
        Me.BtnPlayAgain.TabIndex = 25
        Me.BtnPlayAgain.TabStop = False
        Me.BtnPlayAgain.Text = "Play again"
        Me.BtnPlayAgain.UseVisualStyleBackColor = True
        '
        'BtnMainMenu
        '
        Me.BtnMainMenu.Enabled = False
        Me.BtnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMainMenu.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMainMenu.Location = New System.Drawing.Point(99, 365)
        Me.BtnMainMenu.Name = "BtnMainMenu"
        Me.BtnMainMenu.Size = New System.Drawing.Size(83, 23)
        Me.BtnMainMenu.TabIndex = 24
        Me.BtnMainMenu.TabStop = False
        Me.BtnMainMenu.Text = "Main Menu"
        Me.BtnMainMenu.UseVisualStyleBackColor = True
        '
        'PBoxLogo
        '
        Me.PBoxLogo.BackColor = System.Drawing.Color.White
        Me.PBoxLogo.BackgroundImage = Global.Hangman.My.Resources.Resources.EigthNote
        Me.PBoxLogo.Location = New System.Drawing.Point(120, 284)
        Me.PBoxLogo.Name = "PBoxLogo"
        Me.PBoxLogo.Size = New System.Drawing.Size(35, 38)
        Me.PBoxLogo.TabIndex = 2
        Me.PBoxLogo.TabStop = False
        '
        'TimerLetterAppear
        '
        Me.TimerLetterAppear.Interval = 20
        '
        'Ending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(280, 400)
        Me.Controls.Add(Me.BtnPlayAgain)
        Me.Controls.Add(Me.BtnMainMenu)
        Me.Controls.Add(Me.PBoxLogo)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.LblStats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ending"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ending"
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        CType(Me.PBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblStats As System.Windows.Forms.Label
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPlayAgain As System.Windows.Forms.Button
    Friend WithEvents BtnMainMenu As System.Windows.Forms.Button
    Friend WithEvents TimerLetterAppear As System.Windows.Forms.Timer
End Class
