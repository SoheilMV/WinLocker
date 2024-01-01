using Microsoft.Win32;

namespace WinLocker
{
    public class Registries
    {
        public static void DisableLock(bool disable)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    if (disable)
                        reg.SetValue("DisableLockWorkstation", "1", RegistryValueKind.DWord);
                    else
                        reg.SetValue("DisableLockWorkstation", "0", RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static bool LockIsDisable()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    object? obj = reg.GetValue("DisableLockWorkstation", "0");
                    return (obj != null) ? Convert.ToBoolean(obj) : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void DisableSwitchUser(bool disable)
        {
            try
            {
                using (RegistryKey reg = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    if (disable)
                        reg.SetValue("HideFastUserSwitching", "1", RegistryValueKind.DWord);
                    else
                        reg.SetValue("HideFastUserSwitching", "0", RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static bool SwitchUserIsDisable()
        {
            try
            {
                using (RegistryKey reg = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    object? obj = reg.GetValue("HideFastUserSwitching", "0");
                    return (obj != null) ? Convert.ToBoolean(obj) : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void DisableSignOut(bool disable)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer"))
                {
                    if (disable)
                        reg.SetValue("NoLogoff", "1", RegistryValueKind.DWord);
                    else
                        reg.SetValue("NoLogoff", "0", RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static bool SignOutIsDisable()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer"))
                {
                    object? obj = reg.GetValue("NoLogoff", "0");
                    return (obj != null) ? Convert.ToBoolean(obj) : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void DisableChangePassword(bool disable)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    if (disable)
                        reg.SetValue("DisableChangePassword", "1", RegistryValueKind.DWord);
                    else
                        reg.SetValue("DisableChangePassword", "0", RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static bool ChangePasswordIsDisable()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    object? obj = reg.GetValue("DisableChangePassword", "0");
                    return (obj != null) ? Convert.ToBoolean(obj) : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void DisableTaskManager(bool disable)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    if (disable)
                        reg.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                    else
                        reg.SetValue("DisableTaskMgr", "0", RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static bool TaskManagerIsDisable()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    object? obj = reg.GetValue("DisableTaskMgr", "0");
                    return (obj != null) ? Convert.ToBoolean(obj) : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void EnableStartup(bool enable)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"))
                {
                    if (enable)
                        reg.SetValue("WinLocker", Application.ExecutablePath);
                    else
                        reg.DeleteValue("WinLocker");
                }
            }
            catch { }
        }

        //public static void DisableLUA(bool disable)
        //{
        //    try
        //    {
        //        using (RegistryKey reg = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
        //        {
        //            if (disable)
        //            {
        //                reg.SetValue("EnableLUA", "0", RegistryValueKind.DWord);
        //                reg.SetValue("ConsentPromptBehaviorAdmin", "0", RegistryValueKind.DWord);
        //            }
        //            else
        //            {
        //                reg.SetValue("EnableLUA", "1", RegistryValueKind.DWord);
        //                reg.SetValue("ConsentPromptBehaviorAdmin", "5", RegistryValueKind.DWord);
        //            }
        //        }
        //    }
        //    catch { }
        //}

        public static bool SetAccount(string username, string password)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\MVSoft\\WinLocker"))
                {
                    reg.SetValue("Username", username, RegistryValueKind.String);
                    reg.SetValue("Password", password, RegistryValueKind.String);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static (string username, string password)? GetAccount()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\MVSoft\\WinLocker"))
                {
                    object? user = reg.GetValue("Username", string.Empty);
                    object? pass = reg.GetValue("Password", string.Empty);
                    return user != null && pass != null ? (user.ToString(), pass.ToString())! : null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
