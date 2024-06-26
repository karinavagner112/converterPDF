﻿using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace ConverterPDF
{
    public class MergeFiles
    {
        /// <summary>
        /// merge two or more pdf files in one
        /// </summary>
        /// <param name="targetPath">path to new pdf file</param>
        /// <param name="pdfs">array with paths to pdf files</param>
        public void MergePDFs(string targetPath, string[] pdfs)
        {
            string pathWithFileName = Path.Combine(targetPath, "new.pdf");
            using (var output = new PdfDocument())
            {
                foreach (var pdf in pdfs)
                {
                    using (var pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            var page = pdfDoc.Pages[i];
                            output.AddPage(pdfDoc.Pages[i]);
                        }
                        CopyFonts(pdfDoc, output);
                    }
                    Console.WriteLine("The file {0} has been processed.", pdf);
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                output.Save(pathWithFileName);
            }

        }


        /// <summary>
        /// copies fonts from the source pdf to the target pdf
        /// </summary>
        void CopyFonts(PdfDocument source, PdfDocument target)
        {
            foreach (var font in source.Internals.GetAllObjects().Where(o => o is PdfFont))
            {
                target.Internals.AddObject(font);
            }
        }
    }
}

