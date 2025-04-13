using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilCoding.Helpers;
using static UtilCoding.Helpers.DirectoryHelper;

namespace UtilCoding
{
    public partial class frmSearch : Form
    {

        public frmSearch()
        {
            InitializeComponent();
        }

        private void SearchText() 
        {
            DirectoryHelper.SearchText oSearchText = new DirectoryHelper.SearchText();
            Task<List<DirectoryHelper.ObjectFile>> oTask;
            try
            {
                oSearchText.Path = txtPath.Text;
                oSearchText.FileName = txtNameFile_SearchInternalFile.Text;
                oSearchText.Extension = ddlExtension.SelectedValue.ToString();
                oSearchText.IncludeText = txtInternalText.Text;
                oSearchText.ExcludeText = txtNoIncludeText.Text;

                gvCheck.DataSource = new List<DirectoryHelper.ObjectFile>();

                FreezeWhileRun(false);
                oTask = DirectoryHelper.Instance.FindTextWithoutAnotherText(oSearchText);
                gvCheck.DataSource = BaseEntity.ToDataTable<ObjectFile>(oTask.Result);
                gvCheck.PrepararGrilla();
                FreezeWhileRun(oTask.IsCompleted);
            }
            catch (DirectoryHelper.DirectoryHelperException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchFile() 
        {
            DirectoryHelper.SearchFile oSearchFile = new DirectoryHelper.SearchFile();
            Task<List<DirectoryHelper.ObjectFile>> oTask;
            try
            {
                oSearchFile.Path = txtPath.Text;
                oSearchFile.FileName = txtFilename.Text;

                gvCheck.DataSource = new List<DirectoryHelper.ObjectFile>();

                FreezeWhileRun(false);
                oTask = DirectoryHelper.Instance.FindFiles(oSearchFile);
                gvCheck.DataSource = BaseEntity.ToDataTable<ObjectFile>(oTask.Result);
                gvCheck.PrepararGrilla();
                FreezeWhileRun(oTask.IsCompleted);
            }
            catch (DirectoryHelper.DirectoryHelperException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void FillExtension() 
        {
            List<string> lExtension = new List<string>() { "cs","css", "sass" ,"js", "vb", "xml", "jsx" ,"txt", "json", "*"};
            ddlExtension.DataSource = DirectoryHelper.Instance.ListToDatatable(lExtension);
            ddlExtension.DisplayMember = "Descripcion";
            ddlExtension.ValueMember = "Id";
        }

        private void Export() 
        {
            StringBuilder sbFile = new StringBuilder();
            string[] lResult;
            try 
            {
                saveFileDialog1.FileName = sbFile.ToString();
                saveFileDialog1.ShowDialog();
                sbFile.Append(saveFileDialog1.FileName);
                sbFile.Append(".csv");

                if (saveFileDialog1.FileName.Length == 0  || gvCheck.CountRows == 0 ) 
                {
                    MessageBox.Show("Cancel Process","Cancel process",MessageBoxButtons.OK);
                    return;
                }

                lResult = gvCheck.GetReport();
                File.WriteAllLines(sbFile.ToString(),lResult);
            }
            catch (DirectoryHelper.DirectoryHelperException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btninternalSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchText();
            }
            catch (DirectoryHelper.DirectoryHelperException ex)
            {
                MessageBox.Show(ex.Message); 
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            FillExtension();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FreezeWhileRun(bool lEnabled) 
        {
            btninternalSearch.Enabled = lEnabled;
            btnFullSearch.Enabled = lEnabled;
            btnExport.Enabled = lEnabled;
            btnCopy.Enabled = lEnabled;
            lblWorking.Visible = !lEnabled;
        }

        private void btnFullSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchFile();
            }
            catch (DirectoryHelper.DirectoryHelperException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                gSearchFile.Enabled = true;
                gSearchText.Enabled = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string sPath = string.Empty;
            string[] lResult;
            string sNombreArchivo;
            string sPathInicialArchivo;

            try
            {
                folderBrowserCopy.ShowDialog();
                sPath = folderBrowserCopy.SelectedPath;
                lResult = gvCheck.GetReport();
                
                for (int i=1;i< lResult.Length;i++) 
                {
                    StringBuilder sbPathFin = new StringBuilder();
                    StringBuilder sbPathCopy = new StringBuilder();
                    sNombreArchivo = lResult[i].Split(',').GetValue(0).ToString();
                    sPathInicialArchivo = lResult[i].Split(',').GetValue(1).ToString();

                    sbPathFin.Append(sPath);
                    sbPathFin.Append(@"\");
                    sbPathCopy.Append(sPath);
                    sbPathCopy.Append(@"\");

                    sbPathFin.Append(sNombreArchivo);

                    if ( File.Exists(sbPathFin.ToString()) )
                    {
                        sbPathCopy.Append(i.ToString());
                    }

                    sbPathCopy.Append(sNombreArchivo);

                    File.Copy(sPathInicialArchivo, sbPathCopy.ToString());
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
