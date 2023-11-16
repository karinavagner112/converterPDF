using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ConverterPDF
{
	public class DeletePage
	{
		/// <summary>
		/// delete pages from pdf file
		/// </summary>
		/// <param name="sourcePdf"> path to source pdf file</param>
		/// <param name="targetPdf">path to new pdf file </param>
		/// <param name="pagesToRemove">which pages should be removed</param>
		public void DeletePageFromPDF(string sourcePdf, string targetPdf, List<int> pagesToRemove)
		{
			using (PdfDocument sourceDocument = PdfReader.Open(sourcePdf, PdfDocumentOpenMode.Import))
			{
				using(PdfDocument targetDocument = new PdfDocument())
				{
					for(int pageIndex = 0; pageIndex < sourceDocument.PageCount; pageIndex++)
					{
						if(!pagesToRemove.Contains(pageIndex + 1))
						{
							PdfPage page = sourceDocument.Pages[pageIndex];
							targetDocument.AddPage(page); 
						}
					}

                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    targetDocument.Save(targetPdf);
				}
			}
		}
	}
}

