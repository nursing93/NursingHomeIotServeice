namespace LogingWindow
{
    partial class LogingWindown
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logingBtn = new System.Windows.Forms.Button();
            this.cancleLogBtn = new System.Windows.Forms.Button();
            this.statuLable = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.ComboBox();
            this.userPassWordBox = new System.Windows.Forms.TextBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(94, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(94, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码：";
            // 
            // logingBtn
            // 
            this.logingBtn.BackColor = System.Drawing.Color.Green;
            this.logingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logingBtn.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logingBtn.ForeColor = System.Drawing.Color.Snow;
            this.logingBtn.Location = new System.Drawing.Point(95, 261);
            this.logingBtn.Name = "logingBtn";
            this.logingBtn.Size = new System.Drawing.Size(75, 23);
            this.logingBtn.TabIndex = 4;
            this.logingBtn.Text = "登录";
            this.logingBtn.UseVisualStyleBackColor = false;
            this.logingBtn.Click += new System.EventHandler(this.logingBtn_Click);
            // 
            // cancleLogBtn
            // 
            this.cancleLogBtn.BackColor = System.Drawing.Color.Green;
            this.cancleLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancleLogBtn.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancleLogBtn.ForeColor = System.Drawing.Color.Snow;
            this.cancleLogBtn.Location = new System.Drawing.Point(227, 261);
            this.cancleLogBtn.Name = "cancleLogBtn";
            this.cancleLogBtn.Size = new System.Drawing.Size(75, 23);
            this.cancleLogBtn.TabIndex = 5;
            this.cancleLogBtn.Text = "取消";
            this.cancleLogBtn.UseVisualStyleBackColor = false;
            this.cancleLogBtn.Click += new System.EventHandler(this.cancleLogBtn_Click);
            // 
            // statuLable
            // 
            this.statuLable.AutoSize = true;
            this.statuLable.BackColor = System.Drawing.Color.Transparent;
            this.statuLable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statuLable.ForeColor = System.Drawing.Color.Snow;
            this.statuLable.Location = new System.Drawing.Point(12, 9);
            this.statuLable.Name = "statuLable";
            this.statuLable.Size = new System.Drawing.Size(122, 21);
            this.statuLable.TabIndex = 6;
            this.statuLable.Text = "欢迎使用本系统";
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("宋体", 12F);
            this.userNameBox.FormattingEnabled = true;
            this.userNameBox.Location = new System.Drawing.Point(181, 135);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(121, 24);
            this.userNameBox.TabIndex = 7;
            this.userNameBox.SelectedIndexChanged += new System.EventHandler(this.userNameBox_SelectedIndexChanged);
            // 
            // userPassWordBox
            // 
            this.userPassWordBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPassWordBox.Location = new System.Drawing.Point(181, 174);
            this.userPassWordBox.Name = "userPassWordBox";
            this.userPassWordBox.PasswordChar = '*';
            this.userPassWordBox.Size = new System.Drawing.Size(121, 26);
            this.userPassWordBox.TabIndex = 8;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.BackColor = System.Drawing.Color.Transparent;
            this.checkBox.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox.ForeColor = System.Drawing.Color.Snow;
            this.checkBox.Location = new System.Drawing.Point(216, 222);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(86, 18);
            this.checkBox.TabIndex = 9;
            this.checkBox.Text = "记住密码";
            this.checkBox.UseVisualStyleBackColor = false;
            // 
            // LogingWindown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LogingWindow.Properties.Resources.timg;
            this.ClientSize = new System.Drawing.Size(600, 343);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.userPassWordBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.cancleLogBtn);
            this.Controls.Add(this.logingBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statuLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogingWindown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用本系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogingWindown_FormClosing);
            this.Load += new System.EventHandler(this.LogingWindown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logingBtn;
        private System.Windows.Forms.Button cancleLogBtn;
        private System.Windows.Forms.Label statuLable;
        private System.Windows.Forms.ComboBox userNameBox;
        private System.Windows.Forms.TextBox userPassWordBox;
        private System.Windows.Forms.CheckBox checkBox;
    }
}

