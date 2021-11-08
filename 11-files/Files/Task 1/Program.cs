using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\EPAM\EPAM\GitHub\dotnet-courses-2021-2\11-files\Files\disposable_task_file.txt";

            ProcessFile(path);
        }

        static void ProcessFile(string pathToTxtFile)
        {
            int[] ints = ReadFile(pathToTxtFile, Encoding.UTF8);

            for (int i = 0; i < ints.Length; i++)
                ints[i] *= ints[i];

            //int[] ints = new int[100];
            //for (int i = 0; i < ints.Length; i++)
            //    ints[i] = i + 1;

            WriteFile(pathToTxtFile, Encoding.UTF8, ints);
        }

        static int[] ReadFile(string filePath, Encoding encoding)
        {
            int[] ints;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                // в общем случае некорректно, буфер служит для чтения данных порциями
                byte[] buffer = new byte[fs.Length];

                string fileContent = string.Empty;
                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    fileContent = encoding.GetString(buffer);
                    Console.WriteLine(fileContent);
                }

                ints = fileContent.Split('\n').Select(n => Convert.ToInt32(n)).ToArray();
            }

            return ints;
        }

        static void WriteFile(string filePath, Encoding encoding, int[] ints)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < ints.Length; i++)
                {
                    sb.Append(ints[i]);
                    sb.Append("\n");
                }
                
                byte[] buffer = encoding.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
