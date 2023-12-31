using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMMRTTestContent.Content.Feature;

namespace UMMRTTestContent.Content
{
    internal static class Features
    {
        internal static void Build()
        {
            HomeWorlds.CreateSentinelWorld();
            Advancements.CreateAllAttributesAdvancement();
            Advancements.CreateAllSkillsAdvancement();
        }

        internal static void Patch()
        {
            HomeWorlds.PatchCharGenOriginPath();
            HomeWorlds.PatchCheckBackOrigins();
            Occupations.PatchSanctionedPsycker();
            Occupations.PatchSanctionedPsyckerTorments();
            Occupations.PatchCheckBackOccupations();
            Advancements.PatchSelections();
            CareerPaths.PatchWarrior();
            CareerPaths.PatchAssassin();
            CareerPaths.PatchArchMilitant();
            CareerPaths.PatchMasterTactician();
            CareerPaths.PatchOfficer();
            CareerPaths.PatchVanguard();
            CareerPaths.PatchBountyHunter();
            CareerPaths.PatchExamplar();
            CareerPaths.PatchGrandStrategist();
            CareerPaths.PatchOperative();
            CareerPaths.PatchSoldier();
        }
    }
}
