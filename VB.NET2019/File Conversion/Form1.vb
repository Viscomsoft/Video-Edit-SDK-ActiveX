Public Class Form1
    Public strMode As String
    Dim clrTranColor As Color
    Dim clrText As Color
    Dim clrTextBg As Color
    Dim clrGifTranColor As Color
    Dim progressForm As Form2


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub AxVideoEdit1_Complete(sender As System.Object, e As System.EventArgs) Handles AxVideoEdit1.Complete
        If Not IsNothing(progressForm) Then

            progressForm.ProgressBar1.Value = progressForm.ProgressBar1.Maximum
            progressForm.Close()

            progressForm = Nothing
            MessageBox.Show("Convert Completed")
        End If

    End Sub

    Private Sub btnSelVideo_Click(sender As System.Object, e As System.EventArgs) Handles btnSelVideo.Click
        Dim idur As Double

        OpenFileDialog1.Filter = "All Files (*.*)|*.*|FLV (*.flv*.f4v)|*.flv;*.f4v|Flash (*.swf)|*.swf|AVCHD (*.m2ts*.ts)|*.m2ts;*.ts|MPEG2 (*.vob) | *.vob|QuickTime (*.mov) | *.mov|MP4 (*.mp4) | *.mp4|Divx (*.divx)|*.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|mpg (*.mpg) | *.mpg|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif "

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            'Actually Save the File
            txtVideo1.Text = OpenFileDialog1.FileName

            AxVideoEdit1.InfoLoadMedia(txtVideo1.Text)

            Me.txtVideoStart1.Text = CStr(0)
            idur = System.Math.Round(AxVideoEdit1.InfoDuration, 2)
            'if 0, this may image file, so set duration
            If idur = 0 Then
                Me.txtVideoStop1.Text = CStr(1)
            Else
                Me.txtVideoStop1.Text = idur
                'Set Audio detail
                Me.txtAudioStart1.Text = CStr(0)
                Me.txtAudioStop1.Text = idur
                txtAudio1.Text = txtVideo1.Text
            End If
        Else
            ' The User clicked the Cancel button
            txtVideo1.Text = ""
        End If

        cboaudiotrackname.Items.Clear()

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim iCount As Short
        Dim iRmCount As Short
        Dim strFolderPath As String
        Dim iPathIndex As Integer
        strMode = "STOP"

        SSTab1.SelectedIndex = 5

        cboGPU.Items.Add("None")
        cboGPU.Items.Add("Nvidia")
        cboGPU.Items.Add("AMD")
        cboGPU.Items.Add("Intel")
        cboGPU.SelectedIndex = 0

        cbonvidapreset.Items.Add("slow")
        cbonvidapreset.Items.Add("medium")
        cbonvidapreset.Items.Add("fast")
        cbonvidapreset.Items.Add("high performance")
        cbonvidapreset.Items.Add("high quality")
        cbonvidapreset.Items.Add("bluray disk")
        cbonvidapreset.Items.Add("low latency")
        cbonvidapreset.Items.Add("low latency high quality")
        cbonvidapreset.Items.Add("low latency high performance")
        cbonvidapreset.Items.Add("lossless")
        cbonvidapreset.Items.Add("lossless high performance")
        cbonvidapreset.SelectedIndex = 3



        cboslowmotion.Items.Add("0.5")
        cboslowmotion.Items.Add("1.0")
        cboslowmotion.Items.Add("2.0")
        cboslowmotion.Items.Add("3.0")
        cboslowmotion.SelectedIndex = 2

        cbofastmotion.Items.Add("0.9")
        cbofastmotion.Items.Add("0.8")
        cbofastmotion.Items.Add("0.7")
        cbofastmotion.Items.Add("0.6")
        cbofastmotion.Items.Add("0.5")
        cbofastmotion.Items.Add("0.4")
        cbofastmotion.Items.Add("0.3")
        cbofastmotion.Items.Add("0.2")
        cbofastmotion.Items.Add("0.1")
        cbofastmotion.SelectedIndex = 4






        cbopreset.Items.Add("superfast")
        cbopreset.Items.Add("veryfast")
        cbopreset.Items.Add("faster")
        cbopreset.Items.Add("fast")
        cbopreset.Items.Add("medium")
        cbopreset.Items.Add("slow")
        cbopreset.Items.Add("slower")
        cbopreset.Items.Add("veryslow")
        cbopreset.SelectedIndex = 0

        cboMP4AspectRadio.Items.Add(("4:3"))
        cboMP4AspectRadio.Items.Add(("16:9"))
        cboMP4AspectRadio.SelectedIndex = 0


        cboavchdaudiosamplerate.Items.Add("44100")
        cboavchdaudiosamplerate.Items.Add("48000")
        cboavchdaudiosamplerate.SelectedIndex = 0

        cboavchdvideobitrate.Items.Add("256")
        cboavchdvideobitrate.Items.Add("384")
        cboavchdvideobitrate.Items.Add("512")
        cboavchdvideobitrate.Items.Add("768")
        cboavchdvideobitrate.Items.Add("1024")
        cboavchdvideobitrate.Items.Add("4096")
        cboavchdvideobitrate.SelectedIndex = 0

        cboavchdaudiobitrate.Items.Add("48")
        cboavchdaudiobitrate.Items.Add("96")
        cboavchdaudiobitrate.Items.Add("128")
        cboavchdaudiobitrate.Items.Add("256")
        cboavchdaudiobitrate.SelectedIndex = 1


        cboavchdframerate.Items.Add("23.97")
        cboavchdframerate.Items.Add("24")
        cboavchdframerate.Items.Add("25")
        cboavchdframerate.Items.Add("29.97")

        cboavchdframerate.SelectedIndex = 2

        cboavchdwidthheight.Items.Add("720x480")
        cboavchdwidthheight.Items.Add("720x576")
        cboavchdwidthheight.Items.Add("1280x720")
        cboavchdwidthheight.Items.Add("1920x1080")

        cboavchdwidthheight.SelectedIndex = 0

        cboaudiosamplerate.Items.Add(("32000"))
        cboaudiosamplerate.Items.Add(("44100"))
        cboaudiosamplerate.Items.Add(("48000"))
        cboaudiosamplerate.SelectedIndex = 1

        cboMpegFrameRate.Items.Add(("23.976"))
        cboMpegFrameRate.Items.Add(("24"))
        cboMpegFrameRate.Items.Add(("25"))
        cboMpegFrameRate.Items.Add(("29.97"))
        cboMpegFrameRate.Items.Add(("30"))
        cboMpegFrameRate.Items.Add(("50"))
        cboMpegFrameRate.Items.Add(("59.94"))
        cboMpegFrameRate.SelectedIndex = 0

        cboMpegType.Items.Add(("VCD PAL"))
        cboMpegType.Items.Add(("VCD NTSC"))
        cboMpegType.Items.Add(("SVCD PAL"))
        cboMpegType.Items.Add(("SVCD NTSC"))
        cboMpegType.Items.Add(("DVD PAL"))
        cboMpegType.Items.Add(("DVD NTSC"))
        cboMpegType.Items.Add(("MPEG1"))
        cboMpegType.Items.Add(("MPEG2"))

        cboMpegType.SelectedIndex = 0

        cbogifquantizer.Items.Add("Basic")
        cbogifquantizer.Items.Add("Octree")
        cbogifquantizer.Items.Add("Mediancut")
        cbogifquantizer.Items.Add("NeuralNet")
        cbogifquantizer.SelectedIndex = 1

        cbomaxcolor.Items.Add("16")
        cbomaxcolor.Items.Add("32")
        cbomaxcolor.Items.Add("64")
        cbomaxcolor.Items.Add("128")
        cbomaxcolor.Items.Add("256")
        cbomaxcolor.SelectedIndex = 4


        cboqtvideocomp.Items.Add(("Animation Codec"))
        cboqtvideocomp.Items.Add(("BMP Codec"))
        cboqtvideocomp.Items.Add(("ComponentVideo Codec"))
        cboqtvideocomp.Items.Add(("H261 Codec"))
        cboqtvideocomp.Items.Add(("H263 Codec"))
        cboqtvideocomp.Items.Add(("H264 Codec"))
        cboqtvideocomp.Items.Add(("JPEG Codec"))
        cboqtvideocomp.Items.Add(("MPEG4 Visual Codec"))
        cboqtvideocomp.Items.Add(("Sorenson3 Codec"))
        cboqtvideocomp.Items.Add(("Sorenson Codec"))
        cboqtvideocomp.SelectedIndex = 8

        cboqtaudiocomp.Items.Add(("24BitFormat"))
        cboqtaudiocomp.Items.Add(("32BitFormat"))
        cboqtaudiocomp.Items.Add(("ALawCompression"))
        cboqtaudiocomp.Items.Add(("IMACompression"))
        cboqtaudiocomp.Items.Add(("MACE3Compression"))
        cboqtaudiocomp.Items.Add(("MACE6Compression"))
        cboqtaudiocomp.Items.Add(("ULawCompression"))
        cboqtaudiocomp.SelectedIndex = 0


        cboqtaudiochannel.Items.Add(("Mono"))
        cboqtaudiochannel.Items.Add(("Stereo"))
        cboqtaudiochannel.SelectedIndex = 1

        cboMP4AspectRadio.Items.Add(("4:3"))
        cboMP4AspectRadio.Items.Add(("16:9"))
        cboMP4AspectRadio.SelectedIndex = 0

        cbo3GPVideoCodec.Items.Add(("MPEG4"))
        cbo3GPVideoCodec.Items.Add(("H.263"))
        cbo3GPVideoCodec.SelectedIndex = 0

        cbo3GPAudioCodec.Items.Add(("AAC"))
        cbo3GPAudioCodec.Items.Add(("AMR"))
        cbo3GPAudioCodec.SelectedIndex = 0

        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/256Kbit/AAC/48Kbit"))
        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/256Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/384Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/512Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/512Kbit/AAC/128Kbit"))
        cboPSPProfile.Items.Add(("MPEG-4/320x240/29.97FPS/768Kbit/AAC/128Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/256Kbit/AAC/48Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/256Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/384Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/512Kbit/AAC/96Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/512Kbit/AAC/128Kbit"))
        cboPSPProfile.Items.Add(("H.264/320x240/29.97FPS/768Kbit/AAC/128Kbit"))
        cboPSPProfile.SelectedIndex = 0

        For I = 0 To AxVideoEdit1.GetVideoCompressorCount - 1
            cboVideoCompressor.Items.Add(AxVideoEdit1.GetVideoCompressorName(I))

            If AxVideoEdit1.GetVideoCompressorName(I) = "DV Video Encoder" Then
                cboVideoCompressor.SelectedIndex = I
            End If
        Next


        For I = 0 To AxVideoEdit1.GetAudioCompressorCount - 1
            cboAudioCompressor.Items.Add(AxVideoEdit1.GetAudioCompressorName(I))

            If AxVideoEdit1.GetAudioCompressorName(I) = "PCM" Then
                cboAudioCompressor.SelectedIndex = I
            End If
        Next



        iCount = 0
        For I = 0 To AxVideoEdit1.GetWMVProfileCount - 1
            cboWMV.Items.Add(AxVideoEdit1.GetWMVProfileName(I))
        Next


        If cboWMV.Items.Count > 0 Then
            cboWMV.SelectedIndex = 0
        End If



        cbowmv9.Items.Add("Windows Media Video 9 for Dial-up Modems (28,8 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Dial-up Modems (56 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Dial-up Modems or LAN (28,8 to 100 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for LAN, Cable Modem, or xDSL  (100 to 768kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Local Network (100 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Local Network (256 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Local Network (384 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Local Network (768 kbps)")
        cbowmv9.Items.Add("Windows Media Video 9 for Pocket PC (225kbps)")
        cbowmv9.SelectedIndex = 0



        cboscrolldir.Items.Add("Up")
        cboscrolldir.Items.Add("Down")
        cboscrolldir.Items.Add("Left")
        cboscrolldir.Items.Add("Right")
        cboscrolldir.SelectedIndex = 2


        clrTranColor = Color.FromArgb(0, 0, 0)

        clrText = Color.FromArgb(255, 255, 255)
        clrTextBg = Color.FromArgb(0, 0, 255)




        For I = 8 To 99 Step 2
            cbofontsize.Items.Add(Trim(Str(I)))
        Next
        cbofontsize.SelectedIndex = 20


        Me.cbofontstyle.Items.Add("Regular")
        Me.cbofontstyle.Items.Add("Bold")
        Me.cbofontstyle.Items.Add("Italic")
        Me.cbofontstyle.Items.Add("BoldItalic")
        Me.cbofontstyle.Items.Add("Underline")
        Me.cbofontstyle.SelectedIndex = 1

        cbofontname.Items.Add("Arial")
        cbofontname.Items.Add("Arial Black")
        cbofontname.Items.Add("Comic Sans MS")
        cbofontname.Items.Add("Times New Roman")
        cbofontname.SelectedIndex = 0

        Me.cbormvideomode.Items.Add("Normal Mode")
        Me.cbormvideomode.Items.Add("Smooth Mode")
        Me.cbormvideomode.Items.Add("Sharp Mode")
        Me.cbormvideomode.Items.Add("Slide Mode")
        cbormvideomode.SelectedIndex = 0


        cbormaudiomode.Items.Add("Music Mode")
        cbormaudiomode.Items.Add("Voice Mode")
        cbormaudiomode.SelectedIndex = 0


        strFolderPath = Application.ExecutablePath

        iPathIndex = strFolderPath.IndexOf("\VideoEdit Gold ActiveX Control")

        If iPathIndex <> -1 Then


            txtimage.Text = strFolderPath.Substring(0, iPathIndex) + "\VideoEdit Gold ActiveX Control\image.bmp"
            AxVideoEdit1.RMLoadProfiles(strFolderPath.Substring(0, iPathIndex) + "\VideoEdit Gold ActiveX Control\rmdll")

            iRmCount = AxVideoEdit1.RMProfilesCount

            For I = 0 To iRmCount - 1

                Me.cbormprofile.Items.Add(AxVideoEdit1.RMProfileName(I))
            Next

            If cbormprofile.Items.Count > 0 Then

                cbormprofile.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Function HaveAudioStream() As Boolean

        AxVideoEdit1.InfoLoadMedia(txtAudio1.Text)

        If AxVideoEdit1.InfoAudioStreamCount <> 0 Then
            HaveAudioStream = True

        Else
            HaveAudioStream = False


        End If

    End Function

    Private Sub Stop_Video()
        strMode = "STOP"
        AxVideoEdit1.Stop()
        cmdpause.Enabled = False
        cmdstop.Enabled = False
        chkuseoverlay.Enabled = True
        cboaudiotrackname.Enabled = True

    End Sub
    Private Function HaveVideoStream() As Boolean

        AxVideoEdit1.InfoLoadMedia(txtVideo1.Text)

        If AxVideoEdit1.InfoVideoStreamCount <> 0 Then
            HaveVideoStream = True

        Else


            If AxVideoEdit1.InfoMediaContainer = "JPEG" Or AxVideoEdit1.InfoMediaContainer = "Bitmap" Or AxVideoEdit1.InfoMediaContainer = "PNG" Or AxVideoEdit1.InfoMediaContainer = "GIF" Then
                HaveVideoStream = True
            Else
                HaveVideoStream = False
            End If


        End If

    End Function

    Private Sub cmdStart_Click(sender As System.Object, e As System.EventArgs) Handles cmdStart.Click
        Dim result As Boolean
        Dim WMVIndex As Integer
        Dim strWMV As String
        Dim strpath As String
        Dim AudioCompressorIndex As Integer
        Dim strAudioCompressor As String
        Dim CompressorIndex As Integer
        Dim strCompressor As String
        Dim strFilter As String
        Dim stretchmode As Integer
        Dim iWidth As Integer
        Dim iHeight As Integer
        Dim strFolderPath As String
        Dim iPathIndex As Integer
        Dim iFrameRate As Double

        If optaspect1.Checked Then
            stretchmode = 0
        End If

        If optaspect2.Checked Then
            stretchmode = 1
        End If

        If optaspect3.Checked Then
            stretchmode = 2
        End If

        If optaspect4.Checked Then
            stretchmode = 3
        End If



        AxVideoEdit1.InfoLoadMedia(txtVideo1.Text)
        iWidth = AxVideoEdit1.InfoMediaWidth
        iHeight = AxVideoEdit1.InfoMediaHeight
        iFrameRate = AxVideoEdit1.InfoFrameRate


        If iWidth = 0 Then
            iWidth = 320
        End If

        If iHeight = 0 Then
            iHeight = 240
        End If
        AxVideoEdit1.OutputFileWidth = iWidth
        AxVideoEdit1.OutputFileHeight = iHeight
        AxVideoEdit1.FrameRate = iFrameRate

        'Special handle of MPEG format
        If SSTab1.SelectedIndex = 5 Then

            If chkmpeg169.Checked Then
                AxVideoEdit1.MPEGAspectRatio = 1
            Else
                AxVideoEdit1.MPEGAspectRatio = 0

            End If
            Select Case cboMpegType.SelectedIndex
                Case 0
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.VCD_PAL
                Case 1
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.VCD_NTSC
                Case 2
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.SVCD_PAL
                Case 3
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.SVCD_NTSC
                Case 4
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.DVD_PAL
                Case 5
                    Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.DVD_NTSC
                Case 6
                    AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MPEG1
                    AxVideoEdit1.FrameRate = cboMpegFrameRate.Items(cboMpegFrameRate.SelectedIndex)
                    AxVideoEdit1.MPEGAudioSampleRate = cboaudiosamplerate.Items(cboaudiosamplerate.SelectedIndex)
                    AxVideoEdit1.MPEGAudioBitrate = txtAudioBitRate.Text
                    AxVideoEdit1.MPEGAudioChannels = txtMPEGAudioChannel.Text
                    AxVideoEdit1.MPEGVideoBitrate = txtVideoBitRate.Text
                    AxVideoEdit1.MPEGWidth = txtmpegwidth.Text
                    AxVideoEdit1.MPEGHeight = txtmpegheight.Text

                Case 7
                    AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MPEG2
                    AxVideoEdit1.FrameRate = cboMpegFrameRate.Items(cboMpegFrameRate.SelectedIndex)
                    AxVideoEdit1.MPEGAudioSampleRate = cboaudiosamplerate.Items(cboaudiosamplerate.SelectedIndex)
                    AxVideoEdit1.MPEGAudioBitrate = txtAudioBitRate.Text
                    AxVideoEdit1.MPEGAudioChannels = txtMPEGAudioChannel.Text
                    AxVideoEdit1.MPEGVideoBitrate = txtVideoBitRate.Text
                    AxVideoEdit1.MPEGWidth = txtmpegwidth.Text
                    AxVideoEdit1.MPEGHeight = txtmpegheight.Text
            End Select

            strFilter = "MPEG File (*.mpg)|*.mpg||"
        End If

        'Special handle of AVI format
        If SSTab1.SelectedIndex = 0 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.AVI
            strFilter = "Avi File (*.avi)|*.avi"


            If chkUseVideoComp.Checked Then
                AxVideoEdit1.VideoCompressor = cboVideoCompressor.SelectedIndex
            End If


            If ChkUseAudioComp.Checked Then
                AxVideoEdit1.AudioCompressor = cboAudioCompressor.SelectedIndex

            End If

            AxVideoEdit1.AVIMP3Bitrate = CShort(txtavimp3bitrate.Text)
            AxVideoEdit1.AVIMP3SampleRate = CDbl(txtavimp3samplerate.Text)


            AxVideoEdit1.OutputFileWidth = CShort(txtaviwidth.Text)
            AxVideoEdit1.OutputFileHeight = CShort(txtaviheight.Text)
        End If

        'Special handle of WMV format
        If SSTab1.SelectedIndex = 6 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.WMV
            strFilter = "wmv File (*.wmv)|*.wmv"

            If chkusewmv9.CheckState = 1 Then
                strFolderPath = Application.ExecutablePath

                iPathIndex = strFolderPath.IndexOf("\VideoEdit Gold ActiveX Control")

                If iPathIndex <> -1 Then

                    strpath = strFolderPath.Substring(0, iPathIndex) + "\VideoEdit Gold ActiveX ControlX\Profiles"

                End If


                Select Case cbowmv9.SelectedIndex
                    Case 0
                        strpath = strpath + "\Dial-up Modems (28,8 kbps).prx"
                    Case 1
                        strpath = strpath + "\Dial-up Modems (56 kbps).prx"
                    Case 2
                        strpath = strpath + "\Dial-up Modems or LAN (28,8 to 100 kbps).prx"
                    Case 3
                        strpath = strpath + "\LAN, Cable Modem, or xDSL  (100 to 768kbps).prx"
                    Case 4
                        strpath = strpath + "\Local Network (100 kbps).prx"
                    Case 5
                        strpath = strpath + "\Local Network (256 kbps).prx"
                    Case 6
                        strpath = strpath + "\Local Network (384 kbps).prx"
                    Case 7
                        strpath = strpath + "\Local Network (768 kbps).prx"
                    Case 8
                        strpath = strpath + "\Pocket PC (225kbps).prx"

                End Select


                AxVideoEdit1.WMVCustomFileName = "C:\Program Files (x86)\VideoEdit Gold ActiveX ControlX\Profiles\720x480NTSC.prx"
            Else

                strWMV = cboWMV.Items(cboWMV.SelectedIndex)
                WMVIndex = Me.AxVideoEdit1.WMVProfiles.FindWMVProfile(strWMV)

                If WMVIndex <> -1 Then
                    AxVideoEdit1.WMVProfile = WMVIndex
                End If
            End If
        End If


        'Special handle of QT format
        If SSTab1.SelectedIndex = 1 Then

            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.QT
            strFilter = "QuickTime File (*.mov)|*.mov"
            Me.AxVideoEdit1.QTVideoCompressor = cboqtvideocomp.SelectedIndex
            Me.AxVideoEdit1.QTAudioCompressor = cboqtaudiocomp.SelectedIndex
            Me.AxVideoEdit1.QTAudioChannels = cboqtaudiochannel.SelectedIndex
            Me.AxVideoEdit1.QTAudioSampleRate = CInt(txtqtaudiosamplerate.Text)
            AxVideoEdit1.OutputFileWidth = iWidth
            AxVideoEdit1.OutputFileHeight = iHeight
        End If

        If SSTab1.SelectedIndex = 2 Then

            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.RMVB
            strFilter = "RMVB File (*.rmvb)|*.rmvb"
            Me.AxVideoEdit1.RMProfile = Me.cbormprofile.SelectedIndex
            Me.AxVideoEdit1.RMVideoFrameRate = txtRmFrameRate.Text
            Me.AxVideoEdit1.RMWidth = Me.txtRmWidth.Text
            Me.AxVideoEdit1.RMHeight = Me.txtRmHeight.Text
            Me.AxVideoEdit1.RMVideoMode = cbormvideomode.SelectedIndex
            Me.AxVideoEdit1.RMAudioMode = cbormaudiomode.SelectedIndex


        End If

        If SSTab1.SelectedIndex = 4 Then

            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.ANIMATED_GIF
            strFilter = "Animated GIF File (*.gif)|*.gif"
            Me.AxVideoEdit1.AniGIFWidth = txtgifwidth.Text
            Me.AxVideoEdit1.AniGIFHeight = txtgifheight.Text
            Me.AxVideoEdit1.AniGIFLoop = txtgifloop.Text
            Me.AxVideoEdit1.AniGIFMaxColor = cbomaxcolor.Items(cbomaxcolor.SelectedIndex)
            Me.AxVideoEdit1.AniGIFQuantizer = cbogifquantizer.SelectedIndex
            Me.AxVideoEdit1.AniGIFTransColor = clrGifTranColor
            Me.AxVideoEdit1.AniGIFVideoQuality = chkgifvideoquality.Checked
            Me.AxVideoEdit1.FrameRate = txtgiffps.Text


        End If

        If SSTab1.SelectedIndex = 3 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.AVCHD
            strFilter = "AVCHD Video File (*.m2ts)|*.m2ts"

            AxVideoEdit1.AVCHDAudioBitrate = cboavchdaudiobitrate.Items(cboavchdaudiobitrate.SelectedIndex)
            AxVideoEdit1.AVCHDVideoBitrate = cboavchdvideobitrate.Items(cboavchdvideobitrate.SelectedIndex)
            AxVideoEdit1.AVCHDVideoFrameRate = cboavchdframerate.Items(cboavchdframerate.SelectedIndex)

            Select Case cboavchdwidthheight.SelectedIndex
                Case 0
                    Me.AxVideoEdit1.AVCHDWidth = 720
                    Me.AxVideoEdit1.AVCHDHeight = 480
                Case 1
                    Me.AxVideoEdit1.AVCHDWidth = 720
                    Me.AxVideoEdit1.AVCHDHeight = 576

                Case 2
                    Me.AxVideoEdit1.AVCHDWidth = 1280
                    Me.AxVideoEdit1.AVCHDHeight = 720

                Case 3
                    Me.AxVideoEdit1.AVCHDWidth = 1920
                    Me.AxVideoEdit1.AVCHDHeight = 1080

            End Select

            If Me.cboavchdaudiosamplerate.SelectedIndex = 0 Then
                Me.AxVideoEdit1.AVCHDAudioSampleRate = 44100
            Else
                Me.AxVideoEdit1.AVCHDAudioSampleRate = 48000
            End If

            If Me.chkavchd169.Checked Then
                Me.AxVideoEdit1.AVCHDAspectRatio = 1
            Else
                Me.AxVideoEdit1.AVCHDAspectRatio = 0
            End If

        End If

        If SSTab1.SelectedIndex = 7 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MP4
            strFilter = "MP4 Video File (*.mp4)|*.mp4"

            Me.AxVideoEdit1.MP4VideoBitrate = MP4VideoBitrate.Text
            Me.AxVideoEdit1.MP4AudioBitrate = MP4AudioBitrate.Text
            Me.AxVideoEdit1.MP4AudioSampleRate = MP4AudioSampleRate.Text
            Me.AxVideoEdit1.MP4AudioChannels = MP4AudioChannel.Text
            Me.AxVideoEdit1.MP4Framerate = MP4FrameRate.Text
            Me.AxVideoEdit1.MP4Width = MP4Width.Text
            Me.AxVideoEdit1.MP4Height = MP4Height.Text

            AxVideoEdit1.MP4H264Preset = cbopreset.SelectedIndex
            AxVideoEdit1.MP4GPUCodec = cboGPU.SelectedIndex
            AxVideoEdit1.MP4NVIDAPreset = cbonvidapreset.SelectedIndex

            Me.AxVideoEdit1.MP4AspectRatio = Me.cboMP4AspectRadio.SelectedIndex
            If chkSupportMP4Download.Checked Then
                Me.AxVideoEdit1.MP4Streaming = True
            Else
                Me.AxVideoEdit1.MP4Streaming = False
            End If
        End If

        If SSTab1.SelectedIndex = 8 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.VIDEO3GP
            strFilter = "3GP Video File (*.3gp)|*.3gp"

            Me.AxVideoEdit1.Video3GPVideoCodec = cbo3GPVideoCodec.SelectedIndex
            Me.AxVideoEdit1.Video3GPAudioCodec = cbo3GPAudioCodec.SelectedIndex
            Me.AxVideoEdit1.Video3GPVideoBitrate = text3GPVideoBitrate.Text
            Me.AxVideoEdit1.Video3GPAudioSampleRate = text3GPAudioSampleRate.Text
            Me.AxVideoEdit1.OutputFileWidth = text3GPWidth.Text
            Me.AxVideoEdit1.OutputFileHeight = text3GPHeight.Text

        End If

        If SSTab1.SelectedIndex = 9 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.FLV
            strFilter = "FLV Video File (*.flv)|*.flv"

            Me.AxVideoEdit1.FLVVideoBitrate = flvVideoBitrate.Text
            Me.AxVideoEdit1.FLVAudioBitrate = flvAudioBitrate.Text
            Me.AxVideoEdit1.FLVAudioChannels = flvAudioChannel.Text
            Me.AxVideoEdit1.FLVAudioSampleRate = flvAudioSampleRate.Text
            Me.AxVideoEdit1.FLVFrameRate = flvFrameRate.Text
            Me.AxVideoEdit1.FLVWidth = flvWidth.Text
            Me.AxVideoEdit1.FLVHeight = flvHeight.Text

        End If

        If SSTab1.SelectedIndex = 10 Then
            Me.AxVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.PSP
            strFilter = "PSP Video File (*.mp4)|*.mp4"

            Me.AxVideoEdit1.PSPProfile = cboPSPProfile.SelectedIndex
        End If

        If chkuseoverlay.CheckState = 1 Then
            AxVideoEdit1.UseOverlay = True
        Else
            AxVideoEdit1.UseOverlay = False
        End If



        AxVideoEdit1.VideoSampleSize = 32
        AxVideoEdit1.InitControl()

        'Add video track
        If HaveVideoStream() Then
            If txtVideo1.Text <> "" Then
                If Me.optnormalmotion.Checked Then
                    Me.AxVideoEdit1.AddVideo(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode)
                End If

                If Me.optslowmotion.Checked Then
                    Me.AxVideoEdit1.AddVideoWithSlowMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode, cboslowmotion.Items(cboslowmotion.SelectedIndex))
                End If

                If Me.optfastmotion.Checked Then
                    Me.AxVideoEdit1.AddVideoWithFastMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode, cbofastmotion.Items(cbofastmotion.SelectedIndex))
                End If
            End If
        End If

        'Add audio track
        If HaveAudioStream() Then
            If txtAudio1.Text <> "" Then

                If Me.optnormalmotion.Checked Then
                    result = Me.AxVideoEdit1.AddAudio(txtAudio1.Text, CDbl(txtAudioStart1.Text), CDbl(txtAudioStop1.Text))
                End If

                If Me.optslowmotion.Checked Then
                    result = Me.AxVideoEdit1.AddAudioWithSlowMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), cboslowmotion.Items(cboslowmotion.SelectedIndex))
                End If

                If Me.optfastmotion.Checked Then
                    result = Me.AxVideoEdit1.AddAudioWithFastMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), cbofastmotion.Items(cbofastmotion.SelectedIndex))
                End If
                If result = False Then
                    MessageBox.Show("Audio format fail")
                    Stop_Video()
                    Exit Sub
                End If
            End If
        End If

        'Save is Failed
        If AxVideoEdit1.GetTotalDuration = 0 Then
            MessageBox.Show("Timeline empty,cannot process")
            Stop_Video()
            Exit Sub
        End If

        If cboaudiotrackname.Items.Count > 0 Then
            Me.AxVideoEdit1.AMStreamSelectAudioTrack(txtVideo1.Text, cboaudiotrackname.SelectedIndex)
        End If

        OverlaySetting()

        'Save
        SaveFileDialog1.Filter = strFilter
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            result = Me.AxVideoEdit1.Save(SaveFileDialog1.FileName)
            If result = False Then
                MessageBox.Show("Fail to save file")
            End If
        End If
    End Sub

    Private Sub AxVideoEdit1_Processing(sender As System.Object, e As AxVIDEOEDITLib._DVideoEditEvents_ProcessingEvent) Handles AxVideoEdit1.Processing
        If IsNothing(progressForm) Then

            progressForm = New Form2

            progressForm.ProgressBar1.Maximum = e.iDuration * 100
            '  progressForm.ButtonCancel.Click += New EventHandler(ProgressButton_Click)
            AddHandler progressForm.ButtonCancel.Click, AddressOf ProgressButton_Click

            progressForm.Show()
        Else

            progressForm.ProgressBar1.Value = Math.Min(e.iCurPos * 100, e.iDuration * 100)

        End If



    End Sub

    Private Sub ProgressButton_Click()
        AxVideoEdit1.Stop()
        'this.progressForm.cancelButton.Click -= new EventHandler(ProgressButton_Click);
        RemoveHandler progressForm.ButtonCancel.Click, AddressOf ProgressButton_Click
        progressForm.Close()
        progressForm = Nothing

    End Sub

    Private Sub AxVideoEdit1_OnPlaying(sender As System.Object, e As AxVIDEOEDITLib._DVideoEditEvents_OnPlayingEvent) Handles AxVideoEdit1.OnPlaying
        txtTime.Text = CStr(System.Math.Round(e.iCurrent, 2))

    End Sub
    Private Sub OverlaySetting()
        AxVideoEdit1.OverlaySetTextBgColor(clrTextBg.R, clrTextBg.G, clrTextBg.B, CShort(txtalphabg.Text))
        AxVideoEdit1.OverlaySetTextColor(clrText.R, clrText.G, clrText.B, CShort(txtalphatext.Text))
        AxVideoEdit1.OverlayAddText(txtText1.Text & Chr(10) & Chr(13) & txtText2.Text, CShort(txtLeft.Text), CShort(txtTop.Text), CDbl(txtTextStart.Text), CDbl(txtTextEnd.Text), chkfade.Checked)

        If Me.chkscrolltype.Checked() Then
            AxVideoEdit1.OverlaySetState(0)
        Else
            AxVideoEdit1.OverlaySetState(1)

        End If

        AxVideoEdit1.OverlaySetSpeed(CDbl(txtscrollspeed.Text))
        AxVideoEdit1.OverlaySetTextScrollDir(Me.cboscrolldir.SelectedIndex)
        AxVideoEdit1.OverlaySetTextShadow(chkshadow.Checked)
        AxVideoEdit1.OverlaySetFont(cbofontname.Items(cbofontname.SelectedIndex), cbofontsize.Items(cbofontsize.SelectedIndex), cbofontstyle.SelectedIndex)

        If RadioButtonImage.Checked Then
            AxVideoEdit1.OverlayAddImage(txtimage.Text, CShort(txtimageleft.Text), CShort(txtimagetop.Text), clrTranColor.R, clrTranColor.G, clrTranColor.B, CDbl(txtImageStart.Text), CDbl(txtImageEnd.Text), chkfade.Checked)
        Else
            AxVideoEdit1.OverlayAddPNGImage(txtpng.Text, CShort(txtimageleft.Text), CShort(txtimagetop.Text), CDbl(txtImageStart.Text), CDbl(txtImageEnd.Text), chkfade.Checked)

        End If

    End Sub
    Private Sub cmdplay_Click(sender As System.Object, e As System.EventArgs) Handles cmdplay.Click
        Dim result As Boolean
        Dim stretchmode As Integer
        Dim iwidth As Integer
        Dim iheight As Integer

        If txtVideo1.Text = "" Then
            Exit Sub
        End If

        If strMode = "PAUSE" Then
            Me.AxVideoEdit1.Play()
            Exit Sub
        End If

        If strMode = "STOP" Then


            '2014 June updated
            AxVideoEdit1.InfoLoadMedia(txtVideo1.Text)
            iwidth = AxVideoEdit1.InfoMediaWidth
            iheight = AxVideoEdit1.InfoMediaHeight

            If iwidth = 0 Then iwidth = 320
            If iheight = 0 Then iheight = 240

            AxVideoEdit1.OutputFileWidth = iwidth
            AxVideoEdit1.OutputFileHeight = iheight
            AxVideoEdit1.VideoSampleSize = 24

            If chkuseoverlay.CheckState = 1 Then
                AxVideoEdit1.UseOverlay = True
            Else
                AxVideoEdit1.UseOverlay = False
            End If
             AxVideoEdit1.VideoSampleSize = 32	
            AxVideoEdit1.InitControl()
            'Add video track

            If HaveVideoStream() Then
                If txtVideo1.Text <> "" Then
                    If Me.optnormalmotion.Checked Then
                        Me.AxVideoEdit1.AddVideo(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode)
                    End If

                    If Me.optslowmotion.Checked Then
                        Me.AxVideoEdit1.AddVideoWithSlowMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode, cboslowmotion.Items(cboslowmotion.SelectedIndex))
                    End If

                    If Me.optfastmotion.Checked Then
                        Me.AxVideoEdit1.AddVideoWithFastMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), stretchmode, cbofastmotion.Items(cbofastmotion.SelectedIndex))
                    End If
                    strMode = "PLAY"
                End If
            End If


            'Add audio track
            If HaveAudioStream() Then
                If txtAudio1.Text <> "" Then
                    If Me.optnormalmotion.Checked Then
                        result = Me.AxVideoEdit1.AddAudio(txtAudio1.Text, CDbl(txtAudioStart1.Text), CDbl(txtAudioStop1.Text))
                    End If

                    If Me.optslowmotion.Checked Then
                        result = Me.AxVideoEdit1.AddAudioWithSlowMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), cboslowmotion.Items(cboslowmotion.SelectedIndex))
                    End If

                    If Me.optfastmotion.Checked Then
                        result = Me.AxVideoEdit1.AddAudioWithFastMotion(txtVideo1.Text, CDbl(txtVideoStart1.Text), CDbl(txtVideoStop1.Text), cbofastmotion.Items(cbofastmotion.SelectedIndex))
                    End If
                    If result = False Then
                        MessageBox.Show("Audio format fail")
                        Exit Sub
                    End If
                End If
            End If
            OverlaySetting()

            If cboaudiotrackname.Items.Count > 0 Then
                Me.AxVideoEdit1.AMStreamSelectAudioTrack(txtVideo1.Text, cboaudiotrackname.SelectedIndex)
            End If


            Me.AxVideoEdit1.Preview()

            cboaudiotrackname.Enabled = False

            chkuseoverlay.Enabled = False
            cmdpause.Enabled = True
            cmdstop.Enabled = True
        End If

    End Sub

    Private Sub cmdpause_Click(sender As System.Object, e As System.EventArgs) Handles cmdpause.Click
        strMode = "PAUSE"
        Me.AxVideoEdit1.Pause()

    End Sub

    Private Sub cmdstop_Click(sender As System.Object, e As System.EventArgs) Handles cmdstop.Click
        Stop_Video()

    End Sub

    Private Sub chkUseVideoComp_Click(sender As System.Object, e As System.EventArgs) Handles chkUseVideoComp.Click
        If Me.chkUseVideoComp.Checked Then

            Command1.Enabled = True
            cboVideoCompressor.Enabled = True
            AxVideoEdit1.UseVideoCompressor = True


        Else
            Command1.Enabled = False
            cboVideoCompressor.Enabled = False
            AxVideoEdit1.UseVideoCompressor = False


        End If
    End Sub

    Private Sub ChkUseAudioComp_Click(sender As System.Object, e As System.EventArgs) Handles ChkUseAudioComp.Click
        If ChkUseAudioComp.Checked Then
            cboAudioCompressor.Enabled = True

            Me.AxVideoEdit1.UseAudioCompressor = True
        Else
            cboAudioCompressor.Enabled = False
            Me.AxVideoEdit1.UseAudioCompressor = False
        End If
    End Sub

    Private Sub Command1_Click(sender As System.Object, e As System.EventArgs) Handles Command1.Click
        Dim result As Integer
        Dim VideoCompressorIndex As Integer
        Dim strVideoCompressor As String


        result = AxVideoEdit1.VideoCompressors.ShowPropertyPage(cboVideoCompressor.SelectedIndex)

        If result = False Then
            MessageBox.Show("No property page")
        End If
    End Sub

    Private Sub cmdgiftrancolor_Click(sender As System.Object, e As System.EventArgs) Handles cmdgiftrancolor.Click
        ColorDialog1.ShowDialog()
        clrGifTranColor = Me.ColorDialog1.Color
    End Sub

    Private Sub Command11_Click(sender As System.Object, e As System.EventArgs) Handles Command11.Click
        OpenFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp|JPEG File (*.jpg)|*.jpg|TIFF File (*.tif)|*.tif|PNG File (*.png)|*.png"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtimage.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub CommandPNG_Click(sender As System.Object, e As System.EventArgs) Handles CommandPNG.Click
        OpenFileDialog1.Filter = "PNG File (*.png)|*.png"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtpng.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub cmdimagetrancolor_Click(sender As System.Object, e As System.EventArgs) Handles cmdimagetrancolor.Click
        ColorDialog1.ShowDialog()

        clrTranColor = Me.ColorDialog1.Color
    End Sub

    Private Sub Option2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Option2.CheckedChanged

    End Sub

    Private Sub Option2_Click(sender As System.Object, e As System.EventArgs) Handles Option2.Click
        If Option2.Checked Then
            AxVideoEdit1.AspectRatio = False
        End If
    End Sub

    Private Sub Option1_Click(sender As System.Object, e As System.EventArgs) Handles Option1.Click
        If Option1.Checked Then
            AxVideoEdit1.AspectRatio = True
        End If
    End Sub

    Private Sub chkusewmv9_Click(sender As System.Object, e As System.EventArgs) Handles chkusewmv9.Click
        If chkusewmv9.Checked Then
            cboWMV.Enabled = False
            cbowmv9.Enabled = True
        Else
            cboWMV.Enabled = True
            cbowmv9.Enabled = False
        End If
    End Sub

    Private Sub cmdsolidfontcolor_Click(sender As System.Object, e As System.EventArgs) Handles cmdsolidfontcolor.Click
        ColorDialog1.ShowDialog()
        clrText = Me.ColorDialog1.Color
    End Sub

    Private Sub BtnTextBg_Click(sender As System.Object, e As System.EventArgs) Handles BtnTextBg.Click
        ColorDialog1.ShowDialog()
        clrTextBg = Me.ColorDialog1.Color
    End Sub

    Private Sub btnSelAudio_Click(sender As System.Object, e As System.EventArgs) Handles btnSelAudio.Click
        Dim idur As Double


        OpenFileDialog1.Filter = "All Files (*.*)|*.*|FLV (*.flv*.f4v)|*.flv;*.f4v|Flash (*.swf)|*.swf|AVCHD (*.m2ts*.ts)|*.m2ts;*.ts|MPEG2 (*.vob) | *.vob|QuickTime (*.mov) | *.mov|MP4 (*.mp4) | *.mp4|Divx (*.divx)|*.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|mpg (*.mpg) | *.mpg|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif "


        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            txtAudio1.Text = OpenFileDialog1.FileName

            AxVideoEdit1.InfoLoadMedia(txtAudio1.Text)


            Me.txtAudioStart1.Text = CStr(0)

            idur = System.Math.Round(AxVideoEdit1.InfoDuration, 2)

            Me.txtAudioStop1.Text = idur
        Else
            txtAudio1.Text = ""
        End If
    End Sub

    Private Sub cmdgetaudiotrackinfo_Click(sender As System.Object, e As System.EventArgs) Handles cmdgetaudiotrackinfo.Click
        AxVideoEdit1.AMStreamLoadMediaFile(txtVideo1.Text)
        txttotalaudiotrack.Text = AxVideoEdit1.AMStreamAudioTracks

        cboaudiotrackname.Items.Clear()

        If txttotalaudiotrack.Text > 0 Then

            For i = 0 To txttotalaudiotrack.Text - 1

                cboaudiotrackname.Items.Add(AxVideoEdit1.AMStreamGetAudioTrackName(i))

            Next

            If cboaudiotrackname.Items.Count > 0 Then cboaudiotrackname.SelectedIndex = 0
        Else


            ' this video format does support get multi audio track, so only one track only
            cboaudiotrackname.Items.Add("Track 1")
            cboaudiotrackname.SelectedIndex = 0
            txttotalaudiotrack.Text = 1


        End If
    End Sub

    Private Sub GroupBox5_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub txttotalaudiotrack_TextChanged(sender As System.Object, e As System.EventArgs) Handles txttotalaudiotrack.TextChanged

    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub cboaudiotrackname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboaudiotrackname.SelectedIndexChanged

    End Sub

    Private Sub cboGPU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGPU.SelectedIndexChanged
        If cboGPU.SelectedIndex = 1 Then
            cbonvidapreset.Enabled = True
            cbopreset.Enabled = False
        Else
            cbonvidapreset.Enabled = False
            cbopreset.Enabled = True

        End If
    End Sub

    Private Sub cbonvidapreset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbonvidapreset.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cboGPU.SelectedIndex = AxVideoEdit1.MP4DetectGPU()
    End Sub
End Class
