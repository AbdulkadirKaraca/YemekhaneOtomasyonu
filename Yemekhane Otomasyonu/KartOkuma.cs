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
    public partial class KartOkuma : Form
    {
        
        public KartOkuma()
        {
            InitializeComponent();
        }
        public static String KartNo;
        public static String Adi;
        public static String Soyadi;
        public static String Bakiye;
        OleDbDataReader Oku = default(OleDbDataReader);
        
        OleDbConnection Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb");
        
        public void KartOkuma_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            
           
        }

        public void textBox1_Kartno(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox1.Text.Length != 8)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                
                    button1_Devam(button1, new EventArgs());
                
                
            }

        }
        
        private void button1_Devam(object sender, EventArgs e)
        {
            String No = textBox1.Text;
            if (No[0] == '1')
            {
                AramaOg(Convert.ToInt32(textBox1.Text));
            }
            else if (No[0] == '2')
            {
                AramaPersonel(Convert.ToInt32(textBox1.Text));
            }
            else if (No[0] != '1' || No[0] != '2')
            {
                MessageBox.Show(textBox1.Text + " Numaralı bu kart işyerimize ait degil!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                textBox1.Clear();
            }
                
           
        }
        public void AramaOg(int id)
        {
            Baglanti.Open();
            OleDbCommand Komut = new OleDbCommand("Select * FROM Ogrenci WHERE KartNo="+id+"",Baglanti);
            Oku = Komut.ExecuteReader();
            if (Oku.HasRows == true)
            {
                while (Oku.Read())
                {
                    KartNo = Oku[1].ToString();
                    Adi = Oku[2].ToString();
                    Soyadi = Oku[3].ToString();
                    Bakiye = Oku[4].ToString();

                }
                
                KartNo = textBox1.Text;
                IslemSecim Sec = new IslemSecim();
                Baglanti.Close();
                Sec.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show(textBox1.Text +" Bu kart numarası sistemde kayıtlı degil!","Uyarı",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                textBox1.Clear();
                Baglanti.Close();
                
            }
        }
        public void AramaPersonel(int id)
        {
            Baglanti.Open();
            OleDbCommand Komut = new OleDbCommand("Select * FROM Personel WHERE KartNo=" + id + "", Baglanti);
            Oku = Komut.ExecuteReader();
            if (Oku.HasRows == true)
            {
                while (Oku.Read())
                {
                    KartNo = Oku[0].ToString();
                    Adi = Oku[1].ToString();
                    Soyadi = Oku[2].ToString();
                    Bakiye = Oku[3].ToString();

                }

                KartNo = textBox1.Text;
                IslemSecim Sec = new IslemSecim();
                Baglanti.Close();
                Sec.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show(textBox1.Text + " Bu kart numarası sistemde kayıtlı degil!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                textBox1.Clear();
                Baglanti.Close();
            }
        }
        private void button2_Geri(object sender, EventArgs e)
        {

            Giris Gr = new Yemekhane_Otomasyonu.Giris();
            Gr.Show();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetter(e.KeyChar);
        }
    }
}
