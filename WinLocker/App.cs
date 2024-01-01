namespace WinLocker
{
    public class App : ApplicationContext
    {
        private GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();
        private CancellationTokenSource _ctsSettings = new CancellationTokenSource();
        private CancellationTokenSource _ctsLocker = new CancellationTokenSource();

        public App(string[] args)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Account.Load();

            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Visible = true;
            trayIcon.Text = "WinLocker";
            trayIcon.Icon = Properties.Resources.icon;
            trayIcon.BalloonTipIcon = ToolTipIcon.Warning;
            trayIcon.ContextMenuStrip = new ContextMenuStrip()
            {
                Items = {
                    new ToolStripMenuItem("Settings", null, Settings, Keys.Control | Keys.Alt | Keys.S),
                    new ToolStripMenuItem("Desktop Locker", null, Locker, Keys.Control | Keys.Alt | Keys.L),
                    new ToolStripMenuItem("About", null, About),
                    new ToolStripMenuItem("Exit", null, Exit)
                }
            };
            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            _keyboardHook.KeyDown += _keyboardHook_KeyDown;
            _keyboardHook.Hook();
        }

        private void _keyboardHook_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.S))
            {
                Settings(sender, e);
                e.Handled = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.Alt | Keys.L))
            {
                Locker(sender, e);
                e.Handled = true;
            }
        }

        private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        {
            Settings(sender, e);
        }

        private void Settings(object? sender, EventArgs e)
        {
            if (_ctsSettings.IsCancellationRequested)
                return;
            _ctsSettings.Cancel();
            if (Account.HasAccount)
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
                if (login.IsLogin)
                    new frmSettings().ShowDialog();
            }
            else
            {
                new frmSettings().ShowDialog();
            }
            _ctsSettings = new CancellationTokenSource();
        }

        private void Locker(object? sender, EventArgs e)
        {
            if (_ctsLocker.IsCancellationRequested || _ctsSettings.IsCancellationRequested)
                return;
            else if (!Account.HasAccount)
            {
                MessageBox.Show("Please enter the settings and then try to lock again!", "WinLocker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ctsLocker.Cancel();
            new frmLocker().ShowDialog();
            _ctsLocker = new CancellationTokenSource();
        }

        private void About(object? sender, EventArgs e)
        {
            MessageBox.Show("Developed By Soheil MV", "WinLocker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Utility.OpenUrl("https://t.me/MVSoft_ir");
        }

        private void Exit(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the program?", "WinLocker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _keyboardHook.Unhook();
                Application.Exit();
            }
        }
    }
}
