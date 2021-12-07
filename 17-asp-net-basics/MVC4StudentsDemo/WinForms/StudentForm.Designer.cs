namespace WinForms
{
	partial class StudentForm
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblFullName = new System.Windows.Forms.Label();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblPassNumber = new System.Windows.Forms.Label();
			this.cbYear = new System.Windows.Forms.ComboBox();
			this.txtPassNumber = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(300, 156);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(220, 156);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "Сохранить";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.OK_Click);
			// 
			// lblFullName
			// 
			this.lblFullName.AutoSize = true;
			this.lblFullName.Location = new System.Drawing.Point(12, 12);
			this.lblFullName.Name = "lblFullName";
			this.lblFullName.Size = new System.Drawing.Size(97, 13);
			this.lblFullName.TabIndex = 0;
			this.lblFullName.Text = "Ф.И.О. студента:";
			// 
			// txtFullName
			// 
			this.errorProvider.SetIconPadding(this.txtFullName, 2);
			this.txtFullName.Location = new System.Drawing.Point(124, 12);
			this.txtFullName.MaxLength = 64;
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(248, 21);
			this.txtFullName.TabIndex = 1;
			this.txtFullName.Validating += new System.ComponentModel.CancelEventHandler(this.FullName_Validating);
			this.txtFullName.Validated += new System.EventHandler(this.FullName_Validated);
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(12, 80);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(91, 13);
			this.lblYear.TabIndex = 4;
			this.lblYear.Text = "Год зачисления:";
			// 
			// lblPassNumber
			// 
			this.lblPassNumber.AutoSize = true;
			this.lblPassNumber.Location = new System.Drawing.Point(12, 48);
			this.lblPassNumber.Name = "lblPassNumber";
			this.lblPassNumber.Size = new System.Drawing.Size(112, 13);
			this.lblPassNumber.TabIndex = 2;
			this.lblPassNumber.Text = "Номер студ. билета:";
			// 
			// cbYear
			// 
			this.cbYear.FormattingEnabled = true;
			this.errorProvider.SetIconPadding(this.cbYear, 2);
			this.cbYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012"});
			this.cbYear.Location = new System.Drawing.Point(124, 80);
			this.cbYear.MaxLength = 4;
			this.cbYear.Name = "cbYear";
			this.cbYear.Size = new System.Drawing.Size(121, 21);
			this.cbYear.TabIndex = 5;
			this.cbYear.Validating += new System.ComponentModel.CancelEventHandler(this.Year_Validating);
			this.cbYear.Validated += new System.EventHandler(this.Year_Validated);
			// 
			// txtPassNumber
			// 
			this.errorProvider.SetIconPadding(this.txtPassNumber, 2);
			this.txtPassNumber.Location = new System.Drawing.Point(124, 44);
			this.txtPassNumber.MaxLength = 5;
			this.txtPassNumber.Name = "txtPassNumber";
			this.txtPassNumber.Size = new System.Drawing.Size(96, 21);
			this.txtPassNumber.TabIndex = 3;
			this.txtPassNumber.Validating += new System.ComponentModel.CancelEventHandler(this.PassNumber_Validating);
			this.txtPassNumber.Validated += new System.EventHandler(this.PassNumber_Validated);
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// StudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(400, 190);
			this.Controls.Add(this.txtPassNumber);
			this.Controls.Add(this.cbYear);
			this.Controls.Add(this.lblPassNumber);
			this.Controls.Add(this.lblYear);
			this.Controls.Add(this.txtFullName);
			this.Controls.Add(this.lblFullName);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StudentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StudentForm";
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblFullName;
		private System.Windows.Forms.TextBox txtFullName;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblPassNumber;
		private System.Windows.Forms.ComboBox cbYear;
		private System.Windows.Forms.TextBox txtPassNumber;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}