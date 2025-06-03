namespace UtilCoding
{
    partial class frmReplaceFile
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
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkChangeText = new System.Windows.Forms.CheckBox();
            this.chkChangeNameDirectory = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOldValue
            // 
            this.txtOldValue.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldValue.Location = new System.Drawing.Point(164, 40);
            this.txtOldValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.Size = new System.Drawing.Size(227, 23);
            this.txtOldValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Value";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewValue.Location = new System.Drawing.Point(164, 65);
            this.txtNewValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(227, 23);
            this.txtNewValue.TabIndex = 2;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(48, 10);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(384, 20);
            this.txtPath.TabIndex = 4;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path";
            // 
            // chkChangeText
            // 
            this.chkChangeText.AutoSize = true;
            this.chkChangeText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeText.Location = new System.Drawing.Point(163, 121);
            this.chkChangeText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkChangeText.Name = "chkChangeText";
            this.chkChangeText.Size = new System.Drawing.Size(87, 17);
            this.chkChangeText.TabIndex = 6;
            this.chkChangeText.Text = "Change Text";
            this.chkChangeText.UseVisualStyleBackColor = true;
            // 
            // chkChangeNameDirectory
            // 
            this.chkChangeNameDirectory.AutoSize = true;
            this.chkChangeNameDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeNameDirectory.Location = new System.Drawing.Point(111, 142);
            this.chkChangeNameDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkChangeNameDirectory.Name = "chkChangeNameDirectory";
            this.chkChangeNameDirectory.Size = new System.Drawing.Size(139, 17);
            this.chkChangeNameDirectory.TabIndex = 7;
            this.chkChangeNameDirectory.Text = "Change Name Directory";
            this.chkChangeNameDirectory.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(319, 161);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(110, 54);
            this.btnChange.TabIndex = 8;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(242, 191);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 24);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtExtension
            // 
            this.txtExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtension.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtension.Location = new System.Drawing.Point(163, 90);
            this.txtExtension.Margin = new System.Windows.Forms.Padding(2);
            this.txtExtension.MaxLength = 3;
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(64, 23);
            this.txtExtension.TabIndex = 10;
            this.txtExtension.Text = "*";
            // 
            // frmReplaceFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 226);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.chkChangeNameDirectory);
            this.Controls.Add(this.chkChangeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmReplaceFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reeplace File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkChangeText;
        private System.Windows.Forms.CheckBox chkChangeNameDirectory;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtExtension;
    }
}