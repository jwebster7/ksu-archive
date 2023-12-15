namespace PhilsRentals.Views
{
    partial class ReturnMovieWindow
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
            this.uxLabelReturnMovieWindow = new System.Windows.Forms.Label();
            this.uxButtonReturnMovie = new System.Windows.Forms.Button();
            this.uxDataGridViewMovies = new System.Windows.Forms.DataGridView();
            this.MovieTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // uxLabelReturnMovieWindow
            // 
            this.uxLabelReturnMovieWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLabelReturnMovieWindow.BackColor = System.Drawing.Color.Purple;
            this.uxLabelReturnMovieWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxLabelReturnMovieWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.uxLabelReturnMovieWindow.ForeColor = System.Drawing.Color.White;
            this.uxLabelReturnMovieWindow.Location = new System.Drawing.Point(0, 0);
            this.uxLabelReturnMovieWindow.Name = "uxLabelReturnMovieWindow";
            this.uxLabelReturnMovieWindow.Size = new System.Drawing.Size(584, 50);
            this.uxLabelReturnMovieWindow.TabIndex = 0;
            this.uxLabelReturnMovieWindow.Text = "Return Movie";
            this.uxLabelReturnMovieWindow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxButtonReturnMovie
            // 
            this.uxButtonReturnMovie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxButtonReturnMovie.Enabled = false;
            this.uxButtonReturnMovie.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.uxButtonReturnMovie.Location = new System.Drawing.Point(192, 527);
            this.uxButtonReturnMovie.Name = "uxButtonReturnMovie";
            this.uxButtonReturnMovie.Size = new System.Drawing.Size(200, 31);
            this.uxButtonReturnMovie.TabIndex = 13;
            this.uxButtonReturnMovie.Text = "Return Movie(s)";
            this.uxButtonReturnMovie.UseVisualStyleBackColor = true;
            this.uxButtonReturnMovie.Click += new System.EventHandler(this.uxButtonReturnMovie_Click);
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
            this.DueDate});
            this.uxDataGridViewMovies.Location = new System.Drawing.Point(3, 90);
            this.uxDataGridViewMovies.MultiSelect = false;
            this.uxDataGridViewMovies.Name = "uxDataGridViewMovies";
            this.uxDataGridViewMovies.ReadOnly = true;
            this.uxDataGridViewMovies.RowHeadersVisible = false;
            this.uxDataGridViewMovies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.uxDataGridViewMovies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxDataGridViewMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxDataGridViewMovies.Size = new System.Drawing.Size(578, 431);
            this.uxDataGridViewMovies.TabIndex = 17;
            this.uxDataGridViewMovies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uxDataGridViewMovies_CellClick);
            // 
            // MovieTitle
            // 
            this.MovieTitle.HeaderText = "Movie Title";
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.ReadOnly = true;
            this.MovieTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MovieTitle.Width = 420;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DueDate.Width = 160;
            // 
            // ReturnMovieWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uxDataGridViewMovies);
            this.Controls.Add(this.uxButtonReturnMovie);
            this.Controls.Add(this.uxLabelReturnMovieWindow);
            this.Name = "ReturnMovieWindow";
            this.Size = new System.Drawing.Size(584, 561);
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewMovies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uxLabelReturnMovieWindow;
        private System.Windows.Forms.Button uxButtonReturnMovie;
        private System.Windows.Forms.DataGridView uxDataGridViewMovies;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
    }
}
