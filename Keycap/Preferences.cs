using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Keycap
{
    internal class PreferencesSection : ConfigurationSection
    {
        [ConfigurationProperty("BezelColor", DefaultValue = "#202020")]
        public string BezelColor
        {
            get { return (string)this[nameof(BezelColor)]; }
            set { this[nameof(BezelColor)] = value; }
        }

        [ConfigurationProperty("TextColor", DefaultValue = "#ffffff")]
        public string TextColor
        {
            get { return (string)this[nameof(TextColor)]; }
            set { this[nameof(TextColor)] = value; }
        }
    }

    internal class Preferences
    {
        private static string PreferencesSectionName = "Preferences";

        private static Preferences? _instance;
        private static Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
        protected Preferences()
        {
            if (Config.Sections[PreferencesSectionName] is null)
                Config.Sections.Add(PreferencesSectionName, new PreferencesSection());
        }

        public static PreferencesSection GetPreferencesSection()
        {
            return (PreferencesSection)Config.GetSection(PreferencesSectionName);
        }

        public static void Save() => Config.Save();

        internal static Preferences GetInstance()
        {
            return _instance ??= new Preferences();
        }
    }
}
