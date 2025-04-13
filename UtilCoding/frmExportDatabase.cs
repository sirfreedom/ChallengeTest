using System;
using System.Windows.Forms;

namespace UtilCoding
{
    public partial class frmExportDatabase : Form
    {

 

        #region Constructor

        public frmExportDatabase()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos Genericos

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        #endregion

        private void btnAccessTool_Click(object sender, EventArgs e)
        {
            ucAccess frmAccess = new ucAccess();

            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmAccess);
            }
            else 
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmAccess);
            }
        }

        private void btnSqlTool_Click(object sender, EventArgs e)
        {
            ucSQLServer frmSql = new ucSQLServer();
            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmSql);
            }
            else
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmSql);
            }
        }

        private void btnOracleTool_Click(object sender, EventArgs e)
        {
            ucOracle frmOracle = new ucOracle();
            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmOracle);
            }
            else
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmOracle);
            }
        }

        private void BtnSalirTool_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            this.Close();
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucJson frmjson = new ucJson();
            if (panelContenedor.Controls.Count == 0)
            {
                panelContenedor.Controls.Add(frmjson);
            }
            else
            {
                panelContenedor.Controls.Clear();
                panelContenedor.Controls.Add(frmjson);
            }
        }



    }
}