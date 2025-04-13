
namespace UtilCoding
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btninternalSearch = new System.Windows.Forms.Button();
            this.txtNameFile_SearchInternalFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInternalText = new System.Windows.Forms.TextBox();
            this.gSearchText = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoIncludeText = new System.Windows.Forms.TextBox();
            this.ddlExtension = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gSearchFile = new System.Windows.Forms.GroupBox();
            this.btnFullSearch = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblWorking = new System.Windows.Forms.Label();
            this.gvCheck = new cDataGridView();
            this.LinkArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TamanoArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtensionArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtributosArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopy = new System.Windows.Forms.Button();
            this.folderBrowserCopy = new System.Windows.Forms.FolderBrowserDialog();
            this.gSearchText.SuspendLayout();
            this.gSearchFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(346, 10);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(37, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(389, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(343, 23);
            this.txtPath.TabIndex = 0;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btninternalSearch
            // 
            this.btninternalSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninternalSearch.Location = new System.Drawing.Point(358, 138);
            this.btninternalSearch.Name = "btninternalSearch";
            this.btninternalSearch.Size = new System.Drawing.Size(155, 23);
            this.btninternalSearch.TabIndex = 3;
            this.btninternalSearch.Text = "Search Text";
            this.btninternalSearch.UseVisualStyleBackColor = true;
            this.btninternalSearch.Click += new System.EventHandler(this.btninternalSearch_Click);
            // 
            // txtNameFile_SearchInternalFile
            // 
            this.txtNameFile_SearchInternalFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameFile_SearchInternalFile.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameFile_SearchInternalFile.Location = new System.Drawing.Point(119, 24);
            this.txtNameFile_SearchInternalFile.Name = "txtNameFile_SearchInternalFile";
            this.txtNameFile_SearchInternalFile.Size = new System.Drawing.Size(343, 23);
            this.txtNameFile_SearchInternalFile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Include Text";
            // 
            // txtInternalText
            // 
            this.txtInternalText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInternalText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInternalText.Location = new System.Drawing.Point(119, 80);
            this.txtInternalText.Name = "txtInternalText";
            this.txtInternalText.Size = new System.Drawing.Size(343, 23);
            this.txtInternalText.TabIndex = 6;
            // 
            // gSearchText
            // 
            this.gSearchText.Controls.Add(this.label4);
            this.gSearchText.Controls.Add(this.txtNoIncludeText);
            this.gSearchText.Controls.Add(this.ddlExtension);
            this.gSearchText.Controls.Add(this.btninternalSearch);
            this.gSearchText.Controls.Add(this.label3);
            this.gSearchText.Controls.Add(this.txtInternalText);
            this.gSearchText.Controls.Add(this.label2);
            this.gSearchText.Controls.Add(this.txtNameFile_SearchInternalFile);
            this.gSearchText.Controls.Add(this.label1);
            this.gSearchText.Enabled = false;
            this.gSearchText.Location = new System.Drawing.Point(12, 37);
            this.gSearchText.Name = "gSearchText";
            this.gSearchText.Size = new System.Drawing.Size(519, 170);
            this.gSearchText.TabIndex = 8;
            this.gSearchText.TabStop = false;
            this.gSearchText.Text = "Search Text Inside file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "No Include Text";
            // 
            // txtNoIncludeText
            // 
            this.txtNoIncludeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoIncludeText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoIncludeText.Location = new System.Drawing.Point(119, 109);
            this.txtNoIncludeText.Name = "txtNoIncludeText";
            this.txtNoIncludeText.Size = new System.Drawing.Size(343, 23);
            this.txtNoIncludeText.TabIndex = 10;
            // 
            // ddlExtension
            // 
            this.ddlExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlExtension.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ddlExtension.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlExtension.FormattingEnabled = true;
            this.ddlExtension.Location = new System.Drawing.Point(119, 53);
            this.ddlExtension.Name = "ddlExtension";
            this.ddlExtension.Size = new System.Drawing.Size(121, 24);
            this.ddlExtension.Sorted = true;
            this.ddlExtension.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Extension";
            // 
            // gSearchFile
            // 
            this.gSearchFile.Controls.Add(this.btnFullSearch);
            this.gSearchFile.Controls.Add(this.txtFilename);
            this.gSearchFile.Controls.Add(this.label6);
            this.gSearchFile.Enabled = false;
            this.gSearchFile.Location = new System.Drawing.Point(537, 37);
            this.gSearchFile.Name = "gSearchFile";
            this.gSearchFile.Size = new System.Drawing.Size(519, 170);
            this.gSearchFile.TabIndex = 9;
            this.gSearchFile.TabStop = false;
            this.gSearchFile.Text = "Search File";
            // 
            // btnFullSearch
            // 
            this.btnFullSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullSearch.Location = new System.Drawing.Point(357, 138);
            this.btnFullSearch.Name = "btnFullSearch";
            this.btnFullSearch.Size = new System.Drawing.Size(155, 23);
            this.btnFullSearch.TabIndex = 3;
            this.btnFullSearch.Text = "Search Files";
            this.btnFullSearch.UseVisualStyleBackColor = true;
            this.btnFullSearch.Click += new System.EventHandler(this.btnFullSearch_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilename.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(123, 48);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(343, 23);
            this.txtFilename.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "File Name";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(894, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(726, 418);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(162, 37);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.CheckPathExists = false;
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = " \"Text files (*.csv)|*.csv|All files (*.*)|*.*\";";
            this.saveFileDialog1.OverwritePrompt = false;
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.ForeColor = System.Drawing.Color.Red;
            this.lblWorking.Location = new System.Drawing.Point(12, 422);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(105, 24);
            this.lblWorking.TabIndex = 12;
            this.lblWorking.Text = "Working...";
            this.lblWorking.Visible = false;
            // 
            // gvCheck
            // 
            this.gvCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gvCheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCheck.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCheck.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvCheck.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCheck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LinkArchivo,
            this.TamanoArchivo,
            this.ExtensionArchivo,
            this.NombreArchivo,
            this.FechaArchivo,
            this.AtributosArchivo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCheck.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCheck.Location = new System.Drawing.Point(12, 234);
            this.gvCheck.MultiSelect = true;
            this.gvCheck.Name = "gvCheck";
            this.gvCheck.ReadOnly = true;
            this.gvCheck.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCheck.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvCheck.RowHeadersVisible = true;
            this.gvCheck.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gvCheck.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCheck.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCheck.ShowCellErrors = false;
            this.gvCheck.ShowCellToolTips = false;
            this.gvCheck.ShowEditingIcon = false;
            this.gvCheck.ShowRowErrors = false;
            this.gvCheck.Size = new System.Drawing.Size(1044, 178);
            this.gvCheck.TabIndex = 0;
            this.gvCheck.VerticalScrollBarValue = 0;
            // 
            // LinkArchivo
            // 
            this.LinkArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LinkArchivo.DataPropertyName = "LinkArchivo";
            this.LinkArchivo.FillWeight = 200F;
            this.LinkArchivo.HeaderText = "Link";
            this.LinkArchivo.Name = "LinkArchivo";
            this.LinkArchivo.ReadOnly = true;
            this.LinkArchivo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LinkArchivo.ToolTipText = "LinkArchivo";
            // 
            // TamanoArchivo
            // 
            this.TamanoArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TamanoArchivo.DataPropertyName = "TamanoArchivo";
            this.TamanoArchivo.FillWeight = 40F;
            this.TamanoArchivo.HeaderText = "Size";
            this.TamanoArchivo.Name = "TamanoArchivo";
            this.TamanoArchivo.ReadOnly = true;
            this.TamanoArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TamanoArchivo.ToolTipText = "TamanoArchivo";
            // 
            // ExtensionArchivo
            // 
            this.ExtensionArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExtensionArchivo.DataPropertyName = "ExtensionArchivo";
            this.ExtensionArchivo.FillWeight = 20F;
            this.ExtensionArchivo.HeaderText = "Extension";
            this.ExtensionArchivo.Name = "ExtensionArchivo";
            this.ExtensionArchivo.ReadOnly = true;
            this.ExtensionArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExtensionArchivo.ToolTipText = "ExtensionArchivo";
            this.ExtensionArchivo.Visible = false;
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreArchivo.DataPropertyName = "NombreArchivo";
            this.NombreArchivo.FillWeight = 127.1574F;
            this.NombreArchivo.HeaderText = "Name";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.ReadOnly = true;
            this.NombreArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NombreArchivo.ToolTipText = "NombreArchivo";
            this.NombreArchivo.Visible = false;
            // 
            // FechaArchivo
            // 
            this.FechaArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FechaArchivo.DataPropertyName = "FechaArchivo";
            this.FechaArchivo.HeaderText = "Date";
            this.FechaArchivo.Name = "FechaArchivo";
            this.FechaArchivo.ReadOnly = true;
            this.FechaArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaArchivo.ToolTipText = "FechaArchivo";
            this.FechaArchivo.Visible = false;
            // 
            // AtributosArchivo
            // 
            this.AtributosArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AtributosArchivo.DataPropertyName = "AtributosArchivo";
            this.AtributosArchivo.HeaderText = "Atrib";
            this.AtributosArchivo.Name = "AtributosArchivo";
            this.AtributosArchivo.ReadOnly = true;
            this.AtributosArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AtributosArchivo.ToolTipText = "AtributosArchivo";
            this.AtributosArchivo.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(558, 418);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(162, 37);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "Copy Files to...";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 467);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gSearchFile);
            this.Controls.Add(this.gSearchText);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.gvCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.gSearchText.ResumeLayout(false);
            this.gSearchText.PerformLayout();
            this.gSearchFile.ResumeLayout(false);
            this.gSearchFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public cDataGridView gvCheck;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btninternalSearch;
        private System.Windows.Forms.TextBox txtNameFile_SearchInternalFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInternalText;
        private System.Windows.Forms.GroupBox gSearchText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlExtension;
        private System.Windows.Forms.GroupBox gSearchFile;
        private System.Windows.Forms.Button btnFullSearch;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoIncludeText;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TamanoArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtensionArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AtributosArchivo;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserCopy;
    }
}