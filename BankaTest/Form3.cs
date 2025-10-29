using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankaTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0NNHPCV\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLKISILER (Ad,Soyad,TC,Telefon,Hesapno,SIFRE) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", MskHesapNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtSifre.Text);
            komut.ExecuteNonQuery();

            //Veri tabanına hesapno eklemek
            SqlCommand komutekle = new SqlCommand("insert into TBLHESAP (HESAPNO,BAKIYE) values (@k1,@k2)", baglanti);
            komutekle.Parameters.AddWithValue("@k1", MskHesapNo.Text);
            komutekle.Parameters.AddWithValue("@k2", 0);
            komutekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri bilgileri başarı ile kayıt edildi.");
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void BtnHesapNo_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi;
            bool benzersizmi = false;
            baglanti.Open();
            while (!benzersizmi)
            {
                sayi = rastgele.Next(100000, 1000000);
                SqlCommand kontrolkomut = new SqlCommand("SELECT count(*) From TBLKISILER where Hesapno = @hesapno", baglanti);
                kontrolkomut.Parameters.AddWithValue("@hesapno", sayi);
                int adet = (int)kontrolkomut.ExecuteScalar();
                if (adet == 0)
                {
                    MskHesapNo.Text = sayi.ToString();
                    benzersizmi = true;
                }
            }
            baglanti.Close();
        }
    }
}
