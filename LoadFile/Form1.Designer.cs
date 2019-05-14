namespace LoadFile
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loadBt = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressLb = new System.Windows.Forms.Label();
            this.progressInfoLb = new System.Windows.Forms.Label();
            this.unzipBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadBt
            // 
            this.loadBt.Location = new System.Drawing.Point(713, 227);
            this.loadBt.Name = "loadBt";
            this.loadBt.Size = new System.Drawing.Size(75, 23);
            this.loadBt.TabIndex = 0;
            this.loadBt.Text = "load";
            this.loadBt.UseVisualStyleBackColor = true;
            this.loadBt.Click += new System.EventHandler(this.loadBt_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(93, 111);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(587, 12);
            this.progressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "进度:";
            // 
            // progressLb
            // 
            this.progressLb.AutoSize = true;
            this.progressLb.Location = new System.Drawing.Point(695, 111);
            this.progressLb.Name = "progressLb";
            this.progressLb.Size = new System.Drawing.Size(17, 12);
            this.progressLb.TabIndex = 3;
            this.progressLb.Text = "0%";
            // 
            // progressInfoLb
            // 
            this.progressInfoLb.AutoSize = true;
            this.progressInfoLb.Location = new System.Drawing.Point(91, 147);
            this.progressInfoLb.Name = "progressInfoLb";
            this.progressInfoLb.Size = new System.Drawing.Size(77, 12);
            this.progressInfoLb.TabIndex = 4;
            this.progressInfoLb.Text = "正在下载文件";
            // 
            // unzipBt
            // 
            this.unzipBt.Location = new System.Drawing.Point(349, 227);
            this.unzipBt.Name = "unzipBt";
            this.unzipBt.Size = new System.Drawing.Size(75, 23);
            this.unzipBt.TabIndex = 5;
            this.unzipBt.Text = "解压";
            this.unzipBt.UseVisualStyleBackColor = true;
            this.unzipBt.Click += new System.EventHandler(this.unzipBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 262);
            this.Controls.Add(this.unzipBt);
            this.Controls.Add(this.progressInfoLb);
            this.Controls.Add(this.progressLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.loadBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadBt;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label progressLb;
        private System.Windows.Forms.Label progressInfoLb;
        private System.Windows.Forms.Button unzipBt;
    }
}

