using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLitePlayer : ModPlayer
    {
        public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
        {
            AlchemistNPCLitePlayer clone = clientClone as AlchemistNPCLitePlayer;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
        }
    }
}