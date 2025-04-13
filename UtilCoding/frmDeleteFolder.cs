using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace UtilCoding
{
    public partial class frmDeleteFolder : Form
    {


        public frmDeleteFolder()
        {
            InitializeComponent();
        }

        private void SetConfiguration() 
        {
            if (txtFolder.Text.Length == 0) {
                return;
            }

            ConfigurationHelper.Instance.Save("UtilDelete.Path", txtFolder.Text);
        }

        private void GetConfiguration() 
        {
            txtFolder.Text = ConfigurationHelper.Instance.Read("UtilDelete.Path");
        }

        private void txtFolder_Click(object sender, EventArgs e)
        {
            SetDirectory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteConfigurationModel oConfiguration = new DeleteConfigurationModel();

            if (txtFolder.Text.Length == 0){
                return;
            }
            lblDirectoryProgress.Text = string.Empty;
            btnClose.Enabled = false;
            btnDelete.Enabled = false;

            oConfiguration.PrincipalPath = txtFolder.Text;

            if (chkBinObj.Checked) {
                oConfiguration.lDirectory.Add("bin");
                oConfiguration.lDirectory.Add("obj");
                oConfiguration.lDirectory.Add(".vscode");
            }
            if (chkPackageLock.Checked) {
                oConfiguration.lFile.Add("package-lock.json");
            }
            if (chkReactNode.Checked) {
                oConfiguration.lDirectory.Add("node_modules");
            }

            if (chkDisconectTFS.Checked) {
                oConfiguration.lExt.Add(".vspscc");
                oConfiguration.lDirectory.Add(".vs");
                oConfiguration.lDirectory.Add(".git");
                oConfiguration.lDirectory.Add("packages");
            }

            if (chkThumbs.Checked) {
                oConfiguration.lFile.Add("Thumbs.db");
            }

            backgroundWorker1.RunWorkerAsync(oConfiguration);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo[] lTopDirectoryInfo;
            List<DirectoryDeleteModel> lTopDirectoryDelete = new List<DirectoryDeleteModel>();
            List<DirectoryDeleteModel> lDirectoryFiles = new List<DirectoryDeleteModel>();
            DeleteConfigurationModel oConfiguration = new DeleteConfigurationModel();
            StringBuilder sbFilterFile = new StringBuilder();
            try
            {
                oConfiguration = (DeleteConfigurationModel)e.Argument;
                DirectoryInfo d = new DirectoryInfo(oConfiguration.PrincipalPath);
                lTopDirectoryInfo = d.GetDirectories("*.*", SearchOption.AllDirectories);

                if (lTopDirectoryInfo.Length == 0)
                {
                    return;
                }

                for (int iFile = 0; iFile < oConfiguration.lFile.Count; iFile++)
                {
                    sbFilterFile.Append(oConfiguration.lFile[iFile]);

                    if (iFile < oConfiguration.lFile.Count - 1)
                    {
                        sbFilterFile.Append(",");
                    }
                }

                var queryDirectoriesDelete = from p in lTopDirectoryInfo
                                             join o in oConfiguration.lDirectory on
                                             p.Name.ToLower() equals o.ToLower()
                                             select new { p.Name, p.FullName, p.Attributes };

                var queryDirectoryFiles = lTopDirectoryInfo.Where(x => !oConfiguration.lDirectory.Contains(x.Name.ToLower()));


                lTopDirectoryDelete = queryDirectoriesDelete.ToList().Select(x => new DirectoryDeleteModel
                {
                    Name = x.Name,
                    FullName = x.FullName,
                    IsHidden = x.Attributes.ToString().Split(',').Contains("Hidden"),
                    lFile = new List<string>().ToArray()
                }).ToList();


                lDirectoryFiles = queryDirectoryFiles.Select(x => new DirectoryDeleteModel
                {
                    Name = x.Name,
                    FullName = x.FullName,
                    IsHidden = x.Attributes.ToString().Split(',').Contains("Hidden"),
                    lFile = Directory.GetFiles(x.FullName, "*.*")
                }).ToList();


                lDirectoryFiles.Add(new DirectoryDeleteModel
                {
                    Name = "",
                    FullName = oConfiguration.PrincipalPath,
                    IsHidden = false,
                    lFile = Directory.GetFiles(oConfiguration.PrincipalPath,"*.*")
                });


                for (int iDirectory = 0; iDirectory < lTopDirectoryDelete.Count; iDirectory++)
                {
                    Directory.Delete(lTopDirectoryDelete[iDirectory].FullName,true);
                }

                for (int iDirectoryFile = 0; iDirectoryFile < lDirectoryFiles.Count; iDirectoryFile++)
                {
                    for (int iFile = 0; iFile < lDirectoryFiles[iDirectoryFile].lFile.Length; iFile++)
                    {
                        StringBuilder sbFile = new StringBuilder();
                        string sNombreFile;
                        string sExtFile;
                        sNombreFile = Path.GetFileNameWithoutExtension(lDirectoryFiles[iDirectoryFile].lFile[iFile]);
                        sExtFile = Path.GetExtension(lDirectoryFiles[iDirectoryFile].lFile[iFile]);
                        sbFile.Append(sNombreFile);
                        sbFile.Append(sExtFile);

                        if (oConfiguration.lFile.Contains(sbFile.ToString()) || oConfiguration.lExt.Contains(sExtFile))
                        {
                            File.Delete(lDirectoryFiles[iDirectoryFile].lFile[iFile]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnClose.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = true;
            lblDirectoryProgress.Text = "100 %";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SetConfiguration();
            this.Close();
        }

        internal class DeleteConfigurationModel 
        {
            public string PrincipalPath { get; set; }

            public bool HiddenFolder { get; set; } = false;
            public List<string> lDirectory { get; set; } = new List<string>();
            public List<string> lFile { get; set; } = new List<string>();
            public List<string> lExt { get; set; } = new List<string>();
        }

        internal class DirectoryDeleteModel 
        { 
            public string Name { get; set; }
            public string FullName { get; set; }
            public bool IsHidden { get; set; }
            public string[] lFile { get; set; }
        }

       
        private void btnSetDirectory_Click(object sender, EventArgs e)
        {
            SetDirectory();
        }

        private void SetDirectory() 
        {
            folderBrowserDialog1.ShowDialog();
            txtFolder.Text = folderBrowserDialog1.SelectedPath;
        }



    }
}
