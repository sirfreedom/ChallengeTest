
namespace UtilCoding
{
    partial class frmSpliter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpliter));
            this.txtFinish = new System.Windows.Forms.TextBox();
            this.txtIni = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCleanChecks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkItemShow = new System.Windows.Forms.CheckedListBox();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.ddlSplitNumber = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSplitCaracter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.txtReplace3a = new System.Windows.Forms.TextBox();
            this.txtReplace2a = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReplace1a = new System.Windows.Forms.TextBox();
            this.txtReplace1b = new System.Windows.Forms.TextBox();
            this.txtReplace2b = new System.Windows.Forms.TextBox();
            this.txtReplace3b = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlSpliter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnSaveCode = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFinish
            // 
            this.txtFinish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinish.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtFinish.Location = new System.Drawing.Point(620, 122);
            this.txtFinish.Multiline = true;
            this.txtFinish.Name = "txtFinish";
            this.txtFinish.ReadOnly = true;
            this.txtFinish.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFinish.Size = new System.Drawing.Size(497, 467);
            this.txtFinish.TabIndex = 6;
            // 
            // txtIni
            // 
            this.txtIni.AcceptsReturn = true;
            this.txtIni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIni.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtIni.Location = new System.Drawing.Point(12, 165);
            this.txtIni.Multiline = true;
            this.txtIni.Name = "txtIni";
            this.txtIni.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIni.Size = new System.Drawing.Size(602, 424);
            this.txtIni.TabIndex = 5;
            this.txtIni.TextChanged += new System.EventHandler(this.txtIni_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCleanChecks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkItemShow);
            this.groupBox1.Controls.Add(this.btnSelectItem);
            this.groupBox1.Controls.Add(this.ddlSplitNumber);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSplitCaracter);
            this.groupBox1.Location = new System.Drawing.Point(471, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 104);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spliter Configuration";
            // 
            // btnCleanChecks
            // 
            this.btnCleanChecks.Location = new System.Drawing.Point(461, 62);
            this.btnCleanChecks.Name = "btnCleanChecks";
            this.btnCleanChecks.Size = new System.Drawing.Size(60, 19);
            this.btnCleanChecks.TabIndex = 42;
            this.btnCleanChecks.Text = "Clean";
            this.btnCleanChecks.UseVisualStyleBackColor = true;
            this.btnCleanChecks.Click += new System.EventHandler(this.btnCleanChecks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Order Split List";
            // 
            // chkItemShow
            // 
            this.chkItemShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkItemShow.CheckOnClick = true;
            this.chkItemShow.Enabled = false;
            this.chkItemShow.FormattingEnabled = true;
            this.chkItemShow.Location = new System.Drawing.Point(400, 17);
            this.chkItemShow.Name = "chkItemShow";
            this.chkItemShow.Size = new System.Drawing.Size(55, 62);
            this.chkItemShow.TabIndex = 41;
            this.chkItemShow.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkItemShow_ItemCheck);
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.Location = new System.Drawing.Point(207, 58);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(93, 21);
            this.btnSelectItem.TabIndex = 40;
            this.btnSelectItem.Text = "Add Item Show";
            this.btnSelectItem.UseVisualStyleBackColor = true;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // ddlSplitNumber
            // 
            this.ddlSplitNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSplitNumber.Enabled = false;
            this.ddlSplitNumber.Font = new System.Drawing.Font("Verdana", 9F);
            this.ddlSplitNumber.FormattingEnabled = true;
            this.ddlSplitNumber.Location = new System.Drawing.Point(81, 58);
            this.ddlSplitNumber.Name = "ddlSplitNumber";
            this.ddlSplitNumber.Size = new System.Drawing.Size(120, 22);
            this.ddlSplitNumber.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Split Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Split Caracter";
            // 
            // txtSplitCaracter
            // 
            this.txtSplitCaracter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSplitCaracter.Location = new System.Drawing.Point(81, 32);
            this.txtSplitCaracter.MaxLength = 1;
            this.txtSplitCaracter.Name = "txtSplitCaracter";
            this.txtSplitCaracter.Size = new System.Drawing.Size(37, 20);
            this.txtSplitCaracter.TabIndex = 0;
            this.txtSplitCaracter.Text = " ";
            this.txtSplitCaracter.TextChanged += new System.EventHandler(this.txtSplitCaracter_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReplace);
            this.groupBox2.Controls.Add(this.txtReplace3a);
            this.groupBox2.Controls.Add(this.txtReplace2a);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtReplace1a);
            this.groupBox2.Controls.Add(this.txtReplace1b);
            this.groupBox2.Controls.Add(this.txtReplace2b);
            this.groupBox2.Controls.Add(this.txtReplace3b);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(1, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 104);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replace Configuration";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(380, 68);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // txtReplace3a
            // 
            this.txtReplace3a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace3a.Location = new System.Drawing.Point(25, 70);
            this.txtReplace3a.Name = "txtReplace3a";
            this.txtReplace3a.Size = new System.Drawing.Size(157, 20);
            this.txtReplace3a.TabIndex = 30;
            // 
            // txtReplace2a
            // 
            this.txtReplace2a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace2a.Location = new System.Drawing.Point(25, 45);
            this.txtReplace2a.Name = "txtReplace2a";
            this.txtReplace2a.Size = new System.Drawing.Size(157, 20);
            this.txtReplace2a.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "1";
            // 
            // txtReplace1a
            // 
            this.txtReplace1a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace1a.Location = new System.Drawing.Point(25, 19);
            this.txtReplace1a.Name = "txtReplace1a";
            this.txtReplace1a.Size = new System.Drawing.Size(157, 20);
            this.txtReplace1a.TabIndex = 27;
            // 
            // txtReplace1b
            // 
            this.txtReplace1b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace1b.Location = new System.Drawing.Point(188, 20);
            this.txtReplace1b.Name = "txtReplace1b";
            this.txtReplace1b.Size = new System.Drawing.Size(179, 20);
            this.txtReplace1b.TabIndex = 22;
            // 
            // txtReplace2b
            // 
            this.txtReplace2b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace2b.Location = new System.Drawing.Point(188, 46);
            this.txtReplace2b.Name = "txtReplace2b";
            this.txtReplace2b.Size = new System.Drawing.Size(179, 20);
            this.txtReplace2b.TabIndex = 23;
            // 
            // txtReplace3b
            // 
            this.txtReplace3b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace3b.Location = new System.Drawing.Point(188, 71);
            this.txtReplace3b.Name = "txtReplace3b";
            this.txtReplace3b.Size = new System.Drawing.Size(179, 20);
            this.txtReplace3b.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(8, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "3";
            // 
            // ddlSpliter
            // 
            this.ddlSpliter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSpliter.Font = new System.Drawing.Font("Verdana", 9F);
            this.ddlSpliter.FormattingEnabled = true;
            this.ddlSpliter.Location = new System.Drawing.Point(199, 137);
            this.ddlSpliter.Name = "ddlSpliter";
            this.ddlSpliter.Size = new System.Drawing.Size(203, 22);
            this.ddlSpliter.TabIndex = 15;
            this.ddlSpliter.SelectedIndexChanged += new System.EventHandler(this.ddlSpliter_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Select Code";
            // 
            // btnSplit
            // 
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(1009, 17);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(108, 50);
            this.btnSplit.TabIndex = 17;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveCode.Location = new System.Drawing.Point(514, 122);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(75, 37);
            this.btnSaveCode.TabIndex = 18;
            this.btnSaveCode.Text = "Save Code";
            this.btnSaveCode.UseVisualStyleBackColor = true;
            this.btnSaveCode.Click += new System.EventHandler(this.btnSaveCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(1009, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 46);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSpliter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1122, 600);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveCode);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ddlSpliter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFinish);
            this.Controls.Add(this.txtIni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpliter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spliter";
            this.Load += new System.EventHandler(this.frmSpliter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFinish;
        private System.Windows.Forms.TextBox txtIni;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtReplace3a;
        private System.Windows.Forms.TextBox txtReplace2a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReplace1a;
        private System.Windows.Forms.TextBox txtReplace1b;
        private System.Windows.Forms.TextBox txtReplace2b;
        private System.Windows.Forms.TextBox txtReplace3b;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSplitCaracter;
        private System.Windows.Forms.ComboBox ddlSpliter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlSplitNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.CheckedListBox chkItemShow;
        private System.Windows.Forms.Button btnCleanChecks;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnSaveCode;
        private System.Windows.Forms.Button btnClose;
    }
}