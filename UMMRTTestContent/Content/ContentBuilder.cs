using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Content
{
    class ContentBuilder
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            [HarmonyPostfix]
            static void Build()
            {
                try
                {
                    if (Initialized) return;
                    Initialized = true;

                    Logger.Log("Loading New Content");

                    Logger.Log("Creating new Features");
                    Features.Build();

                    Logger.Log("Creating new Items");
                    Items.Build();

                }
                catch (Exception e)
                {
                    Logger.Error("Exception occured in ContentAdder BlueprintsCache_Init_Patch Build");
                    Logger.LogException(e);
                }
            }

            [HarmonyPriority(Priority.Last)]
            [HarmonyPostfix]
            static void Patch()
            {
                try
                {
                    Logger.Log("Patching Content");

                    Logger.Log("Patching Features");
                    Features.Patch();
                }
                catch (Exception e)
                {
                    Logger.Error("Exception occured in ContentAdder BlueprintsCache_Init_Patch Patch");
                    Logger.LogException(e);
                }
            }
        }
    }
}

