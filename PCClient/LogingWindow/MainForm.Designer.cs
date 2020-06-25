namespace LogingWindow
{
    partial class MainForm
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
            this.searchByNameBut = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainWebBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personDetails_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetails_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassword_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manager_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUser_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUser_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elderManager_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amendRecord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中国地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.城市地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.集体位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.园区地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.居家服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最近打开位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本地数据库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateElderList_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateRingData_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hardRateLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.sexLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_Main = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlBtn = new System.Windows.Forms.Button();
            this.bloodPressureLable = new System.Windows.Forms.Label();
            this.temperatureLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchByNameBut
            // 
            this.searchByNameBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByNameBut.Location = new System.Drawing.Point(54, 3);
            this.searchByNameBut.Name = "searchByNameBut";
            this.searchByNameBut.Size = new System.Drawing.Size(78, 23);
            this.searchByNameBut.TabIndex = 0;
            this.searchByNameBut.Text = "按姓名检索";
            this.searchByNameBut.UseVisualStyleBackColor = true;
            this.searchByNameBut.Click += new System.EventHandler(this.searchByNameBut_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(3, 3);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(45, 21);
            this.searchBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(155, 210);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // mainWebBrowser
            // 
            this.mainWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.mainWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainWebBrowser.Name = "mainWebBrowser";
            this.mainWebBrowser.Size = new System.Drawing.Size(585, 374);
            this.mainWebBrowser.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户ToolStripMenuItem,
            this.elderManager_ToolStripMenuItem,
            this.地图ToolStripMenuItem,
            this.本地数据库管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personDetails_ToolStripMenuItem,
            this.manager_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // personDetails_ToolStripMenuItem
            // 
            this.personDetails_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetails_ToolStripMenuItem,
            this.changePassword_ToolStripMenuItem});
            this.personDetails_ToolStripMenuItem.Name = "personDetails_ToolStripMenuItem";
            this.personDetails_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.personDetails_ToolStripMenuItem.Text = "个人信息";
            // 
            // manageDetails_ToolStripMenuItem
            // 
            this.manageDetails_ToolStripMenuItem.Name = "manageDetails_ToolStripMenuItem";
            this.manageDetails_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.manageDetails_ToolStripMenuItem.Text = "基本资料";
            this.manageDetails_ToolStripMenuItem.Click += new System.EventHandler(this.manageDetails_ToolStripMenuItem_Click);
            // 
            // changePassword_ToolStripMenuItem
            // 
            this.changePassword_ToolStripMenuItem.Name = "changePassword_ToolStripMenuItem";
            this.changePassword_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.changePassword_ToolStripMenuItem.Text = "修改密码";
            this.changePassword_ToolStripMenuItem.Click += new System.EventHandler(this.changePassword_ToolStripMenuItem_Click);
            // 
            // manager_ToolStripMenuItem
            // 
            this.manager_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkUser_ToolStripMenuItem,
            this.manageUser_ToolStripMenuItem});
            this.manager_ToolStripMenuItem.Name = "manager_ToolStripMenuItem";
            this.manager_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.manager_ToolStripMenuItem.Text = "管理员";
            // 
            // checkUser_ToolStripMenuItem
            // 
            this.checkUser_ToolStripMenuItem.Name = "checkUser_ToolStripMenuItem";
            this.checkUser_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.checkUser_ToolStripMenuItem.Text = "查看用户";
            this.checkUser_ToolStripMenuItem.Click += new System.EventHandler(this.checkUser_ToolStripMenuItem_Click);
            // 
            // manageUser_ToolStripMenuItem
            // 
            this.manageUser_ToolStripMenuItem.Name = "manageUser_ToolStripMenuItem";
            this.manageUser_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.manageUser_ToolStripMenuItem.Text = "用户管理";
            this.manageUser_ToolStripMenuItem.Click += new System.EventHandler(this.manageUser_ToolStripMenuItem_Click);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exit_ToolStripMenuItem.Text = "退出登录";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // elderManager_ToolStripMenuItem
            // 
            this.elderManager_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开列表ToolStripMenuItem,
            this.关闭列表ToolStripMenuItem,
            this.刷新列表ToolStripMenuItem,
            this.newRecord_ToolStripMenuItem,
            this.amendRecord_ToolStripMenuItem,
            this.deleteRecord_ToolStripMenuItem});
            this.elderManager_ToolStripMenuItem.Name = "elderManager_ToolStripMenuItem";
            this.elderManager_ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.elderManager_ToolStripMenuItem.Text = "人员管理";
            // 
            // 打开列表ToolStripMenuItem
            // 
            this.打开列表ToolStripMenuItem.Name = "打开列表ToolStripMenuItem";
            this.打开列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开列表ToolStripMenuItem.Text = "打开列表";
            // 
            // 关闭列表ToolStripMenuItem
            // 
            this.关闭列表ToolStripMenuItem.Name = "关闭列表ToolStripMenuItem";
            this.关闭列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭列表ToolStripMenuItem.Text = "关闭列表";
            // 
            // 刷新列表ToolStripMenuItem
            // 
            this.刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            this.刷新列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.刷新列表ToolStripMenuItem.Text = "刷新列表";
            // 
            // newRecord_ToolStripMenuItem
            // 
            this.newRecord_ToolStripMenuItem.Name = "newRecord_ToolStripMenuItem";
            this.newRecord_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newRecord_ToolStripMenuItem.Text = "新建档案";
            this.newRecord_ToolStripMenuItem.Click += new System.EventHandler(this.newRecord_ToolStripMenuItem_Click);
            // 
            // amendRecord_ToolStripMenuItem
            // 
            this.amendRecord_ToolStripMenuItem.Name = "amendRecord_ToolStripMenuItem";
            this.amendRecord_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.amendRecord_ToolStripMenuItem.Text = "修改档案";
            this.amendRecord_ToolStripMenuItem.Click += new System.EventHandler(this.amendRecord_ToolStripMenuItem_Click);
            // 
            // deleteRecord_ToolStripMenuItem
            // 
            this.deleteRecord_ToolStripMenuItem.Name = "deleteRecord_ToolStripMenuItem";
            this.deleteRecord_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteRecord_ToolStripMenuItem.Text = "删除档案";
            this.deleteRecord_ToolStripMenuItem.Click += new System.EventHandler(this.deleteRecord_ToolStripMenuItem_Click);
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看地图ToolStripMenuItem,
            this.集体位置ToolStripMenuItem,
            this.最近打开位置ToolStripMenuItem,
            this.默认位置ToolStripMenuItem});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.地图ToolStripMenuItem.Text = "地图";
            // 
            // 查看地图ToolStripMenuItem
            // 
            this.查看地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中国地图ToolStripMenuItem,
            this.城市地图ToolStripMenuItem});
            this.查看地图ToolStripMenuItem.Name = "查看地图ToolStripMenuItem";
            this.查看地图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看地图ToolStripMenuItem.Text = "查看地图";
            // 
            // 中国地图ToolStripMenuItem
            // 
            this.中国地图ToolStripMenuItem.Name = "中国地图ToolStripMenuItem";
            this.中国地图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.中国地图ToolStripMenuItem.Text = "中国地图";
            // 
            // 城市地图ToolStripMenuItem
            // 
            this.城市地图ToolStripMenuItem.Name = "城市地图ToolStripMenuItem";
            this.城市地图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.城市地图ToolStripMenuItem.Text = "城市地图";
            // 
            // 集体位置ToolStripMenuItem
            // 
            this.集体位置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.园区地图ToolStripMenuItem,
            this.居家服务ToolStripMenuItem});
            this.集体位置ToolStripMenuItem.Name = "集体位置ToolStripMenuItem";
            this.集体位置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.集体位置ToolStripMenuItem.Text = "集体位置";
            // 
            // 园区地图ToolStripMenuItem
            // 
            this.园区地图ToolStripMenuItem.Name = "园区地图ToolStripMenuItem";
            this.园区地图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.园区地图ToolStripMenuItem.Text = "园区人员";
            // 
            // 居家服务ToolStripMenuItem
            // 
            this.居家服务ToolStripMenuItem.Name = "居家服务ToolStripMenuItem";
            this.居家服务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.居家服务ToolStripMenuItem.Text = "所有人员";
            // 
            // 最近打开位置ToolStripMenuItem
            // 
            this.最近打开位置ToolStripMenuItem.Name = "最近打开位置ToolStripMenuItem";
            this.最近打开位置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.最近打开位置ToolStripMenuItem.Text = "最近打开位置";
            // 
            // 默认位置ToolStripMenuItem
            // 
            this.默认位置ToolStripMenuItem.Name = "默认位置ToolStripMenuItem";
            this.默认位置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.默认位置ToolStripMenuItem.Text = "默认位置";
            // 
            // 本地数据库管理ToolStripMenuItem
            // 
            this.本地数据库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateElderList_ToolStripMenuItem,
            this.updateRingData_ToolStripMenuItem});
            this.本地数据库管理ToolStripMenuItem.Name = "本地数据库管理ToolStripMenuItem";
            this.本地数据库管理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.本地数据库管理ToolStripMenuItem.Text = "本地缓存管理";
            // 
            // updateElderList_ToolStripMenuItem
            // 
            this.updateElderList_ToolStripMenuItem.Name = "updateElderList_ToolStripMenuItem";
            this.updateElderList_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.updateElderList_ToolStripMenuItem.Text = "更新在院人员表";
            this.updateElderList_ToolStripMenuItem.Click += new System.EventHandler(this.updateElderList_ToolStripMenuItem_Click);
            // 
            // updateRingData_ToolStripMenuItem
            // 
            this.updateRingData_ToolStripMenuItem.Name = "updateRingData_ToolStripMenuItem";
            this.updateRingData_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.updateRingData_ToolStripMenuItem.Text = "更新手环数据";
            this.updateRingData_ToolStripMenuItem.Click += new System.EventHandler(this.updateRingData_ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 374);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchBox);
            this.panel4.Controls.Add(this.searchByNameBut);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(155, 29);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.temperatureLable);
            this.panel3.Controls.Add(this.bloodPressureLable);
            this.panel3.Controls.Add(this.hardRateLabel);
            this.panel3.Controls.Add(this.yearLabel);
            this.panel3.Controls.Add(this.sexLabel);
            this.panel3.Controls.Add(this.nameLabel);
            this.panel3.Controls.Add(this.IDLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 240);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 134);
            this.panel3.TabIndex = 3;
            // 
            // hardRateLabel
            // 
            this.hardRateLabel.AutoSize = true;
            this.hardRateLabel.Location = new System.Drawing.Point(19, 82);
            this.hardRateLabel.Name = "hardRateLabel";
            this.hardRateLabel.Size = new System.Drawing.Size(29, 12);
            this.hardRateLabel.TabIndex = 4;
            this.hardRateLabel.Text = "心率";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(94, 46);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 12);
            this.yearLabel.TabIndex = 3;
            this.yearLabel.Text = "年龄";
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(19, 46);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(29, 12);
            this.sexLabel.TabIndex = 2;
            this.sexLabel.Text = "性别";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(94, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 12);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "姓名";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(19, 20);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(29, 12);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "编号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.layoutControlBtn);
            this.panel2.Controls.Add(this.mainWebBrowser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(161, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 374);
            this.panel2.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_Main});
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(585, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_Main
            // 
            this.statusLabel_Main.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusLabel_Main.ForeColor = System.Drawing.Color.Blue;
            this.statusLabel_Main.Name = "statusLabel_Main";
            this.statusLabel_Main.Size = new System.Drawing.Size(570, 20);
            this.statusLabel_Main.Spring = true;
            this.statusLabel_Main.Text = "欢迎使用本系统";
            // 
            // layoutControlBtn
            // 
            this.layoutControlBtn.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.layoutControlBtn.Location = new System.Drawing.Point(3, 0);
            this.layoutControlBtn.Name = "layoutControlBtn";
            this.layoutControlBtn.Size = new System.Drawing.Size(35, 23);
            this.layoutControlBtn.TabIndex = 5;
            this.layoutControlBtn.Text = "<<";
            this.layoutControlBtn.UseVisualStyleBackColor = true;
            this.layoutControlBtn.Click += new System.EventHandler(this.layoutControlBtn_Click);
            // 
            // bloodPressureLable
            // 
            this.bloodPressureLable.AutoSize = true;
            this.bloodPressureLable.Location = new System.Drawing.Point(94, 82);
            this.bloodPressureLable.Name = "bloodPressureLable";
            this.bloodPressureLable.Size = new System.Drawing.Size(29, 12);
            this.bloodPressureLable.TabIndex = 5;
            this.bloodPressureLable.Text = "血压";
            // 
            // temperatureLable
            // 
            this.temperatureLable.AutoSize = true;
            this.temperatureLable.Location = new System.Drawing.Point(19, 109);
            this.temperatureLable.Name = "temperatureLable";
            this.temperatureLable.Size = new System.Drawing.Size(29, 12);
            this.temperatureLable.TabIndex = 6;
            this.temperatureLable.Text = "体温";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 399);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "集散化养老智能管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchByNameBut;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elderManager_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private System.Windows.Forms.WebBrowser mainWebBrowser;
        private System.Windows.Forms.ToolStripMenuItem personDetails_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manager_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUser_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUser_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRecord_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amendRecord_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRecord_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetails_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePassword_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label hardRateLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button layoutControlBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem 本地数据库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateElderList_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateRingData_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中国地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 城市地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 集体位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 园区地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 居家服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最近打开位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_Main;
        private System.Windows.Forms.Label bloodPressureLable;
        private System.Windows.Forms.Label temperatureLable;
    }
}