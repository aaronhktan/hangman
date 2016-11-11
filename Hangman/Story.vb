Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System
Imports System.IO
Imports System.IO.StreamReader

Module CustomFont

    'Creates font holder to hold custom font
    Private FontCollect As PrivateFontCollection = Nothing

    Public ReadOnly Property GetInstance(ByVal Size As Single, _
                                         ByVal style As FontStyle) As Font
        Get
            'If this is the first time getting font, then it loads
            If FontCollect Is Nothing Then LoadFont()

            'Returns font based on size and style given
            Return New Font(FontCollect.Families(0), Size, style)
        End Get

    End Property

    Private Sub LoadFont()
        Try
            'Initializes font collection
            FontCollect = New PrivateFontCollection

            'Loads memory pointer for font
            Dim FontPointer As IntPtr = _
                Marshal.AllocCoTaskMem( _
                My.Resources.Hello.Length)

            'Copies data to memory location
            Marshal.Copy(My.Resources.Hello, _
                         0, FontPointer, _
                         My.Resources.Hello.Length)

            'Loads memory font into font collection
            FontCollect.AddMemoryFont(FontPointer, _
                               My.Resources.Hello.Length)

            'Frees unsafe memory
            Marshal.FreeCoTaskMem(FontPointer)

        Catch ex As Exception
            'ERROR LOADING FONT. HANDLE EXCEPTION HERE
        End Try

    End Sub

End Module

