using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankaTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0NNHPCV\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True");

        private void LnkKayitol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void BtnGirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLKISILER where hesapno=@p1 and sıfre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", MskHesapno.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm2 = new Form2();
                frm2.hesap = MskHesapno.Text;
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı bilgi tekrardan deneyiniz");
            }
            baglanti.Close();
        }
    }
}
