namespace BILLIARDTRAINING
{
    partial class FrmIgra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIgra));
            this.pnlCrtaj = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlCrtaj
            // 
            this.pnlCrtaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCrtaj.Location = new System.Drawing.Point(27, 55);
            this.pnlCrtaj.Name = "pnlCrtaj";
            this.pnlCrtaj.Size = new System.Drawing.Size(728, 402);
            this.pnlCrtaj.TabIndex = 0;
            this.pnlCrtaj.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlCrtaj_Paint);
            // 
            // FrmIgra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlCrtaj);
            this.Font = new System.Drawing.Font("Rage Italic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmIgra";
            this.Text = "BILLIARD";
            this.Load += new System.EventHandler(this.FrmIgra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCrtaj;
    }
}

