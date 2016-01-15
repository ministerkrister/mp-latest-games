using MediaPortal.GUI.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LatestGames
{
    public class LatestGames : IPlugin, ISetupForm
    {
        private Timer timer;
        private const int startupDelay = 5000;
        private const int timerInterval = 30000;
        private const int noOfGames = 3;

        private List<Game> games = null;
        private int updateCounter = 0;
        private const int updateGamesInterval = 60; // Update games list every 30000/1000*60 second (every 30 min)

        #region IPlugin
        void IPlugin.Start()
        {
            ClearGamesProperties();
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
            return false;
        }

        string ISetupForm.PluginName()
        {
            return "LatestGames";
        }

        void ISetupForm.ShowPlugin()
        {
            return;
        }
        #endregion

        #region LatestGames

        private void UpdateProperties(object state)
        {
            if (games == null || updateCounter >= updateGamesInterval)
            {
                games = MyEmulatorsHelper.GetGames(noOfGames);
                updateCounter = 0;
                if (games != null)
                {
                    for (int i = 1; i <= games.Count; i++)
                    {
                        Game g = games[i - 1];
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Boxart", g.Boxart);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Fanart", g.Fanart);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Title", g.Title);
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Id", g.Id.ToString());
                        GUIPropertyManager.SetProperty("#Latest.Game." + i + ".Description", g.Description);
                    }
                }
            }
            if (games == null || games.Count == 0)
            {
                ClearGamesProperties();
            }
            else
            {
                Game g = games[updateCounter % games.Count];
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Boxart", g.Boxart);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Fanart", g.Fanart);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Title", g.Title);
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Id", g.Id.ToString());
                GUIPropertyManager.SetProperty("#Latest.Game.Rotate.Description", g.Description);
            }
            updateCounter++;
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

        #endregion

    }
}
