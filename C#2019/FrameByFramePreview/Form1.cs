using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelVideo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*|MP4 (*.mp4) | *.mp4|mpg (*.mpg) | *.mpg|FLV (*.flv*.f4v)|*.flv;*.f4v|Flash (*.swf)|*.swf|AVCHD (*.m2ts*.ts)|*.m2ts;*.ts|MPEG2 (*.vob) | *.vob|QuickTime (*.mov) | *.mov|Divx (*.divx)|*.divx|webm (*.webm)|*.webm|3GP (*.3gp) | *.3gp|avi (*.avi) | *.avi|wmv (*.wmv)| *.wmv|asf (*.asf) | *.asf|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif ";

         if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
           {
                txtVideo1.Text = openFileDialog1.FileName;
                axVideoEdit1.FrameLoadVideo(txtVideo1.Text);
                txttotalframe.Text = axVideoEdit1.FrameGetFrameCount().ToString();
                HScrollBar1.Maximum = Convert.ToInt16(axVideoEdit1.FrameGetFrameCount());
           }
        }

        private void cmdplay_Click(object sender, EventArgs e)
        {
           axVideoEdit1.FramePlay();
        }

        private void cmdpause_Click(object sender, EventArgs e)
        {
            axVideoEdit1.FramePause();
        }

        private void cmdstop_Click(object sender, EventArgs e)
        {
            axVideoEdit1.FrameStop();
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            axVideoEdit1.FramePause();

            axVideoEdit1.FrameSeek(HScrollBar1.Value);
        }

        private void axVideoEdit1_OnFrameChange(object sender, AxVIDEOEDITLib._DVideoEditEvents_OnFrameChangeEvent e)
        {
            HScrollBar1.Value = e.iFrame;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HScrollBar1.LargeChange = 1;
        }

        private void axVideoEdit1_OnFrameCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Frame By Frame Preview Completed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           bool bResult;
           saveFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg";
                if(saveFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    bResult = axVideoEdit1.FrameExportFrame(saveFileDialog1.FileName);
                    axVideoEdit1.FramePause();
                }

        }
    }
}
