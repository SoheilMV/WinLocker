using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLocker
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkLock.Checked = Registries.LockIsDisable();
            chkSwitchUser.Checked = Registries.SwitchUserIsDisable();
            chkSignOut.Checked = Registries.SignOutIsDisable();
            chkChangePassword.Checked = Registries.ChangePasswordIsDisable();
            chkTaskManager.Checked = Registries.TaskManagerIsDisable();
        }

        private void btnAccountSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtRepassword.Text.Trim()))
            {
                if (txtPassword.Text.Trim().Equals(txtRepassword.Text.Trim()))
                {
                    Account.Save(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    this.Close();
                }
                else
                    MessageBox.Show("The password is not the same as the re-password!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Username or password cannot be empty!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked && chkAll.CheckState == CheckState.Checked)
            {
                chkLock.Checked = true;
                if(Utility.IsRunAsAdmin())
                    chkSwitchUser.Checked = true;
                chkSignOut.Checked = true;
                chkChangePassword.Checked = true;
                chkTaskManager.Checked = true;
            }
            else if(!chkAll.Checked && chkAll.CheckState == CheckState.Unchecked)
            {
                chkLock.Checked = false;
                if (Utility.IsRunAsAdmin())
                    chkSwitchUser.Checked = false;
                chkSignOut.Checked = false;
                chkChangePassword.Checked = false;
                chkTaskManager.Checked = false;
            }
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLock.Checked)
                Registries.DisableLock(true);
            else
                Registries.DisableLock(false);

            CheckAll();
        }

        private void chkSwitchUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Utility.IsRunAsAdmin())
            {
                if (chkSwitchUser.Checked)
                    Registries.DisableSwitchUser(true);
                else
                    Registries.DisableSwitchUser(false);
            }
            else
                chkSwitchUser.Checked = false;
            CheckAll();
        }

        private void chkSignOut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSignOut.Checked)
                Registries.DisableSignOut(true);
            else
                Registries.DisableSignOut(false);

            CheckAll();
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangePassword.Checked)
                Registries.DisableChangePassword(true);
            else
                Registries.DisableChangePassword(false);

            CheckAll();
        }

        private void chkTaskManager_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaskManager.Checked)
                Registries.DisableTaskManager(true);
            else
                Registries.DisableTaskManager(false);

            CheckAll();
        }

        private void CheckAll()
        {
            if (chkLock.Checked && chkSwitchUser.Checked && chkSignOut.Checked && chkChangePassword.Checked && chkTaskManager.Checked)
                chkAll.CheckState = CheckState.Checked;
            else if (!chkLock.Checked && !chkSwitchUser.Checked && !chkSignOut.Checked && !chkChangePassword.Checked && !chkTaskManager.Checked)
                chkAll.CheckState = CheckState.Unchecked;
            else
                chkAll.CheckState = CheckState.Indeterminate;
        }
    }
}
