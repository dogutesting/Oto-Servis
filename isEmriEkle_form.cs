using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Servis
{
    public partial class isEmriEkle_form : Form
    {
        Form f;
        public static aracKabulObj paslananObj;
        public isEmriEkle_form()
        {
            InitializeComponent();
        }

        public isEmriEkle_form(aracKabulObj pasla)
        {
            InitializeComponent();
            paslananObj = pasla;
            //f = new isEmriSayfalari.aracKabul(pasla);
            f = new isEmriSayfalari.aracKabul();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f);
            f.Show();
        }

        private void isEmriEkle_form_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aracKabulButton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            f = new isEmriSayfalari.aracKabul();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f);
            f.Show();
            aracKabulButton.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            servisAsamalariButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            eklemelerButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        }

        private void servisAsamalariButton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            f = new isEmriSayfalari.elisciligi();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f);
            f.Show();
            aracKabulButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            servisAsamalariButton.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            eklemelerButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        }

        private void eklemelerButton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            f = new isEmriSayfalari.eklemeler();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f);
            f.Show();
            aracKabulButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            servisAsamalariButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            eklemelerButton.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {

        }

        private void kapatButton_Click(object sender, EventArgs e)
        {

        }
    }
}
