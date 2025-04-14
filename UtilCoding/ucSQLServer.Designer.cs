namespace UtilCoding
{
    partial class ucSQLServer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opSQL2005 = new System.Windows.Forms.RadioButton();
            this.opSQL2000 = new System.Windows.Forms.RadioButton();
            this.opOracle = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gConection = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalRegistros = new System.Windows.Forms.TextBox();
            this.txtCantidadRegistrosPorArchivo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.opComa = new System.Windows.Forms.RadioButton();
            this.opPunto = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPathScript = new System.Windows.Forms.Button();
            this.txtPathScript = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCargando = new System.Windows.Forms.Label();
            this.WorkerSql = new System.ComponentModel.BackgroundWorker();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.btnCreateSP = new System.Windows.Forms.Button();
            this.btnUnselect = new System.Windows.Forms.Button();
            this.chkList = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkFind = new System.Windows.Forms.CheckBox();
            this.chkGet = new System.Windows.Forms.CheckBox();
            this.btnCreateClass = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkIncludePK = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBaseClass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gvTablesSQL = new cDataGridView();
            this.chkSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.gConection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opSQL2005);
            this.groupBox1.Controls.Add(this.opSQL2000);
            this.groupBox1.Controls.Add(this.opOracle);
            this.groupBox1.Location = new System.Drawing.Point(774, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 50);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // opSQL2005
            // 
            this.opSQL2005.AutoSize = true;
            this.opSQL2005.Checked = true;
            this.opSQL2005.Location = new System.Drawing.Point(245, 19);
            this.opSQL2005.Name = "opSQL2005";
            this.opSQL2005.Size = new System.Drawing.Size(147, 17);
            this.opSQL2005.TabIndex = 2;
            this.opSQL2005.TabStop = true;
            this.opSQL2005.Text = "Export to SQL 2005/2008";
            this.opSQL2005.UseVisualStyleBackColor = true;
            // 
            // opSQL2000
            // 
            this.opSQL2000.AutoSize = true;
            this.opSQL2000.Location = new System.Drawing.Point(124, 21);
            this.opSQL2000.Name = "opSQL2000";
            this.opSQL2000.Size = new System.Drawing.Size(115, 17);
            this.opSQL2000.TabIndex = 1;
            this.opSQL2000.Text = "Export to SQL2000";
            this.opSQL2000.UseVisualStyleBackColor = true;
            // 
            // opOracle
            // 
            this.opOracle.AutoSize = true;
            this.opOracle.Location = new System.Drawing.Point(16, 20);
            this.opOracle.Name = "opOracle";
            this.opOracle.Size = new System.Drawing.Size(101, 17);
            this.opOracle.TabIndex = 0;
            this.opOracle.Text = "Export to Oracle";
            this.opOracle.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(429, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(1082, 394);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 34);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gConection
            // 
            this.gConection.Controls.Add(this.label10);
            this.gConection.Controls.Add(this.label9);
            this.gConection.Controls.Add(this.txtTotalRegistros);
            this.gConection.Controls.Add(this.txtCantidadRegistrosPorArchivo);
            this.gConection.Controls.Add(this.label8);
            this.gConection.Controls.Add(this.opComa);
            this.gConection.Controls.Add(this.opPunto);
            this.gConection.Controls.Add(this.label7);
            this.gConection.Controls.Add(this.btnPathScript);
            this.gConection.Controls.Add(this.txtPathScript);
            this.gConection.Controls.Add(this.label6);
            this.gConection.Controls.Add(this.label5);
            this.gConection.Controls.Add(this.txtSchema);
            this.gConection.Controls.Add(this.txtServer);
            this.gConection.Controls.Add(this.label4);
            this.gConection.Controls.Add(this.chkIntegratedSecurity);
            this.gConection.Controls.Add(this.txtBase);
            this.gConection.Controls.Add(this.txtPassword);
            this.gConection.Controls.Add(this.txtUser);
            this.gConection.Controls.Add(this.btnGetTables);
            this.gConection.Controls.Add(this.label3);
            this.gConection.Controls.Add(this.label2);
            this.gConection.Controls.Add(this.label1);
            this.gConection.Location = new System.Drawing.Point(3, 3);
            this.gConection.Name = "gConection";
            this.gConection.Size = new System.Drawing.Size(420, 274);
            this.gConection.TabIndex = 7;
            this.gConection.TabStop = false;
            this.gConection.Text = "Conection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "( Opcional )";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Top  Rows :";
            // 
            // txtTotalRegistros
            // 
            this.txtTotalRegistros.Location = new System.Drawing.Point(178, 168);
            this.txtTotalRegistros.MaxLength = 9;
            this.txtTotalRegistros.Name = "txtTotalRegistros";
            this.txtTotalRegistros.Size = new System.Drawing.Size(144, 20);
            this.txtTotalRegistros.TabIndex = 19;
            // 
            // txtCantidadRegistrosPorArchivo
            // 
            this.txtCantidadRegistrosPorArchivo.Location = new System.Drawing.Point(178, 145);
            this.txtCantidadRegistrosPorArchivo.MaxLength = 9;
            this.txtCantidadRegistrosPorArchivo.Name = "txtCantidadRegistrosPorArchivo";
            this.txtCantidadRegistrosPorArchivo.Size = new System.Drawing.Size(144, 20);
            this.txtCantidadRegistrosPorArchivo.TabIndex = 18;
            this.txtCantidadRegistrosPorArchivo.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Rows per File : ";
            // 
            // opComa
            // 
            this.opComa.AutoSize = true;
            this.opComa.Location = new System.Drawing.Point(240, 193);
            this.opComa.Name = "opComa";
            this.opComa.Size = new System.Drawing.Size(60, 17);
            this.opComa.TabIndex = 16;
            this.opComa.Text = "Comma";
            this.opComa.UseVisualStyleBackColor = true;
            // 
            // opPunto
            // 
            this.opPunto.AutoSize = true;
            this.opPunto.Checked = true;
            this.opPunto.Location = new System.Drawing.Point(181, 193);
            this.opPunto.Name = "opPunto";
            this.opPunto.Size = new System.Drawing.Size(42, 17);
            this.opPunto.TabIndex = 12;
            this.opPunto.TabStop = true;
            this.opPunto.Text = "Dot";
            this.opPunto.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Decimal Separator :";
            // 
            // btnPathScript
            // 
            this.btnPathScript.Location = new System.Drawing.Point(283, 217);
            this.btnPathScript.Name = "btnPathScript";
            this.btnPathScript.Size = new System.Drawing.Size(43, 21);
            this.btnPathScript.TabIndex = 14;
            this.btnPathScript.Text = "Open";
            this.btnPathScript.UseVisualStyleBackColor = true;
            this.btnPathScript.Click += new System.EventHandler(this.btnPathScript_Click);
            // 
            // txtPathScript
            // 
            this.txtPathScript.Location = new System.Drawing.Point(112, 218);
            this.txtPathScript.Name = "txtPathScript";
            this.txtPathScript.ReadOnly = true;
            this.txtPathScript.Size = new System.Drawing.Size(164, 20);
            this.txtPathScript.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Directory Script :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Schema :";
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(179, 121);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(185, 20);
            this.txtSchema.TabIndex = 4;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(179, 97);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(185, 20);
            this.txtServer.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Server :";
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIntegratedSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(159, 244);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(113, 17);
            this.chkIntegratedSecurity.TabIndex = 5;
            this.chkIntegratedSecurity.Text = "Integrated Security";
            this.chkIntegratedSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(179, 71);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(185, 20);
            this.txtBase.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(179, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(179, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 0;
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(278, 241);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(75, 23);
            this.btnGetTables.TabIndex = 6;
            this.btnGetTables.Text = "Get Tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Base :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User :";
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.ForeColor = System.Drawing.Color.Red;
            this.lblCargando.Location = new System.Drawing.Point(663, 368);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(105, 24);
            this.lblCargando.TabIndex = 6;
            this.lblCargando.Text = "Working...";
            this.lblCargando.Visible = false;
            // 
            // WorkerSql
            // 
            this.WorkerSql.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerSql_DoWork);
            this.WorkerSql.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerSql_RunWorkerCompleted);
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(653, 338);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(106, 27);
            this.btnSeleccionarTodos.TabIndex = 12;
            this.btnSeleccionarTodos.Text = "Select All Rows";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);
            // 
            // btnCreateSP
            // 
            this.btnCreateSP.Enabled = false;
            this.btnCreateSP.Location = new System.Drawing.Point(973, 394);
            this.btnCreateSP.Name = "btnCreateSP";
            this.btnCreateSP.Size = new System.Drawing.Size(103, 34);
            this.btnCreateSP.TabIndex = 13;
            this.btnCreateSP.Text = "Create SP";
            this.btnCreateSP.UseVisualStyleBackColor = true;
            this.btnCreateSP.Click += new System.EventHandler(this.btnCreateSP_Click);
            // 
            // btnUnselect
            // 
            this.btnUnselect.Location = new System.Drawing.Point(541, 338);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(106, 27);
            this.btnUnselect.TabIndex = 14;
            this.btnUnselect.Text = "UnSelect Rows";
            this.btnUnselect.UseVisualStyleBackColor = true;
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // chkList
            // 
            this.chkList.AutoSize = true;
            this.chkList.Checked = true;
            this.chkList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkList.Enabled = false;
            this.chkList.Location = new System.Drawing.Point(27, 20);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(42, 17);
            this.chkList.TabIndex = 15;
            this.chkList.Text = "List";
            this.chkList.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkInsert);
            this.groupBox2.Controls.Add(this.chkDelete);
            this.groupBox2.Controls.Add(this.chkUpdate);
            this.groupBox2.Controls.Add(this.chkList);
            this.groupBox2.Controls.Add(this.chkFind);
            this.groupBox2.Controls.Add(this.chkGet);
            this.groupBox2.Location = new System.Drawing.Point(3, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 50);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export SP";
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Checked = true;
            this.chkInsert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsert.Location = new System.Drawing.Point(243, 21);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(52, 17);
            this.chkInsert.TabIndex = 21;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(307, 21);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 20;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(176, 22);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 19;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkFind
            // 
            this.chkFind.AutoSize = true;
            this.chkFind.Checked = true;
            this.chkFind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFind.Location = new System.Drawing.Point(126, 21);
            this.chkFind.Name = "chkFind";
            this.chkFind.Size = new System.Drawing.Size(46, 17);
            this.chkFind.TabIndex = 18;
            this.chkFind.Text = "Find";
            this.chkFind.UseVisualStyleBackColor = true;
            // 
            // chkGet
            // 
            this.chkGet.AutoSize = true;
            this.chkGet.Checked = true;
            this.chkGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGet.Location = new System.Drawing.Point(75, 21);
            this.chkGet.Name = "chkGet";
            this.chkGet.Size = new System.Drawing.Size(43, 17);
            this.chkGet.TabIndex = 17;
            this.chkGet.Text = "Get";
            this.chkGet.UseVisualStyleBackColor = true;
            // 
            // btnCreateClass
            // 
            this.btnCreateClass.Enabled = false;
            this.btnCreateClass.Location = new System.Drawing.Point(864, 394);
            this.btnCreateClass.Name = "btnCreateClass";
            this.btnCreateClass.Size = new System.Drawing.Size(103, 34);
            this.btnCreateClass.TabIndex = 17;
            this.btnCreateClass.Text = "Create Class with Properties";
            this.btnCreateClass.UseVisualStyleBackColor = true;
            this.btnCreateClass.Click += new System.EventHandler(this.btnCreateClass_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.chkIncludePK);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtBaseClass);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtNamespace);
            this.groupBox3.Location = new System.Drawing.Point(3, 339);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 102);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Class and Properties";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(168, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "( Include the pk field as a property )";
            // 
            // chkIncludePK
            // 
            this.chkIncludePK.AutoSize = true;
            this.chkIncludePK.Location = new System.Drawing.Point(96, 75);
            this.chkIncludePK.Name = "chkIncludePK";
            this.chkIncludePK.Size = new System.Drawing.Size(77, 17);
            this.chkIncludePK.TabIndex = 26;
            this.chkIncludePK.Text = "Include Pk";
            this.chkIncludePK.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Base class ? ";
            // 
            // txtBaseClass
            // 
            this.txtBaseClass.Location = new System.Drawing.Point(96, 45);
            this.txtBaseClass.Name = "txtBaseClass";
            this.txtBaseClass.Size = new System.Drawing.Size(268, 20);
            this.txtBaseClass.TabIndex = 24;
            this.txtBaseClass.Text = "MyBaseClass";
            this.txtBaseClass.Click += new System.EventHandler(this.txtBaseClass_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Namespace :";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(96, 19);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(268, 20);
            this.txtNamespace.TabIndex = 22;
            this.txtNamespace.Text = "MyNameSpace";
            this.txtNamespace.Click += new System.EventHandler(this.txtNamespace_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(755, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 34);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Save Configuration";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvTablesSQL
            // 
            this.gvTablesSQL.AllowUserToAddRows = true;
            this.gvTablesSQL.AllowUserToDeleteRows = true;
            this.gvTablesSQL.AllowUserToResizeColumns = false;
            this.gvTablesSQL.AllowUserToResizeRows = true;
            this.gvTablesSQL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gvTablesSQL.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvTablesSQL.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvTablesSQL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTablesSQL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTablesSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTablesSQL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSel,
            this.TableId,
            this.TableName,
            this.Relation});
            this.gvTablesSQL.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvTablesSQL.Location = new System.Drawing.Point(438, 13);
            this.gvTablesSQL.MultiSelect = true;
            this.gvTablesSQL.Name = "gvTablesSQL";
            this.gvTablesSQL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvTablesSQL.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTablesSQL.RowHeadersVisible = true;
            this.gvTablesSQL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gvTablesSQL.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTablesSQL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTablesSQL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTablesSQL.ShowCellErrors = false;
            this.gvTablesSQL.ShowCellToolTips = false;
            this.gvTablesSQL.ShowEditingIcon = false;
            this.gvTablesSQL.ShowRowErrors = false;
            this.gvTablesSQL.Size = new System.Drawing.Size(756, 317);
            this.gvTablesSQL.TabIndex = 8;
            this.gvTablesSQL.VerticalScrollBarValue = 0;
            // 
            // chkSel
            // 
            this.chkSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chkSel.FalseValue = "0";
            this.chkSel.FillWeight = 20F;
            this.chkSel.Frozen = true;
            this.chkSel.HeaderText = "";
            this.chkSel.IndeterminateValue = "0";
            this.chkSel.MinimumWidth = 6;
            this.chkSel.Name = "chkSel";
            this.chkSel.TrueValue = "1";
            this.chkSel.Width = 20;
            // 
            // TableId
            // 
            this.TableId.DataPropertyName = "TableId";
            this.TableId.HeaderText = "Id";
            this.TableId.MinimumWidth = 6;
            this.TableId.Name = "TableId";
            this.TableId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TableId.Visible = false;
            this.TableId.Width = 125;
            // 
            // TableName
            // 
            this.TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TableName.DataPropertyName = "TableName";
            this.TableName.FillWeight = 500F;
            this.TableName.HeaderText = "Name";
            this.TableName.MinimumWidth = 6;
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Relation
            // 
            this.Relation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Relation.DataPropertyName = "Relation";
            this.Relation.FillWeight = 70F;
            this.Relation.HeaderText = "Relation";
            this.Relation.MinimumWidth = 6;
            this.Relation.Name = "Relation";
            this.Relation.ReadOnly = true;
            this.Relation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Relation.Width = 77;
            // 
            // ucSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCreateClass);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnUnselect);
            this.Controls.Add(this.btnCreateSP);
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gvTablesSQL);
            this.Controls.Add(this.gConection);
            this.Controls.Add(this.lblCargando);
            this.Name = "ucSQLServer";
            this.Size = new System.Drawing.Size(1209, 451);
            this.Load += new System.EventHandler(this.ucSQLServer_Load);
            this.Leave += new System.EventHandler(this.ucSQLServer_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gConection.ResumeLayout(false);
            this.gConection.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablesSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opSQL2005;
        private System.Windows.Forms.RadioButton opSQL2000;
        private System.Windows.Forms.RadioButton opOracle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private cDataGridView gvTablesSQL;
        private System.Windows.Forms.GroupBox gConection;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCargando;
        private System.ComponentModel.BackgroundWorker WorkerSql;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPathScript;
        private System.Windows.Forms.TextBox txtPathScript;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton opComa;
        private System.Windows.Forms.RadioButton opPunto;
        private System.Windows.Forms.Button btnSeleccionarTodos;
        private System.Windows.Forms.TextBox txtCantidadRegistrosPorArchivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalRegistros;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCreateSP;
        private System.Windows.Forms.Button btnUnselect;
        private System.Windows.Forms.CheckBox chkList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkFind;
        private System.Windows.Forms.CheckBox chkGet;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.Button btnCreateClass;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBaseClass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.CheckBox chkIncludePK;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
    }
}
