namespace LogingWindow
{
    partial class AdminForm
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
            this.components = new System.ComponentModel.Container();
            this.AdminTabControl = new System.Windows.Forms.TabControl();
            this.userListPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userManagePage = new System.Windows.Forms.TabPage();
            this.userManageTabControl = new System.Windows.Forms.TabControl();
            this.creatUserTab = new System.Windows.Forms.TabPage();
            this.nSexBox = new System.Windows.Forms.ComboBox();
            this.nIsAdminBox = new System.Windows.Forms.ComboBox();
            this.nBirthdayBox = new System.Windows.Forms.DateTimePicker();
            this.nNursingHomeIdBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.nCancleSaveBtn = new System.Windows.Forms.Button();
            this.nSaveUserBtn = new System.Windows.Forms.Button();
            this.nUserPhoneBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nRealNameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nUserIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nPasswordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteUserTab = new System.Windows.Forms.TabPage();
            this.dUserIDBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dCancleDeleteBtn = new System.Windows.Forms.Button();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.dIDCardBox = new System.Windows.Forms.TextBox();
            this.dSexBox = new System.Windows.Forms.TextBox();
            this.dIsAdminBox = new System.Windows.Forms.TextBox();
            this.dUserNameBox = new System.Windows.Forms.TextBox();
            this.dBirthdayBox = new System.Windows.Forms.TextBox();
            this.dRealNameBox = new System.Windows.Forms.TextBox();
            this.dSuperiorBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteUser_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdminTabControl.SuspendLayout();
            this.userListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.userManagePage.SuspendLayout();
            this.userManageTabControl.SuspendLayout();
            this.creatUserTab.SuspendLayout();
            this.deleteUserTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminTabControl
            // 
            this.AdminTabControl.Controls.Add(this.userListPage);
            this.AdminTabControl.Controls.Add(this.userManagePage);
            this.AdminTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminTabControl.Location = new System.Drawing.Point(0, 0);
            this.AdminTabControl.Name = "AdminTabControl";
            this.AdminTabControl.SelectedIndex = 0;
            this.AdminTabControl.Size = new System.Drawing.Size(610, 345);
            this.AdminTabControl.TabIndex = 0;
            // 
            // userListPage
            // 
            this.userListPage.Controls.Add(this.dataGridView1);
            this.userListPage.Location = new System.Drawing.Point(4, 22);
            this.userListPage.Name = "userListPage";
            this.userListPage.Padding = new System.Windows.Forms.Padding(3);
            this.userListPage.Size = new System.Drawing.Size(602, 319);
            this.userListPage.TabIndex = 0;
            this.userListPage.Text = "用户列表";
            this.userListPage.UseVisualStyleBackColor = true;
            this.userListPage.Enter += new System.EventHandler(this.userListPage_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userName,
            this.isAdmin,
            this.number,
            this.realName,
            this.sex,
            this.idCard,
            this.birthday});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(596, 313);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // userManagePage
            // 
            this.userManagePage.Controls.Add(this.userManageTabControl);
            this.userManagePage.Location = new System.Drawing.Point(4, 22);
            this.userManagePage.Name = "userManagePage";
            this.userManagePage.Padding = new System.Windows.Forms.Padding(3);
            this.userManagePage.Size = new System.Drawing.Size(602, 319);
            this.userManagePage.TabIndex = 1;
            this.userManagePage.Text = "用户管理";
            this.userManagePage.UseVisualStyleBackColor = true;
            // 
            // userManageTabControl
            // 
            this.userManageTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.userManageTabControl.Controls.Add(this.creatUserTab);
            this.userManageTabControl.Controls.Add(this.deleteUserTab);
            this.userManageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userManageTabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userManageTabControl.ItemSize = new System.Drawing.Size(50, 22);
            this.userManageTabControl.Location = new System.Drawing.Point(3, 3);
            this.userManageTabControl.Multiline = true;
            this.userManageTabControl.Name = "userManageTabControl";
            this.userManageTabControl.SelectedIndex = 0;
            this.userManageTabControl.Size = new System.Drawing.Size(596, 313);
            this.userManageTabControl.TabIndex = 0;
            // 
            // creatUserTab
            // 
            this.creatUserTab.Controls.Add(this.nSexBox);
            this.creatUserTab.Controls.Add(this.nIsAdminBox);
            this.creatUserTab.Controls.Add(this.nBirthdayBox);
            this.creatUserTab.Controls.Add(this.nNursingHomeIdBox);
            this.creatUserTab.Controls.Add(this.label17);
            this.creatUserTab.Controls.Add(this.nCancleSaveBtn);
            this.creatUserTab.Controls.Add(this.nSaveUserBtn);
            this.creatUserTab.Controls.Add(this.nUserPhoneBox);
            this.creatUserTab.Controls.Add(this.label8);
            this.creatUserTab.Controls.Add(this.label7);
            this.creatUserTab.Controls.Add(this.label6);
            this.creatUserTab.Controls.Add(this.nRealNameBox);
            this.creatUserTab.Controls.Add(this.label5);
            this.creatUserTab.Controls.Add(this.label4);
            this.creatUserTab.Controls.Add(this.nUserIdBox);
            this.creatUserTab.Controls.Add(this.label3);
            this.creatUserTab.Controls.Add(this.nPasswordBox);
            this.creatUserTab.Controls.Add(this.label2);
            this.creatUserTab.Location = new System.Drawing.Point(26, 4);
            this.creatUserTab.Name = "creatUserTab";
            this.creatUserTab.Padding = new System.Windows.Forms.Padding(3);
            this.creatUserTab.Size = new System.Drawing.Size(566, 305);
            this.creatUserTab.TabIndex = 0;
            this.creatUserTab.Text = "新建用户";
            this.creatUserTab.UseVisualStyleBackColor = true;
            // 
            // nSexBox
            // 
            this.nSexBox.FormattingEnabled = true;
            this.nSexBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.nSexBox.Location = new System.Drawing.Point(100, 139);
            this.nSexBox.Name = "nSexBox";
            this.nSexBox.Size = new System.Drawing.Size(100, 25);
            this.nSexBox.TabIndex = 37;
            this.nSexBox.Text = "男";
            // 
            // nIsAdminBox
            // 
            this.nIsAdminBox.FormattingEnabled = true;
            this.nIsAdminBox.Items.AddRange(new object[] {
            "有",
            "无"});
            this.nIsAdminBox.Location = new System.Drawing.Point(388, 86);
            this.nIsAdminBox.Name = "nIsAdminBox";
            this.nIsAdminBox.Size = new System.Drawing.Size(100, 25);
            this.nIsAdminBox.TabIndex = 36;
            this.nIsAdminBox.Text = "无";
            // 
            // nBirthdayBox
            // 
            this.nBirthdayBox.Location = new System.Drawing.Point(100, 189);
            this.nBirthdayBox.Name = "nBirthdayBox";
            this.nBirthdayBox.Size = new System.Drawing.Size(138, 23);
            this.nBirthdayBox.TabIndex = 35;
            // 
            // nNursingHomeIdBox
            // 
            this.nNursingHomeIdBox.Location = new System.Drawing.Point(388, 136);
            this.nNursingHomeIdBox.Name = "nNursingHomeIdBox";
            this.nNursingHomeIdBox.Size = new System.Drawing.Size(100, 23);
            this.nNursingHomeIdBox.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(289, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 20);
            this.label17.TabIndex = 33;
            this.label17.Text = "机构编号：";
            // 
            // nCancleSaveBtn
            // 
            this.nCancleSaveBtn.Location = new System.Drawing.Point(407, 259);
            this.nCancleSaveBtn.Name = "nCancleSaveBtn";
            this.nCancleSaveBtn.Size = new System.Drawing.Size(81, 28);
            this.nCancleSaveBtn.TabIndex = 17;
            this.nCancleSaveBtn.Text = "取消";
            this.nCancleSaveBtn.UseVisualStyleBackColor = true;
            this.nCancleSaveBtn.Click += new System.EventHandler(this.nCancleSaveBtn_Click);
            // 
            // nSaveUserBtn
            // 
            this.nSaveUserBtn.Location = new System.Drawing.Point(307, 259);
            this.nSaveUserBtn.Name = "nSaveUserBtn";
            this.nSaveUserBtn.Size = new System.Drawing.Size(81, 28);
            this.nSaveUserBtn.TabIndex = 16;
            this.nSaveUserBtn.Text = "提交";
            this.nSaveUserBtn.UseVisualStyleBackColor = true;
            this.nSaveUserBtn.Click += new System.EventHandler(this.nSaveUserBtn_Click);
            // 
            // nUserPhoneBox
            // 
            this.nUserPhoneBox.Location = new System.Drawing.Point(388, 186);
            this.nUserPhoneBox.Name = "nUserPhoneBox";
            this.nUserPhoneBox.Size = new System.Drawing.Size(100, 23);
            this.nUserPhoneBox.TabIndex = 15;
            this.nUserPhoneBox.Text = "13245678912";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(289, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "联系方式：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(43, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "生日：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(43, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "性别：";
            // 
            // nRealNameBox
            // 
            this.nRealNameBox.Location = new System.Drawing.Point(100, 91);
            this.nRealNameBox.Name = "nRealNameBox";
            this.nRealNameBox.Size = new System.Drawing.Size(100, 23);
            this.nRealNameBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(43, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(289, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "管理员权限：";
            // 
            // nUserIdBox
            // 
            this.nUserIdBox.Location = new System.Drawing.Point(100, 39);
            this.nUserIdBox.Name = "nUserIdBox";
            this.nUserIdBox.Size = new System.Drawing.Size(100, 23);
            this.nUserIdBox.TabIndex = 5;
            this.nUserIdBox.TextChanged += new System.EventHandler(this.nUserNameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(43, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "工号：";
            // 
            // nPasswordBox
            // 
            this.nPasswordBox.Location = new System.Drawing.Point(388, 36);
            this.nPasswordBox.Name = "nPasswordBox";
            this.nPasswordBox.Size = new System.Drawing.Size(100, 23);
            this.nPasswordBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(289, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "初始密码：";
            // 
            // deleteUserTab
            // 
            this.deleteUserTab.Controls.Add(this.dUserIDBox);
            this.deleteUserTab.Controls.Add(this.label11);
            this.deleteUserTab.Controls.Add(this.dCancleDeleteBtn);
            this.deleteUserTab.Controls.Add(this.deleteUserBtn);
            this.deleteUserTab.Controls.Add(this.dIDCardBox);
            this.deleteUserTab.Controls.Add(this.dSexBox);
            this.deleteUserTab.Controls.Add(this.dIsAdminBox);
            this.deleteUserTab.Controls.Add(this.dUserNameBox);
            this.deleteUserTab.Controls.Add(this.dBirthdayBox);
            this.deleteUserTab.Controls.Add(this.dRealNameBox);
            this.deleteUserTab.Controls.Add(this.dSuperiorBox);
            this.deleteUserTab.Controls.Add(this.label13);
            this.deleteUserTab.Controls.Add(this.label14);
            this.deleteUserTab.Controls.Add(this.label15);
            this.deleteUserTab.Controls.Add(this.label16);
            this.deleteUserTab.Controls.Add(this.label9);
            this.deleteUserTab.Controls.Add(this.label10);
            this.deleteUserTab.Controls.Add(this.label12);
            this.deleteUserTab.Location = new System.Drawing.Point(26, 4);
            this.deleteUserTab.Name = "deleteUserTab";
            this.deleteUserTab.Padding = new System.Windows.Forms.Padding(3);
            this.deleteUserTab.Size = new System.Drawing.Size(566, 305);
            this.deleteUserTab.TabIndex = 1;
            this.deleteUserTab.Text = "删除用户";
            this.deleteUserTab.UseVisualStyleBackColor = true;
            // 
            // dUserIDBox
            // 
            this.dUserIDBox.Location = new System.Drawing.Point(374, 68);
            this.dUserIDBox.Name = "dUserIDBox";
            this.dUserIDBox.ReadOnly = true;
            this.dUserIDBox.Size = new System.Drawing.Size(100, 23);
            this.dUserIDBox.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(317, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "工号：";
            // 
            // dCancleDeleteBtn
            // 
            this.dCancleDeleteBtn.Location = new System.Drawing.Point(393, 228);
            this.dCancleDeleteBtn.Name = "dCancleDeleteBtn";
            this.dCancleDeleteBtn.Size = new System.Drawing.Size(81, 28);
            this.dCancleDeleteBtn.TabIndex = 30;
            this.dCancleDeleteBtn.Text = "取消";
            this.dCancleDeleteBtn.UseVisualStyleBackColor = true;
            this.dCancleDeleteBtn.Click += new System.EventHandler(this.dCancleDeleteBtn_Click);
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.Location = new System.Drawing.Point(287, 228);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(81, 28);
            this.deleteUserBtn.TabIndex = 29;
            this.deleteUserBtn.Text = "删除";
            this.deleteUserBtn.UseVisualStyleBackColor = true;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // dIDCardBox
            // 
            this.dIDCardBox.Location = new System.Drawing.Point(374, 175);
            this.dIDCardBox.Name = "dIDCardBox";
            this.dIDCardBox.ReadOnly = true;
            this.dIDCardBox.Size = new System.Drawing.Size(159, 23);
            this.dIDCardBox.TabIndex = 28;
            // 
            // dSexBox
            // 
            this.dSexBox.Location = new System.Drawing.Point(374, 125);
            this.dSexBox.Name = "dSexBox";
            this.dSexBox.ReadOnly = true;
            this.dSexBox.Size = new System.Drawing.Size(100, 23);
            this.dSexBox.TabIndex = 27;
            // 
            // dIsAdminBox
            // 
            this.dIsAdminBox.Location = new System.Drawing.Point(108, 71);
            this.dIsAdminBox.Name = "dIsAdminBox";
            this.dIsAdminBox.ReadOnly = true;
            this.dIsAdminBox.Size = new System.Drawing.Size(100, 23);
            this.dIsAdminBox.TabIndex = 26;
            // 
            // dUserNameBox
            // 
            this.dUserNameBox.Location = new System.Drawing.Point(374, 25);
            this.dUserNameBox.Name = "dUserNameBox";
            this.dUserNameBox.ReadOnly = true;
            this.dUserNameBox.Size = new System.Drawing.Size(100, 23);
            this.dUserNameBox.TabIndex = 25;
            // 
            // dBirthdayBox
            // 
            this.dBirthdayBox.Location = new System.Drawing.Point(108, 175);
            this.dBirthdayBox.Name = "dBirthdayBox";
            this.dBirthdayBox.ReadOnly = true;
            this.dBirthdayBox.Size = new System.Drawing.Size(100, 23);
            this.dBirthdayBox.TabIndex = 24;
            // 
            // dRealNameBox
            // 
            this.dRealNameBox.Location = new System.Drawing.Point(108, 125);
            this.dRealNameBox.Name = "dRealNameBox";
            this.dRealNameBox.ReadOnly = true;
            this.dRealNameBox.Size = new System.Drawing.Size(100, 23);
            this.dRealNameBox.TabIndex = 23;
            // 
            // dSuperiorBox
            // 
            this.dSuperiorBox.Location = new System.Drawing.Point(108, 25);
            this.dSuperiorBox.Name = "dSuperiorBox";
            this.dSuperiorBox.ReadOnly = true;
            this.dSuperiorBox.Size = new System.Drawing.Size(100, 23);
            this.dSuperiorBox.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(289, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "身份证号：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(317, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 20);
            this.label14.TabIndex = 19;
            this.label14.Text = "性别：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(9, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "管理员权限：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(303, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "用户名：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(51, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "生日：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(51, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "姓名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(37, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "创建者：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteUser_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // deleteUser_ToolStripMenuItem
            // 
            this.deleteUser_ToolStripMenuItem.Name = "deleteUser_ToolStripMenuItem";
            this.deleteUser_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.deleteUser_ToolStripMenuItem.Text = "删除";
            this.deleteUser_ToolStripMenuItem.Click += new System.EventHandler(this.deleteUser_ToolStripMenuItem_Click);
            // 
            // userName
            // 
            this.userName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userName.HeaderText = "用户名";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Width = 66;
            // 
            // isAdmin
            // 
            this.isAdmin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isAdmin.HeaderText = "管理员权限";
            this.isAdmin.Name = "isAdmin";
            this.isAdmin.ReadOnly = true;
            this.isAdmin.Width = 90;
            // 
            // number
            // 
            this.number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.number.HeaderText = "机构编号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 78;
            // 
            // realName
            // 
            this.realName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.realName.HeaderText = "姓名";
            this.realName.Name = "realName";
            this.realName.ReadOnly = true;
            this.realName.Width = 54;
            // 
            // sex
            // 
            this.sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 54;
            // 
            // idCard
            // 
            this.idCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCard.HeaderText = "联系方式";
            this.idCard.Name = "idCard";
            this.idCard.ReadOnly = true;
            this.idCard.Width = 78;
            // 
            // birthday
            // 
            this.birthday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.birthday.HeaderText = "生日";
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            this.birthday.Width = 54;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 345);
            this.Controls.Add(this.AdminTabControl);
            this.Name = "AdminForm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.AdminTabControl.ResumeLayout(false);
            this.userListPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.userManagePage.ResumeLayout(false);
            this.userManageTabControl.ResumeLayout(false);
            this.creatUserTab.ResumeLayout(false);
            this.creatUserTab.PerformLayout();
            this.deleteUserTab.ResumeLayout(false);
            this.deleteUserTab.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AdminTabControl;
        private System.Windows.Forms.TabPage userListPage;
        private System.Windows.Forms.TabPage userManagePage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl userManageTabControl;
        private System.Windows.Forms.TabPage creatUserTab;
        private System.Windows.Forms.TextBox nUserPhoneBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nRealNameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nUserIdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nPasswordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage deleteUserTab;
        private System.Windows.Forms.TextBox dIDCardBox;
        private System.Windows.Forms.TextBox dSexBox;
        private System.Windows.Forms.TextBox dIsAdminBox;
        private System.Windows.Forms.TextBox dUserNameBox;
        private System.Windows.Forms.TextBox dBirthdayBox;
        private System.Windows.Forms.TextBox dRealNameBox;
        private System.Windows.Forms.TextBox dSuperiorBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button nCancleSaveBtn;
        private System.Windows.Forms.Button nSaveUserBtn;
        private System.Windows.Forms.Button dCancleDeleteBtn;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.TextBox nNursingHomeIdBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox dUserIDBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker nBirthdayBox;
        private System.Windows.Forms.ComboBox nIsAdminBox;
        private System.Windows.Forms.ComboBox nSexBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteUser_ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn isAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn realName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthday;
    }
}