namespace ETYS
{
    partial class FrmAnaPanel
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
            this.btnUrunler = new System.Windows.Forms.Button();
            this.lblToplamUrun = new System.Windows.Forms.Label();
            this.lblToplamFiyat = new System.Windows.Forms.Label();
            this.dgvKritikStok = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKritikStok)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUrunler
            // 
            this.btnUrunler.Location = new System.Drawing.Point(153, 46);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new System.Drawing.Size(75, 23);
            this.btnUrunler.TabIndex = 0;
            this.btnUrunler.Text = "button1";
            this.btnUrunler.UseVisualStyleBackColor = true;
            this.btnUrunler.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblToplamUrun
            // 
            this.lblToplamUrun.AutoSize = true;
            this.lblToplamUrun.Location = new System.Drawing.Point(310, 46);
            this.lblToplamUrun.Name = "lblToplamUrun";
            this.lblToplamUrun.Size = new System.Drawing.Size(98, 16);
            this.lblToplamUrun.TabIndex = 1;
            this.lblToplamUrun.Text = "Toplam Ürün: 0";
            this.lblToplamUrun.Click += new System.EventHandler(this.lblToplamUrun_Click);
            // 
            // lblToplamFiyat
            // 
            this.lblToplamFiyat.AutoSize = true;
            this.lblToplamFiyat.Location = new System.Drawing.Point(307, 81);
            this.lblToplamFiyat.Name = "lblToplamFiyat";
            this.lblToplamFiyat.Size = new System.Drawing.Size(127, 16);
            this.lblToplamFiyat.TabIndex = 2;
            this.lblToplamFiyat.Text = "Toplam Değer: 0 TL";
            // 
            // dgvKritikStok
            // 
            this.dgvKritikStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKritikStok.Location = new System.Drawing.Point(51, 181);
            this.dgvKritikStok.Name = "dgvKritikStok";
            this.dgvKritikStok.RowHeadersWidth = 51;
            this.dgvKritikStok.RowTemplate.Height = 24;
            this.dgvKritikStok.Size = new System.Drawing.Size(612, 234);
            this.dgvKritikStok.TabIndex = 3;
            this.dgvKritikStok.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKritikStok_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "⚠️ Kritik Stok Seviyesindeki Ürünler";
            // 
            // FrmAnaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvKritikStok);
            this.Controls.Add(this.lblToplamFiyat);
            this.Controls.Add(this.lblToplamUrun);
            this.Controls.Add(this.btnUrunler);
            this.Name = "FrmAnaPanel";
            this.Text = "FrmAnaPanel";
            this.Load += new System.EventHandler(this.FrmAnaPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKritikStok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUrunler;
        private System.Windows.Forms.Label lblToplamUrun;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.DataGridView dgvKritikStok;
        private System.Windows.Forms.Label label1;
    }
}