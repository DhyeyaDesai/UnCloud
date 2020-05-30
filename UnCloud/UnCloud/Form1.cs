using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace UnCloud
{
    public partial class Form1 : Form
    {
        struct FileInfo
        {
            public String filePath;
            public String fileName;
            public String downloadLocation;
        };
        FileInfo fileInfo;
        static String IPAddress = "";
        static StringBuilder path = new StringBuilder(IPAddress);
        int spaces = 0;
        String[] MAC = new String[10];
        String[] name = new String[10];
        int deviceIndex;

        String uncloudPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UnCloud\";
        String portNo = "2221";

        public Form1()
        {
            InitializeComponent();
            
            if (!Directory.Exists(uncloudPath))
            {
                Directory.CreateDirectory(uncloudPath);
                if (!Directory.Exists(uncloudPath + @"Downloads\"))
                    Directory.CreateDirectory(uncloudPath + @"Downloads\");
                if (!Directory.Exists(uncloudPath + @"FoldersToSync\"))
                    Directory.CreateDirectory(uncloudPath + @"FoldersToSync\");
                if (!Directory.Exists(uncloudPath + @"Sync\"))
                    Directory.CreateDirectory(uncloudPath + @"Sync\");
                if (!Directory.Exists(uncloudPath + @"SyncFilesHashes\"))
                    Directory.CreateDirectory(uncloudPath + @"SyncFilesHashes\");
                if (!Directory.Exists(uncloudPath + @"TempDownloads\"))
                    Directory.CreateDirectory(uncloudPath + @"TempDownloads\");
                if (!File.Exists(uncloudPath + @"DeviceList.txt"))
                    File.Create(uncloudPath + @"DeviceList.txt");
                if (!File.Exists(uncloudPath + @"FilesToSync.txt"))
                    File.Create(uncloudPath + @"FilesToSync.txt");
            }

            progressState.Text = "";
            progressBar.Visible = false;

            refreshDevices();
            foreach (String MAC1 in MAC)
            {
                if (MAC1 != null)
                {
                    Thread s1 = new Thread(() => uploadSyncText(MAC1));
                    s1.Start();
                }
            }
        }
        public void countSpaces()
        {
            String list = File.ReadAllText(uncloudPath + "DeviceList.txt");
            int i = 0;
            while (i < list.Length)
            {
                if (list[i] == ' ')
                {
                    spaces++;
                }
                i++;
            }
            spaces = spaces / 2;
        }
        private void refreshDevices()
        {
            emptyDeviceList();
            countSpaces();
            String list = File.ReadAllText(uncloudPath + "DeviceList.txt");
            StringBuilder x = new StringBuilder();
            int i = 0;
            int m = 0;
            int n = 0;
            int count = 0;
            try
            {
                while (i < list.Length)
                {
                    x.Append(list[i]);
                    if (list[i] == ' ' && m <= spaces && n <= spaces)
                    {
                        if (count == 0)
                        {
                            MAC[m] = Convert.ToString(x);
                            m++;
                        }
                        if (count == 1)
                        {
                            name[n] = Convert.ToString(x);
                            n++;
                        }
                        if (count == 1)
                            count = 0;
                        else
                            count = 1;
                        x.Length = 0;
                    }
                    i++;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            i = 0;
            try
            {
                while (i <= MAC.Length)
                {
                    deviceList.Items.Add(name[i]);
                    i++;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
        }
        private void emptyDeviceList()
        {
            deviceList.Items.Clear();
        }
        private void deviceSelected(object sender, EventArgs e)
        {
            try
            {
                path = path.Clear();
                deviceIndex = deviceList.SelectedIndex;
                IPAddress = (IPMacMapper.InitializeGetIPsAndMac(MAC[deviceIndex]) + "");
                path = path.Append("ftp://" + IPAddress + ":" + portNo);
                refreshFiles(path);
            }
            catch (Exception) { }
        }
        private void refreshFiles(StringBuilder path)
        {
            fileName.Text = "--";
            fileType.Text = "--";
            fileSize.Text = "--";
            pathTextBox.Text = Convert.ToString(path);
            directoryList.Items.Clear();
            List<string> files = new List<string>();

            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Convert.ToString(path));
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential("", "");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    Application.DoEvents();
                    files.Add(reader.ReadLine());
                }

                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server");
            }

            if (files.Count != 0)
            {
                String ext;
                foreach (String file in files)
                {
                    if (file.Contains('.'))
                    {
                        ext = file.Substring(file.LastIndexOf("."), file.Length - file.LastIndexOf("."));
                        switch (ext)
                        {
                            case ".mp3":
                            case ".mp":
                                directoryList.Items.Add(file, 1);
                                break;
                            case ".mp4":
                            case ".avi":
                            case ".mkv":
                                directoryList.Items.Add(file, 2);
                                break;
                            case ".jpeg":
                            case ".jpg":
                            case ".png":
                                directoryList.Items.Add(file, 3);
                                break;
                            case ".pdf":
                                directoryList.Items.Add(file, 4);
                                break;
                            case ".txt":
                                directoryList.Items.Add(file, 5);
                                break;
                            case ".apk":
                                directoryList.Items.Add(file, 6);
                                break;
                            case ".zip":
                            case ".rar":
                            case ".7z":
                                directoryList.Items.Add(file, 7);
                                break;
                            case ".exe":
                                directoryList.Items.Add(file, 8);
                                break;
                            case ".ppt":
                            case ".pptx":
                                directoryList.Items.Add(file, 9);
                                break;
                            case ".doc":
                            case ".docx":
                                directoryList.Items.Add(file, 10);
                                break;
                            default:
                                directoryList.Items.Add(file, 11);
                                break;
                        }
                    }
                    else
                    {
                        directoryList.Items.Add(file, 0);
                    }
                }
            }
        }
        private void fileSelected(object sender, EventArgs e)
        {
            if (IsFile(Convert.ToString(path + "/" + directoryList.SelectedItems[0].Text)))
            {
                //Process.Start(Convert.ToString(path + "/" + directoryList.SelectedItems[0].Text));
            }
            else
            {
                path.Append(Convert.ToString("/" + directoryList.SelectedItems[0].Text));
                refreshFiles(path);
            }
        }
        private void getPreview(object sender, EventArgs e)
        {
            fileName.Text = "--";
            fileType.Text = "--";
            fileSize.Text = "--";
            if (IsFile(Convert.ToString(path + "/" + directoryList.SelectedItems[0].Text)))
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(path + "/" + directoryList.SelectedItems[0].Text));
                    request.Proxy = null;
                    request.Credentials = new NetworkCredential("", "");
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    long size = response.ContentLength;
                    response.Close();
                    fileName.Text = directoryList.SelectedItems[0].Text;
                    fileType.Text = directoryList.SelectedItems[0].Text.Substring(directoryList.SelectedItems[0].Text.LastIndexOf("."), directoryList.SelectedItems[0].Text.Length - directoryList.SelectedItems[0].Text.LastIndexOf("."));
                    fileSize.Text = Convert.ToString(size / 1024 + " KB");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        private static bool isLocalFile(String localPath)
        {
            FileAttributes attr = File.GetAttributes(localPath);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return false;
            else
                return true;
        }

        static bool IsFile(string ftpPath)
        {
            var request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            request.Credentials = new NetworkCredential("", "");
            try
            {
                using (var response = (FtpWebResponse)request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private void backButtonClick(object sender, EventArgs e)
        {
            fileName.Text = "--";
            fileType.Text = "--";
            fileSize.Text = "--";

            path.Remove(Convert.ToString(path).LastIndexOf("/"), path.Length - Convert.ToString(path).LastIndexOf("/"));
            refreshFiles(path);
        }
        private void addNewDevice(object sender, EventArgs e)
        {
            try
            {
                String newName1 = newName.Text;
                String newMac1 = newMAC.Text;
                //ADD REGEX FOR MAC
                //ADD CONDITION FOR WHEN MAC OR DEVICE IS NULL
                if (true)
                {
                    if (File.ReadAllText(uncloudPath + "DeviceList.txt").Contains(newMac1))
                    {
                        MessageBox.Show("Device already exists.");
                    }
                    else
                    {
                        TextWriter tsw = new StreamWriter(uncloudPath + "DeviceList.txt", true);
                        tsw.Write(newMac1 + " ");
                        tsw.Write(newName1 + " ");
                        tsw.Close();
                    }
                }
                else
                {
                    MessageBox.Show("MAC Address is invalid.");
                }
                
                
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            refreshDevices();
        }

        private void removeThisDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder devices = new StringBuilder("");
                devices.Append(File.ReadAllText(uncloudPath + "DeviceList.txt"));
                devices.Replace(deviceList.SelectedItem + "", "");
                devices.Replace(MAC[deviceList.SelectedIndex], "");
                TextWriter tsw = new StreamWriter(uncloudPath + "DeviceList.txt", false);
                tsw.Write(devices + "");
                tsw.Close();
            }
            catch (Exception) { }
            refreshDevices();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            //progressState.Text = "Downloading...";
            fileInfo.filePath = path + "";
            fileInfo.downloadLocation = uncloudPath + @"Downloads\";

            String permanentPath = fileInfo.filePath = path + "";

            for (int count = 0; count < directoryList.SelectedItems.Count; count++)
            {
                fileInfo.filePath = permanentPath;
                fileInfo.fileName = directoryList.SelectedItems[count].Text;
                fileInfo.filePath = fileInfo.filePath + "/" + fileInfo.fileName;
                Thread s = new Thread(() => downloadFiles(fileInfo, false, ""));
                s.Start();
                downloadFiles(fileInfo, false, "");
            }
        }

        private void downloadFiles(FileInfo fileInfo, bool makeHash, String folderPath)
        {
            if (IsFile(fileInfo.filePath))
            {

                MessageBox.Show(fileInfo.fileName);
                fileInfo.downloadLocation = fileInfo.downloadLocation + fileInfo.fileName + @"";

                
                try
                {
                    var request = (FtpWebRequest)WebRequest.Create(fileInfo.filePath);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential("", "");
                    request.UseBinary = true;

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    Stream responseStream = response.GetResponseStream();
                    FileStream fs = new FileStream(fileInfo.downloadLocation, FileMode.Create);

                    byte[] buffer = new byte[102400];
                    int read = 0;
                    do
                    {
                        read = responseStream.Read(buffer, 0, buffer.Length);
                        fs.Write(buffer, 0, read);
                        fs.Flush();
                    }
                    while (!(read == 0));

                    fs.Flush();
                    fs.Close();

                    if (makeHash)
                    {
                        String hash = createHashes(fileInfo.downloadLocation);
                        TextWriter tsw = new StreamWriter(uncloudPath + @"SyncFilesHashes\HASH" + fileInfo.fileName + ".txt");
                        tsw.Write(hash, true);
                        tsw.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                folderPath = folderPath + fileInfo.fileName + @"\";
                FileInfo fileInfo1;
                List<string> files = new List<string>();
                files = listDirectories(fileInfo.filePath);
                try
                {
                    if (makeHash)
                    {
                        TextWriter tsw = new StreamWriter(uncloudPath + @"FoldersToSync\" + fileInfo.fileName + ".txt");
                        foreach (String file in files)
                        {
                            tsw.Write(file + "\n", true);
                        }
                        tsw.Close();
                    }

                    if (!Directory.Exists(fileInfo.downloadLocation + fileInfo.fileName))
                        Directory.CreateDirectory(fileInfo.downloadLocation + fileInfo.fileName);
                    fileInfo1.downloadLocation = fileInfo.downloadLocation + fileInfo.fileName + @"\";

                    files = listDirectories(fileInfo.filePath);
                    foreach (String file in files)
                    {
                        fileInfo1.fileName = file;
                        fileInfo1.filePath = fileInfo.filePath + "/" + file;
                        //Thread s = new Thread(() => downloadFiles(fileInfo1, makeHash, folderPath));
                        //s.Start();
                        downloadFiles(fileInfo1, makeHash, folderPath);
                    }
                    
                }
                catch (Exception)
                {
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int count = 0; count < directoryList.SelectedItems.Count; count++)
            {
                deleteFile(path + "/" + directoryList.SelectedItems[count].Text);
            }
            refreshFiles(path);
        }

        private void deleteFile(String filePath)
        {
            try
            {
                FtpWebRequest request;
                FtpWebResponse response;

                request = (FtpWebRequest)WebRequest.Create(filePath);
                if (IsFile(filePath))
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                else
                {
                    if (isFTPFolderEmpty(filePath))
                    {
                        request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                    }
                    else
                    {
                        List<string> directories = listDirectories(filePath);

                        foreach (String files in directories)
                        {
                            deleteFile(filePath + "/" + files);
                        }
                        deleteFile(filePath);
                    }
                }
                response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch { }
        }

        private bool isFTPFolderEmpty(String folderPath)
        {
            List<String> directories = listDirectories(folderPath);
            
            if (directories.Count == 0)
                return true;
            else
                return false;
        }

        private static List<string> listDirectories(String folderPath)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderPath);
                ftpRequest.Credentials = new NetworkCredential("", "");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();
                return directories;
            }
            catch(Exception)
            {
                return null;
            }
        }

        private void refreshButtonClick(object sender, EventArgs e)
        {
            refreshFiles(path);
        }

        private void directoryList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void directoryList_DragDrop(object sender, DragEventArgs e)
        {
            progressState.Visible = true;
            progressState.Text = "Uploading...";
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string file in files)
            {
                fileInfo.fileName = Path.GetFileName(file);
                Thread s = new Thread(() => uploadFile(path + "", file, path + ""));
                s.Start();
            }
            progressState.Visible = false;
            progressState.Text = "";
        }

        private void uploadFile(String filePath, String file, String uploadPath)
        {
            String fileName = Path.GetFileName(file);

            if (isLocalFile(file))
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential("", "");
                        client.UploadFile(filePath + "/" + fileName, file);
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    WebRequest request = WebRequest.Create(uploadPath + "/" + fileName);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    request.Credentials = new NetworkCredential("", "");
                    using (var resp = (FtpWebResponse)request.GetResponse()) { }

                    uploadPath = uploadPath + "/" + fileName;
                    string[] pathFiles = Directory.GetFiles(file);
                    string[] pathFolders = Directory.GetDirectories(file);
                    foreach (String files in pathFolders)
                    {
                        Thread s = new Thread(() => uploadFile(uploadPath + "", files, uploadPath));
                        s.Start();
                    }
                    foreach (String files in pathFiles)
                    {
                        Thread s = new Thread(() => uploadFile(uploadPath + "", files, uploadPath));
                        s.Start();
                    }
                }
                catch
                {
                }
            }
            //refreshFiles(path);
        }

        private void createAFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newFolder = new Form2();
            newFolder.getPath(path);
            newFolder.ShowDialog();
            refreshFiles(path);
        }

        private void Properties_Click(object sender, EventArgs e)
        {

        }

        private void Sync_Click(object sender, EventArgs e)
        {
            try
            {
                String list = File.ReadAllText(uncloudPath + "FilesToSync.txt");
                String[] fileList = list.Split(Environment.NewLine.ToCharArray());

                FileInfo fileInfo;
                fileInfo.fileName = directoryList.SelectedItems[0].Text;
                fileInfo.filePath = path + "/" + fileInfo.fileName;
                fileInfo.downloadLocation = uncloudPath + @"Sync\";

                String fileLocation = fileInfo.filePath;

                if (!fileList.Contains(fileLocation.Replace(IPAddress, MAC[deviceIndex].Trim()))) {
                    
                    TextWriter tsw1 = new StreamWriter(uncloudPath + "FilesToSync.txt", true);
                    tsw1.WriteLine(fileLocation.Replace(IPAddress, MAC[deviceIndex].Trim()), true);
                    tsw1.Close();
                    //if (!IsFile(fileLocation))
                    //  addToTextFile(uncloudPath + "FilesToSync.txt", fileInfo.fileName, fileLocation);

                    downloadFiles(fileInfo, true, "");
                    foreach (String MAC1 in MAC)
                    {
                        if (MAC1 != null)
                        {
                            Thread s1 = new Thread(() => uploadSyncText(MAC1));
                            s1.Start();
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("You're already syncing this file");
                }
            }
            catch (System.ArgumentException)
            {
                if(IPAddress == "")
                    MessageBox.Show("You can't sync on a temporary device");
            }
        }

        private void addToTextFile(String textFilePath, String fileName, String filePath)
        {
            TextWriter tsw1 = new StreamWriter(textFilePath, true);
            tsw1.WriteLine(filePath.Replace(IPAddress, MAC[deviceIndex].Trim()), true);
            tsw1.Close();

            if (!IsFile(filePath))
            {
                List<string> files = new List<string>();
                files = listDirectories(filePath);
                foreach (String file in files)
                {
                    addToTextFile(uncloudPath + @"FoldersToSync\" + fileName + ".txt", file, filePath + "/" + file);
                }
            }
        }

        private void uploadSyncText(String MAC)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("", "");
                    client.UploadFile("ftp://"+ IPMacMapper.InitializeGetIPsAndMac(MAC) + ":" + portNo + "/UnCloud/FilesToSync.txt", uncloudPath + "FilesToSync.txt");
                }
            }
            catch (Exception)
            {
            }
        }

        private String createHashes(String filePath)
        {
            byte[] buffer;
            int bytesRead;
            long size;
            long totalBytesRead = 0;
            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;
                using (HashAlgorithm hasher = MD5.Create())
                {
                    do
                    {
                        buffer = new byte[4096];
                        bytesRead = file.Read(buffer, 0, buffer.Length);
                        totalBytesRead += bytesRead;
                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                    }
                    while (bytesRead != 0);
                    hasher.TransformFinalBlock(buffer, 0, 0);
                    return MakeHashString(hasher.Hash);
                }
            }
        }

        private static string MakeHashString(byte[] hashBytes)
        {
            StringBuilder hash = new StringBuilder(32);
            foreach (byte b in hashBytes)
            {
                hash.Append(b.ToString("X2").ToLower());
            }
            return hash.ToString();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            Thread s = new Thread(() => syncFiles(uncloudPath + "FilesToSync.txt", ""));
            s.Start();
        }


        private void syncFiles(String fileToRead, String subFolder)
        {
            try 
            { 
                String list = File.ReadAllText(fileToRead);
                string[] lines = list.Split(Environment.NewLine.ToCharArray());
                foreach (String line in lines)
                {
                    if (line != "")
                    {
                        String location = line.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + "");
                        String fileName = location.Substring(location.LastIndexOf("/") + 1, location.Length - location.LastIndexOf("/") - 1);

                        if (IsFile(line.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + ""))) {
                            try
                            {
                                location = line.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + "");
                                fileName = location.Substring(location.LastIndexOf("/") + 1, location.Length - location.LastIndexOf("/") - 1);
                                String fileLocation = location.Replace(fileName, "");
                                FileInfo tempFile;
                                tempFile.filePath = line.Substring(0, 29) + "UnCloud/SyncFilesHashes/HASH" + fileName + ".txt";
                                tempFile.filePath = tempFile.filePath.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + "");
                                tempFile.fileName = "HASH" + fileName + ".txt";
                                tempFile.downloadLocation = uncloudPath + @"TempDownloads\";

                                downloadFiles(tempFile, false, "");

                                if (!FileEquals(uncloudPath + @"SyncFilesHashes\" + tempFile.fileName, uncloudPath + @"TempDownloads\" + tempFile.fileName))
                                {
                                    tempFile.filePath = line.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + "");
                                    tempFile.fileName = location.Substring(location.LastIndexOf("/") + 1, location.Length - location.LastIndexOf("/") - 1);
                                    tempFile.downloadLocation = uncloudPath + @"Sync\" + subFolder;
                                    downloadFiles(tempFile, true, "");
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {


                            String newFileToRead = uncloudPath + @"FoldersToSync\" + fileName + ".txt";

                            syncFiles(newFileToRead, subFolder + fileName + @"\");

                            FileInfo tempFile;
                            tempFile.filePath = line.Substring(0, 29) + "UnCloud/FoldersToSync/" + fileName + ".txt";
                            tempFile.filePath = tempFile.filePath.Replace(line.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(line.Substring(6, 17)) + "");
                            tempFile.fileName = fileName + ".txt";
                            tempFile.downloadLocation = uncloudPath + @"TempDownloads\";

                            downloadFiles(tempFile, false, "");

                            if (!FileEquals(uncloudPath + @"FoldersToSync\" + fileName + ".txt", uncloudPath + @"TempDownloads\" + fileName + ".txt"))
                            {
                                String listPC = File.ReadAllText(uncloudPath + @"FoldersToSync\" + fileName + ".txt");
                                string[] linesPC = listPC.Split(Environment.NewLine.ToCharArray());
                                String listPhone = File.ReadAllText(uncloudPath + @"TempDownloads\" + fileName + ".txt");
                                string[] linesPhone = listPhone.Split(Environment.NewLine.ToCharArray());
                                foreach (String linePhone in linesPhone)
                                {
                                    if (linePhone != "" && !listPC.Contains(linePhone))
                                    {
                                        tempFile.fileName = linePhone.Substring(linePhone.LastIndexOf("/") + 1, linePhone.Length - linePhone.LastIndexOf("/") - 1);
                                        tempFile.filePath = (linePhone.Replace(linePhone.Substring(6, 17), IPMacMapper.InitializeGetIPsAndMac(linePhone.Substring(6, 17)) + ""));
                                        tempFile.downloadLocation = uncloudPath + @"Sync\" + subFolder + fileName + @"\";

                                        downloadFiles(tempFile, true, "");
                                    }
                                }
                                File.Delete(uncloudPath + @"FoldersToSync\" + fileName + ".txt");
                                File.Move(uncloudPath + @"TempDownloads\" + fileName + ".txt", uncloudPath + @"FoldersToSync\" + fileName + ".txt");
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        static bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }


        private void tempConnectionButton_Click(object sender, EventArgs e)
        {
            String tempMAC = tempDeviceMAC.Text;
            StringBuilder tempIP = IPMacMapper.InitializeGetIPsAndMac(tempMAC);
            path.Clear();
            path = path.Append("ftp://" + tempIP + ":" + portNo);
            refreshFiles(path);
        }
    }


    public class IPMacMapper
     {
        public static List<IPAndMac> list;

        private static StreamReader ExecuteCommandLine(String file, String arguments = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = file;
            startInfo.Arguments = arguments;
            Process process = Process.Start(startInfo);
            return process.StandardOutput;
        }

        public static StringBuilder InitializeGetIPsAndMac(String macAddress)
        {
            try
            {
                if (list != null)
                    return null;

                var arpStream = ExecuteCommandLine("arp", "-a");
                List<string> result = new List<string>();

                while (!arpStream.EndOfStream)
                {
                    var line = arpStream.ReadLine().Trim();
                    result.Add(line);
                }
                String s = "";
                for (int i = 3; i < result.Count(); i++)
                {
                    s = Convert.ToString(result[i]);
                    if (s.Contains(macAddress))
                    {
                        break;
                    }
                }
                //char[] ip = new char[15];
                StringBuilder ipaddr = new StringBuilder();
                for (int i = 0; s[i].CompareTo(' ') != 0; i++)
                {
                    ipaddr.Append(s[i]);
                }
                return ipaddr;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public class IPAndMac
        {
            public string IP { get; set; }
            public string MAC { get; set; }
        }
     }
}