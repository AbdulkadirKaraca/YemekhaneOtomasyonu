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
    public partial class ParaYükleme : Form
    {
        public static String Para;
        public static String Para1;
        public ParaYükleme()
        {
            InitializeComponent();
        }
        //OleDbDataReader Oku = default(OleDbDataReader);
        OleDbConnection Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb");
       


        private void button1_Yükle(object sender, EventArgs e)
        {
            if (label4.Text[0] == '1')
                GuncelleOg(Convert.ToInt32(label4.Text));
            else if (label4.Text[0] == '2')
                GuncellePersonel(Convert.ToInt32(label4.Text));
            
        }
        public void GuncelleOg (int id)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Yüklemek istediginiz tutar "+textBox1.Text+" TL mi?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (Secim == DialogResult.Yes) {
                Double ToplamPara;
                ToplamPara = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(KartOkuma.Bakiye);
                Para = ToplamPara.ToString();
                Para1 = textBox1.Text.ToString();
                textBox1.Text = ToplamPara.ToString();
                String Sorgu = "UPDATE Ogrenci SET Bakiye='" + textBox1.Text + "'WHERE KartNo=" + id;
                OleDbCommand Guncel = new OleDbCommand(Sorgu, Baglanti); 
                Guncel.ExecuteNonQuery();
                MessageBox.Show("Paranız başarıyla yüklendi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Baglanti.Close();
                KartOkuma oku = new KartOkuma();
                oku.Show();
                this.Close();
            }
               
        }
        public void GuncellePersonel(int id)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Yüklemek istediginiz tutar " + textBox1.Text + " TL mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Secim == DialogResult.Yes)
            {
                Double ToplamPara;
                ToplamPara = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(KartOkuma.Bakiye);
                Para1 = textBox1.Text.ToString();
                Para = ToplamPara.ToString();
                textBox1.Text = ToplamPara.ToString();
                String Sorgu = "UPDATE Personel SET Bakiye='" + textBox1.Text + "'WHERE KartNo=" + id;
                OleDbCommand Guncel = new OleDbCommand(Sorgu, Baglanti);
                Guncel.ExecuteNonQuery();
                MessageBox.Show("Paranız başarıyla yüklendi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Baglanti.Close();
                KartOkuma oku = new KartOkuma();
                oku.Show();
                
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Geri(object sender, EventArgs e)
        {
            KartIslemleri KrtIsm = new Yemekhane_Otomasyonu.KartIslemleri();
            KrtIsm.Show();
            this.Close();       }

        private void ParaYükleme_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            Baglanti.Open();
            if (Baglanti.State == ConnectionState.Open) label5.Text = "Bağlantı Yapıldı";
            else label5.Text = "Bağlantı Kurulamadı";
            if (YeniKayit.KartNo == null)
            {
                label4.Text = KartOkuma.KartNo;
            }
            else
                label4.Text = YeniKayit.KartNo;
        }

        private void textBox1_Ucret(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                button1.Enabled = false;
            }
            else button1.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar)) 
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13) //Enter tuşuna basıldımı
                {

                    Single birimfiyat = Convert.ToSingle(textBox1.Text);
                    textBox1.Text = string.Format("{0:c}", double.Parse(textBox1.Text));
                    //Parabirimine dönüştür tekrar aynı text kutusuna aktar
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }
    }
}
