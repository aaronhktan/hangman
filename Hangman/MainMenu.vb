'Created by Aaron Tan
'Code written sometime in 2015
'Licensed under the GNU Public License 4.0
'Enjoy the game!

Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System
Imports System.IO

Public Class MainMenu
    Dim Labels(5) As Label 'Labels for first column
    Dim Labels2(8) As Label 'Labels for second column
    Dim Labels3(4) As Label 'Labels for third column
    Dim Labels4(7) As Label 'Labels for fourth column
    Dim Labels5(0) As Label 'Laels for fifth column
    Dim SpecialLabel(7) As Integer 'Special labels
    Dim LetterShow As Integer 'For animation pf letters
    Dim SettingsClicked As Integer 'Keep track of settings
    Dim Reset As Integer 'Keep track of reset confirmation
    Public Music As Boolean = True 'Music setting

    'Used to drag borderless forms
#Region "FormDrag"
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
#End Region

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Randomize()

        'Sets title font
        LblTitle.Font = CustomFont.GetInstance(24, FontStyle.Bold)

        'Checks for labels
        LevelCheck()

        'Creates label for animation
        Label()

        'Plays music if setting is on
        If Music Then
            My.Computer.Audio.Play(My.Resources.Death, AudioPlayMode.BackgroundLoop)
        End If

    End Sub

    'Creates animated labels
    Private Sub Label()

        'Reads for words to use in labels
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim SpecialWord() As String = File.ReadAllLines(myPath & "\MainWords.txt")

        'Labels for first column
        SpecialLabel(0) = Int(4 * Rnd()) 'Determines which label is special
        For LabelQuantity = 0 To UBound(Labels)
            Labels(LabelQuantity) = New Label 'Creates new labels for each element in array
            Me.Controls.Add(Me.Labels(LabelQuantity))
            If LabelQuantity = SpecialLabel(0) Then 'Label is animated and has special properties
                With Labels(LabelQuantity)
                    .AccessibleDescription = SpecialWord(Int(15 * Rnd()))
                    .AutoSize = True
                    .BackColor = Color.Black
                    .BringToFront()
                    .ForeColor = Color.White
                    .Font = New Font("Lucida Console", 7)
                    .TabStop = False
                End With
                With Labels(LabelQuantity) 'Sets location
                    .Location = New Point(104 * Rnd() + 26, 219 + (Int(11 * Rnd()) * 12))
                End With
                For LabelLength = 0 To Len(Labels(LabelQuantity).AccessibleDescription) - 1 'Sets size
                    Labels(LabelQuantity).Text &= " "
                Next
            Else 'Label is not animated, and is normal
                With Labels(LabelQuantity)
                    .BackColor = Color.Black
                    .Size = New Size(Int(41 * Rnd()) + 40, 10)
                    .Location = New Point(Int(((186 - Labels(LabelQuantity).Width) - 25) * Rnd()) _
                                          + 26, 219 + (Int(11 * Rnd()) * 12))
                    .TabStop = False
                End With
            End If
        Next

        'Labels for second column
        SpecialLabel(1) = Int(7 * Rnd()) 'Determines which three labels are special
        SpecialLabel(2) = Int(7 * Rnd())
        SpecialLabel(3) = Int(7 * Rnd())
        For LabelQuantity = 0 To UBound(Labels2) 'Creates new labels
            Labels2(LabelQuantity) = New Label
            Me.Controls.Add(Me.Labels2(LabelQuantity))
            If LabelQuantity = SpecialLabel(1) Or LabelQuantity = SpecialLabel(2) Or _
                LabelQuantity = SpecialLabel(3) Then 'Sets special label properties
                With Labels2(LabelQuantity)
                    .AccessibleDescription = SpecialWord(Int(15 * Rnd()))
                    .AutoSize = True
                    .BackColor = Color.Black
                    .BringToFront()
                    .ForeColor = Color.White
                    .Font = New Font("Lucida Console", 7)
                    .TabStop = False
                End With
                With Labels2(LabelQuantity) 'Sets location
                    .Location = New Point(106 * Rnd() + 196, 219 + (Int(17 * Rnd()) * 12))
                End With
                For LabelLength = 0 To Len(Labels2(LabelQuantity).AccessibleDescription) - 1 'Sets spaces
                    Labels2(LabelQuantity).Text &= " "
                Next
            Else 'Label is normal, nothing special here
                With Labels2(LabelQuantity)
                    .BackColor = Color.Black
                    .Size = New Size(Int(41 * Rnd()) + 40, 10)
                    .Location = New Point(Int(((355 - Labels2(LabelQuantity).Width) - 195) * _
                                              Rnd()) + 196, 219 + (Int(17 * Rnd()) * 12))
                    .TabStop = False
                End With
            End If
        Next

        'Labels for third colomn
        SpecialLabel(4) = Int(1 * Rnd()) 'Determines special labels for third column
        For LabelQuantity = 0 To UBound(Labels3) 'Creates labels
            Labels3(LabelQuantity) = New Label
            Me.Controls.Add(Me.Labels3(LabelQuantity))
            If LabelQuantity = SpecialLabel(4) Then 'It's special!
                With Labels3(LabelQuantity)
                    .AccessibleDescription = SpecialWord(Int(15 * Rnd()))
                    .AutoSize = True
                    .BackColor = Color.Black
                    .BringToFront()
                    .ForeColor = Color.White
                    .Font = New Font("Lucida Console", 7)
                    .TabStop = False
                End With
                With Labels3(LabelQuantity)
                    .Location = New Point(102 * Rnd() + 367, 328 + (Int(8 * Rnd()) * 12))
                End With
                For LabelLength = 0 To Len(Labels3(LabelQuantity).AccessibleDescription) - 1
                    Labels3(LabelQuantity).Text &= " "
                Next
            Else 'It's not special
                With Labels3(LabelQuantity)
                    .BackColor = Color.Black
                    .Size = New Size(Int(41 * Rnd()) + 40, 10)
                    .Location = New Point(Int(((526 - Labels3(LabelQuantity).Width) - 366) * _
                                              Rnd()) + 367, 328 + (Int(8 * Rnd()) * 12))
                    .TabStop = False
                End With
            End If
        Next

        'Labels for fourth column
        SpecialLabel(5) = Int(6 * Rnd()) 'Determines three special labels for fourth column
        SpecialLabel(6) = Int(6 * Rnd())
        SpecialLabel(7) = Int(6 * Rnd())
        For LabelQuantity = 0 To UBound(Labels4) 'Creates labels
            Labels4(LabelQuantity) = New Label
            Me.Controls.Add(Me.Labels4(LabelQuantity))
            If LabelQuantity = SpecialLabel(5) Or LabelQuantity = SpecialLabel(6) Or _
                LabelQuantity = SpecialLabel(7) Then 'Label is special and has special properties
                With Labels4(LabelQuantity)
                    .AccessibleDescription = SpecialWord(Int(15 * Rnd()))
                    .AutoSize = True
                    .BackColor = Color.Black
                    .BringToFront()
                    .ForeColor = Color.White
                    .Font = New Font("Lucida Console", 7)
                    .TabStop = False
                End With
                With Labels4(LabelQuantity)
                    .Location = New Point(106 * Rnd() + 536, 118 + (Int(15 * Rnd()) * 12))
                End With
                For LabelLength = 0 To Len(Labels4(LabelQuantity).AccessibleDescription) - 1
                    Labels4(LabelQuantity).Text &= " "
                Next
            Else 'Label is not special and does not have special properties
                With Labels4(LabelQuantity)
                    .BackColor = Color.Black
                    .Size = New Size(Int(41 * Rnd()) + 40, 10)
                    .Location = New Point(Int(((696 - Labels4(LabelQuantity).Width) - 535) * _
                                              Rnd()) + 536, 118 + (Int(15 * Rnd()) * 12))
                End With
            End If
        Next

        'Creates labels for fifth column
        For LabelQuantity = 0 To UBound(Labels5) 'Creates labels, all of which are not special
            Labels5(LabelQuantity) = New Label
            Me.Controls.Add(Me.Labels5(LabelQuantity))
            With Labels5(LabelQuantity)
                .BackColor = Color.Black
                .Size = New Size(Int(41 * Rnd()) + 40, 10)
                .Location = New Point(Int(((696 - Labels5(LabelQuantity).Width) - 535) * _
                                          Rnd()) + 536, 327 + (Int(2 * Rnd()) * 12))
                .TabStop = False
            End With
        Next

        'Starts animation timer
        TimerLabelShow.Start()

    End Sub

    'Animates 'censored' labels on main menu
    Private Sub TimerLabelShow_Tick(sender As Object, e As EventArgs) Handles TimerLabelShow.Tick
        LetterShow += 1
        For Each Labeling As Label In Me.Controls.OfType(Of Label)()
            If Labeling.AccessibleDescription IsNot vbNullString And LetterShow <= _
                Len(Labeling.AccessibleDescription) Then 'Makes sure label is special by
                'checking whether it has an accessibledescription
                Mid(Labeling.Text, LetterShow, 1) = Mid(Labeling.AccessibleDescription, LetterShow, 1)
                Labeling.BringToFront()
            End If
        Next
        If LetterShow = 15 Then
            For Each Labeling As Label In Me.Controls.OfType(Of Label)() 'Keeps specific labels 
                'visible but hides everything else
                If Labeling.Name = "LblByline" Or Labeling.Name = "LblEndless" _
                    Or Labeling.Name = "LblStory" Or Labeling.Name = "LblTitle" _
                    Or Labeling.Name = "LblSettings" Or Labeling.Name = "LblHelp" _
                    Or Labeling.Name = "LblAbout" Or Labeling.Name = "LblModes" _
                    Or Labeling.Name = "LblOther" Or Labeling.Name = "LblMore" _
                    Or Labeling.Name = "LblCredits" Or Labeling.Name = "LblClose" _
                    Or Labeling.Name = "LblMinimize" Then
                    Labeling.Visible = True
                Else
                    Labeling.Visible = False
                End If
            Next
        ElseIf LetterShow = 16 Then 'Resets labels
            TimerLabelShow.Stop()
            LetterShow = 0
            If LblSettings.Text = "Help ▼" Or LblSettings.Text = "About ▼" Or LblSettings.Text = _
                "More ▼" Then
                LblSettings.Text = "Settings >"
                LblInstruct.Visible = False
                LblHelp.Text = "Help >"
                LblMore.Text = "More >"
                LblAbout.Text = "About >"
            End If
            Label()
        End If
    End Sub

    'Allows user to access Endless mode
    Private Sub LblEndless_Click(sender As Object, e As EventArgs) Handles LblEndless.Click
        Endless.Show()
        Me.Hide()
    End Sub

    'Sets colour when mouse is over label
    Private Sub LblEndless_Mouseenter(sender As Object, e As EventArgs) Handles LblEndless.MouseEnter, _
        LblStory.MouseEnter, LblSettings.MouseEnter, LblHelp.MouseEnter, LblAbout.MouseEnter, LblMore.MouseEnter
        sender.BackColor = Color.Gainsboro
    End Sub

    'Sets colour when mouse leaves label
    Private Sub LblEndless_Mouseleave(sender As Object, e As EventArgs) Handles LblEndless.MouseLeave, _
        LblStory.MouseLeave, LblSettings.MouseLeave, LblHelp.MouseLeave, LblAbout.MouseLeave, LblMore.MouseLeave
        sender.BackColor = Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
    End Sub

    'Opens story mode
    Private Sub LblStory_Click(sender As Object, e As EventArgs) Handles LblStory.Click
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim FirstTimes() = File.ReadAllLines(myPath & "\FirstTime.txt")
        Dim FirstTime As String
        FirstTime = FirstTimes(0)
        If FirstTime Like "Yes" Then
            Passport.Show()
        Else
            Story.Show()
        End If
        Me.Hide()
    End Sub

    'Shows settings
    Private Sub LblSettings_Click(sender As Object, e As EventArgs) Handles LblSettings.Click
        SettingsClicked += 1
        If LblSettings.Text = "Help ▼" Or LblSettings.Text = "About ▼" Or LblSettings.Text = "More ▼" Then
            SettingsClicked += 1
        End If
        If (SettingsClicked Mod 2) = 0 Then
            LblInstruct.Visible = False
            LblSettings.Text = "Settings >"
            LblHelp.Text = "Help >"
            LblMore.Text = "More >"
            LblAbout.Text = "About >"
            LblAbout.Visible = True
            LblHelp.Visible = True
            LblMore.Visible = True
        Else
            LblSettings.Text = "Settings ▼"
            If Music = True Then
                LblHelp.Text = "Music Off >"
            Else
                LblHelp.Text = "Music On >"
            End If
            LblMore.Text = "Reset >"
            LblAbout.Text = "Relaunch >"
        End If
    End Sub

    'Closes program
    Private Sub LblClose_Click(sender As Object, e As EventArgs) Handles LblClose.Click
        Close()
    End Sub

    'Minimizes program
    Private Sub LblMinimize_Click(sender As Object, e As EventArgs) Handles LblMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Shows stuff in button
    Private Sub LblMore_Click(sender As Object, e As EventArgs) Handles LblMore.Click
        If LblMore.Text = "More >" Then
            LblSettings.Text = "More ▼"
            LblAbout.Visible = False
            LblHelp.Visible = False
            LblMore.Visible = False
            LblInstruct.Visible = True
            LblInstruct.Text = "There is nothing more to discover."
        Else
            Reset += 1
            If Reset / 2 = 1 Then
                LblMore.Text = "Reset >"
                Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
                Dim data As String() = {1, 0, 0, 0, 0, 0, "", 0}
                File.WriteAllLines(myPath & "\Level.txt", data)
                Dim FirstTimes As String() = {"Yes", ""}
                File.WriteAllLines(myPath & "\FirstTime.Txt", FirstTimes)
                Dim HighScores As String() = {0}
                File.WriteAllLines(myPath & "\HighScore.Txt", HighScores)
                LevelCheck()
                MsgBox("You successfully reset everything!")
                Reset = 0
            Else
                LblMore.Text = "Sure?"
            End If
        End If
    End Sub

    'Checks for level; if is more than 1, modifies main menu accordingly
    Private Sub LevelCheck()
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim Information() As String = File.ReadAllLines(myPath & "\Level.txt")
        Story.StoryPoint = Information(0)
        If Story.StoryPoint <> 1 Then
            LblStory.Text = "Continue Story Mode >"
            LblStory.TextAlign = ContentAlignment.TopLeft
        Else
            LblStory.Text = "Story Mode" & vbCrLf & ">"
            LblStory.TextAlign = ContentAlignment.TopRight
        End If
    End Sub

    'Help button
    Private Sub LblHelp_Click(sender As Object, e As EventArgs) Handles LblHelp.Click
        If LblHelp.Text = "Help >" Then
            LblSettings.Text = "Help ▼"
            LblAbout.Visible = False
            LblHelp.Visible = False
            LblMore.Visible = False
            LblInstruct.Visible = True
            LblInstruct.Text = "The government of Grushnacht does not give help. You have been warned."
        ElseIf Music = True Then
            Music = False
            My.Computer.Audio.Stop()
            LblHelp.Text = "Music On >"
        Else
            Music = True
            My.Computer.Audio.Play(My.Resources.Death, AudioPlayMode.BackgroundLoop)
            LblHelp.Text = "Music Off >"
        End If
    End Sub

    'Credits/About
    Private Sub LblAbout_Click(sender As Object, e As EventArgs) Handles LblAbout.Click
        If LblAbout.Text = "About >" Then
            LblSettings.Text = "About ▼"
            LblAbout.Visible = False
            LblHelp.Visible = False
            LblMore.Visible = False
            LblInstruct.Visible = True
            LblInstruct.Text = "This game was made by Aaron Tan, with images and sound by Lucas Pope."
        Else
            Me.Hide()
            Me.Show()
        End If
    End Sub
End Class