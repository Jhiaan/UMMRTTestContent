using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment.Modes;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Mechanics.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Damage;
using UMMRTTestContent.Core.Blueprint;
using UMMRTTestContent.Core.Blueprint.Extensions;
using UnityEngine;

namespace UMMRTTestContent.Content.Item
{
    internal static class Weapons
    {
        internal static BlueprintItemWeapon BloodSeekerKlaive = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("4ec59f09523148f98cb05d63f63e5d4f");
        internal static BlueprintItemWeapon SwordOfFaith = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("73e83b5b49c4461cb32324498c23474d");
        internal static BlueprintItemWeapon ImperialStaff = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("993996a4c0a24463aa400b9441d4caa8");
        
        public static string ForceSwordName(int level)
        {
            return $"UMMRTTCForceSword{level}_Item";
        }

        public static string PowerSwordName(int level)
        {
            return $"UMMRTTCPowerSword{level}_Item";
        }

        public static string PowerAxeName(int level)
        {
            return $"UMMRTTCPowerAxe{level}_Item";
        }

        public static string HeavyBolterName(int level)
        {
            return $"UMMRTTCHeavyBolter{level}_Item";
        }
        public static string BleederPistolName()
        {
            return "UMMRTTCBleederPistol_Item";
        }

        public static string SniperRiffleName(int level)
        {
            return $"UMMRTTCSniperRiffle{level}_Item";
        }

        public static string PlasmaRiffleName()
        {
            return "UMMRTTCPlasmaRiffle_Item";
        }

        public static string MeltaRiffleName()
        {
            return "UMMRTTCMeltaRiffle_Item";
        }

        public static string PsykerSpearName(int level)
        {
            return $"UMMRTTCPsykerSpear{level}_Item";
        }


        public static void CreateForceSword(int level)
        {

            // ancient force sword
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("24db44debaed469386fad90088c20ee9", ForceSwordName(level), bp =>
            {
                switch (level) {
                    case 1:
                        bp.WarhammerDamage = 10;
                        bp.WarhammerMaxDamage = 20;
                        bp.WarhammerPenetration = 10;
                        break;
                    case 2:
                        bp.WarhammerDamage = 20;
                        bp.WarhammerMaxDamage = 27;
                        bp.WarhammerPenetration = 20;
                        bp.AddFactToEquipmentWielder(new[] {
                            "98a981e836d7416bbd498d09797b78ce", // willpower20Feature
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                        });
                        break;
                    case 3:
                        bp.WarhammerDamage = 28;
                        bp.WarhammerMaxDamage = 35;
                        bp.WarhammerPenetration = 30;
                        bp.RemoveComponents<AddFactToEquipmentWielder>(c =>
                        {
                            return c.Fact.AssetGuid == "53c19a9468d24539863989b3be9ed1f5";
                        });
                        bp.AddFactToEquipmentWielder(new[] {
                            "da338f7caf3e44ddac7da84ee6f2ddc9", // parry25Feature
                            "98a981e836d7416bbd498d09797b78ce", // willpower20Feature
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                            "d1192a15fbc84b2a88bf87a5e6e11788", // DjinBladeIremeriss_Feature
                            "51e7b641f2ac4553986c066541c2c9a8", // DuelingSwordFeature
                            "e8f2057b69674afba5d136a759c60b76", // Epiphany_PowerSword_Feature
                            "93837572ddb94e4f84039c40fb5e1eae", // AeldariEyeGouger_Knife_Feature
                        });
                        break;
                    default: 
                        break;
                }
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_Origin = Kingmaker.UI.Common.ItemsItemOrigin.Xeno;
                bp.RemoveEquipmentRestrictionsHasFacts();
                bp.WeaponAbilities.Ability2 = new WeaponAbility()
                {
                    Mode = BloodSeekerKlaive.WeaponAbilities.Ability2.Mode,
                    Type = BloodSeekerKlaive.WeaponAbilities.Ability2.Type,
                    m_Ability = BloodSeekerKlaive.WeaponAbilities.Ability2.m_Ability,
                    m_FXSettings = bp.WeaponAbilities.Ability2.m_FXSettings,
                    AP = BloodSeekerKlaive.WeaponAbilities.Ability2.AP,
                    OnHitOverrideType = BloodSeekerKlaive.WeaponAbilities.Ability2.OnHitOverrideType,
                    m_OnHitActions = BloodSeekerKlaive.WeaponAbilities.Ability2.m_OnHitActions
                };
                bp.WeaponAbilities.Ability4 = SwordOfFaith.WeaponAbilities.Ability2;
                bp.WeaponAbilities.Ability5 = SwordOfFaith.WeaponAbilities.Ability4;
                bp.SkinAfter("1c89025a08624dabbfe29d9f9bc98859"); // halluVenomSword_Item
                bp.LocalizeName(key: "UMMRTTCForceSword_Item");
                bp.LocalizeDescription();
            });
        }


