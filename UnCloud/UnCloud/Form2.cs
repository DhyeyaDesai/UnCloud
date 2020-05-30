using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnCloud
{
    public partial class Form2 : Form
    {
        StringBuilder folderPath;
        public Form2()
        {
            InitializeComponent();
        }
        public void getPath(StringBuilder path)
        {
            folderPath = path;
        }
        private void createFolderButton_Click(object sender, EventArgs e)
        {
            FtpWebRequest request;
            FtpWebResponse response;
            Console.WriteLine(folderPath+"jii");
            request = (FtpWebRequest)WebRequest.Create(folderPath + "/" + folderName.Text);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential("", "");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            response = (FtpWebResponse)request.GetResponse();
            response.Close();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
