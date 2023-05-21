// See https://aka.ms/new-console-template for more information
string folderPath = @"C:\Users\igor_\OneDrive\Рабочий стол\SizeFolder";

try
{
    long folderSize = FolderSize(folderPath);
    Console.WriteLine($"Размер папки {folderPath}: {folderSize} байт");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

static long FolderSize(string folderPath)
{
    long folderSize = 0;
    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
    if (!directoryInfo.Exists)
    {
        throw new DirectoryNotFoundException($"Папка {folderPath} не найдена");
    }
    FileInfo[] files = directoryInfo.GetFiles();
    foreach (FileInfo file in files)
    {
        folderSize += file.Length;
    }
   
    DirectoryInfo[] subDirs = directoryInfo.GetDirectories();
    foreach(DirectoryInfo subDir in subDirs)
    {
        folderSize += FolderSize(subDir.FullName);
    }
    return folderSize;
}

