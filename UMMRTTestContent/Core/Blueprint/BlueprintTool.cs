using System;
using System.IO;
using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using static UMMRTTestContent.Core.Utilities.Helpers;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.Blueprint
{
    public static class BlueprintTool
    {
        internal static readonly BlueprintRepository Repository = new BlueprintRepository();

        public static void Intialize()
        {
            Repository.Initialize();
        }

        public static void Clear()
        {
            Repository.Clear();
        }

        public static string ModGuid(string name)
        {
            return Repository.GetGUID(name);
        }

        public static T GetModBlueprintReference<T>(string name) where T : BlueprintReferenceBase
        {
            string assetId = ModGuid(name);
            if (assetId is null) return null;

            return GetBlueprintReference<T>(assetId);
        }

        public static T GetModBlueprint<T>(string name) where T : SimpleBlueprint
        {
            return Repository.GetModBlueprint<T>(name);
        }

        public static T GetBlueprintReference<T>(string id) where T : BlueprintReferenceBase
        {
            var reference = Activator.CreateInstance<T>();
            reference.guid = id;
            return reference;
        }

        public static T GetBlueprint<T>(string id) where T : SimpleBlueprint
        {
            return Repository.GetBlueprint<T>(id);
        }

        public static T CreateBlueprint<T>([NotNull] string name, Action<T> init = null) where T : SimpleBlueprint, new()
        {
            var result = new T
            {
                name = name,
                AssetGuid = ModGuid(name)
            };
            init?.Invoke(result);
            Repository.AddBlueprint(result);
            return result;
        }

        public static T CreateFromModBlueprint<T>(string assetId, string name, Action<T> init = null) where T : SimpleBlueprint
        {
            var blueprint = GetModBlueprint<T>(assetId);
            return CreateFromBlueprint(blueprint, name, init);
        }

        public static T CreateFromBlueprint<T>(string assetId, string name, Action<T> init = null) where T : SimpleBlueprint
        {
            var blueprint = GetBlueprint<T>(assetId);
            return CreateFromBlueprint(blueprint, name, init);
        }

        public static T CreateFromBlueprint<T>(T blueprint, string name, Action<T> init = null) where T : SimpleBlueprint
        {
            var copy = ObjectDeepCopier.Clone(blueprint) as T;
            if (copy != null)
            {
                copy.name = name;
                copy.AssetGuid = ModGuid(name);
                init?.Invoke(copy);
                Repository.AddBlueprint(copy);
            }
            else { Logger.Error($"Could not copy blueprint: {blueprint.AssetGuid} - {typeof(T)}"); }

            return copy;
        }

        public static void TryExportBlueprint(SimpleBlueprint bp, string path)
        {
            var Export = new BlueprintJsonWrapper(bp);
            try
            {
                //Export.Save($"{path}{Path.DirectorySeparatorChar}{bp.name}.jbp");
                Export.Save($"{path}{Path.DirectorySeparatorChar}{bp.name}.{bp.AssetGuid}.jbp");
            }
            catch
            {
                Logger.Error($"Failed to export {bp.AssetGuid} - {bp.name}");
            }
        }
    }
}