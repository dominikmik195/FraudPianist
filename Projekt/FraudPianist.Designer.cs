namespace piano
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panelScore = new System.Windows.Forms.Panel();
            this.labelPercent = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.labelLvlMsg = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelPoruka = new System.Windows.Forms.Label();
            this.labelBodovi = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.piano = new piano.Piano();
            this.tilesBox = new System.Windows.Forms.PictureBox();
            this.panelScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMenu.BackColor = System.Drawing.Color.Azure;
            this.buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Image = global::piano.Properties.Resources.mainmanji;
            this.buttonMenu.Location = new System.Drawing.Point(156, 624);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(75, 71);
            this.buttonMenu.TabIndex = 3;
            this.buttonMenu.TabStop = false;
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // panelScore
            // 
            this.panelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScore.BackColor = System.Drawing.Color.Azure;
            this.panelScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelScore.Controls.Add(this.labelPercent);
            this.panelScore.Controls.Add(this.restartButton);
            this.panelScore.Controls.Add(this.buttonMenu);
            this.panelScore.Controls.Add(this.labelLvlMsg);
            this.panelScore.Controls.Add(this.labelPass);
            this.panelScore.Controls.Add(this.labelPoruka);
            this.panelScore.Controls.Add(this.labelBodovi);
            this.panelScore.Controls.Add(this.labelLevel);
            this.panelScore.Location = new System.Drawing.Point(1057, -1);
            this.panelScore.Margin = new System.Windows.Forms.Padding(0);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(392, 773);
            this.panelScore.TabIndex = 4;
            // 
            // labelPercent
            // 
            this.labelPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPercent.BackColor = System.Drawing.Color.Azure;
            this.labelPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPercent.Font = new System.Drawing.Font("Lucida Handwriting", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPercent.Location = new System.Drawing.Point(108, 213);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(173, 100);
            this.labelPercent.TabIndex = 7;
            this.labelPercent.Text = "10,00%";
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            this.restartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.restartButton.BackColor = System.Drawing.Color.Orchid;
            this.restartButton.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(108, 496);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(173, 100);
            this.restartButton.TabIndex = 10;
            this.restartButton.Text = "button1";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // labelLvlMsg
            // 
            this.labelLvlMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLvlMsg.BackColor = System.Drawing.Color.Azure;
            this.labelLvlMsg.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLvlMsg.Location = new System.Drawing.Point(63, 408);
            this.labelLvlMsg.Name = "labelLvlMsg";
            this.labelLvlMsg.Size = new System.Drawing.Size(269, 85);
            this.labelLvlMsg.TabIndex = 9;
            this.labelLvlMsg.Text = "level message";
            this.labelLvlMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPass
            // 
            this.labelPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPass.BackColor = System.Drawing.Color.Azure;
            this.labelPass.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(64, 325);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(258, 77);
            this.labelPass.TabIndex = 8;
            this.labelPass.Text = "pass/fail";
            this.labelPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoruka
            // 
            this.labelPoruka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoruka.BackColor = System.Drawing.Color.Azure;
            this.labelPoruka.Font = new System.Drawing.Font("Lucida Handwriting", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoruka.Location = new System.Drawing.Point(50, 226);
            this.labelPoruka.Name = "labelPoruka";
            this.labelPoruka.Size = new System.Drawing.Size(290, 120);
            this.labelPoruka.TabIndex = 5;
            this.labelPoruka.Text = "label";
            this.labelPoruka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBodovi
            // 
            this.labelBodovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBodovi.BackColor = System.Drawing.Color.Azure;
            this.labelBodovi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBodovi.Font = new System.Drawing.Font("Lucida Handwriting", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBodovi.Location = new System.Drawing.Point(110, 97);
            this.labelBodovi.Name = "labelBodovi";
            this.labelBodovi.Size = new System.Drawing.Size(173, 100);
            this.labelBodovi.TabIndex = 4;
            this.labelBodovi.Text = "0";
            this.labelBodovi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLevel
            // 
            this.labelLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLevel.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.Location = new System.Drawing.Point(52, 41);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(289, 43);
            this.labelLevel.TabIndex = 11;
            this.labelLevel.Text = "level";
            this.labelLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // piano
            // 
            this.piano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.piano.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.piano.Location = new System.Drawing.Point(2, 475);
            this.piano.Margin = new System.Windows.Forms.Padding(0);
            this.piano.Name = "piano";
            this.piano.Size = new System.Drawing.Size(1055, 296);
            this.piano.TabIndex = 0;
            this.piano.Visible = false;
            // 
            // tilesBox
            // 
            this.tilesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tilesBox.BackColor = System.Drawing.Color.Azure;
            this.tilesBox.Location = new System.Drawing.Point(-1, -2);
            this.tilesBox.Margin = new System.Windows.Forms.Padding(0);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(1058, 477);
            this.tilesBox.TabIndex = 5;
            this.tilesBox.TabStop = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1448, 771);
            this.Controls.Add(this.tilesBox);
            this.Controls.Add(this.panelScore);
            this.Controls.Add(this.piano);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(728, 800);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fraud Pianist";
            this.SizeChanged += new System.EventHandler(this.FormGame_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.panelScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Piano piano;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Panel panelScore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelBodovi;
        private System.Windows.Forms.Label labelPoruka;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelLvlMsg;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.PictureBox tilesBox;
    }
}