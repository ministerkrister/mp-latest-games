using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LatestGames.Model
{
    [DataContract]
    public class SteamResponse
    {
        [DataMember(Name = "response")]
        public SteamResponseObject Response { get; set; }

    }

    [DataContract]
    public class SteamResponseObject
    {
        [DataMember(Name = "games")]
        public List<SteamGame> Games { get; set; }

        [DataMember(Name = "total_count")]
        public int Count { get; set; }

    }

    [DataContract]
    public class SteamGame
    {
        [DataMember(Name = "appid")]
        public int AppId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "img_logo_url")]
        public string LogoHash { get; set; }
        public string LogoFile
        {
            get
            {
                return System.IO.Path.Combine(LatestGamesSettings.SteamThumbFolder, AppId.ToString(), LogoHash + ".jpg");
            }
        }
        public string LogoUrl
        {
            get
            {
                return string.Format("http://media.steampowered.com/steamcommunity/public/images/apps/{0}/{1}.jpg", AppId, LogoHash);
            }
        }
    }
}
