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


namespace Vt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string bcum = "Data Source=(localdb)\\Projects;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        SqlConnection bag;
        SqlDataAdapter da;
        SqlDataReader de;
        SqlCommand komut;
        DataTable dt;
        DataSet ds;

        private void Listele()
        {
            bag = new SqlConnection(bcum);
            da = new SqlDataAdapter("SELECT * FROM Products", bag);
           // da = new SqlDataAdapter()
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; 
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();


        }

        private void Calistir(string proc)
        {
            bag = new SqlConnection(bcum);
            komut = new SqlCommand(proc, bag);
            komut.CommandType = CommandType.StoredProcedure;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calistir("dbo.UrunEkle");
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@fyt", textBox2.Text);
            bag.Open();
            if (komut.ExecuteNonQuery() == 0)
                MessageBox.Show("Kayıt Başarısız");
            else
            { 
                MessageBox.Show("Kayıt Eklendi");
                Listele();
            }
               
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            Calistir("UrunSil");

            komut.Parameters.AddWithValue("@id", textBox1.Tag);
            bag.Open();
            if (komut.ExecuteNonQuery() == 0)
                MessageBox.Show("Silme Başarısız");
            else
            {
                MessageBox.Show("Kayıt Silindi");
                Listele();
            }
            bag.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index == 0) return;
            int id = (int)dataGridView1.CurrentRow.Cells["ProductID"].Value;
            textBox1.Tag = id.ToString();
           // MessageBox.Show(id.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["UnitPrice"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["ProductID"].Value.ToString();
           // textBox2.Text.Replace(",", "");

            MessageBox.Show("Tag tutula ID : " + id);
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            Calistir("UrunGuncelle");

            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@fyt", textBox2.Text);
            komut.Parameters.AddWithValue("@id", textBox3.Text);
            bag.Open();
            if (komut.ExecuteNonQuery() == 0)
                MessageBox.Show("Güncelleme Başarısız");
            else
            {
                MessageBox.Show("Kayıt Güncellendi");
                Listele();
            }
            bag.Close();
        }
    }
}
