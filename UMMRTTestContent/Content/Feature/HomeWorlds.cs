using Kingmaker.UnitLogic.Progression.Features;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats.Base;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Properties;
using Kingmaker.UnitLogic.Progression.Paths;
using Kingmaker.UnitLogic.Levelup.Selections;
using Owlcat.Runtime.Core;
using HarmonyLib;
using static UMMRTTestContent.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Kingmaker.ElementsSystem;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.UnitLogic.Levelup.Selections.Feature;

namespace UMMRTTestContent.Content.Feature
{
    internal class HomeWorlds
    {

        internal static string SentinelWorldName()
        {
            return "UMMRTTCSentinel_Homeworld";
        }

        internal static void CreateSentinelWorld()
        {
            BlueprintTool.CreateBlueprint<BlueprintFeature>(SentinelWorldName(), bp =>
            {
                bp.AddContextStatBonus(StatType.WarhammerAgility, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerBallisticSkill, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerFellowship, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerIntelligence, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerPerception, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerStrength, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerToughness, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerWeaponSkill, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.WarhammerWillpower, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillAthletics, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillAwareness, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillCarouse, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillCoercion, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillCommerce, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillDemolition, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillLogic, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillLoreImperium, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillLoreWarp, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillLoreXenos, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillMedicae, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillPersuasion, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddContextStatBonus(StatType.SkillTechUse, 5, ModifierDescriptor.OriginAdvancement);
                bp.AddFacts(new[]
                {
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("56513668e80d49c1ac337b170b863d45"), // DeathWorld_InnateTalent
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("aaf4cbeaccf1465b80744848c3b21563"), // VoidBorn_Innate_Talent
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("bfca260991b94d64adf2a09b1d490254"), // FortressWorld_InnateTalent_Feature
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("838681f4b3bd43af946a2fd6830df12b"), // DeathWorld_Talent1 brutal hunter
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("6ee56b90ea554830b83d2331bceeb3b8"), // DeathWorld_Talent3 wounded beast
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("13918777460b44568ce625d150251f88"), // VoidBorn_Talent01_Feature bloody mess
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("19c8c652a77743b39e610b0b23c8bd69"), // ForgeWorld_Talent04_Feature persistence of the forge
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("75ee9160a7ff41c4b77818094334c889"), // FortressWorld_Talent03_Feature familiar kickback
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("40edd34c2d9d4b2482603083309a3ecf"), // FortressWorld_Talent05_Feature never stop believing
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("864d5b0a750e4ea3a1f5bcc8489bdacf"), // FortressWorld_Talent02_Feature hail of steel
                    BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("d991437bdbde4d458cadf9d851d35a85"), // FortressWorld_Talent03_Feature spare magazine
                });
                bp.Localize();
            });
        }
        

        internal static void PatchCharGenOriginPath()
        {
            var chargenOrigin = BlueprintTool.GetBlueprint<BlueprintOriginPath>("45181a40472441a8904a5282f83693f4");
            var chargenOriginComponents = new List<BlueprintComponent>();
            var features = new List<BlueprintFeatureReference>();

            chargenOrigin.ComponentsArray.ForEach(bp =>
            {
                if (bp is AddFeaturesToLevelUp bp2 && bp2.Group == FeatureGroup.ChargenHomeworld)
                {
                    bp2.Features.ForEach(f => { features.Add(f.ToReference<BlueprintFeatureReference>()); });
                }
                else chargenOriginComponents.Add(bp);
            });

            features.Add(BlueprintTool.GetModBlueprintReference<BlueprintFeatureReference>(SentinelWorldName()));
            var tmpList = new List<BlueprintComponent>(1 + chargenOriginComponents.Count) { 
                new AddFeaturesToLevelUp() {
                    Group = FeatureGroup.ChargenHomeworld,
                    m_Features = features.ToArray()
                }
            };
            tmpList.AddRange(chargenOriginComponents);
            chargenOrigin.SetComponents(tmpList);
            chargenOrigin.OnEnable();
        }

        internal static void PatchCheckBackOrigins()
        {
            var voidbornContitionsHolder = BlueprintTool.GetBlueprint<ConditionsHolder>("5d68e240162a4d21b54f5e4e0a60c38e");
            var isFromSentinelWorld = new HasFact()
            {
                m_Fact = BlueprintTool.GetModBlueprintReference<BlueprintUnitFactReference>(SentinelWorldName()), // sentinel
                Unit = (voidbornContitionsHolder.Conditions.Conditions[0] as HasFact).Unit
            };


            voidbornContitionsHolder.Conditions.Conditions = new Condition[]
            {
                voidbornContitionsHolder.Conditions.Conditions[0],
                isFromSentinelWorld
            };
            voidbornContitionsHolder.Conditions.Operation = Operation.Or;
            voidbornContitionsHolder.m_AllElements = new List<Element>() {
                voidbornContitionsHolder.m_AllElements[0],
                isFromSentinelWorld,
                voidbornContitionsHolder.m_AllElements[1]
            };
            voidbornContitionsHolder.OnEnable();

            var deathWorldContitionsHolder = BlueprintTool.GetBlueprint<ConditionsHolder>("efef605391ce411d961972a0203c652c");
            deathWorldContitionsHolder.Conditions.Conditions = new Condition[]
            {
                deathWorldContitionsHolder.Conditions.Conditions[0],
                isFromSentinelWorld
            };
            deathWorldContitionsHolder.Conditions.Operation = Operation.Or;
            deathWorldContitionsHolder.m_AllElements = new List<Element>() {
                deathWorldContitionsHolder.m_AllElements[0],
                isFromSentinelWorld,
                deathWorldContitionsHolder.m_AllElements[1]
            };
            deathWorldContitionsHolder.OnEnable();
        }
    }
}
