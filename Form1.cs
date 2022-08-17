using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    public partial class Form1 : Form
    {
        public static Form f;

        public Form1()
        {
            InitializeComponent();
            /*
            try
            {
                mysqlbaglan.Open();
                if(mysqlbaglan.State != ConnectionState.Closed)
                {
                    meslog("Bağlantı Başarılı");
                }
                else
                {
                    meslog("Bağlantı Başarısız");
                }
            }
            catch(MySqlException e)
            {
                meslog("Harici bir hata ile karşılaşıldı: " + e);
            }
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f = new stock_form();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(f);
            f.Show();
        }

        public static void meslog(Object o)
        {
            MessageBox.Show(o.ToString());
        }
        private void stokButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            f = new stock_form();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(f);
            f.Show();
        }

        private void cariButton_Click(object sender, EventArgs e)
        {
            
            mainPanel.Controls.Clear();
            f = new cari_form();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(f);
            f.Show();
        }
        private void aracButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            f = new arac_form();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(f);
            f.Show();
        }
        private void isEmri_Click(object sender, EventArgs e)
        {
            
            mainPanel.Controls.Clear();
            f = new isEmri_form();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.AutoScroll = false;
            f.AutoSize = true;
            f.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Controls.Add(f);
            f.Show();
            
        }

        public static void refreshPage()
        {
            f.Refresh();
        }

        private void kasaButton_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
