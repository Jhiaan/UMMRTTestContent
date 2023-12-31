using Kingmaker.Localization;
using Kingmaker.Localization.Shared;
using Kingmaker.Localization.Enums;
using System;
using UMMRTTestContent.Core.Utilities;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.Localization
{
    /// <remarks>Based on code from <see href="https://github.com/WittleWolfie/WW-Blueprint-Core"/>WW-Blueprint-Core</remarks>
    public class LocalizationTool
    {
        private static MultiLocalizationPack LocalizationPack = new MultiLocalizationPack();

        public static void Initialize()
        {
            LocalizationPack.Add(Helpers.GetJsonDefinitions<MultiLocaleString>("Localization"));
        }
        public static LocalizedString CreateString(string key, string value, bool tagEncyclopediaEntries = false)
        {
            if (LocalizationPack.Has(key))
            {
                var localString = LocalizationPack.Get(key);
                if (!localString.Text(LocalizationManager.Instance.CurrentPack.Locale).Equals(value))
                {
                    throw new InvalidOperationException($"String with key {key} already exists with a different value.");
                }
                return localString.LocalizedString;
            }

            var localizedString = new LocalizedString() { m_Key = key };
            var currentString = LocalizationManager.Instance.CurrentPack.GetText(key, reportUnknown: false);
            if (!string.IsNullOrEmpty(currentString))
            {
                if (currentString.Equals(value))
                {
                    Logger.Log($"Localized string already exists with key {key} and matching value.");
                }
                else
                {
                    throw new InvalidOperationException($"String with key {key} already exists with a different value.");
                }
            }

            return localizedString;
        }
        public static LocalizedString GetString(string key)
        {
            if (LocalizationPack.Has(key)) { return LocalizationPack.Get(key).LocalizedString; }
            else Logger.Error($"Localized string {key} not found");

            var localizedString = LocalizationManager.Instance.CurrentPack.GetText(key, reportUnknown: false);
            if (string.IsNullOrEmpty(localizedString))
            {
                throw new InvalidOperationException($"No string exists with key {key}");
            }
            return new() { m_Key = key };
        }

        public static void AddToLocalizationPack(LocalizationPack pack)
        {
            if (pack.Locale == Locale.Sound || LocalizationPack.IsEmpty) return;
            pack.AddStrings(LocalizationPack.Generate(pack.Locale));
        }
    }
    public class LocalString
    {
        public readonly LocalizedString LocalizedString;

        private LocalString(string key)
        {
            LocalizedString = new LocalizedString() { m_Key = key };
        }

        private LocalString(LocalizedString localizedString)
        {
            LocalizedString = localizedString;
        }

        public static implicit operator LocalString(string key)
        {
            return new(key);
        }

        public static implicit operator LocalString(LocalizedString localizedString)
        {
            return new(localizedString);
        }
    }
}