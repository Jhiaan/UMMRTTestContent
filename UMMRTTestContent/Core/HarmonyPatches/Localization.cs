using HarmonyLib;
using Kingmaker.Localization.Enums;
using Kingmaker.Localization.Shared;
using Kingmaker.Localization;
using System;
using UMMRTTestContent.Core.Localization;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.HarmonyPatches
{

    static class Localization
    {
        [HarmonyPatch(typeof(LocalizationManager))]
        static class LocalizationManager_LoadPack_Patch
        {
            private static void AddTolocalizationPack(string patch, LocalizationPack pack)
            {
                try
                {
                    LocalizationTool.AddToLocalizationPack(pack);
                }
                catch (Exception e)
                {
                    Logger.Error($"LocalizationManager_Patch {patch} failed for Locale {pack.Locale}");
                    Logger.LogException(e);
                }

            }

            [HarmonyPatch(nameof(LocalizationManager.LoadPack), new[] { typeof(Locale) }), HarmonyPostfix]
            [HarmonyPriority(Priority.Last)]
            static void LoadPack(ref LocalizationPack __result)
            {
                AddTolocalizationPack("LoadPack", __result);
            }

            [HarmonyPatch(nameof(LocalizationManager.LoadPack), new[] { typeof(string), typeof(Locale) }), HarmonyPostfix]
            [HarmonyPriority(Priority.Last)]
            static void LoadPackWithPath(ref LocalizationPack __result)
            {
                AddTolocalizationPack("LoadPackWithPath", __result);
            }
        }
    }
}