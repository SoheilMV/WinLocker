using System.Diagnostics;
using System.Drawing.Imaging;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace WinLocker
{
    internal class Utility
    {
        public static Bitmap CaptureScreen()
        {
            using (Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(screen))
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, screen.Size);
                }
                Bitmap newBitmap = new Bitmap(screen.Width, screen.Height);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    ImageAttributes attributes = new ImageAttributes();
                    g.DrawImage(screen, new Rectangle(0, 0, screen.Width, screen.Height), 0, 0, screen.Width, screen.Height, GraphicsUnit.Pixel, attributes);
                }
                return newBitmap;
            }
        }

        public static byte[] CaptureScreen(ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(screen))
                    {
                        graphics.CopyFromScreen(0, 0, 0, 0, screen.Size);
                    }
                    using (Bitmap newBitmap = new Bitmap(screen.Width, screen.Height))
                    {
                        using (Graphics g = Graphics.FromImage(newBitmap))
                        {
                            ImageAttributes attributes = new ImageAttributes();
                            g.DrawImage(screen, new Rectangle(0, 0, screen.Width, screen.Height), 0, 0, screen.Width, screen.Height, GraphicsUnit.Pixel, attributes);
                        }
                        newBitmap.Save(ms, format);
                        return ms.ToArray();
                    }
                }
            }
        }

        public static bool IsRunAsAdmin()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        public static bool OpenUrl(string url)
        {
            Process? p = null;
            bool success = true;
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.OSDescription.Contains("microsoft-standard");
            try
            {
                p = Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = isWindows
                });
            }
            catch
            {
                if (isWindows)
                {
                    url = url.Replace("&", "^&");
                    try
                    {
                        p = Process.Start(new ProcessStartInfo("cmd.exe", "/c start " + url)
                        {
                            CreateNoWindow = true
                        });
                    }
                    catch
                    {
                        success = false;
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    p = Process.Start("xdg-open", url);
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    p = Process.Start("open", url);
                else
                    success = false;
            }
            p?.Dispose();
            return success;
        }
    }
}
