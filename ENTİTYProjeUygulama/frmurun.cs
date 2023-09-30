using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENTİTYProjeUygulama
{
    public partial class frmurun : Form
    {
        public frmurun()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DbentıtyUrunEntities db =new DbentıtyUrunEntities();
        private void BTNLİSTELE_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.ID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FİYAT,
                                            x.tblkategori.AD,
                                            x.DURUM,

                                        }).ToList();




                                        
        }

        private void BTNEKLE_Click(object sender, EventArgs e)
        {
            TBLURUN t =new TBLURUN();
            t.URUNAD = TXTAD.Text;
            t.MARKA=TXTMARKA.Text;
            t.STOK=short.Parse(TXTSTOK.Text);
            t.KATEGORI = int.Parse(comboBox1.Text);
            t.FİYAT = decimal.Parse(TXTFİYAT.Text);
            t.DURUM = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("ürün sisteme kaydedildi");

        }

        private void BTNSİL_Click(object sender, EventArgs e)
        {
            int x =Convert.ToInt32(TXTID.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("ürün silindi");
            dataGridView1.DataSource=db.TBLURUN.ToList();
            
        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TXTID.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = TXTAD.Text;
            urun.STOK = short.Parse(TXTSTOK.Text);
            urun.MARKA= TXTMARKA.Text;
            urun.FİYAT = decimal.Parse(TXTFİYAT.Text);
            urun.DURUM = bool.Parse(TXTDURUM.Text);
            urun.KATEGORI = int.Parse(comboBox1.Text);
            db.SaveChanges();
            MessageBox.Show("ürün güncellendi");
            dataGridView1.DataSource = db.TBLURUN.ToList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            TXTAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TXTMARKA.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            TXTFİYAT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TXTDURUM.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void frmurun_Load(object sender, EventArgs e)
        {
            var kstegoriler = (from x in db.tblkategori 
                               select new 
                               { 
                                   x.ID,
                                   x.AD 
                               }
                               ).ToList();
            comboBox1.ValueMember = "ıd";
            comboBox1.DisplayMember= "ad";
            comboBox1.DataSource=kstegoriler;   
        }

        private void BTNTEMİZLE_Click(object sender, EventArgs e)
        {
           
        }
    }
}
