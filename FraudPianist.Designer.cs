
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
            this.buttonMenu = new System.Windows.Forms.Button();
            this.piano = new piano.Piano();
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
            this.buttonMenu.Location = new System.Drawing.Point(1086, 12);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(186, 49);
            this.buttonMenu.TabIndex = 3;
            this.buttonMenu.Text = "Main menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // piano
            // 
            this.piano.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.piano.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.piano.Location = new System.Drawing.Point(0, 457);
            this.piano.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.piano.Name = "piano";
            this.piano.Size = new System.Drawing.Size(1777, 373);
            this.piano.TabIndex = 0;
            this.piano.Visible = false;
            this.piano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.piano_KeyDown);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 830);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.piano);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(965, 506);
            this.Name = "FormGame";
            this.Text = "Fraud Pianist";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Piano piano;
        private System.Windows.Forms.Button buttonMenu;
    }
}

