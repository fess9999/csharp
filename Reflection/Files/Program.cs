using System;
using System.IO;
using System.Text;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //DirectoriesFun();
            //FunWithFiles();
            BigFile();

            Console.ReadLine();
        }

        private static void BigFile()
        {
            var bigFileName = "bigFile.txt";

            using (var streamReader = File.OpenText(bigFileName))
            {
                while (!streamReader.EndOfStream)
                {
                    Console.Write(streamReader.ReadLine());
                }
            }
        }

        private static void FunWithFiles()
        {
            var file1 = "Directory1/textFile1.txt";
            var file2 = "Directory1/textFile2.txt";

            var exists = File.Exists(file2);
            if (exists) File.Delete(file2);

            File.Copy(file1, file2);

            var text = File.ReadAllText(file2, Encoding.UTF8);
            var bytes = File.ReadAllBytes(file2);
            var lines = File.ReadAllLines(file2);

            File.Delete(file1);
            File.AppendAllText(file2, "\r\nThis is a second line of file");

            File.WriteAllText(file2, "New content of file");
        }

        private static void DirectoriesFun()
        {
            var directoryName = "MyDirectory";

            if (Directory.Exists(directoryName))
                Directory.Delete(directoryName, true);

            Directory.CreateDirectory(directoryName);

            var directories = Directory.GetDirectories(@"c:\Program Files", "*.*", SearchOption.TopDirectoryOnly);
            var files = Directory.GetFiles(@"c:\Program Files", "*.dll", SearchOption.AllDirectories);

            var info = new DirectoryInfo(directoryName);
            var exists = info.Exists;
        }
    }
}
