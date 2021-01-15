
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
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelPoruka = new System.Windows.Forms.Label();
            this.labelBodovi = new System.Windows.Forms.Label();
            this.tilesBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelLvlMsg = new System.Windows.Forms.Label();
            this.piano = new piano.Piano();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackColor = System.Drawing.Color.GhostWhite;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.buttonMenu.FlatAppearance.BorderSize = 5;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.Location = new System.Drawing.Point(44, 457);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(194, 40);
            this.buttonMenu.TabIndex = 3;
            this.buttonMenu.Text = "Main menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.labelLvlMsg);
            this.panel1.Controls.Add(this.labelPass);
            this.panel1.Controls.Add(this.labelPercent);
            this.panel1.Controls.Add(this.labelResult);
            this.panel1.Controls.Add(this.labelPoruka);
            this.panel1.Controls.Add(this.labelBodovi);
            this.panel1.Controls.Add(this.buttonMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1060, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 671);
            this.panel1.TabIndex = 4;
            // 
            // labelPass
            // 
            this.labelPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPass.BackColor = System.Drawing.Color.Azure;
            this.labelPass.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(0, 258);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(271, 43);
            this.labelPass.TabIndex = 8;
            this.labelPass.Text = "pass/fail";
            this.labelPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPercent
            // 
            this.labelPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPercent.BackColor = System.Drawing.Color.Azure;
            this.labelPercent.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPercent.Location = new System.Drawing.Point(3, 215);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(271, 43);
            this.labelPercent.TabIndex = 7;
            this.labelPercent.Text = "percent";
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.BackColor = System.Drawing.Color.Azure;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(0, 172);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(271, 43);
            this.labelResult.TabIndex = 6;
            this.labelResult.Text = "Result:";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoruka
            // 
            this.labelPoruka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoruka.BackColor = System.Drawing.Color.Azure;
            this.labelPoruka.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoruka.Location = new System.Drawing.Point(6, 86);
            this.labelPoruka.Name = "labelPoruka";
            this.labelPoruka.Size = new System.Drawing.Size(265, 50);
            this.labelPoruka.TabIndex = 5;
            this.labelPoruka.Text = "label";
            this.labelPoruka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBodovi
            // 
            this.labelBodovi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBodovi.BackColor = System.Drawing.Color.AliceBlue;
            this.labelBodovi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBodovi.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBodovi.Location = new System.Drawing.Point(69, 25);
            this.labelBodovi.Name = "labelBodovi";
            this.labelBodovi.Size = new System.Drawing.Size(140, 50);
            this.labelBodovi.TabIndex = 4;
            this.labelBodovi.Text = "0";
            this.labelBodovi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tilesBox
            // 
            this.tilesBox.BackColor = System.Drawing.Color.LightCyan;
            this.tilesBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilesBox.Location = new System.Drawing.Point(0, 0);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(1060, 366);
            this.tilesBox.TabIndex = 5;
            this.tilesBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 700;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labelLvlMsg
            // 
            this.labelLvlMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLvlMsg.BackColor = System.Drawing.Color.Azure;
            this.labelLvlMsg.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLvlMsg.Location = new System.Drawing.Point(0, 323);
            this.labelLvlMsg.Name = "labelLvlMsg";
            this.labelLvlMsg.Size = new System.Drawing.Size(271, 111);
            this.labelLvlMsg.TabIndex = 9;
            this.labelLvlMsg.Text = "level message";
            this.labelLvlMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // piano
            // 
            this.piano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.piano.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.piano.Location = new System.Drawing.Point(0, 368);
            this.piano.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.piano.Name = "piano";
            this.piano.Size = new System.Drawing.Size(1055, 303);
            this.piano.TabIndex = 0;
            this.piano.Visible = false;
            this.piano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.piano_KeyDown);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1334, 671);
            this.Controls.Add(this.tilesBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.piano);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(728, 418);
            this.Name = "FormGame";
            this.Text = "Fraud Pianist";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Piano piano;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox tilesBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelBodovi;
        private System.Windows.Forms.Label labelPoruka;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelLvlMsg;
    }
}

