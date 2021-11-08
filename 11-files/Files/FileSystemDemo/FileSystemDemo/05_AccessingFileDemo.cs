using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public class AccessingFileDemo
	{
		public static void Demo()
		{
			DirectoryInfo dir = new DirectoryInfo(@"D:\Net\Testing");
			dir.Create();

			// предпочтительно использовать методы Path для создания адресов
			string filePath = Path.Combine(dir.FullName, "test.txt");

			FileInfo file = new FileInfo(filePath);
			using (StreamWriter sw = file.AppendText())
			{
				sw.WriteLine("Тест кирилицы");
			}

			using (StreamReader sr = file.OpenText())
			{
				string fileContent = sr.ReadToEnd();
				Console.WriteLine(fileContent);
			}
		}
	}
}
