
namespace UtilCoding
{
    partial class frmDeleteFolder
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDisconectTFS = new System.Windows.Forms.CheckBox();
            this.chkBinObj = new System.Windows.Forms.CheckBox();
            this.chkPackageLock = new System.Windows.Forms.CheckBox();
            this.chkReactNode = new System.Windows.Forms.CheckBox();
            this.btnSetDirectory = new System.Windows.Forms.Button();
            this.lblDirectoryProgress = new System.Windows.Forms.Label();
            this.chkThumbs = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(676, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(12, 25);
            this.txtFolder.Multiline = true;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(683, 24);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.Click += new System.EventHandler(this.txtFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Folder";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(560, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(688, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkThumbs);
            this.groupBox1.Controls.Add(this.chkDisconectTFS);
            this.groupBox1.Controls.Add(this.chkBinObj);
            this.groupBox1.Controls.Add(this.chkPackageLock);
            this.groupBox1.Controls.Add(this.chkReactNode);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 188);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration Setting";
            // 
            // chkDisconectTFS
            // 
            this.chkDisconectTFS.AutoSize = true;
            this.chkDisconectTFS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisconectTFS.Location = new System.Drawing.Point(17, 103);
            this.chkDisconectTFS.Name = "chkDisconectTFS";
            this.chkDisconectTFS.Size = new System.Drawing.Size(165, 18);
            this.chkDisconectTFS.TabIndex = 3;
            this.chkDisconectTFS.Text = "Disconect TFS .vspscc ";
            this.chkDisconectTFS.UseVisualStyleBackColor = true;
            // 
            // chkBinObj
            // 
            this.chkBinObj.AutoSize = true;
            this.chkBinObj.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBinObj.Location = new System.Drawing.Point(17, 79);
            this.chkBinObj.Name = "chkBinObj";
            this.chkBinObj.Size = new System.Drawing.Size(144, 18);
            this.chkBinObj.TabIndex = 2;
            this.chkBinObj.Text = "bin / obj / package";
            this.chkBinObj.UseVisualStyleBackColor = true;
            // 
            // chkPackageLock
            // 
            this.chkPackageLock.AutoSize = true;
            this.chkPackageLock.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPackageLock.Location = new System.Drawing.Point(17, 55);
            this.chkPackageLock.Name = "chkPackageLock";
            this.chkPackageLock.Size = new System.Drawing.Size(139, 18);
            this.chkPackageLock.TabIndex = 1;
            this.chkPackageLock.Text = "package-lock.json";
            this.chkPackageLock.UseVisualStyleBackColor = true;
            // 
            // chkReactNode
            // 
            this.chkReactNode.AutoSize = true;
            this.chkReactNode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReactNode.Location = new System.Drawing.Point(17, 31);
            this.chkReactNode.Name = "chkReactNode";
            this.chkReactNode.Size = new System.Drawing.Size(119, 18);
            this.chkReactNode.TabIndex = 0;
            this.chkReactNode.Text = "node_modules";
            this.chkReactNode.UseVisualStyleBackColor = true;
            // 
            // btnSetDirectory
            // 
            this.btnSetDirectory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDirectory.Location = new System.Drawing.Point(701, 26);
            this.btnSetDirectory.Name = "btnSetDirectory";
            this.btnSetDirectory.Size = new System.Drawing.Size(110, 23);
            this.btnSetDirectory.TabIndex = 8;
            this.btnSetDirectory.Text = "Set Directory";
            this.btnSetDirectory.UseVisualStyleBackColor = true;
            this.btnSetDirectory.Click += new System.EventHandler(this.btnSetDirectory_Click);
            // 
            // lblDirectoryProgress
            // 
            this.lblDirectoryProgress.AutoSize = true;
            this.lblDirectoryProgress.Location = new System.Drawing.Point(358, 57);
            this.lblDirectoryProgress.Name = "lblDirectoryProgress";
            this.lblDirectoryProgress.Size = new System.Drawing.Size(13, 13);
            this.lblDirectoryProgress.TabIndex = 6;
            this.lblDirectoryProgress.Text = "0";
            // 
            // chkThumbs
            // 
            this.chkThumbs.AutoSize = true;
            this.chkThumbs.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThumbs.Location = new System.Drawing.Point(17, 127);
            this.chkThumbs.Name = "chkThumbs";
            this.chkThumbs.Size = new System.Drawing.Size(95, 18);
            this.chkThumbs.TabIndex = 4;
            this.chkThumbs.Text = "Thumbs.db";
            this.chkThumbs.UseVisualStyleBackColor = true;
            // 
            // frmDeleteFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 338);
            this.Controls.Add(this.btnSetDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDirectoryProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDeleteFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Folder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPackageLock;
        private System.Windows.Forms.CheckBox chkReactNode;
        private System.Windows.Forms.CheckBox chkBinObj;
        private System.Windows.Forms.CheckBox chkDisconectTFS;
        private System.Windows.Forms.Button btnSetDirectory;
        private System.Windows.Forms.Label lblDirectoryProgress;
        private System.Windows.Forms.CheckBox chkThumbs;
    }
}