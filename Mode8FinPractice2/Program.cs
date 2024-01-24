namespace Mode8FinPractice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\lino-\OneDrive\Рабочий стол\Новая папка (3)";
            Console.WriteLine($"Размер каталога:{GetFolderSize(path)} байт"); 
        }

        static long GetFolderSize(string path)
        {
            try
            {
                long size = 0;
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    FileInfo[] files = directory.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        size += file.Length;
                    }
                    DirectoryInfo[] folders = directory.GetDirectories();
                    foreach (DirectoryInfo folder in folders)
                    {
                        size += GetFolderSize(folder.FullName);
                    }
                    return size;
                }
                else
                {
                    Console.WriteLine("Каталога не существует либо введён неверный путь");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
