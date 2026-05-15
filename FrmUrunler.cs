using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETYS
{

    public partial class FrmUrunler : Form
    {
        int seciliUrunId = 0;
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\mehme\source\repos\ETYS\ETYS\ETYSDB.mdf';Integrated Security=True");
        private void btnUrunler_Click(object sender, EventArgs e)
        {

            FrmUrunler frm = new FrmUrunler();
            frm.Show();
        }
        
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Ürün listesini DataGridView'e dolduran metodunu çağırıyoruz
                Listele();

                // 2. Kategori bilgilerini veritabanından çekip ComboBox'a dolduruyoruz
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kategoriler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategori.DisplayMember = "kategori_ad"; // Listede görünecek isim
                cmbKategori.ValueMember = "kategori_id";   // Arka planda tutulacak ID değeri
                cmbKategori.DataSource = dt;

                baglanti.Close();

                // 3. Form başlığını standart hale getiriyoruz
                this.Text = "Ürün Yönetim Paneli";
            }
            catch (Exception ex)
            {
                // Herhangi bir bağlantı hatasında programın çökmemesi için
                MessageBox.Show("Ürünler yüklenirken bir hata oluştu: " + ex.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }   
        }

        private void FrmUrunler_Load_1(object sender, EventArgs e)
        {
            MessageBox.Show("Load çalıştı");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Listele();
            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "INSERT INTO Urunler (urun_kodu,urun_ad, fiyat, stok_adedi, kategori_id) VALUES (@urunkodu,@ad, @fiyat, @stok, @kategori)",
                baglanti);
            komut.Parameters.AddWithValue("@urunkodu", txtUrunKodu.Text);
            komut.Parameters.AddWithValue("@ad", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
            komut.Parameters.AddWithValue("@stok", txtStok.Text);
            komut.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue);

            komut.ExecuteNonQuery();

            baglanti.Close();
            Listele();
            MessageBox.Show("Ürün eklendi");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand(
                "DELETE FROM Stok_Hareketleri WHERE urun_id = @id",
                baglanti);

            komut1.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["urun_id"].Value);
            komut1.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand(
                "DELETE FROM Urunler WHERE urun_id = @id",
                baglanti);

            komut2.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["urun_id"].Value);
            komut2.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Ürün silindi");

            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliUrunId == 0)
                {
                    MessageBox.Show("Lütfen listeden güncellenecek bir ürün seçin!");
                    return;
                }

                baglanti.Open();
                SqlCommand komut = new SqlCommand(
                    "UPDATE Urunler SET urun_ad=@ad, fiyat=@fiyat, stok_adedi=@stok, kategori_id=@kategori WHERE urun_id=@id",
                    baglanti);

                komut.Parameters.AddWithValue("@ad", txtUrunAd.Text);
                komut.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(txtFiyat.Text)); // Decimal yapman gerektiğini konuşmuştuk!
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txtStok.Text));
                komut.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue);
                komut.Parameters.AddWithValue("@id", seciliUrunId); // Hafızadaki ID'yi kullandık

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Ürün başarıyla güncellendi.");
                Listele(); // Listeyi yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
                baglanti.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void Listele()
        {
            SqlConnection baglanti = new SqlConnection(
         @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\mehme\source\repos\ETYS\ETYS\ETYSDB.mdf';Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from urunler", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunKodu.Text = dataGridView1.SelectedRows[0].Cells["urun_kodu"].Value.ToString();
            txtUrunAd.Text = dataGridView1.SelectedRows[0].Cells["urun_ad"].Value.ToString();
            txtFiyat.Text = dataGridView1.SelectedRows[0].Cells["fiyat"].Value.ToString();
            txtStok.Text = dataGridView1.SelectedRows[0].Cells["stok_adedi"].Value.ToString();

            cmbKategori.SelectedValue = dataGridView1.CurrentRow.Cells["kategori_id"].Value;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
        "SELECT * FROM Urunler WHERE urun_ad LIKE '%" + txtAra.Text + "%'",
        baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan satır boş değilse
            if (dataGridView1.CurrentRow != null)
            {
                // 1. ID'yi hafızaya al (En önemli kısım burası!)
                seciliUrunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["urun_id"].Value);

                // 2. Diğer bilgileri kutucuklara doldur
                txtUrunKodu.Text = dataGridView1.CurrentRow.Cells["urun_kodu"].Value.ToString();
                txtUrunAd.Text = dataGridView1.CurrentRow.Cells["urun_ad"].Value.ToString();
                txtFiyat.Text = dataGridView1.CurrentRow.Cells["fiyat"].Value.ToString();
                txtStok.Text = dataGridView1.CurrentRow.Cells["stok_adedi"].Value.ToString();
                cmbKategori.SelectedValue = dataGridView1.CurrentRow.Cells["kategori_id"].Value;
            }
        }
    }
}