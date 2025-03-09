using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class DungeonTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
            Item.consumable = true;
            return;
        }

        public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(0);
                return true;
            }
            return false;
        }
    }
}
