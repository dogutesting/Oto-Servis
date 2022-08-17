using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    public partial class cariEkle_form : Form
    {
        MySqlConnection con;
        public cariEkle_form()
        {
            InitializeComponent();
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();
        }

        bool gelenFormVar = false;
        Form gelenForm;
        public cariEkle_form(Form gelenForm)
        {
            InitializeComponent();

            gelenFormVar = true;
            this.gelenForm = gelenForm;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();
        }

        private void cariEkle_form_Load(object sender, EventArgs e)
        {
            string[] installs = new string[] {"Müşteri", "Personel", "Diğer"};
            grupComboBox.Items.AddRange(installs);
            grupComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            grupComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cariEkleButton_Click(object sender, EventArgs e)
        {
            string grup, unvan, telefon, eposta, adres, notlar;

            grup = grupComboBox.Text;
            unvan = unvanTextBox.Texts;
            telefon = telefonTextBox.Texts;
            eposta = epostaTextBox.Texts;
            adres = adresTextBox.Texts;
            notlar = notlarTextBox.Texts;

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            //MessageBox.Show(date.ToString().Split(' ')[0]);

            if (string.IsNullOrEmpty(grup) || string.IsNullOrEmpty(unvan))
            {
                MessageBox.Show("Grup ve Ünvan alanları boş bırakılamaz.");
                return;
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO cariler (grup, unvan, telefon, eposta, adres, notlar, eklenmeTarihi) " +
                    $"VALUES('{grup}', '{unvan}', '{telefon}', '{eposta}', '{adres}', '{notlar}', '{date.ToString("dd-MM-yyyy")}')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cari eklendi.");
                //cariEkle_form frm = new cariEkle_form();
                //frm.Refresh();
                
                this.Close();
            }
        }

        private void cariEkle_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(gelenFormVar)
            {
                gelenForm.Show();
            }
        }
    }
}
