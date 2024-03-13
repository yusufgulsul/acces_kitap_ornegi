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
    public partial class kulanicı_giris : Form
    {
        public kulanicı_giris()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0;Data Source = kutuphane.mdb");
     

            private void button1_Click(object sender, EventArgs e)
            {

                string sql = "SELECT * FROM kulanıcı_parola";
                OleDbCommand komut = new OleDbCommand(sql, baglanti);
                baglanti.Open();

                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();



                if (oku.GetValue(1).ToString() == textBox1.Text && oku.GetValue(2).ToString() == textBox2.Text)
                {
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(" kulanıcı adı veya parola yanlış");
                }
                baglanti.Close();
                    
         
            }

        }
    }

           
           
            

            
        

