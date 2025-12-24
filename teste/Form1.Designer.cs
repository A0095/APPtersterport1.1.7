namespace teste
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.txtip = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.txtResponseTime = new System.Windows.Forms.TextBox();
            this.tmpinter = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.txtlog = new System.Windows.Forms.RichTextBox();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genererLeRapportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commissioningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(15, 136);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnstop
            // 
            this.btnstop.AutoSize = true;
            this.btnstop.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnstop.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnstop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnstop.Location = new System.Drawing.Point(15, 179);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(93, 25);
            this.btnstop.TabIndex = 1;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = false;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // txtip
            // 
            this.txtip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtip.BackColor = System.Drawing.Color.LightYellow;
            this.txtip.Location = new System.Drawing.Point(114, 36);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(163, 20);
            this.txtip.TabIndex = 3;
            this.txtip.Enter += new System.EventHandler(this.txtip_Enter);
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.LightYellow;
            this.txtPort.Location = new System.Drawing.Point(114, 72);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(163, 20);
            this.txtPort.TabIndex = 4;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Numero de port ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ip Serveur APP";
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.BackColor = System.Drawing.SystemColors.Info;
            this.txtSend.Location = new System.Drawing.Point(358, 55);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(483, 195);
            this.txtSend.TabIndex = 10;
            this.txtSend.Text = "";
            // 
            // txtResponseTime
            // 
            this.txtResponseTime.BackColor = System.Drawing.Color.LightYellow;
            this.txtResponseTime.Location = new System.Drawing.Point(114, 107);
            this.txtResponseTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtResponseTime.Name = "txtResponseTime";
            this.txtResponseTime.Size = new System.Drawing.Size(163, 20);
            this.txtResponseTime.TabIndex = 8;
            // 
            // tmpinter
            // 
            this.tmpinter.BackColor = System.Drawing.Color.Lavender;
            this.tmpinter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tmpinter.Location = new System.Drawing.Point(12, 107);
            this.tmpinter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tmpinter.Name = "tmpinter";
            this.tmpinter.Size = new System.Drawing.Size(96, 20);
            this.tmpinter.TabIndex = 9;
            this.tmpinter.Text = "Answer time";
            // 
            // txtReceive
            // 
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.BackColor = System.Drawing.SystemColors.Info;
            this.txtReceive.Location = new System.Drawing.Point(358, 275);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(483, 223);
            this.txtReceive.TabIndex = 10;
            this.txtReceive.Text = "";
            // 
            // txtlog
            // 
            this.txtlog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtlog.BackColor = System.Drawing.SystemColors.Info;
            this.txtlog.Location = new System.Drawing.Point(14, 219);
            this.txtlog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtlog.Name = "txtlog";
            this.txtlog.Size = new System.Drawing.Size(308, 278);
            this.txtlog.TabIndex = 11;
            this.txtlog.Text = "";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(69, 26);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genererLeRapportToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.logToolStripMenuItem.Text = "log";
            // 
            // genererLeRapportToolStripMenuItem
            // 
            this.genererLeRapportToolStripMenuItem.Name = "genererLeRapportToolStripMenuItem";
            this.genererLeRapportToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.genererLeRapportToolStripMenuItem.Text = "generer le rapport ";
            this.genererLeRapportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.debugToolStripMenuItem.Text = "debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commissioningToolStripMenuItem,
            this.lectureToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // commissioningToolStripMenuItem
            // 
            this.commissioningToolStripMenuItem.Name = "commissioningToolStripMenuItem";
            this.commissioningToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.commissioningToolStripMenuItem.Text = "Commissioning";
            // 
            // lectureToolStripMenuItem
            // 
            this.lectureToolStripMenuItem.Name = "lectureToolStripMenuItem";
            this.lectureToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.lectureToolStripMenuItem.Text = "Lecture";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(873, 544);
            this.Controls.Add(this.txtlog);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.tmpinter);
            this.Controls.Add(this.txtResponseTime);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtip);
            this.Controls.Add(this.btnstop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.TextBox txtResponseTime;
        private System.Windows.Forms.Label tmpinter;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.RichTextBox txtlog;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genererLeRapportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commissioningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lectureToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

