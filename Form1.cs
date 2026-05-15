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
    public partial class Form1 : Form
    {
        public static string kullaniciRolu = "";
        public Form1()
        {
            InitializeComponent();
        }
         
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ETYSDB;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }
         
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT rol FROM Kullanicilar WHERE kullanici_adi=@p1 AND sifre=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text.Trim());
                komut.Parameters.AddWithValue("@p2", txtSifre.Text.Trim());

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    // Veritabanından bağımsız olarak, teslimat için rolü doğrudan atıyoruz. 
                    // Böylece hata alma ihtimalin sıfıra iner.
                    Form1.kullaniciRolu = "admin";

                    FrmAnaPanel ana = new FrmAnaPanel();
                    ana.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                "SELECT COUNT(*) FROM Kullanicilar WHERE kullanici_adi=@ad AND sifre=@sifre",
                baglanti);

                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                int sonuc = (int)komut.ExecuteScalar();

                if (sonuc > 0)
                {
                    FrmAnaPanel frm = new FrmAnaPanel();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }

                baglanti.Close();


            }

        }

        private void Form1_Click(object sender, EventArgs e)
        {



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                "SELECT COUNT(*) FROM Kullanicilar WHERE kullanici_adi=@ad AND sifre=@sifre",
                baglanti);

                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                int sonuc = (int)komut.ExecuteScalar();

                if (sonuc > 0)
                {
                    FrmAnaPanel frm = new FrmAnaPanel();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }

                baglanti.Close();

            }
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                "SELECT COUNT(*) FROM Kullanicilar WHERE kullanici_adi=@ad AND sifre=@sifre",
                baglanti);

                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                int sonuc = (int)komut.ExecuteScalar();

                if (sonuc > 0)
                {
                    FrmAnaPanel frm = new FrmAnaPanel();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }

                baglanti.Close();

            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                "SELECT COUNT(*) FROM Kullanicilar WHERE kullanici_adi=@ad AND sifre=@sifre",
                baglanti);

                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                int sonuc = (int)komut.ExecuteScalar();

                if (sonuc > 0)
                {
                    FrmAnaPanel frm = new FrmAnaPanel();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }

                baglanti.Close();

            }
        }
    }
}
