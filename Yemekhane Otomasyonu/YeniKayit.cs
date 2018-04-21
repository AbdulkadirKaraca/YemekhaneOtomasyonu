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

    public partial class YeniKayit : Form
    {
        public YeniKayit()
        {
            InitializeComponent();
        }
        public static String KartNo;
        public static String Adi;
        public static String Soyadi;

        OleDbDataReader Oku = default(OleDbDataReader);
        OleDbConnection Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb");
        private void textBox1_Isim(object sender, EventArgs e)
        {

            
        }

        private void textBox2_Soyisim(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KartNo(object sender, EventArgs e)
        {

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text != "")
                        button2.Enabled = true;
                }
            }
        }
        
        private void button1_Geri(object sender, EventArgs e)
        {
            Giris Gr = new Yemekhane_Otomasyonu.Giris();
            Gr.Show();
            this.Hide();
        }

        private void button2_Kayit(object sender, EventArgs e)
        {
            if(textBox3.Text[0]=='1'&&textBox3.Text.Length==8)
            {
                KayitEtOg();
            }
            else if (textBox3.Text[0] == '2' && textBox3.Text.Length == 8)
            {
                KayitEtPersonel();
            }
            else if (textBox3.Text[0] !='1'|| textBox3.Text[0] != '2'|| textBox3.Text.Length == 8)
            { 
                MessageBox.Show(textBox3.Text+" Numaralı kullandıgınız kart işyerimize ait degil!","Uyarı",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                textBox3.Clear();
            }
        }
        public void KayitEtOg()
        {
            //Baglanti.Open();
            OleDbCommand Komut = new OleDbCommand("Select * FROM Ogrenci WHERE KartNo=" + Convert.ToInt32(textBox3.Text) + "", Baglanti);
            Oku = Komut.ExecuteReader();
            if (Oku.HasRows == true)
            {
                MessageBox.Show(Convert.ToInt32(textBox3.Text) + "  Bu kart sistemde kaytlı lütfen başka bir kart deneyiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox3.Clear();
            }
            else { 
                OleDbCommand Kaydet = new OleDbCommand("insert into Ogrenci(KartNo,Adi,Soyadi) values(" + Convert.ToInt32(textBox3.Text) + ",'" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", Baglanti);
            Kaydet.ExecuteNonQuery();
            Baglanti.Close();
            MessageBox.Show(textBox3.Text + " Numaralı kartınız başarıyla tanımlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KartNo = textBox3.Text;
            Adi = textBox1.Text;
            Soyadi = textBox2.Text;
            KartIslemleri Krt = new KartIslemleri();
            Krt.Show();
            this.Close();

                }
        }
        public void KayitEtPersonel()
        {
            
            OleDbCommand Komut = new OleDbCommand("Select * FROM Personel WHERE KartNo=" + Convert.ToInt32(textBox3.Text) + "", Baglanti);
            Oku = Komut.ExecuteReader();
            if (Oku.HasRows == true)
            {
                MessageBox.Show(Convert.ToInt32(textBox3.Text) + "  Bu kart sistemde kaytlı lütfen başka bir kart deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
            }
            else {
                
            OleDbCommand Kaydet = new OleDbCommand("insert into Personel(KartNo,Adi,Soyadi) values(" + Convert.ToInt32(textBox3.Text) + ",'" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", Baglanti);
            Kaydet.ExecuteNonQuery();
            Baglanti.Close();
            MessageBox.Show(textBox3.Text + " Numaralı kartınız başarıyla tanımlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KartNo = textBox3.Text;
            Adi = textBox1.Text;
            Soyadi = textBox2.Text;
            
            KartIslemleri Krt = new KartIslemleri();
            Krt.Show();
            this.Close();
            }
        }

        private void YeniKayit_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
            Baglanti.Open();
            if (Baglanti.State == ConnectionState.Open) label4.Text = "Bağlantı Yapıldı";
           else label4.Text = "Bağlantı Kurulamadı";
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetter(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}
/*If DLookup("[idnumuneadi]", "tbl_numadi", "[numuneadi]=" & "'" & Me.numuneadid & "'") > 0 Then 'Form_frm_numadi.numuneadi
    If MsgBox("Aynı kayıt var Yinede Kaydetmek İstiyormusunuz", vbCritical + vbYesNo, "Kayıt Tekrarı") = vbNo Then
        Me.Undo
        'DoCmd.GoToRecord , , , Me.idnumuneadi
        Else
    End If
Else
End If*/