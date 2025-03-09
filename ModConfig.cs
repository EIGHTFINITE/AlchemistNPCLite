using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace AlchemistNPCLite
{
	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[DefaultValue(true)]
		public bool LifeformAnalyzer;
		
		[DefaultValue(false)]
		public bool LifeformAnalyzerAlt;

		[Range(40, 4000)]
		[DefaultValue(4000)]
		public int LocatorRange;
		//[Range(-4000, 4000)]
		public HashSet<NPCDefinition> DisabledLocatorNpcs = new HashSet<NPCDefinition>();

		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int StarPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int RecallPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int WormholePrice;
		
		[Range(1, 1000000)]
		[DefaultValue(700)]
		public int SiltSlushPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int DesertFossilPrice;

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPCLite.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) {
			if (!NetMessage.DoesPlayerSlotCountAsAHost(whoAmI)) {
				message = NetworkText.FromKey("tModLoader.ModConfigRejectChangesNotHost"); // "Only the host can change this config"
				return false;
			}
			message = NetworkText.FromKey("ModConfigAccepted");
			return true;
		}
	}
}
