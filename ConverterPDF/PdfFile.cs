using System;
namespace ConverterPDF
{
    public class PdfFile
    {
        private string _basePath;

        private string _newPath;

        private string _pathSplit; 

        public string Path
        {
            get { return _basePath; }
            set { _basePath = value; }
        }

        public string NewPath
        {
            get { return _newPath; }
            set { _newPath = value; }
        }

        public string PathSplit
        {
            get { return _pathSplit; }
            set { _pathSplit = value; }
        }
    }
}

