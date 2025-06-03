using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilCoding.Helpers;

namespace UtilCoding
{
    public partial class frmReplaceFile : Form
    {
        public frmReplaceFile()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Change() 
        { 
             DirectoryHelper.Instance.ReplaceText(txtPath.Text,txtOldValue.Text,txtNewValue.Text,txtExtension.Text);            
        }


    }
}
