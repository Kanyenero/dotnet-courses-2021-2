
namespace WinFormsThreeLayer
{
    partial class AddPersonForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxBirthdateYear = new System.Windows.Forms.TextBox();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxBirthdateDay = new System.Windows.Forms.TextBox();
            this.textBoxBirthdateMonth = new System.Windows.Forms.TextBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.listBoxAwardsList = new System.Windows.Forms.ListBox();
            this.listBoxChoosedAwardsList = new System.Windows.Forms.ListBox();
            this.buttonRemoveListBoxItem = new System.Windows.Forms.Button();
            this.buttonAddListBoxItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(38, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(96, 6);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(274, 27);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(96, 39);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(274, 27);
            this.textBoxLastName.TabIndex = 3;
            this.textBoxLastName.TextChanged += new System.EventHandler(this.textBoxLastName_TextChanged);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(8, 42);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(82, 20);
            this.labelLastName.TabIndex = 2;
            this.labelLastName.Text = "Last Name:";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxBirthdateYear
            // 
            this.textBoxBirthdateYear.Location = new System.Drawing.Point(251, 72);
            this.textBoxBirthdateYear.MaxLength = 4;
            this.textBoxBirthdateYear.Name = "textBoxBirthdateYear";
            this.textBoxBirthdateYear.Size = new System.Drawing.Size(119, 27);
            this.textBoxBirthdateYear.TabIndex = 5;
            this.textBoxBirthdateYear.TextChanged += new System.EventHandler(this.textBoxBirthdateYear_TextChanged);
            this.textBoxBirthdateYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBirthdateYear_keyPress);
            // 
            // labelBirthDate
            // 
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Location = new System.Drawing.Point(17, 75);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(73, 20);
            this.labelBirthDate.TabIndex = 4;
            this.labelBirthDate.Text = "Birthdate:";
            this.labelBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(8, 319);
            this.labelInfo.MaximumSize = new System.Drawing.Size(290, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(133, 20);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "Everything is fine :)";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(96, 347);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(94, 29);
            this.buttonAccept.TabIndex = 8;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 347);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxBirthdateDay
            // 
            this.textBoxBirthdateDay.Location = new System.Drawing.Point(96, 72);
            this.textBoxBirthdateDay.MaxLength = 2;
            this.textBoxBirthdateDay.Name = "textBoxBirthdateDay";
            this.textBoxBirthdateDay.Size = new System.Drawing.Size(73, 27);
            this.textBoxBirthdateDay.TabIndex = 10;
            this.textBoxBirthdateDay.TextChanged += new System.EventHandler(this.textBoxBirthdateDay_TextChanged);
            this.textBoxBirthdateDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBirthdateDay_keyPress);
            // 
            // textBoxBirthdateMonth
            // 
            this.textBoxBirthdateMonth.Location = new System.Drawing.Point(175, 72);
            this.textBoxBirthdateMonth.MaxLength = 2;
            this.textBoxBirthdateMonth.Name = "textBoxBirthdateMonth";
            this.textBoxBirthdateMonth.Size = new System.Drawing.Size(70, 27);
            this.textBoxBirthdateMonth.TabIndex = 11;
            this.textBoxBirthdateMonth.TextChanged += new System.EventHandler(this.textBoxBirthdateMonth_TextChanged);
            this.textBoxBirthdateMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBirthdateMonth_keyPress);
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(114, 102);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(33, 20);
            this.labelDay.TabIndex = 12;
            this.labelDay.Text = "day";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(185, 102);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(52, 20);
            this.labelMonth.TabIndex = 13;
            this.labelMonth.Text = "month";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(290, 102);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(37, 20);
            this.labelYear.TabIndex = 14;
            this.labelYear.Text = "year";
            // 
            // listBoxAwardsList
            // 
            this.listBoxAwardsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAwardsList.FormattingEnabled = true;
            this.listBoxAwardsList.ItemHeight = 20;
            this.listBoxAwardsList.Location = new System.Drawing.Point(8, 161);
            this.listBoxAwardsList.Name = "listBoxAwardsList";
            this.listBoxAwardsList.Size = new System.Drawing.Size(161, 142);
            this.listBoxAwardsList.TabIndex = 16;
            // 
            // listBoxChoosedAwardsList
            // 
            this.listBoxChoosedAwardsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxChoosedAwardsList.FormattingEnabled = true;
            this.listBoxChoosedAwardsList.ItemHeight = 20;
            this.listBoxChoosedAwardsList.Location = new System.Drawing.Point(209, 161);
            this.listBoxChoosedAwardsList.Name = "listBoxChoosedAwardsList";
            this.listBoxChoosedAwardsList.Size = new System.Drawing.Size(161, 142);
            this.listBoxChoosedAwardsList.TabIndex = 17;
            // 
            // buttonRemoveListBoxItem
            // 
            this.buttonRemoveListBoxItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveListBoxItem.Location = new System.Drawing.Point(174, 161);
            this.buttonRemoveListBoxItem.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonRemoveListBoxItem.Name = "buttonRemoveListBoxItem";
            this.buttonRemoveListBoxItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.buttonRemoveListBoxItem.Size = new System.Drawing.Size(31, 45);
            this.buttonRemoveListBoxItem.TabIndex = 18;
            this.buttonRemoveListBoxItem.Text = "<";
            this.buttonRemoveListBoxItem.UseVisualStyleBackColor = true;
            this.buttonRemoveListBoxItem.Click += new System.EventHandler(this.buttonRemoveListBoxItem_Click);
            // 
            // buttonAddListBoxItem
            // 
            this.buttonAddListBoxItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddListBoxItem.Location = new System.Drawing.Point(174, 208);
            this.buttonAddListBoxItem.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonAddListBoxItem.Name = "buttonAddListBoxItem";
            this.buttonAddListBoxItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.buttonAddListBoxItem.Size = new System.Drawing.Size(31, 45);
            this.buttonAddListBoxItem.TabIndex = 19;
            this.buttonAddListBoxItem.Text = ">";
            this.buttonAddListBoxItem.UseVisualStyleBackColor = true;
            this.buttonAddListBoxItem.Click += new System.EventHandler(this.buttonAddListBoxItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Choose Awards:";
            // 
            // AddPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 385);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddListBoxItem);
            this.Controls.Add(this.buttonRemoveListBoxItem);
            this.Controls.Add(this.listBoxChoosedAwardsList);
            this.Controls.Add(this.listBoxAwardsList);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.textBoxBirthdateMonth);
            this.Controls.Add(this.textBoxBirthdateDay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxBirthdateYear);
            this.Controls.Add(this.labelBirthDate);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddPersonForm";
            this.Text = "Add Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxBirthdateYear;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxBirthdateDay;
        private System.Windows.Forms.TextBox textBoxBirthdateMonth;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ListBox listBoxAwardsList;
        private System.Windows.Forms.ListBox listBoxChoosedAwardsList;
        private System.Windows.Forms.Button buttonRemoveListBoxItem;
        private System.Windows.Forms.Button buttonAddListBoxItem;
        private System.Windows.Forms.Label label1;
    }
}