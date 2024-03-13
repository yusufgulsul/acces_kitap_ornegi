using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutupane_ders_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand comut;
        OleDbDataAdapter adaptr;
        string kitap_no = "0";
        void Listele()
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = kutuphane.mdb");
            
            adaptr = new OleDbDataAdapter("SELECT * FROM kitaplar", baglanti);
            DataTable tablo = new DataTable();
            adaptr.Fill(tablo);

            baglanti.Open();
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO kitaplar (adi,yazar,tur,raf,sayfa_sayisi) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"',"+textBox5.Text+")";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kitap_no != "0")
            {
                baglanti.Open();
                string silmeSorgusu = "DELETE FROM kitaplar WHERE Kimlik =" + kitap_no + "";

                OleDbCommand komut = new OleDbCommand(silmeSorgusu, baglanti);

                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kitap_no != "0")
            {
                baglanti.Open();
                string silmeSorgusu = "UPDATE kitaplar SET adi = '"+textBox1.Text+"',yazar = '"+textBox2.Text+"' ,tur = '"+textBox3.Text+"' ,raf = '"+textBox4.Text+"' ,sayfa_sayisi ="+textBox5.Text+"  WHERE Kimlik =" + kitap_no + "";

                OleDbCommand komut = new OleDbCommand(silmeSorgusu, baglanti);

                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
        }

     

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            kitap_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM kitaplar";
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            baglanti.Open();

            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();

            if (oku.GetValue(1).ToString() == "admin")
                MessageBox.Show("Giriş Başarılı");
        }
    }
}
