using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Yemekhane_Otomasyonu
{
    public partial class Giris : Form
    {
     
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
        }

        private void Giris_Click(object sender, EventArgs e)
        {
            KartOkuma KartOku = new Yemekhane_Otomasyonu.KartOkuma();
            KartOku.Show();
            this.Hide();

        }

        private void Misafir_Click(object sender, EventArgs e)
        {

        }

        private void YeniKayit_Click(object sender, EventArgs e)
        {
            YeniKayit Yeni = new Yemekhane_Otomasyonu.YeniKayit();
            Yeni.Show();
            this.Hide();
        }

        private void button4_Cikis(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediginizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (sonuc == DialogResult.Yes)
            {
                Giris.ActiveForm.Close();
            }
        }
    }
}
