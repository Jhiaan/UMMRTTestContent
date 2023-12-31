using Kingmaker.UnitLogic.Mechanics.Blueprints;
using UMMRTTestContent.Core.Localization;

namespace UMMRTTestContent.Core.Blueprint.Extensions
{
    public static class LocalizationExtensions
    {

        public static BlueprintMechanicEntityFact LocalizeName(this BlueprintMechanicEntityFact obj, BlueprintMechanicEntityFact other = null, string key = null)
        {
            obj.m_DisplayName = other != null ? other.m_DisplayName : LocalizationTool.GetString($"{key ?? obj.name}.Name");
            return obj;
        }
        public static BlueprintMechanicEntityFact LocalizeDescription(this BlueprintMechanicEntityFact obj, BlueprintMechanicEntityFact other = null, string key = null)
        {
            obj.m_Description = other != null ? other.m_Description : LocalizationTool.GetString($"{key ?? obj.name}.Description");
            return obj;
        }

        public static BlueprintMechanicEntityFact Localize(this BlueprintMechanicEntityFact obj, BlueprintMechanicEntityFact other = null, string key = null)
        {
            obj.LocalizeName(other, key);
            obj.LocalizeDescription(other, key);

            return obj;
        }

        public static BlueprintMechanicEntityFact SetName(this BlueprintMechanicEntityFact obj, string name)
        {
            obj.m_DisplayName = LocalizationTool.CreateString($"{obj.name}.Name", name, false);

            return obj;
        }

        public static BlueprintMechanicEntityFact SetDescription(this BlueprintMechanicEntityFact obj, string description, bool tagEncyclopediaEntries = false)
        {
            obj.m_Description = LocalizationTool.CreateString($"{obj.name}.Description", description, tagEncyclopediaEntries);

            return obj;
        }

        public static BlueprintMechanicEntityFact SetNameDescription(this BlueprintMechanicEntityFact obj, string name, string description, bool tagEncyclopediaEntries = false)
        {
            obj.SetName(name);
            obj.SetDescription(description, tagEncyclopediaEntries);
            return obj;
        }
    }
}
