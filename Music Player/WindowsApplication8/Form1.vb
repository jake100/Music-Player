Imports System.IO

Public Class Form1
    Private Songs = New List(Of Song)
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If AxWindowsMediaPlayer1.URL = getSong(ListBox1.SelectedIndex).SongPath Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            AxWindowsMediaPlayer1.URL = getSong(ListBox1.SelectedIndex).SongPath
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub
    Dim counter As Integer = 0
    Private Function getSong(index As Integer) As Song
        For Each Song In Songs
            If counter = index Then
                counter = 0
                Return Song
            End If
            counter += 1
        Next
        counter = 0
        Return New Song("")
    End Function

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        If Windows.Forms.DialogResult.OK Then
            For Each track As String In OpenFileDialog1.FileNames
                Dim song As Song = New Song(track)
                ListBox1.Items.Add(song.Name)
                Songs.Add(song)
            Next
        End If
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub
End Class

Public Class Song
    Public Property SongPath As String
    Public Property Name As String
    Public Sub New(ByVal Song_Path As String)
        SongPath = Song_Path
        Name = Path.GetFileName(SongPath)
        Name = Replace(Name, ".mp3", "")
    End Sub
End Class
