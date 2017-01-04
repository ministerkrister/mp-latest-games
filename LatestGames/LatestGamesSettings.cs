using LatestGames.Client;
using MediaPortal.Profile;

namespace LatestGames
{
    internal class LatestGamesSettings
    {
        #region App Properties

        internal static int StartupDelay { get { return 5000; } }
        internal static int TimerInterval { get { return 30000; } }
        internal static int NumberOfGames { get { return 3; } }

        internal static readonly string SteamThumbFolder = MediaPortal.Configuration.Config.GetSubFolder(MediaPortal.Configuration.Config.Dir.Thumbs, @"LatestGames\Steam");

        #endregion

        #region Constants

        private const string cLatestGames = "LatestGames";
        private const string cEnableLatestGames = "EnableLatestGames";
        private const string cOrderByLatestPlay = "OrderByLatestPlay";
        private const string cEnableLatestSteamGames = "EnableLatestSteamGames";
        private const string cSteamAPIKey = "SteamAPIKey";
        private const string cSteamUserId = "SteamUserId";

        #endregion

        #region Persisted settings

        internal static bool EnableLatestGames { get; set; }
        internal static bool OrderByLatestPlay { get; set; }
        internal static bool EnableLatestSteamGames { get; set; }
        internal static string SteamAPIKey { get; set; }
        internal static string SteamUserId { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Loads the Settings
        /// </summary>
        internal static void LoadSettings(bool reload = false)
        {
            using (Settings xmlreader = new MPSettings())
            {
                EnableLatestGames = xmlreader.GetValueAsBool(cLatestGames, cEnableLatestGames, true);
                OrderByLatestPlay = xmlreader.GetValueAsBool(cLatestGames, cOrderByLatestPlay, false);
                EnableLatestSteamGames = xmlreader.GetValueAsBool(cLatestGames, cEnableLatestSteamGames, false);
                SteamAPIKey = xmlreader.GetValueAsString(cLatestGames, cSteamAPIKey, string.Empty);
                SteamUserId = xmlreader.GetValueAsString(cLatestGames, cSteamUserId, string.Empty);
            }
            EnableLatestGames = EnableLatestGames && MyEmulators.MyEmulatorsPresentAndEnabled;
            EnableLatestSteamGames = EnableLatestSteamGames && !string.IsNullOrWhiteSpace(SteamAPIKey) && !string.IsNullOrWhiteSpace(SteamUserId);
        }

        /// <summary>
        /// Saves the Settings
        /// </summary>
        internal static void SaveSettings()
        {
            using (Settings xmlwriter = new MPSettings())
            {
                xmlwriter.SetValueAsBool(cLatestGames, cEnableLatestGames, EnableLatestGames);
                xmlwriter.SetValueAsBool(cLatestGames, cOrderByLatestPlay, OrderByLatestPlay);
                xmlwriter.SetValueAsBool(cLatestGames, cEnableLatestSteamGames, EnableLatestSteamGames);
                xmlwriter.SetValue(cLatestGames, cSteamAPIKey, SteamAPIKey);
                xmlwriter.SetValue(cLatestGames, cSteamUserId, SteamUserId);
            }
        }

        #endregion


    }
}
