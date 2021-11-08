using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public class FileInfoDemo
	{
		public static void ImageDisplayFiles()
		{
			DirectoryInfo dir = new DirectoryInfo("C:\\Windows\\Web\\Wallpaper");

			// Получить все файлы с расширением .jpg
			FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

			// Сколько файлов найдено
			Console.WriteLine("Найдено {0} картинок", imageFiles.Length);

			// Вывести информацию о каждом файле
			foreach (FileInfo f in imageFiles)
			{
				Console.WriteLine("\n******************\n");
				Console.WriteLine("Имя файла: " + f.Name);
				Console.WriteLine("Размер файла: " + f.Length);
				Console.WriteLine("Время создания файла: " + f.CreationTime);
			}
			Console.ReadLine();
		}
	}
}
