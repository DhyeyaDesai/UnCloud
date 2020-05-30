namespace UnCloud
{
    partial class Form2
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
            this.folderName = new System.Windows.Forms.TextBox();
            this.createFolderButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderName
            // 
            this.folderName.Location = new System.Drawing.Point(12, 12);
            this.folderName.Name = "folderName";
            this.folderName.Size = new System.Drawing.Size(443, 22);
            this.folderName.TabIndex = 0;
            // 
            // createFolderButton
            // 
            this.createFolderButton.Location = new System.Drawing.Point(107, 40);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(75, 23);
            this.createFolderButton.TabIndex = 1;
            this.createFolderButton.Text = "Create";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.createFolderButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(267, 40);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 71);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createFolderButton);
            this.Controls.Add(this.folderName);
            this.Name = "Form2";
            this.Text = "Create a New Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderName;
        private System.Windows.Forms.Button createFolderButton;
        private System.Windows.Forms.Button cancelButton;
    }
}