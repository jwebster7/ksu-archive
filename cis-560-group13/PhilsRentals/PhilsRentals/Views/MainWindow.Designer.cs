namespace PhilsRentals
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.uxPanelCreateAccount = new System.Windows.Forms.Panel();
            this.uxButtonCreateAccount = new System.Windows.Forms.Button();
            this.uxPanelMenu = new System.Windows.Forms.Panel();
            this.uxPanelReturnMovie = new System.Windows.Forms.Panel();
            this.uxButtonReturnMovie = new System.Windows.Forms.Button();
            this.uxPanelSelectAccount = new System.Windows.Forms.Panel();
            this.uxButtonSelectAccount = new System.Windows.Forms.Button();
            this.uxPanelBrowseMovie = new System.Windows.Forms.Panel();
            this.uxButtonBrowseMovie = new System.Windows.Forms.Button();
            this.uxLabelTitle = new System.Windows.Forms.Label();
            this.uxPanelAddMovie = new System.Windows.Forms.Panel();
            this.uxButtonAddMovie = new System.Windows.Forms.Button();
            this.uxPanelDeleteAccount = new System.Windows.Forms.Panel();
            this.uxButtonDeleteAccount = new System.Windows.Forms.Button();
            this.uxPanelModifyAccount = new System.Windows.Forms.Panel();
            this.uxButtonModifyAccount = new System.Windows.Forms.Button();
            this.uxPanelRentMovie = new System.Windows.Forms.Panel();
            this.uxButtonRentMovie = new System.Windows.Forms.Button();
            this.uxPanelMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uxPanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPanelCreateAccount
            // 
            this.uxPanelCreateAccount.BackColor = System.Drawing.Color.Silver;
            this.uxPanelCreateAccount.ForeColor = System.Drawing.Color.White;
            this.uxPanelCreateAccount.Location = new System.Drawing.Point(0, 180);
            this.uxPanelCreateAccount.Name = "uxPanelCreateAccount";
            this.uxPanelCreateAccount.Size = new System.Drawing.Size(5, 35);
            this.uxPanelCreateAccount.TabIndex = 1;
            // 
            // uxButtonCreateAccount
            // 
            this.uxButtonCreateAccount.FlatAppearance.BorderSize = 0;
            this.uxButtonCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonCreateAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonCreateAccount.ForeColor = System.Drawing.Color.White;
            this.uxButtonCreateAccount.Location = new System.Drawing.Point(0, 180);
            this.uxButtonCreateAccount.Name = "uxButtonCreateAccount";
            this.uxButtonCreateAccount.Size = new System.Drawing.Size(200, 35);
            this.uxButtonCreateAccount.TabIndex = 0;
            this.uxButtonCreateAccount.Text = "Create Account";
            this.uxButtonCreateAccount.UseVisualStyleBackColor = true;
            this.uxButtonCreateAccount.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelMenu
            // 
            this.uxPanelMenu.BackColor = System.Drawing.Color.Purple;
            this.uxPanelMenu.Controls.Add(this.pictureBox1);
            this.uxPanelMenu.Controls.Add(this.uxPanelReturnMovie);
            this.uxPanelMenu.Controls.Add(this.uxButtonReturnMovie);
            this.uxPanelMenu.Controls.Add(this.uxPanelSelectAccount);
            this.uxPanelMenu.Controls.Add(this.uxButtonSelectAccount);
            this.uxPanelMenu.Controls.Add(this.uxPanelBrowseMovie);
            this.uxPanelMenu.Controls.Add(this.uxButtonBrowseMovie);
            this.uxPanelMenu.Controls.Add(this.uxLabelTitle);
            this.uxPanelMenu.Controls.Add(this.uxPanelAddMovie);
            this.uxPanelMenu.Controls.Add(this.uxButtonAddMovie);
            this.uxPanelMenu.Controls.Add(this.uxPanelDeleteAccount);
            this.uxPanelMenu.Controls.Add(this.uxButtonDeleteAccount);
            this.uxPanelMenu.Controls.Add(this.uxPanelModifyAccount);
            this.uxPanelMenu.Controls.Add(this.uxButtonModifyAccount);
            this.uxPanelMenu.Controls.Add(this.uxPanelRentMovie);
            this.uxPanelMenu.Controls.Add(this.uxButtonRentMovie);
            this.uxPanelMenu.Controls.Add(this.uxPanelCreateAccount);
            this.uxPanelMenu.Controls.Add(this.uxButtonCreateAccount);
            this.uxPanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.uxPanelMenu.ForeColor = System.Drawing.Color.Orange;
            this.uxPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.uxPanelMenu.Name = "uxPanelMenu";
            this.uxPanelMenu.Size = new System.Drawing.Size(200, 553);
            this.uxPanelMenu.TabIndex = 5;
            // 
            // uxPanelReturnMovie
            // 
            this.uxPanelReturnMovie.BackColor = System.Drawing.Color.Silver;
            this.uxPanelReturnMovie.ForeColor = System.Drawing.Color.White;
            this.uxPanelReturnMovie.Location = new System.Drawing.Point(0, 145);
            this.uxPanelReturnMovie.Name = "uxPanelReturnMovie";
            this.uxPanelReturnMovie.Size = new System.Drawing.Size(5, 35);
            this.uxPanelReturnMovie.TabIndex = 18;
            // 
            // uxButtonReturnMovie
            // 
            this.uxButtonReturnMovie.Enabled = false;
            this.uxButtonReturnMovie.FlatAppearance.BorderSize = 0;
            this.uxButtonReturnMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonReturnMovie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonReturnMovie.ForeColor = System.Drawing.Color.White;
            this.uxButtonReturnMovie.Location = new System.Drawing.Point(0, 145);
            this.uxButtonReturnMovie.Name = "uxButtonReturnMovie";
            this.uxButtonReturnMovie.Size = new System.Drawing.Size(200, 35);
            this.uxButtonReturnMovie.TabIndex = 17;
            this.uxButtonReturnMovie.Text = "Return Movies";
            this.uxButtonReturnMovie.UseVisualStyleBackColor = true;
            this.uxButtonReturnMovie.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelSelectAccount
            // 
            this.uxPanelSelectAccount.BackColor = System.Drawing.Color.Silver;
            this.uxPanelSelectAccount.ForeColor = System.Drawing.Color.White;
            this.uxPanelSelectAccount.Location = new System.Drawing.Point(0, 75);
            this.uxPanelSelectAccount.Name = "uxPanelSelectAccount";
            this.uxPanelSelectAccount.Size = new System.Drawing.Size(5, 35);
            this.uxPanelSelectAccount.TabIndex = 16;
            this.uxPanelSelectAccount.Visible = false;
            // 
            // uxButtonSelectAccount
            // 
            this.uxButtonSelectAccount.FlatAppearance.BorderSize = 0;
            this.uxButtonSelectAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonSelectAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonSelectAccount.ForeColor = System.Drawing.Color.White;
            this.uxButtonSelectAccount.Location = new System.Drawing.Point(0, 75);
            this.uxButtonSelectAccount.Name = "uxButtonSelectAccount";
            this.uxButtonSelectAccount.Size = new System.Drawing.Size(200, 35);
            this.uxButtonSelectAccount.TabIndex = 15;
            this.uxButtonSelectAccount.Text = "Select Account";
            this.uxButtonSelectAccount.UseVisualStyleBackColor = true;
            this.uxButtonSelectAccount.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelBrowseMovie
            // 
            this.uxPanelBrowseMovie.BackColor = System.Drawing.Color.Silver;
            this.uxPanelBrowseMovie.ForeColor = System.Drawing.Color.White;
            this.uxPanelBrowseMovie.Location = new System.Drawing.Point(0, 285);
            this.uxPanelBrowseMovie.Name = "uxPanelBrowseMovie";
            this.uxPanelBrowseMovie.Size = new System.Drawing.Size(5, 35);
            this.uxPanelBrowseMovie.TabIndex = 14;
            // 
            // uxButtonBrowseMovie
            // 
            this.uxButtonBrowseMovie.FlatAppearance.BorderSize = 0;
            this.uxButtonBrowseMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonBrowseMovie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonBrowseMovie.ForeColor = System.Drawing.Color.White;
            this.uxButtonBrowseMovie.Location = new System.Drawing.Point(0, 285);
            this.uxButtonBrowseMovie.Name = "uxButtonBrowseMovie";
            this.uxButtonBrowseMovie.Size = new System.Drawing.Size(200, 35);
            this.uxButtonBrowseMovie.TabIndex = 13;
            this.uxButtonBrowseMovie.Text = "Browse Movies";
            this.uxButtonBrowseMovie.UseVisualStyleBackColor = true;
            this.uxButtonBrowseMovie.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxLabelTitle
            // 
            this.uxLabelTitle.AutoSize = true;
            this.uxLabelTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabelTitle.ForeColor = System.Drawing.Color.White;
            this.uxLabelTitle.Location = new System.Drawing.Point(12, 21);
            this.uxLabelTitle.Name = "uxLabelTitle";
            this.uxLabelTitle.Size = new System.Drawing.Size(221, 46);
            this.uxLabelTitle.TabIndex = 12;
            this.uxLabelTitle.Text = "Phils Rentals";
            // 
            // uxPanelAddMovie
            // 
            this.uxPanelAddMovie.BackColor = System.Drawing.Color.Silver;
            this.uxPanelAddMovie.ForeColor = System.Drawing.Color.White;
            this.uxPanelAddMovie.Location = new System.Drawing.Point(0, 320);
            this.uxPanelAddMovie.Name = "uxPanelAddMovie";
            this.uxPanelAddMovie.Size = new System.Drawing.Size(5, 35);
            this.uxPanelAddMovie.TabIndex = 11;
            // 
            // uxButtonAddMovie
            // 
            this.uxButtonAddMovie.FlatAppearance.BorderSize = 0;
            this.uxButtonAddMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonAddMovie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonAddMovie.ForeColor = System.Drawing.Color.White;
            this.uxButtonAddMovie.Location = new System.Drawing.Point(0, 320);
            this.uxButtonAddMovie.Name = "uxButtonAddMovie";
            this.uxButtonAddMovie.Size = new System.Drawing.Size(200, 35);
            this.uxButtonAddMovie.TabIndex = 10;
            this.uxButtonAddMovie.Text = "Add Movie";
            this.uxButtonAddMovie.UseVisualStyleBackColor = true;
            this.uxButtonAddMovie.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelDeleteAccount
            // 
            this.uxPanelDeleteAccount.BackColor = System.Drawing.Color.Silver;
            this.uxPanelDeleteAccount.ForeColor = System.Drawing.Color.White;
            this.uxPanelDeleteAccount.Location = new System.Drawing.Point(0, 250);
            this.uxPanelDeleteAccount.Name = "uxPanelDeleteAccount";
            this.uxPanelDeleteAccount.Size = new System.Drawing.Size(5, 35);
            this.uxPanelDeleteAccount.TabIndex = 9;
            // 
            // uxButtonDeleteAccount
            // 
            this.uxButtonDeleteAccount.FlatAppearance.BorderSize = 0;
            this.uxButtonDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonDeleteAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonDeleteAccount.ForeColor = System.Drawing.Color.White;
            this.uxButtonDeleteAccount.Location = new System.Drawing.Point(0, 250);
            this.uxButtonDeleteAccount.Name = "uxButtonDeleteAccount";
            this.uxButtonDeleteAccount.Size = new System.Drawing.Size(200, 35);
            this.uxButtonDeleteAccount.TabIndex = 8;
            this.uxButtonDeleteAccount.Text = "Delete Account";
            this.uxButtonDeleteAccount.UseVisualStyleBackColor = true;
            this.uxButtonDeleteAccount.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelModifyAccount
            // 
            this.uxPanelModifyAccount.BackColor = System.Drawing.Color.Silver;
            this.uxPanelModifyAccount.ForeColor = System.Drawing.Color.White;
            this.uxPanelModifyAccount.Location = new System.Drawing.Point(0, 215);
            this.uxPanelModifyAccount.Name = "uxPanelModifyAccount";
            this.uxPanelModifyAccount.Size = new System.Drawing.Size(5, 35);
            this.uxPanelModifyAccount.TabIndex = 7;
            // 
            // uxButtonModifyAccount
            // 
            this.uxButtonModifyAccount.FlatAppearance.BorderSize = 0;
            this.uxButtonModifyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonModifyAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonModifyAccount.ForeColor = System.Drawing.Color.White;
            this.uxButtonModifyAccount.Location = new System.Drawing.Point(0, 215);
            this.uxButtonModifyAccount.Name = "uxButtonModifyAccount";
            this.uxButtonModifyAccount.Size = new System.Drawing.Size(200, 35);
            this.uxButtonModifyAccount.TabIndex = 6;
            this.uxButtonModifyAccount.Text = "Modify Account";
            this.uxButtonModifyAccount.UseVisualStyleBackColor = true;
            this.uxButtonModifyAccount.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelRentMovie
            // 
            this.uxPanelRentMovie.BackColor = System.Drawing.Color.Silver;
            this.uxPanelRentMovie.ForeColor = System.Drawing.Color.White;
            this.uxPanelRentMovie.Location = new System.Drawing.Point(0, 110);
            this.uxPanelRentMovie.Name = "uxPanelRentMovie";
            this.uxPanelRentMovie.Size = new System.Drawing.Size(5, 35);
            this.uxPanelRentMovie.TabIndex = 5;
            // 
            // uxButtonRentMovie
            // 
            this.uxButtonRentMovie.Enabled = false;
            this.uxButtonRentMovie.FlatAppearance.BorderSize = 0;
            this.uxButtonRentMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxButtonRentMovie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonRentMovie.ForeColor = System.Drawing.Color.White;
            this.uxButtonRentMovie.Location = new System.Drawing.Point(0, 110);
            this.uxButtonRentMovie.Name = "uxButtonRentMovie";
            this.uxButtonRentMovie.Size = new System.Drawing.Size(200, 35);
            this.uxButtonRentMovie.TabIndex = 4;
            this.uxButtonRentMovie.Text = "Rent Movies";
            this.uxButtonRentMovie.UseVisualStyleBackColor = true;
            this.uxButtonRentMovie.Click += new System.EventHandler(this.uxMenuHandler);
            // 
            // uxPanelMain
            // 
            this.uxPanelMain.BackColor = System.Drawing.Color.White;
            this.uxPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPanelMain.Location = new System.Drawing.Point(200, 0);
            this.uxPanelMain.Name = "uxPanelMain";
            this.uxPanelMain.Size = new System.Drawing.Size(582, 553);
            this.uxPanelMain.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 361);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 189);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.uxPanelMain);
            this.Controls.Add(this.uxPanelMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Phils Rentals";
            this.uxPanelMenu.ResumeLayout(false);
            this.uxPanelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel uxPanelCreateAccount;
        private System.Windows.Forms.Button uxButtonCreateAccount;
        private System.Windows.Forms.Panel uxPanelMenu;
        private System.Windows.Forms.Panel uxPanelRentMovie;
        private System.Windows.Forms.Button uxButtonRentMovie;
        private System.Windows.Forms.Panel uxPanelAddMovie;
        private System.Windows.Forms.Button uxButtonAddMovie;
        private System.Windows.Forms.Panel uxPanelDeleteAccount;
        private System.Windows.Forms.Button uxButtonDeleteAccount;
        private System.Windows.Forms.Panel uxPanelModifyAccount;
        private System.Windows.Forms.Button uxButtonModifyAccount;
        private System.Windows.Forms.Label uxLabelTitle;
        private System.Windows.Forms.Panel uxPanelMain;
        private System.Windows.Forms.Panel uxPanelBrowseMovie;
        private System.Windows.Forms.Button uxButtonBrowseMovie;
        private System.Windows.Forms.Panel uxPanelSelectAccount;
        private System.Windows.Forms.Button uxButtonSelectAccount;
        private System.Windows.Forms.Panel uxPanelReturnMovie;
        private System.Windows.Forms.Button uxButtonReturnMovie;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

