
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Designers.Mechanics.Facts.Restrictions;
using Kingmaker.EntitySystem.Properties;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Enums;
using Owlcat.Runtime.Core;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Levelup.Selections;

namespace UMMRTTestContent.Core.Blueprint.Extensions
{

    public static class BlueprintExtensions
    {
        

        public static BlueprintScriptableObject SkinAfter(this BlueprintItemEquipment obj, string assetGuid)
        {
            var item = BlueprintTool.GetBlueprint<BlueprintItemEquipment>(assetGuid);
            if (item != null) SkinAfter(obj, item);
            return obj;
        }

        public static BlueprintScriptableObject SkinAfter(this BlueprintItemEquipment obj, BlueprintItemEquipment item)
        {
            obj.m_Icon = item.m_Icon;
            obj.m_InventoryTakeSound = item.m_InventoryTakeSound;
            obj.m_InventoryPutSound = item.m_InventoryPutSound;
            obj.m_InventoryTakeSound = item.m_InventoryTakeSound;

            var objHand = obj as BlueprintItemEquipmentHand;
            var itemHand = item as BlueprintItemEquipmentHand;
            if (objHand != null && itemHand != null)
                objHand.m_VisualParameters = itemHand.m_VisualParameters;

            return obj;
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, string[] assetGuids)
        {
            assetGuids.ForEach(assetGuid =>
            {
                obj.AddFactToEquipmentWielder(assetGuid);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, string assetGuid)
        {
            var fact = BlueprintTool.GetBlueprintReference<BlueprintUnitFactReference>(assetGuid);
            if (fact is null) return obj;

            return obj.AddFactToEquipmentWielder(fact);
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, BlueprintUnitFact[] facts)
        {
            facts.ForEach(fact =>
            {
                obj.AddFactToEquipmentWielder(fact);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, BlueprintUnitFact fact)
        {
            return obj.AddFactToEquipmentWielder(fact.ToReference<BlueprintUnitFactReference>());
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, BlueprintUnitFactReference[] facts)
        {
            facts.ForEach(fact =>
            {
                obj.AddFactToEquipmentWielder(fact);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddFactToEquipmentWielder(this BlueprintItemEquipment obj, BlueprintUnitFactReference fact)
        {
            return obj.AddComponent(new AddFactToEquipmentWielder()
            {
                m_Fact = fact

            });
        }

        public static BlueprintScriptableObject RemoveEquipmentRestrictionsHasFacts(this BlueprintItemEquipment obj)
        {
            var c = obj.GetComponent<EquipmentRestrictionHasFacts>();
            if (c != null) obj.RemoveComponent(c);
            return obj;
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, BlueprintBuff[] buffs)
        {
            buffs.ForEach(b =>
            {
                obj.AddSpecificBuffImmunity(b);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, string assetGuid)
        {
            var buff = BlueprintTool.GetBlueprintReference<BlueprintBuffReference>(assetGuid);
            if (buff is null) return obj;

            return obj.AddSpecificBuffImmunity(buff);
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, string[] assetGuids)
        {
            assetGuids.ForEach(assetGuid =>
            {
                obj.AddSpecificBuffImmunity(assetGuid);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, BlueprintBuff buff)
        {
            return obj.AddSpecificBuffImmunity(buff.ToReference<BlueprintBuffReference>());
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, BlueprintBuffReference[] buffs)
        {
            buffs.ForEach(b =>
            {
                obj.AddSpecificBuffImmunity(b);
            });
            return obj;
        }

        public static BlueprintScriptableObject AddSpecificBuffImmunity(this BlueprintScriptableObject obj, BlueprintBuffReference buff)
        {
            return obj.AddComponent(new SpecificBuffImmunity()
            {
                m_Buff = buff
            });
        }

        public static BlueprintScriptableObject AddContextStatBonus(this BlueprintScriptableObject obj, Kingmaker.EntitySystem.Stats.Base.StatType stat, ContextValue value, ModifierDescriptor descriptor = ModifierDescriptor.BaseStatBonus, int multiplier = 1)
        {
            return obj.AddComponent(new AddContextStatBonus()
            {
                Restrictions = new RestrictionCalculator()
                {
                    Property = new PropertyCalculator()
                    {
                        FailSilentlyIfNoTarget = false,
                        TargetType = PropertyTargetType.CurrentEntity,
                        Operation = PropertyCalculator.OperationType.Sum
                    }
                },

                Descriptor = descriptor,
                Stat = stat,
                Multiplier = multiplier,
                Value = value,
            });
        }

        public static BlueprintScriptableObject AddFeaturesToLevelUp(this BlueprintScriptableObject obj, BlueprintFeatureReference[] features, FeatureGroup group = FeatureGroup.None)
        {
            return obj.AddComponent(new AddFeaturesToLevelUp()
            {
                Group = group,
                m_Features = features
            });
        }

        public static BlueprintScriptableObject AddFacts(this BlueprintScriptableObject obj, BlueprintUnitFactReference[] facts)
        {
            return obj.AddComponent(new AddFacts()
            {
                MinDifficulty = Kingmaker.Settings.GameDifficultyOption.Story,
                m_Facts = facts
            });
        }

        public static BlueprintScriptableObject AddFacts(this BlueprintScriptableObject obj, BlueprintUnitFactReference fact)
        {
            return obj.AddFacts(new[] { fact });
        }

    }
}
