using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SICLib2.Manager
{
    public class FileManager
    {

        private StringBuilder Builder { get; set; } = new StringBuilder();

        private readonly int BuilderThreshold = 10000;
        private readonly int FileThreshold = 200000;

        private string FileDirectory { get; set; }
        private string FileName { get; set; }
        private string FileExtension { get; set; }
        private int FileNumber { get; set; } = 1;

        private int BuilderLines { get; set; } = 0;
        private int FileLines { get; set; } = 0;

        readonly object lockStringBuilder = new object();


        public FileManager(string directoryPath, string fileName, string fileExtension)
        {
            FileDirectory = directoryPath;
            FileName = fileName;
            FileExtension = fileExtension;
        }

        public void ConcatString(string line)
        {
            lock(lockStringBuilder)
            {
                Builder.Append(line);
                BuilderLines++;
                if (BuilderLines > BuilderThreshold)
                    WriteToFile();
            }
        }

        public void WriteBuilderToFile()
        {
            lock (lockStringBuilder)
            {
                WriteToFile();
            }
        }

        private void WriteToFile()
        {
            if (FileLines > FileThreshold)
            {
                FileLines = 0;
                FileNumber++;
            }
            var filePath = $"{FileDirectory}\\{FileName}_{FileNumber}.{FileExtension}";
            WriteLineFile(filePath);
            FileLines += BuilderLines;
            BuilderLines = 0;
        }

        private void WriteLineFile(string path)
        {
            File.AppendAllLines(path, new[] { Builder.ToString() });
        }

    }
}
