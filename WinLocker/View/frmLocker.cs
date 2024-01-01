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
    public partial class frmLocker : Form
    {
        private GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public frmLocker()
        {
            InitializeComponent();
        }

        private void frmLocker_Load(object sender, EventArgs e)
        {
            Win32.SetWndowHandle(this.Handle);
            //Explorer.Stop();
            Monitor.Start();
            _keyboardHook.KeyDown += Hook_KeyDown;
            _keyboardHook.Hook();
            Task.Factory.StartNew(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    await Activated();
                }
            }, _cts.Token);
        }

        private void Hook_KeyDown(object? sender, KeyEventArgs e)
        {
            bool AltShift = (e.KeyData == (Keys.LShiftKey | Keys.Alt)) || (e.KeyData == (Keys.RShiftKey | Keys.Alt));
            bool invalid = (e.Control || e.Alt || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin || e.KeyCode == Keys.End || e.KeyCode == Keys.Delete);
            if (!AltShift && invalid)
                e.Handled = true;
        }

        private new async Task Activated()
        {
            if (!Win32.IsMaximized)
                Win32.ShowWindow(Win32.MainWindowHandle, ShowWindowCommands.Maximize);

            if (!Win32.IsForegroundMainWindow)
                Win32.SwitchWindow(Win32.MainWindowHandle);

            await Task.Delay(10);
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == Account.Username && txtPassword.Text == Account.Password)
            {
                Monitor.Stop();
                //Explorer.Start();
                this.Close();
            }
            else
                lblStatus.Text = "The username or password is incorrect!";
        }

        private void frmLocker_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel();
            _keyboardHook.Unhook();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "-";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "-";
        }

        private void frmLocker_MouseDown(object sender, MouseEventArgs e)
        {
            //this.Opacity = 0.1;
        }

        private void frmLocker_MouseUp(object sender, MouseEventArgs e)
        {
            //this.Opacity = 1.0;
        }
    }
}
