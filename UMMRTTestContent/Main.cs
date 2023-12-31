using HarmonyLib;
using System.Reflection;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager;

namespace UMMRTTestContent;

#if DEBUG
[EnableReloading]
#endif
static class Main
{
    internal static Harmony HarmonyInstance;
    internal static ModEntry ModEntry;
    internal static ModEntry.ModLogger Logger => ModEntry.Logger;
    static bool Load(ModEntry modEntry)
    {
        ModEntry = modEntry;
        modEntry.OnGUI = OnGUI;
#if DEBUG
        modEntry.OnUnload = OnUnload;
#endif
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        return true;
    }

    static void OnGUI(ModEntry modEntry)
    {

    }

#if DEBUG
    static bool OnUnload(ModEntry modEntry)
    {
        HarmonyInstance.UnpatchAll(modEntry.Info.Id);
        return true;
    }
#endif
}