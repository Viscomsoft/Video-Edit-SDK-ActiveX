using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        //3 Modes START,STOP,PAUSE
        public string strMode;
        short stretchMode;
        public ProgressForm progressForm;
        Color clrTextBgColor;
        Color clrTextColor;
        Color clrTranColor;
        Color clrTranImageColor;
        Color clrGifTransparentColor;


        public Form1()
        {
            InitializeComponent();
            this.RefreshOutFormat(0);
        }

        public uint Color2Uint32(Color clr)
        {

            int t;
            byte[] a;

            t = ColorTranslator.ToOle(clr);

            a = BitConverter.GetBytes(t);

            return BitConverter.ToUInt32(a, 0);

        }

        private void RefreshOutFormat(int intTab)
        {
            //AVI
            if (intTab == 0)
            {
                this.videoCompressorComboBox.Enabled = this.useVideoCompCheckBox.Checked;
                this.audioCompressorComboBox.Enabled = this.audioCompCheckBox.Checked;
            }

            //WMV
            if (intTab == 2)
            {
                this.wMVComboBox.Enabled = true;
            }
            if (intTab == 7)
            {
                if (cboMPEGType.Text == "MPEG1" || cboMPEGType.Text == "MPEG2")
                {
                 this.cboMPEGFrameRate.Enabled = true;
                 this.cboMPEGAudioSampleRate.Enabled = true;
                 this.mpegAudioBitrate.Enabled = true;
                 this.mpegAudioChannel.Enabled = true;
                 this.mpegHeight.Enabled = true;
                 this.mpegVideoBitrate.Enabled = true;
                 this.mpegWidth.Enabled = true;
                }
            }
            if (intTab == 9)
            {
                this.gifButtonColor.Enabled = this.chkGifOutputQuality.Checked;
            }

        }

        private void StopVideo()
        {
            this.axVideoEdit1.Stop();
            this.strMode = "STOP";
            this.pauseButton.Enabled = false;
            this.stopButton.Enabled = false;
            this.useOverlayCheckBox.Enabled = true;
            this.cboaudiotrackname.Enabled = true;

        }

        private void gpAudioCodecComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.gpAudioSampleRateTextBox.Enabled = (this.gpAudioCodecComboBox.SelectedIndex == 1);
        }

      

      
     
       
       
        private void audioCompCheckBox_Click(object sender, EventArgs e)
        {
            this.axVideoEdit1.UseAudioCompressor = this.audioCompCheckBox.Checked;
            this.audioCompressorComboBox.Enabled = this.audioCompCheckBox.Checked;
        }

        private void useVideoCompCheckBox_Click(object sender, EventArgs e)
        {
            this.axVideoEdit1.UseVideoCompressor = this.useVideoCompCheckBox.Checked;
            this.videoCompressorComboBox.Enabled = this.useVideoCompCheckBox.Checked;
            this.videoCompressorButton.Enabled = this.useVideoCompCheckBox.Checked;
        }

        private void useWMV9CheckBox_Click(object sender, EventArgs e)
        {
            this.wMVComboBox.Enabled = !this.useWMV9CheckBox.Checked;
            this.wMV9ComboBox.Enabled = this.useWMV9CheckBox.Checked;
        }

     
      

    

        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.strMode = "PAUSE";
            this.axVideoEdit1.Pause();
        }
        private void overlaySetting()
        {
            axVideoEdit1.OverlaySetTextBgColor(clrTextBgColor.R, clrTextBgColor.G, clrTextBgColor.B, Convert.ToInt16(txtalphabg.Text));
            axVideoEdit1.OverlaySetTextColor(clrTextColor.R, clrTextColor.G, clrTextColor.B, Convert.ToInt16(txtalphatext.Text));

        
            if(chkScrollEffect.Checked)
                axVideoEdit1.OverlaySetState(0);
            else
                axVideoEdit1.OverlaySetState(1);

            axVideoEdit1.OverlaySetSpeed(Convert.ToInt16(txtscrollspeed.Text));
            axVideoEdit1.OverlaySetTextScrollDir((short)cboscrolldir.SelectedIndex);

            axVideoEdit1.OverlaySetTextShadow(chkshadoweffect.Checked);

            axVideoEdit1.OverlaySetFont(fontNameComboBox.Text,Convert.ToInt16(fontSizeComboBox.Text), (short)fontStyleComboBox.SelectedIndex);


            axVideoEdit1.OverlayAddText(textBox1.Text + Environment.NewLine + textBox2.Text, Convert.ToInt16(leftTextBox.Text), Convert.ToInt16(topTextBox.Text), Convert.ToInt16(txtTextStart.Text), Convert.ToInt16(txtTextEnd.Text), chktextfade.Checked);
            
            if (RadioButtonImage.Checked)
              axVideoEdit1.OverlayAddImage(imageTextBox.Text, Convert.ToInt16(imageLeftTextBox.Text), Convert.ToInt16(imageTopTextBox.Text), clrTranImageColor.R, clrTranImageColor.G, clrTranImageColor.B, Convert.ToInt16(txtImageStart.Text), Convert.ToInt16(txtImageEnd.Text), chkimagefade.Checked);
            else
                axVideoEdit1.OverlayAddPNGImage(PNGTextBox.Text, Convert.ToInt16(imageLeftTextBox.Text), Convert.ToInt16(imageTopTextBox.Text),Convert.ToInt16(txtImageStart.Text), Convert.ToInt16(txtImageEnd.Text), chkimagefade.Checked);
        

        }

        private Boolean HaveVideoStream()
        {
        axVideoEdit1.InfoLoadMedia(videoTextBox.Text);

        if (axVideoEdit1.InfoVideoStreamCount !=0)
            return true;
        else
            if(axVideoEdit1.InfoMediaContainer=="JPEG" || axVideoEdit1.InfoMediaContainer=="Bitmap" ||axVideoEdit1.InfoMediaContainer=="PNG" ||axVideoEdit1.InfoMediaContainer=="GIF" )
                return true;
            else
                return false;

        }

        private Boolean HaveAudioStream()
        {
            axVideoEdit1.InfoLoadMedia(audioTextBox.Text);

            if (axVideoEdit1.InfoAudioStreamCount != 0)
                return true;
            else
                    return false;

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.StopVideo();

            try
            {
                if (this.videoTextBox.Text == "")
                {
                    return;
                }

                if (this.strMode == "PAUSE")
                {
                    this.axVideoEdit1.Play();
                    return;
                }

                if (this.strMode == "STOP")
                {
                    this.axVideoEdit1.VideoSampleSize = 32;


                     //2014 June updated
                    axVideoEdit1.InfoLoadMedia(videoTextBox.Text);
                    int iwidth = axVideoEdit1.InfoMediaWidth;
                    int iheight = axVideoEdit1.InfoMediaHeight;
                
                    if (iwidth == 0) iwidth = 320;
                    if (iheight == 0) iheight = 240;

                    this.axVideoEdit1.OutputFileWidth = (short)iwidth;
                    this.axVideoEdit1.OutputFileHeight = (short)iheight;

                    this.axVideoEdit1.UseOverlay = this.useOverlayCheckBox.Checked;
	    this.axVideoEdit1.VideoSampleSize = 32; 	
                    this.axVideoEdit1.InitControl();
                    //Add video track

                    if (HaveVideoStream())
                    {
                        if (this.videoTextBox.Text != "")
                        {
                            this.axVideoEdit1.AddVideo(this.videoTextBox.Text, Convert.ToDouble(this.videoStartTextBox.Text), Convert.ToDouble(this.videoStopTextBox.Text), stretchMode);
                            this.strMode = "PLAY";
                        }
                    }


                    //Add audio track
                    if (HaveAudioStream())
                    {
                        if (this.audioTextBox.Text != "")
                        {
                            bool result = this.axVideoEdit1.AddAudio(this.audioTextBox.Text, Convert.ToDouble(this.audioStartTextBox.Text), Convert.ToDouble(this.audioStopTextBox.Text));
                            if (!result)
                            {
                                MessageBox.Show("Audio format fail");
                                return;
                            }
                        }
                    }
                    
                    overlaySetting();

                    if (cboaudiotrackname.Items.Count > 0)
                        axVideoEdit1.AMStreamSelectAudioTrack(videoTextBox.Text, (short)cboaudiotrackname.SelectedIndex);
   


                    this.axVideoEdit1.Preview();
                    cboaudiotrackname.Enabled = false;
                    this.useOverlayCheckBox.Enabled = false;
                    this.pauseButton.Enabled = true;
                    this.stopButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

     

        private void convertButton_Click(object sender, EventArgs e)
        {
            //File Resize or Stretche checking
            this.stretchMode = 2;

            axVideoEdit1.InfoLoadMedia(videoTextBox.Text);
            int iWidth = axVideoEdit1.InfoMediaWidth;
            int iHeight = axVideoEdit1.InfoMediaHeight;
          double iFrameRate = axVideoEdit1.InfoFrameRate;
            
            if ((iWidth == 0) || (iHeight == 0))
            {
                iWidth = 320;
                iHeight = 240;
            }

            axVideoEdit1.FrameRate = (float)iFrameRate;

            string strFilter = string.Empty;


            //Special handle of AVI format
            if (this.ssTabControl.SelectedIndex == 0)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.AVI;
                strFilter = "Avi File (*.avi)|*.avi";

                this.axVideoEdit1.VideoCompressor = (short)this.videoCompressorComboBox.SelectedIndex;
                this.axVideoEdit1.AudioCompressor = (short)this.audioCompressorComboBox.SelectedIndex;
                this.axVideoEdit1.AVIMP3Bitrate = Convert.ToInt16(this.txtavimp3bitrate.Text);
                this.axVideoEdit1.AVIMP3SampleRate = Convert.ToInt32(this.txtavimp3samplerate.Text);

            }

            //Special handle of WMV format
            if (this.ssTabControl.SelectedIndex == 1)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.WMV;

                strFilter = "wmv File (*.wmv)|*.wmv";

                if (this.useWMV9CheckBox.Checked)
                {
                    string strPath = "C:\\Program Files (x86)\\VideoEdit Gold ActiveX Control\\Profiles";
                    switch (this.wMV9ComboBox.SelectedIndex)
                    {
                        case 0:
                            strPath = strPath + "\\Dial-up Modems (28,8 kbps).prx";
                            break;
                        case 1:
                            strPath = strPath + "\\Dial-up Modems (56 kbps).prx";
                            break;
                        case 2:
                            strPath = strPath + "\\Dial-up Modems or LAN (28,8 to 100 kbps).prx";
                            break;
                        case 3:
                            strPath = strPath + "\\LAN, Cable Modem, or xDSL  (100 to 768kbps).prx";
                            break;
                        case 4:
                            strPath = strPath + "\\Local Network (100 kbps).prx";
                            break;
                        case 5:
                            strPath = strPath + "\\Local Network (256 kbps).prx";
                            break;
                        case 6:
                            strPath = strPath + "\\Local Network (384 kbps).prx";
                            break;
                        case 7:
                            strPath = strPath + "\\Local Network (768 kbps).prx";
                            break;
                        case 8:
                            strPath = strPath + "\\Pocket PC (225kbps).prx";
                            break;
                    }
                    this.axVideoEdit1.WMVCustomFileName = strPath;
                }
                else
                {
                    string strWMV = this.wMVComboBox.Text;
                    short wMVIndex = this.axVideoEdit1.WMVProfiles.FindWMVProfile(strWMV);
                    if (wMVIndex != -1)
                    {
                        this.axVideoEdit1.WMVProfile = wMVIndex;
                    }
                }
            }


            if (this.ssTabControl.SelectedIndex == 2)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.AVCHD;
                strFilter = "Avchd File (*.m2ts)|*.m2ts||";
                switch(this.cboAvchdVideoBitrate.SelectedIndex)
                {
                    case 0:
                        this.axVideoEdit1.AVCHDVideoBitrate = 256;
                        break;
                    case 1:
                        this.axVideoEdit1.AVCHDVideoBitrate = 384;
                        break;
                    case 2:
                        this.axVideoEdit1.AVCHDVideoBitrate = 512;
                        break;
                    case 3:
                        this.axVideoEdit1.AVCHDVideoBitrate = 768;
                        break;
                    case 4:
                        this.axVideoEdit1.AVCHDVideoBitrate = 1024;
                        break;
                    case 5:
                        this.axVideoEdit1.AVCHDVideoBitrate = 4096;
                        break;
                }
                switch (this.cboAvchdAudioBitrate.SelectedIndex)
                { 
                    case 0:
                        this.axVideoEdit1.AVCHDAudioBitrate = 48;
                        break;
                    case 1:
                        this.axVideoEdit1.AVCHDAudioBitrate = 96;
                        break;
                    case 2:
                        this.axVideoEdit1.AVCHDAudioBitrate = 128;
                        break;
                    case 3:
                        this.axVideoEdit1.AVCHDAudioBitrate = 256;
                        break;
                }
                switch (this.cboAvchdFrameRate.SelectedIndex)
                { 
                    case 0:
                        this.axVideoEdit1.AVCHDVideoFrameRate = 23.97;
                        break;
                    case 1:
                        this.axVideoEdit1.AVCHDVideoFrameRate = 24;
                        break;
                    case 2:
                        this.axVideoEdit1.AVCHDVideoFrameRate = 25;
                        break;
                    case 3:
                        this.axVideoEdit1.AVCHDVideoFrameRate = 29.97;
                        break;
                }
                switch (this.cboAvchdAudioSampleRate.SelectedIndex)
                { 
                    case 0:
                        this.axVideoEdit1.AVCHDAudioSampleRate = 44100;
                        break;
                    case 1:
                        this.axVideoEdit1.AVCHDAudioSampleRate = 48000;
                        break;
                }
                switch (this.cboAvchdWidthandHeight.SelectedIndex)
                { 
                    case 0:
                        this.axVideoEdit1.AVCHDWidth = 720;
                        this.axVideoEdit1.AVCHDHeight = 480;
                        break;
                    case 1:
                        this.axVideoEdit1.AVCHDWidth = 720;
                        this.axVideoEdit1.AVCHDHeight = 576;
                        break;
                    case 2:
                        this.axVideoEdit1.AVCHDWidth = 1280;
                        this.axVideoEdit1.AVCHDHeight = 720;
                        break;
                    case 3:
                        this.axVideoEdit1.AVCHDWidth = 1920;
                        this.axVideoEdit1.AVCHDHeight = 1080;
                        break;
                 }
            }

            if (this.ssTabControl.SelectedIndex == 3)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.PSP;
                strFilter = "PSP File (*.mp4)|*.mp4||";
                this.axVideoEdit1.PSPProfile = (short)this.pspComboBox.SelectedIndex;

                this.axVideoEdit1.OutputFileWidth =(short) iWidth;
                this.axVideoEdit1.OutputFileHeight = (short)iHeight;
            }

            if (this.ssTabControl.SelectedIndex == 4)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.FLV;
                strFilter = "FLV File (*.flv)|*.flv||";
                this.axVideoEdit1.FLVAudioBitrate = Convert.ToInt32(this.flvAudioBitrateTextBox.Text);
                this.axVideoEdit1.FLVAudioChannels = Convert.ToInt16(this.flvAudioChannelTextBox.Text);
                this.axVideoEdit1.FLVAudioSampleRate = Convert.ToInt32(this.flvAudioSampleRateTextBox.Text);
                this.axVideoEdit1.FLVVideoBitrate = Convert.ToInt32(this.flvVideoBitrateTextBox.Text);
                this.axVideoEdit1.OutputFileHeight = (short)iHeight;
                this.axVideoEdit1.OutputFileWidth = (short)iWidth;
            }

            if (this.ssTabControl.SelectedIndex == 5)
            {
                this.axVideoEdit1.OutputType =  VIDEOEDITLib.MYOUTPUT.VIDEO3GP;
                strFilter = "3GP File (*.3gp)|*.3gp||";
                this.axVideoEdit1.Video3GPVideoCodec =(short) this.gpVideoCodecComboBox.SelectedIndex;
                this.axVideoEdit1.Video3GPAudioCodec = (short)this.gpAudioCodecComboBox.SelectedIndex;
                this.axVideoEdit1.Video3GPAudioSampleRate = Convert.ToInt32(this.gpAudioSampleRateTextBox.Text);
                this.axVideoEdit1.OutputFileHeight = (short)iHeight;
                this.axVideoEdit1.OutputFileWidth = (short)iWidth;
            }


            if (this.ssTabControl.SelectedIndex == 6)
            {
                this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MP4;
                strFilter = "MP4 File (*.mp4)|*.mp4||";

                this.axVideoEdit1.MP4VideoBitrate = Convert.ToInt32(this.mp4VideoBitrate.Text);
                this.axVideoEdit1.MP4AudioBitrate = Convert.ToInt32(this.mp4AudioBitrate.Text);
                this.axVideoEdit1.MP4AudioChannels = Convert.ToInt16(this.mp4AudioChannel.Text);
                this.axVideoEdit1.MP4AudioSampleRate = Convert.ToInt32(this.mp4AudioSampleRate.Text);
                this.axVideoEdit1.MP4Framerate = Convert.ToInt32(this.mp4FrameRate.Text);
                this.axVideoEdit1.MP4Width = Convert.ToInt16(this.mp4Width.Text);
                this.axVideoEdit1.MP4Height = Convert.ToInt16(this.mp4Height.Text);
                this.axVideoEdit1.MP4AspectRatio = (short)this.cboMP4AspectRadio.SelectedIndex;
                this.axVideoEdit1.MP4H264Preset = (short)this.cbopreset.SelectedIndex;
                this.axVideoEdit1.OutputFileWidth = (short)iWidth;
                this.axVideoEdit1.OutputFileHeight = (short)iHeight;
                this.axVideoEdit1.MP4GPUCodec = (short)cboGPU.SelectedIndex;
                this.axVideoEdit1.MP4NVIDAPreset = (short)cbonvidapreset.SelectedIndex;


            }

            if (this.ssTabControl.SelectedIndex == 7)
            {
                //this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT;
                switch (this.cboMPEGType.SelectedIndex)
                { 
                    case 0:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.VCD_PAL;
                        break;
                    case 1:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.VCD_NTSC;
                        break;
                    case 2:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.SVCD_PAL;
                        break;
                    case 3:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.SVCD_NTSC;
                        break;
                    case 4:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.DVD_PAL;
                        break;
                    case 5:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.DVD_NTSC;
                        break;
                    case 6:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MPEG1;
                        switch (this.cboMPEGFrameRate.SelectedIndex)
                        { 
                            case 0:
                                this.axVideoEdit1.FrameRate = (float)23.976;
                                break;
                            case 1:
                                this.axVideoEdit1.FrameRate = 24;
                                break;
                            case 2:
                                this.axVideoEdit1.FrameRate = 25;
                                break;
                            case 3:
                                this.axVideoEdit1.FrameRate = (float)29.97;
                                break;
                            case 4:
                                this.axVideoEdit1.FrameRate = 30;
                                break;
                            case 5:
                                this.axVideoEdit1.FrameRate = 50;
                                break;
                            case 6:
                                this.axVideoEdit1.FrameRate = (float)59.94;
                                break;
                        }
                        switch (this.cboMPEGAudioSampleRate.SelectedIndex)
                        { 
                            case 0:
                                this.axVideoEdit1.MPEGAudioSampleRate = 32000;
                                break;
                            case 1:
                                this.axVideoEdit1.MPEGAudioSampleRate = 44100;
                                break;
                            case 2:
                                this.axVideoEdit1.MPEGAudioSampleRate = 48000;
                                break;
                        }
                        this.axVideoEdit1.MPEGAudioChannels = Convert.ToInt16(this.mpegAudioChannel.Text);
                        this.axVideoEdit1.MPEGVideoBitrate = Convert.ToInt32(this.mpegVideoBitrate.Text);
                        this.axVideoEdit1.MPEGAudioBitrate = Convert.ToInt32(this.mpegAudioBitrate.Text);
                        this.axVideoEdit1.MPEGWidth = Convert.ToInt16(this.mpegWidth.Text);
                        this.axVideoEdit1.MPEGHeight = Convert.ToInt16(this.mpegHeight.Text);
                        break;
                    case 7:
                        this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.MPEG2;
                        switch (this.cboMPEGFrameRate.SelectedIndex)
                        { 
                            case 0:
                                this.axVideoEdit1.FrameRate = (float)23.976;
                                break;
                            case 1:
                                this.axVideoEdit1.FrameRate = 24;
                                break;
                            case 2:
                                this.axVideoEdit1.FrameRate = 25;
                                break;
                            case 3:
                                this.axVideoEdit1.FrameRate = (float)29.97;
                                break;
                            case 4:
                                this.axVideoEdit1.FrameRate = 30;
                                break;
                            case 5:
                                this.axVideoEdit1.FrameRate = 50;
                                break;
                            case 6:
                                this.axVideoEdit1.FrameRate = (float)59.94;
                                break;
                        }
                        switch (this.cboMPEGAudioSampleRate.SelectedIndex)
                        { 
                            case 0:
                                this.axVideoEdit1.MPEGAudioSampleRate = 32000;
                                break;
                            case 1:
                                this.axVideoEdit1.MPEGAudioSampleRate = 44100;
                                break;
                            case 2:
                                this.axVideoEdit1.MPEGAudioSampleRate = 48000;
                                break;
                        }
                        this.axVideoEdit1.MPEGAudioChannels = Convert.ToInt16(this.mpegAudioChannel.Text);
                        this.axVideoEdit1.MPEGVideoBitrate = Convert.ToInt32(this.mpegVideoBitrate.Text);
                        this.axVideoEdit1.MPEGAudioBitrate = Convert.ToInt32(this.mpegAudioBitrate.Text);
                        this.axVideoEdit1.MPEGWidth = Convert.ToInt16(this.mpegWidth.Text);
                        this.axVideoEdit1.MPEGHeight = Convert.ToInt16(this.mpegHeight.Text);
                        break;
                }
                strFilter = "MPEG File (*.mpg)|*.mpg||";
            }

            if (this.ssTabControl.SelectedIndex == 8)
            {
                this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.RMVB;
                strFilter = "Rmvb File (*.rmvb)|*.rmvb||";

                this.axVideoEdit1.RMVideoFrameRate = (short)Convert.ToInt32(this.rmvbFrameRate.Text);
                this.axVideoEdit1.RMWidth = Convert.ToInt16(this.rmvbWidth.Text);
                this.axVideoEdit1.RMHeight = Convert.ToInt16(this.rmvbHeight.Text);
                this.axVideoEdit1.RMVideoMode = (short)this.cboRmvbVideoMode.SelectedIndex;
                this.axVideoEdit1.RMAudioMode = (short)this.cboRmvbAudioMode.SelectedIndex;
                this.axVideoEdit1.RMProfile = (short)this.cboRMProfile.SelectedIndex;
            }

            if (this.ssTabControl.SelectedIndex == 9)
            {
                this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.ANIMATED_GIF;
                strFilter = "Animate GIF File (*.gif)|*.gif||";
                
                switch(this.cboGifMaxColor.SelectedIndex)
                {
                    case 0:
                        this.axVideoEdit1.AniGIFMaxColor = 16;
                        break;
                    case 1:
                        this.axVideoEdit1.AniGIFMaxColor = 32;
                        break;
                    case 2:
                        this.axVideoEdit1.AniGIFMaxColor = 64;
                        break;
                    case 3:
                        this.axVideoEdit1.AniGIFMaxColor = 128;
                        break;
                    case 4:
                        this.axVideoEdit1.AniGIFMaxColor = 256;
                        break;
                }

                this.axVideoEdit1.AniGIFQuantizer = (short)this.cboGifQuantizer.SelectedIndex;
                this.axVideoEdit1.AniGIFLoop = Convert.ToInt16(this.gifLoopCount.Text);
                this.axVideoEdit1.AniGIFTransColor = clrGifTransparentColor;
                this.axVideoEdit1.AniGIFWidth = Convert.ToInt16(this.gifWidth.Text);
                this.axVideoEdit1.AniGIFHeight = Convert.ToInt16(this.gifHeight.Text);
                this.axVideoEdit1.FrameRate = Convert.ToInt32(this.gifFrameRate.Text);

            }

            if (this.ssTabControl.SelectedIndex == 10)
            {
                this.axVideoEdit1.OutputType = VIDEOEDITLib.MYOUTPUT.QT;
                strFilter = "QuickTime File (*.mov)|*.mov";
                this.axVideoEdit1.QTAudioChannels = (short)(this.cboMovAudioChannel.SelectedIndex);
                this.axVideoEdit1.QTVideoCompressor = (short)this.cboMovVideoCom.SelectedIndex;
                this.axVideoEdit1.QTAudioCompressor = (short)this.cboMovAudioCom.SelectedIndex;
     
               this.axVideoEdit1.QTAudioSampleRate = Convert.ToInt32(this.movAudioSampleRate.Text);

                this.axVideoEdit1.OutputFileWidth = (short)iWidth;
                this.axVideoEdit1.OutputFileHeight = (short)iHeight;

            }
              
            this.axVideoEdit1.UseOverlay = this.useOverlayCheckBox.Checked;

            this.axVideoEdit1.VideoSampleSize = 32;
            this.axVideoEdit1.InitControl();

            //Add video track
            if (HaveVideoStream())
            if (!string.IsNullOrEmpty(this.videoTextBox.Text))
            {
                this.axVideoEdit1.AddVideo(this.videoTextBox.Text, Convert.ToDouble(this.videoStartTextBox.Text), Convert.ToDouble(this.videoStopTextBox.Text), this.stretchMode);
            }

            //Add audio track
            if (HaveAudioStream())
            if (!string.IsNullOrEmpty(this.audioTextBox.Text))
            {
                bool result = this.axVideoEdit1.AddAudio(this.audioTextBox.Text, Convert.ToDouble(this.audioStartTextBox.Text), Convert.ToDouble(this.audioStopTextBox.Text));
                if (!result)
                {
                    MessageBox.Show("Audio format fail");
                    this.StopVideo();
                    return;
                }
            }

            //Save is Failed
            if (this.axVideoEdit1.GetTotalDuration() == 0)
            {
                MessageBox.Show("Timeline empty,cannot process");
                this.StopVideo();
                return;
            }
            overlaySetting();

            if (cboaudiotrackname.Items.Count > 0)
                axVideoEdit1.AMStreamSelectAudioTrack(videoTextBox.Text, (short)cboaudiotrackname.SelectedIndex);
   

            if (this.ssTabControl.SelectedIndex == 3)//psp save to specific folder
            {
                if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string strSelPath = this.folderBrowserDialog.SelectedPath;

                    string strPSPFileName = strSelPath + "\\M4V00001.MP4";
                    string strTHMFileName = strSelPath + "\\M4V00001.THM";

                    //create thumbnail
                    this.axVideoEdit1.GetFrameBySize(this.videoTextBox.Text, 0, strTHMFileName, 160, 120, 1);

                    bool result = this.axVideoEdit1.Save(strPSPFileName);
                }
            }
            else
            {
                this.saveFileDialog.Filter = strFilter;
                if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    bool result = this.axVideoEdit1.Save(this.saveFileDialog.FileName);

                }
            }
        }

        private void videoCompressorButton_Click(object sender, EventArgs e)
        {
            bool result = this.axVideoEdit1.VideoCompressors.ShowPropertyPage((short)this.videoCompressorComboBox.SelectedIndex);
            if (!result)
            {
                MessageBox.Show("No property page");
            }
        }

        private void videoButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog.Filter = "All Files (*.*)|*.*|AVCHD (*.m2ts*.m2t,*,mts,*.ts)|*.m2ts;*.m2t;*.mts;*.ts|Flash (*.swf)|*.swf|FLV (*.flv)|*.flv|QuickTime (*.mov) | *.mov|MP4 (*.mp4) | *.mp4|Divx (*.divx) | *.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|mpg (*.mpg) | *.mpg|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif ";

                if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    //Actually Save the File
                    this.videoTextBox.Text = this.openFileDialog.FileName;

                     axVideoEdit1.InfoLoadMedia (videoTextBox.Text);
      
                    this.videoStartTextBox.Text = "0";
                    double iDur = Math.Round(this.axVideoEdit1.InfoDuration, 2);

                    //if 0, this may image file, so set duration
                    if (iDur == 0)
                    {
                        this.videoStopTextBox.Text = "1";
                    }
                    else
                    {
                        this.videoStopTextBox.Text = iDur.ToString();
                        //Set Audio detail
                        this.audioStartTextBox.Text = "0";
                        this.audioStopTextBox.Text = iDur.ToString();
                        this.audioTextBox.Text = this.videoTextBox.Text;
                    }
                }

                cboaudiotrackname.Items.Clear();
                this.StopVideo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.videoTextBox.Text = "";
            }
        }

        private void audioButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog.Filter = "All Files (*.*)|*.*|AVCHD (*.m2ts*.m2t,*,mts,*.ts)|*.m2ts;*.m2t;*.mts;*.ts|Flash (*.swf)|*.swf|FLV (*.flv)|*.flv|QuickTime (*.mov) | *.mov|MP4 (*.mp4) | *.mp4|Divx (*.divx) | *.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|mpg (*.mpg) | *.mpg|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif ";

                if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.audioTextBox.Text = this.openFileDialog.FileName;

                    axVideoEdit1.InfoLoadMedia(audioTextBox.Text);
      
                    this.audioStartTextBox.Text = "0";

                    double iDur = Math.Round(this.axVideoEdit1.InfoDuration , 2);

                    this.audioStopTextBox.Text = iDur.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.audioTextBox.Text = "";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.StopVideo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.clrTextColor = Color.FromArgb(255, 255, 255);
            this.clrTextBgColor = Color.FromArgb(0, 0, 255);
            this.clrTranColor = Color.FromArgb(0, 0, 0);
            clrTranImageColor = Color.FromArgb(0, 0, 0);


            cboGPU.Items.Add("None");
            cboGPU.Items.Add("Nvidia");
            cboGPU.Items.Add("AMD");
            cboGPU.Items.Add("Intel");
            cboGPU.SelectedIndex = 0;

            cbonvidapreset.Items.Add("slow");
            cbonvidapreset.Items.Add("medium");
            cbonvidapreset.Items.Add("fast");
            cbonvidapreset.Items.Add("high performance");
            cbonvidapreset.Items.Add("high quality");
            cbonvidapreset.Items.Add("bluray disk");
            cbonvidapreset.Items.Add("low latency");
            cbonvidapreset.Items.Add("low latency high quality");
            cbonvidapreset.Items.Add("low latency high performance");
            cbonvidapreset.Items.Add("lossless");
            cbonvidapreset.Items.Add("lossless high performance");
            cbonvidapreset.SelectedIndex = 3;



            this.strMode = "STOP";

            cbopreset.Items.Add("superfast");
            cbopreset.Items.Add("veryfast");
            cbopreset.Items.Add("faster");
            cbopreset.Items.Add("fast");
            cbopreset.Items.Add("medium");
            cbopreset.Items.Add("slow");
            cbopreset.Items.Add("slower");
            cbopreset.Items.Add("veryslow");
            cbopreset.SelectedIndex = 0;
           

            this.pspComboBox.Items.AddRange(new string[]{"MPEG-4/320x240/29.97FPS/256Kbit/AAC/48Kbit", "MPEG-4/320x240/29.97FPS/256Kbit/AAC/96Kbit",
"MPEG-4/320x240/29.97FPS/384Kbit/AAC/96Kbit", "MPEG-4/320x240/29.97FPS/512Kbit/AAC/96Kbit", "MPEG-4/320x240/29.97FPS/512Kbit/AAC/128Kbit",
"MPEG-4/320x240/29.97FPS/768Kbit/AAC/128Kbit","H.264/320x240/29.97FPS/256Kbit/AAC/48Kbit", "H.264/320x240/29.97FPS/256Kbit/AAC/96Kbit",
"H.264/320x240/29.97FPS/512Kbit/AAC/96Kbit","H.264/320x240/29.97FPS/512Kbit/AAC/128Kbit", "H.264/320x240/29.97FPS/768Kbit/AAC/128Kbit"});
            this.pspComboBox.SelectedIndex = 0;

            this.gpVideoCodecComboBox.Items.AddRange(new string[] { "MPEG4", "H.263" });
            this.gpVideoCodecComboBox.SelectedIndex = 0;

            this.gpAudioCodecComboBox.Items.AddRange(new string[] { "AAC", "AMR" });
            this.gpAudioCodecComboBox.SelectedIndex = 0;

            this.cboMP4AspectRadio.Items.AddRange(new string[] { "4:3" , "16:9" });
            this.cboMP4AspectRadio.SelectedIndex = 0;

            this.cboAvchdAudioBitrate.Items.AddRange(new string[] { "48", "96" , "128" , "256"});
            this.cboAvchdAudioBitrate.SelectedIndex = 1;

            this.cboAvchdAudioSampleRate.Items.AddRange(new string[] { "44100", "48000" });
            this.cboAvchdAudioSampleRate.SelectedIndex = 0;

            this.cboAvchdFrameRate.Items.AddRange(new string[] { "23.97", "24", "25", "29.97" });
            this.cboAvchdFrameRate.SelectedIndex = 2;

            this.cboAvchdVideoBitrate.Items.AddRange(new string[] { "256", "384", "512", "768" ,"1024" , "4096"});
            this.cboAvchdVideoBitrate.SelectedIndex = 0;

            this.cboAvchdWidthandHeight.Items.AddRange(new string[] { "720X480", "720X576", "1280X720", "1920X1080" });
            this.cboAvchdWidthandHeight.SelectedIndex = 0;


            this.cboMPEGType.Items.AddRange(new string[] { "VCD PAL", "VCD NTSC", "SVCD PAL", "SVCD NTSC", "DVD PAL", "DVD NTSC", "MPEG1", "MPEG2" });
            this.cboMPEGType.SelectedIndex = 0;

            this.cboMPEGFrameRate.Items.AddRange(new string[] { "23.976", "24", "25", "29.97", "30", "50" , "59.94"});
            this.cboMPEGFrameRate.SelectedIndex = 0;

            this.cboMPEGAudioSampleRate.Items.AddRange(new string[] { "32000", "44100", "48000" });
            this.cboMPEGAudioSampleRate.SelectedIndex = 1;

            this.cboGifMaxColor.Items.AddRange(new string[] { "16", "32", "64","128","256" });
            this.cboGifMaxColor.SelectedIndex = 4;

            this.cboGifQuantizer.Items.AddRange(new string[] { "Basic", "Octree", "Mediancut", "NeuralNet" });
            this.cboGifQuantizer.SelectedIndex = 1;

            this.cboMovVideoCom.Items.AddRange(new string[] { "Animation Codec", "BMP Codec", "ComponentVideo Codec", "H261 Codec" , "H263 Codec" ,"H264 Codec","JPEG Codec","MPEG4 Visual Codec","Sorenson3 Codec","Sorenson Codec"});
            this.cboMovVideoCom.SelectedIndex = 8;

            this.cboMovAudioCom.Items.AddRange(new string[] { "24BitFormat", "32BitFormat", "ALawCompression", "IMACompression" ,"MACE3Compression","MACE6Compression","ULawCompression" });
            this.cboMovAudioCom.SelectedIndex = 0;
            
            this.cboMovAudioChannel.Items.AddRange(new string[] { "Mono", "Stereo" });
            this.cboMovAudioChannel.SelectedIndex = 1;

            this.cboRmvbVideoMode.Items.AddRange(new string[] { "Normal Mode", "Smooth Mode" ,"Sharp Mode","Slide Mode"});
            this.cboRmvbVideoMode.SelectedIndex = 0;

            this.cboRmvbAudioMode.Items.AddRange(new string[] { "Music Mode", "Voice Mode" });
            this.cboRmvbAudioMode.SelectedIndex = 0;

            string strCurPath = System.Windows.Forms.Application.ExecutablePath;
         
            
            int iIndex = strCurPath.IndexOf("\\Examples");
            string strPath = strCurPath;
            if (iIndex != -1)
            {
                strPath = strCurPath.Substring(0, iIndex) + "\\rmdll";
            }


            this.axVideoEdit1.RMLoadProfiles(strPath);
            short rmCount = 0;
            rmCount = this.axVideoEdit1.RMProfilesCount();
            for (short rmprofilesel = 0; rmprofilesel < rmCount; rmprofilesel++)
            {
                string strRmProfile = this.axVideoEdit1.RMProfileName(rmprofilesel);
                this.cboRMProfile.Items.Add(strRmProfile);
                if (this.cboRMProfile.Items.Count > 0)
                {
                    this.cboRMProfile.SelectedIndex = 0;
                }
            }

                for (short videoIndex = 0; videoIndex < this.axVideoEdit1.VideoCompressors.Count; videoIndex++)
                {

                    string strVideoCompName = this.axVideoEdit1.VideoCompressors.FindVideoCompressorName(videoIndex);
                    this.videoCompressorComboBox.Items.Add(strVideoCompName);
                    if (strVideoCompName == "DV Video Encoder")
                        this.videoCompressorComboBox.SelectedIndex = videoIndex;


                }
          


            for (short audioIndex = 0; audioIndex < this.axVideoEdit1.AudioCompressors.Count; audioIndex++)
            {
                string strAudioCompName = this.axVideoEdit1.AudioCompressors.FindAudioCompressorName(audioIndex);
                this.audioCompressorComboBox.Items.Add(strAudioCompName);
                if(strAudioCompName=="PCM")
                    this.audioCompressorComboBox.SelectedIndex = audioIndex;

            }

            
            for (short i = 0; i < this.axVideoEdit1.WMVProfiles.Count; i++)
            {
                if (!this.axVideoEdit1.WMVProfiles.IsAudioOnly(i))
                {
                    this.wMVComboBox.Items.Add(this.axVideoEdit1.WMVProfiles.FindWMVProfileName(i));
                }
            }
            if (this.wMVComboBox.Items.Count > 0)
            {
                this.wMVComboBox.SelectedIndex = 0;
            }

            this.wMV9ComboBox.Items.AddRange(new string[]{"Windows Media Video 9 for Dial-up Modems (28,8 kbps)","Windows Media Video 9 for Dial-up Modems (56 kbps)",
"Windows Media Video 9 for Dial-up Modems or LAN (28,8 to 100 kbps)","Windows Media Video 9 for LAN, Cable Modem, or xDSL  (100 to 768kbps)", "Windows Media Video 9 for Local Network (100 kbps)",
"Windows Media Video 9 for Local Network (256 kbps)", "Windows Media Video 9 for Local Network (384 kbps)","Windows Media Video 9 for Local Network (768 kbps)",
 "Windows Media Video 9 for Pocket PC (225kbps)"});
            this.wMV9ComboBox.SelectedIndex = 0;

   
            cboscrolldir.Items.Add("Up");
            cboscrolldir.Items.Add("Down");
            cboscrolldir.Items.Add("Left");
            cboscrolldir.Items.Add("Right");
            cboscrolldir.SelectedIndex =2;




          
            for (int i = 8; i <= 60; i += 2)
            {
                this.fontSizeComboBox.Items.Add(i.ToString());
            }
            this.fontSizeComboBox.SelectedIndex = 12;

            this.fontStyleComboBox.Items.AddRange(new string[] { "Regular", "Bold", "Italic", "BoldItalic", "Underline" });
            this.fontStyleComboBox.SelectedIndex = 1;

            this.fontNameComboBox.Items.AddRange(new string[] { "Arial", "AirCut", "Arial Black", "Comic Sans MS", "Times New Roman" });
            this.fontNameComboBox.SelectedIndex = 0;

    
          
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            this.axVideoEdit1.AspectRatio = this.aRatioRadioButton.Checked;
        }

     
        private void axVideoEdit1_OnPlaying(object sender, AxVIDEOEDITLib._DVideoEditEvents_OnPlayingEvent e)
        {

            this.lblTime.Text = Math.Round(e.iCurrent, 2).ToString() + " s";

        }

        private void axVideoEdit1_Processing(object sender, AxVIDEOEDITLib._DVideoEditEvents_ProcessingEvent e)
        {
            

            if (this.progressForm == null)
            {
                this.progressForm = new ProgressForm();
                this.progressForm.progressBar1.Maximum = (int)(e.iDuration * 100);
                this.progressForm.cancelButton.Click += new EventHandler(ProgressButton_Click);
                this.progressForm.Show(this);
            }
            else
            {
                this.progressForm.progressBar1.Value = (int)Math.Min(e.iCurPos * 100, e.iDuration * 100);
            }
        }

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            this.axVideoEdit1.Stop();
            this.progressForm.cancelButton.Click -= new EventHandler(ProgressButton_Click);
            this.progressForm.Close();
            this.progressForm = null;
        }

    
     
      
        private void ssTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshOutFormat(this.ssTabControl.SelectedIndex);
        }

        private void solidFontColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.clrTextColor = colorDialog.Color;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.clrTextBgColor = colorDialog.Color;

            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Bitmap File (*.bmp)|*.bmp|JPEG File (*.jpg)|*.jpg|Gif File (*.gif)|*.gif";
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageTextBox.Text=this.openFileDialog.FileName;
            }
        }

        private void iamgeTranColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
               this.clrTranImageColor = colorDialog.Color;

            }
        }

        private void axVideoEdit1_Complete_1(object sender, EventArgs e)
        {
            this.StopVideo();
            if (this.progressForm != null)
            {
                this.progressForm.progressBar1.Value = this.progressForm.progressBar1.Maximum;
                this.progressForm.Close();
            }
            this.progressForm = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void audioCompressorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (audioCompressorComboBox.Text == "MPEG Layer-3")
             {
            txtavimp3bitrate.Enabled =true;
            txtavimp3samplerate.Enabled = true;
             }
             else
             {
            txtavimp3bitrate.Enabled = false;
            txtavimp3samplerate.Enabled = false;
             }

        }

        private void chkSupportMP4Download_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSupportMP4Download.CheckState == CheckState.Checked)
            {
                this.axVideoEdit1.MP4Streaming = true;
            }
            else
            {
                this.axVideoEdit1.MP4Streaming = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAvchdScale169.CheckState == CheckState.Checked)
            {
                this.axVideoEdit1.AVCHDAspectRatio = 1;
            }
            else 
            {
                this.axVideoEdit1.AVCHDAspectRatio = 0;
            }
        }

        private void chkMPEGScale169_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMPEGScale169.CheckState == CheckState.Checked)
            {
                this.axVideoEdit1.MPEGAspectRatio = 1;
            }
            else
            {
                this.axVideoEdit1.MPEGAspectRatio = 0;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.chkGifOutputQuality.CheckState == CheckState.Checked)
            {
                this.axVideoEdit1.AniGIFVideoQuality = true;
            }
            else
            {
                this.axVideoEdit1.AniGIFVideoQuality = false;
            }
        }

        private void gifButtonColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.clrGifTransparentColor = colorDialog.Color;

            }
        }

        private void axVideoEdit1_Complete(object sender, EventArgs e)
        {
            if (this.progressForm != null)
            {
                this.progressForm.progressBar1.Value = this.progressForm.progressBar1.Maximum;
                this.progressForm.Close();
            }
            this.progressForm = null;
            MessageBox.Show("Convert Completed");
        }

        private void videoTextBox_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "PNG File (*.png)|*.png";
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                PNGTextBox.Text = this.openFileDialog.FileName;
            }
        }

        private void RadioButtonImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButtonPng_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButtonImage_Click(object sender, EventArgs e)
        {
            imageButton.Enabled = true;
            button2.Enabled = false;

        }

        private void RadioButtonPng_Click(object sender, EventArgs e)
        {
            imageButton.Enabled = false;
            button2.Enabled = true;

        }

       

        private void cmdgetaudiotrackinfo_Click(object sender, EventArgs e)
        {
            axVideoEdit1.AMStreamLoadMediaFile(videoTextBox.Text);

            short iCount = (short)axVideoEdit1.AMStreamAudioTracks;
           
         
           txttotalaudiotrack.Text = axVideoEdit1.AMStreamAudioTracks.ToString();


           cboaudiotrackname.Items.Clear();

           if (iCount > 0)
           {
               for (short i = 0; i < iCount; i++)
               {
                   cboaudiotrackname.Items.Add(axVideoEdit1.AMStreamGetAudioTrackName(i));
               }

               if (cboaudiotrackname.Items.Count > 0)
                   cboaudiotrackname.SelectedIndex = 0;

           }
           else
           {
                 cboaudiotrackname.Items.Add("Track 1");
                  cboaudiotrackname.SelectedIndex = 0;
                  txttotalaudiotrack.Text = "1";
           }

        }

        private void cboaudiotrackname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            axVideoEdit1.ShowFullScreen(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cboGPU.SelectedIndex = axVideoEdit1.MP4DetectGPU();
        }

        private void cboGPU_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cboGPU.SelectedIndex == 1)
             {
                 cbonvidapreset.Enabled = true;
                cbopreset.Enabled = false;
             }
             else
             {
                cbonvidapreset.Enabled = false;
                cbopreset.Enabled = true;
             }

        }

      

     
    }
}