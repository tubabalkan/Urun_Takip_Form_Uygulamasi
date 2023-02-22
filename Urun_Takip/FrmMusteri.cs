using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TblMusteriTableAdapter tb = new DataSet1TableAdapters.TblMusteriTableAdapter();
        //DataSet1TableAdapters.TblMusteriTableAdapter sınıfından tb olarak yeni bir nesne oluşturduk
        private void TxtBakiye_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
           
           
            dataGridView1.DataSource = tb.MusteriListesi();
            //dataGridView1 in veri kaynagı tb den gelen müşteri litesi
            
            //databind web tabanlı projelerde kullanılır


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            tb.MusteriEkle(TxtAd.Text, TxtSoyad.Text, TxtSehir.Text, decimal.Parse(TxtBakiye.Text));
            MessageBox.Show("Muşteri Sisteme Kaydedildi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSil(int.Parse(TxtId.Text));
            MessageBox.Show("Muşteri Sistemden Silindi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            tb.MusteriGuncelle(TxtAd.Text, TxtSoyad.Text, TxtSehir.Text, decimal.Parse(TxtBakiye.Text),int.Parse(TxtId.Text));
            MessageBox.Show("Muşteri Bilgisi Güncellenmiştir");


        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if(RdbAd.Checked == true)
            {
               dataGridView1.DataSource = tb.AdaGoreListele(TxtAraDeger.Text);
            }
            if(RdbSehir.Checked==true)
            {
                dataGridView1.DataSource = tb.SehreGoreListele(TxtAraDeger.Text);
            }
            if(RdbSoyad.Checked== true)
            {
                dataGridView1.DataSource = tb.SoyadaGöreListele(TxtAraDeger.Text);
            }
        }
    }
}
