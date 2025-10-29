using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0NNHPCV\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        public string hesap;

        private void Hareketlerlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLHAREKET WHERE GONDEREN=@p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", hesap);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void HesapListesiYukle()
        {
            listBox1.Items.Clear();
            baglanti.Open();
            SqlCommand komutliste = new SqlCommand("SELECT HESAPNO, AD, SOYAD FROM TBLKISILER", baglanti);
            SqlDataReader dr = komutliste.ExecuteReader();
            while (dr.Read())
            {
                string satir = dr["HESAPNO"] + "-" + dr["AD"] + " " + dr["SOYAD"];
                listBox1.Items.Add(satir);
            }
            baglanti.Close();
        }
        private void BakiyeGuncelle()
        {
            baglanti.Open();
            SqlCommand bakiyeKomut = new SqlCommand("SELECT BAKIYE FROM TBLHESAP WHERE HESAPNO=@p1", baglanti);
            bakiyeKomut.Parameters.AddWithValue("@p1", hesap);
            decimal bakiye = Convert.ToDecimal(bakiyeKomut.ExecuteScalar());
            LblBakiye.Text = bakiye.ToString("C2");
            baglanti.Close();
        }
        private void listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                string secilen = listBox1.SelectedItems.ToString();
                string[] parcalar = secilen.Split('-');
                MskHesapno.Text = parcalar[0].Trim();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LblHesapno.Text = hesap;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKISILER where hesapno=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", hesap);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[1] + " " + dr[2];
                LblTC.Text = dr[3].ToString();
                LblTelefon.Text = dr[4].ToString();
            }
            dr.Close(); // Reader kapatılmalı
            baglanti.Close();

            BakiyeGuncelle(); // Ayrı fonksiyonla bakiye çek
            Hareketlerlistesi();
            HesapListesiYukle();
            dataGridView1.Columns["ID"].Width = 40;
            dataGridView1.Columns["GONDEREN"].Width = 125;
            dataGridView1.Columns["ALICI"].Width = 125;
            dataGridView1.Columns["TUTAR"].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gonderen = LblHesapno.Text;
            string alıcı = MskHesapno.Text;
            decimal tutar = Convert.ToDecimal(TxtTutar.Text);
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT BAKIYE FROM TBLHESAP WHERE HESAPNO=@p1", baglanti);
            //bakiye kontrol
            komut1.Parameters.AddWithValue("@p1", gonderen);
            decimal bakiye = Convert.ToDecimal(komut1.ExecuteScalar());
            if (bakiye>= tutar)
            {
                //gönderen bakiyesi düşmesi
                SqlCommand komut2 = new SqlCommand("UPDATE TBLHESAP SET BAKIYE = BAKIYE - @p2 WHERE HESAPNO=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", gonderen);
                komut2.Parameters.AddWithValue("@p2", tutar);
                komut2.ExecuteNonQuery();
                //alıcı bakiye düşmesi
                SqlCommand komut3 = new SqlCommand("UPDATE TBLHESAP SET BAKIYE = BAKIYE + @p2 WHERE HESAPNO=@P3", baglanti);
                komut3.Parameters.AddWithValue("@p2", tutar);
                komut3.Parameters.AddWithValue("@p3", alıcı);
                komut3.ExecuteNonQuery();
                MessageBox.Show("Havale oldu tebrik");
                //Hareketler tablosu
                SqlCommand komut4 = new SqlCommand("INSERT INTO TBLHAREKET (GONDEREN,ALICI,TUTAR) values (@p1,@p2,@p3)", baglanti);
                komut4.Parameters.AddWithValue("@p1", gonderen);
                komut4.Parameters.AddWithValue("@p2", alıcı);
                komut4.Parameters.AddWithValue("@p3", tutar);
                komut4.ExecuteNonQuery();
               

            }
            else if (bakiye==tutar)
            {
                MessageBox.Show("Bakiye sıfırlandı");
            }
            else
            {
                MessageBox.Show("Yetersiz bakiye");
            }
            baglanti.Close();
        }
    }
}
