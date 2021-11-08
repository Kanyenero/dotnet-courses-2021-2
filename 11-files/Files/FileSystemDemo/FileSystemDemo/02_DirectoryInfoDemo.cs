using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public class DirectoryInfoDemo
	{
		public static void Demo()
		{
			// Привязаться к текущему рабочему каталогу
			DirectoryInfo dir1 = new DirectoryInfo(".");
			ShowWindowsDirectoryInfo(dir1);

			// Привязаться к C:\Windows
			DirectoryInfo dir2 = new DirectoryInfo(@"C:\Windows");

			ShowWindowsDirectoryInfo(dir2);

			// Привязаться к несуществующему каталогу, затем создать его
			DirectoryInfo dir3 = new DirectoryInfo(@"D:\Epam\Net\Testing");
			dir3.Create();

			ShowWindowsDirectoryInfo(dir3);
		}


		static void ShowWindowsDirectoryInfo(DirectoryInfo dir)
		{
			Console.WriteLine("***** Информация о каталоге *****\n");
			Console.WriteLine("Полный путь: {0}\nНазвание папки: {1}\nРодительский каталог: {2}\n" +
									 "Время создания: {3}\nАтрибуты: {4}\nКорневой каталог: {5}",
									 dir.FullName, dir.Name, dir.Parent, dir.CreationTime, dir.Attributes, dir.Root);
			Console.ReadLine();
		}
	}
}
