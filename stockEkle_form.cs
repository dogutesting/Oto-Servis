using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Oto_Servis
{
    public partial class stockEkle_form : Form
    {
        MySqlConnection con;
        public stockEkle_form()
        {
            InitializeComponent();

            tbResim.Enabled = false;

            ConnectionClass connect = new ConnectionClass();
            con = connect.myConnection();

            con.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM birimler", con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                cbBirim.Items.Add(read["birimTuru"].ToString());
            }
            con.Close();
        }

        private void stockEkle_form_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            string urunAdi, marka, birim, birimFiyat, miktar, barkod, resim;
            urunAdi = tbUrunAdi.Texts;
            marka = tbMarka.Texts;
            birim = cbBirim.Texts;
            birimFiyat = tbBirimFiyati.Texts;
            miktar = tbMiktar.Texts;
            barkod = tbBarkod.Texts;
            resim = tbResim.Texts;

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            //MessageBox.Show(date.ToString().Split(' ')[0]);
            
            if(string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(birim) || string.IsNullOrEmpty(birimFiyat))
            {
                MessageBox.Show("Ürün Adı, Birim ve Birim Fiyatı alanları boş bırakılamaz.");
                return;
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO stocks (marka, urunAdi, birim, miktar, fiyat, barkod, eklenmeTarihi, urunResim) " +
                    $"VALUES('{marka}', '{urunAdi}', '{birim}', '{miktar}', '{birimFiyat}', '{barkod}', '{date.ToString("yyyy-MM-dd")}', '{Regex.Escape(resim)}')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                
                MessageBox.Show("Ürün eklendi");
                //stock_form frm = new stock_form();
                //frm.Refresh();
                Form1.f.Refresh();
                this.Close();
            }
        }

        private void tbUrunAdi__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUrunAdi.Texts))
            {
                if(notStartWithSpace(tbUrunAdi.Texts.ToCharArray()[0]))
                {

                    tbUrunAdi.Texts = String.Empty;
                    //tbUrunAdi.isPlaceholder = false;
                }
            }
        }

        private void tbMarka__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMarka.Texts))
            {
                if (notStartWithSpace(tbMarka.Texts.ToCharArray()[0]))
                {
                    tbMarka.Texts = String.Empty;
                    //tbMarka.Texts = "";
                }
            }
        }

        private void cbBirim_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(tbUrunAdi.Texts))
            {
                if (notStartWithSpace(tbUrunAdi.Texts.ToCharArray()[0]))
                {
                    tbUrunAdi.Texts = "";
                }
            }
            */
        }

        
        private void tbBirimFiyati__TextChanged(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(tbBirimFiyati.Texts))
            {
                if (notStartWithSpace(tbBirimFiyati.Texts.ToCharArray()[0]))
                {
                    tbUrunAdi.Texts = String.Empty;
                }
                if(!string.IsNullOrEmpty(tbBirimFiyati.Texts) && !tbBirimFiyati.Texts.All(char.IsDigit))
                {
                    tbBirimFiyati.Texts = tbBirimFiyati.Texts.Remove(tbBirimFiyati.Texts.Length - 1);
                }
            }
            */
        }

        private void tbMiktar__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUrunAdi.Texts))
            {
                if (notStartWithSpace(tbUrunAdi.Texts.ToCharArray()[0]))
                {
                    tbMiktar.Texts = String.Empty;
                }
            }
        }

        private void tbBarkod__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUrunAdi.Texts))
            {
                if (notStartWithSpace(tbUrunAdi.Texts.ToCharArray()[0]))
                {
                    tbBarkod.Texts = String.Empty;
                }
            }
        }

        private void tbResim__TextChanged(object sender, EventArgs e)
        {
            
            /*
            if (!string.IsNullOrEmpty(tbUrunAdi.Texts))
            {
                if (notStartWithSpace(tbUrunAdi.Texts.ToCharArray()[0]))
                {
                    //tbUrunAdi.Texts = "";
                }
            }
            */
        }

        private bool notStartWithSpace(char character)
        {
            bool returnedValue = false;
            if (String.IsNullOrWhiteSpace(character.ToString()))
            {
                returnedValue = true;
                //MessageBox.Show("Boşluk ile başlayamazsınız.");
            }
            return returnedValue;
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    tbResim.Texts = path;
                }
            }
        }

        private void tbBirimFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("HGere");
        }
    }
}
