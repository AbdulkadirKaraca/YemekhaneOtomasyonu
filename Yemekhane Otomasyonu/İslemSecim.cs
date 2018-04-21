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
    public partial class IslemSecim : Form
    {
        public static String KartNumarası;
        public static String IslemSecimBakiye;
        public IslemSecim()
        {
            InitializeComponent();
        }

        private void button1_YemekSiparis(object sender, EventArgs e)
        {
            if (Convert.ToDouble(KartOkuma.Bakiye) >= 1.00)
            {
                YemekSiparis Yemek = new Yemekhane_Otomasyonu.YemekSiparis();
                Yemek.Show();
                this.Close();
            }
            else
                MessageBox.Show("Bakiyniz alışveriş için yetersiz yükleme yapmanız gerekiyor","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button2_KartIslem(object sender, EventArgs e)
        {
            KartIslemleri KartIslem = new KartIslemleri();
            KartIslem.Show();
            this.Hide();
        }

        private void button3_Cıkıs(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediginizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (sonuc == DialogResult.OK)
            {
                IslemSecim.ActiveForm.Close();
                this.Close();
                Application.Exit();
            }
        }

        private void İslemSecim_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            KartOkuma Oku = new KartOkuma();

            if (KartOkuma.Adi == null) {
                
                label4.Text = YeniKayit.Adi + " " + YeniKayit.Soyadi;
                label5.Text = YeniKayit.KartNo;
                KartNumarası = label5.Text;
                label6.Text = KartOkuma.Bakiye + " TL";

            }
            else
            {

                label4.Text = KartOkuma.Adi + " " + KartOkuma.Soyadi;
                label5.Text = KartOkuma.KartNo;
                KartNumarası = label5.Text;

                 label6.Text = KartOkuma.Bakiye + " TL";

            }
            if (label5.Text[0] == 1)
                Oku.AramaOg(Convert.ToInt32(label5.Text));

            else if (label5.Text[0] == 2)
            {
                Oku.AramaPersonel(Convert.ToInt32(label5.Text));
            }

            label6.Text = Convert.ToDouble(KartOkuma.Bakiye)+" TL";
            IslemSecimBakiye = label6.Text;

        }

       
    }
}
