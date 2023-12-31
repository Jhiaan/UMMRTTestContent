using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.HarmonyPatches
{
    internal class Initializer
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            [HarmonyPrefix]
            static void Prefix()
            {
                if (Initialized) return;
                Initialized = true;

                try
                {
                    Core.Blueprint.BlueprintTool.Intialize();
                    Core.Localization.LocalizationTool.Initialize();
                }
                catch (Exception e)
                {
                    Logger.Error("Exception occured in Initializer BlueprintsCache_Init_Patch Prefix");
                    Logger.LogException(e);
                }
            }
        }

        [HarmonyPatch(typeof(StartGameLoader), "LoadPackTOC")]
        internal class StartGameLoader_LoadPackTOC_Patch
        {
            [HarmonyPriority(Priority.Last)]
            [HarmonyPostfix]
            static void Postfix()
            {
                Core.Blueprint.BlueprintTool.Clear();
            }
        }
    }
}

