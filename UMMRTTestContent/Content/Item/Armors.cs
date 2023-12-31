using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts.DodgeChance;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Progression.Features;
using Kingmaker.Designers.Mechanics.Facts.Restrictions;
using Kingmaker.EntitySystem.Properties;
using Kingmaker.EntitySystem.Properties.BaseGetter;
using Kingmaker.EntitySystem.Properties.Getters;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;

namespace UMMRTTestContent.Content.Item
{
    internal static class Armors
    {
        public static string LightArmorName(int level)
        {
            return $"UMMRTTCLightArmor{level}_Item";
        }
        public static string PlayerLightArmorName(int level)
        {
            return $"UMMRTTCPlayerLightArmor{level}_Item";
        }

        public static string LightArmorFeatureName() {
            return "UMMRTTCLightArmor_Feature";
        }
        public static void CreateLightArmorFeature()
        {
            var feature = BlueprintTool.CreateBlueprint<BlueprintFeature>(LightArmorFeatureName(), f =>
            {
                f.AddComponent(new WarhammerDodgeChanceModifierDefender()
                {
                    Properties = WarhammerDodgeChanceModifier.PropertyType.DodgeChance,
                    DodgeChance = new ContextValue
                    {
                        ValueType = ContextValueType.Simple,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = EntityProperty.None,
                        m_CustomProperty = null,
                        PropertyName = ContextPropertyName.Value1,
                        Value = 25,
                    },
                    Restrictions = new RestrictionCalculator()
                    {
                        Property = new PropertyCalculator()
                        {
                            FailSilentlyIfNoTarget = false,
                            TargetType = PropertyTargetType.ContextCaster,
                            Operation = PropertyCalculator.OperationType.G,
                            Getters = new PropertyGetter[]
                            {
                                new SimplePropertyGetter()
                                {
                                    Property = EntityProperty.Agility
                                },
                                new ContextValueGetter()
                                {
                                    Value = 60
                                }
                            }
                        }
                    }

                });

                f.AddSpecificBuffImmunity(new[]
                {
                    "8da2a947a1a8bc543b9e7a9cad054414", "8efe147110a46d2488c30447e7545f13", "14da454c23c4480a9c79f552e12aced6", "8ffb3e2385d04b3986df7dae49819169", "79aa52bbdf534f6c9bc5da0b4e463b66", "5cfac951670244efbe03fa1454480a9"
                });

                f.HideInUI = true;
                f.HideInCharacterSheetAndLevelUp = true;
                f.HideNotAvailibleInUI = true;
            });
        }


        public static void CreateLightArmor(int level)
        {
            // Ranger Armor

            var lightArmor = BlueprintTool.CreateFromBlueprint<BlueprintItemArmor>("fda161d189d74905a58ce2c9560c0226", LightArmorName(level), bp =>
            {
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_OverrideDamageAbsorption = true;
                bp.m_OverrideDamageDeflection = true;
                bp.RemoveAllComponents();
                bp.LocalizeName(key: "UMMRTTCLightArmor_Item");
                switch (level)
                {
                    case 1:
                        bp.m_DamageAbsorption = 35;
                        bp.m_DamageDeflection = 2;
                        bp.AddFactToEquipmentWielder(new[] {
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                        });
                        bp.LocalizeDescription(key: "UMMRTTCLightArmorEmpty_Item");
                        break;

                    case 2:
                        bp.m_DamageAbsorption = 50;
                        bp.m_DamageDeflection = 4;
                        bp.AddFactToEquipmentWielder(new[] {
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                            "2a9b207610c644caa41e30fe8b9befb1", // PsykerTempestusCarapace_Feature
                        });
                        bp.LocalizeDescription(key: "UMMRTTCLightArmorEmpty_Item");
                        break;

                    case 3:
                        bp.m_DamageAbsorption = 75;
                        bp.m_DamageDeflection = 8;
                        bp.AddFactToEquipmentWielder(new[] {
                            "6f5b63dc44cc476091c1a80a6b7ddc49", // DragonScalePowerArmour_Feature
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                            "2a9b207610c644caa41e30fe8b9befb1", // PsykerTempestusCarapace_Feature
                        });
                        bp.AddFactToEquipmentWielder(BlueprintTool.GetModBlueprintReference<BlueprintFeatureReference>(LightArmorFeatureName()));
                        bp.LocalizeDescription();
                        break;

                    default:
                        break;
                }
            });
        }


        public static void CreatePlayerLightArmor(int level)
        {
            // ScoutArmour_Item
            var lightArmor = BlueprintTool.CreateFromBlueprint<BlueprintItemArmor>("5bee6a60c37341b6a4cb39995498546e", PlayerLightArmorName(level), bp =>
            {
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_Type = BlueprintTool.GetBlueprintReference<BlueprintArmorTypeReference>("0fa0782686d949a389eefe83f63e4658");
                bp.m_OverrideDamageAbsorption = true;
                bp.m_OverrideDamageDeflection = true;
                bp.RemoveAllComponents();
                bp.LocalizeName(key: "UMMRTTCPlayerLightArmor_Item");
                switch (level)
                {
                    case 1:
                        bp.m_DamageAbsorption = 40;
                        bp.m_DamageDeflection = 3;
                        bp.AddFactToEquipmentWielder(new[] {
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                        });
                        bp.LocalizeDescription(key: "UMMRTTCPlayerLightArmorEmpty_Item");
                        break;

                    case 2:
                        bp.m_DamageAbsorption = 60;
                        bp.m_DamageDeflection = 5;
                        bp.AddFactToEquipmentWielder(new[] {
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                            "2a9b207610c644caa41e30fe8b9befb1", // PsykerTempestusCarapace_Feature
                        });
                        bp.LocalizeDescription(key: "UMMRTTCPlayerLightArmorEmpty_Item");
                        break;

                    case 3:
                        bp.m_DamageAbsorption = 80;
                        bp.m_DamageDeflection = 10;
                        bp.AddFactToEquipmentWielder(new[] {
                            "6f5b63dc44cc476091c1a80a6b7ddc49", // DragonScalePowerArmour_Feature
                            "49af8877399c4f069d33734079cf7d38", // ChaosBodyglove_Spec_Feature
                            "2a9b207610c644caa41e30fe8b9befb1", // PsykerTempestusCarapace_Feature
                        });
                        bp.AddFactToEquipmentWielder(BlueprintTool.GetModBlueprintReference<BlueprintFeatureReference>(LightArmorFeatureName()));
                        break;

                    default:
                        break;
                }
            });
        }
    }
}
