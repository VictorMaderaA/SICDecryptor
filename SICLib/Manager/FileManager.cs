using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SICLib.Manager
{
    public class FileManager
    {

        private System.Text.StringBuilder Builder { get; set; } = new System.Text.StringBuilder();

        private readonly int BuilderThreshold = 10;
        private readonly int FileThreshold = 100000;

        private string FileDirectory { get; set; }
        private string FileName { get; set; }
        private string FileExtension { get; set; }
        private int FileNumber { get; set; } = 1;

        private int BuilderLines { get; set; } = 0;
        private int FileLines { get; set; } = 0;

        private string FileHeader { get; set; }

        readonly object lockStringBuilder = new object();


        public FileManager(string directoryPath, string fileName, string fileExtension, string fileHeader)
        {
            FileDirectory = directoryPath;
            FileName = fileName;
            FileExtension = fileExtension;
            FileHeader = fileHeader;
            ConcatNewLine(FileHeader);
        }

        public void ConcatNewLine(string line)
        {
            lock (lockStringBuilder)
            {
                Builder.Append(line + "\n");
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
            var filePath = $"{FileDirectory}\\{FileName}_{FileNumber.ToString("D2")}.{FileExtension}";
            WriteLineFile(filePath);
            FileLines += BuilderLines;
            BuilderLines = 0;
            if (FileLines > FileThreshold)
            {
                FileLines = 0;
                FileNumber++;
                ConcatNewLine(FileHeader);
            }
        }

        private void WriteLineFile(string path)
        {
            try
            {
                File.AppendAllLines(path, new[] { Builder.ToString() });
            }
            catch(Exception)
            {

            }
            Builder.Clear();

        }

    }
}
