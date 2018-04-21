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
    public partial class KartIslemleri : Form
    {
        public KartIslemleri()
        {
            InitializeComponent();
        }

        private void button1_ParaYükle(object sender, EventArgs e)
        {
            ParaYükleme ParaYükle = new Yemekhane_Otomasyonu.ParaYükleme();
            ParaYükle.Show();
            this.Close();
        }

        private void button2_KartIptal(object sender, EventArgs e)
        {
            KayitSilme KartIpt = new Yemekhane_Otomasyonu.KayitSilme();
            KartIpt.Show();
            this.Close();
        }

        private void button3_Geri(object sender, EventArgs e)
        {
            IslemSecim IslemSec = new Yemekhane_Otomasyonu.IslemSecim();
            IslemSec.Show();
            this.Close();

        }

        private void KartIslemleri_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            if (YeniKayit.KartNo == null)
            {
                label2.Text = KartOkuma.KartNo;
            }
            else
                label2.Text = YeniKayit.KartNo;
        }
    }
}
