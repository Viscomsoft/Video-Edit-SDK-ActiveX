namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axVideoEdit1 = new AxVIDEOEDITLib.AxVideoEdit();
            this.txttotalframe = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtVideo1 = new System.Windows.Forms.TextBox();
            this.btnSelVideo = new System.Windows.Forms.Button();
            this.HScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.cmdplay = new System.Windows.Forms.Button();
            this.Frame3 = new System.Windows.Forms.Panel();
            this.cmdpause = new System.Windows.Forms.Button();
            this.cmdstop = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoEdit1)).BeginInit();
            this.Frame3.SuspendLayout();
            this.SuspendLayout();
            // 
            // axVideoEdit1
            // 
            this.axVideoEdit1.Enabled = true;
            this.axVideoEdit1.Location = new System.Drawing.Point(23, 136);
            this.axVideoEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.axVideoEdit1.Name = "axVideoEdit1";
            this.axVideoEdit1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoEdit1.OcxState")));
            this.axVideoEdit1.Size = new System.Drawing.Size(485, 348);
            this.axVideoEdit1.TabIndex = 0;
            this.axVideoEdit1.OnFrameChange += new AxVIDEOEDITLib._DVideoEditEvents_OnFrameChangeEventHandler(this.axVideoEdit1_OnFrameChange);
            this.axVideoEdit1.OnFrameCompleted += new System.EventHandler(this.axVideoEdit1_OnFrameCompleted);
            // 
            // txttotalframe
            // 
            this.txttotalframe.Location = new System.Drawing.Point(472, 11);
            this.txttotalframe.Margin = new System.Windows.Forms.Padding(2);
            this.txttotalframe.Name = "txttotalframe";
            this.txttotalframe.Size = new System.Drawing.Size(68, 21);
            this.txttotalframe.TabIndex = 64;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(389, 11);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 12);
            this.Label1.TabIndex = 63;
            this.Label1.Text = "Total Frame";
            // 
            // txtVideo1
            // 
            this.txtVideo1.AcceptsReturn = true;
            this.txtVideo1.BackColor = System.Drawing.SystemColors.Window;
            this.txtVideo1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVideo1.Enabled = false;
            this.txtVideo1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideo1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVideo1.Location = new System.Drawing.Point(26, 9);
            this.txtVideo1.MaxLength = 0;
            this.txtVideo1.Name = "txtVideo1";
            this.txtVideo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVideo1.Size = new System.Drawing.Size(319, 20);
            this.txtVideo1.TabIndex = 62;
            // 
            // btnSelVideo
            // 
            this.btnSelVideo.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelVideo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelVideo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelVideo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelVideo.Location = new System.Drawing.Point(346, 9);
            this.btnSelVideo.Name = "btnSelVideo";
            this.btnSelVideo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelVideo.Size = new System.Drawing.Size(30, 19);
            this.btnSelVideo.TabIndex = 61;
            this.btnSelVideo.Text = "...";
            this.btnSelVideo.UseVisualStyleBackColor = false;
            this.btnSelVideo.Click += new System.EventHandler(this.btnSelVideo_Click);
            // 
            // HScrollBar1
            // 
            this.HScrollBar1.Location = new System.Drawing.Point(26, 41);
            this.HScrollBar1.Name = "HScrollBar1";
            this.HScrollBar1.Size = new System.Drawing.Size(463, 26);
            this.HScrollBar1.TabIndex = 65;
            this.HScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar1_Scroll);
            // 
            // cmdplay
            // 
            this.cmdplay.BackColor = System.Drawing.SystemColors.Control;
            this.cmdplay.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdplay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdplay.Location = new System.Drawing.Point(8, 15);
            this.cmdplay.Name = "cmdplay";
            this.cmdplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdplay.Size = new System.Drawing.Size(89, 30);
            this.cmdplay.TabIndex = 55;
            this.cmdplay.Text = "PLAY";
            this.cmdplay.UseVisualStyleBackColor = false;
            this.cmdplay.Click += new System.EventHandler(this.cmdplay_Click);
            // 
            // Frame3
            // 
            this.Frame3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Frame3.Controls.Add(this.button1);
            this.Frame3.Controls.Add(this.cmdplay);
            this.Frame3.Controls.Add(this.cmdpause);
            this.Frame3.Controls.Add(this.cmdstop);
            this.Frame3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Frame3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame3.Location = new System.Drawing.Point(26, 70);
            this.Frame3.Name = "Frame3";
            this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame3.Size = new System.Drawing.Size(434, 51);
            this.Frame3.TabIndex = 66;
            // 
            // cmdpause
            // 
            this.cmdpause.BackColor = System.Drawing.SystemColors.Control;
            this.cmdpause.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdpause.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdpause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdpause.Location = new System.Drawing.Point(103, 15);
            this.cmdpause.Name = "cmdpause";
            this.cmdpause.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdpause.Size = new System.Drawing.Size(89, 30);
            this.cmdpause.TabIndex = 53;
            this.cmdpause.Text = "PAUSE";
            this.cmdpause.UseVisualStyleBackColor = false;
            this.cmdpause.Click += new System.EventHandler(this.cmdpause_Click);
            // 
            // cmdstop
            // 
            this.cmdstop.BackColor = System.Drawing.SystemColors.Control;
            this.cmdstop.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdstop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdstop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdstop.Location = new System.Drawing.Point(197, 15);
            this.cmdstop.Name = "cmdstop";
            this.cmdstop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdstop.Size = new System.Drawing.Size(89, 30);
            this.cmdstop.TabIndex = 52;
            this.cmdstop.Text = "STOP";
            this.cmdstop.UseVisualStyleBackColor = false;
            this.cmdstop.Click += new System.EventHandler(this.cmdstop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(301, 15);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 56;
            this.button1.Text = "Export Frame";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 501);
            this.Controls.Add(this.Frame3);
            this.Controls.Add(this.HScrollBar1);
            this.Controls.Add(this.txttotalframe);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtVideo1);
            this.Controls.Add(this.btnSelVideo);
            this.Controls.Add(this.axVideoEdit1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axVideoEdit1)).EndInit();
            this.Frame3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxVIDEOEDITLib.AxVideoEdit axVideoEdit1;
        internal System.Windows.Forms.TextBox txttotalframe;
        internal System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtVideo1;
        public System.Windows.Forms.Button btnSelVideo;
        internal System.Windows.Forms.HScrollBar HScrollBar1;
        public System.Windows.Forms.Button cmdplay;
        public System.Windows.Forms.Panel Frame3;
        public System.Windows.Forms.Button cmdpause;
        public System.Windows.Forms.Button cmdstop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

