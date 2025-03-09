using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLite : Mod
    {
        public static Mod Instance;
        internal static AlchemistNPCLite instance;
        internal static ModConfiguration modConfiguration;

        public override void Load()
        {
            Instance = this;
            instance = this;
        }

        public override void Unload()
        {
            Instance = null;
            instance = null;
            modConfiguration = null;
        }
    }
}
