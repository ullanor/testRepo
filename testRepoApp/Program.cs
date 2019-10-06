using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.WriteLine("55 - Download txt file");
                Console.WriteLine("56 - Read text from downl.file");
                Console.WriteLine("57 - Remove downloaded file");
                Console.WriteLine("59 - Count special marks (!) in text");
                Console.WriteLine("60 - test count punctuation marks!");
                Console.WriteLine("61 - count words!");
                Console.WriteLine("62 - count sentences");
                Console.WriteLine("63 - save stat file");
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
                {
                    RemoveDownloadedFile();
                    break;
                }
                if (input == 55)
                    DownloadFileFromWeb();
                if (input == 56)
                    ReadDownloadedFile();
                if (input == 57)
                    RemoveDownloadedFile();
                if (input == 59)
                    CountSpecialMarks();
                if (input == 60)
                    Console.WriteLine(CountPunctuationMarks());
                if (input == 61)
                    CountWordsInText();
                if (input == 62)
                    Console.WriteLine(CountSentences());
                if (input == 63)
                    SaveStatFile();
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

        static void SaveStatFile()
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "statystyki.txt")))
            {
                outputFile.WriteLine(CountSentences());
                outputFile.WriteLine(CountPunctuationMarks());
            }
            Console.WriteLine("statystyki.txt was created successfully!");
        }

        static string CountSentences()
        {
            //string tester = "blablab aljdskf lskdalf?? !?! lkadslajs alkjdslf.. lajsldfkj alsdjf aadf !! alsdfjl ads.";
            string tester = ReadFileToString();
            string pattern = "(?<!(\\?|\\.|!))(\\?|\\.|!)"; // <- this is super!
            int doubled = Regex.Matches(tester, pattern).Count;
            //Console.WriteLine(doubled);
            //Console.WriteLine("Number of sentences: {0}", doubled);
            return "Number of sentences: " + doubled;
        }
        static string CountPunctuationMarks()
        {

            //string tester = "blablab aljdskf lskdalf?? !?! lkadslajs alkjdslf.. lajsldfkj alsdjf aadf !! alsdfjl ads.";
            string tester = ReadFileToString();
            char[] punctuationMarks = { '!', '?', '.' ,':',';',',','-','[',']','{','}','(',')','\'','\"'};
            int result = tester.ToCharArray().Count(c => (punctuationMarks.Contains(c)));
            //Console.WriteLine("Number of punctuation marks: "+result);
            return "Number of punctuation marks: " + result;
            //web test is working !
            //System.Diagnostics.Process.Start("microsoft-edge:https://geldonia2.ddns.net:1610");
        }

        static void CountSpecialMarks()
        {
            //string fileString = ReadFileToString();
            // if (fileString == string.Empty)
            //     return;
            //int result = fileString.ToCharArray().Count(c => c == '!');
            //int result1 = str.Length - str.Replace("a", "").Length;
            //int result2 = str.Split('a').Length - 1;
            //Console.WriteLine("Number of '!' in text: " + result);
            string tester = ReadFileToString();
            string pattern = "(\\?|\\.|!)"; // <- this is super!
            int doubled = Regex.Matches(tester, pattern).Count;
            Console.WriteLine(doubled);
            Console.WriteLine("Number of sentences: {0}", doubled);
        }

        static void RemoveDownloadedFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//statystyki.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("webText.txt was deleted!");
            }
            if (File.Exists(path2))
            {
                File.Delete(path2);
                Console.WriteLine("statystyki.txt was deleted!");
            }
            Console.WriteLine("Quitting App ...");
            Console.ReadKey();
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

        public static void CountWordsInText()
        {


            string fileString = ReadFileToString();
            if (fileString == string.Empty)
            {
                Console.WriteLine("\nMusisz najpierw załadować plik!!!\n");
                return;
            }

            string[] source = fileString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in source select word;
            int wordCount = matchQuery.Count();
            Console.WriteLine(source.Count());
            Console.WriteLine("\nLiczba wyrazów w pliku to {0}\n", wordCount);




        }
    }
}