        public static void CreatePowerSword(int level)
        {
            // PowerSwordEldar_Item
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("b7b4b9a224b64d27a9dc89ca40b84fa0", PowerSwordName(level), bp =>
            {
                switch (level)
                {
                    case 1:
                        bp.WarhammerDamage = 10;
                        bp.WarhammerMaxDamage = 20;
                        bp.WarhammerPenetration = 20;
                        break;
                    case 2:
                        bp.WarhammerDamage = 20;
                        bp.WarhammerMaxDamage = 27;
                        bp.WarhammerPenetration = 25;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                        });
                        break;
                    case 3:
                        bp.WarhammerDamage = 28;
                        bp.WarhammerMaxDamage = 35;
                        bp.WarhammerPenetration = 40;
                        bp.RemoveComponents<AddFactToEquipmentWielder>(c =>
                        {
                            return c.Fact.AssetGuid == "53c19a9468d24539863989b3be9ed1f5";
                        });
                        bp.AddFactToEquipmentWielder(new[] {
                            "da338f7caf3e44ddac7da84ee6f2ddc9", // parry25Feature
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                            "d1192a15fbc84b2a88bf87a5e6e11788", // DjinBladeIremeriss_Feature
                            "51e7b641f2ac4553986c066541c2c9a8", // DuelingSwordFeature
                            "e8f2057b69674afba5d136a759c60b76", // Epiphany_PowerSword_Feature
                            "93837572ddb94e4f84039c40fb5e1eae", // AeldariEyeGouger_Knife_Feature
                        });
                        bp.LocalizeDescription();
                        break;
                    default:
                        break;
                }
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_Origin = Kingmaker.UI.Common.ItemsItemOrigin.Xeno;
                bp.RemoveEquipmentRestrictionsHasFacts();
                bp.SkinAfter("1c89025a08624dabbfe29d9f9bc98859"); // halluVenomSword_Item
                bp.WeaponAbilities.Ability2 = new WeaponAbility()
                {
                    Mode = BloodSeekerKlaive.WeaponAbilities.Ability2.Mode,
                    Type = BloodSeekerKlaive.WeaponAbilities.Ability2.Type,
                    m_Ability = BloodSeekerKlaive.WeaponAbilities.Ability2.m_Ability,
                    m_FXSettings = bp.WeaponAbilities.Ability2.m_FXSettings,
                    AP = BloodSeekerKlaive.WeaponAbilities.Ability2.AP,
                    OnHitOverrideType = BloodSeekerKlaive.WeaponAbilities.Ability2.OnHitOverrideType,
                    m_OnHitActions = BloodSeekerKlaive.WeaponAbilities.Ability2.m_OnHitActions
                };
                bp.LocalizeName(key: "UMMRTTCPowerSword_Item");
            });
        }


        public static void CreatePowerAxe(int level)
        {
            // Omnissiah's Providence
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("36dec72188af4c3e99757db6443f8bd7", PowerAxeName(level), bp =>
            {
                switch (level)
                {
                    case 1:
                        bp.WarhammerDamage = 15;
                        bp.WarhammerMaxDamage = 25;
                        bp.WarhammerPenetration = 30;
                        break;
                    case 2:
                        bp.WarhammerDamage = 25;
                        bp.WarhammerMaxDamage = 35;
                        bp.WarhammerPenetration = 40;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                        });
                        break;
                    case 3:
                        bp.WarhammerDamage = 30;
                        bp.WarhammerMaxDamage = 43;
                        bp.WarhammerPenetration = 50;
                        bp.AddFactToEquipmentWielder(new[] {
                            "da338f7caf3e44ddac7da84ee6f2ddc9", // parry25Feature
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "a3c5541e26f5428f853318342edcbbf4", // autoStrickingFeature
                        });
                        break;
                    default:
                        break;
                }
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.LocalizeName(key: "UMMRTTCPowerAxe_Item");
            });
        }


        public static void CreateHeavyBolter(int level)
        {
            // Hymn of Vengance
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("0adaa28e654e4fd6a74830eed3f63390", HeavyBolterName(level), bp =>
            {
                switch (level)
                {
                    case 1:
                        bp.WarhammerDamage = 15;
                        bp.WarhammerMaxDamage = 25;
                        bp.WarhammerPenetration = 15;
                        bp.WarhammerMaxDistance = 30;
                        break;
                    case 2:
                        bp.WarhammerDamage = 25;
                        bp.WarhammerMaxDamage = 35;
                        bp.WarhammerPenetration = 20;
                        bp.WarhammerMaxDistance = 30;
                        bp.AdditionalHitChance = 10;
                        bp.WarhammerMaxAmmo = 20;
                        bp.DodgePenetration = 5;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "ebe8bc566b684c88abd588896a06b72b", // Unhallowed Bellow
                        });
                        break;
                    case 3:
                        bp.WarhammerDamage = 30;
                        bp.WarhammerMaxDamage = 45;
                        bp.WarhammerPenetration = 25;
                        bp.WarhammerMaxDistance = 30;
                        bp.AdditionalHitChance = 15;
                        bp.RateOfFire = 6;
                        bp.WarhammerMaxAmmo = 24;
                        bp.DodgePenetration = 10;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "ebe8bc566b684c88abd588896a06b72b", // Unhallowed Bellow
                            "c31185d9515d4727aae60696c6fa96b9" // they shall weep
                        });
                        break;
                    default:
                        break;
                }
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.LocalizeName(key: "UMMRTTCHeavyBolter_Item");
            });
        }

        public static void CreateBleederPistol()
        {
            // BleederSplinterPistol_Item
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("20795f340f744844bb3f803a90890a3e", BleederPistolName(), bp =>
            {
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_Origin = Kingmaker.UI.Common.ItemsItemOrigin.Xeno;
                bp.WarhammerDamage = 20;
                bp.WarhammerMaxDamage = 30;
                bp.WarhammerPenetration = 25;
                bp.WarhammerMaxDistance = 20;
                bp.AdditionalHitChance = 10;
                bp.RateOfFire = 6;
                bp.WarhammerMaxAmmo = 28;
                bp.DodgePenetration = 20;
                bp.RemoveEquipmentRestrictionsHasFacts();
                bp.AddFactToEquipmentWielder("05a6f94522fb4f398483997d079b9e5b"); // AssasinPistol_Feature
                bp.Localize();
            });
        }

        public static void CreateSniperRiffle(int level)
        {
            var lasGun = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("015e4b1b239c41259fc6ee30817cea69");
            var eyeOfHecaton = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("d043a2289a1f45f784a415057c725cb5");

            BlueprintTool.CreateFromBlueprint(eyeOfHecaton, SniperRiffleName(level), bp =>
            {

                switch (level)
                {
                    case 1:
                        bp.WarhammerDamage = 25;
                        bp.WarhammerMaxDamage = 40;
                        bp.WarhammerPenetration = 30;
                        bp.WarhammerMaxDistance = 40;
                        bp.AdditionalHitChance = 10;
                        bp.WarhammerMaxAmmo = 20;
                        bp.DodgePenetration = 20;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                        });
                        break;
                    case 2:
                        bp.WarhammerDamage = 30;
                        bp.WarhammerMaxDamage = 45;
                        bp.WarhammerPenetration = 40;
                        bp.WarhammerMaxDistance = 40;
                        bp.AdditionalHitChance = 20;
                        bp.WarhammerMaxAmmo = 20;
                        bp.DodgePenetration = 30;
                        bp.AddFactToEquipmentWielder(new[] {
                            "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                            "261abe4b20f54a75aab43232a4457cb4", // Wanderer's Portent
                        });
                        bp.AddComponent(new OverrideOverpenetrationFactor()
                        {
                            FactorPercents = 200
                        });
                        break;
                    default: break;
                }
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.WarhammerRecoil = 10;
                bp.RateOfFire = 6;
                bp.WeaponAbilities.Ability1 = eyeOfHecaton.WeaponAbilities.Ability1;
                bp.WeaponAbilities.Ability2 = lasGun.WeaponAbilities.Ability2;
                bp.WeaponAbilities.Ability3 = eyeOfHecaton.WeaponAbilities.Ability2;
                bp.WeaponAbilities.Ability4 = lasGun.WeaponAbilities.Ability3;
                bp.LocalizeName(key: "UMMRTTCSniperRiffle_Item");
            });
        }

        public static void CreateMeltaRiffle()
        {
            var eruptionMelta = BlueprintTool.GetBlueprint<BlueprintItemWeapon>("51cef9a165014130a5b3293ecc9e0ed0");
            // MeltaUltima_Item
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("15fff32aea5d499b92d037144f8eaef8", MeltaRiffleName(), bp =>
            {
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.WarhammerDamage = 45;
                bp.WarhammerMaxDamage = 60;
                bp.WarhammerMaxDistance = 20;
                bp.AdditionalHitChance = 20;
                bp.WarhammerMaxAmmo = 10;
                bp.WarhammerPenetration = 90;
                bp.DodgePenetration = 15;
                bp.AddFactToEquipmentWielder(new[] {
                    "572c6fba29f8402fa5d86e157edf8f29", // PlasmaRifleCH05Unique_Feature
                    "d0da5ccac4fc40fea393635c62bd326c", // navigatorStaffPerception25Feature
                });
                bp.WeaponAbilities.Ability2 = eruptionMelta.WeaponAbilities.Ability2;
                bp.Localize();
            });
        }

        public static void CreatePsykerSpear(int level)
        {
            // StaffOfShockAndAwe_Item
            BlueprintTool.CreateFromBlueprint<BlueprintItemWeapon>("08824553c62145a78d642fde86286c6e", PsykerSpearName(level), bp =>
            {
                bp.m_Rarity = BlueprintItem.ItemRarity.Unique;
                bp.m_Origin = Kingmaker.UI.Common.ItemsItemOrigin.Xeno;
                bp.RemoveEquipmentRestrictionsHasFacts();
                bp.RemoveComponents<StackingUnitProperty>();
                bp.AddComponent(new StackingUnitProperty()
                {
                    m_Property = BlueprintTool.GetBlueprintReference<BlueprintStackingUnitProperty.Reference>("cd640c41545049be9d57771c192d85cc"), // LightningPsykerWeaponProperty
                    m_Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Simple,
                        Value = level * 7
                    }
                });
                bp.AddComponent(new StackingUnitProperty()
                {
                    m_Property = BlueprintTool.GetBlueprintReference<BlueprintStackingUnitProperty.Reference>("d7d37969b0854308a43a9e4fc724bc25"), // Sanctic_Weapon_EmperorsWrath_Property
                    m_Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Simple,
                        Value = level * 7
                    }
                });
                bp.WeaponAbilities.Ability4 = ImperialStaff.WeaponAbilities.Ability2;
                bp.WeaponAbilities.Ability5 = ImperialStaff.WeaponAbilities.Ability3;
                bp.SkinAfter("714bca98165b4b18b626b26ebf1f05b0"); // singingSpear_Item
                bp.LocalizeName(key: "UMMRTTCPsykerSpear_Item");
                bp.LocalizeDescription();
            }); 
        }
    }
}
