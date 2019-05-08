using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestLoadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("start loading file...");

            //本机文件下载路径.
            //string url = "G:/a.docx";
            //外网下载文件地址.
            //string url = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1494677827304&di=8e8aaf1a717ae37b73b772ee4728c7ea&imgtype=0&src=http%3A%2F%2Fscimg.jb51.net%2Fallimg%2F141123%2F10-1411231F92W16.jpg";
            //局域网下载文件地址.
            string url = "\\\\SERVER\\TestLoadFile\\Test.zip";
            string fileName = "Test.zip";
            DownLoadFile(url, fileName);

            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
        
        static void DownLoadFile(string url, string fileName)
        {
            try
            {
                WebClient wc = new WebClient();
                if (wc.IsBusy == true)
                {
                    wc.CancelAsync();
                }

                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                wc.DownloadFile(url, fileName);
                wc.Dispose();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("DownLoadFile -> ex == " + ex);
            }
        }

        private static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //文件下载进度.
            Console.Out.WriteLine("load progress: " + e.ProgressPercentage);
            Console.Out.WriteLine("load file -> {0}/{1}(byte)", e.BytesReceived, e.TotalBytesToReceive);
        }

        private static void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                Console.Out.WriteLine("load file have beed cancelled!");
            }
            else
            {
                Console.Out.WriteLine("load file over!");
            }
        }
    }
}
