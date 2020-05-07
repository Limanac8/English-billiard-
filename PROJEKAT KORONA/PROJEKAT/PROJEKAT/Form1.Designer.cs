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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIgra));
            this.pnlSto = new System.Windows.Forms.Panel();
            this.pnlSkor = new System.Windows.Forms.Panel();
            this.pnlZeleno = new System.Windows.Forms.Panel();
            this.TAJMER = new System.Windows.Forms.Timer(this.components);
            this.pnlSkor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSto
            // 
            this.pnlSto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSto.Location = new System.Drawing.Point(277, 32);
            this.pnlSto.Name = "pnlSto";
            this.pnlSto.Size = new System.Drawing.Size(724, 400);
            this.pnlSto.TabIndex = 0;
            this.pnlSto.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlCrtaj_Paint);
            this.pnlSto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlSto_MouseDown);
            // 
            // pnlSkor
            // 
            this.pnlSkor.Controls.Add(this.pnlZeleno);
            this.pnlSkor.Location = new System.Drawing.Point(36, 32);
            this.pnlSkor.Name = "pnlSkor";
            this.pnlSkor.Size = new System.Drawing.Size(208, 400);
            this.pnlSkor.TabIndex = 1;
            // 
            // pnlZeleno
            // 
            this.pnlZeleno.Location = new System.Drawing.Point(20, 20);
            this.pnlZeleno.Name = "pnlZeleno";
            this.pnlZeleno.Size = new System.Drawing.Size(168, 360);
            this.pnlZeleno.TabIndex = 0;
            // 
            // TAJMER
            // 
            this.TAJMER.Tick += new System.EventHandler(this.TAJMER_Tick);
            // 
            // FrmIgra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 462);
            this.Controls.Add(this.pnlSkor);
            this.Controls.Add(this.pnlSto);
            this.Font = new System.Drawing.Font("Rage Italic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmIgra";
            this.Text = "BILLIARD";
            this.Load += new System.EventHandler(this.FrmIgra_Load);
            this.pnlSkor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSto;
        private System.Windows.Forms.Panel pnlSkor;
        private System.Windows.Forms.Panel pnlZeleno;
        private System.Windows.Forms.Timer TAJMER;
    }
}

