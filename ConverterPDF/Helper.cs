using System;
namespace ConverterPDF
{
	public class Helper
	{
        public void PagesToInt(string[] pages, List<int> numbers)
        {
            foreach (string numberString in pages)
            {
                if (int.TryParse(numberString, out int number))
                {
                    numbers.Add(number);
                }
            }
        }
    }
}

