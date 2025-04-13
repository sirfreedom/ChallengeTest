using System;
using System.Windows.Forms;

namespace UtilCoding
{
    public partial class FrmReplace : Form
    {
        public FrmReplace()
        {
            InitializeComponent();
        }

        private void Replace() 
        {
            string sReplace1 = string.Empty;
            string sReplace2 = string.Empty;
            string sReplace3 = string.Empty;
            string sValorInicial = string.Empty;
            
            sValorInicial = txtIni.Text;

            if (txtReplace1.Text.Trim() != "" && (BackupChanges.Instance.NullToString(ddlReplace1.SelectedValue) == "") )
            {
                sReplace1 = txtReplace1.Text.Trim();
            }

            if (txtReplace1.Text.Trim() == "" && (BackupChanges.Instance.NullToString(ddlReplace1.SelectedValue) != "") )
            { 
                sReplace1 = ddlReplace1.SelectedValue.ToString();
            }

            if (txtReplace2.Text.Trim() != "" && BackupChanges.Instance.NullToString(ddlReplace2.SelectedValue) == "")  
            {
                sReplace2 = txtReplace2.Text.Trim();
            }

            if (txtReplace2.Text.Trim() == "" && BackupChanges.Instance.NullToString(ddlReplace2.SelectedValue) != "")
            {
                sReplace2 = ddlReplace2.SelectedValue.ToString();
            }

            if (txtReplace3.Text.Trim() != "" && BackupChanges.Instance.NullToString(ddlReplace3.SelectedValue) == "")
            {
                sReplace3 = txtReplace3.Text.Trim();
            }

            if (txtReplace3.Text.Trim() == "" && BackupChanges.Instance.NullToString(ddlReplace3.SelectedValue) != "")
            {
                sReplace3 = ddlReplace3.SelectedValue.ToString();
            }

            if (chkReplace1.Checked)
            {
                sValorInicial = sValorInicial.Replace(txtReplace1a.Text, sReplace1);
            }

            if (!chkReplace1.Checked)
            {
                sValorInicial = sValorInicial.Replace(txtReplace1a.Text, "");
            }

            if (chkReplace2.Checked)
            {
                sValorInicial = sValorInicial.Replace(txtReplace2a.Text, sReplace2);
            }

            if (!chkReplace2.Checked)
            {
                sValorInicial = sValorInicial.Replace(txtReplace2a.Text, "");
            }

            if (chkReplace3.Checked && (txtReplace3.Text != "" || BackupChanges.Instance.NullToString(ddlReplace3.SelectedValue) != ""))
            {
                sValorInicial = sValorInicial.Replace(txtReplace3a.Text, sReplace3);
            }

            if (!chkReplace3.Checked)
            {
                sValorInicial = sValorInicial.Replace(txtReplace3a.Text, "");
            }

            txtFinish.Text = sValorInicial.Replace("  "," ");
        }

        private void FillDropboxList() 
        {
            ddlReplace1.DataSource = BackupChanges.Instance.Read("1");
            ddlReplace1.DisplayMember = "d";
            ddlReplace1.ValueMember = "d";
            ddlReplace1.SelectedValue = "";

            ddlReplace2.DataSource = BackupChanges.Instance.Read("2");
            ddlReplace2.DisplayMember = "d";
            ddlReplace2.ValueMember = "d";
            ddlReplace2.SelectedValue = "";

            ddlReplace3.DataSource = BackupChanges.Instance.Read("3");
            ddlReplace3.DisplayMember = "d";
            ddlReplace3.ValueMember = "d";
            ddlReplace3.SelectedValue = "";
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void txtReplace2_TextChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void txtReplace3_TextChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void txtReplace1_TextChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void chkReplace2_CheckStateChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void chkReplace3_CheckedChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void txtReplace1_DoubleClick(object sender, EventArgs e)
        {
            txtReplace1.Text = string.Empty;

            if (ddlReplace1.Items.Count > 0)
            {
                ddlReplace1.SelectedValue = "";
            }
        }

        private void txtReplace2_DoubleClick(object sender, EventArgs e)
        {
            txtReplace2.Text = string.Empty;
            if (ddlReplace2.Items.Count > 0)
            {
                ddlReplace2.SelectedValue = "";
            }
        }

        private void btnReplace1Clean_Click(object sender, EventArgs e)
        {
            txtReplace1.Text = string.Empty;
        }

        private void btnReplace2Clean_Click(object sender, EventArgs e)
        {
            txtReplace2.Text = string.Empty;
        }

        private void btnReplace3Clean_Click(object sender, EventArgs e)
        {
            txtReplace3.Text = string.Empty;
        }

        private void btnReplace1Add_Click(object sender, EventArgs e)
        {
            BackupChanges.Instance.WriteInsertXml("1", txtReplace1.Text);
            ddlReplace1.DataSource = BackupChanges.Instance.Read("1");
            ddlReplace1.SelectedValue = "";
        }

        private void btnReplace2Add_Click(object sender, EventArgs e)
        {
            BackupChanges.Instance.WriteInsertXml("2", txtReplace2.Text);
            ddlReplace2.DataSource = BackupChanges.Instance.Read("2");
            ddlReplace2.SelectedValue = "";
        }

        private void btnReplace3Add_Click(object sender, EventArgs e)
        {
            BackupChanges.Instance.WriteInsertXml("3", txtReplace3.Text);
            ddlReplace3.DataSource = BackupChanges.Instance.Read("3");
            ddlReplace3.SelectedValue = "";
        }

        private void FrmChange_Load(object sender, EventArgs e)
        {
            FillDropboxList();
        }

        private void ddlReplace1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void ddlReplace2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void ddlReplace3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void chkReplace1_CheckedChanged(object sender, EventArgs e)
        {
            Replace();
        }

        private void ddlReplace1_TextChanged(object sender, EventArgs e)
        {
            txtReplace1.Text = string.Empty;
        }

        private void ddlReplace2_TextChanged(object sender, EventArgs e)
        {
            txtReplace2.Text = string.Empty;
        }

        private void ddlReplace3_TextChanged(object sender, EventArgs e)
        {
            txtReplace3.Text = string.Empty;
        }

        private void txtReplace1_Click(object sender, EventArgs e)
        {
            if (ddlReplace1.Items.Count > 0) {
                ddlReplace1.SelectedValue = "";
            }
        }

        private void txtReplace2_Click(object sender, EventArgs e)
        {
            if (ddlReplace2.Items.Count > 0)
            {
                ddlReplace2.SelectedValue = "";
            }
        }

        private void txtReplace3_Click(object sender, EventArgs e)
        {
            if (ddlReplace3.Items.Count > 0)
            {
                ddlReplace3.SelectedValue = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

