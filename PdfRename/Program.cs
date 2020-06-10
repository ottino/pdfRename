using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PdfRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string ReadPdfFile(object Filename)
            {
                PdfReader reader2 = new PdfReader((string)Filename);
                string strText = string.Empty;

                //for (int page = 1; page <= reader2.NumberOfPages; page++)
                for (int page = 1; page <= 1; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                    PdfReader reader = new PdfReader((string)Filename);
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strText = strText + s;
                    reader.Close();
                }
                return strText.Substring(84,61).Replace(" ","_").Replace(":","").Trim();
            }


            DirectoryInfo di = new DirectoryInfo(@"C:\\temp\\pdfs");
            
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(di + "\\\\" + fi);
                Console.WriteLine("Pdf: " + ReadPdfFile(di + "\\\\" + fi));
                string oldfile = di + "\\\\" + fi;
                string text_pdf = ReadPdfFile(di + "\\\\" + fi).ToString();
                string nwfile = di + "\\\\" + text_pdf.ToString() + ".pdf";
                Console.WriteLine("old: " + oldfile);
                Console.WriteLine("new: " + nwfile);
                //Console.ReadKey();
                // Poner un try para ver donde da error
                File.Copy(oldfile, nwfile, true);
            }
            Console.ReadKey();
            /*
            string path = "C:\\temp\\ver.pdf";
            Console.WriteLine("Pdf: " + ReadPdfFile(path));
            Console.ReadKey();
            */
        }
    }
}
