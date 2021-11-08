using System;
using System.IO;
using System.Collections.Generic;

namespace Task_2
{
    /*  
     *   [Change File History Controller]
     *   
     *
     *   Предоставляет возможность для всех текстовых файлов (*.txt), 
     *   находящихся в этой папке и вложенных подпапках, реализовать 
     *   сохранение истории изменений с возможностью отката состояния 
     *   к любому моменту
     *   
     */
    public partial class CFHController
    {
        // Определяет режим работы контроллера
        public CFHControllerMode Mode { get; set; }

        // Указывает базовую директорию для контроллера
        private string BaseDirectoryPath { get; }
        private readonly DirectoryInfo baseDirectory;

        // Хранит все версии отслеживаемых файлов
        private readonly DirectoryInfo storageDirectory;
        private readonly string storageName;

        // Хранит значение файлового фильтра
        private string TargetFilesExtension { get; }

        // Ожидает уведомления файловой системы об изменениях и
        // инициирует события при изменениях каталога или файла в каталоге
        private FileSystemWatcher txtWatcher;
        private FileSystemWatcher dirWatcher;

        // Этот словарь хранит пары <ключ, значение>
        // для файлов, помещаемых в хранилище
        // Ключ - время какой-либо операции над файлом
        // Значение - уникальное имя файла в хранилище
        Dictionary <DateTime, string> logList;

        // Время, вводимое пользователем, на которое
        // будет производиться откат
        DateTime userBackupTime;

        // Конструктор класса
        public CFHController
        (
            string baseDirectoryPath, 
            string targetFilesExtension, 
            CFHControllerMode mode = CFHControllerMode.Observation
        ) 
        {
            BaseDirectoryPath = baseDirectoryPath;
            TargetFilesExtension = targetFilesExtension;
            Mode = mode;

            baseDirectory = new DirectoryInfo(BaseDirectoryPath);
            storageName = "STORAGE";
            storageDirectory = new DirectoryInfo( 
                Path.GetFullPath( Path.Combine( Path.Combine( BaseDirectoryPath, @"..\" ), storageName) ) );

            if (!storageDirectory.Exists) storageDirectory.Create();

            logList = new Dictionary <DateTime, string>();

            Console.WriteLine(CFHControllerTitle());
        }

        private string CFHControllerTitle()
        {
            return string.Format($"#> Hello from Change File History Controller!\n" +
                                 $"#: \n" +
                                 $"#: Base Directory Path    [{baseDirectory.FullName}]\n" +
                                 $"#: File History Path      [{storageDirectory.FullName}]\n" +
                                 $"#: Target File Extension  [{TargetFilesExtension}]\n" +
                                 $"#: Controller Mode        [{Mode}]\n" +
                                 $"#: ");
        }
    }
}
