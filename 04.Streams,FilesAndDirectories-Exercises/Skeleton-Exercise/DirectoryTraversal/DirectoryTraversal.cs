namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
           SortedDictionary<string, List<FileInfo>> extentionsFiels 
                = new SortedDictionary<string, List<FileInfo>>();

            string[] fiels = Directory.GetFiles(inputFolderPath);

            foreach (string file in fiels)
            {
                FileInfo fileInfo = new(file);

                if (!extentionsFiels.ContainsKey(fileInfo.Extension))
                {
                    extentionsFiels.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extentionsFiels[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var extentionFiles in extentionsFiels.OrderByDescending(ef => ef.Value.Count))
            {
                sb.AppendLine(extentionFiles.Key);

                foreach (var file in extentionFiles.Value.OrderBy(x => x.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024.0:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
