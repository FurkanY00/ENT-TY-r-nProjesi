using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ENTİTYProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbentıtyUrunEntities DB =new DbentıtyUrunEntities();
        private void BTNLİSTELE_Click(object sender, EventArgs e)
        {
            var kategoriler =DB.tblkategori.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BTNEKLE_Click(object sender, EventArgs e)
        {
            tblkategori t = new tblkategori();
            t.AD=textBox2.Text;
            DB.tblkategori.Add(t);
            DB.SaveChanges();
            MessageBox.Show("kategori eklendi");
        }

        private void BTNSİL_Click(object sender, EventArgs e)
        {
            int x =Convert.ToInt32(textBox1.Text);
            var ktgr = DB.tblkategori.Find(x);
            DB.tblkategori.Remove(ktgr);
            DB.SaveChanges();
            MessageBox.Show("kategori silindi");

        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(textBox1.Text);
            var ktgr = DB.tblkategori.Find(x);
            ktgr.AD=textBox2.Text;
            DB.SaveChanges();
            MessageBox.Show("Bilgi Güncellendi");



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frmanaform FR = new Frmanaform();
            FR.Show();
            this.Close();
        }
    }
}
