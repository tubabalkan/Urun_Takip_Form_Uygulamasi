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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DbUrun; 
            Integrated Security = True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad,count(*) From TblUrun inner Join TblKategori on TblUrun.Kategori = TblKategori.ID Group by Ad", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0], dr[1]);

            }

            baglanti.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
