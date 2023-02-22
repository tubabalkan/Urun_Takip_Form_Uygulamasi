using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DbUrun; 
            Integrated Security = True");

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut1 =new  SqlCommand("select count(*) From TblKategori",baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                LblToplamKategori.Text = dr[0].ToString();
                
            }
          baglanti.Close();

            //Toplam Ürün Sayisi
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) From TblUrun", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Toplam Beyaz Eşya Sayısı
            baglanti.Open();
            SqlCommand komut3=  new SqlCommand("Select count(*) From TblUrun Where Kategori=(Select ID From TblKategori Where Ad = 'Beyaz Esya')", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBeyazEsyaSayisi.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Toplam Beyaz Eşya Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(*) From TblUrun Where Kategori=(Select ID From TblKategori Where Ad = 'Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while(dr4.Read())
            {
                LblKucukEvAletiSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //En Yüksek Stoklu Ürün
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * From TblUrun where Stok=(Select Max(Stok) From TblUrun)", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblEnYuksekStok.Text = dr5["UrunAd"].ToString();
            }
            baglanti.Close();

            //En Düşük Stoklu Ürün
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * From TblUrun where Stok=(Select Min(Stok) From TblUrun)", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
             LblEnDusukStok.Text = dr6["UrunAd"].ToString();
            }
            baglanti.Close();

            //Leptop toplam kar oranı
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand(" select Stok*(SatisFiyat - AlisFiyat) from TblUrun where UrunAd ='Leptop'", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblToplamLeptopKar.Text = dr7[0].ToString() +" ₺";
            }
            baglanti.Close();

            //Beyaz Eşya toplam kar oranı
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select sum(Stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Çarpılan Sonuc' from TblUrun Where  Kategori = (Select ID from TblKategori where Ad = 'Beyaz Esya')",baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblBeyazEsyaKar.Text = dr8[0].ToString() + " ₺";
            }
            baglanti.Close();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
