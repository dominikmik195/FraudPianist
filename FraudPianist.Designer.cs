﻿
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
            this.piano = new piano.Piano();
            this.SuspendLayout();
            // 
            // piano
            // 
            this.piano.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.piano.Location = new System.Drawing.Point(0, 371);
            this.piano.Margin = new System.Windows.Forms.Padding(2);
            this.piano.Name = "piano";
            this.piano.Size = new System.Drawing.Size(1333, 303);
            this.piano.TabIndex = 0;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 674);
            this.Controls.Add(this.piano);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(728, 420);
            this.Name = "FormGame";
            this.Text = "Fraud Pianist";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormGame_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Piano piano;
    }
}
