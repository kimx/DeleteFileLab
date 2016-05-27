using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFileLab
{
    class Program
    {
        static string SourceZip = ConfigurationManager.AppSettings["SourceZip"];
        static string DeleteDir = ConfigurationManager.AppSettings["DeleteDir"];

        static void Main(string[] args)
        {
            try
            {
                DeleteFile(DeleteDir);
                //ExtraFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }

        private static void DeleteFile(string extraDir)
        {
            if (Directory.Exists(extraDir))
            {
                File.SetAttributes(extraDir, FileAttributes.Normal);
                Console.WriteLine("DeleteFile-Begin");
                Directory.Delete(extraDir, true);
                Console.WriteLine("DeleteFile-End");
            }
            else
                Console.WriteLine("extraDir Not Exists :" + extraDir);
        }

        private static void ExtraFile()
        {
            string extraDir = Path.Combine(Path.GetDirectoryName(SourceZip), Path.GetFileNameWithoutExtension(SourceZip));
            DeleteFile(extraDir);
            if (File.Exists(SourceZip))
            {
                Console.WriteLine("ExtraFile-Begin");
                ZipFile.ExtractToDirectory(SourceZip, extraDir);
                Console.WriteLine("ExtraFile-End");
            }
            else
                Console.WriteLine("SourceZip Not Exists :" + SourceZip);
        }

    }
}
