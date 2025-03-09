using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite
{
    public class StarPrice : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
               case ItemID.SiltBlock:
                    item.value = AlchemistNPCLite.modConfiguration.SiltSlushPrice;
                    break;
               case ItemID.SlushBlock:
                    item.value = AlchemistNPCLite.modConfiguration.SiltSlushPrice;
                    break;
               case ItemID.DesertFossil:
                    item.value = AlchemistNPCLite.modConfiguration.DesertFossilPrice;
                    break;
            }
        }
    }
}