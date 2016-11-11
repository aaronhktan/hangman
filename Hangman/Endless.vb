'Created by Aaron Tan
'Code written sometime in 2015
'Licensed under the GNU Public License 4.0
'Enjoy the game!

Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System
Imports System.IO

Public Class Endless
    Dim PBoxCites(20) As PictureBox 'Picturebox for citation when getting stuff wrong
    Dim LblCites(20) As Label 'Label for picturebox text
    Dim LblCiteTitles(20) As Label 'Label for picturebox text
    Dim LblLetters(20) As Label 'Label for picturebox letters
    Dim Words(49) As String 'Array to hold randomly generated words
    Dim WordNum As Integer 'Which word?
    Dim HintNum As Integer 'Which hint?
    Dim Guessed As Integer 'Total number of guessed letters
    Dim Letters As String 'Holds all incorrect letters
    Dim Correct As Integer 'Letters guessed correctly
    Dim Incorrect As Integer 'Letters guesssed incorrectly
    Dim Done As Boolean 'Whether is done checking for correct letters
    Dim Solved As Integer 'Number of solved words
    Dim Percent As Integer 'Percentage of correctly guessed letters
    Dim Clues As Integer = 10 'Number of hints
    Dim Lives As Integer = 15 'Number of lives left

#Region "FormDrag"
    'Used to drag borderless forms
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

    Private Sub Endless_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblTitle.Font = CustomFont.GetInstance(24, FontStyle.Bold)
        GenerateWord()
        Me.KeyPreview = True
    End Sub

    'Closes form
    Private Sub LblClose_Click(sender As Object, e As EventArgs) Handles LblClose.Click
        MainMenu.Close()
        Ending.Close()
        Passport.Close()
        Close()
    End Sub

    'Minimizes form
    Private Sub LblMinimize_Click(sender As Object, e As EventArgs) Handles LblMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub LabelBack_Click(sender As Object, e As EventArgs) Handles LblBack.Click
        MainMenu.Show()
        Story.AnswerWrite()
        Me.Close()
    End Sub

    'For keyboard press
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, _
        Button9.Click, Button8.Click, Button6.Click, Button7.Click, Button5.Click, Button4.Click, Button25.Click, _
        Button23.Click, Button26.Click, Button21.Click, Button24.Click, Button22.Click, Button20.Click, Button19.Click, _
        Button17.Click, Button15.Click, Button18.Click, Button13.Click, Button16.Click, Button11.Click, Button14.Click, _
        Button12.Click, Button10.Click

        sender.visible = False 'Makes button invisible
        Guessed += 1 'Adds a guess and shows in label
        LblGuessed.Text = "Guessed: " & Guessed

        For x = 1 To Len(LblWord.AccessibleDescription)
            If Mid(LblWord.AccessibleDescription, x, 1) Like sender.text Then 'User got it right!

                Mid(LblWord.Text, x, 1) = sender.text 'Replaces spaces with letter guessed
                If Done = False Then 'Adds correct if not already added
                    Correct += 1
                    LblCorrect.Text = "Correct: " & Correct
                    Done = True
                End If
                If LblWord.Text = LblWord.AccessibleDescription Then
                    BtnNext.Visible = True
                End If

            Else 'User got it wrong


                'If it is the last label, then it adds one incorrect to counter.
                If Done = False And x = Len(LblWord.AccessibleDescription) Then

                    'Disables buttons for the duration of animation
                    For Each buttons As Button In Me.Controls.OfType(Of Button)()
                        buttons.Enabled = False
                    Next

                    'Adds an incorrect and subtracts a life
                    Incorrect += 1
                    LblIncorrect.Text = "Incorrect: " & Incorrect
                    Lives -= 1
                    LblLives.Text = "Lives: " & Lives

                    Done = True

                    'Adds incorrect letter to list
                    If Incorrect > 1 Then
                        Letters &= ", "
                    End If
                    Letters &= sender.text

                    If Lives <= 0 Then

                        YouDied()
                    Else
                        'Creates citation
                        CitationCreate()

                        'Starts timer for animation
                        TimerIncorrect.Start()
                    End If
                End If
            End If
        Next

        'Calculates percentage
        Percent = Int(Correct / Guessed * 100)
        LblPercent.Text = "Percentage: " & Percent & "%"

        Done = False

    End Sub

    'Allows user to press keys and enter in form
    Private Sub Key(ByVal sender As Object, ByVal KeyPress As System.Windows.Forms.KeyPressEventArgs) _
    Handles Me.KeyPress
        Select Case KeyPress.KeyChar
            Case ChrW(65), ChrW(97)
                Button11.PerformClick()
            Case ChrW(66), ChrW(98)
                Button24.PerformClick()
            Case ChrW(67), ChrW(99)
                Button22.PerformClick()
            Case ChrW(68), ChrW(100)
                Button13.PerformClick()
            Case ChrW(69), ChrW(101)
                Button3.PerformClick()
            Case ChrW(70), ChrW(102)
                Button14.PerformClick()
            Case ChrW(71), ChrW(103)
                Button15.PerformClick()
            Case ChrW(72), ChrW(104)
                Button16.PerformClick()
            Case ChrW(73), ChrW(105)
                Button8.PerformClick()
            Case ChrW(74), ChrW(106)
                Button17.PerformClick()
            Case ChrW(75), ChrW(107)
                Button18.PerformClick()
            Case ChrW(76), ChrW(108)
                Button19.PerformClick()
            Case ChrW(77), ChrW(109)
                Button26.PerformClick()
            Case ChrW(78), ChrW(110)
                Button25.PerformClick()
            Case ChrW(79), ChrW(111)
                Button9.PerformClick()
            Case ChrW(80), ChrW(112)
                Button10.PerformClick()
            Case ChrW(81), ChrW(113)
                Button1.PerformClick()
            Case ChrW(82), ChrW(114)
                Button4.PerformClick()
            Case ChrW(83), ChrW(115)
                Button12.PerformClick()
            Case ChrW(84), ChrW(116)
                Button5.PerformClick()
            Case ChrW(85), ChrW(117)
                Button7.PerformClick()
            Case ChrW(86), ChrW(118)
                Button23.PerformClick()
            Case ChrW(87), ChrW(119)
                Button2.PerformClick()
            Case ChrW(88), ChrW(120)
                Button21.PerformClick()
            Case ChrW(89), ChrW(121)
                Button6.PerformClick()
            Case ChrW(90), ChrW(122)
                Button20.PerformClick()
        End Select

        KeyPress.Handled = True

    End Sub

    'Generates word
    Private Sub GenerateWord()
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim SpecialWord() As String = File.ReadAllLines(myPath & "\Words.txt")
        WordNum = Int((File.ReadAllLines(myPath & "\Words.txt").Length) * Rnd())
        LblWord.AccessibleDescription = SpecialWord(WordNum)
        For Underscore = 1 To Len(LblWord.AccessibleDescription)
            LblWord.Text &= "-"
        Next
    End Sub

    Private Sub CitationCreate()
        'Creates new citation from "Ministry of Information"
        PBoxCites(Incorrect) = New System.Windows.Forms.PictureBox()
        Me.Controls.Add(Me.PBoxCites(Incorrect))
        With PBoxCites(Incorrect)
            .BringToFront()
            .BackgroundImage = Global.Hangman.My.Resources.Resources.MiniInfo
            .BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            .Location = New Point(741, 117)
            .Size = New Size(192, 192)
            .TabStop = False
            .Width = 192
            .Height = 192
        End With

        LblCites(Incorrect) = New Label
        Me.Controls.Add(Me.LblCites(Incorrect))
        With LblCites(Incorrect)
            .BringToFront()
            .BackColor = Color.FromArgb(236, 224, 215)
            .Location = New Point(796, 268)
            .Size = New Size(94, 14)
            .Text = "Infractions:"
            .TextAlign = System.Drawing.ContentAlignment.TopCenter
            .TabStop = False
        End With

        LblCiteTitles(Incorrect) = New Label
        Me.Controls.Add(Me.LblCiteTitles(Incorrect))
        With LblCiteTitles(Incorrect)
            .BringToFront()
            .BackColor = System.Drawing.Color.FromArgb(236, 224, 215)
            .Location = New Point(755, 125)
            .Size = New Size(168, 28)
            .TabStop = False
            .Text = "Citation from the " & Global.Microsoft.VisualBasic.ChrW(13) _
                & Global.Microsoft.VisualBasic.ChrW(10) & "Ministry of Information"
            .TextAlign = System.Drawing.ContentAlignment.TopCenter
        End With

        LblLetters(Incorrect) = New Label
        Me.Controls.Add(Me.LblLetters(Incorrect))
        With LblLetters(Incorrect)
            .BringToFront()
            .BackColor = System.Drawing.Color.FromArgb(236, 224, 215)
            .Location = New Point(755, 287)
            .MinimumSize = New Size(170, 14)
            .Size = New Size(140, 14)
            .TabStop = False
            .Text = Letters
            .TextAlign = System.Drawing.ContentAlignment.TopCenter
        End With

        Me.KeyPreview = True
    End Sub

    'Moves citation
    Dim Ticks As Integer
    Private Sub TimerIncorrect_Tick(sender As Object, e As EventArgs) Handles TimerIncorrect.Tick

        Me.KeyPreview = False
        Ticks += 1

        Select Case Ticks
            Case 1 To 30
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X - 2, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X - 2, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X - 2, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X - 2, LblLetters(Incorrect).Location.Y)
            Case 31 To 50
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X, LblLetters(Incorrect).Location.Y)
            Case 51 To 80
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X - 2, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X - 2, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X - 2, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X - 2, LblLetters(Incorrect).Location.Y)
            Case 81 To 100
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X, LblLetters(Incorrect).Location.Y)
            Case 101 To 120
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X - 2, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X - 2, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X - 2, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X - 2, LblLetters(Incorrect).Location.Y)
            Case 121 To 145
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X, LblLetters(Incorrect).Location.Y)
            Case 146 To 180
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X - 2, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X - 2, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X - 2, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X - 2, LblLetters(Incorrect).Location.Y)
            Case Else
                PBoxCites(Incorrect).Location = New Point(PBoxCites(Incorrect).Location.X, PBoxCites(Incorrect).Location.Y)
                LblCites(Incorrect).Location = New Point(LblCites(Incorrect).Location.X, LblCites(Incorrect).Location.Y)
                LblCiteTitles(Incorrect).Location = New Point(LblCiteTitles(Incorrect).Location.X, LblCiteTitles(Incorrect).Location.Y)
                LblLetters(Incorrect).Location = New Point(LblLetters(Incorrect).Location.X, LblLetters(Incorrect).Location.Y)
                TimerIncorrect.Stop()
                Ticks = 0
                For Each buttons As Button In Me.Controls.OfType(Of Button)()
                    buttons.Enabled = True
                Next
                If Incorrect > 1 Then
                    PBoxCites(Incorrect - 1).Dispose()
                    LblCites(Incorrect - 1).Dispose()
                    LblCiteTitles(Incorrect - 1).Dispose()
                    LblLetters(Incorrect - 1).Dispose()
                End If
                Me.KeyPreview = True
        End Select

    End Sub

    'Moves on to next word
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Solved += 1
        LblSolved.Text = "Solved: " & Solved
        LblWord.Text = ""
        LblPercent.Text = "Percentage: 100%"
        Me.Controls.Remove(PBoxCites(Incorrect))
        Me.Controls.Remove(LblCites(Incorrect))
        Me.Controls.Remove(LblCiteTitles(Incorrect))
        Me.Controls.Remove(LblLetters(Incorrect))
        LblHint.Text = ""
        LblHelp.Enabled = True
        Guessed = 0
        Incorrect = 0
        Correct = 0
        LblGuessed.Text = "Guessed: " & Guessed
        LblCorrect.Text = "Correct: " & Correct
        LblIncorrect.Text = "Incorrect: " & Incorrect
        Letters = ""
        GenerateWord()
        For Each Buttons As Button In Me.Controls.OfType(Of Button)()
            Buttons.Visible = True
        Next
        BtnNext.Visible = False
    End Sub

    'Provides a clue
    Private Sub LblHelp_Click(sender As Object, e As EventArgs) Handles LblHelp.Click

        LblHelp.Enabled = False
        If Clues <= 0 Then
            MsgBox("You've run out of clues!")
        Else
            Clues -= 1
            LblHints.Text = "Clues: " & Clues
            HintNum = Int(3 * Rnd())
            Select Case WordNum
                Case 0
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "A shot, fired. One last breath. Death."
                        Case 1
                            LblHint.Text = "Nighttime. Knife in the back. Death."
                        Case 3
                            LblHint.Text = "Blood. Fills your vision. Death."
                    End Select
                Case 1
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "They come. They hurt you."
                        Case 1
                            LblHint.Text = "Punches and kicks. Black eyes, sore body."
                        Case 3
                            LblHint.Text = "All directions. Body hurts."
                    End Select
                Case 2
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Brainwash. Slaves. Power."
                        Case 1
                            LblHint.Text = "Shift, Escape. Task Manager."
                        Case 3
                            LblHint.Text = "They have it. Over the population."
                    End Select
                Case 3
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Against them. Struggle."
                        Case 1
                            LblHint.Text = "Do not conform. Conformity is death."
                        Case 2
                            LblHint.Text = "Two groups, two ideologies. Overthrow."
                    End Select
                Case 4
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Not a utopia."
                        Case 1
                            LblHint.Text = "Bad, bad future."
                        Case 2
                            LblHint.Text = "They said... It shouldn't be. Not this way."
                    End Select
                Case 5
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "In history class. ISIS was one."
                        Case 1
                            LblHint.Text = "They say we are one."
                        Case 2
                            LblHint.Text = "Inpiring fear. Spreading paranoia."
                    End Select
                Case 6
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Buildings do it. So do governments."
                        Case 1
                            LblHint.Text = "Topple. It happens."
                        Case 2
                            LblHint.Text = "Can't support weight. Falls."
                    End Select
                Case 7
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Happened last week. No more life."
                        Case 1
                            LblHint.Text = "It was organized. Screams. Blood..."
                        Case 2
                            LblHint.Text = "Streets of blood. Dead."
                    End Select
                Case 8
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Electricity does this. My newspaper too."
                        Case 1
                            LblHint.Text = "Jaded. Heart color. Not red."
                        Case 2
                            LblHint.Text = "Before, rare. Now, often."
                    End Select
                Case 9
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Take it out. Cover it. Don't look."
                        Case 1
                            LblHint.Text = "Don't show. Black out. Unsafe."
                        Case 2
                            LblHint.Text = "Words to hide. Not to show."
                    End Select
                Case 10
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Destroyed property. Streets. Chaos."
                        Case 1
                            LblHint.Text = "Loud. Rebellion. Shots fired."
                        Case 2
                            LblHint.Text = "Shouts. Fires. People. Anger."
                    End Select
                Case 11
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Passport granted."
                        Case 1
                            LblHint.Text = "Gruschnachti. No longer alien."
                        Case 2
                            LblHint.Text = "Part of country. Person."
                    End Select
                Case 12
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Kill. Hurt. Tool."
                        Case 1
                            LblHint.Text = "Maim. Hurt. Object."
                        Case 2
                            LblHint.Text = "Destroy. Defend. Kill. Object."
                    End Select
                Case 13
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Cough. Fever. Sick."
                        Case 1
                            LblHint.Text = "Headache. Nosebleeds. Sick."
                        Case 2
                            LblHint.Text = "Dizzy. Tired. Unwell."
                    End Select
                Case 14
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Life terminated."
                        Case 1
                            LblHint.Text = "Light fades. Eyes close. Gone forever."
                        Case 2
                            LblHint.Text = "Mourn. Casket. Funeral."
                    End Select
                Case 15
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Deadly. Costly. Sometimes natural."
                        Case 1
                            LblHint.Text = "Bad occurrence. Not good. Very bad."
                        Case 2
                            LblHint.Text = "Flood. Earthquake. Eruptions."
                    End Select
                Case 16
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Sentence. No more life."
                        Case 1
                            LblHint.Text = "Firing squad. The ground, red. Painted by blood."
                        Case 2
                            LblHint.Text = "Electric chair. Treason."
                    End Select
                Case 17
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Describes before. No civilisation."
                        Case 1
                            LblHint.Text = "Primitive. Uncouth."
                        Case 2
                            LblHint.Text = "Uncivilised. Like before."
                    End Select
                Case 18
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "They say authoritarian. We say normal."
                        Case 1
                            LblHint.Text = "Government."
                        Case 2
                            LblHint.Text = "Style of rule. North Korea?"
                    End Select
                Case 19
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Glorious master."
                        Case 1
                            LblHint.Text = "He leads us. To victory. To riches."
                        Case 2
                            LblHint.Text = "All hail the great president."
                    End Select
                Case 20
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "PC Master race?"
                        Case 1
                            LblHint.Text = "Our country. Before the rebels."
                        Case 2
                            LblHint.Text = "Great and beautiful."
                    End Select
                Case 21
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Gnaws at stomach. Hurts."
                        Case 1
                            LblHint.Text = "No food. Pain."
                        Case 2
                            LblHint.Text = "So tired. Need food..."
                    End Select
                Case 22
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Eat human. Only way. Hunger compels."
                        Case 1
                            LblHint.Text = "Too weak. No energy. Need food...:"
                        Case 2
                            LblHint.Text = "Thin. Bones and skin. No food."
                    End Select
                Case 23
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Don't have."
                        Case 1
                            LblHint.Text = "Too poor."
                        Case 2
                            LblHint.Text = "Want, but cannot."
                    End Select
                Case 24
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "One person to another."
                        Case 1
                            LblHint.Text = "Infect. More and more."
                        Case 2
                            LblHint.Text = "Disperse over area. Bigger, and bigger."
                    End Select
                Case 25
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Infect. Living, or not?"
                        Case 1
                            LblHint.Text = "Sick. Mutate. Spread."
                        Case 2
                            LblHint.Text = "Infect. Mutate. Spread."
                    End Select
                Case 26
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Infect. Living. Reproduce."
                        Case 1
                            LblHint.Text = "Disease. Suffering. Little cause."
                        Case 2
                            LblHint.Text = "Spread. Infect. Unicellular."
                    End Select
                Case 27
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Sick. Hacking out blood. Bitter."
                        Case 1
                            LblHint.Text = "Clears throat. Doesn't work."
                        Case 2
                            LblHint.Text = "Ahem."
                    End Select
                Case 28
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Runny nose. Expel air."
                        Case 1
                            LblHint.Text = "Nose itches. Eyes close. Expels air."
                        Case 2
                            LblHint.Text = "Like coughing, but hurts more."
                    End Select
                Case 29
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Gash in skin. Red comes out."
                        Case 1
                            LblHint.Text = "Nose broken. Liquid sprays."
                        Case 2
                            LblHint.Text = "Scarlet exits body. Pain."
                    End Select
                Case 30
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Bang. Light. Shouts. Screams."
                        Case 1
                            LblHint.Text = "It's loud. Red appears. Guts everywhere."
                        Case 2
                            LblHint.Text = "Fire. Bullet. Pain."
                    End Select
                Case 31
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Loud. Repeated. Bang."
                        Case 1
                            LblHint.Text = "Staccato bangs. Screams. Despair."
                        Case 2
                            LblHint.Text = "Repeated. Loud. Blood."
                    End Select
                Case 32
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Weapons. Immediate pain. Blood."
                        Case 1
                            LblHint.Text = "Bang. World goes dark."
                        Case 2
                            LblHint.Text = "Black. Sleek. Scary."
                    End Select
                Case 33
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Arms, of combustion."
                        Case 1
                            LblHint.Text = "It hurts. When it fires."
                        Case 2
                            LblHint.Text = "Fires. Causes death."
                    End Select
                Case 34
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Electric weapon."
                        Case 1
                            LblHint.Text = "Its use is... shocking."
                        Case 2
                            LblHint.Text = "120 volts can kill!"
                    End Select
                Case 35
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Blood samples and photo ID required."
                        Case 1
                            LblHint.Text = "Keep track of the population."
                        Case 2
                            LblHint.Text = "Demographics."
                    End Select
                Case 36
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Underground movement. Against the government."
                        Case 1
                            LblHint.Text = "Revolutionin'."
                        Case 2
                            LblHint.Text = "The government will fall."
                    End Select
                Case 37
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "We rise against tyranny."
                        Case 1
                            LblHint.Text = "Rise up and fight."
                        Case 2
                            LblHint.Text = "Do not obey. Fight."
                    End Select
                Case 38
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "They said work. I said no."
                        Case 1
                            LblHint.Text = "Refused to work. Demanded more."
                        Case 2
                            LblHint.Text = "Need higher salary. Stopped work."
                    End Select
                Case 39
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Place of despair."
                        Case 1
                            LblHint.Text = "Destitution. Poverty. Location."
                        Case 2
                            LblHint.Text = "Anguish lives here. Despair."
                    End Select
                Case 40
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Overthrow. Unseat."
                        Case 1
                            LblHint.Text = "Remove the head. The rest follows."
                        Case 2
                            LblHint.Text = "Topple the leader."
                    End Select
                Case 41
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "The bodies press. Sweaty, stinky. Gathering."
                        Case 1
                            LblHint.Text = "Throngs gather. Many peoeple."
                        Case 2
                            LblHint.Text = "The stench comes. Along with peoople."
                    End Select
                Case 42
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "It's sharp. Pierces my skin. I scream."
                        Case 1
                            LblHint.Text = "Gentle caress... Sharpened metal. Scarlet flows."
                        Case 2
                            LblHint.Text = "Kitchen. But also weapon."
                    End Select
                Case 43
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Explosion. Rubble. Screams."
                        Case 1
                            LblHint.Text = "Explosion. Body parts everywhere."
                        Case 2
                            LblHint.Text = "Deafening. Fire. Collapse."
                    End Select
                Case 44
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Future. Strategize."
                        Case 1
                            LblHint.Text = "Thoughts for future. If there is one."
                        Case 2
                            LblHint.Text = "Ideas for later."
                    End Select
                Case 45
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Contructed. Years pass. Gone."
                        Case 1
                            LblHint.Text = "I CAME IN ON A WRECKING BALL..."
                        Case 2
                            LblHint.Text = "Building is hard. This is easy."
                    End Select
                Case 46
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "All that's left. Broken bits. Abandoned pieces."
                        Case 1
                            LblHint.Text = "After the war. No more buildings. Only this."
                        Case 2
                            LblHint.Text = "It was destroyed. I saw only this."
                    End Select
                Case 47
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Rage, rage against the dying of the light."
                        Case 1
                            LblHint.Text = "Physical might. Determines outcome."
                        Case 2
                            LblHint.Text = "Lost one. Black eye. Body sore."
                    End Select
                Case 48
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Needed something. Took it. No money."
                        Case 1
                            LblHint.Text = "Wanted it. Didn't pay."
                        Case 2
                            LblHint.Text = "Too poor. Need medicine. Stole it."
                    End Select
                Case 49
                    Select Case HintNum
                        Case 0
                            LblHint.Text = "Working class. Support the rich and lazy."
                        Case 1
                            LblHint.Text = "We worked. We toiled away."
                        Case 2
                            LblHint.Text = "Not middle class. Working class."
                    End Select
                Case Else
                    MsgBox("Something went wrong! Oh no! :(")
            End Select
        End If

        Me.KeyPreview = True
    End Sub

    'Death condition
    Private Sub YouDied()
        Dim LblDead As New Label
        Me.Controls.Add(LblDead)
        With LblDead
            .AutoSize = True
            .BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(220, Byte), Integer))
            .Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .Location = New System.Drawing.Point(189, 127)
            .Size = New System.Drawing.Size(311, 39)
            .TabIndex = 57
            .Text = "You have died."
        End With
        LblHelp.Visible = False
        LblWord.Text = "You solved " & Solved & " words."
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim HighScores() As String = File.ReadAllLines(myPath & "\HighScore.txt")
        If Solved > HighScores(0) Then
            LblHint.Text = "New high score! It's now: " & Solved & "."
            HighScores(0) = Solved
            File.WriteAllLines(myPath & "\HighScore.txt", HighScores)
        Else
            LblHint.Text = "The high score is " & HighScores(0) & "."
        End If
    End Sub
End Class