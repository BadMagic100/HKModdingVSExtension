using Microsoft.VisualStudio.Settings;
using System.Runtime.CompilerServices;

namespace HKModWizard
{
    public class HKSettings
    {
        private WritableSettingsStore settings;
        private const string path = "HKModding";

        private string GetString([CallerMemberName]string property = null)
        {
            return settings.GetString(path, property, "");
        }

        private bool GetBool([CallerMemberName]string property = null)
        {
            return settings.GetBoolean(path, property, true);
        }

        private void SetValue<T>(T value, [CallerMemberName]string property = null)
        {
            if (!settings.CollectionExists(path))
            {
                settings.CreateCollection(path);
            }
            if (value is string s)
            {
                settings.SetString(path, property, s);
            }
            else if (value is bool b)
            {
                settings.SetBoolean(path, property, b);
            }
            else if (value is int i)
            {
                settings.SetInt32(path, property, i);
            }
        }

        public string Author
        {
            get => GetString();
            set => SetValue(value);
        }

        public string HKManagedPath
        {
            get => GetString();
            set => SetValue(value);
        }

        public bool UseNullables
        {
            get => GetBool();
            set => SetValue(value);
        }

        public HKSettings(WritableSettingsStore settings)
        {
            this.settings = settings;
        }
    }
}
