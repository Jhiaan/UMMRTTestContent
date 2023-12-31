using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Newtonsoft.Json;
using System.Collections.Generic;
using UMMRTTestContent.Core.Utilities;
using static UMMRTTestContent.Main;

namespace UMMRTTestContent.Core.Blueprint
{
    internal class BlueprintRepository
    {
        [JsonProperty]
        private readonly Dictionary<string, string> ModGuids = new Dictionary<string, string>();

        private readonly Dictionary<string, SimpleBlueprint> ModBlueprints = new Dictionary<string, SimpleBlueprint>();

        [JsonObject(MemberSerialization.OptIn)]
        internal class BlueprintEntry
        {
            [JsonProperty]
            public readonly string Name = "";
            [JsonProperty]
            public readonly string Guid = "";
        }

        public void Initialize()
        {
            Helpers.GetJsonDefinitions<BlueprintEntry>("Blueprints").ForEach(e =>
            {
                if (ModGuids.ContainsKey(e.Name))
                {
                    Logger.Error($"Blueprint name {e.Name} already exists");
                    return;
                }
                ModGuids.Add(e.Name, e.Guid);
            });
        }

        public void Clear()
        {
            ModBlueprints.Clear();
            ModGuids.Clear();
        }

        public string GetGUID(string name)
        {
            string guid;
            if (!ModGuids.TryGetValue(name, out guid))
                Logger.Error($"No Guid found for {name}");
            return guid;
        }

        public T GetModBlueprint<T>(string name) where T : SimpleBlueprint
        {
            SimpleBlueprint asset;
            if (!ModBlueprints.TryGetValue(name, out asset))
            {
                Logger.Error($"No Blueprint found for {name}");
                return null;
            }

            var bp = asset as T;
            if (bp == null) { Logger.Error($"Could not load mod blueprint: {name} - {typeof(T)}"); }

            return bp;
        }

        public T GetBlueprint<T>(string assetId) where T : SimpleBlueprint
        {
            SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(assetId);
            T value = asset as T;
            if (value == null) { Logger.Error($"COULD NOT LOAD BLUEPRINT: {assetId} - {typeof(T)}"); }
            return value;
        }

        public void AddBlueprint([NotNull] SimpleBlueprint blueprint)
        {
            var loadedBlueprint = ResourcesLibrary.TryGetBlueprint(blueprint.AssetGuid);
            if (loadedBlueprint == null)
            {
                ModBlueprints[blueprint.name] = blueprint;
                ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(blueprint.AssetGuid, blueprint);
                blueprint.OnEnable();
                Logger.Log($"Added {blueprint}");
            }
            else
            {
                Logger.Log($"Failed to Add: {blueprint.name}");
                Logger.Log($"Asset ID: {blueprint.AssetGuid} already in use by: {loadedBlueprint.name}");
            }
        }
    }
}
