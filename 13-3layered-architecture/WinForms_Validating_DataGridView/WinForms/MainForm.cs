using Department.BLL;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForms
{
	public partial class MainForm : Form
	{
		private enum StudentSortMode { Asceding, Desceding };

		private readonly StudentsBL students;

		private SplashForm splashForm;
		private StudentSortMode sortMode = StudentSortMode.Asceding;

		
 

		public MainForm()
		{
			students = new StudentsBL();
			InitializeComponent();
			
			//
			this.Visible = false;
		}

		private void FileExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//CreateStudentGrid();

			//splashForm = new SplashForm();
			//splashForm.Show(this);


			//SortStudentsByFullNameAsc();
			//DisplayStudents(students);

			ctlStudents.DataSource = students.InitList();
		}

		private void CreateStudentGrid()
		{
			ctlStudents.AutoGenerateColumns = false;

			ctlStudents.Columns.Add(new DataGridViewColumn()
			{
				CellTemplate = new DataGridViewTextBoxCell(),
				DataPropertyName = "FullName",
				HeaderText = "Ф.И.О.",
				Width = 200
			});

			ctlStudents.Columns.Add(new DataGridViewColumn()
			{
				CellTemplate = new DataGridViewTextBoxCell(),
				DataPropertyName = "PassNumber",
				HeaderText = "Номер студ. билета",
				Width = 70
			});

			ctlStudents.Columns.Add(new DataGridViewColumn()
			{
				CellTemplate = new DataGridViewTextBoxCell(),
				DataPropertyName = "Year",
				HeaderText = "Год зачисления",
				Width = 70
			});
		}

		private void DisplayStudents()
		{
			// Data binding
			ctlStudents.DataSource = null;
			ctlStudents.DataSource = students.GetList();

			/*
			ctlStudents.Items.Clear();

			for (int i = 0; i < students.Count; i++)
			{
				Student student = students[i];

				ListViewItem lvi = new ListViewItem();
				lvi.Text = (i + 1).ToString(); // 1-я колонка

				lvi.SubItems.Add(student.FullName); 
				lvi.SubItems.Add(student.Year.ToString()); 
				lvi.SubItems.Add(student.PassNumber.ToString());

				ctlStudents.Items.Add(lvi);
			}
			*/

			//ctlStudentCount.Text = String.Format("Учебный центр EPAM Systems: {0}", students.Count);
			//ctlProgressBar.Value = students.Count;
		}

		private void Students_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			EditSelectedStudent();
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
				students.Add(form.FullName, form.Year, form.PassNumber);
				DisplayStudents();
			}
		}

		private void EditSelectedStudent()
		{
			if (ctlStudents.SelectedCells.Count > 0)
			{
				Student student = (Student) ctlStudents.SelectedCells[0].OwningRow.DataBoundItem;

				/*StudentForm form = new StudentForm(student);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					student.FullName = form.FullName;
					student.Year = form.Year;
					student.PassNumber = form.PassNumber;

					DisplayStudents(students);
				}*/
			}

			/*
			if (ctlStudents.SelectedIndices.Count > 0)
			{
				int index = ctlStudents.SelectedIndices[0];

				Student student = students[index];

				StudentForm form = new StudentForm(student);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					student.FullName = form.FullName;
					student.Year = form.Year;
					student.PassNumber = form.PassNumber;

					DisplayStudents(students);
				}
			}
			 */ 
		}

		private void RemoveSelectedStudent()
		{
			if (ctlStudents.SelectedCells.Count > 0)
			{
				Student student = (Student) ctlStudents.SelectedCells[0].OwningRow.DataBoundItem;

				/*students.Remove(student);
				DisplayStudents(students);*/
			}

			/*
			if (ctlStudents.SelectedIndices.Count > 0)
			{
				int index = ctlStudents.SelectedIndices[0];

				students.RemoveAt(index);
				DisplayStudents(students);
			}*/
		}

		private void SplashTimer_Tick(object sender, EventArgs e)
		{
			//splashForm.Close();
			//splashTimer.Enabled = false;

			this.WindowState = FormWindowState.Normal;
			this.Visible = true;
		}

		private void Students_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == 1)
			{
				if (sortMode == StudentSortMode.Asceding)
				{
					students.SortStudentsByFullNameDesc();
					sortMode = StudentSortMode.Desceding;
				}
				else
				{
					students.SortStudentsByFullNameAsc();
					sortMode = StudentSortMode.Asceding;
				}

				DisplayStudents();
			}
		}

		private void Browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "*.jpg";

			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				ctlPicture.Image = Image.FromFile(fileName);
			}
		}
	}
}

