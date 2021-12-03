using System;
using System.IO;

namespace Task_2
{
    /* 
     * 
     * [Change File History Controller]
     * 
     * В файле реализуются методы, касающиеся
     * настройки и запуска модуля FileSystemWatcher
     * 
     */
    public partial class CFHController
    {
        public void InitFileSystemWatchers()
        {
            fsw_Init(out txtWatcher, TargetFilesExtension, NotifyFilters.FileName | NotifyFilters.LastWrite);
            fsw_Init(out dirWatcher, "*.*", NotifyFilters.DirectoryName);
        }

        public void StartFileSystemWatchers()
        {
            fsw_BeginWork(txtWatcher);
            fsw_BeginWork(dirWatcher);

            Console.WriteLine("Press \'o\' to enable Observation Mode\n" +
                              "Press \'r\' to enable Rollback Mode\n" +
                              "Press \'q\' to stop program.\n\n");

            while(true)
            {
                string controlSymbol = Console.ReadLine();

                if (controlSymbol == "o") 
                { 
                    Mode = CFHControllerMode.Observation;
                    Console.WriteLine($"#: Mode changed to [{Mode}]");
                }

                if (controlSymbol == "r") 
                { 
                    Mode = CFHControllerMode.Rollback;
                    Console.WriteLine($"#: Mode changed to [{Mode}]");
                    Console.Write($"#: Type backup DateTime [dd.mm.yyyy hh:mm:ss]: ");
                    string bckpTime = Console.ReadLine();

                    try
                    {
                        userBackupTime = DateTime.Parse(bckpTime);
                        Console.WriteLine("#: [Input parsed with success: {0}]", userBackupTime);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("#: Unable to parse '{0}'", bckpTime);
                    }

                    MakeBackup(userBackupTime);
                }

                if (controlSymbol == "q")
                {
                    Console.WriteLine($"#: Program stopped");
                    return;
                }
            }
        }

        private void fsw_Init(out FileSystemWatcher fsw, string targetFilesExtension, NotifyFilters filterMask)
        {
            fsw = new FileSystemWatcher
            {
                Path = BaseDirectoryPath,
                Filter = targetFilesExtension,
                NotifyFilter = filterMask,
                IncludeSubdirectories = true
            };

            // Подписаться на события
            if(filterMask == NotifyFilters.DirectoryName)
            {
                fsw.Created += new FileSystemEventHandler(fsw_OnDirectoryCreated);
            }
            else
            {
                fsw.Changed += fsw_OnFileChanged;
                fsw.Created += new FileSystemEventHandler(fsw_OnFileCreated);
                fsw.Deleted += new FileSystemEventHandler(fsw_OnFileDeleted);
                fsw.Renamed += new RenamedEventHandler(fsw_OnFileRenamed);
            }

            Console.WriteLine(FileSystemWatcherTitle(fsw));
        }

        private string FileSystemWatcherTitle(FileSystemWatcher fsw)
        {
            return string.Format($"#> File System Watcher Initialised\n" +
                                 $"#: Choosed NotifyFilters\n" +
                                 $"#:     [{fsw.NotifyFilter}]\n" +
                                 $"#: \n" +
                                 $"#: Subdirectories included\n" +
                                 $"#: ");
        }

        private void fsw_BeginWork(FileSystemWatcher fsw)
        {
            // Запустить модуль
            fsw.EnableRaisingEvents = true;

            Console.WriteLine($"#: {fsw} started work!");
        }

        /*
         * 
         * Обработчики событий FileSystemWatcher
         * для директорий
         * 
         */
        private void fsw_OnDirectoryCreated(object source, FileSystemEventArgs e)
        {
            if (Mode == CFHControllerMode.Observation)
            {
                Console.WriteLine("CREATED DIR [{0}]", e.Name);
                AddDirToStorage(e.Name);
            }
        }

        /*
         * 
         * Обработчики событий FileSystemWatcher
         * для файлов
         * 
         */
        private void fsw_OnFileCreated(object source, FileSystemEventArgs e)
        {
            if(Mode == CFHControllerMode.Observation)
            {
                Console.WriteLine("CREATED FILE [{0}]", e.Name);
                AddFileToStorage(e.FullPath, e.Name, File.GetCreationTime(e.FullPath));
            }
        }
        private void fsw_OnFileDeleted(object source, FileSystemEventArgs e)
        {
            if (Mode == CFHControllerMode.Observation)
            {
                Console.WriteLine("DELETED FILE [{0}]", e.Name);
            }
        }
        private void fsw_OnFileChanged(object source, FileSystemEventArgs e)
        {
            if (Mode == CFHControllerMode.Observation)
            {
                Console.WriteLine("CHANGED FILE [{0}]", e.Name);
                AddFileToStorage(e.FullPath, e.Name, File.GetLastWriteTime(e.FullPath));
            }
        }
        private void fsw_OnFileRenamed(object source, RenamedEventArgs e)
        {
            if (Mode == CFHControllerMode.Observation)
            {
                Console.WriteLine("RENAMED FILE [{0}] to [{1}]", e.OldName, e.Name);
                AddFileToStorage(e.FullPath, e.Name, File.GetLastWriteTime(e.FullPath));
            }
        }
    }
}
