using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public class FileDemo
	{
		public static void Demo()
		{
			File.Open(@"D:\Epam\Net\Testing\test.txt", FileMode.Create, FileAccess.Write, FileShare.None);
		}
	}
}
