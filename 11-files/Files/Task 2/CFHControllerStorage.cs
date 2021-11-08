using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_2
{
    /* 
     * 
     * [Change File History Controller]
     * 
     * В файле реализуются методы класса,
     * касающиеся операций с хранилищем
     * 
     */
    public partial class CFHController
    {
        private void AddDirToStorage(string srcName)
        {
            Directory.CreateDirectory(Path.Combine(storageDirectory.FullName, srcName));
        }

        private void AddFileToStorage(string srcPath, string srcName, DateTime modifiedTime)
        {
            string destPath = RenameFileWithModificationTime(
                Path.Combine(storageDirectory.FullName, srcName), 
                modifiedTime);

            File.Copy(srcPath, destPath);
            File.SetCreationTime(destPath, modifiedTime);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void CopyFileFromStorage(string srcPath, DirectoryInfo destDirectory)
        {
            string[] extractFileName = Regex.Split(srcPath, storageName);
            string[] extractDirName = Regex.Split(extractFileName[1], Path.GetFileName(srcPath));

            string destDirectoryWithSubfolder = string.Concat(baseDirectory.FullName, extractDirName[0].TrimEnd('\\'));

            if (!Directory.Exists(destDirectoryWithSubfolder))
                Directory.CreateDirectory(destDirectoryWithSubfolder);

            File.Copy(srcPath, string.Concat(destDirectory.FullName, extractFileName[1]));
        }

        private string RenameFileWithModificationTime(string filePath, DateTime creationTime)
        {
            string modifiedFileName = string.Concat(
                Path.GetFileNameWithoutExtension(filePath),
                "_",
                creationTime.ToString()).
                Replace('.', '_').
                Replace(':', '_').
                Replace(' ', '_');

            modifiedFileName = string.Concat("\\", modifiedFileName, Path.GetExtension(filePath));

            return string.Concat(Path.GetDirectoryName(filePath), modifiedFileName);
        }

        private void MakeBackup(DateTime targetTime)
        {
            Console.WriteLine($"#: Backup to [{targetTime}] in process. Please, wait...");

            ClearDirectory(baseDirectory);

            List<string> allFilesList = new List<string>();
            List<string> filteredFilesList = new List<string>();

            // Получить все пути к файлам в хранилище
            allFilesList.AddRange(Directory.GetFiles(
                storageDirectory.FullName, 
                TargetFilesExtension,
                SearchOption.AllDirectories));

            // Отфильтровать файлы по введенному пользователем времени
            foreach (string file in allFilesList)
                if (new FileInfo(file).CreationTime < targetTime) 
                    filteredFilesList.Add(file);

            // Скопировать отфильтрованные файлы из хранилища в наблюдаемую папку
            foreach (string fpath in filteredFilesList)
            {
                CopyFileFromStorage(fpath, baseDirectory);
            }

            Console.WriteLine($"#: Backup to [{targetTime}] done.");
        }

        private void ClearDirectory(DirectoryInfo di)
        {
            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }
    }
}
