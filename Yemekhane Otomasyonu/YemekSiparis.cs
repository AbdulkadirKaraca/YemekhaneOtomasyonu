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
    public partial class YemekSiparis : Form
    {
        OleDbConnection Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb");
        Double Hesap;
        public YemekSiparis()
        {
            InitializeComponent();
        }

        private void YemekSiparis_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            String kart;
            label2.Text = IslemSecim.KartNumarası;
            label4.Text = IslemSecim.IslemSecimBakiye;
            kart = label2.Text;
            if (kart[0] == '1')
            {
                Ogrenci.Enabled = true;
                Ogrenci.Visible = true;
                Personel.Enabled = false;
                Personel.Visible = false;
               
            }
            else if(kart[0] == '2')
            {
                Personel.Enabled = true;
                Personel.Visible = true;
                Ogrenci.Enabled = false;
                Ogrenci.Visible = false;
                
                
            }
            label11.Text = "0 TL";
        }

        private void Ogrenci_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Personel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Hesapla_Click(object sender, EventArgs e)
        {
            DialogResult Secim;
            
            if(C1.Checked==true|| C2.Checked == true|| C3.Checked == true) { Hesap += 1; }
            if (S1.Checked == true || S2.Checked == true || S3.Checked == true) { Hesap += 1.5; }
            if (Y1.Checked == true || Y2.Checked == true || Y3.Checked == true) { Hesap += 1.5; }
            if (I1.Checked == true || I2.Checked == true || I3.Checked == true) { Hesap += 1; }
            
            Secim = MessageBox.Show("Ödeyecginiz Tutar " + Hesap + " TL" + "\n" + "Ödeme Yapmak İstiyor musunuz!!", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Secim == DialogResult.Yes)
            {
                if(Convert.ToDouble(KartOkuma.Bakiye)< Hesap)
                {
                    MessageBox.Show("Bakiyeniz yetersiz sadece "+ KartOkuma.Bakiye+" TL tutarında alış veriş yapabilirsiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    C1.Checked = false; C2.Checked = false; C3.Checked = false;
                    S1.Checked = false; S2.Checked = false; S3.Checked = false;
                    Y1.Checked = false; Y2.Checked = false; Y3.Checked = false;
                    I1.Checked = false; I2.Checked = false; I3.Checked = false;
                    Hesap = 0;
                }
                else { 
                Baglanti.Open();
                Double Tutar = Convert.ToDouble(KartOkuma.Bakiye) - Hesap;
                Tutar.ToString();
                String Sorgu = "UPDATE Ogrenci SET Bakiye='" + Tutar + "'WHERE KartNo=" + Convert.ToInt32(label2.Text);
                OleDbCommand Guncel = new OleDbCommand(Sorgu, Baglanti);
                Guncel.ExecuteNonQuery();
                MessageBox.Show("Ödeme işleminiz başarı ile gerçekleşti"+"  Afiyet Olsun", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Baglanti.Close();
                Giris g = new Giris();
                g.Show();
                this.Close();
                }
            }
            else if(Secim== DialogResult.No)
            {
                C1.Checked = false; C2.Checked = false; C3.Checked = false;
                S1.Checked = false; S2.Checked = false; S3.Checked = false;
                Y1.Checked = false; Y2.Checked = false; Y3.Checked = false;
                I1.Checked = false; I2.Checked = false; I3.Checked = false;
                Hesap = 0;

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IslemSecim git = new IslemSecim();
            git.Show();
            this.Close();
        }

        private void HesaplaPer_Click(object sender, EventArgs e)
        {
            if (CC1.Checked == true) { Hesap += 2.00; }
            if (CC2.Checked == true) { Hesap += 2.00; }
            if (CC3.Checked == true) { Hesap += 2.00; }
            if (SS1.Checked == true) { Hesap += 3.00; }
            if (SS2.Checked == true) { Hesap += 3.00; }
            if (SS3.Checked == true) { Hesap += 3.00; }
            if (YY1.Checked == true) { Hesap += 3.00; }
            if (YY2.Checked == true) { Hesap += 3.00; }
            if (YY3.Checked == true) { Hesap += 3.00; }
            if (II1.Checked == true) { Hesap += 1.5; }
            if (II2.Checked == true) { Hesap += 1.5; }
            if (II3.Checked == true) { Hesap += 1.5; }
            label11.Text=Hesap+" TL";
            DialogResult Secim;
            Secim = MessageBox.Show("Ödeyecginiz Tutar " + Hesap + " TL" + "\n" + "Ödeme Yapmak İstiyor musunuz!!", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Secim == DialogResult.Yes)
            {
                if (Convert.ToDouble(KartOkuma.Bakiye) < Hesap)
                {
                    MessageBox.Show("Bakiyeniz yetersiz sadece " + KartOkuma.Bakiye + " TL tutarında alış veriş yapabilirsiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1_Click(button1, new EventArgs());
                }
                else { 
                    Baglanti.Open();
                Double Tutar = Convert.ToDouble(KartOkuma.Bakiye) - Hesap;
                Tutar.ToString();
                String Sorgu = "UPDATE Personel SET Bakiye='" + Tutar + "'WHERE KartNo=" + Convert.ToInt32(label2.Text);
                OleDbCommand Guncel = new OleDbCommand(Sorgu, Baglanti);
                Guncel.ExecuteNonQuery();
                MessageBox.Show("Ödeme işleminiz başarı ile gerçekleşti" + "  Afiyet Olsun", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Baglanti.Close();
                Giris g = new Giris();
                g.Show();
                this.Close();
                }
            }
            else if (Secim == DialogResult.No) { this.Show(); }
                
                Hesap = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in CCorba.Controls )
            foreach (Control item1 in SSulu.Controls)
            foreach (Control item2 in YYemek.Controls)
            foreach (Control item3 in IIcecek.Controls)
             {
                if (item is CheckBox){((CheckBox)item).Checked = false;}
                if (item1 is CheckBox){((CheckBox)item1).Checked = false;}
                if (item2 is CheckBox) { ((CheckBox)item2).Checked = false; }
                if (item3 is CheckBox) { ((CheckBox)item3).Checked = false; }
             }
            Hesap = 0;
            label11.Text = "0 TL";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IslemSecim sec = new IslemSecim();
            sec.Show();
            this.Close();
        }

        private void Odeme_Click(object sender, EventArgs e)
        {
           
        }
    }
}
