using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testRepoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "You can download the file and read it!";
            while (true)
            {
                Console.WriteLine(testString);
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Addition");              
                Console.WriteLine("55 - Download txt file");
                Console.WriteLine("56 - Read text from downl.file");
                Console.WriteLine("57 - Remove downloaded file");
                Console.WriteLine("59 - Count special marks (!) in text");
                int input = 99;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                if (input == 0)
                    break;
                if (input == 55)
                    DownloadFileFromWeb();
                if (input == 56)
                    ReadDownloadedFile();
                if (input == 57)
                    RemoveDownloadedFile();
                if (input == 58)
                    CountSpecialMarks();
            }

        }

        static string ReadFileToString()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            if (!File.Exists(path))
                return string.Empty;
            string fileString = File.ReadAllText(path);
            return fileString;
        }

        static void CountSpecialMarks()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return;
            int result = fileString.ToCharArray().Count(c => c == '!');
            //int result1 = str.Length - str.Replace("a", "").Length;
            //int result2 = str.Split('a').Length - 1;
            Console.WriteLine("Number of '!' in text: " + result);
        }

        static void RemoveDownloadedFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            if (!File.Exists(path))
                return;
            File.Delete(path);
            Console.WriteLine("File was deleted!");
        }

        static void ReadDownloadedFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            if (!File.Exists(path))
                return;
            string fileString = File.ReadAllText(path);
            Console.WriteLine("\n"+fileString);
        }

        static void DownloadFileFromWeb()
        {
            Console.WriteLine("Download request processing!");
            string remoteUri = "https://s3.zylowski.net/public/input/1.txt";

            WebClient myWebClient = new WebClient();
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", "1.txt", 
                remoteUri.Substring(0,remoteUri.Length-5));

            myWebClient.DownloadFile(remoteUri, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt");
            Console.WriteLine("Successfully Downloaded File \"{0}\"", remoteUri);
        }
    }
}
