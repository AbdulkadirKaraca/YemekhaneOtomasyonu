using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Yemekhane_Otomasyonu
{
    public partial class KayitSilme : Form
    {
        public KayitSilme()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb");
       
        private void button1_Geri(object sender, EventArgs e)
        {
            KartIslemleri KrtIslm = new Yemekhane_Otomasyonu.KartIslemleri();
            KrtIslm.Show();
            this.Close();
        }

        private void KayitSilme_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            if (YeniKayit.KartNo == null)
            {
                label2.Text = KartOkuma.KartNo;
            }
            else
                label2.Text = YeniKayit.KartNo;
        }

        private void button2_Sil(object sender, EventArgs e)
        {
            if(label2.Text[0] == '1')
            KayitSilOg(Convert.ToInt32(label2.Text));
            else
                KayitSilPersonel(Convert.ToInt32(label2.Text));

        }
        public void KayitSilOg(int Id)
        {

            DialogResult Secim;
            Secim = MessageBox.Show("Kaydınızı silmek istyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                Baglanti.Open();
                OleDbCommand Sil = new OleDbCommand("DELETE FROM Ogrenci WHERE KartNo=" + Id + "", Baglanti);
                Sil.ExecuteNonQuery();
                Baglanti.Close();
                MessageBox.Show(Id + " Numaralı Ögrenci kaydınız Silindi..."+" Hesaptaki "+KartOkuma.Bakiye+" TL"+"paranızı almayı untmayınız", "Bilgi");
                Giris Git = new Giris();
                Git.Show();
                this.Close();

            }
        }
        public void KayitSilPersonel(int Id)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Kaydınızı silmek istyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                Baglanti.Open();
                OleDbCommand Sil = new OleDbCommand("DELETE FROM Personel WHERE KartNo=" + Id + "", Baglanti);
                Sil.ExecuteNonQuery();
                Baglanti.Close();
                MessageBox.Show(Id + " Numaralı Personel kaydınız Silindi..." + " Hesaptaki " + KartOkuma.Bakiye + " TL" + "paranızı almayı untmayınız", "Bilgi");
                Giris Git = new Giris();
                
                Git.Show();
                this.Close();

            }
        }
    }
}
