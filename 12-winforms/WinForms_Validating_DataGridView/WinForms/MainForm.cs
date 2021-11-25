using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForms
{
	public partial class MainForm : Form
	{
		private enum StudentSortMode { Asceding, Desceding };
		private StudentSortMode _sortMode = StudentSortMode.Asceding;
		private BindingList<Student> _students = new BindingList<Student>();

		public MainForm()
		{
			InitializeComponent();
		}

		private void FileExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_students.Add(new Student() { FullName = "Иванов И.И.", Year = 2010, PassNumber = 90000 });
			_students.Add(new Student() { FullName = "Петров И.И.", Year = 2011, PassNumber = 90001 });
			_students.Add(new Student() { FullName = "Никитин И.И.", Year = 2012, PassNumber = 90002 });

			SortStudentsByFullNameAsc();

			ctlStudents.DataSource = _students;
		}

		private void FileRegister_Click(object sender, EventArgs e)
		{
			RegisterNewStudent();
		}

		private void FileEdit_Click(object sender, EventArgs e)
		{
			EditSelectedStudent();
		}

		private void FileRemove_Click(object sender, EventArgs e)
		{
			RemoveSelectedStudent();
		}

		private void ContextRegister_Click(object sender, EventArgs e)
		{
			RegisterNewStudent();
		}

		private void ContextEdit_Click(object sender, EventArgs e)
		{
			EditSelectedStudent();
		}

		private void ContextRemove_Click(object sender, EventArgs e)
		{
			RemoveSelectedStudent();
		}

		private void RegisterNewStudent()
		{
			StudentForm form = new StudentForm();

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Student student = new Student();
				student.FullName = form.FullName;
				student.Year = form.Year;
				student.PassNumber = form.PassNumber;

				_students.Add(student);
			}
		}

		private void EditSelectedStudent()
		{
			if (ctlStudents.SelectedCells.Count > 0)
			{
				Student student = (Student)ctlStudents.SelectedCells[0].OwningRow.DataBoundItem;

				StudentForm form = new StudentForm(student);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					student.FullName = form.FullName;
					student.Year = form.Year;
					student.PassNumber = form.PassNumber;
				}
			}
		}

		private void RemoveSelectedStudent()
		{
			if (ctlStudents.SelectedCells.Count > 0)
			{
				Student student = (Student)ctlStudents.SelectedCells[0].OwningRow.DataBoundItem;
				_students.Remove(student);
			}
		}

		private void SortStudentsByFullNameAsc()
		{
			_students = new BindingList<Student>(_students.OrderBy(s => s.FullName).ToList());
		}

		private void SortStudentsByFullNameDesc()
		{
			_students = new BindingList<Student>(_students.OrderByDescending(s => s.FullName).ToList());
		}

		private void ctlStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				if (_sortMode == StudentSortMode.Asceding)
				{
					SortStudentsByFullNameDesc();
					_sortMode = StudentSortMode.Desceding;
				}
				else
				{
					SortStudentsByFullNameAsc();
					_sortMode = StudentSortMode.Asceding;
				}
			}
		}

		private void Browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "images|*.jpg";

			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				ctlPicture.Image = Image.FromFile(fileName);
			}
		}
	}
}

