
namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPersons = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePersonFromTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePersons = new System.Windows.Forms.TabPage();
            this.tabPageRewards = new System.Windows.Forms.TabPage();
            this.dgvRewards = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePersons.SuspendLayout();
            this.tabPageRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersons
            // 
            this.dgvPersons.AllowUserToAddRows = false;
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AllowUserToResizeColumns = false;
            this.dgvPersons.AllowUserToResizeRows = false;
            this.dgvPersons.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPersons.Location = new System.Drawing.Point(6, 6);
            this.dgvPersons.MultiSelect = false;
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.RowHeadersWidth = 51;
            this.dgvPersons.Size = new System.Drawing.Size(938, 631);
            this.dgvPersons.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personsToolStripMenuItem,
            this.rewardsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personsToolStripMenuItem
            // 
            this.personsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPersonToTableToolStripMenuItem,
            this.removePersonFromTableToolStripMenuItem,
            this.removeToolStripMenuItem1});
            this.personsToolStripMenuItem.Name = "personsToolStripMenuItem";
            this.personsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.personsToolStripMenuItem.Text = "Persons";
            // 
            // addPersonToTableToolStripMenuItem
            // 
            this.addPersonToTableToolStripMenuItem.Name = "addPersonToTableToolStripMenuItem";
            this.addPersonToTableToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.addPersonToTableToolStripMenuItem.Text = "Add";
            this.addPersonToTableToolStripMenuItem.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // removePersonFromTableToolStripMenuItem
            // 
            this.removePersonFromTableToolStripMenuItem.Name = "removePersonFromTableToolStripMenuItem";
            this.removePersonFromTableToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.removePersonFromTableToolStripMenuItem.Text = "Edit";
            this.removePersonFromTableToolStripMenuItem.Click += new System.EventHandler(this.editPersonToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(146, 26);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removePersonToolStripMenuItem_Click);
            // 
            // rewardsToolStripMenuItem
            // 
            this.rewardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.rewardsToolStripMenuItem.Name = "rewardsToolStripMenuItem";
            this.rewardsToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.rewardsToolStripMenuItem.Text = "Rewards";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addRewardToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editRewardToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeRewardToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePersons);
            this.tabControl.Controls.Add(this.tabPageRewards);
            this.tabControl.Location = new System.Drawing.Point(12, 31);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(958, 676);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPagePersons
            // 
            this.tabPagePersons.Controls.Add(this.dgvPersons);
            this.tabPagePersons.Location = new System.Drawing.Point(4, 29);
            this.tabPagePersons.Name = "tabPagePersons";
            this.tabPagePersons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersons.Size = new System.Drawing.Size(950, 643);
            this.tabPagePersons.TabIndex = 0;
            this.tabPagePersons.Text = "Persons";
            this.tabPagePersons.UseVisualStyleBackColor = true;
            // 
            // tabPageRewards
            // 
            this.tabPageRewards.Controls.Add(this.dgvRewards);
            this.tabPageRewards.Location = new System.Drawing.Point(4, 29);
            this.tabPageRewards.Name = "tabPageRewards";
            this.tabPageRewards.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRewards.Size = new System.Drawing.Size(950, 643);
            this.tabPageRewards.TabIndex = 1;
            this.tabPageRewards.Text = "Rewards";
            this.tabPageRewards.UseVisualStyleBackColor = true;
            // 
            // dgvRewards
            // 
            this.dgvRewards.AllowUserToAddRows = false;
            this.dgvRewards.AllowUserToDeleteRows = false;
            this.dgvRewards.AllowUserToResizeColumns = false;
            this.dgvRewards.AllowUserToResizeRows = false;
            this.dgvRewards.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRewards.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRewards.Location = new System.Drawing.Point(6, 6);
            this.dgvRewards.MultiSelect = false;
            this.dgvRewards.Name = "dgvRewards";
            this.dgvRewards.RowHeadersWidth = 51;
            this.dgvRewards.Size = new System.Drawing.Size(938, 631);
            this.dgvRewards.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 719);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Persons and Rewards";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePersons.ResumeLayout(false);
            this.tabPageRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersons;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePersonFromTableToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePersons;
        private System.Windows.Forms.TabPage tabPageRewards;
        private System.Windows.Forms.DataGridView dgvRewards;
        private System.Windows.Forms.ToolStripMenuItem rewardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
    }
}

