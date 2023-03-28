using System.Runtime.CompilerServices;

namespace AsyncLogger
{
    public static class FileService
    {
        public static async Task WriteToFile(string log, string path, string fileName)
        {
            DirectoryInfo(path);
            using StreamWriter sw = new StreamWriter(path + fileName, true);
            await sw.WriteAsync(log);
            sw.Close();
        }

        public static void DirectoryInfo(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] fileInfos = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                if (fileInfos.Length > 3)
                {
                    fileInfos[0].Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
