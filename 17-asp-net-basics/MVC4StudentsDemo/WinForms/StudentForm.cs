using Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinForms
{
	public partial class StudentForm : Form
	{
		private string fullName;
		private int year;
		private int passNumber;

		private bool createNew = true;


		#region Properties

		public string FullName
		{
			get
			{
				return fullName;
			}
		}

		public int Year
		{
			get
			{
				return year;
			}
		}

		public int PassNumber
		{
			get
			{
				return passNumber;
			}
		}

		#endregion

		public StudentForm()
		{
			InitializeComponent();
		}

		public StudentForm(Student student)
		{
			InitializeComponent();

			this.fullName = student.FullName;
			this.year = student.Year;
			this.passNumber = student.PassNumber;

			createNew = false;
		}

		private void Form_Load(object sender, EventArgs e)
		{
			txtFullName.Text = fullName;
			txtPassNumber.Text = passNumber.ToString();
			cbYear.Text = year.ToString();

			// cbYear.SelectedIndex = 0;

			if (createNew == true)
			{
				this.Text = "Регистрация нового студента";
				btnOK.Text = "Создать";
			}
			else
			{
				this.Text = "Редактирование записи о студенте";
				btnOK.Text = "Обновить";
			}
		}

		private void OK_Click(object sender, EventArgs e)
		{
			// fullName = txtFullName.Text;
			// year = Int32.Parse(cbYear.Text);
			// passNumber = Int32.Parse(txtPassNumber.Text);

			if (this.ValidateChildren() == true)
			{
				this.DialogResult = DialogResult.OK;
			}
			else 
			{
				this.DialogResult = DialogResult.None;
			}
		}

		private void FullName_Validating(object sender, CancelEventArgs e)
		{
			string input = txtFullName.Text.Trim();

			if (String.IsNullOrEmpty(input) == true)
			{
				errorProvider.SetError(txtFullName, "Некорректное значение!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(txtFullName, String.Empty);
				e.Cancel = false;
			}
		}

		private void FullName_Validated(object sender, EventArgs e)
		{
			fullName = txtFullName.Text.Trim();
		}

		private void PassNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string input = txtPassNumber.Text.Trim();

			int result;
			if (Int32.TryParse(input, out result) == false)
			{
				errorProvider.SetError(txtPassNumber, "Некорректное значение!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(txtPassNumber, String.Empty);
				e.Cancel = false;
			}
		}

		private void PassNumber_Validated(object sender, EventArgs e)
		{
			passNumber = Int32.Parse(txtPassNumber.Text);
		}

		private void Year_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string input = cbYear.Text.Trim();

			int result;
			if (Int32.TryParse(input, out result) == false)
			{
				errorProvider.SetError(cbYear, "Некорректное значение!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(cbYear, String.Empty);
				e.Cancel = false;
			}
		}

		private void Year_Validated(object sender, EventArgs e)
		{
			year = Int32.Parse(cbYear.Text);
		}
	}
}
