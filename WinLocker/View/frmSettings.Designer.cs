namespace WinLocker
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAccountSave = new System.Windows.Forms.Button();
            this.txtRepassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.chkSwitchUser = new System.Windows.Forms.CheckBox();
            this.chkSignOut = new System.Windows.Forms.CheckBox();
            this.chkChangePassword = new System.Windows.Forms.CheckBox();
            this.chkTaskManager = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAccountSave);
            this.groupBox1.Controls.Add(this.txtRepassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Manager";
            // 
            // btnAccountSave
            // 
            this.btnAccountSave.Location = new System.Drawing.Point(6, 109);
            this.btnAccountSave.Name = "btnAccountSave";
            this.btnAccountSave.Size = new System.Drawing.Size(326, 23);
            this.btnAccountSave.TabIndex = 3;
            this.btnAccountSave.Text = "Save";
            this.btnAccountSave.UseVisualStyleBackColor = true;
            this.btnAccountSave.Click += new System.EventHandler(this.btnAccountSave_Click);
            // 
            // txtRepassword
            // 
            this.txtRepassword.Location = new System.Drawing.Point(93, 80);
            this.txtRepassword.Name = "txtRepassword";
            this.txtRepassword.Size = new System.Drawing.Size(239, 23);
            this.txtRepassword.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(239, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 23);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Re-password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 156);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(134, 19);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "Disable Ctrl+Alt+Del";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(185, 156);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(92, 19);
            this.chkLock.TabIndex = 5;
            this.chkLock.Text = "Disable Lock";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // chkSwitchUser
            // 
            this.chkSwitchUser.AutoSize = true;
            this.chkSwitchUser.Location = new System.Drawing.Point(12, 181);
            this.chkSwitchUser.Name = "chkSwitchUser";
            this.chkSwitchUser.Size = new System.Drawing.Size(128, 19);
            this.chkSwitchUser.TabIndex = 6;
            this.chkSwitchUser.Text = "Disable Switch User";
            this.chkSwitchUser.UseVisualStyleBackColor = true;
            this.chkSwitchUser.CheckedChanged += new System.EventHandler(this.chkSwitchUser_CheckedChanged);
            // 
            // chkSignOut
            // 
            this.chkSignOut.AutoSize = true;
            this.chkSignOut.Location = new System.Drawing.Point(185, 181);
            this.chkSignOut.Name = "chkSignOut";
            this.chkSignOut.Size = new System.Drawing.Size(113, 19);
            this.chkSignOut.TabIndex = 7;
            this.chkSignOut.Text = "Disable Sign Out";
            this.chkSignOut.UseVisualStyleBackColor = true;
            this.chkSignOut.CheckedChanged += new System.EventHandler(this.chkSignOut_CheckedChanged);
            // 
            // chkChangePassword
            // 
            this.chkChangePassword.AutoSize = true;
            this.chkChangePassword.Location = new System.Drawing.Point(12, 206);
            this.chkChangePassword.Name = "chkChangePassword";
            this.chkChangePassword.Size = new System.Drawing.Size(161, 19);
            this.chkChangePassword.TabIndex = 8;
            this.chkChangePassword.Text = "Disable Change Password";
            this.chkChangePassword.UseVisualStyleBackColor = true;
            this.chkChangePassword.CheckedChanged += new System.EventHandler(this.chkChangePassword_CheckedChanged);
            // 
            // chkTaskManager
            // 
            this.chkTaskManager.AutoSize = true;
            this.chkTaskManager.Location = new System.Drawing.Point(185, 206);
            this.chkTaskManager.Name = "chkTaskManager";
            this.chkTaskManager.Size = new System.Drawing.Size(139, 19);
            this.chkTaskManager.TabIndex = 9;
            this.chkTaskManager.Text = "Disable Task Manager";
            this.chkTaskManager.UseVisualStyleBackColor = true;
            this.chkTaskManager.CheckedChanged += new System.EventHandler(this.chkTaskManager_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 237);
            this.Controls.Add(this.chkChangePassword);
            this.Controls.Add(this.chkSignOut);
            this.Controls.Add(this.chkSwitchUser);
            this.Controls.Add(this.chkTaskManager);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtRepassword;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAccountSave;
        private CheckBox chkAll;
        private CheckBox chkLock;
        private CheckBox chkSwitchUser;
        private CheckBox chkSignOut;
        private CheckBox chkChangePassword;
        private CheckBox chkTaskManager;
    }
}