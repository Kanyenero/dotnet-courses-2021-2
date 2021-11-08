using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = @"D:\EPAM\EPAM\GitHub\dotnet-courses-2021-2\11-files\Files\Task 2 Test Directory";
            string fileFilter = "*.txt";

            CFHController controller = new CFHController(workingDirectory, fileFilter);

            controller.InitFileSystemWatchers();
            controller.StartFileSystemWatchers();
        }
    }
}
