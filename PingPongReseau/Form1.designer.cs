namespace PingPongReseau
{
    partial class Form1
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
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServeurtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NomJoueur = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MultiPlayerToolStripMenuItem,
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.gameToolStripMenuItem.Text = "Jeux";
            // 
            // MultiPlayerToolStripMenuItem
            // 
            this.MultiPlayerToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.MultiPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServeurtoolStripMenuItem,
            this.ClientStripMenuItem});
            this.MultiPlayerToolStripMenuItem.Name = "MultiPlayerToolStripMenuItem";
            this.MultiPlayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.MultiPlayerToolStripMenuItem.Text = "Multijoueurs";
            // 
            // ServeurtoolStripMenuItem
            // 
            this.ServeurtoolStripMenuItem.Name = "ServeurtoolStripMenuItem";
            this.ServeurtoolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ServeurtoolStripMenuItem.Text = "Heberger partie";
            this.ServeurtoolStripMenuItem.Click += new System.EventHandler(this.ServeurtoolStripMenuItem_Click);
            // 
            // ClientStripMenuItem
            // 
            this.ClientStripMenuItem.Name = "ClientStripMenuItem";
            this.ClientStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ClientStripMenuItem.Text = "Rejoindre partie";
            this.ClientStripMenuItem.Click += new System.EventHandler(this.ClientStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "Local";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.normalToolStripMenuItem.Text = "Nouvelle partie";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Sortie";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.NomJoueur});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 23);
            // 
            // NomJoueur
            // 
            this.NomJoueur.Name = "NomJoueur";
            this.NomJoueur.Size = new System.Drawing.Size(100, 23);
            this.NomJoueur.Text = "VotreNom";
            // 
            // Form1
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(492, 342);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 320);
            this.Name = "Form1";
            this.Text = "Ping Pong ";
            this.SizeChanged += new System.EventHandler(this.ResizeEvent);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MultiPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServeurtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox NomJoueur;

    }
}

