
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
            this.tilesBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.piano = new piano.Piano();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackColor = System.Drawing.Color.Snow;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.buttonMenu.FlatAppearance.BorderSize = 5;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.Location = new System.Drawing.Point(69, 11);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(140, 40);
            this.buttonMenu.TabIndex = 3;
            this.buttonMenu.Text = "Main menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1059, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 674);
            this.panel1.TabIndex = 4;
            // 
            // tilesBox
            // 
            this.tilesBox.BackColor = System.Drawing.Color.LightCyan;
            this.tilesBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilesBox.Location = new System.Drawing.Point(0, 0);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(1059, 366);
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
            // piano
            // 
            this.piano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.piano.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.piano.Location = new System.Drawing.Point(0, 371);
            this.piano.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.piano.Name = "piano";
            this.piano.Size = new System.Drawing.Size(1054, 303);
            this.piano.TabIndex = 0;
            this.piano.Visible = false;
            this.piano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.piano_KeyDown);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 674);
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
    }
}

