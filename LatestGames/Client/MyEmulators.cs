using LatestGames.Model;
using LatestGames.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LatestGames.Client
{

    internal static class MyEmulators
    {

        internal static bool MyEmulatorsPresentAndEnabled
        {
            get
            {
                return CheckPluginUtil.IsAssemblyOfVersionAvailable("MyEmulators2", Version.Parse("0.3.0.98")) && CheckPluginUtil.IsPluginEnabled("Emulators 2");
            }
        }

        internal static List<EmulatorsGame> GetEmulatorsGames(int noOfGames, bool orderByLatestPlay)
        {
            if (MyEmulatorsPresentAndEnabled)
            {
                return SafeGetGames(noOfGames, orderByLatestPlay);
            }
            return new List<EmulatorsGame>();
        }

        private static List<EmulatorsGame> SafeGetGames(int noOfGames, bool orderByLatestPlay)
        {
            List<EmulatorsGame> games = new List<EmulatorsGame>();
            List<MyEmulators2.Game> emuGames = MyEmulators2.DB.Instance.GetGames();
            if (emuGames != null && emuGames.Count > 0)
            {
                if (orderByLatestPlay)
                {
                    emuGames = emuGames.Where(g => g.Visible && g.Latestplay != null).OrderByDescending(g => g.Latestplay).ToList<MyEmulators2.Game>();
                }
                else
                {
                    emuGames = emuGames.Where(g => g.Visible).OrderByDescending(g => g.GameID).ToList<MyEmulators2.Game>();
                }
                emuGames = emuGames.GetRange(0, emuGames.Count >= noOfGames ? noOfGames : emuGames.Count);
                emuGames.ForEach(
                    (g) =>
                    {
                        string imageFolder = MediaPortal.Configuration.Config.GetSubFolder(MediaPortal.Configuration.Config.Dir.Thumbs, @"Emulators 2\Games\" + g.GameID);
                        string boxart = " ";
                        string fanart = " ";
                        if (Directory.Exists(imageFolder))
                        {
                            boxart = Directory.GetFiles(imageFolder).FirstOrDefault(f => f.Contains("BoxFront") && MediaPortal.Util.Utils.IsPicture(f)) ?? " ";
                            fanart = Directory.GetFiles(imageFolder).FirstOrDefault(f => f.Contains("Fanart") && MediaPortal.Util.Utils.IsPicture(f)) ?? " ";
                        }
                        games.Add(new EmulatorsGame() { Id = g.GameID, Title = g.Title, Description = g.Description, Boxart = boxart, Fanart = fanart });
                    });
            }
            return games;
        }
    }
}