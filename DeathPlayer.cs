using DeathCounter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace DeathCounter
{
    public class DeathPlayer : ModPlayer
    {
        private string playerDeathPath = null;

        public override void OnEnterWorld()
        {
            base.OnEnterWorld();
            playerDeathPath = Path.Combine(DeathCounter.DeathDir, Player.name + ".txt");

            if (!File.Exists(playerDeathPath))
            {
                using (FileStream fs = File.Create(playerDeathPath))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    PrintDeaths(Player, 0, Color.Yellow);
                    sw.WriteLine("0");
                    sw.Close();
                    sw.Dispose();

                    fs.Close();
                    fs.Dispose();
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(playerDeathPath))
                {
                    long deathCount = Convert.ToInt64(sr.ReadLine());
                    PrintDeaths(Player, deathCount, Color.Yellow);
                    sr.Close();
                    sr.Dispose();
                }
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            base.Kill(damage, hitDirection, pvp, damageSource);
            long deathCount = 0;
            using (StreamReader sr = new StreamReader(playerDeathPath))
            {
                deathCount = Convert.ToInt64(sr.ReadLine());
                sr.Close();
                sr.Dispose();
            }

            deathCount++;
            using (StreamWriter sw = new StreamWriter(playerDeathPath))
            {
                PrintDeaths(Player, deathCount, Color.Red);
                sw.WriteLine(deathCount.ToString());
                sw.Close();
                sw.Dispose();
            }
        }

        public void PrintDeaths(Player player, long deaths, Color color)
        {
            string format = String.Empty;
            if(deaths == 1)
            {
                format = $"{player.name} has {deaths} death.";
            }
            else
            {
                format = $"{player.name} has {deaths} deaths.";
            }

            Mod.Logger.Info(format);
            Main.NewText(format, color);
        }
    }
}
