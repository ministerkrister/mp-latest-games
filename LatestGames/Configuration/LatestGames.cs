using LatestGames.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LatestGames.Configuration
{
    public partial class LatestGames : Form
    {
        private const string installOrEnableMyEmulators2 = "Please install and/or enable the My Emulators 2 plugin";
        private const string enableLatestMyEmulators2 = "Enable Latest Games for My Emulators 2";
        public LatestGames()
        {
            InitializeComponent();
            bool myEmulatorsPresentAndEnabled = MyEmulators.MyEmulatorsPresentAndEnabled;

            LatestGamesSettings.LoadSettings();
            this.checkBoxEnableEmulators.Checked = LatestGamesSettings.EnableLatestGames;
            this.checkBoxEnableEmulators.Enabled = myEmulatorsPresentAndEnabled;
            this.checkBoxEnableEmulators.Text = myEmulatorsPresentAndEnabled ? enableLatestMyEmulators2 : installOrEnableMyEmulators2;
            this.checkBoxEmulatorsShowLatestPlayed.Checked = LatestGamesSettings.OrderByLatestPlay;
            this.checkBoxEmulatorsShowLatestPlayed.Enabled = myEmulatorsPresentAndEnabled;
            this.textBoxSteamApiKey.Text = LatestGamesSettings.SteamAPIKey.Trim();
            this.textBoxSteamId.Text = LatestGamesSettings.SteamUserId.Trim();
            this.checkBoxEnableSteam.Checked = LatestGamesSettings.EnableLatestSteamGames;
            this.checkBoxEnableSteam.Enabled = !string.IsNullOrEmpty(this.textBoxSteamApiKey.Text) && !string.IsNullOrEmpty(this.textBoxSteamId.Text);
        }

        private void checkBoxEnableEmulators_CheckedChanged(object sender, EventArgs e)
        {
            LatestGamesSettings.EnableLatestGames = checkBoxEnableEmulators.Checked;
        }

        private void checkBoxEmulatorsShowLatestPlayed_CheckedChanged(object sender, EventArgs e)
        {
            LatestGamesSettings.OrderByLatestPlay = checkBoxEmulatorsShowLatestPlayed.Checked;
        }

        private void checkBoxEnableSteam_CheckedChanged(object sender, EventArgs e)
        {
            LatestGamesSettings.EnableLatestSteamGames = checkBoxEnableSteam.Checked;
        }

        private void toggleEnableSteam()
        {
            if (!this.checkBoxEnableSteam.Enabled && !string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && !string.IsNullOrWhiteSpace(this.textBoxSteamId.Text))
            {
                this.checkBoxEnableSteam.Enabled = true;
                this.checkBoxEnableSteam.Checked = true;
            }
            else if (this.checkBoxEnableSteam.Enabled && string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && string.IsNullOrWhiteSpace(this.textBoxSteamId.Text))
            {
                this.checkBoxEnableSteam.Enabled = false;
                this.checkBoxEnableSteam.Checked = false;
            }
        }
        private void textBoxSteamApiKey_TextChanged(object sender, EventArgs e)
        {
            toggleEnableSteam();
            LatestGamesSettings.SteamAPIKey = textBoxSteamApiKey.Text;
        }

        private void textBoxSteamId_TextChanged(object sender, EventArgs e)
        {
            toggleEnableSteam();
            LatestGamesSettings.SteamUserId = this.textBoxSteamId.Text;
        }

        private void LatestGames_FormClosing(object sender, FormClosingEventArgs e)
        {
            LatestGamesSettings.SaveSettings();
        }
    }
}
