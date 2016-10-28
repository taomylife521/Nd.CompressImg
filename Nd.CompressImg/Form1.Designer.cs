namespace Nd.CompressImg
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.btnOutPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstDetail = new System.Windows.Forms.ListBox();
            this.lbFileCount = new System.Windows.Forms.Label();
            this.lbFolderCount = new System.Windows.Forms.Label();
            this.lbOutPath = new System.Windows.Forms.Label();
            this.lbDealPath = new System.Windows.Forms.Label();
            this.txtLeastCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsbResult = new System.Windows.Forms.ListBox();
            this.lbDealing = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ChbIsSubFolder = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxTask = new System.Windows.Forms.TextBox();
            this.chbCopyOtherFile = new System.Windows.Forms.CheckBox();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCompressHeight = new System.Windows.Forms.TextBox();
            this.txtCompressWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(383, 166);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开启";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.Black;
            this.lstLog.ForeColor = System.Drawing.Color.White;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(-2, 207);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(561, 220);
            this.lstLog.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(484, 166);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(70, 13);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(408, 21);
            this.txtPath.TabIndex = 3;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(484, 13);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 23);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "处理路径";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "处理路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "输出路径";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(71, 43);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(407, 21);
            this.txtOutPath.TabIndex = 6;
            // 
            // btnOutPath
            // 
            this.btnOutPath.Location = new System.Drawing.Point(484, 46);
            this.btnOutPath.Name = "btnOutPath";
            this.btnOutPath.Size = new System.Drawing.Size(75, 23);
            this.btnOutPath.TabIndex = 7;
            this.btnOutPath.Text = "输出路径";
            this.btnOutPath.UseVisualStyleBackColor = true;
            this.btnOutPath.Click += new System.EventHandler(this.btnOutPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lstDetail);
            this.groupBox1.Controls.Add(this.lbFileCount);
            this.groupBox1.Controls.Add(this.lbFolderCount);
            this.groupBox1.Controls.Add(this.lbOutPath);
            this.groupBox1.Controls.Add(this.lbDealPath);
            this.groupBox1.Location = new System.Drawing.Point(585, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 166);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理明细";
            // 
            // lstDetail
            // 
            this.lstDetail.FormattingEnabled = true;
            this.lstDetail.ItemHeight = 12;
            this.lstDetail.Location = new System.Drawing.Point(8, 102);
            this.lstDetail.Name = "lstDetail";
            this.lstDetail.Size = new System.Drawing.Size(379, 64);
            this.lstDetail.TabIndex = 11;
            // 
            // lbFileCount
            // 
            this.lbFileCount.AutoSize = true;
            this.lbFileCount.Location = new System.Drawing.Point(148, 17);
            this.lbFileCount.Name = "lbFileCount";
            this.lbFileCount.Size = new System.Drawing.Size(65, 12);
            this.lbFileCount.TabIndex = 10;
            this.lbFileCount.Text = "图片数量：";
            // 
            // lbFolderCount
            // 
            this.lbFolderCount.AutoSize = true;
            this.lbFolderCount.Location = new System.Drawing.Point(6, 18);
            this.lbFolderCount.Name = "lbFolderCount";
            this.lbFolderCount.Size = new System.Drawing.Size(77, 12);
            this.lbFolderCount.TabIndex = 9;
            this.lbFolderCount.Text = "文件夹数量：";
            // 
            // lbOutPath
            // 
            this.lbOutPath.AutoSize = true;
            this.lbOutPath.Location = new System.Drawing.Point(6, 66);
            this.lbOutPath.Name = "lbOutPath";
            this.lbOutPath.Size = new System.Drawing.Size(65, 12);
            this.lbOutPath.TabIndex = 6;
            this.lbOutPath.Text = "输出路径：";
            // 
            // lbDealPath
            // 
            this.lbDealPath.AutoSize = true;
            this.lbDealPath.Location = new System.Drawing.Point(6, 41);
            this.lbDealPath.Name = "lbDealPath";
            this.lbDealPath.Size = new System.Drawing.Size(65, 12);
            this.lbDealPath.TabIndex = 6;
            this.lbDealPath.Text = "处理路径：";
            // 
            // txtLeastCount
            // 
            this.txtLeastCount.Location = new System.Drawing.Point(129, 70);
            this.txtLeastCount.Name = "txtLeastCount";
            this.txtLeastCount.Size = new System.Drawing.Size(46, 21);
            this.txtLeastCount.TabIndex = 16;
            this.txtLeastCount.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "线程至少处理数量";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsbResult);
            this.groupBox2.Location = new System.Drawing.Point(579, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 250);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处理结果";
            // 
            // lsbResult
            // 
            this.lsbResult.BackColor = System.Drawing.Color.Black;
            this.lsbResult.ForeColor = System.Drawing.Color.Green;
            this.lsbResult.FormattingEnabled = true;
            this.lsbResult.ItemHeight = 12;
            this.lsbResult.Location = new System.Drawing.Point(0, 14);
            this.lsbResult.Name = "lsbResult";
            this.lsbResult.Size = new System.Drawing.Size(422, 232);
            this.lsbResult.TabIndex = 15;
            // 
            // lbDealing
            // 
            this.lbDealing.AutoSize = true;
            this.lbDealing.Location = new System.Drawing.Point(5, 191);
            this.lbDealing.Name = "lbDealing";
            this.lbDealing.Size = new System.Drawing.Size(59, 12);
            this.lbDealing.TabIndex = 20;
            this.lbDealing.Text = "正在处理:";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(75, 177);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(11, 12);
            this.lbTime.TabIndex = 21;
            this.lbTime.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "已用时(s):";
            // 
            // ChbIsSubFolder
            // 
            this.ChbIsSubFolder.AutoSize = true;
            this.ChbIsSubFolder.Checked = true;
            this.ChbIsSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbIsSubFolder.Location = new System.Drawing.Point(199, 72);
            this.ChbIsSubFolder.Name = "ChbIsSubFolder";
            this.ChbIsSubFolder.Size = new System.Drawing.Size(120, 16);
            this.ChbIsSubFolder.TabIndex = 23;
            this.ChbIsSubFolder.Text = "是否处理子文件夹";
            this.ChbIsSubFolder.UseVisualStyleBackColor = true;
            this.ChbIsSubFolder.CheckedChanged += new System.EventHandler(this.ChbIsSubFolder_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "最大线程数量";
            // 
            // txtMaxTask
            // 
            this.txtMaxTask.Location = new System.Drawing.Point(130, 98);
            this.txtMaxTask.Name = "txtMaxTask";
            this.txtMaxTask.Size = new System.Drawing.Size(46, 21);
            this.txtMaxTask.TabIndex = 24;
            this.txtMaxTask.Text = "50";
            // 
            // chbCopyOtherFile
            // 
            this.chbCopyOtherFile.AutoSize = true;
            this.chbCopyOtherFile.Checked = true;
            this.chbCopyOtherFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCopyOtherFile.Location = new System.Drawing.Point(199, 97);
            this.chbCopyOtherFile.Name = "chbCopyOtherFile";
            this.chbCopyOtherFile.Size = new System.Drawing.Size(228, 16);
            this.chbCopyOtherFile.TabIndex = 26;
            this.chbCopyOtherFile.Text = "是否复制处理路径下的其它非图片文件";
            this.chbCopyOtherFile.UseVisualStyleBackColor = true;
            // 
            // cmbQuality
            // 
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Location = new System.Drawing.Point(184, 127);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(57, 20);
            this.cmbQuality.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "压缩质量(1(最差)-100(最好))";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "压缩高度:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "压缩宽度:";
            // 
            // txtCompressHeight
            // 
            this.txtCompressHeight.Location = new System.Drawing.Point(327, 124);
            this.txtCompressHeight.Name = "txtCompressHeight";
            this.txtCompressHeight.Size = new System.Drawing.Size(48, 21);
            this.txtCompressHeight.TabIndex = 31;
            this.txtCompressHeight.Text = "0";
            // 
            // txtCompressWidth
            // 
            this.txtCompressWidth.Location = new System.Drawing.Point(446, 121);
            this.txtCompressWidth.Name = "txtCompressWidth";
            this.txtCompressWidth.Size = new System.Drawing.Size(48, 21);
            this.txtCompressWidth.TabIndex = 32;
            this.txtCompressWidth.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "处理路径格式明细输出：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "注:压缩高度宽度为0默认为原图片宽高";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 428);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCompressWidth);
            this.Controls.Add(this.txtCompressHeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.chbCopyOtherFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaxTask);
            this.Controls.Add(this.ChbIsSubFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbDealing);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLeastCount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOutPath);
            this.Controls.Add(this.txtOutPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "你定图片压缩工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Button btnOutPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFolderCount;
        private System.Windows.Forms.Label lbOutPath;
        private System.Windows.Forms.Label lbDealPath;
        private System.Windows.Forms.Label lbFileCount;
        private System.Windows.Forms.TextBox txtLeastCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbDealing;
        private System.Windows.Forms.ListBox lsbResult;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChbIsSubFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxTask;
        private System.Windows.Forms.ListBox lstDetail;
        private System.Windows.Forms.CheckBox chbCopyOtherFile;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCompressHeight;
        private System.Windows.Forms.TextBox txtCompressWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
    }
}

