namespace teste.Forms
{
    partial class AsMessageBoxDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblMessage__NT = new System.Windows.Forms.Label();
            this.buttonBar = new teste.Forms.MessageBoxButtonBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.picIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage__NT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBar, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picIcon
            // 
            this.picIcon.Image = global::teste.Properties.Resources.dialog_information;
            this.picIcon.Location = new System.Drawing.Point(3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(120, 120);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblMessage__NT
            // 
            this.lblMessage__NT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage__NT.AutoSize = true;
            this.lblMessage__NT.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMessage__NT.Location = new System.Drawing.Point(129, 0);
            this.lblMessage__NT.Name = "lblMessage__NT";
            this.lblMessage__NT.Padding = new System.Windows.Forms.Padding(10);
            this.lblMessage__NT.Size = new System.Drawing.Size(279, 126);
            this.lblMessage__NT.TabIndex = 1;
            this.lblMessage__NT.Text = "this is an importent text";
            // 
            // buttonBar
            // 
            this.buttonBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBar.AutoSize = true;
            this.buttonBar.Buttons = System.Windows.Forms.MessageBoxButtons.OK;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonBar, 2);
            this.buttonBar.Location = new System.Drawing.Point(280, 129);
            this.buttonBar.Name = "buttonBar";
            this.buttonBar.Size = new System.Drawing.Size(128, 50);
            this.buttonBar.TabIndex = 2;
            // 
            // AsMessageBoxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(411, 182);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AsMessageBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblMessage__NT;
        private MessageBoxButtonBar buttonBar;
    }
}