<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.cmdpause = New System.Windows.Forms.Button()
        Me.cmdstop = New System.Windows.Forms.Button()
        Me.Frame3 = New System.Windows.Forms.Panel()
        Me.cmdplay = New System.Windows.Forms.Button()
        Me.AxVideoEdit1 = New AxVIDEOEDITLib.AxVideoEdit()
        Me.txtVideo1 = New System.Windows.Forms.TextBox()
        Me.btnSelVideo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttotalframe = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Frame3.SuspendLayout()
        CType(Me.AxVideoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdpause
        '
        Me.cmdpause.BackColor = System.Drawing.SystemColors.Control
        Me.cmdpause.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdpause.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdpause.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdpause.Location = New System.Drawing.Point(103, 15)
        Me.cmdpause.Name = "cmdpause"
        Me.cmdpause.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdpause.Size = New System.Drawing.Size(89, 30)
        Me.cmdpause.TabIndex = 53
        Me.cmdpause.Text = "PAUSE"
        Me.cmdpause.UseVisualStyleBackColor = False
        '
        'cmdstop
        '
        Me.cmdstop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdstop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdstop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdstop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdstop.Location = New System.Drawing.Point(197, 15)
        Me.cmdstop.Name = "cmdstop"
        Me.cmdstop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdstop.Size = New System.Drawing.Size(89, 30)
        Me.cmdstop.TabIndex = 52
        Me.cmdstop.Text = "STOP"
        Me.cmdstop.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Frame3.Controls.Add(Me.Button1)
        Me.Frame3.Controls.Add(Me.cmdplay)
        Me.Frame3.Controls.Add(Me.cmdpause)
        Me.Frame3.Controls.Add(Me.cmdstop)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(26, 68)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(449, 51)
        Me.Frame3.TabIndex = 55
        '
        'cmdplay
        '
        Me.cmdplay.BackColor = System.Drawing.SystemColors.Control
        Me.cmdplay.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdplay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdplay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdplay.Location = New System.Drawing.Point(8, 15)
        Me.cmdplay.Name = "cmdplay"
        Me.cmdplay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdplay.Size = New System.Drawing.Size(89, 30)
        Me.cmdplay.TabIndex = 55
        Me.cmdplay.Text = "PLAY"
        Me.cmdplay.UseVisualStyleBackColor = False
        '
        'AxVideoEdit1
        '
        Me.AxVideoEdit1.Enabled = True
        Me.AxVideoEdit1.Location = New System.Drawing.Point(11, 135)
        Me.AxVideoEdit1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AxVideoEdit1.Name = "AxVideoEdit1"
        Me.AxVideoEdit1.OcxState = CType(resources.GetObject("AxVideoEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVideoEdit1.Size = New System.Drawing.Size(666, 577)
        Me.AxVideoEdit1.TabIndex = 56
        '
        'txtVideo1
        '
        Me.txtVideo1.AcceptsReturn = True
        Me.txtVideo1.BackColor = System.Drawing.SystemColors.Window
        Me.txtVideo1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVideo1.Enabled = False
        Me.txtVideo1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVideo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVideo1.Location = New System.Drawing.Point(26, 10)
        Me.txtVideo1.MaxLength = 0
        Me.txtVideo1.Name = "txtVideo1"
        Me.txtVideo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVideo1.Size = New System.Drawing.Size(319, 20)
        Me.txtVideo1.TabIndex = 58
        '
        'btnSelVideo
        '
        Me.btnSelVideo.BackColor = System.Drawing.SystemColors.Control
        Me.btnSelVideo.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSelVideo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelVideo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSelVideo.Location = New System.Drawing.Point(346, 10)
        Me.btnSelVideo.Name = "btnSelVideo"
        Me.btnSelVideo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSelVideo.Size = New System.Drawing.Size(30, 19)
        Me.btnSelVideo.TabIndex = 57
        Me.btnSelVideo.Text = "..."
        Me.btnSelVideo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(389, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Total Frame"
        '
        'txttotalframe
        '
        Me.txttotalframe.Location = New System.Drawing.Point(472, 12)
        Me.txttotalframe.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txttotalframe.Name = "txttotalframe"
        Me.txttotalframe.Size = New System.Drawing.Size(68, 21)
        Me.txttotalframe.TabIndex = 60
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(26, 39)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(463, 26)
        Me.HScrollBar1.TabIndex = 61
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(302, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(132, 30)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "Export Frame"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 764)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.txttotalframe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVideo1)
        Me.Controls.Add(Me.btnSelVideo)
        Me.Controls.Add(Me.AxVideoEdit1)
        Me.Controls.Add(Me.Frame3)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Frame By Frame Preview"
        Me.Frame3.ResumeLayout(False)
        CType(Me.AxVideoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cmdpause As System.Windows.Forms.Button
    Public WithEvents cmdstop As System.Windows.Forms.Button
    Public WithEvents Frame3 As System.Windows.Forms.Panel
    Public WithEvents cmdplay As System.Windows.Forms.Button
    Friend WithEvents AxVideoEdit1 As AxVIDEOEDITLib.AxVideoEdit
    Public WithEvents txtVideo1 As System.Windows.Forms.TextBox
    Public WithEvents btnSelVideo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttotalframe As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
