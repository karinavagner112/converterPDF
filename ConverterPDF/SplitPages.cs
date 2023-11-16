using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ConverterPDF
{
	public class SplitPages
	{
        /// <summary>
        /// split one pdf in two pdfs 
        /// </summary>
        /// <param name="sourcePdf">path to source pdf file </param>
        /// <param name="targetPdf1">path to new pdf file </param>
        /// <param name="targetPdf2">path to another one new pdf file</param>
        /// <param name="pageToSplit">on which page the file will be split</param>
        public void SplitPdfPages(string sourcePdf, string targetPdf1, string targetPdf2, int pageToSplit)
		{
			using(PdfDocument sourceDocument = PdfReader.Open(sourcePdf, PdfDocumentOpenMode.Import))
			{
				using(PdfDocument targetDocument1 = new PdfDocument())
				using(PdfDocument targetDocument2 = new PdfDocument())
				{
					for(int i = 0; i < sourceDocument.PageCount; i++)
					{
						PdfPage page = sourceDocument.Pages[i];
						if(i < pageToSplit)
						{
							targetDocument1.AddPage(page);
						}
						else
						{
							targetDocument2.AddPage(page);
						}
					}
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

					targetDocument1.Save(targetPdf1);
					targetDocument2.Save(targetPdf2);

                }
			}
		}
	}
}

