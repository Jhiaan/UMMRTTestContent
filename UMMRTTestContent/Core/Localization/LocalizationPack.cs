using Kingmaker.Localization;
using Kingmaker.Localization.Enums;
using Kingmaker.Localization.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.Localization
{
    /// <summary>
    /// Contains and manages localization for all available langauges.
    /// </summary>
    /// 
    /// <remarks>Based on code from <see href="https://github.com/Vek17/TabletopTweaks-Core"/>TabletopTweaks-Core</remarks>
    internal class MultiLocalizationPack
    {
        /// <summary>
        /// Dictionary of existing MultiLocaleStrings by Key.
        /// </summary>
        private readonly Dictionary<string, MultiLocaleString> Strings = new();

        internal bool Has(string key)
        {
            return Strings.ContainsKey(key);
        }

        internal MultiLocaleString Get(string key)
        {
            return Strings[key];
        }

        internal void Add(List<MultiLocaleString> localeStrings)
        {
            localeStrings.ForEach(localeString =>
            {
                Add(localeString);
            });
        }

        internal void Add(MultiLocaleString localeString)
        {
            if (Strings.ContainsKey(localeString.Key))
            {
                Logger.Error($"Localized string with key {localeString.Key} already exists");
                return;
            }
            Strings.Add(localeString.Key, localeString);
        }

        /// <summary>
        /// Generates a new LocalizationPack based on the contents of the MultiLocalizationPack.
        /// </summary>
        internal LocalizationPack Generate(Locale locale)
        {
            var pack = new LocalizationPack
            {
                Locale = locale,
            };

            foreach (var entry in Strings)
            {
                pack.PutString(entry.Key, entry.Value.Text(locale));
            }
            return pack;
        }

        internal virtual bool IsEmpty => Strings.Count == 0;
    }

    /// <summary>
    /// Contains key used for LocalizedString as well as localized text for all supported lanagues.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class MultiLocaleString
    {
        [JsonProperty]
        private readonly bool ProcessTemplates = true;

        [JsonProperty]
        public readonly string Key = "";

        [JsonProperty]
        private readonly string enGB = "";

        [JsonProperty]
        private readonly string ruRU = "";

        [JsonProperty]
        private readonly string deDE = "";

        [JsonProperty]
        private readonly string frFR = "";

        [JsonProperty]
        private readonly string zhCN = "";

        [JsonProperty]
        private readonly string esES = "";

        internal LocalizedString LocalizedString
        {
            get
            {
                m_LocalizedString ??= new LocalizedString
                {
                    m_Key = Key,
                    m_ShouldProcess = ProcessTemplates
                };
                return m_LocalizedString;
            }
        }
        private LocalizedString m_LocalizedString;

        public string Text(Locale locale = Locale.enGB)
        {
            bool tagEntries = false;
            string result;
            switch (locale)
            {
                case Locale.enGB:
                    result = enGB;
                    tagEntries = ProcessTemplates;
                    break;
                case Locale.ruRU:
                    result = ruRU;
                    break;
                case Locale.deDE:
                    result = deDE;
                    break;
                case Locale.frFR:
                    result = frFR;
                    break;
                case Locale.zhCN:
                    result = zhCN;
                    break;
                case Locale.esES:
                    result = esES;
                    break;
                default:
                    result = enGB;
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                result = enGB;
            }

            return result;

            /*return new LocalizationPack.StringEntry
            {
                Text = tagEntries ? EncyclopediaTool.TagEncyclopediaEntries(result) : result
            };*/
        }

        public override string ToString()
        {
            return Text(LocalizationManager.Instance.CurrentLocale);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode() ^ enGB.GetHashCode();
        }
    }
}