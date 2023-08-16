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

namespace Personel_Kayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-P0AC89F\\SQLEXPRESS;Initial Catalog=PersonelVeritabani;Integrated Security=True");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayısı 
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1=komut1.ExecuteReader();
            while(dr1.Read())
            {
                toplampersonelsayısı.Text = dr1[0].ToString();
            }

            baglanti.Close();

            // Evli Personel Sayisi 

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2=komut2.ExecuteReader();
            while(dr2.Read())
            {
                evlipersonel.Text= dr2[0].ToString();
            }
            baglanti.Close();

            // Bekar Personel Sayısı 

            baglanti.Open();
            SqlCommand komut3 =new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=0",baglanti);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                bekarpersonel.Text=dr3[0].ToString();
            }
            baglanti.Close();
            // Toplam Sehir Sayısı 

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) From  Tbl_Personel", baglanti);
            SqlDataReader dr4=komut4.ExecuteReader();
            while(dr4.Read())
            {
                sehirsayisi.Text=dr4[0].ToString(); 
            }
            baglanti.Close();

            // Toplam Maas 

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5=komut5.ExecuteReader();
            while(dr5.Read())
            {
                toplammaas.Text=dr5[0].ToString();
            }
            baglanti.Close();

            // Ortalama Maas 
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6=komut6.ExecuteReader();
            while(dr6.Read())
            {
                ortalamamaas.Text=dr6[0].ToString();
            }
            baglanti.Close();
          
        }               
    }
}
