using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinForms
{
	public partial class StudentForm : Form
	{
		private readonly bool _createNew = true;

		public string FullName { get; private set; }

		public int Year { get; private set; }

		public int PassNumber { get; private set; }

		public StudentForm()
		{
			InitializeComponent();
		}

		public StudentForm(Student student)
		{
			InitializeComponent();

			FullName = student.FullName;
			Year = student.Year;
			PassNumber = student.PassNumber;

			_createNew = false;
		}

		private void Form_Load(object sender, EventArgs e)
		{
			txtFullName.Text = FullName;
			txtPassNumber.Text = PassNumber.ToString();
			cbYear.Text = Year.ToString();

			if (_createNew)
			{
				Text = "Регистрация нового студента";
				btnOK.Text = "Создать";
			}
			else
			{
				Text = "Редактирование записи о студенте";
				btnOK.Text = "Обновить";
			}
		}

		private void OK_Click(object sender, EventArgs e)
		{
			DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
		}

		private void FullName_Validating(object sender, CancelEventArgs e)
		{
			string input = txtFullName.Text.Trim();

			if (String.IsNullOrEmpty(input))
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
			FullName = txtFullName.Text.Trim();
		}

		private void PassNumber_Validating(object sender, CancelEventArgs e)
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
			PassNumber = Int32.Parse(txtPassNumber.Text);
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
			Year = Int32.Parse(cbYear.Text);
		}
	}
}
