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
            

            if(option == "1")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdfs, die zusammengefügt werden:");
                string pdfPath = Console.ReadLine();
                string[] paths = pdfPath.Split(' ');
                Console.WriteLine("Geben Sie den Dateipfad für die Zieldatei");
                string newPath = Console.ReadLine();
                MergeFiles mergePdf = new MergeFiles();
                mergePdf.MergePDFs(newPath, paths);
            }
            else if(option == "2")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdf-Datei, in der die Seiten gelöscht werden sollen: ");
                string pdfPath = Console.ReadLine();
                Console.WriteLine("Geben Sie den Dateipfad für die Zieldatei");
                string newPath = Console.ReadLine();
                Console.WriteLine("Welche Seiten sollen gelöscht werden? (Die Seitennummern durch Komma trennen.)");
                string pages = Console.ReadLine();
                string[] numberStrings = pages.Split(',');
                List<int> numbersPdf = new List<int>();
                helper.PagesToInt(numberStrings, numbersPdf);
                DeletePage delete = new DeletePage();
                delete.DeletePageFromPDF(pdfPath, newPath, numbersPdf);

            }
            else if (option == "3")
            {
                Console.WriteLine("Geben Sie die Dateipfade von Pdf-Datei, die geteilt werden soll: ");
                string pdfPath = Console.ReadLine();
                Console.WriteLine("Geben Sie den Dateipfade für die beiden Zieldatei");
                string newPathOne = Console.ReadLine();
                string newPathTwo = Console.ReadLine();
                Console.WriteLine("Auf welcher Seite sollte die PDF-Datei getrennt werden soll?");
                string pageNumber = Console.ReadLine();
                int number = int.Parse(pageNumber);
                SplitPages split = new SplitPages();
                split.SplitPdfPages(pdfPath, newPathOne, newPathTwo, number);
            }
            else
            {
                Console.WriteLine("Falsche Eingabe! Versuchen Sie noch mal!");
            }
            
        }
    }
}

