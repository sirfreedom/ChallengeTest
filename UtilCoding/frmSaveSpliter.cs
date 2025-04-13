using System;
using System.Windows.Forms;

namespace UtilCoding
{
    public partial class frmSaveSpliter : Form
    {
        private string _TextSpliter;


        public frmSaveSpliter(string TextSpliter)
        {
            _TextSpliter = TextSpliter;
            InitializeComponent();
        }

        private void SaveCode()
        {
            if (txtDescripcionSpliter.Text.Length == 0)
            {
                return;
            }
            BackupChanges.Instance.WriteInsertXml("4", _TextSpliter, txtDescripcionSpliter.Text, true);
            txtDescripcionSpliter.Text = string.Empty;
        }

        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            SaveCode();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
