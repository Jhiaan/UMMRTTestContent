using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMMRTTestContent.Content.Item;

namespace UMMRTTestContent.Content
{
    internal static class Items
    {

        public static void Build()
        {
            Armors.CreateLightArmorFeature();
            Armors.CreateLightArmor(1);
            Armors.CreatePlayerLightArmor(1);
            Armors.CreateLightArmor(2);
            Armors.CreatePlayerLightArmor(2);
            Armors.CreateLightArmor(3);
            Armors.CreatePlayerLightArmor(3);

            Weapons.CreateForceSword(1);
            Weapons.CreatePowerSword(1);
            Weapons.CreatePowerAxe(1);
            Weapons.CreatePsykerSpear(1);
            Weapons.CreateHeavyBolter(1);
            Weapons.CreateForceSword(2);
            Weapons.CreatePowerAxe(2);
            Weapons.CreatePowerSword(2);
            Weapons.CreatePsykerSpear(2);
            Weapons.CreateHeavyBolter(2);
            Weapons.CreateForceSword(3);
            Weapons.CreatePowerSword(3);
            Weapons.CreatePowerAxe(3);
            Weapons.CreatePsykerSpear(3);
            Weapons.CreateHeavyBolter(3);
            Weapons.CreateBleederPistol();
            Weapons.CreateSniperRiffle(1);
            Weapons.CreateSniperRiffle(2);
            Weapons.CreateMeltaRiffle();
        }

        public static void Pacth()
        {
            
        }
    }
}
