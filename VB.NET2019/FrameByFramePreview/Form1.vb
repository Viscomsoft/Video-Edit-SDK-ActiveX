Public Class Form1

    Private Sub btnSelVideo_Click(sender As System.Object, e As System.EventArgs) Handles btnSelVideo.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|MP4 (*.mp4) | *.mp4|mpg (*.mpg) | *.mpg|FLV (*.flv*.f4v)|*.flv;*.f4v|Flash (*.swf)|*.swf|AVCHD (*.m2ts*.ts)|*.m2ts;*.ts|MPEG2 (*.vob) | *.vob|QuickTime (*.mov) | *.mov|Divx (*.divx)|*.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif "

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtVideo1.Text = OpenFileDialog1.FileName
            AxVideoEdit1.FrameLoadVideo(txtVideo1.Text)
            txttotalframe.Text = AxVideoEdit1.FrameGetFrameCount
            HScrollBar1.Maximum = txttotalframe.Text
        End If

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.LargeChange = 1
    End Sub

    Private Sub cmdplay_Click(sender As System.Object, e As System.EventArgs) Handles cmdplay.Click

        AxVideoEdit1.FramePlay()
    End Sub

    Private Sub cmdpause_Click(sender As System.Object, e As System.EventArgs) Handles cmdpause.Click
        AxVideoEdit1.FramePause()
    End Sub

    Private Sub cmdstop_Click(sender As System.Object, e As System.EventArgs) Handles cmdstop.Click
        AxVideoEdit1.FrameStop()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        AxVideoEdit1.FramePause()

        AxVideoEdit1.FrameSeek(HScrollBar1.Value)

    End Sub

   

    Private Sub AxVideoEdit1_OnFrameChange(sender As Object, e As AxVIDEOEDITLib._DVideoEditEvents_OnFrameChangeEvent) Handles AxVideoEdit1.OnFrameChange
        HScrollBar1.Value = e.iFrame
    End Sub

    Private Sub AxVideoEdit1_OnFrameCompleted(sender As Object, e As System.EventArgs) Handles AxVideoEdit1.OnFrameCompleted
        MessageBox.Show("Frame by Frame preview completed")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bResult As Boolean
        SaveFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            bResult = AxVideoEdit1.FrameExportFrame(SaveFileDialog1.FileName)
            AxVideoEdit1.FramePause()

        End If

    End Sub
End Class
