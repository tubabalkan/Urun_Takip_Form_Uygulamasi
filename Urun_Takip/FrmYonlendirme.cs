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
    public partial class FrmYonlendirme : Form
    {
        public FrmYonlendirme()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
          FrmÜrün fr = new FrmÜrün();
            fr.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
              
        }

        private void Pnlistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik frm = new Frmİstatistik();
            frm.Show();
           
                
        }

        private void PnlGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();

        }

        private void PnlLogin_Click(object sender, EventArgs e)
        {
            FrmAdmin frm = new FrmAdmin();
            frm.Show();
            this.Hide();
        }

        private void FrmYonlendirme_Load(object sender, EventArgs e)
        {

        }
    }
}
