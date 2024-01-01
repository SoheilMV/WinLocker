namespace WinLocker
{
    internal static class Account
    {
        public static string? Username { get; private set; }
        public static string? Password { get; private set; }
        public static bool HasAccount => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        public static void Save(string username, string password)
        {
            if (Registries.SetAccount(username, password))
            {
                Username = username;
                Password = password;
            }
        }

        public static void Load()
        {
            var account = Registries.GetAccount();
            Username = account?.username;
            Password = account?.password;
        }
    }
}
