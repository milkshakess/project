namespace PingPongReseau
{
    partial class login
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
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tBPasswd = new System.Windows.Forms.TextBox();
            this.lbUserID = new System.Windows.Forms.Label();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(101, 19);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(142, 20);
            this.tbUserID.TabIndex = 0;
            // 
            // tBPasswd
            // 
            this.tBPasswd.Location = new System.Drawing.Point(101, 65);
            this.tBPasswd.Name = "tBPasswd";
            this.tBPasswd.PasswordChar = '*';
            this.tBPasswd.Size = new System.Drawing.Size(142, 20);
            this.tBPasswd.TabIndex = 1;
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(28, 25);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(40, 13);
            this.lbUserID.TabIndex = 2;
            this.lbUserID.Text = "UserID";
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Location = new System.Drawing.Point(28, 68);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(44, 13);
            this.lbPasswd.TabIndex = 3;
            this.lbPasswd.Text = "Passwd";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(197, 129);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(103, 129);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(31, 97);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(176, 13);
            this.lbError.TabIndex = 6;
            this.lbError.Text = "Utilisateur/mot de passe incorrectes";
            this.lbError.Visible = false;
            // 
            // login
            // 
            this.AcceptButton = this.btLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.lbPasswd);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.tBPasswd);
            this.Controls.Add(this.tbUserID);
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tBPasswd;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label lbPasswd;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label lbError;
    }
}