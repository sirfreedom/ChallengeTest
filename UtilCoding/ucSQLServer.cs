using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace UtilCoding
{
    public partial class ucSQLServer : UserControl
    {

        #region Constructor

        public ucSQLServer()
        {
            InitializeComponent();
        }

        #endregion

        #region Load

        private void ucSQLServer_Load(object sender, EventArgs e)
        {
            gvTablesSQL.PrepararGrilla();
            GetConfiguration();
        }

        #endregion

        #region Method

        private void GetConfiguration() 
        {
            txtUser.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.User");
            txtPassword.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Pass");
            txtBase.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Base");
            txtServer.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Server");
            txtSchema.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Schema");
            txtCantidadRegistrosPorArchivo.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.RowsPerFile");
            txtTotalRegistros.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.TopRows");
            opPunto.Checked = bool.Parse(ConfigurationHelper.Instance.Read("UtilSqlServer.DecimalSeparatorDot"));
            txtPathScript.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Path");
            chkIntegratedSecurity.Checked = bool.Parse(ConfigurationHelper.Instance.Read("UtilSqlServer.IntegratedSecurity"));
            txtNamespace.Text = ConfigurationHelper.Instance.Read("UtilSqlServer.Namespace");
        }

        private void SetConfiguration() 
        {
            ConfigurationHelper.Instance.Save("UtilSqlServer.User",txtUser.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.Pass",txtPassword.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.Base", txtBase.Text );
            ConfigurationHelper.Instance.Save("UtilSqlServer.Server",txtServer.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.Schema",txtSchema.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.RowsPerFile",txtCantidadRegistrosPorArchivo.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.TopRows", txtTotalRegistros.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.DecimalSeparatorDot", opPunto.Checked.ToString());
            ConfigurationHelper.Instance.Save("UtilSqlServer.Path", txtPathScript.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.Namespace", txtPathScript.Text);
            ConfigurationHelper.Instance.Save("UtilSqlServer.IntegratedSecurity", chkIntegratedSecurity.Checked.ToString());
        }


        private void GetTables() 
        {
            List<SQLServerManager.TableRelation> lTableInfo = new List<SQLServerManager.TableRelation>();
            try
            {
                if (txtBase.Text.Length == 0 || txtServer.Text.Length == 0)
                {
                    return;
                }
                SQLServerManager oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
                lTableInfo = oSql.GetTables();

                if (lTableInfo.Count == 0) 
                {
                    throw new AppException("No se encontraron tablas en la base de datos");
                }

                gvTablesSQL.DataSource = lTableInfo;
                gvTablesSQL.PrepararGrilla();
            }
            catch (AppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPath()
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowDialog();
            txtPathScript.Text = fb.SelectedPath + "\\";
        }

        private void CleanFields() 
        {
            gvTablesSQL.CleanRows();
        }

        private void CreateSP() 
        {
            if (!chkStoreProcedure.Checked) { return; }

            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateSP(lTable,txtPathScript.Text,chkList.Checked,chkGet.Checked,chkFind.Checked,chkInsert.Checked,chkUpdate.Checked,chkDelete.Checked);
        }

        private void CreateDataLayerClass() 
        {
            if (!chkDataLayer.Checked) { return; }

            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateDataLayerClass(lTable, txtPathScript.Text, txtNamespace.Text, txtBaseClass.Text,chkList.Checked,chkGet.Checked,chkFind.Checked,chkInsert.Checked,chkUpdate.Checked,chkDelete.Checked);
        }

        private void CreateBizLayerClass() 
        {
            if (!chkBizLayer.Checked) { return; }

            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateBizLayerClass(lTable, txtPathScript.Text, txtNamespace.Text, txtBaseClass.Text, chkList.Checked, chkGet.Checked, chkFind.Checked, chkInsert.Checked, chkUpdate.Checked, chkDelete.Checked);
        }

        private void CreateClass() 
        {
            if (!chkClass.Checked) { return; }

            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateClass(lTable, txtPathScript.Text, chkIncludePK.Checked , txtNamespace.Text,txtBaseClass.Text);
        }

        private void CreateModelClass() 
        {
            if (!chkModelClass.Checked) { return; }

            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateClassModel(lTable, txtPathScript.Text, txtNamespace.Text, txtBaseClass.Text);
        }

        private void CreateController() 
        {
            SQLServerManager oSql;
            List<string> lTable = new List<string>();
            oSql = new SQLServerManager(txtBase.Text, txtServer.Text, txtUser.Text, txtPassword.Text, chkIntegratedSecurity.Checked);
            lTable = gvTablesSQL.GetSeleccionados("chkSel", "TableName");
            oSql.CreateControllerClass(lTable, txtPathScript.Text, txtNamespace.Text, txtBaseController.Text, chkList.Checked, chkGet.Checked, chkFind.Checked, chkInsert.Checked, chkUpdate.Checked, chkDelete.Checked);
        }

        private void ButtonEnabled(bool Habilitar) 
        {
            btnExport.Enabled = Habilitar;
            btnCreateSP.Enabled = Habilitar;
            chkClass.Enabled = Habilitar;
            chkDataLayer.Enabled = Habilitar;
            chkBizLayer.Enabled = Habilitar;
            chkControllerLayer.Enabled = Habilitar;
            chkModelClass.Enabled = Habilitar;
        }

        #endregion

        #region Eventos

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            try
            {
                GetTables();
                ButtonEnabled(true);   
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WorkerSql.CancelAsync();
            lblCargando.Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            lblCargando.Visible = true;
            List<string> lTables = new List<string>();
            SQLServerManager.ParameterExport oParam = new SQLServerManager.ParameterExport();
            string sPath = string.Empty;
            try
            {
                if (txtBase.Text.Length == 0)
                {
                    throw new AppException("Debe incluir base de datos");
                }
                if (txtServer.Text.Length == 0)
                {
                    throw new AppException("VERIFIQUE Server");
                }
                if (txtPathScript.Text.Length == 0 && !File.Exists(txtPathScript.Text))
                {
                    throw new AppException("VERIFIQUE PATH donde dejar el Script, presione 'Open' para seleccionarlo.");
                }
                if (gvTablesSQL.Rows.Count == 0 || gvTablesSQL.GetSeleccionados("chkSel", "TableName").Count == 0)
                {
                    throw new AppException("Verifique las tablas seleccionadas");
                }
                if (opPunto.Checked)
                {
                    oParam.PuntoComa = SQLServerManager.LenguajePuntoComa.Punto;
                }
                else
                {
                    oParam.PuntoComa = SQLServerManager.LenguajePuntoComa.Coma;
                }

                oParam.lTables = gvTablesSQL.GetSeleccionados("chkSel", "TableName");

                if (opOracle.Checked)
                {
                    oParam.TipoMotorExport = SQLServerManager.TipoMotor.Oracle;
                }

                if (opSQL2000.Checked)
                {
                    oParam.TipoMotorExport = SQLServerManager.TipoMotor.SqlServer2000;
                }

                if (opSQL2005.Checked)
                {
                    oParam.TipoMotorExport = SQLServerManager.TipoMotor.SqlServer2005;
                }

                oParam.PathInicial = txtPathScript.Text;
                oParam.Base = txtBase.Text;
                oParam.IntegratedSecurity = chkIntegratedSecurity.Checked;
                oParam.PassBase = txtPassword.Text;
                oParam.Schema = txtSchema.Text;
                oParam.Server = txtServer.Text;
                oParam.UserBase = txtUser.Text;
                oParam.RowPerPage = int.Parse(txtCantidadRegistrosPorArchivo.Text);
                btnCancel.Enabled = true;
                WorkerSql.RunWorkerAsync(oParam);
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WorkerSql_DoWork(object sender, DoWorkEventArgs e)
        {
            string sScript = string.Empty;
            SQLServerManager oSql;
            SQLServerManager.ParameterExport oParam = new SQLServerManager.ParameterExport();
            oParam = (SQLServerManager.ParameterExport)e.Argument;
            try
            {
                oSql = new SQLServerManager(oParam.Base, oParam.Server, oParam.UserBase, oParam.PassBase, oParam.IntegratedSecurity);
                oSql.SaveOutputScript(oParam.lTables, oParam.TipoMotorExport, oParam.PathInicial,oParam.Schema,oParam.RowPerPage);
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WorkerSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblCargando.Visible = false;
            SetConfiguration();
            ButtonEnabled(false);
            btnCancel.Enabled = false;
        }

        private void btnPathScript_Click(object sender, EventArgs e)
        {
            SetPath();
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            if (gvTablesSQL.Rows.Count > 1)
            {
                gvTablesSQL.SeleccionarTodosLosRegistros("chkSel",true);
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            if (gvTablesSQL.Rows.Count > 1)
            {
                gvTablesSQL.SeleccionarTodosLosRegistros("chkSel", false);
            }
        }


        private void btnCreateSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBase.Text.Length == 0)
                {
                    throw new AppException("Debe incluir base de datos");
                }
                if (txtServer.Text.Length == 0)
                {
                    throw new AppException("VERIFIQUE Server");
                }
                if (txtPathScript.Text.Length == 0  && !File.Exists(txtPathScript.Text) )
                {
                    throw new AppException("VERIFIQUE PATH donde dejar el Script, presione 'Open' para seleccionarlo.");
                }
                if (gvTablesSQL.Rows.Count == 0 || gvTablesSQL.GetSeleccionados("chkSel", "TableName").Count == 0)
                {
                    throw new AppException("Verifique las tablas seleccionadas");
                }
                ButtonEnabled(false);
                CreateSP();
                CreateClass();
                CreateDataLayerClass();
                CreateBizLayerClass();
                CreateController();
                CreateModelClass();
                ButtonEnabled(true);
                MessageBox.Show("Finalizo la exportacion de store procedures", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBase.Text.Length == 0)
                {
                    throw new AppException("Debe incluir base de datos");
                }
                if (txtServer.Text.Length == 0)
                {
                    throw new AppException("VERIFIQUE Server");
                }
                if (txtPathScript.Text.Length == 0 && !File.Exists(txtPathScript.Text))
                {
                    throw new AppException("VERIFIQUE PATH donde dejar el Script, presione 'Open' para seleccionarlo.");
                }
                if (gvTablesSQL.Rows.Count == 0 || gvTablesSQL.GetSeleccionados("chkSel", "TableName").Count == 0)
                {
                    throw new AppException("Verifique las tablas seleccionadas");
                }

                
                MessageBox.Show("Finalizo la exportacion de class con sus propiedades", "Classes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtNamespace_Click(object sender, EventArgs e)
        {
            txtNamespace.Text = string.Empty;
        }

        private void txtBaseClass_Click(object sender, EventArgs e)
        {
            txtBaseClass.Text = string.Empty;
        }

        private void ucSQLServer_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            SetConfiguration();
        }
             
    }
}
