using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETYS
{
    public partial class FrmAnaPanel : Form
    {
        public FrmAnaPanel()
        {
            InitializeComponent();
        }
        // Formun içindeki 'public partial class FrmAnaPanel : Form' satırının hemen altına:
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\mehme\source\repos\ETYS\ETYS\ETYSDB.mdf';Integrated Security=True");
        private void FrmAnaPanel_Load(object sender, EventArgs e)
        {
            VerileriYukle();
            KritikStoklariListele();

            this.Text = "ETYS - Stok Takip ve Yönetim Sistemi";
        }
        private void VerileriYukle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                // 1. Toplam Ürün Sayısını Al (Kaç çeşit ürün var?)
                SqlCommand komutUrun = new SqlCommand("SELECT COUNT(*) FROM Urunler", baglanti);
                int urunSayisi = (int)komutUrun.ExecuteScalar();
                lblToplamUrun.Text = "Toplam Ürün: " + urunSayisi.ToString();

                // 2. Toplam Envanter Değerini Al (Her ürünün fiyatı * stok adedi ve bunların toplamı)
                SqlCommand komutFiyat = new SqlCommand("SELECT SUM(fiyat * stok_adedi) FROM Urunler", baglanti);
                object sonuc = komutFiyat.ExecuteScalar();

                // Eğer tablo boşsa hata almamak için kontrol ekliyoruz
                decimal toplamDeger = (sonuc != DBNull.Value) ? Convert.ToDecimal(sonuc) : 0;
                lblToplamFiyat.Text = "Toplam Değer: " + toplamDeger.ToString("N2") + " TL";

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken hata oluştu: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            FrmUrunler frm = new FrmUrunler();
            frm.Show();
        }

        private void lblToplamUrun_Click(object sender, EventArgs e)
        {

        }
        private void KritikStoklariListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                // Stoğu 5'ten az olan ürünleri çeken SQL sorgusu
                string sorgu = "SELECT urun_kodu, urun_ad, stok_adedi FROM Urunler WHERE stok_adedi < 5";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Veriyi DataGridView'e bağlama
                dgvKritikStok.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kritik stok listesi yüklenirken hata: " + ex.Message);
            }
        }

        private void dgvKritikStok_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Stok adedi sütununa bak (2. sütun olduğunu varsayıyoruz)
            if (dgvKritikStok.Columns[e.ColumnIndex].Name == "stok_adedi")
            {
                if (Convert.ToInt32(e.Value) < 3) // Stok 3'ten de azsa daha koyu kırmızı
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }
    }


}
