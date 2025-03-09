using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Terraria.ModLoader.Config;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLiteWorld : ModSystem
    {
        private const int saveVersion = 0;

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int LocatorArrowIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (LocatorArrowIndex != -1)
            {
                layers.Insert(LocatorArrowIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Locator Arrow",
                    delegate
                    {
                        Player player = Main.LocalPlayer;
                        if (player.accCritterGuide && AlchemistNPCLite.modConfiguration.LifeformAnalyzer)
                        {
                            for (int v = 0; v < 200; ++v)
                            {
                                NPC npc = Main.npc[v];
                                if (npc.active && npc.rarity >= 1 && !AlchemistNPCLite.modConfiguration.DisabledLocatorNpcs.Contains(new NPCDefinition(npc.type)))
                                {
                                    // Adapted from Census mod
                                    Vector2 playerCenter = Main.LocalPlayer.Center + new Vector2(0, Main.LocalPlayer.gfxOffY);
                                    var vector = npc.Center - playerCenter;
                                    var distance = vector.Length();
                                    if (distance > 40 && distance <= AlchemistNPCLite.modConfiguration.LocatorRange)
                                    {
                                        var offset = Vector2.Normalize(vector) * Math.Min(70, distance - 20);
                                        float rotation = vector.ToRotation() + (float)(Math.PI / 2);
                                        var drawPosition = playerCenter - Main.screenPosition + offset;
                                        float fade = Math.Min(1f, (distance - 20) / 70);
										if (!AlchemistNPCLite.modConfiguration.LifeformAnalyzerAlt)
											Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCLite/Projectiles/LocatorProjectile").Value, drawPosition,
                                                                null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                        else Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCLite/Projectiles/LocatorProjectileAlt").Value, drawPosition,
                                                                null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                    }
                                }
                            }
                        }
                        return true;
                    }, InterfaceScaleType.Game)
                );
            }
        }
    }
}
