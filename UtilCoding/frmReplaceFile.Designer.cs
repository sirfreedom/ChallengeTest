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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkChangeText = new System.Windows.Forms.CheckBox();
            this.chkChangeNameDirectory = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(218, 49);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.Size = new System.Drawing.Size(176, 22);
            this.txtOldValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Value";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(218, 79);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(176, 22);
            this.txtNewValue.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(511, 22);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path";
            // 
            // chkChangeText
            // 
            this.chkChangeText.AutoSize = true;
            this.chkChangeText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeText.Location = new System.Drawing.Point(218, 118);
            this.chkChangeText.Name = "chkChangeText";
            this.chkChangeText.Size = new System.Drawing.Size(102, 20);
            this.chkChangeText.TabIndex = 6;
            this.chkChangeText.Text = "Change Text";
            this.chkChangeText.UseVisualStyleBackColor = true;
            // 
            // chkChangeNameDirectory
            // 
            this.chkChangeNameDirectory.AutoSize = true;
            this.chkChangeNameDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeNameDirectory.Location = new System.Drawing.Point(150, 144);
            this.chkChangeNameDirectory.Name = "chkChangeNameDirectory";
            this.chkChangeNameDirectory.Size = new System.Drawing.Size(170, 20);
            this.chkChangeNameDirectory.TabIndex = 7;
            this.chkChangeNameDirectory.Text = "Change Name Directory";
            this.chkChangeNameDirectory.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(417, 199);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(146, 67);
            this.btnChange.TabIndex = 8;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // frmReplaceFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 278);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.chkChangeNameDirectory);
            this.Controls.Add(this.chkChangeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldValue);
            this.Name = "frmReplaceFile";
            this.Text = "Reeplace File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkChangeText;
        private System.Windows.Forms.CheckBox chkChangeNameDirectory;
        private System.Windows.Forms.Button btnChange;
    }
}