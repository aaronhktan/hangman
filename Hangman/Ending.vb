'Created by Aaron Tan
'Code written sometime in 2015
'Licensed under the GNU Public License 4.0
'Enjoy the game!

Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System
Imports System.IO

Public Class Ending
    Dim LetterTicks As Integer 'Variable for timer
    Dim StringGovernment As String 'String for scenarios
    Dim StringDeath As String
    Dim CitationDeath As String
    Dim StringDeath2 As String
    Dim StringSONG As String
    Dim Stats As String 'String for stats

    Private Sub Ending_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Stops any previous audio
        My.Computer.Audio.Stop()

        'Reads for info
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim Information() As String = File.ReadAllLines(myPath & "\Level.txt")
        Story.StoryPoint = Information(0)
        Story.Helped = Information(1)
        Story.TotalUnHelped = Information(2)
        Story.TotalTime = Information(3)
        Story.TotalCorrect = Information(4)
        Stats = "During this game, you got " & Story.TotalCorrect & " letters correct, taking a total of " _
                & Story.TotalTime & " seconds."

        'Sets things based on outcome of story
        If Story.TotalUnHelped = 3 Or Story.TotalUnHelped = 2 Or Story.TotalIncorrect = 5 Then

            'Set background color
            Me.BackColor = Color.Gray
            LblTitle.BackColor = Color.Gray
            LblMessage.BackColor = Color.Gray
            LblStats.BackColor = Color.Gray
            With PBoxLogo
                .BackColor = Color.Gray
                .BackgroundImage = My.Resources.MinistryOfAdmissionSeal
                .Size = New Size(35, 35)
                .Location = New Point(125, 280)
            End With

            'Sets text
            LblTitle.Text = "A Message from the Ministry of Information"
            StringGovernment = "The insurgent group SONG has been crushed. Your audit reveals that you have were associated with this terrorist group. " _
                & "It appears you did not help them. The Ministry thanks you for your support of the Gruschnachti government." & vbCrLf & vbCrLf _
                & "Glory to Grushnacht."
            StringDeath = "Your audit reveals that you have letters from the terrorist group SONG in your possession. " _
                & vbCrLf & vbCrLf & "Association with terrorist groups is forbidden." & vbCrLf & "You have been sentenced to death." _
                & vbCrLf & vbCrLf & "Glory to Gruschnacht."
            CitationDeath = "You have exceeded the maximum allowed number of 5 citations set by the the Ministry of Information. " _
                & vbCrLf & vbCrLf & "The government of Gruschnacht does not forgive." & vbCrLf & vbCrLf & "You have been sentenced to death."

            'Plays music if music is on
            If Story.Music Then
                My.Computer.Audio.Play(My.Resources.Death, AudioPlayMode.BackgroundLoop)
            End If

        ElseIf Story.TotalUnHelped = 1 Or Story.TotalUnHelped = 0 Then

            'Set background color
            Me.BackColor = Color.White
            LblTitle.BackColor = Color.White
            LblMessage.BackColor = Color.White
            LblStats.BackColor = Color.White
            With PBoxLogo
                .BackColor = Color.Blue
                .BackgroundImage = My.Resources.EigthNote
                .BackgroundImageLayout = ImageLayout.Stretch
                .Size = New Size(50, 50)
                .Location = New Point(125, 270)
            End With

            'Sets string to show
            LblTitle.Text = "A Message from SONG"
            StringDeath2 = "You failed to help us overthrow the government. Those loyal to the Gruschnachti government cannot be tolerated." _
                & vbCrLf & vbCrLf & "You could have built a new government with us." & vbCrLf & vbCrLf & "You will be confined " _
                & "to a maximum security prison."
            StringSONG = "SONG thanks you for being a member of the revolution." _
                & vbCrLf & vbCrLf & "The old corrupt government has been removed." & vbCrLf & vbCrLf & "It is time to celebrate " _
                & "our newfound freedoms." & vbCrLf & vbCrLf & "Glory to the New Gruschnacht!"

            'Plays different music
            If Story.TotalUnHelped = 0 Then
                If Story.Music Then
                    My.Computer.Audio.Play(My.Resources.Victory, AudioPlayMode.BackgroundLoop)
                End If
            Else
                If Story.Music Then
                    My.Computer.Audio.Play(My.Resources.Death, AudioPlayMode.BackgroundLoop)
                End If
            End If
        End If

        'Starts timer to show letters
        TimerLetterAppear.Start()

    End Sub

    'Returns user to first level
    Private Sub BtnPlayAgain_Click(sender As Object, e As EventArgs) Handles BtnPlayAgain.Click

        'Resets information
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim data As String() = {1, 0, 0, 0, 0, 0, "", 0}
        File.WriteAllLines(myPath & "\Level.txt", data)
        Dim FirstTimes As String() = {"Yes", ""}
        File.WriteAllLines(myPath & "\FirstTime.Txt", FirstTimes)
        My.Computer.Audio.Stop()
        Story.Close()
        Story.Show()
        Me.Close()

    End Sub

    'Animates characters
    Private Sub TimerLetterAppear_Tick(sender As Object, e As EventArgs) Handles TimerLetterAppear.Tick

        'Reads for outcome
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim Information() As String = File.ReadAllLines(myPath & "\Level.txt")
        Story.TotalUnHelped = Information(2)
        Story.TotalIncorrect = Information(7)

        'Animates based on outcome
        LetterTicks += 1
        If Story.TotalIncorrect = 5 Then
            LblMessage.Text &= Mid(CitationDeath, LetterTicks, 1)
            If LblMessage.Text = CitationDeath Then
                TimerLetterAppear.Stop()
                BtnMainMenu.Enabled = True
                BtnPlayAgain.Enabled = True
            End If
        Else
            Select Case Story.TotalUnHelped
                Case 3
                    LblMessage.Text &= Mid(StringGovernment, LetterTicks, 1)
                    If LblMessage.Text = StringGovernment Then
                        TimerLetterAppear.Stop()
                        BtnMainMenu.Enabled = True
                        BtnPlayAgain.Enabled = True
                    End If
                Case 2
                    LblMessage.Text &= Mid(StringDeath, LetterTicks, 1)
                    If LblMessage.Text = StringDeath Then
                        TimerLetterAppear.Stop()
                        BtnMainMenu.Enabled = True
                        BtnPlayAgain.Enabled = True
                    End If
                Case 1
                    LblMessage.Text &= Mid(StringDeath2, LetterTicks, 1)
                    If LblMessage.Text = StringDeath2 Then
                        TimerLetterAppear.Stop()
                        BtnMainMenu.Enabled = True
                        BtnPlayAgain.Enabled = True
                    End If
                Case 0
                    LblMessage.Text &= Mid(StringSONG, LetterTicks, 1)
                    If LblMessage.Text = StringSONG Then
                        TimerLetterAppear.Stop()
                        BtnMainMenu.Enabled = True
                        BtnPlayAgain.Enabled = True
                    End If
            End Select
        End If

        LblStats.Text &= Mid(Stats, LetterTicks, 1)

    End Sub

    'Returns user to main menu
    Private Sub BtnMainMenu_Click(sender As Object, e As EventArgs) Handles BtnMainMenu.Click

        'Resets stats and game
        My.Computer.Audio.Stop()
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim data As String() = {1, 0, 0, 0, 0, 0, "", 0}
        File.WriteAllLines(myPath & "\Level.txt", data)
        Dim FirstTimes As String() = {"Yes", ""}
        File.WriteAllLines(myPath & "\FirstTime.Txt", FirstTimes)
        Story.Close()
        MainMenu.Dispose()
        MainMenu.Show()
        Me.Close()

    End Sub
End Class