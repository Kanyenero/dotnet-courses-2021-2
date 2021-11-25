namespace WinForms
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
			this.components = new System.ComponentModel.Container();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.ctlFile = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlFileRegister = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlFileEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlFileRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ctlFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctlContextRegister = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlContextEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlContextRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlStatusPanel = new System.Windows.Forms.StatusStrip();
			this.ctlStudentCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.ctlProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.lblInfo = new System.Windows.Forms.Label();
			this.splashTimer = new System.Windows.Forms.Timer(this.components);
			this.ctlTab = new System.Windows.Forms.TabControl();
			this.ctlStudentPage = new System.Windows.Forms.TabPage();
			this.ctlStudents = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ctlPicture = new System.Windows.Forms.PictureBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PassNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainMenu.SuspendLayout();
			this.ctlContextMenu.SuspendLayout();
			this.ctlStatusPanel.SuspendLayout();
			this.ctlTab.SuspendLayout();
			this.ctlStudentPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlStudents)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlFile,
            this.ctlHelp});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(588, 24);
			this.mainMenu.TabIndex = 0;
			// 
			// ctlFile
			// 
			this.ctlFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlFileRegister,
            this.ctlFileEdit,
            this.ctlFileRemove,
            this.toolStripMenuItem1,
            this.ctlFileExit});
			this.ctlFile.Name = "ctlFile";
			this.ctlFile.Size = new System.Drawing.Size(45, 20);
			this.ctlFile.Text = "Файл";
			// 
			// ctlFileRegister
			// 
			this.ctlFileRegister.Name = "ctlFileRegister";
			this.ctlFileRegister.Size = new System.Drawing.Size(180, 22);
			this.ctlFileRegister.Text = "Зарегистрировать...";
			this.ctlFileRegister.Click += new System.EventHandler(this.FileRegister_Click);
			// 
			// ctlFileEdit
			// 
			this.ctlFileEdit.Name = "ctlFileEdit";
			this.ctlFileEdit.Size = new System.Drawing.Size(180, 22);
			this.ctlFileEdit.Text = "Редактировать..";
			this.ctlFileEdit.Click += new System.EventHandler(this.FileEdit_Click);
			// 
			// ctlFileRemove
			// 
			this.ctlFileRemove.Name = "ctlFileRemove";
			this.ctlFileRemove.Size = new System.Drawing.Size(180, 22);
			this.ctlFileRemove.Text = "Удалить";
			this.ctlFileRemove.Click += new System.EventHandler(this.FileRemove_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
			// 
			// ctlFileExit
			// 
			this.ctlFileExit.Name = "ctlFileExit";
			this.ctlFileExit.Size = new System.Drawing.Size(180, 22);
			this.ctlFileExit.Text = "Выход";
			this.ctlFileExit.Click += new System.EventHandler(this.FileExit_Click);
			// 
			// ctlHelp
			// 
			this.ctlHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlHelpAbout});
			this.ctlHelp.Name = "ctlHelp";
			this.ctlHelp.Size = new System.Drawing.Size(59, 20);
			this.ctlHelp.Text = "Помощь";
			// 
			// ctlHelpAbout
			// 
			this.ctlHelpAbout.Name = "ctlHelpAbout";
			this.ctlHelpAbout.Size = new System.Drawing.Size(150, 22);
			this.ctlHelpAbout.Text = "О программе...";
			// 
			// ctlContextMenu
			// 
			this.ctlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlContextRegister,
            this.ctlContextEdit,
            this.ctlContextRemove});
			this.ctlContextMenu.Name = "ctlContextMenu";
			this.ctlContextMenu.Size = new System.Drawing.Size(175, 70);
			// 
			// ctlContextRegister
			// 
			this.ctlContextRegister.Name = "ctlContextRegister";
			this.ctlContextRegister.Size = new System.Drawing.Size(174, 22);
			this.ctlContextRegister.Text = "Зарегистировать...";
			this.ctlContextRegister.Click += new System.EventHandler(this.ContextRegister_Click);
			// 
			// ctlContextEdit
			// 
			this.ctlContextEdit.Name = "ctlContextEdit";
			this.ctlContextEdit.Size = new System.Drawing.Size(174, 22);
			this.ctlContextEdit.Text = "Редактировать...";
			this.ctlContextEdit.Click += new System.EventHandler(this.ContextEdit_Click);
			// 
			// ctlContextRemove
			// 
			this.ctlContextRemove.Name = "ctlContextRemove";
			this.ctlContextRemove.Size = new System.Drawing.Size(174, 22);
			this.ctlContextRemove.Text = "Удалить";
			this.ctlContextRemove.Click += new System.EventHandler(this.ContextRemove_Click);
			// 
			// ctlStatusPanel
			// 
			this.ctlStatusPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlStudentCount,
            this.ctlProgressBar});
			this.ctlStatusPanel.Location = new System.Drawing.Point(0, 361);
			this.ctlStatusPanel.Name = "ctlStatusPanel";
			this.ctlStatusPanel.Size = new System.Drawing.Size(588, 22);
			this.ctlStatusPanel.TabIndex = 3;
			this.ctlStatusPanel.Text = "statusStrip1";
			// 
			// ctlStudentCount
			// 
			this.ctlStudentCount.AutoSize = false;
			this.ctlStudentCount.Name = "ctlStudentCount";
			this.ctlStudentCount.Size = new System.Drawing.Size(109, 17);
			this.ctlStudentCount.Text = "toolStripStatusLabel1";
			// 
			// ctlProgressBar
			// 
			this.ctlProgressBar.Maximum = 20;
			this.ctlProgressBar.Name = "ctlProgressBar";
			this.ctlProgressBar.Size = new System.Drawing.Size(100, 16);
			this.ctlProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// lblInfo
			// 
			this.lblInfo.BackColor = System.Drawing.Color.SteelBlue;
			this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblInfo.ForeColor = System.Drawing.Color.White;
			this.lblInfo.Location = new System.Drawing.Point(0, 24);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblInfo.Size = new System.Drawing.Size(588, 40);
			this.lblInfo.TabIndex = 4;
			this.lblInfo.Text = "Учебный центр EPAM Systems";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splashTimer
			// 
			this.splashTimer.Enabled = true;
			this.splashTimer.Interval = 5000;
			this.splashTimer.Tick += new System.EventHandler(this.SplashTimer_Tick);
			// 
			// ctlTab
			// 
			this.ctlTab.Controls.Add(this.ctlStudentPage);
			this.ctlTab.Controls.Add(this.tabPage2);
			this.ctlTab.Dock = System.Windows.Forms.DockStyle.Top;
			this.ctlTab.Location = new System.Drawing.Point(0, 64);
			this.ctlTab.Name = "ctlTab";
			this.ctlTab.SelectedIndex = 0;
			this.ctlTab.Size = new System.Drawing.Size(588, 300);
			this.ctlTab.TabIndex = 5;
			// 
			// ctlStudentPage
			// 
			this.ctlStudentPage.Controls.Add(this.ctlStudents);
			this.ctlStudentPage.Location = new System.Drawing.Point(4, 22);
			this.ctlStudentPage.Name = "ctlStudentPage";
			this.ctlStudentPage.Padding = new System.Windows.Forms.Padding(3);
			this.ctlStudentPage.Size = new System.Drawing.Size(580, 274);
			this.ctlStudentPage.TabIndex = 0;
			this.ctlStudentPage.Text = "Студенты";
			this.ctlStudentPage.UseVisualStyleBackColor = true;
			// 
			// ctlStudents
			// 
			this.ctlStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ctlStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.PassNumber,
            this.Year});
			this.ctlStudents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlStudents.Location = new System.Drawing.Point(3, 3);
			this.ctlStudents.Name = "ctlStudents";
			this.ctlStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.ctlStudents.Size = new System.Drawing.Size(574, 268);
			this.ctlStudents.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.ctlPicture);
			this.tabPage2.Controls.Add(this.btnBrowse);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(512, 174);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Лого";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ctlPicture
			// 
			this.ctlPicture.Location = new System.Drawing.Point(4, 4);
			this.ctlPicture.Name = "ctlPicture";
			this.ctlPicture.Size = new System.Drawing.Size(408, 136);
			this.ctlPicture.TabIndex = 1;
			this.ctlPicture.TabStop = false;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(336, 144);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 0;
			this.btnBrowse.Text = "Открыть...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.Browse_Click);
			// 
			// FullName
			// 
			this.FullName.DataPropertyName = "FullName";
			this.FullName.HeaderText = "FIO";
			this.FullName.Name = "FullName";
			this.FullName.ReadOnly = true;
			this.FullName.Width = 200;
			// 
			// PassNumber
			// 
			this.PassNumber.DataPropertyName = "PassNumber";
			this.PassNumber.HeaderText = "Pass";
			this.PassNumber.Name = "PassNumber";
			// 
			// Year
			// 
			this.Year.DataPropertyName = "Year";
			this.Year.HeaderText = "Year";
			this.Year.Name = "Year";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 383);
			this.Controls.Add(this.ctlTab);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.ctlStatusPanel);
			this.Controls.Add(this.mainMenu);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Список студентов";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ctlContextMenu.ResumeLayout(false);
			this.ctlStatusPanel.ResumeLayout(false);
			this.ctlStatusPanel.PerformLayout();
			this.ctlTab.ResumeLayout(false);
			this.ctlStudentPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlStudents)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem ctlFile;
		private System.Windows.Forms.ToolStripMenuItem ctlFileExit;
		private System.Windows.Forms.ToolStripMenuItem ctlHelp;
		private System.Windows.Forms.ToolStripMenuItem ctlHelpAbout;
		private System.Windows.Forms.StatusStrip ctlStatusPanel;
		private System.Windows.Forms.ToolStripStatusLabel ctlStudentCount;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.ToolStripMenuItem ctlFileRegister;
		private System.Windows.Forms.ToolStripMenuItem ctlFileEdit;
		private System.Windows.Forms.ToolStripMenuItem ctlFileRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip ctlContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ctlContextRegister;
		private System.Windows.Forms.ToolStripMenuItem ctlContextRemove;
		private System.Windows.Forms.ToolStripMenuItem ctlContextEdit;
		private System.Windows.Forms.Timer splashTimer;
		private System.Windows.Forms.ToolStripProgressBar ctlProgressBar;
		private System.Windows.Forms.TabControl ctlTab;
		private System.Windows.Forms.TabPage ctlStudentPage;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.PictureBox ctlPicture;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.DataGridView ctlStudents;
		private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
		private System.Windows.Forms.DataGridViewTextBoxColumn PassNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn Year;
	}
}

