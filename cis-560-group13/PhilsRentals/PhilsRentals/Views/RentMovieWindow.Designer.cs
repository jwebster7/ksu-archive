namespace PhilsRentals.Views
{
    partial class RentMovieWindow
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
            this.uxButtonRentMovie = new System.Windows.Forms.Button();
            this.uxTextBoxMovieTitle = new System.Windows.Forms.TextBox();
            this.uxLabelMovieTitle = new System.Windows.Forms.Label();
            this.uxDataGridViewMovies = new System.Windows.Forms.DataGridView();
            this.MovieTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).BeginInit();
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
            this.uxLabelTitle.TabIndex = 13;
            this.uxLabelTitle.Text = "Rent Movie";
            this.uxLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxButtonRentMovie
            // 
            this.uxButtonRentMovie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxButtonRentMovie.Enabled = false;
            this.uxButtonRentMovie.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.uxButtonRentMovie.Location = new System.Drawing.Point(192, 527);
            this.uxButtonRentMovie.Name = "uxButtonRentMovie";
            this.uxButtonRentMovie.Size = new System.Drawing.Size(200, 31);
            this.uxButtonRentMovie.TabIndex = 12;
            this.uxButtonRentMovie.Text = "Rent Movie(s)";
            this.uxButtonRentMovie.UseVisualStyleBackColor = true;
            this.uxButtonRentMovie.Click += new System.EventHandler(this.uxButtonRentMovie_Click);
            // 
            // uxTextBoxMovieTitle
            // 
            this.uxTextBoxMovieTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxTextBoxMovieTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uxTextBoxMovieTitle.Location = new System.Drawing.Point(141, 55);
            this.uxTextBoxMovieTitle.Name = "uxTextBoxMovieTitle";
            this.uxTextBoxMovieTitle.Size = new System.Drawing.Size(429, 29);
            this.uxTextBoxMovieTitle.TabIndex = 15;
            this.uxTextBoxMovieTitle.TextChanged += new System.EventHandler(this.uxTextBoxMovieTitle_TextChanged);
            // 
            // uxLabelMovieTitle
            // 
            this.uxLabelMovieTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxLabelMovieTitle.AutoSize = true;
            this.uxLabelMovieTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabelMovieTitle.ForeColor = System.Drawing.Color.Black;
            this.uxLabelMovieTitle.Location = new System.Drawing.Point(11, 59);
            this.uxLabelMovieTitle.Name = "uxLabelMovieTitle";
            this.uxLabelMovieTitle.Size = new System.Drawing.Size(117, 21);
            this.uxLabelMovieTitle.TabIndex = 14;
            this.uxLabelMovieTitle.Text = "Search Movie:";
            // 
            // uxDataGridViewMovies
            // 
            this.uxDataGridViewMovies.AllowUserToAddRows = false;
            this.uxDataGridViewMovies.AllowUserToDeleteRows = false;
            this.uxDataGridViewMovies.AllowUserToResizeColumns = false;
            this.uxDataGridViewMovies.AllowUserToResizeRows = false;
            this.uxDataGridViewMovies.ColumnHeadersHeight = 30;
            this.uxDataGridViewMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uxDataGridViewMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MovieTitle,
            this.Count});
            this.uxDataGridViewMovies.Location = new System.Drawing.Point(3, 90);
            this.uxDataGridViewMovies.MultiSelect = false;
            this.uxDataGridViewMovies.Name = "uxDataGridViewMovies";
            this.uxDataGridViewMovies.ReadOnly = true;
            this.uxDataGridViewMovies.RowHeadersVisible = false;
            this.uxDataGridViewMovies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.uxDataGridViewMovies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxDataGridViewMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxDataGridViewMovies.Size = new System.Drawing.Size(578, 431);
            this.uxDataGridViewMovies.TabIndex = 16;
            this.uxDataGridViewMovies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uxDataGridViewMovies_CellClick);
            // 
            // MovieTitle
            // 
            this.MovieTitle.HeaderText = "Movie Title";
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.ReadOnly = true;
            this.MovieTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MovieTitle.Width = 480;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // RentMovieWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uxDataGridViewMovies);
            this.Controls.Add(this.uxTextBoxMovieTitle);
            this.Controls.Add(this.uxLabelMovieTitle);
            this.Controls.Add(this.uxLabelTitle);
            this.Controls.Add(this.uxButtonRentMovie);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "RentMovieWindow";
            this.Size = new System.Drawing.Size(584, 561);
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabelTitle;
        private System.Windows.Forms.Button uxButtonRentMovie;
        private System.Windows.Forms.TextBox uxTextBoxMovieTitle;
        private System.Windows.Forms.Label uxLabelMovieTitle;
        private System.Windows.Forms.DataGridView uxDataGridViewMovies;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}
