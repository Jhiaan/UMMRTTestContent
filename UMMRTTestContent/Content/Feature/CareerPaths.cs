using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Levelup.Selections;
using Kingmaker.UnitLogic.Progression.Paths;
using Owlcat.Runtime.Core;
using System.Collections.Generic;
using System.Linq;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;

namespace UMMRTTestContent.Content.Feature
{
    internal static class CareerPaths
    {
        internal static BlueprintFeatureReference allAttribs;
        internal static BlueprintFeatureReference allSkills;

        internal static BlueprintFeatureReference SwiftMovements = BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("afbf357060c24bd2a70c6d310516f59c");
        internal static BlueprintFeatureReference DuellingMastery = BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("c13b7db1752d41f99b752d086425349a");
        internal static BlueprintFeatureReference CombatMaster = BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("f128235d9f4e4ae387aef64a5840f425");
        internal static BlueprintFeatureReference Nimble = BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("cffa0455647e48cb8163c9071c1cb430");
        internal static BlueprintFeatureReference BolterProficiency = BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("19673fbc918241c6add6710025f67058");

        
        internal static BlueprintSelection.Reference TalentSelection = BlueprintTool.GetBlueprintReference<BlueprintSelection.Reference>("c1f309f9c3e54f019bac7485fa5d2e6d");
        internal static BlueprintSelection.Reference CommonSelection = BlueprintTool.GetBlueprintReference<BlueprintSelection.Reference>("2b1f502ae314466097a1541c3d2efe25");
        internal static BlueprintSelection.Reference AbilitySelection = BlueprintTool.GetBlueprintReference<BlueprintSelection.Reference>("957644aa4c324b099cd41d135ab05557");
        internal static BlueprintSelection.Reference UltimateSelection = BlueprintTool.GetBlueprintReference<BlueprintSelection.Reference>("a09ebb084bb846898e25f855be0e7e53");

        internal static BlueprintFeatureReference AllAtributesAdvancement()
        {
            if (allAttribs == null) 
                allAttribs = BlueprintTool.GetModBlueprintReference<BlueprintFeatureReference>(Advancements.AllAttributesName());
            return allAttribs;
        }
        internal static BlueprintFeatureReference AllSkillsAdvancement()
        {
            if (allSkills == null)
                allSkills = BlueprintTool.GetModBlueprintReference<BlueprintFeatureReference>(Advancements.AllSkillsName());
            return allSkills;
        }

        internal static void PatchWarrior()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("974496d72fbe4329b438ee15cf004bd2");
            AddAvancements(path);



            path.RankEntries[0].m_Features = new[]
            {
                path.RankEntries[0].m_Features[0], SwiftMovements, DuellingMastery, CombatMaster, Nimble, BolterProficiency
            };

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[2].m_Selections = new[]
            {
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[3].m_Selections = new[]
            {
                path.RankEntries[3].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
                UltimateSelection
            };

            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                path.RankEntries[9].m_Selections[1],
                CommonSelection,
            };

            path.RankEntries[10].m_Selections = new[]
            {
                path.RankEntries[10].m_Selections[0],
                TalentSelection,
            };

            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                path.RankEntries[11].m_Selections[1],
                UltimateSelection,
            };

