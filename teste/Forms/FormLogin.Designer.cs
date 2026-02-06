namespace teste.forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frecnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commissioningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnTestLoop = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.verisonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frecnhToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.germanToolStripMenuItem,
            this.spanishToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // frecnhToolStripMenuItem
            // 
            this.frecnhToolStripMenuItem.Image = global::teste.Properties.Resources.flagFR;
            this.frecnhToolStripMenuItem.Name = "frecnhToolStripMenuItem";
            this.frecnhToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.frecnhToolStripMenuItem.Text = "Frecnh";
            this.frecnhToolStripMenuItem.Click += new System.EventHandler(this.frecnhToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Image = global::teste.Properties.Resources.flagEN;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Image = global::teste.Properties.Resources.flagDE;
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            this.germanToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.germanToolStripMenuItem.Text = "German";
            this.germanToolStripMenuItem.Click += new System.EventHandler(this.germanToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("spanishToolStripMenuItem.Image")));
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.spanishToolStripMenuItem.Text = "Spanish";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commissioningToolStripMenuItem,
            this.lectureToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // commissioningToolStripMenuItem
            // 
            this.commissioningToolStripMenuItem.Name = "commissioningToolStripMenuItem";
            this.commissioningToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.commissioningToolStripMenuItem.Text = "Commissioning";
            this.commissioningToolStripMenuItem.Click += new System.EventHandler(this.commissioningToolStripMenuItem_Click);
            // 
            // lectureToolStripMenuItem
            // 
            this.lectureToolStripMenuItem.Name = "lectureToolStripMenuItem";
            this.lectureToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.lectureToolStripMenuItem.Text = "Lecture";
            // 
            // verisonToolStripMenuItem
            // 
            this.verisonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.verisonToolStripMenuItem.Name = "verisonToolStripMenuItem";
            this.verisonToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.verisonToolStripMenuItem.Text = "About";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(12, 246);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(115, 33);
            this.btnLog.TabIndex = 15;
            this.btnLog.Text = "&Log Publisher";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Visible = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnTestLoop
            // 
            this.btnTestLoop.Location = new System.Drawing.Point(12, 207);
            this.btnTestLoop.Name = "btnTestLoop";
            this.btnTestLoop.Size = new System.Drawing.Size(115, 33);
            this.btnTestLoop.TabIndex = 16;
            this.btnTestLoop.Text = "&Test Loop";
            this.btnTestLoop.UseVisualStyleBackColor = true;
            this.btnTestLoop.Visible = false;
            this.btnTestLoop.Click += new System.EventHandler(this.btnTestLoop_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.Location = new System.Drawing.Point(12, 285);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(115, 33);
            this.btnClosed.TabIndex = 17;
            this.btnClosed.Text = "&Exit Software";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Visible = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::teste.Properties.Resources.ASCAI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(986, 633);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnTestLoop);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Login ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commissioningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lectureToolStripMenuItem;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnTestLoop;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.ToolStripMenuItem verisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frecnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
    }
}