﻿namespace Ksu.Cis300.WordLookup
{
    partial class UserInterface
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
            this.uxLookUp = new System.Windows.Forms.Button();
            this.uxWord = new System.Windows.Forms.TextBox();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxLookUp
            // 
            this.uxLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookUp.Location = new System.Drawing.Point(15, 117);
            this.uxLookUp.Name = "uxLookUp";
            this.uxLookUp.Size = new System.Drawing.Size(216, 56);
            this.uxLookUp.TabIndex = 14;
            this.uxLookUp.Text = "Look up Word";
            this.uxLookUp.UseVisualStyleBackColor = true;
            // 
            // uxWord
            // 
            this.uxWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxWord.Location = new System.Drawing.Point(16, 82);
            this.uxWord.Name = "uxWord";
            this.uxWord.Size = new System.Drawing.Size(215, 29);
            this.uxWord.TabIndex = 13;
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpen.Location = new System.Drawing.Point(16, 20);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(215, 56);
            this.uxOpen.TabIndex = 12;
            this.uxOpen.Text = "Open Dictionary";
            this.uxOpen.UseVisualStyleBackColor = true;
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Text Files|*.txt";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 193);
            this.Controls.Add(this.uxLookUp);
            this.Controls.Add(this.uxWord);
            this.Controls.Add(this.uxOpen);
            this.Name = "UserInterface";
            this.Text = "Word Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxLookUp;
        private System.Windows.Forms.TextBox uxWord;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

