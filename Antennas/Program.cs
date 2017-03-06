using System;
using System.IO;

namespace Antennas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher("c:\\123");
            fsw.Created += FswOnCreated;
            fsw.Deleted += FswOnDeleted;
            fsw.EnableRaisingEvents = true;

            Console.ReadLine();
        }

        private static void FswOnCreated(object Sender, FileSystemEventArgs e)
        {
            Console.WriteLine("В каталоге c:\\123 создан файл:");
            Console.WriteLine(e.Name);
            Console.WriteLine(e.FullPath);
        }

        private static void FswOnDeleted(object Sender, FileSystemEventArgs e)
        {
            Console.WriteLine("В каталоге c:\\123 удалён файл:");
            Console.WriteLine(e.Name);
            Console.WriteLine(e.FullPath);
        }
    }
}