namespace LogingWindow
{
    partial class AreaSetWindow
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
            this.setAreaWebBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveAreaBtn = new System.Windows.Forms.Button();
            this.putAreaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // setAreaWebBrowser
            // 
            this.setAreaWebBrowser.AllowWebBrowserDrop = false;
            this.setAreaWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setAreaWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.setAreaWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.setAreaWebBrowser.Name = "setAreaWebBrowser";
            this.setAreaWebBrowser.Size = new System.Drawing.Size(905, 418);
            this.setAreaWebBrowser.TabIndex = 0;
            this.setAreaWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.layoutControlBtn);
            this.panel1.Controls.Add(this.saveAreaBtn);
            this.panel1.Controls.Add(this.putAreaBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 36);
            this.panel1.TabIndex = 1;
            // 
            // saveAreaBtn
            // 
            this.saveAreaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAreaBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveAreaBtn.Location = new System.Drawing.Point(754, -1);
            this.saveAreaBtn.Name = "saveAreaBtn";
            this.saveAreaBtn.Size = new System.Drawing.Size(100, 34);
            this.saveAreaBtn.TabIndex = 3;
            this.saveAreaBtn.Text = "保存设置";
            this.saveAreaBtn.UseVisualStyleBackColor = true;
            this.saveAreaBtn.Click += new System.EventHandler(this.saveAreaBtn_Click);
            // 
            // putAreaBtn
            // 
            this.putAreaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.putAreaBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.putAreaBtn.Location = new System.Drawing.Point(621, -1);
            this.putAreaBtn.Name = "putAreaBtn";
            this.putAreaBtn.Size = new System.Drawing.Size(127, 35);
            this.putAreaBtn.TabIndex = 2;
            this.putAreaBtn.Text = "放置基本图形";
            this.putAreaBtn.UseVisualStyleBackColor = true;
            this.putAreaBtn.Click += new System.EventHandler(this.putAreaBtn_Click);
            this.putAreaBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.putAreaBtn_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "请在地图页面中设置安全区域";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutControlBtn
            // 
            this.layoutControlBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControlBtn.Font = new System.Drawing.Font("Candara", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlBtn.Location = new System.Drawing.Point(879, 9);
            this.layoutControlBtn.Name = "layoutControlBtn";
            this.layoutControlBtn.Size = new System.Drawing.Size(26, 26);
            this.layoutControlBtn.TabIndex = 4;
            this.layoutControlBtn.Text = "+";
            this.layoutControlBtn.UseVisualStyleBackColor = true;
            this.layoutControlBtn.Click += new System.EventHandler(this.layoutControlBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(12, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 28);
            this.label8.TabIndex = 15;
            this.label8.Text = "设计步骤说明";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(531, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(307, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "6、右键单击“保存设置”以临时保存图形";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(48, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(323, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "5、右键单击“放置基本图形”弹出历史记录";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(531, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "4、点击“保存设置”以完成活动区域规划";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(48, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "1、将预设地点拖致地图显示区域";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(48, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "3、根据实际情况设计区域形状和覆盖范围";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(531, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "2、点击“放置基本图形”按钮放置基本图形";
            // 
            // AreaSetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.setAreaWebBrowser);
            this.Name = "AreaSetWindow";
            this.Text = "AreaSetWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AreaSetWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveAreaBtn;
        private System.Windows.Forms.Button putAreaBtn;
        public System.Windows.Forms.WebBrowser setAreaWebBrowser;
        private System.Windows.Forms.Button layoutControlBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}