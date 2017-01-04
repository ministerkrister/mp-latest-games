namespace LatestGames.Configuration
{
    partial class LatestGames
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelEmulatorsHeader = new System.Windows.Forms.Label();
            this.labelSteamHeader = new System.Windows.Forms.Label();
            this.labelSteamApiKey = new System.Windows.Forms.Label();
            this.textBoxSteamApiKey = new System.Windows.Forms.TextBox();
            this.labelSteamUserId = new System.Windows.Forms.Label();
            this.textBoxSteamId = new System.Windows.Forms.TextBox();
            this.checkBoxEmulatorsShowLatestPlayed = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableEmulators = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSteam = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelEmulatorsHeader
            // 
            this.labelEmulatorsHeader.AutoSize = true;
            this.labelEmulatorsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmulatorsHeader.Location = new System.Drawing.Point(9, 9);
            this.labelEmulatorsHeader.Name = "labelEmulatorsHeader";
            this.labelEmulatorsHeader.Size = new System.Drawing.Size(69, 13);
            this.labelEmulatorsHeader.TabIndex = 0;
            this.labelEmulatorsHeader.Text = "Emulators2";
            // 
            // labelSteamHeader
            // 
            this.labelSteamHeader.AutoSize = true;
            this.labelSteamHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSteamHeader.Location = new System.Drawing.Point(9, 84);
            this.labelSteamHeader.Name = "labelSteamHeader";
            this.labelSteamHeader.Size = new System.Drawing.Size(60, 13);
            this.labelSteamHeader.TabIndex = 1;
            this.labelSteamHeader.Text = "MPSteam";
            // 
            // labelSteamApiKey
            // 
            this.labelSteamApiKey.AutoSize = true;
            this.labelSteamApiKey.Location = new System.Drawing.Point(9, 120);
            this.labelSteamApiKey.Name = "labelSteamApiKey";
            this.labelSteamApiKey.Size = new System.Drawing.Size(296, 13);
            this.labelSteamApiKey.TabIndex = 3;
            this.labelSteamApiKey.Text = "Api Key (get one @ http://steamcommunity.com/dev/apikey)";
            // 
            // textBoxSteamApiKey
            // 
            this.textBoxSteamApiKey.Location = new System.Drawing.Point(12, 145);
            this.textBoxSteamApiKey.Name = "textBoxSteamApiKey";
            this.textBoxSteamApiKey.Size = new System.Drawing.Size(382, 20);
            this.textBoxSteamApiKey.TabIndex = 4;
            this.textBoxSteamApiKey.TextChanged += new System.EventHandler(this.textBoxSteamApiKey_TextChanged);
            // 
            // labelSteamUserId
            // 
            this.labelSteamUserId.AutoSize = true;
            this.labelSteamUserId.Location = new System.Drawing.Point(9, 177);
            this.labelSteamUserId.Name = "labelSteamUserId";
            this.labelSteamUserId.Size = new System.Drawing.Size(279, 13);
            this.labelSteamUserId.TabIndex = 5;
            this.labelSteamUserId.Text = "steamID64 (search for yours @ https://steamid.io/lookup)";
            // 
            // textBoxSteamId
            // 
            this.textBoxSteamId.Location = new System.Drawing.Point(12, 204);
            this.textBoxSteamId.Name = "textBoxSteamId";
            this.textBoxSteamId.Size = new System.Drawing.Size(382, 20);
            this.textBoxSteamId.TabIndex = 6;
            this.textBoxSteamId.TextChanged += new System.EventHandler(this.textBoxSteamId_TextChanged);
            // 
            // checkBoxEmulatorsShowLatestPlayed
            // 
            this.checkBoxEmulatorsShowLatestPlayed.AutoSize = true;
            this.checkBoxEmulatorsShowLatestPlayed.Location = new System.Drawing.Point(12, 51);
            this.checkBoxEmulatorsShowLatestPlayed.Name = "checkBoxEmulatorsShowLatestPlayed";
            this.checkBoxEmulatorsShowLatestPlayed.Size = new System.Drawing.Size(235, 17);
            this.checkBoxEmulatorsShowLatestPlayed.TabIndex = 2;
            this.checkBoxEmulatorsShowLatestPlayed.Text = "Show Latest Played instead of Latest Added";
            this.checkBoxEmulatorsShowLatestPlayed.UseVisualStyleBackColor = true;
            this.checkBoxEmulatorsShowLatestPlayed.CheckedChanged += new System.EventHandler(this.checkBoxEmulatorsShowLatestPlayed_CheckedChanged);
            // 
            // checkBoxEnableEmulators
            // 
            this.checkBoxEnableEmulators.AutoSize = true;
            this.checkBoxEnableEmulators.Location = new System.Drawing.Point(12, 28);
            this.checkBoxEnableEmulators.Name = "checkBoxEnableEmulators";
            this.checkBoxEnableEmulators.Size = new System.Drawing.Size(217, 17);
            this.checkBoxEnableEmulators.TabIndex = 7;
            this.checkBoxEnableEmulators.Text = "Enable Latest Games for My Emulators 2";
            this.checkBoxEnableEmulators.UseVisualStyleBackColor = true;
            this.checkBoxEnableEmulators.CheckedChanged += new System.EventHandler(this.checkBoxEnableEmulators_CheckedChanged);
            // 
            // checkBoxEnableSteam
            // 
            this.checkBoxEnableSteam.AutoSize = true;
            this.checkBoxEnableSteam.Location = new System.Drawing.Point(12, 100);
            this.checkBoxEnableSteam.Name = "checkBoxEnableSteam";
            this.checkBoxEnableSteam.Size = new System.Drawing.Size(382, 17);
            this.checkBoxEnableSteam.TabIndex = 8;
            this.checkBoxEnableSteam.Text = "Enable Latest Played Games on Steam (Api Key and steamID64 mandatory)";
            this.checkBoxEnableSteam.UseVisualStyleBackColor = true;
            this.checkBoxEnableSteam.CheckedChanged += new System.EventHandler(this.checkBoxEnableSteam_CheckedChanged);
            // 
            // LatestGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 241);
            this.Controls.Add(this.checkBoxEnableSteam);
            this.Controls.Add(this.checkBoxEnableEmulators);
            this.Controls.Add(this.labelSteamApiKey);
            this.Controls.Add(this.textBoxSteamApiKey);
            this.Controls.Add(this.checkBoxEmulatorsShowLatestPlayed);
            this.Controls.Add(this.labelSteamUserId);
            this.Controls.Add(this.textBoxSteamId);
            this.Controls.Add(this.labelEmulatorsHeader);
            this.Controls.Add(this.labelSteamHeader);
            this.Name = "LatestGames";
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LatestGames_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEmulatorsHeader;
        private System.Windows.Forms.Label labelSteamHeader;
        private System.Windows.Forms.Label labelSteamApiKey;
        private System.Windows.Forms.TextBox textBoxSteamApiKey;
        private System.Windows.Forms.Label labelSteamUserId;
        private System.Windows.Forms.TextBox textBoxSteamId;
        private System.Windows.Forms.CheckBox checkBoxEmulatorsShowLatestPlayed;
        private System.Windows.Forms.CheckBox checkBoxEnableEmulators;
        private System.Windows.Forms.CheckBox checkBoxEnableSteam;
    }
}