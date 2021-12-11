using System;
using System.IO;
using System.Text;

namespace pocket_import_helper
{
    class Program
    {
        private const string _fileImport = "links.txt";
        private const string _fileExport = "links.html";

        private const string _htmlStart = "<!DOCTYPE html>\n<html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n<title>Instapaper: Export</title>\n</head>\n<body>\n<h1>Unread</h1>\n<ol>\n";
        private const string _htmlEnd = "</ol>\n</body>\n</html>";

        private const string _tagStart = "<li><a href=\"";
        private const string _tagEnd = "\"></a>\n";

        private const string _http = "http://";
        private const string _https = "https://";

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        private static bool Menu()
        {
            Console.Clear();

            Console.WriteLine("Hello! Thanks for using \"Pocket Import Helper\"!\nDeveloped by Danil Kostylev.\n");
            Console.WriteLine("This program will help you make a file ready for import into Pocket from your text file with links (URLs).");
            Console.WriteLine("Please note that URLs must start with \"{0}\" or with \"{1}\". Each line is a separate URL.\n", _http, _https);

            Console.WriteLine("0. Exit");
            Console.WriteLine("1. I have prepared the file ({0}), start!", _fileImport);

            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    Console.Clear();
                    CreateExportFile();
                    Console.WriteLine("\nPress any key to return to the menu.");
                    Console.ReadKey();
                    return true;
                default:
                    return true;
            }
        }

        private static void CreateExportFile()
        {
            int counterIncorrect = 0;
            int counterCorrect = 0;
            string links = "";

            Console.Write("Checking for the existence of a file ({0})... ", _fileImport);
            if (File.Exists(_fileImport))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The file exists.");
                Console.ResetColor();
                try
                {
                    using (StreamReader streamReader = new StreamReader(_fileImport, System.Text.Encoding.UTF8))
                    {
                        string link;
                        while ((link = streamReader.ReadLine()) != null)
                        {
                            if (link != "" && (link.StartsWith(_https) || link.StartsWith(_http)))
                            {
                                links += _tagStart + link + _tagEnd;
                                counterCorrect++;
                            }
                            else
                            {
                                counterIncorrect++;
                            }
                        }
                        Console.WriteLine("\nLinks (URLs)");
                        Console.WriteLine(new string('-', 12));
                        Console.WriteLine("Correct:   {0}", counterCorrect);
                        Console.WriteLine("Incorrect: {0}\n", counterIncorrect);
                        Console.ResetColor();
                    }

                    if (counterCorrect != 0)
                    {
                        Console.Write("Creating a file ready for import into Pocket... ");
                        // Create the file, or overwrite if the file exists.
                        using (FileStream fileStream = File.Create(_fileExport))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(_htmlStart + links + _htmlEnd);
                            fileStream.Write(info, 0, info.Length);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Success");
                            Console.ResetColor();
                            Console.WriteLine("\nFile ({0}) is ready to be imported into Pocket.\n\nGo to \"{1}\" and select ({0}) HTML-file.", _fileExport, "https://getpocket.com/import/instapaper");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No correct links (URLs) found in ({0}).", _fileImport);
                        Console.ResetColor();
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: {0}", e.Message);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File ({0}) does not exist.", _fileImport);
                Console.ResetColor();
            }
        }
    }
}
