using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public class FileStreamDemo
	{
		public static void Demo()
		{
			DirectoryInfo dir = new DirectoryInfo(@"D:\Epam\Net\Testing");
			dir.Create();

			// предпочтительно использовать методы Path для создания адресов
			string filePath = Path.Combine(dir.FullName, "FileStreamtest.txt");

			// содержит методы для конвертации сстроки в массив байт и обратно
			UTF8Encoding encoding = new UTF8Encoding();


			using (FileStream fs = File.Create(filePath))
			{
				byte[] info = encoding.GetBytes("Тест кирилицы");
				fs.Write(info, 0, info.Length);
			}

			using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
				// в общем случае некорректно, буфер служит для чтения данных порциями
				byte[] buffer = new byte[fs.Length];

				while (fs.Read(buffer, 0, buffer.Length) > 0)
				{
					string fileContent = encoding.GetString(buffer);
					Console.WriteLine(fileContent);
				}
			}
		}
	}
}
