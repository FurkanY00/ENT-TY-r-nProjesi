using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENTİTYProjeUygulama
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        DbentıtyUrunEntities db = new DbentıtyUrunEntities();
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tblkategori.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label13.Text = db.TBLURUN.Sum(y => y.STOK).ToString();
            label21.Text=db.TBLSATIS.Sum(z=>z.FIYAT).ToString() + "TL";
            label11.Text = (from x in db.TBLURUN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text=(from x in db.TBLURUN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            label15.Text = db.TBLURUN.Count(X => X.KATEGORI == 1).ToString();
            label17.Text = db.TBLURUN.Count(x => x.URUNAD == "buzdolabı").ToString();
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frmanaform FR = new Frmanaform();
            FR.Show();
            this.Close();
        }
    }
}
