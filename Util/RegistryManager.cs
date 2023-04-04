using Microsoft.Win32;
using System;

namespace Util
{
    public class RegistryManager
    {
        private RegistryKey registryKey;

        public RegistryManager(String identifier)
        {
            registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + identifier, true);
            if (registryKey == null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + identifier);
            }
        }

        public void RegisterValue(String key, String value)
        {
            registryKey.SetValue(key, value);
        }

        public string GetValue(String key)
        {
            return registryKey != null ? Convert.ToString(registryKey.GetValue(key)) : string.Empty;
        }

        public void CloseRegister()
        {
            registryKey.Close();
        }
    }
}