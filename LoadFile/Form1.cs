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
            DownLoadFile();
        }

        WebClient m_WebClient;
        void Init()
        {
            SetActiveUI(false);
            progressInfoLb.Text = "";
            m_WebClient = new WebClient();
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

        void DownLoadFile()
        {
            Console.Out.WriteLine("DownLoadFile...");
            SetActiveUI(true);
            //本机文件下载路径.
            //string url = "G:/a.docx";
            //外网下载文件地址.
            //string url = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1494677827304&di=8e8aaf1a717ae37b73b772ee4728c7ea&imgtype=0&src=http%3A%2F%2Fscimg.jb51.net%2Fallimg%2F141123%2F10-1411231F92W16.jpg";
            //局域网下载文件地址.
            string url = "\\\\SERVER\\TestLoadFile\\Test.zip";
            string fileName = "Test.zip";
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
            }
        }
    }
}
