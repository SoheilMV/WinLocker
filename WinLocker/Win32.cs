using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinLocker
{
    //https://stackoverflow.com/questions/62966320/setforegroundwindow-not-setting-focus
    //https://stackoverflow.com/questions/53706056/how-to-activate-window-started-by-another-process
    internal static class Win32
    {
        private static IntPtr _handle = IntPtr.Zero;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        private static extern IntPtr SetActiveWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsZoomed(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);


        public static IntPtr MainWindowHandle => _handle == IntPtr.Zero ? Process.GetCurrentProcess().MainWindowHandle : _handle;
        public static uint CurrentThreadId => GetCurrentThreadId();
        public static bool IsMaximized => IsZoomed(MainWindowHandle) != 0;
        public static bool IsMinimized => IsIconic(MainWindowHandle) != 0;
        public static bool IsEnabled => IsWindowEnabled(MainWindowHandle) != 0;
        public static bool IsVisible => IsWindowVisible(MainWindowHandle) != 0;
        public static bool IsForegroundMainWindow => GetForegroundWindow() == MainWindowHandle;


        public static (uint ThreadId, uint ProcessId) GetWindowThreadProcessId()
        {
            uint processId;
            uint threadId = GetWindowThreadProcessId(MainWindowHandle, out processId);
            return (threadId, processId);
        }

        public static (uint ThreadId, uint ProcessId) GetWindowThreadProcessId(IntPtr windowHandle)
        {
            uint processId;
            uint threadId = GetWindowThreadProcessId(windowHandle, out processId);
            return (threadId, processId);
        }

        public static void SwitchWindow(IntPtr windowHandle)
        {
            IntPtr foregroundWindowHandle = GetForegroundWindow();
            var foregroundIds = GetWindowThreadProcessId(foregroundWindowHandle);
            AttachThreadInput(CurrentThreadId, foregroundIds.ThreadId, true);
            SetForegroundWindow(windowHandle);
            SetActiveWindow(windowHandle);
            AttachThreadInput(CurrentThreadId, foregroundIds.ThreadId, false);
        }

        public static void ShowWindow(ShowWindowCommands command)
        {
            int nCmdShow = (int)command;
            ShowWindow(MainWindowHandle, nCmdShow);
        }

        public static void ShowWindow(IntPtr windowHandle, ShowWindowCommands command)
        {
            int nCmdShow = (int)command;
            ShowWindow(windowHandle, nCmdShow);
        }

        public static void SetWndowHandle(IntPtr windowHandle)
        {
            _handle = windowHandle;
        }
    }

    public enum ShowWindowCommands : int
    {
        /// <summary>
        /// [SW_HIDE] Hides the window and activates another window.
        /// </summary>
        Hide = 0,

        /// <summary>
        /// [SW_SHOWNORMAL] Activates and displays a window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        ShowNormal = 1,

        /// <summary>
        /// [SW_NORMAL] Activates and displays a window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// [SW_SHOWMINIMIZED] Activates the window and displays it as a minimized window.
        /// </summary>
        ShowMinimized = 2,

        /// <summary>
        /// [SW_SHOWMAXIMIZED] Activates the window and displays it as a maximized window.
        /// </summary>
        ShowMaximized = 3,

        /// <summary>
        /// [SW_MAXIMIZE] Activates the window and displays it as a maximized window.
        /// </summary>
        Maximize = 3,

        /// <summary>
        /// [SW_SHOWNOACTIVATE] Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
        /// </summary>
        ShowNoActivate = 4,

        /// <summary>
        /// [SW_SHOW] Activates the window and displays it in its current size and position.
        /// </summary>
        Show = 5,

        /// <summary>
        /// [SW_MINIMIZE] Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        Minimize = 6,

        /// <summary>
        /// [SW_SHOWMINNOACTIVE] Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
        /// </summary>
        ShowMinNoActive = 7,

        /// <summary>
        /// [SW_SHOWNA] Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
        /// </summary>
        ShowNA = 8,

        /// <summary>
        /// [SW_RESTORE] Activates and displays the window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
        /// </summary>
        Restore = 9,

        /// <summary>
        /// [SW_SHOWDEFAULT] Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
        /// </summary>
        ShowDefault = 10,

        /// <summary>
        /// [SW_FORCEMINIMIZE] Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        ForceMinimize = 11
    }
}
