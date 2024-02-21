using System;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ConverterPDF
{
    public class CompressFile
    {
        public void CompressPdf(string targetPath)
        {
            using (var stream = new MemoryStream(File.ReadAllBytes(targetPath)) { Position = 0 })
            using (var source = PdfReader.Open(stream, PdfDocumentOpenMode.Import))
            using (var document = new PdfDocument())
            {
                var options = document.Options;
                options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;
                options.UseFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Automatic;
                options.CompressContentStreams = true;
                options.NoCompression = true;
                foreach (var page in source.Pages)
                {
                    document.AddPage(page);
                }

                document.Save(targetPath);
            }
        }
    }
}

