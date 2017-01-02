using MediaPortal.GUI.Library;
using System.Collections.Generic;
using System.Threading;
using LatestGames.Model;
using LatestGames.Client;

namespace LatestGames
{
    public class LatestGames : IPlugin, ISetupForm
    {
        private int startupDelay;
        private int timerInterval;
        private int noOfGames;
        private int updateGamesInterval;

        private bool enableLatestGames;
        private bool enableLatestSteamGames;
        private bool orderByLatestPlay;
        private string steamAPIKey;
        private string steamUserId;

        private Timer timer;
        private List<EmulatorsGame> emulatorGames = null;
        private List<SteamGame> steamGames = null;
        private int updateGameCounter;
        private int updateSteamGameCounter;

        #region IPlugin
        void IPlugin.Start()
        {
            LatestGamesSettings.LoadSettings();
            startupDelay = LatestGamesSettings.StartupDelay; // 5000
            timerInterval = LatestGamesSettings.TimerInterval; // 30000 
            noOfGames = LatestGamesSettings.NumberOfGames; // 3
            updateGamesInterval = (LatestGamesSettings.TimerInterval / 1000) * 30; // Update games list every 30000/1000*30 second (every 15 min)
            enableLatestGames = LatestGamesSettings.EnableLatestGames;
            enableLatestSteamGames = LatestGamesSettings.EnableLatestSteamGames;
            orderByLatestPlay = LatestGamesSettings.OrderByLatestPlay;
            steamAPIKey = LatestGamesSettings.SteamAPIKey;
            steamUserId = LatestGamesSettings.SteamUserId;

            GUIPropertyManager.SetProperty("#Latest.Game.Enabled", enableLatestGames.ToString());
            GUIPropertyManager.SetProperty("#Latest.Game.Steam.Enabled", enableLatestSteamGames.ToString());

            updateGameCounter = 0;
            updateSteamGameCounter = 0;
            ClearGamesProperties();
            ClearSteamGamesProperties();
            timer = new Timer(new TimerCallback(UpdateProperties));
            timer.Change(startupDelay, timerInterval);
        }

        void IPlugin.Stop()
        {
            timer.Dispose();
        }

        #endregion

        #region ISetupForm
        
        string ISetupForm.Author()
        {
            return "Ministerk";
        }

        bool ISetupForm.CanEnable()
        {
            return true;
        }

        bool ISetupForm.DefaultEnabled()
        {
            return true;
        }

        string ISetupForm.Description()
        {
            return "Loading latest added My Emulator games into some properties to show in basic home";
        }

        bool ISetupForm.GetHome(out string strButtonText, out string strButtonImage, out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonImage = string.Empty;
            strButtonText = "LatestGames";
            strButtonImageFocus = string.Empty;
            strPictureImage = string.Empty;
            return false;
        }

        int ISetupForm.GetWindowId()
        {
            return 0;
        }

        bool ISetupForm.HasSetup()
        {
            return true;
        }

        string ISetupForm.PluginName()
        {
            return "LatestGames";
        }

        void ISetupForm.ShowPlugin()
        {
            Configuration.LatestGames config = new Configuration.LatestGames();
            config.ShowDialog();
        }

        #endregion

        #region LatestGames

        private void UpdateProperties(object state)
        {
            if (enableLatestGames)
                UpdateGameProperties();
            if (enableLatestSteamGames)
                UpdateSteamGameProperties();
        }

        private void UpdateGameProperties()
        {
            if (emulatorGames == null || updateGameCounter >= updateGamesInterval)
            {
                try
                {
                    emulatorGames = MyEmulators.GetEmulatorsGames(noOfGames, orderByLatestPlay);
                    updateGameCounter = 0;
                    for (int i = 1; i <= emulatorGames.Count; i++)
                    {
                        EmulatorsGame g = emulatorGames[i - 1];
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Boxart", g.Boxart);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Fanart", g.Fanart);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Title", g.Title);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Id", g.Id.ToString());
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Description", g.Description);
                    }
                }
                catch { }
            }
            if (emulatorGames == null || emulatorGames.Count == 0)
            {
                ClearGamesProperties();
            }
            else
            {
                EmulatorsGame g = emulatorGames[updateGameCounter % emulatorGames.Count];
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Boxart", g.Boxart);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Fanart", g.Fanart);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Title", g.Title);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Id", g.Id.ToString());
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Description", g.Description);
            }
            updateGameCounter++;
        }

        private void UpdateSteamGameProperties()
        {
            if (steamGames == null || updateSteamGameCounter >= updateGamesInterval)
            {
                try
                {
                    steamGames = SteamWeb.Instance.GetGamesPlayedLastTwoWeeksOnSteam(steamAPIKey, steamUserId, noOfGames);
                    updateSteamGameCounter = 0;
                    for (int i = 1; i <= steamGames.Count; i++)
                    {
                        SteamGame g = steamGames[i - 1];
                        GUIPropertyManager.SetProperty("#Latest.Game.Steam." + i + ".Logo", g.LogoFile);
                        GUIPropertyManager.SetProperty("#Latest.Game.Steam." + i + ".Title", g.Name);
                    }
                }
                catch { }
            }
            if (steamGames == null || steamGames.Count == 0)
            {
                ClearSteamGamesProperties();
            }
            else
            {
                SteamGame g = steamGames[updateSteamGameCounter % steamGames.Count];
                GUIPropertyManager.SetProperty("#Latest.Game.Steam.Rotate.Logo", g.LogoFile);
                GUIPropertyManager.SetProperty("#Latest.Game.Steam.Rotate.Title", g.Name);
            }
            updateSteamGameCounter++;
        }

        private void ClearGamesProperties()
        {
            for (int i = 1; i <= noOfGames; i++)
            {
                GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Boxart", " ");
                GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Fanart", " ");
                GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Title", " ");
                GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Id", " ");
                GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Description", " ");
            }
            GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Boxart", " ");
            GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Fanart", " ");
            GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Title", " ");
            GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Id", " ");
            GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Description", " ");
        }

        private void ClearSteamGamesProperties()
        {
            for (int i = 1; i <= noOfGames; i++)
            {
                GUIPropertyManager.SetProperty("#Latest.Game.Steam." + i + ".Logo", " ");
                GUIPropertyManager.SetProperty("#Latest.Game.Steam." + i + ".Title", " ");
            }
            GUIPropertyManager.SetProperty("#Latest.Game.Steam.Rotate.Logo", " ");
            GUIPropertyManager.SetProperty("#Latest.Game.Steam.Rotate.Title", " ");
        }

        #endregion

    }
}
