using System;
using System.IO;
using Terraria.ModLoader;

namespace DeathCounter
{
	public class DeathCounter : Mod
	{
		public static string TmodDir { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "Terraria", "tModLoader");
		public static string DeathDir { get; } = Path.Combine(TmodDir, "Death Counter");

		public override void Load()
		{
			base.Load();
			if(!Directory.Exists(DeathDir))
			{
				Logger.Info("No directory found! Creating a new one...");
				Directory.CreateDirectory(DeathDir);
			}
		}
	}
}