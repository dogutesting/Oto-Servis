using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        public event EventHandler DataAdded;

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
            cbBirim.SelectedIndex = 0;
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
            string 
                urunAdi = tbUrunAdi.Texts, 
                marka = tbMarka.Texts,
                birim = cbBirim.Texts, 
                birimFiyat = tbBirimFiyati.Texts,
                birimKusurat = tbBirimKusurat.Texts,
                miktar = tbMiktar.Texts,
                barkod = tbBarkod.Texts, 
                resim = tbResim.Texts;

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            //MessageBox.Show(date.ToString().Split(' ')[0]);
            
            if(string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(birim) || string.IsNullOrEmpty(birimFiyat) || string.IsNullOrEmpty(miktar))
            {
                MessageBox.Show("Ürün Adı, Birim, Birim Fiyatı ve Miktar alanları boş bırakılamaz.");
                return;
            }
            else
            {
                if (birimFiyat.Substring(0, 1) == "0" || miktar.Substring(0, 1) == "0")
                {
                    MessageBox.Show("Fiyat ve miktar alanları 0 ile başlayamaz veya 0 olamaz.");
                    return;
                }

                string newFiyat = "";

                try
                {
                    int fiyat = int.Parse(birimFiyat);
                    int kusurat = int.Parse(birimKusurat);

                    newFiyat = fiyat.ToString() + "," + kusurat.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün fiyatı ve küsuratı tam sayı olmalı. Rakamlar dışında bir şey yazmayın. Örnek: 300 90");
                    return;
                }


                if (resim != "")
                {
                    string fileExtension = Path.GetExtension(resim);
                    string randomFileName = Guid.NewGuid().ToString() + fileExtension;
                    string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string saveDirectory = Path.Combine(applicationDirectory, "all_images");
                    if(!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    string newFilePath = Path.Combine(saveDirectory, randomFileName);
                    File.Copy(resim, newFilePath, true);

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO stocks (marka, urunAdi, birim, miktar, fiyat, barkod, eklenmeTarihi, urunResim) " +
                        $"VALUES('{marka}', '{urunAdi}', '{birim}', '{miktar}', '{newFiyat}', '{barkod}', '{date.ToString("dd-MM-yy")}', '{Regex.Escape(newFilePath)}')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO stocks (marka, urunAdi, birim, miktar, fiyat, barkod, eklenmeTarihi, urunResim) " +
                        $"VALUES('{marka}', '{urunAdi}', '{birim}', '{miktar}', '{newFiyat}', '{barkod}', '{date.ToString("yyyy-MM-dd")}', '{Regex.Escape(resim)}')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                
                //MessageBox.Show("Ürün eklendi");

                DataAdded?.Invoke(this, EventArgs.Empty);
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

        bool isFloat = false;
        private void cbBirim_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            string birimAdi = cbBirim.Texts;
            birimName.Text = birimAdi;
            tbMiktar.Texts = "";
            label4.Text = char.ToUpper(birimAdi[0]) + birimAdi.Substring(1).ToLower() + " Fiyatı*";
            if (birimAdi == "metre" || birimAdi == "litre")
            {
                isFloat = true;
            }
            else
            {
                isFloat = false;
            }
        }

        int i = 0;
        private void tbBirimFiyati__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbMiktar__TextChanged(object sender, EventArgs e)
        {
            if (tbMiktar.Texts != "")
            {
                if (isFloat)
                {
                    try
                    {
                        float f = float.Parse(tbMiktar.Texts);
                    }
                    catch
                    {
                        tbMiktar.Texts = "";
                        if(cbBirim.Texts == "")
                        {
                            MessageBox.Show("Önce birim seçin.");
                        }
                        else { 
                            MessageBox.Show("Seçilen birim: " + cbBirim.Texts + ". Bu birim için sadece ondalık sayı girilebilir. Örnek: 3.14");
                        }
                    }
                }
                else
                {
                    try
                    {
                        int i = int.Parse(tbMiktar.Texts);
                    }
                    catch
                    {
                        tbMiktar.Texts = "";
                        if (cbBirim.Texts == "")
                        {
                            MessageBox.Show("Önce birim seçin.");
                        }
                        else
                        {
                            MessageBox.Show("Seçilen birim: " + cbBirim.Texts + ". Bu birim için sadece tam sayı girilebilir.");
                        }
                    }
                }
            }
            else
            {

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

        private void tbMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {

           

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }
    }
}
