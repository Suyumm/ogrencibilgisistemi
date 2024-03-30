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

namespace ogrencibilgisistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\obs.accdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitlistele();
        }
        private void kayitlistele()
        {
            try
            {
                bag.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from bilgi", bag);
                DataSet bsBilgi = new DataSet();
                liste.Fill(bsBilgi);
                dataGridView1.DataSource = bsBilgi.Tables[0];
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();

            OleDbCommand ekle = new OleDbCommand("insert into bilgi(o_No,ad,soyad,bolum,dal,sinif,sube,ort)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + textBox4.Text + "')", bag);
            ekle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi kaydedildi ");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            kayitlistele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //string bolum = comboBox1.SelectedItem.ToString();
            if (comboBox1.Text=="Bilişim")
            {
                string[] dal = { "Veri Tabanı", "Ağ Sistemleri ve Yönlendirme" };
                comboBox2.Items.AddRange(dal);
            }
            else if (comboBox2.Text == "Elektrik-Elektronik")
            {
                string[] dal = { "Bakım ve Onarım", "Elektrik" };
                comboBox2.Items.AddRange(dal);
            }
            else if (comboBox3.Text == "Muhasebe")
            {
                string[] dal = { "Finansman", "Muhasebe" };
                comboBox2.Items.AddRange(dal);
            }
            else if (comboBox4.Text == "Grafik")
            {
                string[] dal = { "Fotoğraf", "Tasarım" };
                comboBox2.Items.AddRange(dal);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select*from bilgi where o_No='" + textBox1.Text + "'", bag);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand sil = new OleDbCommand("delete from bilgi where o_No='" + textBox1.Text + "'", bag);
            sil.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi silindi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand guncelle = new OleDbCommand("update bilgi set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',ort='"+textBox4.Text+ "' where o_No='" + textBox1.Text + "' ", bag);
            guncelle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("bilgi güncellendi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            textBox4.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select* from bilgi where ad like '" + textBox2.Text + "%'", bag);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                bag.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