            path.RankEntries[13].m_Selections = new[]
            {
                path.RankEntries[13].m_Selections[0],
                TalentSelection,
            };
            path.Configure(); 
        }

        internal static void PatchOperative()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("1529e5a0e7844bf3bb8d0cc0501264d4");
            AddAvancements(path);

            path.RankEntries[0].m_Features = new[]
            {
                path.RankEntries[0].m_Features[0], SwiftMovements, DuellingMastery, CombatMaster, Nimble, BolterProficiency
            };

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[2].m_Selections = new[]
            {
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[3].m_Selections = new[]
            {
                path.RankEntries[3].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection
            };

            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                path.RankEntries[6].m_Selections[1],
                UltimateSelection
            };

            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                path.RankEntries[8].m_Selections[1],
                AbilitySelection
            };

            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                path.RankEntries[9].m_Selections[1],
                TalentSelection,
            };

            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
                UltimateSelection,
            };

            path.RankEntries[13].m_Selections = new[]
            {
                path.RankEntries[13].m_Selections[0],
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchOfficer()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("33725d84e95e4323ac46d8fbf899b250");
            AddAvancements(path);

            path.RankEntries[0].m_Features = new[]
            {
                path.RankEntries[0].m_Features[0], SwiftMovements, DuellingMastery, CombatMaster, Nimble, BolterProficiency
            };

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[2].m_Selections = new[]
            {
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[3].m_Selections = new[]
            {
                path.RankEntries[3].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection
            };

            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
                UltimateSelection
            };

            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                path.RankEntries[9].m_Selections[1],
                TalentSelection,
            };

            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
                UltimateSelection,
            };

            path.RankEntries[13].m_Selections = new[]
            {
                path.RankEntries[13].m_Selections[0],
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchSoldier()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("06f4f78a9c1a472b85cd79a9a142153d");
            AddAvancements(path);

            path.RankEntries[0].m_Features = new[]
            {
                path.RankEntries[0].m_Features[0], SwiftMovements, DuellingMastery, CombatMaster, Nimble, BolterProficiency
            };

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[2].m_Selections = new[]
            {
                TalentSelection,
                CommonSelection,
            };

            path.RankEntries[3].m_Selections = new[]
            {
                path.RankEntries[3].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
                UltimateSelection
            };

            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                AbilitySelection
            };

            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                path.RankEntries[9].m_Selections[1],
                CommonSelection,
            };

            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
                UltimateSelection,
            };

            path.RankEntries[13].m_Selections = new[]
            {
                TalentSelection,
                path.RankEntries[13].m_Selections[1],
            };

            path.Configure();
        }

        internal static void PatchArchMilitant()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("651684417def4c258c72ba91f481b817");
            AddAvancements(path);

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[13].m_Selections = new[]
            {
                path.RankEntries[13].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                path.RankEntries[18].m_Selections[0],
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchAssassin()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("7b90955673a54136be9c11743943fdfe");
            AddAvancements(path);
            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[14].m_Selections = new[]
            {
                path.RankEntries[14].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[16].m_Selections = new[]
            {
                path.RankEntries[16].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                path.RankEntries[18].m_Selections[0],
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchBountyHunter()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("6f276e8a8e2c4a548504ae39d2a7f22a");
            AddAvancements(path);

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[14].m_Selections = new[]
            {
                path.RankEntries[14].m_Selections[1],
                TalentSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchGrandStrategist()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("a31b390cabe7464fbfd0e1ba53c4112f");
            AddAvancements(path);

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[14].m_Selections = new[]
            {
                path.RankEntries[14].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                TalentSelection,
            };
            path.Configure();
        }

        internal static void PatchMasterTactician()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("604fa184d7d944c8ae5965f9700782b5");
            AddAvancements(path);

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[14].m_Selections = new[]
            {
                path.RankEntries[14].m_Selections[1],
                TalentSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                path.RankEntries[18].m_Selections[0],
                TalentSelection,
            };
            path.Configure();
        }

        internal static void PatchVanguard()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("fec9cd09f11b4615b7a17f441350d2d4");
            AddAvancements(path);

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                CommonSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                TalentSelection,
                AbilitySelection
            };
            path.RankEntries[4].m_Selections = new[]
            {
                path.RankEntries[4].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                UltimateSelection,
            };
            path.RankEntries[8].m_Selections = new[]
            {
                path.RankEntries[8].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                path.RankEntries[9].m_Selections[0],
                AbilitySelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[14].m_Selections = new[]
            {
                path.RankEntries[14].m_Selections[0],
                TalentSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                UltimateSelection,
            };
            path.RankEntries[18].m_Selections = new[]
            {
                TalentSelection,
            };

            path.Configure();
        }

        internal static void PatchExamplar()
        {
            var path = BlueprintTool.GetBlueprint<BlueprintCareerPath>("bcefe9c41c7841c9a99b1dbac1793025");
            AddAvancements(path);

            var examplarSelection = BlueprintTool.GetBlueprintReference<BlueprintSelection.Reference>("c93d8a9f25f74332b6450e32fce4846e");

            path.RankEntries[1].m_Selections = new[]
            {
                path.RankEntries[1].m_Selections[0],
                path.RankEntries[1].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[2].m_Selections = new[]
            {
                path.RankEntries[2].m_Selections[0],
                path.RankEntries[2].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[3].m_Selections = new[]
            {
                path.RankEntries[3].m_Selections[0],
                path.RankEntries[3].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[5].m_Selections = new[]
            {
                path.RankEntries[5].m_Selections[0],
                path.RankEntries[5].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[6].m_Selections = new[]
            {
                path.RankEntries[6].m_Selections[0],
                path.RankEntries[6].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[7].m_Selections = new[]
            {
                path.RankEntries[7].m_Selections[0],
                path.RankEntries[7].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[9].m_Selections = new[]
            {
                examplarSelection,
            };
            path.RankEntries[10].m_Selections = new[]
            {
                path.RankEntries[10].m_Selections[0],
                path.RankEntries[10].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[11].m_Selections = new[]
            {
                path.RankEntries[11].m_Selections[0],
                path.RankEntries[11].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[12].m_Selections = new[]
            {
                path.RankEntries[12].m_Selections[0],
                path.RankEntries[12].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[13].m_Selections = new[]
            {
                path.RankEntries[13].m_Selections[0],
                path.RankEntries[13].m_Selections[1],
                examplarSelection,
            };
            path.RankEntries[15].m_Selections = new[]
            {
                path.RankEntries[15].m_Selections[0],
                path.RankEntries[15].m_Selections[1],
                examplarSelection,
            };
        }

        private static void AddAvancements(BlueprintCareerPath path)
        {
            path.GetComponents<AddFeaturesToLevelUp>().ForEach(c =>
            {
                if (c.Group == FeatureGroup.Attribute)
                {
                    var f = c.m_Features.ToList();
                    f.Add(AllAtributesAdvancement());
                    c.m_Features = f.ToArray();
                }
                else if (c.Group == FeatureGroup.Skill)
                {
                    var f = c.m_Features.ToList();
                    f.Add(AllSkillsAdvancement());
                    c.m_Features = f.ToArray();
                }
            });
        }
    }
}
