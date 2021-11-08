using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemDemo
{
	public static class EvironmentDemo
	{
		public static void EnvironmentDemo()
		{
			Console.WriteLine("CurrentDomain.BaseDirectory: \n\t{0}", AppDomain.CurrentDomain.BaseDirectory);
			Console.WriteLine("CurrentDirectory: \n\t{0}", Environment.CurrentDirectory);
			Console.WriteLine("Is64BitOperatingSystem: \n\t{0}", Environment.Is64BitOperatingSystem);
			Console.WriteLine("MachineName: \n\t{0}", Environment.MachineName);
			Console.WriteLine("OSVersion.VersionString: \n\t{0}", Environment.OSVersion.VersionString);
			Console.WriteLine("SystemDirectory: \n\t{0}", Environment.SystemDirectory);
			Console.WriteLine("UserName: \n\t{0}", Environment.UserName);
			Console.WriteLine("SpecialFolder.LocalApplicationData: \n\t{0}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
		}

		public static void DrivesDemo()
		{
			var drives = DriveInfo.GetDrives();

			foreach (var driveInfo in drives)
			{
				Console.WriteLine("Name {0}", driveInfo.Name);
				Console.WriteLine("DriveType {0}", driveInfo.DriveType);
				Console.WriteLine("IsReady {0}", driveInfo.IsReady);

				if (driveInfo.IsReady)
					Console.WriteLine("TotalFreeSpace {0} GB", driveInfo.TotalFreeSpace >> 30);
			}
		}
	}
}
