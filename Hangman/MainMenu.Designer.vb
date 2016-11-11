<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.LblStory = New System.Windows.Forms.Label()
        Me.LblEndless = New System.Windows.Forms.Label()
        Me.LblByline = New System.Windows.Forms.Label()
        Me.TimerLabelShow = New System.Windows.Forms.Timer(Me.components)
        Me.LblSettings = New System.Windows.Forms.Label()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.LblAbout = New System.Windows.Forms.Label()
        Me.LblModes = New System.Windows.Forms.Label()
        Me.LblOther = New System.Windows.Forms.Label()
        Me.LblMore = New System.Windows.Forms.Label()
        Me.LblMinimize = New System.Windows.Forms.Label()
        Me.LblClose = New System.Windows.Forms.Label()
        Me.LblInstruct = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblTitle.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(136, 24)
        Me.LblTitle.MinimumSize = New System.Drawing.Size(450, 50)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(450, 50)
        Me.LblTitle.TabIndex = 2
        Me.LblTitle.Text = "Gruschnacht Times"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblTitle.UseCompatibleTextRendering = True
        '
        'LblStory
        '
        Me.LblStory.AutoSize = True
        Me.LblStory.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblStory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblStory.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStory.Location = New System.Drawing.Point(34, 166)
        Me.LblStory.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblStory.MinimumSize = New System.Drawing.Size(142, 42)
        Me.LblStory.Name = "LblStory"
        Me.LblStory.Size = New System.Drawing.Size(142, 42)
        Me.LblStory.TabIndex = 4
        Me.LblStory.Text = "Story Mode" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ">"
        Me.LblStory.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'LblEndless
        '
        Me.LblEndless.AutoSize = True
        Me.LblEndless.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblEndless.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblEndless.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndless.Location = New System.Drawing.Point(204, 166)
        Me.LblEndless.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblEndless.Name = "LblEndless"
        Me.LblEndless.Size = New System.Drawing.Size(142, 42)
        Me.LblEndless.TabIndex = 4
        Me.LblEndless.Text = "Endless Mode >"
        Me.LblEndless.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblByline
        '
        Me.LblByline.AutoSize = True
        Me.LblByline.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblByline.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblByline.Location = New System.Drawing.Point(291, 86)
        Me.LblByline.Name = "LblByline"
        Me.LblByline.Size = New System.Drawing.Size(140, 14)
        Me.LblByline.TabIndex = 5
        Me.LblByline.Text = "A game by Aaron Tan"
        '
        'TimerLabelShow
        '
        Me.TimerLabelShow.Interval = 400
        '
        'LblSettings
        '
        Me.LblSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblSettings.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSettings.Location = New System.Drawing.Point(381, 167)
        Me.LblSettings.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblSettings.Name = "LblSettings"
        Me.LblSettings.Size = New System.Drawing.Size(120, 21)
        Me.LblSettings.TabIndex = 4
        Me.LblSettings.Text = "Settings >"
        Me.LblSettings.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblHelp
        '
        Me.LblHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblHelp.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHelp.Location = New System.Drawing.Point(381, 212)
        Me.LblHelp.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(120, 21)
        Me.LblHelp.TabIndex = 4
        Me.LblHelp.Text = "Help >"
        Me.LblHelp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblAbout
        '
        Me.LblAbout.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblAbout.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAbout.Location = New System.Drawing.Point(381, 256)
        Me.LblAbout.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblAbout.Name = "LblAbout"
        Me.LblAbout.Size = New System.Drawing.Size(120, 21)
        Me.LblAbout.TabIndex = 4
        Me.LblAbout.Text = "About >"
        Me.LblAbout.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblModes
        '
        Me.LblModes.AutoSize = True
        Me.LblModes.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblModes.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblModes.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModes.Location = New System.Drawing.Point(34, 125)
        Me.LblModes.Name = "LblModes"
        Me.LblModes.Size = New System.Drawing.Size(153, 22)
        Me.LblModes.TabIndex = 4
        Me.LblModes.Text = "Game Modes..."
        '
        'LblOther
        '
        Me.LblOther.AutoSize = True
        Me.LblOther.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblOther.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblOther.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOther.Location = New System.Drawing.Point(367, 125)
        Me.LblOther.Name = "LblOther"
        Me.LblOther.Size = New System.Drawing.Size(98, 22)
        Me.LblOther.TabIndex = 4
        Me.LblOther.Text = "Other..."
        '
        'LblMore
        '
        Me.LblMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblMore.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMore.Location = New System.Drawing.Point(381, 296)
        Me.LblMore.MaximumSize = New System.Drawing.Size(150, 42)
        Me.LblMore.Name = "LblMore"
        Me.LblMore.Size = New System.Drawing.Size(120, 21)
        Me.LblMore.TabIndex = 4
        Me.LblMore.Text = "More >"
        Me.LblMore.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblMinimize
        '
        Me.LblMinimize.AutoSize = True
        Me.LblMinimize.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblMinimize.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMinimize.Location = New System.Drawing.Point(53, 86)
        Me.LblMinimize.Name = "LblMinimize"
        Me.LblMinimize.Size = New System.Drawing.Size(28, 14)
        Me.LblMinimize.TabIndex = 27
        Me.LblMinimize.Text = "[-]"
        '
        'LblClose
        '
        Me.LblClose.AutoSize = True
        Me.LblClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblClose.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClose.Location = New System.Drawing.Point(19, 86)
        Me.LblClose.Name = "LblClose"
        Me.LblClose.Size = New System.Drawing.Size(28, 14)
        Me.LblClose.TabIndex = 28
        Me.LblClose.Text = "[X]"
        '
        'LblInstruct
        '
        Me.LblInstruct.AutoSize = True
        Me.LblInstruct.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LblInstruct.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstruct.Location = New System.Drawing.Point(400, 202)
        Me.LblInstruct.MaximumSize = New System.Drawing.Size(100, 100)
        Me.LblInstruct.Name = "LblInstruct"
        Me.LblInstruct.Size = New System.Drawing.Size(98, 98)
        Me.LblInstruct.TabIndex = 30
        Me.LblInstruct.Text = "The government of Grushnacht does not give help. You have been warned."
        Me.LblInstruct.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblInstruct.Visible = False
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Hangman.My.Resources.Resources.Newspaper_Template
        Me.ClientSize = New System.Drawing.Size(730, 438)
        Me.Controls.Add(Me.LblMinimize)
        Me.Controls.Add(Me.LblClose)
        Me.Controls.Add(Me.LblByline)
        Me.Controls.Add(Me.LblMore)
        Me.Controls.Add(Me.LblAbout)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.LblSettings)
        Me.Controls.Add(Me.LblEndless)
        Me.Controls.Add(Me.LblOther)
        Me.Controls.Add(Me.LblModes)
        Me.Controls.Add(Me.LblStory)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.LblInstruct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents LblStory As System.Windows.Forms.Label
    Friend WithEvents LblEndless As System.Windows.Forms.Label
    Friend WithEvents LblByline As System.Windows.Forms.Label
    Friend WithEvents TimerLabelShow As System.Windows.Forms.Timer
    Friend WithEvents LblSettings As System.Windows.Forms.Label
    Friend WithEvents LblHelp As System.Windows.Forms.Label
    Friend WithEvents LblAbout As System.Windows.Forms.Label
    Friend WithEvents LblModes As System.Windows.Forms.Label
    Friend WithEvents LblOther As System.Windows.Forms.Label
    Friend WithEvents LblMore As System.Windows.Forms.Label
    Friend WithEvents LblMinimize As System.Windows.Forms.Label
    Friend WithEvents LblClose As System.Windows.Forms.Label
    Friend WithEvents LblInstruct As System.Windows.Forms.Label
End Class
