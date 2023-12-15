namespace PhilsRentals.Views
{
    partial class AddMovieWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxLabelTitle = new System.Windows.Forms.Label();
            this.uxLabelMovieTitle = new System.Windows.Forms.Label();
            this.uxLabelMovieGenre = new System.Windows.Forms.Label();
            this.uxLabelReleaseDate = new System.Windows.Forms.Label();
            this.uxLabelDuration = new System.Windows.Forms.Label();
            this.uxLabelStarRating = new System.Windows.Forms.Label();
            this.uxTextBoxMovieTitle = new System.Windows.Forms.TextBox();
            this.uxButtonAddMovie = new System.Windows.Forms.Button();
            this.uxNumericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.uxCheckedListBoxMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.uxTextBoxDuration = new System.Windows.Forms.TextBox();
            this.uxNumericUpDownRating = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // uxLabelTitle
            // 
            this.uxLabelTitle.BackColor = System.Drawing.Color.Purple;
            this.uxLabelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxLabelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxLabelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.uxLabelTitle.ForeColor = System.Drawing.Color.White;
            this.uxLabelTitle.Location = new System.Drawing.Point(0, 0);
            this.uxLabelTitle.Name = "uxLabelTitle";
            this.uxLabelTitle.Size = new System.Drawing.Size(584, 50);
            this.uxLabelTitle.TabIndex = 0;
            this.uxLabelTitle.Text = "Add Movie";
            this.uxLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxLabelMovieTitle
            // 
            this.uxLabelMovieTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelMovieTitle.AutoSize = true;
            this.uxLabelMovieTitle.BackColor = System.Drawing.Color.White;
            this.uxLabelMovieTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.uxLabelMovieTitle.ForeColor = System.Drawing.Color.Black;
            this.uxLabelMovieTitle.Location = new System.Drawing.Point(20, 90);
            this.uxLabelMovieTitle.Name = "uxLabelMovieTitle";
            this.uxLabelMovieTitle.Size = new System.Drawing.Size(135, 30);
            this.uxLabelMovieTitle.TabIndex = 1;
            this.uxLabelMovieTitle.Text = "Movie Title:";
            // 
            // uxLabelMovieGenre
            // 
            this.uxLabelMovieGenre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelMovieGenre.AutoSize = true;
            this.uxLabelMovieGenre.BackColor = System.Drawing.Color.White;
            this.uxLabelMovieGenre.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.uxLabelMovieGenre.ForeColor = System.Drawing.Color.Black;
            this.uxLabelMovieGenre.Location = new System.Drawing.Point(20, 165);
            this.uxLabelMovieGenre.Name = "uxLabelMovieGenre";
            this.uxLabelMovieGenre.Size = new System.Drawing.Size(151, 30);
            this.uxLabelMovieGenre.TabIndex = 2;
            this.uxLabelMovieGenre.Text = "Movie Genre:";
            // 
            // uxLabelReleaseDate
            // 
            this.uxLabelReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelReleaseDate.AutoSize = true;
            this.uxLabelReleaseDate.BackColor = System.Drawing.Color.White;
            this.uxLabelReleaseDate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.uxLabelReleaseDate.ForeColor = System.Drawing.Color.Black;
            this.uxLabelReleaseDate.Location = new System.Drawing.Point(21, 286);
            this.uxLabelReleaseDate.Name = "uxLabelReleaseDate";
            this.uxLabelReleaseDate.Size = new System.Drawing.Size(287, 30);
            this.uxLabelReleaseDate.TabIndex = 3;
            this.uxLabelReleaseDate.Text = "Movie Release Date (Year):";
            // 
            // uxLabelDuration
            // 
            this.uxLabelDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelDuration.AutoSize = true;
            this.uxLabelDuration.BackColor = System.Drawing.Color.White;
            this.uxLabelDuration.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.uxLabelDuration.ForeColor = System.Drawing.Color.Black;
            this.uxLabelDuration.Location = new System.Drawing.Point(20, 360);
            this.uxLabelDuration.Name = "uxLabelDuration";
            this.uxLabelDuration.Size = new System.Drawing.Size(286, 30);
            this.uxLabelDuration.TabIndex = 4;
            this.uxLabelDuration.Text = "Movie Duration (Minutes):";
            // 
            // uxLabelStarRating
            // 
            this.uxLabelStarRating.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelStarRating.AutoSize = true;
            this.uxLabelStarRating.BackColor = System.Drawing.Color.White;
            this.uxLabelStarRating.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.uxLabelStarRating.ForeColor = System.Drawing.Color.Black;
            this.uxLabelStarRating.Location = new System.Drawing.Point(20, 432);
            this.uxLabelStarRating.Name = "uxLabelStarRating";
            this.uxLabelStarRating.Size = new System.Drawing.Size(157, 30);
            this.uxLabelStarRating.TabIndex = 5;
            this.uxLabelStarRating.Text = "Movie Rating:";
            // 
            // uxTextBoxMovieTitle
            // 
            this.uxTextBoxMovieTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxTextBoxMovieTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.uxTextBoxMovieTitle.Location = new System.Drawing.Point(160, 87);
            this.uxTextBoxMovieTitle.Multiline = true;
            this.uxTextBoxMovieTitle.Name = "uxTextBoxMovieTitle";
            this.uxTextBoxMovieTitle.Size = new System.Drawing.Size(404, 37);
            this.uxTextBoxMovieTitle.TabIndex = 1;
            this.uxTextBoxMovieTitle.TextChanged += new System.EventHandler(this.uxFieldsChanged);
            // 
            // uxButtonAddMovie
            // 
            this.uxButtonAddMovie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxButtonAddMovie.Enabled = false;
            this.uxButtonAddMovie.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonAddMovie.Location = new System.Drawing.Point(192, 501);
            this.uxButtonAddMovie.Name = "uxButtonAddMovie";
            this.uxButtonAddMovie.Size = new System.Drawing.Size(200, 50);
            this.uxButtonAddMovie.TabIndex = 6;
            this.uxButtonAddMovie.Text = "Add Movie";
            this.uxButtonAddMovie.UseVisualStyleBackColor = true;
            this.uxButtonAddMovie.Click += new System.EventHandler(this.uxButtonAddMovie_Click);
            // 
            // uxNumericUpDownYear
            // 
            this.uxNumericUpDownYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownYear.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.uxNumericUpDownYear.Location = new System.Drawing.Point(321, 285);
            this.uxNumericUpDownYear.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.uxNumericUpDownYear.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.uxNumericUpDownYear.Name = "uxNumericUpDownYear";
            this.uxNumericUpDownYear.Size = new System.Drawing.Size(120, 32);
            this.uxNumericUpDownYear.TabIndex = 3;
            this.uxNumericUpDownYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // uxCheckedListBoxMovieGenre
            // 
            this.uxCheckedListBoxMovieGenre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxCheckedListBoxMovieGenre.CheckOnClick = true;
            this.uxCheckedListBoxMovieGenre.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.uxCheckedListBoxMovieGenre.FormattingEnabled = true;
            this.uxCheckedListBoxMovieGenre.Items.AddRange(new object[] {
            "Mystery",
            "Drama",
            "History",
            "Sport",
            "Sci-Fi",
            "Family",
            "Horror",
            "Biography",
            "Crime",
            "Romance",
            "Fantasy",
            "Animation",
            "War",
            "Adventure",
            "Action",
            "Music",
            "Comedy",
            "Documentary",
            "Musical",
            "Thriller",
            "Western"});
            this.uxCheckedListBoxMovieGenre.Location = new System.Drawing.Point(177, 165);
            this.uxCheckedListBoxMovieGenre.Name = "uxCheckedListBoxMovieGenre";
            this.uxCheckedListBoxMovieGenre.ScrollAlwaysVisible = true;
            this.uxCheckedListBoxMovieGenre.Size = new System.Drawing.Size(186, 82);
            this.uxCheckedListBoxMovieGenre.TabIndex = 2;
            this.uxCheckedListBoxMovieGenre.SelectedIndexChanged += new System.EventHandler(this.uxFieldsChanged);
            // 
            // uxTextBoxDuration
            // 
            this.uxTextBoxDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxTextBoxDuration.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.uxTextBoxDuration.Location = new System.Drawing.Point(312, 357);
            this.uxTextBoxDuration.Multiline = true;
            this.uxTextBoxDuration.Name = "uxTextBoxDuration";
            this.uxTextBoxDuration.Size = new System.Drawing.Size(250, 37);
            this.uxTextBoxDuration.TabIndex = 4;
            this.uxTextBoxDuration.TextChanged += new System.EventHandler(this.uxFieldsChanged);
            // 
            // uxNumericUpDownRating
            // 
            this.uxNumericUpDownRating.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownRating.DecimalPlaces = 1;
            this.uxNumericUpDownRating.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.uxNumericUpDownRating.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.uxNumericUpDownRating.Location = new System.Drawing.Point(189, 431);
            this.uxNumericUpDownRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxNumericUpDownRating.Name = "uxNumericUpDownRating";
            this.uxNumericUpDownRating.Size = new System.Drawing.Size(120, 32);
            this.uxNumericUpDownRating.TabIndex = 5;
            // 
            // AddMovieWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uxTextBoxDuration);
            this.Controls.Add(this.uxNumericUpDownRating);
            this.Controls.Add(this.uxCheckedListBoxMovieGenre);
            this.Controls.Add(this.uxNumericUpDownYear);
            this.Controls.Add(this.uxButtonAddMovie);
            this.Controls.Add(this.uxTextBoxMovieTitle);
            this.Controls.Add(this.uxLabelStarRating);
            this.Controls.Add(this.uxLabelDuration);
            this.Controls.Add(this.uxLabelReleaseDate);
            this.Controls.Add(this.uxLabelMovieGenre);
            this.Controls.Add(this.uxLabelMovieTitle);
            this.Controls.Add(this.uxLabelTitle);
            this.Name = "AddMovieWindow";
            this.Size = new System.Drawing.Size(584, 561);
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabelTitle;
        private System.Windows.Forms.Label uxLabelMovieTitle;
        private System.Windows.Forms.Label uxLabelMovieGenre;
        private System.Windows.Forms.Label uxLabelReleaseDate;
        private System.Windows.Forms.Label uxLabelDuration;
        private System.Windows.Forms.Label uxLabelStarRating;
        private System.Windows.Forms.TextBox uxTextBoxMovieTitle;
        private System.Windows.Forms.Button uxButtonAddMovie;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownYear;
        private System.Windows.Forms.CheckedListBox uxCheckedListBoxMovieGenre;
        private System.Windows.Forms.TextBox uxTextBoxDuration;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownRating;
    }
}
