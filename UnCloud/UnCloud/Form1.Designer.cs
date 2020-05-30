namespace UnCloud
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.directoryList = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Sync = new System.Windows.Forms.ToolStripMenuItem();
            this.Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.ToolStripMenuItem();
            this.createAFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.newName = new System.Windows.Forms.TextBox();
            this.newMAC = new System.Windows.Forms.TextBox();
            this.deviceList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeThisDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.MACLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.addNewDeviceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressState = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.tempDeviceMAC = new System.Windows.Forms.TextBox();
            this.tempConnectionButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryList
            // 
            this.directoryList.AllowDrop = true;
            this.directoryList.ContextMenuStrip = this.contextMenuStrip1;
            this.directoryList.HideSelection = false;
            this.directoryList.LargeImageList = this.iconList;
            this.directoryList.Location = new System.Drawing.Point(243, 42);
            this.directoryList.Name = "directoryList";
            this.directoryList.Size = new System.Drawing.Size(751, 596);
            this.directoryList.SmallImageList = this.iconList;
            this.directoryList.TabIndex = 0;
            this.directoryList.UseCompatibleStateImageBehavior = false;
            this.directoryList.Click += new System.EventHandler(this.getPreview);
            this.directoryList.DragDrop += new System.Windows.Forms.DragEventHandler(this.directoryList_DragDrop);
            this.directoryList.DragEnter += new System.Windows.Forms.DragEventHandler(this.directoryList_DragEnter);
            this.directoryList.DoubleClick += new System.EventHandler(this.fileSelected);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Sync,
            this.Properties,
            this.Download,
            this.createAFolderToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 148);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(179, 24);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.fileSelected);
            // 
            // Sync
            // 
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(179, 24);
            this.Sync.Text = "Sync";
            this.Sync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // Properties
            // 
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(179, 24);
            this.Properties.Text = "Properties";
            this.Properties.Click += new System.EventHandler(this.Properties_Click);
            // 
            // Download
            // 
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(179, 24);
            this.Download.Text = "Download";
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // createAFolderToolStripMenuItem
            // 
            this.createAFolderToolStripMenuItem.Name = "createAFolderToolStripMenuItem";
            this.createAFolderToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.createAFolderToolStripMenuItem.Text = "Create a Folder";
            this.createAFolderToolStripMenuItem.Click += new System.EventHandler(this.createAFolderToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "folder.png");
            this.iconList.Images.SetKeyName(1, "music.png");
            this.iconList.Images.SetKeyName(2, "video.png");
            this.iconList.Images.SetKeyName(3, "image.png");
            this.iconList.Images.SetKeyName(4, "pdf.png");
            this.iconList.Images.SetKeyName(5, "txt.png");
            this.iconList.Images.SetKeyName(6, "apk.png");
            this.iconList.Images.SetKeyName(7, "archive.png");
            this.iconList.Images.SetKeyName(8, "exe.png");
            this.iconList.Images.SetKeyName(9, "powerpoint.png");
            this.iconList.Images.SetKeyName(10, "word.png");
            this.iconList.Images.SetKeyName(11, "unknown.png");
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(93, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(739, 22);
            this.pathTextBox.TabIndex = 1;
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(1003, 328);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(251, 22);
            this.newName.TabIndex = 2;
            // 
            // newMAC
            // 
            this.newMAC.Location = new System.Drawing.Point(1003, 399);
            this.newMAC.Name = "newMAC";
            this.newMAC.Size = new System.Drawing.Size(251, 22);
            this.newMAC.TabIndex = 3;
            // 
            // deviceList
            // 
            this.deviceList.ContextMenuStrip = this.contextMenuStrip2;
            this.deviceList.Font = new System.Drawing.Font("Arial", 9F);
            this.deviceList.FormattingEnabled = true;
            this.deviceList.ItemHeight = 17;
            this.deviceList.Location = new System.Drawing.Point(1004, 42);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(250, 225);
            this.deviceList.TabIndex = 4;
            this.deviceList.Click += new System.EventHandler(this.deviceSelected);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeThisDeviceToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(212, 56);
            // 
            // removeThisDeviceToolStripMenuItem
            // 
            this.removeThisDeviceToolStripMenuItem.Name = "removeThisDeviceToolStripMenuItem";
            this.removeThisDeviceToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.removeThisDeviceToolStripMenuItem.Text = "Remove This Device";
            this.removeThisDeviceToolStripMenuItem.Click += new System.EventHandler(this.removeThisDeviceToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1001, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Device Name: ";
            // 
            // MACLabel
            // 
            this.MACLabel.AutoSize = true;
            this.MACLabel.Location = new System.Drawing.Point(1000, 364);
            this.MACLabel.Name = "MACLabel";
            this.MACLabel.Size = new System.Drawing.Size(139, 17);
            this.MACLabel.TabIndex = 6;
            this.MACLabel.Text = "Enter MAC Address: ";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButtonClick);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(838, 13);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButtonClick);
            // 
            // addNewDeviceButton
            // 
            this.addNewDeviceButton.Location = new System.Drawing.Point(1003, 440);
            this.addNewDeviceButton.Name = "addNewDeviceButton";
            this.addNewDeviceButton.Size = new System.Drawing.Size(93, 23);
            this.addNewDeviceButton.TabIndex = 9;
            this.addNewDeviceButton.Text = "Add Device";
            this.addNewDeviceButton.UseVisualStyleBackColor = true;
            this.addNewDeviceButton.Click += new System.EventHandler(this.addNewDevice);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "File Name: ";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(12, 394);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(18, 17);
            this.fileName.TabIndex = 12;
            this.fileName.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "File Type: ";
            // 
            // fileType
            // 
            this.fileType.AutoSize = true;
            this.fileType.Location = new System.Drawing.Point(12, 577);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(18, 17);
            this.fileType.TabIndex = 14;
            this.fileType.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Size: ";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(12, 490);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(18, 17);
            this.fileSize.TabIndex = 16;
            this.fileSize.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label5.Location = new System.Drawing.Point(1004, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "My Devices: ";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 159);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(208, 23);
            this.progressBar.TabIndex = 18;
            // 
            // progressState
            // 
            this.progressState.Location = new System.Drawing.Point(12, 88);
            this.progressState.Name = "progressState";
            this.progressState.Size = new System.Drawing.Size(100, 23);
            this.progressState.TabIndex = 1;
            // 
            // syncButton
            // 
            this.syncButton.Location = new System.Drawing.Point(919, 13);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(75, 23);
            this.syncButton.TabIndex = 19;
            this.syncButton.Text = "Sync";
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // tempDeviceMAC
            // 
            this.tempDeviceMAC.Location = new System.Drawing.Point(1003, 572);
            this.tempDeviceMAC.Name = "tempDeviceMAC";
            this.tempDeviceMAC.Size = new System.Drawing.Size(251, 22);
            this.tempDeviceMAC.TabIndex = 21;
            // 
            // tempConnectionButton
            // 
            this.tempConnectionButton.Location = new System.Drawing.Point(1000, 615);
            this.tempConnectionButton.Name = "tempConnectionButton";
            this.tempConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.tempConnectionButton.TabIndex = 22;
            this.tempConnectionButton.Text = "Connect";
            this.tempConnectionButton.UseVisualStyleBackColor = true;
            this.tempConnectionButton.Click += new System.EventHandler(this.tempConnectionButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1001, 528);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Enter MAC Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label6.Location = new System.Drawing.Point(997, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 18);
            this.label6.TabIndex = 24;
            this.label6.Text = "To create a temporary connection: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1266, 650);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tempConnectionButton);
            this.Controls.Add(this.tempDeviceMAC);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.progressState);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addNewDeviceButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.MACLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.newMAC);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.directoryList);
            this.Name = "Form1";
            this.Text = "UnCloud";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView directoryList;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.TextBox newMAC;
        private System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MACLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button addNewDeviceButton;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fileType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Sync;
        private System.Windows.Forms.ToolStripMenuItem Properties;
        private System.Windows.Forms.ToolStripMenuItem Download;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem createAFolderToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressState;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.TextBox tempDeviceMAC;
        private System.Windows.Forms.Button tempConnectionButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem removeThisDeviceToolStripMenuItem;
    }
}

