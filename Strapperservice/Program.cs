using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;

namespace Strapperservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Don't touch this below
            WebClient client = new WebClient();
            // Don't touch this ^^^
            string downloadurl = ""; // Download link for your software
            string filename = ""; // The file name you want it to be called (just temporary)
            string directoryname = ""; // Directory name that the file will be unpacked to
            string title = ""; // Your software name (will be used for the console title)
            string bootstrapperversion = ""; // Change this to your current bootstrapper version (make sure to change every new update)
            string latestbootstrapperversion = client.DownloadString(""); // Your latest bootstrapper version link (can be stored on a website in a .txt format or pastebin)


            // Bootstrapper code, do not edit unless you know what you are doing
            // Changing anything without knowing something might break the bootstrapper or cause errors
            Console.Title = title;
            Console.WriteLine("Checking for updates");
            if(latestbootstrapperversion == bootstrapperversion)
            {
                Console.WriteLine("Checking directories");
                if (Directory.Exists(directoryname))
                {
                    Console.WriteLine("Already installed, please delete the folder and then try again");
                    Console.ReadKey(); // Cannot overwrite due to an error occuring when trying to
                }
                else
                {
                    Directory.CreateDirectory(directoryname);
                    Console.WriteLine("Installing");
                    client.DownloadFile(downloadurl, filename);
                    Console.WriteLine("Unpacking");
                    ZipFile.ExtractToDirectory(filename, directoryname);
                    Console.WriteLine("Cleaning garbage");
                    File.Delete(filename);
                    Console.WriteLine("Downloaded succesfully");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have an outdated version of the bootstrapper, please download the latest version");
                Console.ReadKey();
            }
        }
    }
}
