using System;

namespace ConverterPDF
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Willkommen in PDF-Konverter");
            Console.WriteLine("Welche Operation möchten Sie machen: " +
                "1 - PDF zusammenfügen; 2 - Seiten löschen; 3 - PDF teilen");

            string option = Console.ReadLine();
            Helper helper = new Helper();
            PdfFile file = new PdfFile();


            if (option == "1")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdfs, die zusammengefügt werden:");
                file.Path = Console.ReadLine();
                string[] paths = file.Path.Split(' ');
                Console.WriteLine("Geben Sie den Dateipfad für die Zieldatei");
                file.NewPath = Console.ReadLine();
                MergeFiles mergePdf = new MergeFiles();
                mergePdf.MergePDFs(file.NewPath, paths);
            }
            else if (option == "2")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdf-Datei, in der die Seiten gelöscht werden sollen: ");
                file.Path = Console.ReadLine();
                Console.WriteLine("Geben Sie den Dateipfad für die Zieldatei");
                file.NewPath = Console.ReadLine();
                Console.WriteLine("Welche Seiten sollen gelöscht werden? (Die Seitennummern durch Komma trennen.)");
                string pages = Console.ReadLine();
                string[] numberStrings = pages.Split(',');
                List<int> numbersPdf = new List<int>();
                helper.PagesToInt(numberStrings, numbersPdf);
                DeletePage delete = new DeletePage();
                delete.DeletePageFromPDF(file.Path, file.NewPath, numbersPdf);

            }
            else if (option == "3")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdf-Datei, die geteilt werden soll: ");
                file.Path = Console.ReadLine();
                Console.WriteLine("Geben Sie den Dateipfade für die beiden Zieldatei");
                file.NewPath = Console.ReadLine();
                file.PathSplit = Console.ReadLine();
                Console.WriteLine("Auf welcher Seite sollte die PDF-Datei getrennt werden soll?");
                string pageNumber = Console.ReadLine();
                int number = int.Parse(pageNumber);
                SplitPages split = new SplitPages();
                split.SplitPdfPages(file.Path, file.NewPath, file.PathSplit, number);
            }
            else
            {
                Console.WriteLine("Eingabe ist falsch, versuchen Sie nochmal");
            }

        }
    }
}

