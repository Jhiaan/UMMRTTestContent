using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Levelup.Selections;
using Kingmaker.UnitLogic.Progression.Features;
using Kingmaker.EntitySystem.Stats.Base;
using Owlcat.Runtime.Core;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using System.Collections.Generic;

namespace UMMRTTestContent.Content.Feature
{
    internal class Occupations
    {


        internal static void PatchSanctionedPsycker()
        {
            var psyckerOccupation = BlueprintTool.GetBlueprint<BlueprintFeature>("1518d1434ed646039215da3fdda6b096");

            psyckerOccupation.AddFacts(new[] {
                BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("e6a279ca5979435fbb0d39d9d60d7f8a"),
                BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("cce96eda109f4431941cb5c240040657"),
            });
            psyckerOccupation.AddContextStatBonus(StatType.PsyRating, 1, ModifierDescriptor.OriginAdvancement);

            // add from militarum and commissar
            var features = new[]
            {
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("3d0bf78f300a4c618d0f8f2f8f38d429"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("222a60a6bf4c442289378b037c186fde"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("92e05f1a6eb34c44b39353f67bf56601"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("d6a82ff97f524294b8323ce50c100a48"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("5f569e5e1dbe4271aa3b22f3cbf69e8c"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("aae32c4d49544102a03df15f18d48adc"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("f8963dfa805e4acb9063a66416c683aa"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("0618c379e430483bab1a17b2de559bc5"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("152d8edf303f4142a49f8b625757d168"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("2f6272c8f22e4532830b19ae53978505"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("6404b6b08a064695a2abf838cfada6f2"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("f403445daae54d8787a91a93480169c7"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("d90301a8393f49149882c774ed73b1a3"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("f92bf6d353374502953387488d2ba3e2"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("d091ea8f960542f2a31ef20ef2341b4f"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("94ea4f4278e147bebb0c964d75cc50ad"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("5285cce7ae36415c8cd09211ad6869fa"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("ce88361ec77b4a538e9c26f5111595a7"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("dd8a80be418043908ce3431dbfb8ac82"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("7ec70c39a3e14326a7799f80c95f9ec7"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("d61fbaba9fe34b6697efe57f3c5e8574"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("0e916a16e02e42968faa1cb730567827"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("4449f8df7b414ff693fe86064f879a16"),
                BlueprintTool.GetBlueprintReference<BlueprintFeatureReference>("fa3d22a15b2d47cea26872abed3ad70f"),
            };

            psyckerOccupation.GetComponents<AddFeaturesToLevelUp>().ForEach(c =>
            {
                switch (c.Group)
                {
                    case FeatureGroup.CommonTalent:
                    case FeatureGroup.Talent:
                    case FeatureGroup.FirstCareerTalent:
                    case FeatureGroup.SecondCareerTalent:
                    case FeatureGroup.FirstOrSecondCareerTalent:
                        c.m_Features = features;
                        break;
                    default:
                        break;
                }
            });

            psyckerOccupation.OnEnable();
        }
        internal static void PatchSanctionedPsyckerTorments()
        {
            var psyckerTorments = BlueprintTool.GetBlueprint<BlueprintFeature>("cc456183aedf4616aaa44040cb08bcb7");
            psyckerTorments.GetComponent<AddContextStatBonus>().Value = -2;
            psyckerTorments.Configure();
        }

        internal static void PatchCheckBackOccupations()
        {
            var commissarConditionsHolder = BlueprintTool.GetBlueprint<ConditionsHolder>("4f6e6056c2b64faaa42aacaedfc019ca");
            var isPsycker = new HasFact()
            {
                m_Fact = BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>("1518d1434ed646039215da3fdda6b096"), // sentinel
                Unit = (commissarConditionsHolder.Conditions.Conditions[0] as HasFact).Unit
            };


            commissarConditionsHolder.Conditions.Conditions = new Condition[]
            {
                commissarConditionsHolder.Conditions.Conditions[0],
                isPsycker
            };
            commissarConditionsHolder.Conditions.Operation = Operation.Or;
            commissarConditionsHolder.m_AllElements = new List<Element>() {
                commissarConditionsHolder.m_AllElements[0],
                isPsycker,
                commissarConditionsHolder.m_AllElements[1]
            };
            commissarConditionsHolder.OnEnable();

            var militarumContitionsHolder = BlueprintTool.GetBlueprint<ConditionsHolder>("fe422afc826e4c3facb12488b74a8299");
            militarumContitionsHolder.Conditions.Conditions = new Condition[]
            {
                militarumContitionsHolder.Conditions.Conditions[0],
                isPsycker
            };
            militarumContitionsHolder.Conditions.Operation = Operation.Or;
            militarumContitionsHolder.m_AllElements = new List<Element>() {
                militarumContitionsHolder.m_AllElements[0],
                isPsycker,
                militarumContitionsHolder.m_AllElements[1]
            };
            militarumContitionsHolder.OnEnable();
        }
    }
}
