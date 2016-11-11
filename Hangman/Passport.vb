'Created by Aaron Tan
'Code written sometime in 2015
'Licensed under the GNU Public License 4.0
'Enjoy the game!

Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System
Imports System.IO

Public Class Passport
    Dim MaleFaces(5) As Image 'For holding male faces
    Dim FemaleFaces(5) As Image 'For female faces
    Dim FaceNumber As Integer 'Random face
    Dim Ticks As Integer 'For animation
    Public PlayerName As String 'For player name

    Private Sub Passport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        LblBirth.Text = DateAdd(DateInterval.Year, -22, Now.Date)
    End Sub

    'Makes male face
    Private Sub RBtnM_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnM.CheckedChanged, RBtnF.CheckedChanged
        FaceMaker()
        ButtonCheck()
    End Sub

    'Makes female face
    Private Sub BtnChangeFace_Click(sender As Object, e As EventArgs) Handles BtnChangeFace.Click
        FaceMaker()
        ButtonCheck()
    End Sub

    'Randomly generates a face
    Private Sub FaceMaker()
        FaceNumber = Int(6 * Rnd())
        If RBtnM.Checked Then
            MaleFaces(0) = My.Resources.MFace1
            MaleFaces(1) = My.Resources.MFace2
            MaleFaces(2) = My.Resources.MFace3
            MaleFaces(3) = My.Resources.MFace4
            MaleFaces(4) = My.Resources.MFace5
            MaleFaces(5) = My.Resources.MFace6
            PBoxFace.BackgroundImage = MaleFaces(FaceNumber)
        ElseIf RBtnF.Checked Then
            FemaleFaces(0) = My.Resources.FFace1
            FemaleFaces(1) = My.Resources.FFace2
            FemaleFaces(2) = My.Resources.FFace3
            FemaleFaces(3) = My.Resources.FFace4
            FemaleFaces(4) = My.Resources.FFace5
            FemaleFaces(5) = My.Resources.FFace6
            PBoxFace.BackgroundImage = FemaleFaces(FaceNumber)
        End If
    End Sub

    'Hides form and continues to game
    Private Sub ButtonContinue_Click(sender As Object, e As EventArgs) Handles BtnContinue.Click
        PBoxGranted.Visible = True
        TimerContinue.Start()
        Dim myPath As String = System.IO.Path.GetFullPath(Application.StartupPath)
        Dim FirstTimes() = File.ReadAllLines(myPath & "\FirstTime.txt")
        Dim FirstTime As String = "No"
        FirstTimes(0) = FirstTime
        FirstTimes(1) = PlayerName
        File.WriteAllLines(myPath & "\FirstTime.txt", FirstTimes)
        LblInfo.Text = "This visa is granted to " & PlayerName & " until death."
    End Sub

    'Changes name
    Private Sub TBoxName_TextChanged(sender As Object, e As EventArgs) Handles TboxName.TextChanged
        ButtonCheck()
        PlayerName = TboxName.Text
    End Sub

    'Enables continue button when paperwork is filled out
    Private Sub ButtonCheck()
        If TboxName.Text <> "" And RBtnM.Checked Then
            BtnContinue.Enabled = True
        ElseIf TboxName.Text <> "" And RBtnF.Checked Then
            BtnContinue.Enabled = True
        Else
            BtnContinue.Enabled = False
        End If
    End Sub

    'Delays hiding of form
    Private Sub TimerContinue_Tick(sender As Object, e As EventArgs) Handles TimerContinue.Tick
        Ticks += 1
        If Ticks = 20 Then
            Story.Show()
            Me.Close()
        End If
    End Sub
End Class