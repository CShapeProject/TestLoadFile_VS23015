using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace LoadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void loadBt_Click(object sender, EventArgs e)
        {
            DownLoadZipFile();
        }

        WebClient m_WebClient;
        public class FileData
        {
            /// <summary>
            /// 下载文件路径.
            /// </summary>
            public string pathLoad = "";
            /// <summary>
            /// 压缩文件名称.
            /// </summary>
            public string zipFileName = "";
            /// <summary>
            /// 解压缩文件夹名称.
            /// </summary>
            public string zipedfolder = "";
            public FileData(string pathLoad, string zipFileName)
            {
                this.pathLoad = pathLoad;
                this.zipFileName = zipFileName;
                zipedfolder = Application.StartupPath;
            }
        }
        public FileData m_FileData;

        void Init()
        {
            SetActiveUI(false);
            progressInfoLb.Text = "";

            //本机文件下载路径.
            //string path = "G:/a.docx";
            //string path = "G:/";
            //外网下载文件地址.
            //string path = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1494677827304&di=8e8aaf1a717ae37b73b772ee4728c7ea&imgtype=0&src=http%3A%2F%2Fscimg.jb51.net%2Fallimg%2F141123%2F10-1411231F92W16.jpg";
            //局域网下载文件地址.
            string pathLoad = "\\\\SERVER\\TestLoadFile\\";
            string fileName = "Test.zip";
            m_FileData = new FileData(pathLoad, fileName);
            m_WebClient = new WebClient();
            
            //UnZipFile(); //test
        }

        void SetActiveUI(bool isActive)
        {
            if (isActive == false)
            {
                label1.Hide();
                progressBar.Hide();
                progressLb.Hide();
            }
            else
            {
                label1.Show();
                progressBar.Show();
                progressLb.Show();
            }
        }

        /// <summary>
        /// 下载压缩包文件.
        /// </summary>
        void DownLoadZipFile()
        {
            Console.Out.WriteLine("DownLoadZipFile...");
            SetActiveUI(true);
            string path = m_FileData.pathLoad;
            string fileName = m_FileData.zipFileName;
            string url = path + fileName;
            DownLoadFile(url, fileName);
        }

        void DownLoadFile(string url, string fileName)
        {
            try
            {
                if (m_WebClient == null)
                {
                    return;
                }

                if (m_WebClient.IsBusy == true)
                {
                    m_WebClient.CancelAsync();
                }

                m_WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                m_WebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                //异步下载文件.
                m_WebClient.DownloadFileAsync(new Uri(url), fileName);
                m_WebClient.Dispose();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("DownLoadFile -> ex == " + ex);
            }
        }

        private void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            //文件下载进度.
            //Console.Out.WriteLine("load progress: " + e.ProgressPercentage);
            //Console.Out.WriteLine("load file -> {0}/{1}(byte)", e.BytesReceived, e.TotalBytesToReceive);
            progressBar.Value = e.ProgressPercentage;
            progressLb.Text = e.ProgressPercentage.ToString() + "%";
            progressInfoLb.Text = string.Format("正在下载文件，完成进度{0}/{1}(字节)", e.BytesReceived, e.TotalBytesToReceive);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //Console.Out.WriteLine("load file have beed cancelled!");
                //MessageBox.Show("下载被取消！");
            }
            else
            {
                //Console.Out.WriteLine("load file over!");
                //MessageBox.Show("下载完成！");
                progressInfoLb.Text = "下载完成！";
                UnZipFile();
            }
        }

        /// <summary>
        /// 解压下载的文件.
        /// </summary>
        void UnZipFile()
        {
            if (m_FileData == null)
            {
                return;
            }
            Console.Out.WriteLine("UnZipFile...");
            progressInfoLb.Text = "解压文件...";

            string fileName = m_FileData.zipedfolder + "\\" + m_FileData.zipFileName;
            string zipedfolder = m_FileData.zipedfolder;
            string msg = "";
            ZipHelper.unZipFile(fileName, zipedfolder, ref msg);
            progressInfoLb.Text = msg;
            //Console.Out.WriteLine("UnZipFile -> msg == " + msg);
            //MessageBox.Show("信息：" + msg);
            //在解压完成之后覆盖本地游戏版号信息.
        }

        private void unzipBt_Click(object sender, EventArgs e)
        {
            UnZipFile();
        }
    }
}
