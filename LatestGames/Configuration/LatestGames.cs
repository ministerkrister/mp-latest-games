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
        public LatestGames()
        {
            InitializeComponent();
            LatestGamesSettings.LoadSettings();
            this.checkBoxEnableEmulators.Checked = LatestGamesSettings.EnableLatestGames;
            this.checkBoxEnableEmulators.Enabled = MyEmulators.MyEmulatorsPresentAndEnabled;
            this.checkBoxEmulatorsShowLatestPlayed.Checked = LatestGamesSettings.OrderByLatestPlay;
            this.checkBoxEmulatorsShowLatestPlayed.Enabled = this.checkBoxEnableEmulators.Enabled;
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

        private void textBoxSteamApiKey_TextChanged(object sender, EventArgs e)
        {
            this.checkBoxEnableSteam.Enabled = !string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && !string.IsNullOrWhiteSpace(this.textBoxSteamId.Text);
            this.checkBoxEnableSteam.Checked = !string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && !string.IsNullOrWhiteSpace(this.textBoxSteamId.Text);
            LatestGamesSettings.SteamAPIKey = textBoxSteamApiKey.Text;
        }

        private void textBoxSteamId_TextChanged(object sender, EventArgs e)
        {
            this.checkBoxEnableSteam.Enabled = !string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && !string.IsNullOrWhiteSpace(this.textBoxSteamId.Text);
            this.checkBoxEnableSteam.Checked = !string.IsNullOrWhiteSpace(this.textBoxSteamApiKey.Text) && !string.IsNullOrWhiteSpace(this.textBoxSteamId.Text);
            LatestGamesSettings.SteamUserId = this.textBoxSteamId.Text;
        }

        private void LatestGames_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.textBoxSteamApiKey.Text = this.textBoxSteamApiKey.Text.Trim();
            this.textBoxSteamId.Text = this.textBoxSteamId.Text.Trim();
            LatestGamesSettings.SaveSettings();
        }
    }
}
