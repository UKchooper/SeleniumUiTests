using System.IO;

namespace SeleniumUiTests.Helpers
{
    public static class WriteToTxtFile
    {
        public static void WriteStringToTxtFile(string txtValue, string fileLocation, string fileName)
        {
            string fullPath = Path.Combine(fileLocation, fileName);

            using(StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(txtValue);
            }
        }
    }
}
