namespace LogingWindow
{
    partial class UserDetailsForm
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
            this.userDetailsTab = new System.Windows.Forms.TabControl();
            this.userDetails = new System.Windows.Forms.TabPage();
            this.saveDetailsBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.amendDetailsBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.userIDBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.userBirthdayBox = new System.Windows.Forms.TextBox();
            this.userSexBox = new System.Windows.Forms.TextBox();
            this.userRealNameBox = new System.Windows.Forms.TextBox();
            this.userIDcardBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.amendPassword = new System.Windows.Forms.TabPage();
            this.pCancleAmendBtn = new System.Windows.Forms.Button();
            this.pOkAmendBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pConfirmPasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pOldPasswordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pNewPasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pUserNameBox = new System.Windows.Forms.TextBox();
            this.userDetailsTab.SuspendLayout();
            this.userDetails.SuspendLayout();
            this.amendPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // userDetailsTab
            // 
            this.userDetailsTab.Controls.Add(this.userDetails);
            this.userDetailsTab.Controls.Add(this.amendPassword);
            this.userDetailsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDetailsTab.Location = new System.Drawing.Point(0, 0);
            this.userDetailsTab.Name = "userDetailsTab";
            this.userDetailsTab.SelectedIndex = 0;
            this.userDetailsTab.Size = new System.Drawing.Size(543, 295);
            this.userDetailsTab.TabIndex = 0;
            // 
            // userDetails
            // 
            this.userDetails.Controls.Add(this.saveDetailsBtn);
            this.userDetails.Controls.Add(this.label6);
            this.userDetails.Controls.Add(this.amendDetailsBtn);
            this.userDetails.Controls.Add(this.label7);
            this.userDetails.Controls.Add(this.userIDBox);
            this.userDetails.Controls.Add(this.label10);
            this.userDetails.Controls.Add(this.userBirthdayBox);
            this.userDetails.Controls.Add(this.userSexBox);
            this.userDetails.Controls.Add(this.userRealNameBox);
            this.userDetails.Controls.Add(this.userIDcardBox);
            this.userDetails.Controls.Add(this.label5);
            this.userDetails.Controls.Add(this.label8);
            this.userDetails.Controls.Add(this.userNameBox);
            this.userDetails.Controls.Add(this.label9);
            this.userDetails.Location = new System.Drawing.Point(4, 22);
            this.userDetails.Name = "userDetails";
            this.userDetails.Padding = new System.Windows.Forms.Padding(3);
            this.userDetails.Size = new System.Drawing.Size(535, 269);
            this.userDetails.TabIndex = 0;
            this.userDetails.Text = "个人信息";
            this.userDetails.UseVisualStyleBackColor = true;
            // 
            // saveDetailsBtn
            // 
            this.saveDetailsBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveDetailsBtn.Location = new System.Drawing.Point(366, 204);
            this.saveDetailsBtn.Name = "saveDetailsBtn";
            this.saveDetailsBtn.Size = new System.Drawing.Size(69, 29);
            this.saveDetailsBtn.TabIndex = 22;
            this.saveDetailsBtn.Text = "保存";
            this.saveDetailsBtn.UseVisualStyleBackColor = true;
            this.saveDetailsBtn.Click += new System.EventHandler(this.saveDetailsBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(265, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "生日：";
            // 
            // amendDetailsBtn
            // 
            this.amendDetailsBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.amendDetailsBtn.Location = new System.Drawing.Point(269, 204);
            this.amendDetailsBtn.Name = "amendDetailsBtn";
            this.amendDetailsBtn.Size = new System.Drawing.Size(69, 29);
            this.amendDetailsBtn.TabIndex = 21;
            this.amendDetailsBtn.Text = "修改";
            this.amendDetailsBtn.UseVisualStyleBackColor = true;
            this.amendDetailsBtn.Click += new System.EventHandler(this.amendDetailsBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(265, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "性别：";
            // 
            // userIDBox
            // 
            this.userIDBox.Location = new System.Drawing.Point(338, 30);
            this.userIDBox.Name = "userIDBox";
            this.userIDBox.Size = new System.Drawing.Size(97, 21);
            this.userIDBox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(265, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "工号：";
            // 
            // userBirthdayBox
            // 
            this.userBirthdayBox.Location = new System.Drawing.Point(338, 146);
            this.userBirthdayBox.Name = "userBirthdayBox";
            this.userBirthdayBox.Size = new System.Drawing.Size(97, 21);
            this.userBirthdayBox.TabIndex = 18;
            // 
            // userSexBox
            // 
            this.userSexBox.Location = new System.Drawing.Point(338, 90);
            this.userSexBox.Name = "userSexBox";
            this.userSexBox.Size = new System.Drawing.Size(97, 21);
            this.userSexBox.TabIndex = 19;
            // 
            // userRealNameBox
            // 
            this.userRealNameBox.Location = new System.Drawing.Point(114, 93);
            this.userRealNameBox.Name = "userRealNameBox";
            this.userRealNameBox.Size = new System.Drawing.Size(97, 21);
            this.userRealNameBox.TabIndex = 10;
            // 
            // userIDcardBox
            // 
            this.userIDcardBox.Location = new System.Drawing.Point(114, 145);
            this.userIDcardBox.Name = "userIDcardBox";
            this.userIDcardBox.Size = new System.Drawing.Size(97, 21);
            this.userIDcardBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(43, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "用户名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(29, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "身份证号：";
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(114, 33);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(97, 21);
            this.userNameBox.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(57, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "姓名：";
            // 
            // amendPassword
            // 
            this.amendPassword.Controls.Add(this.pCancleAmendBtn);
            this.amendPassword.Controls.Add(this.pOkAmendBtn);
            this.amendPassword.Controls.Add(this.label4);
            this.amendPassword.Controls.Add(this.pConfirmPasswordBox);
            this.amendPassword.Controls.Add(this.label3);
            this.amendPassword.Controls.Add(this.pOldPasswordBox);
            this.amendPassword.Controls.Add(this.label2);
            this.amendPassword.Controls.Add(this.pNewPasswordBox);
            this.amendPassword.Controls.Add(this.label1);
            this.amendPassword.Controls.Add(this.pUserNameBox);
            this.amendPassword.Location = new System.Drawing.Point(4, 22);
            this.amendPassword.Name = "amendPassword";
            this.amendPassword.Padding = new System.Windows.Forms.Padding(3);
            this.amendPassword.Size = new System.Drawing.Size(535, 269);
            this.amendPassword.TabIndex = 1;
            this.amendPassword.Text = "修改密码";
            this.amendPassword.UseVisualStyleBackColor = true;
            this.amendPassword.Enter += new System.EventHandler(this.amendPassword_Enter);
            // 
            // pCancleAmendBtn
            // 
            this.pCancleAmendBtn.Location = new System.Drawing.Point(442, 213);
            this.pCancleAmendBtn.Name = "pCancleAmendBtn";
            this.pCancleAmendBtn.Size = new System.Drawing.Size(75, 23);
            this.pCancleAmendBtn.TabIndex = 9;
            this.pCancleAmendBtn.Text = "取消";
            this.pCancleAmendBtn.UseVisualStyleBackColor = true;
            this.pCancleAmendBtn.Click += new System.EventHandler(this.pCancleAmendBtn_Click);
            // 
            // pOkAmendBtn
            // 
            this.pOkAmendBtn.Location = new System.Drawing.Point(336, 213);
            this.pOkAmendBtn.Name = "pOkAmendBtn";
            this.pOkAmendBtn.Size = new System.Drawing.Size(75, 23);
            this.pOkAmendBtn.TabIndex = 8;
            this.pOkAmendBtn.Text = "确认";
            this.pOkAmendBtn.UseVisualStyleBackColor = true;
            this.pOkAmendBtn.Click += new System.EventHandler(this.okAmendBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "新密码确认：";
            // 
            // pConfirmPasswordBox
            // 
            this.pConfirmPasswordBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pConfirmPasswordBox.Location = new System.Drawing.Point(135, 160);
            this.pConfirmPasswordBox.Name = "pConfirmPasswordBox";
            this.pConfirmPasswordBox.PasswordChar = '*';
            this.pConfirmPasswordBox.Size = new System.Drawing.Size(165, 26);
            this.pConfirmPasswordBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "原密码：";
            // 
            // pOldPasswordBox
            // 
            this.pOldPasswordBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pOldPasswordBox.Location = new System.Drawing.Point(135, 76);
            this.pOldPasswordBox.Name = "pOldPasswordBox";
            this.pOldPasswordBox.PasswordChar = '*';
            this.pOldPasswordBox.Size = new System.Drawing.Size(165, 26);
            this.pOldPasswordBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "新密码：";
            // 
            // pNewPasswordBox
            // 
            this.pNewPasswordBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pNewPasswordBox.Location = new System.Drawing.Point(135, 118);
            this.pNewPasswordBox.Name = "pNewPasswordBox";
            this.pNewPasswordBox.PasswordChar = '*';
            this.pNewPasswordBox.Size = new System.Drawing.Size(165, 26);
            this.pNewPasswordBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // pUserNameBox
            // 
            this.pUserNameBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pUserNameBox.Location = new System.Drawing.Point(135, 34);
            this.pUserNameBox.Name = "pUserNameBox";
            this.pUserNameBox.ReadOnly = true;
            this.pUserNameBox.Size = new System.Drawing.Size(165, 26);
            this.pUserNameBox.TabIndex = 0;
            // 
            // UserDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 295);
            this.Controls.Add(this.userDetailsTab);
            this.Name = "UserDetailsForm";
            this.Text = "个人管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserDetailsForm_FormClosing);
            this.Load += new System.EventHandler(this.UserDetailsForm_Load);
            this.userDetailsTab.ResumeLayout(false);
            this.userDetails.ResumeLayout(false);
            this.userDetails.PerformLayout();
            this.amendPassword.ResumeLayout(false);
            this.amendPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl userDetailsTab;
        private System.Windows.Forms.TabPage userDetails;
        private System.Windows.Forms.TabPage amendPassword;
        private System.Windows.Forms.Button pCancleAmendBtn;
        private System.Windows.Forms.Button pOkAmendBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pConfirmPasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pOldPasswordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pNewPasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pUserNameBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userRealNameBox;
        private System.Windows.Forms.TextBox userIDcardBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Button saveDetailsBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button amendDetailsBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox userIDBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox userBirthdayBox;
        private System.Windows.Forms.TextBox userSexBox;
    }
}