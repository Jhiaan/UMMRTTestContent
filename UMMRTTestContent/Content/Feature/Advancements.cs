using Kingmaker.UnitLogic.Progression.Features;
using System;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats.Base;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;
using Owlcat.Runtime.Core;
using Kingmaker.UnitLogic.Levelup.Selections.Feature;
using Kingmaker.UnitLogic.Progression.Features.Advancements;
using Kingmaker.Blueprints.Attributes;
using Kingmaker.Blueprints.JsonSystem.Helpers;
using UnityEngine;
using Kingmaker.Blueprints;

namespace UMMRTTestContent.Content.Feature
{
    internal class Advancements
    {
        internal static string AllAttributesName()
        {
            return "UMMRTTCAllAttributesAdvancement";
        }

        internal static string AllSkillsName()
        {
            return "UMMRTTCAllSkillsAdvancement";
        }

        internal static void CreateAllAttributesAdvancement()
        {
            BlueprintTool.CreateBlueprint<BlueprintAllStatAdvancement>(AllAttributesName(), bp =>
            {
                bp.m_StatCategory = StatCategory.Attribute;
                bp.m_ValuePerRank = 5;
                bp.SetComponents(new[]
                {
                    new AllStatAdvancement()
                });
                bp.Localize();
            });
        }

        internal static void CreateAllSkillsAdvancement()
        {
            BlueprintTool.CreateBlueprint<BlueprintAllStatAdvancement>(AllSkillsName(), bp =>
            {
                bp.m_StatCategory = StatCategory.Skill;
                bp.m_ValuePerRank = 10;
                bp.SetComponents(new[]
                {
                    new AllStatAdvancement()
                });
                bp.Localize();
            });
        }

        internal static void PatchSelections()
        {
            var guids = new[]
            {
                "385b380a81d941baac49e56cb7123085",
                "0cc826a008224ea4b3429240a81d4d1c",
                "db4bd711708442baaace3d41d6efb7f6",
                "946b4ecd52904a07bb4984bc112c7e76",
                "780fc74432984775944fed69bb8cbe85",
                "2fb7109dc64f49f38354d07b9b37bbf6"
            };

            guids.ForEach(guid => {
                var bp = BlueprintTool.GetBlueprint<BlueprintSelectionFeature>(guid);
                bp.MaxRank = 10;
                bp.Configure();
            });
        }

    }

    public enum StatCategory
    {
        Skill = 1,
        Attribute = 2
    }

    [Serializable]
    [TypeId("47d3aeb1-2bb0-454a-9934-774bac668a65")]
    public class BlueprintAllStatAdvancement : BlueprintFeature
    {
        public new class Reference : BlueprintReference<BlueprintAllStatAdvancement>
        {
        }

        [SerializeField]
        public BlueprintStatAdvancement.Source m_Source => BlueprintStatAdvancement.Source.Career;

        [SerializeField]
        public StatCategory m_StatCategory;

        [SerializeField]
        public int m_ValuePerRank;

        public int ValuePerRank => m_ValuePerRank;


        public ModifierDescriptor ModifierDescriptor => m_Source switch
        {
            BlueprintStatAdvancement.Source.Career => ModifierDescriptor.CareerAdvancement,
            BlueprintStatAdvancement.Source.Origin => ModifierDescriptor.OriginAdvancement,
            _ => ModifierDescriptor.OtherAdvancement,
        };

        public BlueprintAllStatAdvancement()
        {
        }
    }

    [Serializable]
    [AllowedOn(typeof(BlueprintAllStatAdvancement))]
    [TypeId("1b9e6237-0753-4e92-aadf-7cf7d4e731cb")]
    public class AllStatAdvancement : StatAdvancement
    {
        public new BlueprintAllStatAdvancement Settings => (BlueprintAllStatAdvancement)base.Fact.Blueprint;

        private StatType[] getStats()
        {
            return Settings.m_StatCategory switch
            {
                StatCategory.Skill => new[] {
                    StatType.SkillAthletics,
                    StatType.SkillAwareness,
                    StatType.SkillCarouse,
                    StatType.SkillCoercion,
                    StatType.SkillCommerce,
                    StatType.SkillDemolition,
                    StatType.SkillLogic,
                    StatType.SkillLoreImperium,
                    StatType.SkillLoreWarp,
                    StatType.SkillLoreXenos,
                    StatType.SkillMedicae,
                    StatType.SkillPersuasion,
                    StatType.SkillTechUse,
                },
                StatCategory.Attribute => new[] {
                    StatType.WarhammerAgility,
                    StatType.WarhammerBallisticSkill,
                    StatType.WarhammerFellowship,
                    StatType.WarhammerIntelligence,
                    StatType.WarhammerPerception,
                    StatType.WarhammerStrength,
                    StatType.WarhammerToughness,
                    StatType.WarhammerWeaponSkill,
                    StatType.WarhammerWillpower,
                },
                _ => null,
            };
        }

        public override void OnActivateOrPostLoad()
        {
            var stats = getStats();
            if (stats == null) return;

            stats.ForEach(stat =>
            {
                base.Owner.Stats.GetStat(stat).AddModifier(Settings.ValuePerRank * base.Fact.GetRank(), base.Runtime, Settings.ModifierDescriptor);
            });
        }

        public override void OnDeactivate()
        {
            var stats = getStats();
            if (stats == null) return;

            stats.ForEach(stat =>
            {
                base.Owner.Stats.GetStat(stat).RemoveModifiersFrom(base.Runtime);
            });
        }

        public override Hash128 GetHash128()
        {
            Hash128 result = default(Hash128);
            Hash128 val = base.GetHash128();
            result.Append(ref val);
            return result;
        }
    }
}
