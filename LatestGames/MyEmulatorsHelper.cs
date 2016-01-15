using MediaPortal.GUI.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LatestGames
{
    internal class Game
    {
        internal int Id { get; set; }
        internal string Title { get; set; }
        internal string Description { get; set; }
        internal string Boxart { get; set; }
        internal string Fanart { get; set; }
    }

    internal static class MyEmulatorsHelper
    {

        private static bool IsAssemblyOfVersionAvailable(string name, Version ver)
        {
            bool result = false;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly a in assemblies)
            {
                try
                {
                    if (a.GetName().Name == name && a.GetName().Version == ver)
                    {
                        result = true;
                        break;
                    }
                }
                catch { }
            }
            if (!result)
            {
                try
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoad(name);
                    result = true;
                }
                catch (Exception e) { }
            }
            return result;
        }

        private static bool IsPluginEnabled(string name)
        {
            using (MediaPortal.Profile.Settings xmlreader = new MediaPortal.Profile.MPSettings())
            {
                return xmlreader.GetValueAsBool("plugins", name, false);
            }
        }

        internal static bool myEmulatorsPresentAndEnabled = IsAssemblyOfVersionAvailable("MyEmulators2", Version.Parse("0.3.0.98")) && IsPluginEnabled("Emulators 2");

        internal static List<Game> GetGames(int noOfGames)
        {
            if (myEmulatorsPresentAndEnabled)
            {
                try
                {
                    return SafeGetGames(noOfGames);
                }
                catch (Exception e)
                {
                }
            }
            return new List<Game>();
        }

        private static List<Game> SafeGetGames(int noOfGames)
        {
            List<Game> games = new List<Game>();
            List<MyEmulators2.Game> emuGames = MyEmulators2.DB.Instance.GetGames();
            if (emuGames != null && emuGames.Count > 0)
            {
                emuGames = emuGames.Where(g => g.Visible).OrderByDescending(g => g.GameID).ToList<MyEmulators2.Game>();
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
                        games.Add(new Game() { Id = g.GameID, Title = g.Title, Description = g.Description, Boxart = boxart, Fanart = fanart });
                    });
            }
            return games;
        }
    }
}