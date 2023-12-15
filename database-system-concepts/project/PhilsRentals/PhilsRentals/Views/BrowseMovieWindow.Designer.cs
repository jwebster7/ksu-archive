namespace PhilsRentals.Views
{
    partial class BrowseMovieWindow
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
            this.uxButtonGetMovie = new System.Windows.Forms.Button();
            this.uxCheckedListBoxMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.uxLabelMovieGenre = new System.Windows.Forms.Label();
            this.uxNumericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.uxLabelStarRating = new System.Windows.Forms.Label();
            this.uxLabelDuration = new System.Windows.Forms.Label();
            this.uxLabelReleaseDate = new System.Windows.Forms.Label();
            this.uxDataGridViewMovies = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxNumericUpDownRatingTwo = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownRatingOperator = new System.Windows.Forms.Button();
            this.uxNumericUpDownYearTwo = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownYearOperator = new System.Windows.Forms.Button();
            this.uxNumericUpDownDurationOperator = new System.Windows.Forms.Button();
            this.uxNumericUpDownDurationTwo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRatingTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYearTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownDurationTwo)).BeginInit();
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
            this.uxLabelTitle.TabIndex = 6;
            this.uxLabelTitle.Text = "Browse Movie";
            this.uxLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxButtonGetMovie
            // 
            this.uxButtonGetMovie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxButtonGetMovie.Enabled = false;
            this.uxButtonGetMovie.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.uxButtonGetMovie.Location = new System.Drawing.Point(17, 207);
            this.uxButtonGetMovie.Name = "uxButtonGetMovie";
            this.uxButtonGetMovie.Size = new System.Drawing.Size(154, 31);
            this.uxButtonGetMovie.TabIndex = 13;
            this.uxButtonGetMovie.Text = "Browse";
            this.uxButtonGetMovie.UseVisualStyleBackColor = true;
            this.uxButtonGetMovie.Click += new System.EventHandler(this.uxButtonGetMovie_Click);
            // 
            // uxCheckedListBoxMovieGenre
            // 
            this.uxCheckedListBoxMovieGenre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxCheckedListBoxMovieGenre.BackColor = System.Drawing.Color.White;
            this.uxCheckedListBoxMovieGenre.CheckOnClick = true;
            this.uxCheckedListBoxMovieGenre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxCheckedListBoxMovieGenre.FormattingEnabled = true;
            this.uxCheckedListBoxMovieGenre.Items.AddRange(new object[] {
            "Mystery (1)",
            "Drama (2)",
            "History (3)",
            "Sport (4)",
            "Sci-Fi (5)",
            "Family (6)",
            "Horror (7)",
            "Biography (8)",
            "Crime (9)",
            "Romance (10)",
            "Fantasy (11)",
            "Animation (12)",
            "War (13)",
            "Adventure (14)",
            "Action (15)",
            "Music (16)",
            "Comedy (17)",
            "Documentary (18)",
            "Musical (19)",
            "Thriller (20)",
            "Western (21)"});
            this.uxCheckedListBoxMovieGenre.Location = new System.Drawing.Point(77, 61);
            this.uxCheckedListBoxMovieGenre.Name = "uxCheckedListBoxMovieGenre";
            this.uxCheckedListBoxMovieGenre.ScrollAlwaysVisible = true;
            this.uxCheckedListBoxMovieGenre.Size = new System.Drawing.Size(205, 120);
            this.uxCheckedListBoxMovieGenre.TabIndex = 17;
            this.uxCheckedListBoxMovieGenre.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.uxCheckedListBoxMovieGenre_ItemCheck);
            this.uxCheckedListBoxMovieGenre.SelectedIndexChanged += new System.EventHandler(this.uxCheckedListBoxMovieGenre_SelectedIndexChanged);
            // 
            // uxLabelMovieGenre
            // 
            this.uxLabelMovieGenre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelMovieGenre.AutoSize = true;
            this.uxLabelMovieGenre.BackColor = System.Drawing.Color.White;
            this.uxLabelMovieGenre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.uxLabelMovieGenre.ForeColor = System.Drawing.Color.Black;
            this.uxLabelMovieGenre.Location = new System.Drawing.Point(12, 61);
            this.uxLabelMovieGenre.Name = "uxLabelMovieGenre";
            this.uxLabelMovieGenre.Size = new System.Drawing.Size(73, 28);
            this.uxLabelMovieGenre.TabIndex = 16;
            this.uxLabelMovieGenre.Text = "Genre:";
            // 
            // uxNumericUpDownRating
            // 
            this.uxNumericUpDownRating.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownRating.DecimalPlaces = 1;
            this.uxNumericUpDownRating.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownRating.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.uxNumericUpDownRating.Location = new System.Drawing.Point(368, 61);
            this.uxNumericUpDownRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxNumericUpDownRating.Name = "uxNumericUpDownRating";
            this.uxNumericUpDownRating.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownRating.TabIndex = 23;
            this.uxNumericUpDownRating.ValueChanged += new System.EventHandler(this.uxNumericUpDownRating_ValueChanged);
            // 
            // uxNumericUpDownDuration
            // 
            this.uxNumericUpDownDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownDuration.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownDuration.Location = new System.Drawing.Point(368, 148);
            this.uxNumericUpDownDuration.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.uxNumericUpDownDuration.Minimum = new decimal(new int[] {
            73,
            0,
            0,
            0});
            this.uxNumericUpDownDuration.Name = "uxNumericUpDownDuration";
            this.uxNumericUpDownDuration.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownDuration.TabIndex = 22;
            this.uxNumericUpDownDuration.Value = new decimal(new int[] {
            73,
            0,
            0,
            0});
            this.uxNumericUpDownDuration.ValueChanged += new System.EventHandler(this.uxNumericUpDownDuration_ValueChanged);
            // 
            // uxNumericUpDownYear
            // 
            this.uxNumericUpDownYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownYear.Location = new System.Drawing.Point(368, 104);
            this.uxNumericUpDownYear.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.uxNumericUpDownYear.Minimum = new decimal(new int[] {
            1888,
            0,
            0,
            0});
            this.uxNumericUpDownYear.Name = "uxNumericUpDownYear";
            this.uxNumericUpDownYear.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownYear.TabIndex = 21;
            this.uxNumericUpDownYear.Value = new decimal(new int[] {
            1888,
            0,
            0,
            0});
            this.uxNumericUpDownYear.ValueChanged += new System.EventHandler(this.uxNumericUpDownYear_ValueChanged);
            // 
            // uxLabelStarRating
            // 
            this.uxLabelStarRating.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelStarRating.AutoSize = true;
            this.uxLabelStarRating.BackColor = System.Drawing.Color.White;
            this.uxLabelStarRating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.uxLabelStarRating.ForeColor = System.Drawing.Color.Black;
            this.uxLabelStarRating.Location = new System.Drawing.Point(298, 63);
            this.uxLabelStarRating.Name = "uxLabelStarRating";
            this.uxLabelStarRating.Size = new System.Drawing.Size(79, 28);
            this.uxLabelStarRating.TabIndex = 20;
            this.uxLabelStarRating.Text = "Rating:";
            // 
            // uxLabelDuration
            // 
            this.uxLabelDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelDuration.AutoSize = true;
            this.uxLabelDuration.BackColor = System.Drawing.Color.White;
            this.uxLabelDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.uxLabelDuration.ForeColor = System.Drawing.Color.Black;
            this.uxLabelDuration.Location = new System.Drawing.Point(298, 150);
            this.uxLabelDuration.Name = "uxLabelDuration";
            this.uxLabelDuration.Size = new System.Drawing.Size(82, 28);
            this.uxLabelDuration.TabIndex = 19;
            this.uxLabelDuration.Text = "Length:";
            // 
            // uxLabelReleaseDate
            // 
            this.uxLabelReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelReleaseDate.AutoSize = true;
            this.uxLabelReleaseDate.BackColor = System.Drawing.Color.White;
            this.uxLabelReleaseDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.uxLabelReleaseDate.ForeColor = System.Drawing.Color.Black;
            this.uxLabelReleaseDate.Location = new System.Drawing.Point(298, 106);
            this.uxLabelReleaseDate.Name = "uxLabelReleaseDate";
            this.uxLabelReleaseDate.Size = new System.Drawing.Size(58, 28);
            this.uxLabelReleaseDate.TabIndex = 18;
            this.uxLabelReleaseDate.Text = "Year:";
            // 
            // uxDataGridViewMovies
            // 
            this.uxDataGridViewMovies.AllowUserToAddRows = false;
            this.uxDataGridViewMovies.AllowUserToDeleteRows = false;
            this.uxDataGridViewMovies.AllowUserToOrderColumns = true;
            this.uxDataGridViewMovies.AllowUserToResizeColumns = false;
            this.uxDataGridViewMovies.AllowUserToResizeRows = false;
            this.uxDataGridViewMovies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDataGridViewMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridViewMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Rating,
            this.Genre,
            this.ReleaseYear,
            this.Duration});
            this.uxDataGridViewMovies.Location = new System.Drawing.Point(17, 244);
            this.uxDataGridViewMovies.MultiSelect = false;
            this.uxDataGridViewMovies.Name = "uxDataGridViewMovies";
            this.uxDataGridViewMovies.ReadOnly = true;
            this.uxDataGridViewMovies.RowHeadersVisible = false;
            this.uxDataGridViewMovies.Size = new System.Drawing.Size(552, 304);
            this.uxDataGridViewMovies.TabIndex = 24;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 110;
            // 
            // Rating
            // 
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            this.Rating.Width = 110;
            // 
            // Genre
            // 
            this.Genre.HeaderText = "Genre";
            this.Genre.Name = "Genre";
            this.Genre.ReadOnly = true;
            this.Genre.Width = 110;
            // 
            // ReleaseYear
            // 
            this.ReleaseYear.HeaderText = "ReleaseYear";
            this.ReleaseYear.Name = "ReleaseYear";
            this.ReleaseYear.ReadOnly = true;
            this.ReleaseYear.Width = 110;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Length";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 108;
            // 
            // uxNumericUpDownRatingTwo
            // 
            this.uxNumericUpDownRatingTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownRatingTwo.DecimalPlaces = 1;
            this.uxNumericUpDownRatingTwo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownRatingTwo.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.uxNumericUpDownRatingTwo.Location = new System.Drawing.Point(501, 61);
            this.uxNumericUpDownRatingTwo.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.uxNumericUpDownRatingTwo.Name = "uxNumericUpDownRatingTwo";
            this.uxNumericUpDownRatingTwo.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownRatingTwo.TabIndex = 25;
            this.uxNumericUpDownRatingTwo.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            // 
            // uxNumericUpDownRatingOperator
            // 
            this.uxNumericUpDownRatingOperator.Location = new System.Drawing.Point(443, 64);
            this.uxNumericUpDownRatingOperator.Name = "uxNumericUpDownRatingOperator";
            this.uxNumericUpDownRatingOperator.Size = new System.Drawing.Size(52, 23);
            this.uxNumericUpDownRatingOperator.TabIndex = 26;
            this.uxNumericUpDownRatingOperator.Text = "<";
            this.uxNumericUpDownRatingOperator.UseVisualStyleBackColor = true;
            this.uxNumericUpDownRatingOperator.Click += new System.EventHandler(this.uxNumericUpDownRatingOperator_Click);
            // 
            // uxNumericUpDownYearTwo
            // 
            this.uxNumericUpDownYearTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownYearTwo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownYearTwo.Location = new System.Drawing.Point(501, 104);
            this.uxNumericUpDownYearTwo.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.uxNumericUpDownYearTwo.Minimum = new decimal(new int[] {
            1888,
            0,
            0,
            0});
            this.uxNumericUpDownYearTwo.Name = "uxNumericUpDownYearTwo";
            this.uxNumericUpDownYearTwo.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownYearTwo.TabIndex = 27;
            this.uxNumericUpDownYearTwo.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // uxNumericUpDownYearOperator
            // 
            this.uxNumericUpDownYearOperator.Location = new System.Drawing.Point(442, 107);
            this.uxNumericUpDownYearOperator.Name = "uxNumericUpDownYearOperator";
            this.uxNumericUpDownYearOperator.Size = new System.Drawing.Size(52, 23);
            this.uxNumericUpDownYearOperator.TabIndex = 28;
            this.uxNumericUpDownYearOperator.Text = "<";
            this.uxNumericUpDownYearOperator.UseVisualStyleBackColor = true;
            this.uxNumericUpDownYearOperator.Click += new System.EventHandler(this.uxNumericUpDownYearOperator_Click);
            // 
            // uxNumericUpDownDurationOperator
            // 
            this.uxNumericUpDownDurationOperator.Location = new System.Drawing.Point(442, 151);
            this.uxNumericUpDownDurationOperator.Name = "uxNumericUpDownDurationOperator";
            this.uxNumericUpDownDurationOperator.Size = new System.Drawing.Size(52, 23);
            this.uxNumericUpDownDurationOperator.TabIndex = 29;
            this.uxNumericUpDownDurationOperator.Text = "<";
            this.uxNumericUpDownDurationOperator.UseVisualStyleBackColor = true;
            this.uxNumericUpDownDurationOperator.Click += new System.EventHandler(this.uxNumericUpDownDurationOperator_Click);
            // 
            // uxNumericUpDownDurationTwo
            // 
            this.uxNumericUpDownDurationTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumericUpDownDurationTwo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxNumericUpDownDurationTwo.Location = new System.Drawing.Point(500, 148);
            this.uxNumericUpDownDurationTwo.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.uxNumericUpDownDurationTwo.Minimum = new decimal(new int[] {
            73,
            0,
            0,
            0});
            this.uxNumericUpDownDurationTwo.Name = "uxNumericUpDownDurationTwo";
            this.uxNumericUpDownDurationTwo.Size = new System.Drawing.Size(68, 34);
            this.uxNumericUpDownDurationTwo.TabIndex = 30;
            this.uxNumericUpDownDurationTwo.Value = new decimal(new int[] {
            280,
            0,
            0,
            0});
            // 
            // BrowseMovieWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uxNumericUpDownDurationTwo);
            this.Controls.Add(this.uxNumericUpDownDurationOperator);
            this.Controls.Add(this.uxNumericUpDownYearOperator);
            this.Controls.Add(this.uxNumericUpDownYearTwo);
            this.Controls.Add(this.uxNumericUpDownRatingOperator);
            this.Controls.Add(this.uxNumericUpDownRatingTwo);
            this.Controls.Add(this.uxDataGridViewMovies);
            this.Controls.Add(this.uxNumericUpDownRating);
            this.Controls.Add(this.uxNumericUpDownDuration);
            this.Controls.Add(this.uxNumericUpDownYear);
            this.Controls.Add(this.uxLabelStarRating);
            this.Controls.Add(this.uxLabelDuration);
            this.Controls.Add(this.uxLabelReleaseDate);
            this.Controls.Add(this.uxCheckedListBoxMovieGenre);
            this.Controls.Add(this.uxLabelMovieGenre);
            this.Controls.Add(this.uxButtonGetMovie);
            this.Controls.Add(this.uxLabelTitle);
            this.Name = "BrowseMovieWindow";
            this.Size = new System.Drawing.Size(584, 561);
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownRatingTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownYearTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownDurationTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxLabelTitle;
        private System.Windows.Forms.Button uxButtonGetMovie;
        private System.Windows.Forms.CheckedListBox uxCheckedListBoxMovieGenre;
        private System.Windows.Forms.Label uxLabelMovieGenre;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownRating;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownDuration;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownYear;
        private System.Windows.Forms.Label uxLabelStarRating;
        private System.Windows.Forms.Label uxLabelDuration;
        private System.Windows.Forms.Label uxLabelReleaseDate;
        private System.Windows.Forms.DataGridView uxDataGridViewMovies;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownRatingTwo;
        private System.Windows.Forms.Button uxNumericUpDownRatingOperator;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownYearTwo;
        private System.Windows.Forms.Button uxNumericUpDownYearOperator;
        private System.Windows.Forms.Button uxNumericUpDownDurationOperator;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownDurationTwo;
    }
}