Public Class Story
    Dim Labels(10) As Label 'Labels for blacking stuff out
    Dim PBoxCites(5) As PictureBox 'Picturebox for citation when getting stuff wrong
    Dim LblCites(5) As Label 'Label for picturebox text
    Dim LblCiteTitles(5) As Label 'Label for picturebox text
    Dim LblLetters(5) As Label 'Label for picturebox letters
    Dim GroupMessage(10) As Label 'Letter from SONG or Government
    Dim GroupDismiss(10) As Button 'User interction with letter
    Dim GroupConsent(10) As Button 'User interaction wtih letter
    Dim GroupPictureBox(10) As PictureBox 'Logo with letter
    Dim FingerPrint As PictureBox 'Fingerprint fun!
    Public StoryPoint As String 'Determines location in story
    Dim Used As Integer 'Determines number of labels blacked out
    Dim Length As Integer 'Determines number of letters needed to beat level
    Dim Guessed As Integer 'Determines total number of guessed letters
    Dim Correct As Integer 'Determines number of correct letters in one level
    Public TotalCorrect As Integer 'Total number of correct letters
    Dim Incorrect As Integer 'Determines number of incorrect guesses
    Public TotalIncorrect As Integer 'Determines total number of incorrect guesses
    Public Letters As String 'String containing all incorrect letters guessed
    Dim Done As Boolean 'Determines whether to add an incorrect to counter
    Dim FormDrag As String 'Used for setting region
    Dim GroupNumber As Integer 'Used for cycling through letter
    Public Helped As String 'Used to determine stuff after user interaction
    Public TotalUnHelped As Integer 'Used for end scenario
    Dim Information() As String 'Used to read contents of text file
    Dim Dismissed As Boolean 'Used for note from SONG or government
    Dim FingerPrintTime As Integer 'Used for animating fingerprints
    Public TotalTime As Integer 'Used to see how long it took
    Public Music As Boolean 'Used for music

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Set custom font of labels
        LblTitle.Font = CustomFont.GetInstance(24, FontStyle.Bold)
        LblHeadline.Font = CustomFont.GetInstance(18, FontStyle.Bold)
        LblQuote.Font = CustomFont.GetInstance(11, FontStyle.Regular)
        LblStatTitle.Font = CustomFont.GetInstance(11, FontStyle.Regular)

        'Plays music
        If MainMenu.Music = True Then
            Music = True
            My.Computer.Audio.Play(My.Resources.Theme, AudioPlayMode.BackgroundLoop)
        End If

        Initialize()

        If Letters <> "" Then
            CitationCreate()
            TimerIncorrect.Start()
            For Each buttons As Button In Me.Controls.OfType(Of Button)()
                buttons.Enabled = False
            Next
        End If
        TimerTotalTime.Start()

    End Sub

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

    'Loads stuff based on level
    Public Sub Initialize()
        'Reads for Level, and resumes things based on text file
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim Information() As String = File.ReadAllLines(myPath & "\Level.txt")
        StoryPoint = Information(0)
        Helped = Information(1)
        TotalUnHelped = Information(2)
        TotalTime = Information(3)
        TotalCorrect = Information(4)
        Guessed = Information(5)
        Letters = Information(6)
        TotalIncorrect = Information(7)
        LblAttempts.Text = "Attempts: " & Guessed
        TimerTotalTime.Stop()
        TimerTotalTime.Start()
        Me.KeyPreview = True

        'Ends game if appropriate
        If TotalIncorrect = 5 Then
            Ending.Show()
            AnswerWrite()
            Me.Dispose()
        End If

        'Sets date in top right corner
        LblDate.Text = DateAdd(DateInterval.Day, StoryPoint - 1, Now.Date)

        'Sets text depending on point in story
        If StoryPoint Like 1 Then
            LblHeadline.Text = "Newspaper censoring begins"
            LblQuote.Text = "'For the safety of population', says Ministry of Info"
            LblArticle1.Text = "Beginning today, all newspapers and media will be censored. " _
                & "All words not deemed safe by the government will now be blacked out, or otherwise hidden. " _
                & "The government will 'assure the mental"
            LblArticle2.Text = "safety of its population', a spokesperson of the Ministry of " _
                & "Information said. They also stated that this was not a response to the execution " _
                & "of the suspected rebel leader last week, who led a failed uprising against the government."
            Used = 2
            Length = 11

        ElseIf StoryPoint Like 2 Then
            LblHeadline.Text = "Insurgent group reported"
            LblQuote.Text = "'Dangerous. Do not approach,' says Ministry of Security"
            LblArticle1.Text = "Reports of a second organized rebel group have been reported around the borders " _
                & "of our country. This group, naming themselves the 'Second Order of the New Gruschnacht', or SONG,"
            LblArticle2.Text = "appears to be fighting for a democratic government. They threaten the stability and " _
                & "peace that was only recently established, says a spokesperson. The government will immediately kill " _
                & "any persons found to have ties with this terrorist group."
            Used = 3
            Length = 14

            GroupCreate()
            GroupMessage(GroupNumber).Text = vbCrLf & "READ CAREFULLY BEFORE DISCARDING" & vbCrLf & vbCrLf & "The SONG beckons. Although you " _
                & "are deaf, you still hear it. The SONG awakens memories from " _
                & "a different era. Some view the SONG as terrible, but we see only beauty." & vbCrLf & vbCrLf _
                & "And we hope that you do as well."
            GroupDismiss(GroupNumber).Text = "OK?"

        ElseIf StoryPoint Like 3 Then
            LblHeadline.Text = "Food rations lowered!"
            LblQuote.Text = "'Less food for healthier bodies!'"
            LblArticle1.Text = "Food rations have been lowered  by the government, as stated in a press release yesterday. " _
                & "'This is the first phase of a push for a leaner, stronger population!', the Minister of Health stated."
            LblArticle2.Text = "stated. All persons purchasing more than the maximum allowed amount of food will be taken to " _
                & "re-education camps. This is the second time the rations have been lowered in six months, the first following an " _
                & "interruption of the food supply due to the terrorist group ONG."
            Used = 4
            Length = 13

        ElseIf StoryPoint Like 4 Then
            LblHeadline.Text = "Theft at Ministry of Information"
            LblQuote.Text = "'Has led to incorrect censoring'"
            LblArticle1.Text = "A recent theft has occurred at the Ministry of Information, leading to several letters being" _
                & "incorrectly censored. The Ministry of Information hopes to rectify this as"
            LblArticle2.Text = "soon as possible in order to assure the reinstatement of censorship as early as possible. Although " _
                & "no official details have come out, reports have stated that the group SONG is behind this theft. 'We apologize " _
                & "for any odd censoring until further notice,' a spokesperson said."
            GroupCreate()
            GroupMessage(GroupNumber).Text = vbCrLf & "The SONG has struck. The first step has been done." & vbCrLf & "Its melody was too powerful for the " _
                & "Ministry of Information to contain. We have struck where it was weakest!" & vbCrLf & vbCrLf & vbCrLf _
                & "But soon, we will need your help."
            GroupDismiss(GroupNumber).Text = "Cool."
            Used = 6
            Length = 5

        ElseIf StoryPoint = 5 Then
            LblHeadline.Text = "Census in progress"
            LblQuote.Text = "'Blood samples will be required'"
            LblArticle1.Text = "In an effort to keep track of the population, the government will be conducting a census. Blood samples, " _
                & "photo ID, and fingerprints will be required. Concerns have been"
            LblArticle2.Text = "raised over government spying, with the Prime Minister of Tanokane denouncing this as a 'power grab' by the " _
                & "Gruschnachti government. Denying all allegations, the government insists this will allow 'increased efficiency' in the judicial system."
            If Dismissed = False Then
                GroupCreate()
                GroupMessage(GroupNumber).BackColor = Color.Gray
                GroupMessage(GroupNumber).TextAlign = ContentAlignment.TopCenter
                GroupMessage(GroupNumber).Text = vbCrLf & vbCrLf & vbCrLf & "As an employee of the Ministry of Information, you have been called for an audit regarding any " _
                    & "activity concerning terrorist groups. If you have any information regarding the group, please give it to us immediately." _
                    & vbCrLf & vbCrLf & "Your audit has been scheduled for:" & vbCrLf & vbCrLf & DateAdd(DateInterval.Day, StoryPoint + 4, Now.Date)
                GroupDismiss(GroupNumber).Text = "Hide them."
                GroupDismiss(GroupNumber).TabStop = False
                GroupConsent(GroupNumber).Text = "Give the Ministry your letters."
                GroupConsent(GroupNumber).TabStop = False
            End If
            Used = 5
            Length = 15

        ElseIf StoryPoint = 6 Then
            LblHeadline.Text = "Measles Outbreak in Näargula"
            LblQuote.Text = "'Bio-weapon by terrorist group'"
            LblArticle1.Text = "A recent outbreak of measles  has been found in the province of Näargula, prompting officials to recommend additional " _
                & "sanitary measures. Healthcare workers have been in working tirelessly to"
            LblArticle2.Text = "prevent further cases. 'Our researchers are working on a vaccine,' a spokesperson stated. 'It will be given out when completed.' " _
                & "The group SONG is reportedly behind this use of bioweapons. Meanwhile, it is recommended report any disease  to the Ministry of Health."
            Used = 4
            Length = 17

        ElseIf StoryPoint = 7 Then
            If Helped Like True Then
                LblHeadline.Text = "Theft at Ministry of Health!"
                LblQuote.Text = "'Security Measures to be tightened'"
                LblArticle1.Text = "An undisclosed number of items has been stolen  from the headquarters of the Ministry of Health. The Minister of Health " _
                    & "blames SONG, decrying their 'barbaric ways'. Any individuals seen"
                LblArticle2.Text = "to appear suspicious should be reported at once to the Ministry of Information. Security has been tightened, with the " _
                    & "system now requiring a fingerprint scan . The Ministry of Health reminds the population to not trust SONG, and that they caused the " _
                    & "measles  pandemic."
                Used = 5
                Length = 14
            End If
            If Helped Like False Then
                LblHeadline.Text = "Attempted theft!"
                LblQuote.Text = "Perpetrators were killed, reports say"
                LblArticle1.Text = "An attempted break-in at the Ministry of Health yesterday night resulted in the deaths of all the perpetrators. Bearing the in" _
                    & "signia of the group SONG, it is believed that this was"
                LblArticle2.Text = "an attempt at an attack  on the great nation of Gruschnacht. Security measures have been tightened, with the system now requiring " _
                    & "a fingerprint scan . 'This attack shows how far SONG is willing to go in order to inspire terror,' a spokesperson said."
                Used = 4
                Length = 13
            End If

        ElseIf StoryPoint = 8 Then
            If Helped Like True Then
                LblHeadline.Text = "Minister of Information dead!"
                LblQuote.Text = "SONG agents found responsible"
                LblArticle1.Text = "The Minister of Information was found dead  at his home yesterday night, his body riddled with bullet  holes. A SONG eighth note  was " _
                    & "found on scene, leading investigators to"
                LblArticle2.Text = "believe that the group SONG was behind this brutal murder . On the note, it was written 'This begins a new day for Gruschnacht - one without " _
                    & "censorship.' Of course, the death of the Minister does not mean censorship programs die along with him, and will thus continue."
                Used = 6
                Length = 16
            Else 'Helped Like False
                LblHeadline.Text = "Minister of Info attacked!"
                LblQuote.Text = "SONG agents found responsible"
                LblArticle1.Text = "The Minister of Information was attacked  at his home yesterday night, but was not harmed  due to his personal bodyguards . They " _
                    & "have been credited for saving his life."
                LblArticle2.Text = "The additional security is also credited with foiling this plot to kill the Minister; as the fingerprint system did not allow them to " _
                    & "access the interior of the Minister's home. The censorship program remains unaffected, and will continue until further notice."
                Used = 4
                Length = 19
            End If

        ElseIf StoryPoint = 9 Then
            LblHeadline.Text = "Weapons confiscated!"
            LblQuote.Text = "People don't kill people, guns kill people!"
            LblArticle1.Text = "In response to the murder  two days ago, all citizens must dispose of all weapons, including guns , knives , and forks, by turning them " _
                & "in to the nearest government centre."
            LblArticle2.Text = "'By removing weapons from the population, we assure the lowest crime  rate possible,' a spokesperson said. This move is intended to take " _
                & "power away from SONG, preventing them from further attacks . Any persons with weapons will be severely punished with internment and death ."
            Used = 9
            Length = 19

        ElseIf StoryPoint = 10 Then 'Reached end of story, time for another form!
            Me.Hide()
            Ending.Show()
            Ending.BringToFront()
            Me.Close()
        Else 'Something has gone wrong! Oh no!
            MsgBox("Something went wrong. Try doing some black magic to make it work again.")
        End If

        LabelGeneration()

    End Sub

    'Generates labels
    Private Sub LabelGeneration()
        'Creates labels for each level depending on number of labels used
        For LabelQuantity = 0 To Used
            Labels(LabelQuantity) = New System.Windows.Forms.Label
            Me.Controls.Add(Me.Labels(LabelQuantity))
            With Labels(LabelQuantity)
                .AutoSize = True
                .BackColor = System.Drawing.Color.Black
                .BringToFront()
                .ForeColor = System.Drawing.SystemColors.ControlLight
                .TabStop = False
                Select Case StoryPoint
                    Case 1
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "censored"
                                .Location = New Point(80, 250)
                            Case 1
                                .AccessibleDescription = "safe"
                                .Location = New Point(146, 265)
                            Case 2
                                .AccessibleDescription = "rebel"
                                .Location = New Point(265, 340)
                        End Select
                    Case 2
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "rebel"
                                .Location = New Point(96, 235)
                            Case 1
                                .AccessibleDescription = "democratic"
                                .Location = New Point(238, 235)
                            Case 2
                                .AccessibleDescription = "threaten"
                                .Location = New Point(198, 265)
                            Case 3
                                .AccessibleDescription = "terrorist"
                                .Location = New Point(198, 400)
                        End Select
                    Case 3
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "lowered"
                                .Location = New Point(29, 235)
                            Case 1
                                .AccessibleDescription = "population"
                                .Location = New Point(91, 325)
                            Case 2
                                .AccessibleDescription = "allowed"
                                .Location = New Point(282, 250)
                            Case 3
                                .AccessibleDescription = "lowered"
                                .Location = New Point(198, 340)
                            Case 4
                                .AccessibleDescription = "terrorist"
                                .Location = New Point(198, 400)
                        End Select
                    Case 4
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "the"
                                .Location = New Point(113, 236)
                            Case 1
                                .AccessibleDescription = "of"
                                .Location = New Point(92, 250)
                            Case 2
                                .AccessibleDescription = "of"
                                .Location = New Point(30, 324)
                            Case 3
                                .AccessibleDescription = "the"
                                .Location = New Point(113, 236)
                            Case 4
                                .AccessibleDescription = "the"
                                .Location = New Point(307, 235)
                            Case 5
                                .AccessibleDescription = "of"
                                .Location = New Point(296, 249)
                            Case 6
                                .AccessibleDescription = "the"
                                .Location = New Point(279, 325)
                        End Select
                    Case 5
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "population"
                                .Location = New Point(29, 250)
                            Case 1
                                .AccessibleDescription = "photo"
                                .Location = New Point(133, 295)
                            Case 2
                                .AccessibleDescription = "spying"
                                .Location = New Point(198, 235)
                            Case 4
                                .AccessibleDescription = "denouncing"
                                .Location = New Point(198, 264)
                            Case 5
                                .AccessibleDescription = "allegations"
                                .Location = New Point(226, 325)
                        End Select
                    Case 6
                        Select Case LabelQuantity
                            Case 0
                                .AccessibleDescription = "measles"
                                .Location = New Point(29, 235)
                            Case 1
                                .AccessibleDescription = "sanitary"
                                .Location = New Point(105, 294)
                            Case 2
                                .AccessibleDescription = "vaccine"
                                .Location = New Point(287, 250)
                            Case 3
                                .AccessibleDescription = "bioweapon"
                                .Location = New Point(247, 339)
                            Case 4
                                .AccessibleDescription = "disease"
                                .Location = New Point(198, 384)
                        End Select
                    Case 7
                        If Helped Like True Then
                            Select Case LabelQuantity
                                Case 0
                                    .AccessibleDescription = "stolen"
                                    .Location = New Point(29, 250)
                                Case 1
                                    .AccessibleDescription = "barbaric"
                                    .Location = New Point(77, 325)
                                Case 2
                                    .AccessibleDescription = "suspicious"
                                    .Location = New Point(269, 220)
                                Case 3
                                    .AccessibleDescription = "scan"
                                    .Location = New Point(282, 325)
                                Case 4
                                    .AccessibleDescription = "measles"
                                    .Location = New Point(198, 399)
                            End Select
                        Else 'Helped like False
                            Select Case LabelQuantity
                                Case 0
                                    .AccessibleDescription = "deaths"
                                    .Location = New Point(140, 265)
                                Case 1
                                    .AccessibleDescription = "insignia"
                                    .Location = New Point(55, 310)
                                Case 2
                                    .AccessibleDescription = "attack"
                                    .Location = New Point(198, 235)
                                Case 3
                                    .AccessibleDescription = "scan"
                                    .Location = New Point(283, 325)
                                Case 4
                                    .AccessibleDescription = "terror"
                                    .Location = New Point(198, 385)
                            End Select
                        End If
                    Case 8
                        If Helped Like True Then
                            Select Case LabelQuantity
                                Case 0
                                    .AccessibleDescription = "dead"
                                    .Location = New Point(29, 250)
                                Case 1
                                    .AccessibleDescription = "bullet"
                                    .Location = New Point(29, 294)
                                Case 2
                                    .AccessibleDescription = "note"
                                    .Location = New Point(77, 310)
                                Case 3
                                    .AccessibleDescription = "murder"
                                    .Location = New Point(246, 250)
                                Case 4
                                    .AccessibleDescription = "censorship"
                                    .Location = New Point(251, 310)
                                Case 5
                                    .AccessibleDescription = "censorship"
                                    .Location = New Point(259, 355)
                                Case 6
                                    .AccessibleDescription = "die"
                                    .Location = New Point(258, 370)
                            End Select
                        Else 'Helped Like False
                            Select Case LabelQuantity
                                Case 0
                                    .AccessibleDescription = "attacked"
                                    .Location = New Point(29, 250)
                                Case 1
                                    .AccessibleDescription = "harmed"
                                    .Location = New Point(85, 280)
                                Case 2
                                    .AccessibleDescription = "bodyguards"
                                    .Location = New Point(29, 310)
                                Case 3
                                    .AccessibleDescription = "plot"
                                    .Location = New Point(232, 265)
                                Case 4
                                    .AccessibleDescription = "censorship"
                                    .Location = New Point(224, 355)
                            End Select
                        End If
                    Case 9
                        Select Case LabelQuantity
                            Case 0
                                If Helped = True Then
                                    .AccessibleDescription = "murder"
                                Else
                                    .AccessibleDescription = "attack"
                                End If
                                .Location = New Point(29, 235)
                            Case 1
                                .AccessibleDescription = "weapons"
                                .Location = New Point(29, 280)
                            Case 2
                                .AccessibleDescription = "guns"
                                .Location = New Point(29, 295)
                            Case 3
                                .AccessibleDescription = "knives"
                                .Location = New Point(77, 295)
                            Case 4
                                .AccessibleDescription = "forks"
                                .Location = New Point(29, 310)
                            Case 5
                                .AccessibleDescription = "weapons"
                                .Location = New Point(287, 220)
                            Case 6
                                .AccessibleDescription = "crime"
                                .Location = New Point(198, 265)
                            Case 7
                                .AccessibleDescription = "attacks"
                                .Location = New Point(198, 355)
                            Case 8
                                .AccessibleDescription = "internment"
                                .Location = New Point(198, 400)
                            Case 9
                                .AccessibleDescription = "death"
                                .Location = New Point(302, 400)
                        End Select
                End Select
            End With
        Next

        'Blacks out words and adds spaces per letter in accessibledescription
        For LabelNumber = 0 To Used
            For z = 1 To Len(Labels(LabelNumber).AccessibleDescription)
                Labels(LabelNumber).Text &= " "
            Next
        Next
    End Sub

    'Checks for correct answer
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, _
        Button9.Click, Button8.Click, Button6.Click, Button7.Click, Button5.Click, Button4.Click, Button25.Click, _
        Button23.Click, Button26.Click, Button21.Click, Button24.Click, Button22.Click, Button20.Click, Button19.Click, _
        Button17.Click, Button15.Click, Button18.Click, Button13.Click, Button16.Click, Button11.Click, Button14.Click, _
        Button12.Click, Button10.Click

        'Adds one guess attempt and shows in label
        Guessed += 1
        LblAttempts.Text = "Attempts: " & Guessed

        'Loops depending on number of labels in array
        For LblNumber = 0 To Used

            For x = 1 To Len(Labels(LblNumber).AccessibleDescription)

                If Mid(Labels(LblNumber).AccessibleDescription, x, 1) Like sender.text Then 'User got it right!

                    Mid(Labels(LblNumber).Text, x, 1) = sender.text 'Replaces spaces with letter guessed
                    If Done = False Then 'Adds correct if not already added
                        Correct += 1
                        TotalCorrect += 1
                        Done = True
                    End If

                Else 'User got it wrong

                    'If it is the last label, then it adds one incorrect to counter.
                    If LblNumber = Used And Done = False And x = Len(Labels(LblNumber).AccessibleDescription) Then

                        'Disables buttons for the duration of animation
                        For Each buttons As Button In Me.Controls.OfType(Of Button)()
                            buttons.Enabled = False
                        Next

                        'Adds an incorrect
                        Incorrect += 1
                        TotalIncorrect += 1
                        Done = True

                        'Adds incorrect letter to list
                        If TotalIncorrect > 1 Then
                            Letters &= ", "
                        End If
                        Letters &= sender.text

                        'Ends game after 5 wrong letters
                        If TotalIncorrect = 5 Then
                            Ending.Show()
                            AnswerWrite()
                            Me.Dispose()
                        End If

                        'Creates citation
                        CitationCreate()

                        'Starts timer for animation
                        TimerIncorrect.Start()

                    End If
                End If
            Next
        Next

        'Shows correct and incorrect values
        LblDecoded.Text = "Decoded: " & Correct
        LblFailures.Text = "Failures: " & Incorrect

        'Makes key unpressable
        sender.visible = False

        'Resets stuff
        Done = False

        'Checks if user has completed the level
        If Correct = Length Then

            StoryPoint += 1
            BtnNext.Visible = True
            For Each buttons As Button In Me.Controls.OfType(Of Button)()
                buttons.Enabled = False
            Next
            BtnNext.Enabled = True

            'Creates letter for specific circumstances
            If StoryPoint = 7 Then
                GroupCreate()
                With GroupDismiss(GroupNumber)
                    .Text = "Help them."
                End With
                With GroupConsent(GroupNumber)
                    .Text = "Do not do anything."
                End With
                With GroupMessage(GroupNumber)
                    .Text = "We need your help tonight. They blame us, but they are do not do anything. It was not us." & vbCrLf _
                        & vbCrLf & "They are keeping the vaccines for themselves and will not give them to the population, " _
                        & "but we will. Sing with us tonight. Help us liberate the medicine!"
                End With
            ElseIf StoryPoint = 8 Then
                GroupCreate()
                With GroupDismiss(GroupNumber)
                    .Text = "Ink them in."
                End With
                With GroupConsent(GroupNumber)
                    .Text = "Don't give them your fingerprints."
                End With
                With GroupMessage(GroupNumber)
                    .Text = "Tonight is the night. Tonight, we will assassinate the Minister of Information." & vbCrLf _
                        & vbCrLf & "We require your fingerprint to access the facility. Without you, this cannot succeed. " _
                        & "This is a critical mission. Do not fail us. We have provided a sheet for you."
                End With
            Else
                AnswerWrite()
            End If
        End If
    End Sub

    'Writes level and other information
    Public Sub AnswerWrite()
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim data As String() = {StoryPoint, Helped, TotalUnHelped, TotalTime, TotalCorrect, Guessed, Letters, TotalIncorrect}
        File.WriteAllLines(myPath & "\Level.txt", data)
    End Sub

    'Clears stuff for next level
    Private Sub Clear()

        'Deletes previous labels and re-enables buttons
        For LabelQuantity = 0 To Used
            Me.Controls.Remove(Labels(LabelQuantity))
            Labels(LabelQuantity).Dispose()
        Next

        For Each buttons As Button In Me.Controls.OfType(Of Button)()
            buttons.Visible = True
            buttons.Enabled = True
        Next

        'Resets number of correct
        Correct = 0
        LblDecoded.Text = "Decoded: " & Correct

        Me.KeyPreview = True

        'Resets for second level
        Initialize()

    End Sub

    'Creates Citation
    Private Sub CitationCreate()
        Me.KeyPreview = False
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
    End Sub

    'Creates letter
    Private Sub GroupCreate()
        Me.KeyPreview = False
        GroupNumber += 1
        LblClose.Enabled = False
        LblMinimize.Enabled = False
        LblBack.Enabled = False
        LblHelp.Enabled = False

        'Adds letter
        GroupMessage(GroupNumber) = New Label
        Me.Controls.Add(Me.GroupMessage(GroupNumber))
        With GroupMessage(GroupNumber)
            .AutoSize = False
            .BackColor = Color.White
            .MinimumSize = New Size(600, 200)
            .Location = New Point(70, -200)
            .TextAlign = ContentAlignment.MiddleCenter
        End With


        'Adds picturebox
        GroupPictureBox(GroupNumber) = New PictureBox
        Me.Controls.Add(Me.GroupPictureBox(GroupNumber))
        With GroupPictureBox(GroupNumber)
            .BackColor = Color.White
            If StoryPoint = 5 Then
                .BackgroundImage = My.Resources.MinistryOfAdmissionSeal
                .BackColor = Color.Gray
                .BackgroundImageLayout = ImageLayout.Zoom
                .Location = New Point(180, -100)
                .Size = New Size(35, 35)
            Else
                .BackgroundImage = My.Resources.EigthNote
                .BackgroundImageLayout = ImageLayout.Stretch
                .Location = New Point(355, -190)
                .Size = New Size(50, 50)
            End If
        End With

        'Adds button
        GroupDismiss(GroupNumber) = New Button
        Me.Controls.Add(Me.GroupDismiss(GroupNumber))
        With GroupDismiss(GroupNumber)
            .AutoSize = True
            .BackColor = Color.Black
            .ForeColor = Color.White
            .FlatStyle = FlatStyle.Flat
            .Location = New Point(560, -40)
        End With
        AddHandler GroupDismiss(GroupNumber).Click, AddressOf GroupDismissNo_Click
        TimerLetter.Start()
        For Each buttons As Button In Me.Controls.OfType(Of Button)()
            buttons.Enabled = False
        Next

        If StoryPoint = 5 Or StoryPoint = 7 Or StoryPoint = 8 Then
            'Adds second button
            GroupConsent(GroupNumber) = New Button
            Me.Controls.Add(Me.GroupConsent(GroupNumber))
            With GroupConsent(GroupNumber)
                .AutoSize = True
                .BackColor = Color.Black
                .BringToFront()
                .ForeColor = Color.White
                .FlatStyle = FlatStyle.Flat
                .Location = New Point(90, -40)
            End With
            AddHandler GroupConsent(GroupNumber).Click, AddressOf GroupConsent_Click
            If StoryPoint = 8 And Dismissed = False Then
                FingerPrint = New PictureBox
                Me.Controls.Add(FingerPrint)
                With FingerPrint
                    .BackgroundImage = My.Resources.FingerPrintSheet
                    .Location = New Point(370, -60)
                    .Size = New Size(170, 60)
                End With
            End If
        End If

        GroupDismiss(GroupNumber).Enabled = True
        GroupMessage(GroupNumber).BringToFront()
        GroupDismiss(GroupNumber).BringToFront()
        If StoryPoint <> 5 Then
            GroupPictureBox(GroupNumber).BringToFront()
        End If
    End Sub

    'First choice that helps SONG
    Private Sub GroupDismissNo_Click(sender As Object, e As EventArgs)


        If StoryPoint = 8 Then
            TimerFingerPrint.Start()
            Helped = True
            Me.Controls.Remove(GroupDismiss(GroupNumber))
            Me.Controls.Remove(GroupConsent(GroupNumber))
            LblClose.Enabled = True
            LblMinimize.Enabled = True
            LblBack.Enabled = True
            LblHelp.Enabled = True
            AnswerWrite()
        Else
            Me.Controls.Remove(GroupMessage(GroupNumber))
            Me.Controls.Remove(GroupPictureBox(GroupNumber))
            Me.Controls.Remove(GroupDismiss(GroupNumber))
            GroupMessage(GroupNumber).Dispose()
            GroupPictureBox(GroupNumber).Dispose()
            GroupDismiss(GroupNumber).Dispose()
            If StoryPoint = 5 And Dismissed = False Then
                Me.Controls.Remove(GroupConsent(GroupNumber))
                GroupConsent(GroupNumber).Dispose()
                GroupCreate()
                GroupMessage(GroupNumber).BackColor = Color.Gray
                GroupMessage(GroupNumber).TextAlign = ContentAlignment.MiddleCenter
                GroupMessage(GroupNumber).Text = "ANY EVIDENCE TO TREASON WILL BE SEVERLY PUNISHED."
                GroupDismiss(GroupNumber).Text = "Lovely!"
                GroupDismiss(GroupNumber).TabStop = False
                GroupConsent(GroupNumber).Visible = False
                GroupPictureBox(GroupNumber).Location = New Point(150, -120)
                GroupConsent(GroupNumber).TabStop = False
                Helped = "True"
                Dismissed = True
            ElseIf StoryPoint = 5 And Dismissed Then
                Me.Controls.Remove(GroupConsent(GroupNumber))
                GroupConsent(GroupNumber).Dispose()
                AnswerWrite()
                Dismissed = False
                LblClose.Enabled = True
                LblMinimize.Enabled = True
                LblBack.Enabled = True
                LblHelp.Enabled = True
                AnswerWrite()
            ElseIf StoryPoint = 7 And Dismissed = False Then
                Me.Controls.Remove(GroupConsent(GroupNumber))
                GroupConsent(GroupNumber).Dispose()
                GroupCreate()
                GroupMessage(GroupNumber).TextAlign = ContentAlignment.MiddleCenter
                GroupMessage(GroupNumber).Text = "This shall be a success thanks to your help."
                GroupDismiss(GroupNumber).Text = "Yay!"
                GroupDismiss(GroupNumber).TabStop = False
                GroupConsent(GroupNumber).Visible = False
                GroupConsent(GroupNumber).TabStop = False
                Helped = "True"
                Dismissed = True
            ElseIf StoryPoint = 7 And Dismissed Then
                Me.Controls.Remove(GroupConsent(GroupNumber))
                GroupConsent(GroupNumber).Dispose()
                Dismissed = False
                LblClose.Enabled = True
                LblMinimize.Enabled = True
                LblBack.Enabled = True
                LblHelp.Enabled = True
                AnswerWrite()
            Else
                LblClose.Enabled = True
                LblMinimize.Enabled = True
                LblBack.Enabled = True
                LblHelp.Enabled = True
                AnswerWrite()
            End If
        End If

        For Each buttons As Button In Me.Controls.OfType(Of Button)()
            buttons.Enabled = True
        Next
    End Sub

    'Second choice that helps the Government
    Private Sub GroupConsent_Click(sender As Object, e As EventArgs)

        'Removes controls from form
        Me.Controls.Remove(GroupMessage(GroupNumber))
        Me.Controls.Remove(GroupPictureBox(GroupNumber))
        Me.Controls.Remove(GroupDismiss(GroupNumber))
        Me.Controls.Remove(GroupConsent(GroupNumber))
        GroupMessage(GroupNumber).Dispose()
        GroupPictureBox(GroupNumber).Dispose()
        GroupDismiss(GroupNumber).Dispose()
        GroupConsent(GroupNumber).Dispose()

        'Re-enables buttons
        For Each buttons As Button In Me.Controls.OfType(Of Button)()
            buttons.Enabled = True
        Next

        'Different behaviour based on each day
        If StoryPoint = 5 Then
            Dismissed = True
            GroupCreate()
            GroupMessage(GroupNumber).BackColor = Color.Gray
            GroupMessage(GroupNumber).TextAlign = ContentAlignment.MiddleCenter
            GroupMessage(GroupNumber).Text = "Your help is greatly appreciated."
            GroupDismiss(GroupNumber).Text = "Awesome!"
            GroupDismiss(GroupNumber).TabStop = False
            GroupConsent(GroupNumber).Visible = False
            GroupPictureBox(GroupNumber).Location = New Point(180, -120)
            GroupConsent(GroupNumber).TabStop = False
            TotalUnHelped += 1
            LblClose.Enabled = True
            LblMinimize.Enabled = True
            LblBack.Enabled = True
            LblHelp.Enabled = True
            AnswerWrite()
        ElseIf StoryPoint = 7 And Dismissed = False Then
            GroupCreate()
            GroupMessage(GroupNumber).TextAlign = ContentAlignment.MiddleCenter
            GroupMessage(GroupNumber).Text = "You have jeopardized the lives of millions. You have failed us."
            GroupDismiss(GroupNumber).Visible = False
            GroupDismiss(GroupNumber).TabStop = False
            GroupConsent(GroupNumber).Text = "Aw, shucks!"
            GroupConsent(GroupNumber).TabStop = False
            Dismissed = True
        ElseIf StoryPoint = 7 And Dismissed Then
            TotalUnHelped += 1
            Dismissed = False
            LblClose.Enabled = True
            LblMinimize.Enabled = True
            LblBack.Enabled = True
            LblHelp.Enabled = True
            AnswerWrite()
        ElseIf StoryPoint = 8 And Dismissed = False Then
            Dismissed = True
            GroupCreate()
            GroupMessage(GroupNumber).TextAlign = ContentAlignment.MiddleCenter
            GroupMessage(GroupNumber).Text = "This is but a minor setback. There are others that are willing to help."
            GroupDismiss(GroupNumber).Visible = False
            GroupDismiss(GroupNumber).TabStop = False
            GroupConsent(GroupNumber).Text = "Great."
            GroupConsent(GroupNumber).TabStop = False
            FingerPrint.Dispose()
        ElseIf StoryPoint = 8 And Dismissed Then
            TotalUnHelped += 1
            FingerPrint.Dispose()
            LblClose.Enabled = True
            LblMinimize.Enabled = True
            LblBack.Enabled = True
            LblHelp.Enabled = True
            AnswerWrite()
        Else
            LblClose.Enabled = True
            LblMinimize.Enabled = True
            LblBack.Enabled = True
            LblHelp.Enabled = True
            AnswerWrite()
        End If

        Helped = "False"

    End Sub

    'Animates citation
    Dim Ticks As Integer
    Private Sub TimerIncorrect_Tick(sender As Object, e As EventArgs) Handles TimerIncorrect.Tick

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

    'Moves letter down from top
    Dim LetterMove As Integer
    Private Sub TimerLetter_Tick(sender As Object, e As EventArgs) Handles TimerLetter.Tick
        LetterMove += 1
        GroupMessage(GroupNumber).BringToFront()
        GroupPictureBox(GroupNumber).BringToFront()
        GroupDismiss(GroupNumber).BringToFront()
        If StoryPoint = 5 Or StoryPoint = 7 Or StoryPoint = 8 Then
            GroupConsent(GroupNumber).BringToFront()
        End If
        If StoryPoint = 8 Then
            FingerPrint.BringToFront()
        End If

        Select Case LetterMove
            Case 1 To 25
                GroupMessage(GroupNumber).Location = New Point(GroupMessage(GroupNumber).Location.X, GroupMessage(GroupNumber).Location.Y + 12)
                GroupPictureBox(GroupNumber).Location = New Point(GroupPictureBox(GroupNumber).Location.X, GroupPictureBox(GroupNumber).Location.Y + 12)
                GroupDismiss(GroupNumber).Location = New Point(GroupDismiss(GroupNumber).Location.X, GroupDismiss(GroupNumber).Location.Y + 12)
                If StoryPoint = 5 Or StoryPoint = 7 Or StoryPoint = 8 Then
                    GroupConsent(GroupNumber).Location = New Point(GroupConsent(GroupNumber).Location.X, GroupConsent(GroupNumber).Location.Y + 12)
                End If
                If StoryPoint = 8 Then
                    FingerPrint.Location = New Point(FingerPrint.Location.X, FingerPrint.Location.Y + 12)
                End If
            Case Else
                GroupMessage(GroupNumber).Location = New Point(GroupMessage(GroupNumber).Location.X, GroupMessage(GroupNumber).Location.Y)
                GroupPictureBox(GroupNumber).Location = New Point(GroupPictureBox(GroupNumber).Location.X, GroupPictureBox(GroupNumber).Location.Y)
                GroupDismiss(GroupNumber).Location = New Point(GroupDismiss(GroupNumber).Location.X, GroupDismiss(GroupNumber).Location.Y)
                If StoryPoint = 5 Or StoryPoint = 7 Or StoryPoint = 8 Then
                    GroupConsent(GroupNumber).Location = New Point(GroupConsent(GroupNumber).Location.X, GroupConsent(GroupNumber).Location.Y)
                End If
                If StoryPoint = 8 Then
                    FingerPrint.Location = New Point(FingerPrint.Location.X, FingerPrint.Location.Y)
                End If
                TimerLetter.Stop()
                LetterMove = 0
        End Select

    End Sub

    'Allows user to press keys and enter in form
    Private Sub Key(ByVal sender As Object, ByVal KeyPress As System.Windows.Forms.KeyPressEventArgs) _
    Handles Me.KeyPress
        Select Case KeyPress.KeyChar
            Case ChrW(65), ChrW(97)
                Button11.PerformClick()
                KeyPress.Handled = True
            Case ChrW(66), ChrW(98)
                Button24.PerformClick()
                KeyPress.Handled = True
            Case ChrW(67), ChrW(99)
                Button22.PerformClick()
                KeyPress.Handled = True
            Case ChrW(68), ChrW(100)
                Button13.PerformClick()
                KeyPress.Handled = True
            Case ChrW(69), ChrW(101)
                Button3.PerformClick()
                KeyPress.Handled = True
            Case ChrW(70), ChrW(102)
                Button14.PerformClick()
                KeyPress.Handled = True
            Case ChrW(71), ChrW(103)
                Button15.PerformClick()
                KeyPress.Handled = True
            Case ChrW(72), ChrW(104)
                Button16.PerformClick()
                KeyPress.Handled = True
            Case ChrW(73), ChrW(105)
                Button8.PerformClick()
                KeyPress.Handled = True
            Case ChrW(74), ChrW(106)
                Button17.PerformClick()
                KeyPress.Handled = True
            Case ChrW(75), ChrW(107)
                Button18.PerformClick()
                KeyPress.Handled = True
            Case ChrW(76), ChrW(108)
                Button19.PerformClick()
                KeyPress.Handled = True
            Case ChrW(77), ChrW(109)
                Button26.PerformClick()
                KeyPress.Handled = True
            Case ChrW(78), ChrW(110)
                Button25.PerformClick()
                KeyPress.Handled = True
            Case ChrW(79), ChrW(111)
                Button9.PerformClick()
                KeyPress.Handled = True
            Case ChrW(80), ChrW(112)
                Button10.PerformClick()
                KeyPress.Handled = True
            Case ChrW(81), ChrW(113)
                Button1.PerformClick()
                KeyPress.Handled = True
            Case ChrW(82), ChrW(114)
                Button4.PerformClick()
                KeyPress.Handled = True
            Case ChrW(83), ChrW(115)
                Button12.PerformClick()
                KeyPress.Handled = True
            Case ChrW(84), ChrW(116)
                Button5.PerformClick()
                KeyPress.Handled = True
            Case ChrW(85), ChrW(117)
                Button7.PerformClick()
                KeyPress.Handled = True
            Case ChrW(86), ChrW(118)
                Button23.PerformClick()
                KeyPress.Handled = True
            Case ChrW(87), ChrW(119)
                Button2.PerformClick()
                KeyPress.Handled = True
            Case ChrW(88), ChrW(120)
                Button21.PerformClick()
                KeyPress.Handled = True
            Case ChrW(89), ChrW(121)
                Button6.PerformClick()
                KeyPress.Handled = True
            Case ChrW(90), ChrW(122)
                Button20.PerformClick()
                KeyPress.Handled = True
        End Select
    End Sub

    'Allows user to access next level
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click

        MainMenu.Close()
        AnswerWrite()
        Clear()
        BtnNext.Visible = False

    End Sub

    'Keeps track of total time used
    Private Sub TimerTotalTime_Tick(sender As Object, e As EventArgs) Handles TimerTotalTime.Tick
        TotalTime += 1
    End Sub

    'Fingerprint Animation
    Dim ThumbPrint As New PictureBox
    Dim IndexPrint As New PictureBox
    Dim MiddlePrint As New PictureBox
    Dim RingPrint As New PictureBox
    Dim PinkyPrint As New PictureBox
    Private Sub TimerFingerPrint_Tick(sender As Object, e As EventArgs) Handles TimerFingerPrint.Tick
        FingerPrintTime += 1
        Select Case FingerPrintTime
            Case 1
                Me.Controls.Add(ThumbPrint)
                With ThumbPrint
                    .BackgroundImage = My.Resources.ThumbSworl
                    .BackColor = Color.FromArgb(224, 217, 235)
                    .BringToFront()
                    .Location = New Point(380, 254)
                    .Size = New Size(22, 32)
                End With
            Case 2
                Me.Controls.Add(IndexPrint)
                With IndexPrint
                    .BackgroundImage = My.Resources.IndexSworl
                    .BackColor = Color.FromArgb(224, 217, 235)
                    .BringToFront()
                    .Location = New Point(411, 254)
                    .Size = New Size(17, 28)
                End With
            Case 3
                Me.Controls.Add(MiddlePrint)
                With MiddlePrint
                    .BackgroundImage = My.Resources.MiddleSworl
                    .BackColor = Color.FromArgb(224, 217, 235)
                    .BringToFront()
                    .Location = New Point(450, 257)
                    .Size = New Size(17, 28)
                End With
            Case 4
                Me.Controls.Add(RingPrint)
                With RingPrint
                    .BackgroundImage = My.Resources.RingSworl
                    .BackColor = Color.FromArgb(224, 217, 235)
                    .BringToFront()
                    .Location = New Point(472, 255)
                    .Size = New Size(18, 27)
                End With
            Case 5
                Me.Controls.Add(PinkyPrint)
                With PinkyPrint
                    .BackgroundImage = My.Resources.PinkySworl
                    .BackColor = Color.FromArgb(224, 217, 235)
                    .BringToFront()
                    .Location = New Point(515, 258)
                    .Size = New Size(14, 24)
                End With
            Case 6 To 8
            Case 9
                Me.Controls.Remove(GroupMessage(GroupNumber))
                Me.Controls.Remove(ThumbPrint)
                Me.Controls.Remove(IndexPrint)
                Me.Controls.Remove(MiddlePrint)
                Me.Controls.Remove(RingPrint)
                Me.Controls.Remove(PinkyPrint)
                Me.Controls.Remove(FingerPrint)
                Me.Controls.Remove(GroupPictureBox(GroupNumber))
                GroupMessage(GroupNumber).Dispose()
                ThumbPrint.Dispose()
                IndexPrint.Dispose()
                MiddlePrint.Dispose()
                RingPrint.Dispose()
                PinkyPrint.Dispose()
                FingerPrint.Dispose()
                GroupPictureBox(GroupNumber).Dispose()
                AnswerWrite()
        End Select
    End Sub

    'Closes form
    Private Sub LblClose_Click(sender As Object, e As EventArgs) Handles LblClose.Click
        Close()
    End Sub

    'Minimizes form
    Private Sub LblMinimize_Click(sender As Object, e As EventArgs) Handles LblMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Back to main menu
    Private Sub LabelBack_Click(sender As Object, e As EventArgs) Handles LblBack.Click
        MainMenu.Show()
        AnswerWrite()
        My.Computer.Audio.Stop()
        If MainMenu.Music Then
            My.Computer.Audio.Play(My.Resources.Death, AudioPlayMode.BackgroundLoop)
        End If
        Me.Close()
    End Sub

    'Shows elp
    Dim LblInstruct As New Label
    Dim BtnPlay As New Button
    Private Sub LabelHelp_Click(sender As Object, e As EventArgs) Handles LblHelp.Click
        TimerTotalTime.Stop()

        For Each Labels As Label In Me.Controls.OfType(Of Label)()
            Labels.Visible = False
        Next
        For Each Buttons As Button In Me.Controls.OfType(Of Button)()
            Buttons.Visible = False
        Next
        LblTitle.Visible = True
        LblClose.Visible = True
        LblMinimize.Visible = True
        LblBack.Visible = True
        LblDate.Visible = True

        Me.Controls.Add(LblInstruct)
        With LblInstruct
            .AutoSize = True
            .BackColor = Color.FromArgb(239, 237, 220)
            .Location = New System.Drawing.Point(100, 191)
            .MaximumSize = New System.Drawing.Size(325, 100)
            .Size = New System.Drawing.Size(315, 56)
            .TabIndex = 26
            .Text = "Have you forgotten how to do your job again, plebian? Press a key on your keyboar" & _
        "d or click on the virtual keyboard in order to fill in the words that are blacke" & _
        "d out."
            .TextAlign = System.Drawing.ContentAlignment.TopCenter
            .Visible = True
        End With

        Me.Controls.Add(BtnPlay)
        AddHandler BtnPlay.Click, AddressOf BtnPlay_Click

        With BtnPlay
            .FlatStyle = System.Windows.Forms.FlatStyle.Flat
            .Location = New System.Drawing.Point(217, 260)
            .Name = "BtnPlay"
            .Size = New System.Drawing.Size(59, 23)
            .TabIndex = 27
            .TabStop = False
            .Text = "Back"
            .UseVisualStyleBackColor = True
            .Visible = True
        End With

        LblPaused.Visible = True
    End Sub

    'Closes help
    Private Sub BtnPlay_Click(sender As Object, e As EventArgs)
        Me.Controls.Remove(LblInstruct)
        Me.Controls.Remove(BtnPlay)

        For Each Labels As Label In Me.Controls.OfType(Of Label)()
            Labels.Visible = True
        Next
        For Each Buttons As Button In Me.Controls.OfType(Of Button)()
            Buttons.Visible = True
        Next

        BtnNext.Visible = False

        LblPaused.Visible = False

        TimerTotalTime.Start()
    End Sub

End Class
