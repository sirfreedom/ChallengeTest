using UtilCoding;
namespace UtilCoding
{
    partial class frmExportDatabase
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportDatabase));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BtnSalirTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAccessTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSqlTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOracleTool = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(16, 33);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1895, 555);
            this.panelContenedor.TabIndex = 32;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSalirTool,
            this.btnAccessTool,
            this.btnSqlTool,
            this.btnOracleTool,
            this.jsonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BtnSalirTool
            // 
            this.BtnSalirTool.Name = "BtnSalirTool";
            this.BtnSalirTool.Size = new System.Drawing.Size(52, 24);
            this.BtnSalirTool.Text = "Salir";
            this.BtnSalirTool.Click += new System.EventHandler(this.BtnSalirTool_Click);
            // 
            // btnAccessTool
            // 
            this.btnAccessTool.Name = "btnAccessTool";
            this.btnAccessTool.Size = new System.Drawing.Size(67, 24);
            this.btnAccessTool.Text = "Access";
            this.btnAccessTool.Click += new System.EventHandler(this.btnAccessTool_Click);
            // 
            // btnSqlTool
            // 
            this.btnSqlTool.Name = "btnSqlTool";
            this.btnSqlTool.Size = new System.Drawing.Size(89, 24);
            this.btnSqlTool.Text = "Sql Server";
            this.btnSqlTool.Click += new System.EventHandler(this.btnSqlTool_Click);
            // 
            // btnOracleTool
            // 
            this.btnOracleTool.Name = "btnOracleTool";
            this.btnOracleTool.Size = new System.Drawing.Size(66, 24);
            this.btnOracleTool.Text = "Oracle";
            this.btnOracleTool.Click += new System.EventHandler(this.btnOracleTool_Click);
            // 
            // jsonToolStripMenuItem
            // 
            this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            this.jsonToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.jsonToolStripMenuItem.Text = "Json";
            this.jsonToolStripMenuItem.Click += new System.EventHandler(this.jsonToolStripMenuItem_Click);
            // 
            // frmExportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 601);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExportDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtnSalirTool;
        private System.Windows.Forms.ToolStripMenuItem btnAccessTool;
        private System.Windows.Forms.ToolStripMenuItem btnSqlTool;
        private System.Windows.Forms.ToolStripMenuItem btnOracleTool;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
    }
}

