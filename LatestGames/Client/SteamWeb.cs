using LatestGames.Extensions;
using LatestGames.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LatestGames.Client
{
    internal class SteamWeb
    {
        private WebClient webClient;
        #region Singleton
        protected SteamWeb()
        {
            webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
        }
        protected static SteamWeb instance = null;
        internal static SteamWeb Instance
        {
            get
            {
                if (instance == null) instance = new SteamWeb();
                return instance;
            }
        }

        #endregion

        internal List<SteamGame> GetGamesPlayedLastTwoWeeksOnSteam(string apiKey, string userId, int noOfGames)
        {
            string url = string.Format("http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v1/?key={0}&steamid={1}&format=json", apiKey, userId);
            string data = webClient.DownloadString(new Uri(url));
            SteamResponse response = data.FromJSON<SteamResponse>();
            List<SteamGame> games = response.Response.Games ?? new List<SteamGame>();
            games = games.OrderBy(g => Guid.NewGuid()).ToList<SteamGame>() ;
            games = games.GetRange(0, games.Count >= noOfGames ? noOfGames : games.Count);
            foreach(SteamGame game in games)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(game.LogoFile));
                if (!File.Exists(game.LogoFile))
                {
                    webClient.DownloadFile(game.LogoUrl, game.LogoFile);
                }
            }
            return games;
        }
    }
}
