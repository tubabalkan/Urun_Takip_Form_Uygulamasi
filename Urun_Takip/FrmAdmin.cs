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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DbUrun; 
            Integrated Security = True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Admin where Kullanici = @p1 and Sifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            
            SqlDataReader dr = komut.ExecuteReader();      
            if(dr.Read())
            {
                FrmYonlendirme fr = new FrmYonlendirme();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifrenizde hata var yeniden deneyiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            baglanti.Close();
        
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
