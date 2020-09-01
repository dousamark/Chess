using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    partial class Form
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.board = new System.Windows.Forms.PictureBox();
            this.pawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawn)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("board.BackgroundImage")));
            this.board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(800, 800);
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            // 
            // pawn
            // 
            this.pawn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pawn.BackgroundImage")));
            this.pawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pawn.Location = new System.Drawing.Point(51, 50);
            this.pawn.Name = "pawn";
            this.pawn.Size = new System.Drawing.Size(70, 70);
            this.pawn.TabIndex = 1;
            this.pawn.TabStop = false;
            this.pawn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pawn_MouseDown);
            this.pawn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pawn_MouseMove);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1198, 944);
            this.Controls.Add(this.pawn);
            this.Controls.Add(this.board);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.PictureBox pawn;

       
    }
}

