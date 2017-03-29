using System;
using System.IO;

namespace Antennas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var antenna = new DipoleAntenna();

            var pm = antenna.BeamManager;

            for(var i = 0; i < pm.Values.Length; i++)
                Console.WriteLine("{0}\t-\t{1}", 
                    pm.Values[i].th * 180 / Math.PI, 
                    pm.Values[i].value);

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