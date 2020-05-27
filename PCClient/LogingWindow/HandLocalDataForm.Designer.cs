namespace LogingWindow
{
    partial class HandLocalDataForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeLayoutBtn = new System.Windows.Forms.Button();
            this.updateLocalListBtn = new System.Windows.Forms.Button();
            this.showLocalListBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.updateRingDataBtn = new System.Windows.Forms.Button();
            this.eDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.sDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.elderIDBox = new System.Windows.Forms.TextBox();
            this.elderNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_RingDT = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar_RingDT = new System.Windows.Forms.ToolStripProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changeLayoutBtn);
            this.panel1.Controls.Add(this.updateLocalListBtn);
            this.panel1.Controls.Add(this.showLocalListBtn);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 291);
            this.panel1.TabIndex = 0;
            // 
            // changeLayoutBtn
            // 
            this.changeLayoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeLayoutBtn.Location = new System.Drawing.Point(132, 0);
            this.changeLayoutBtn.Name = "changeLayoutBtn";
            this.changeLayoutBtn.Size = new System.Drawing.Size(26, 23);
            this.changeLayoutBtn.TabIndex = 3;
            this.changeLayoutBtn.Text = ">>";
            this.changeLayoutBtn.UseVisualStyleBackColor = true;
            this.changeLayoutBtn.Click += new System.EventHandler(this.changeLayoutBtn_Click);
            // 
            // updateLocalListBtn
            // 
            this.updateLocalListBtn.Location = new System.Drawing.Point(0, 0);
            this.updateLocalListBtn.Name = "updateLocalListBtn";
            this.updateLocalListBtn.Size = new System.Drawing.Size(89, 23);
            this.updateLocalListBtn.TabIndex = 2;
            this.updateLocalListBtn.Text = "更新本地列表";
            this.updateLocalListBtn.UseVisualStyleBackColor = true;
            this.updateLocalListBtn.Click += new System.EventHandler(this.updateLocalListBtn_Click);
            // 
            // showLocalListBtn
            // 
            this.showLocalListBtn.Location = new System.Drawing.Point(0, 24);
            this.showLocalListBtn.Name = "showLocalListBtn";
            this.showLocalListBtn.Size = new System.Drawing.Size(89, 23);
            this.showLocalListBtn.TabIndex = 1;
            this.showLocalListBtn.Text = "显示本地列表";
            this.showLocalListBtn.UseVisualStyleBackColor = true;
            this.showLocalListBtn.Click += new System.EventHandler(this.showLocalListBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(174, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.updateRingDataBtn);
            this.panel2.Controls.Add(this.eDateTimePicker);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.sDateTimePicker);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.elderIDBox);
            this.panel2.Controls.Add(this.elderNameBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(180, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 291);
            this.panel2.TabIndex = 1;
            // 
            // updateRingDataBtn
            // 
            this.updateRingDataBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateRingDataBtn.Location = new System.Drawing.Point(286, 230);
            this.updateRingDataBtn.Name = "updateRingDataBtn";
            this.updateRingDataBtn.Size = new System.Drawing.Size(91, 33);
            this.updateRingDataBtn.TabIndex = 9;
            this.updateRingDataBtn.Text = "更新数据";
            this.updateRingDataBtn.UseVisualStyleBackColor = true;
            this.updateRingDataBtn.Click += new System.EventHandler(this.updateRingDataBtn_Click);
            // 
            // eDateTimePicker
            // 
            this.eDateTimePicker.Location = new System.Drawing.Point(246, 176);
            this.eDateTimePicker.Name = "eDateTimePicker";
            this.eDateTimePicker.Size = new System.Drawing.Size(131, 21);
            this.eDateTimePicker.TabIndex = 8;
            this.eDateTimePicker.Value = new System.DateTime(2018, 8, 20, 23, 59, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(172, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "————";
            // 
            // sDateTimePicker
            // 
            this.sDateTimePicker.Location = new System.Drawing.Point(36, 177);
            this.sDateTimePicker.Name = "sDateTimePicker";
            this.sDateTimePicker.Size = new System.Drawing.Size(131, 21);
            this.sDateTimePicker.TabIndex = 6;
            this.sDateTimePicker.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(372, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "(编号)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(173, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "(姓名)";
            // 
            // elderIDBox
            // 
            this.elderIDBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.elderIDBox.Location = new System.Drawing.Point(246, 67);
            this.elderIDBox.Name = "elderIDBox";
            this.elderIDBox.ReadOnly = true;
            this.elderIDBox.Size = new System.Drawing.Size(120, 26);
            this.elderIDBox.TabIndex = 3;
            // 
            // elderNameBox
            // 
            this.elderNameBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.elderNameBox.Location = new System.Drawing.Point(47, 67);
            this.elderNameBox.Name = "elderNameBox";
            this.elderNameBox.ReadOnly = true;
            this.elderNameBox.Size = new System.Drawing.Size(120, 26);
            this.elderNameBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "请选择查询对象:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择查询时间段:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_RingDT,
            this.progressBar_RingDT});
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(606, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_RingDT
            // 
            this.statusLabel_RingDT.ActiveLinkColor = System.Drawing.Color.Red;
            this.statusLabel_RingDT.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusLabel_RingDT.ForeColor = System.Drawing.Color.Blue;
            this.statusLabel_RingDT.Name = "statusLabel_RingDT";
            this.statusLabel_RingDT.Size = new System.Drawing.Size(439, 17);
            this.statusLabel_RingDT.Spring = true;
            // 
            // progressBar_RingDT
            // 
            this.progressBar_RingDT.Name = "progressBar_RingDT";
            this.progressBar_RingDT.Size = new System.Drawing.Size(150, 16);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(606, 291);
            this.panel3.TabIndex = 11;
            // 
            // HandLocalDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 313);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Name = "HandLocalDataForm";
            this.Text = "本地缓存管理";
            this.Load += new System.EventHandler(this.HandLocalDataForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button changeLayoutBtn;
        private System.Windows.Forms.Button updateLocalListBtn;
        private System.Windows.Forms.Button showLocalListBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox elderIDBox;
        private System.Windows.Forms.TextBox elderNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateRingDataBtn;
        private System.Windows.Forms.DateTimePicker eDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker sDateTimePicker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_RingDT;
        private System.Windows.Forms.ToolStripProgressBar progressBar_RingDT;
        private System.Windows.Forms.Panel panel3;
    }
}