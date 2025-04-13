using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UtilCoding
{
    public partial class frmSpliter : Form
    {
        public frmSpliter()
        {
            InitializeComponent();
        }

        private void FillDropList() 
        {
            List<BackupChanges.BackUpEntity> lSpliter;
            lSpliter = BackupChanges.Instance.Read("4", true);
            ddlSpliter.DataSource = lSpliter;
            ddlSpliter.DisplayMember = "v";
            ddlSpliter.ValueMember = "d";
            ddlSpliter.SelectedValue = "";
        }

        private void SaveCode() 
        {
            List<BackupChanges.BackUpEntity> lSpliter;
            frmSaveSpliter f = new frmSaveSpliter(txtIni.Text);

            if(txtIni.Text.Length < 10 ) 
            {
                return;
            }

            f.ShowDialog();

            lSpliter = BackupChanges.Instance.Read("4", true);

            ddlSpliter.DataSource = lSpliter;
            ddlSpliter.DisplayMember = "v";
            ddlSpliter.ValueMember = "d";
            ddlSpliter.SelectedValue = "";
        }

        private void Replace() 
        {
            try
            {
                string s = string.Empty;
                s = txtIni.Text;
                s = (txtReplace1a.Text.Length > 0) ? s.Replace(txtReplace1a.Text, txtReplace1b.Text) : s; 
                s = (txtReplace2a.Text.Length > 0) ? s.Replace(txtReplace2a.Text, txtReplace2b.Text) : s;
                s = (txtReplace3a.Text.Length > 0) ? s.Replace(txtReplace3a.Text, txtReplace3b.Text) : s;
                txtIni.Text = s;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void Trim() 
        {
            try
            {




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillCheckLines() 
        {
            char[] lc;
            string[] lsFinal;
            string[] lsLineas;
            string sFull;
            char[] Enter = new[] { '\r', '\n' };
            StringBuilder sb = new StringBuilder();
            int iLenOfArray = 0;
            try
            {
                lc = txtSplitCaracter.Text.ToCharArray();
                sFull = txtIni.Text;

                lsLineas = sFull.Split(Enter, StringSplitOptions.RemoveEmptyEntries);

                for(int i = 0;i < lsLineas.Length;i++)
                {
                    lsFinal = lsLineas[i].Trim().Split(lc, StringSplitOptions.RemoveEmptyEntries);
                    iLenOfArray = (lsFinal.Length > iLenOfArray) ? lsFinal.Length : iLenOfArray;
                }
                chkItemShow.Items.Clear();
                ddlSplitNumber.Items.Clear();

                for (int i = 0; i < iLenOfArray; i++) 
                {
                    ddlSplitNumber.Items.Add(i);       
                }
                ddlSplitNumber.Enabled = true;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void AddItem() 
        {
            chkItemShow.Items.Add(ddlSplitNumber.SelectedItem.ToString(), true);
            chkItemShow.Enabled = true;
            btnSplit.Enabled = true;
        }

        private void btnSaveCode_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveCode();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSpliter_Load(object sender, System.EventArgs e)
        {
            try
            {
                FillDropList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Split() 
        {
            char[] lc;
            string[] lsFinal;
            string[] lsLineas;
            int iValue = 0;
            string sFull;
            char[] Enter = new[] { '\r', '\n' };
            StringBuilder sb = new StringBuilder();
            try
            {
                lc = (txtSplitCaracter.Text.Length > 0) ? txtSplitCaracter.Text.ToCharArray() : " ".ToCharArray();
                sFull = txtIni.Text;

                lsLineas = sFull.Split(Enter, StringSplitOptions.RemoveEmptyEntries);

                foreach (string sLinea in lsLineas)
                {
                    lsFinal = sLinea.Trim().Split(lc, StringSplitOptions.RemoveEmptyEntries);

                    for (int i=0;i<chkItemShow.Items.Count;i++) 
                    {
                        iValue = int.Parse(chkItemShow.Items[i].ToString());
                        sb.Append((lsFinal.Length >= iValue) ? lsFinal[iValue] : "");
                        sb.Append(" ");
                    }
                    sb.AppendLine();
                }

                txtFinish.Text = sb.ToString();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void ddlSpliter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                txtIni.Text = ddlSpliter.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReplace_Click(object sender, System.EventArgs e)
        {
            try
            {
                Replace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillCheckLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCleanChecks_Click(object sender, EventArgs e)
        {
            try
            {
                chkItemShow.Items.Clear();
                btnSplit.Enabled = false;
                txtFinish.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                Split();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkItemShow_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                Split();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSplitCaracter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillCheckLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
