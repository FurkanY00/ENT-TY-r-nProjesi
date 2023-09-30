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
    public partial class FRMGİRİS : Form
    {
        public FRMGİRİS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbentıtyUrunEntities DB =new DbentıtyUrunEntities();
            var sorgu = from x in DB.TBLADMİN where x.KULLANICI == textBox1.Text && x.SİFRE == textBox2.Text select x;
            if (sorgu.Any())
            {
                Frmanaform fr =new Frmanaform();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı KullanıcıADI veya şifre");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
