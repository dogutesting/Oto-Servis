using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    public partial class aracEkle_form : Form
    {
        MySqlConnection con;
        string resourcesFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");

    public aracEkle_form()
        {
            InitializeComponent();
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();
        }

        private void aracEkle_form_Load(object sender, EventArgs e)
        {
            /*
            string[] installs = new string[] { "mustang", "bugatti", "ferrai", "musford" };
            markaComboBox.Items.AddRange(installs);

            markaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            markaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            */

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cariler", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                aracSahibiComboBox.Items.Add(dataReader["unvan"].ToString());
                ruhsatSahibiComboBox.Items.Add(dataReader["unvan"].ToString());
                
            }
            con.Close();
           
            aracSahibiComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            aracSahibiComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            ruhsatSahibiComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ruhsatSahibiComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            string[] yakitCinsi = new string[] {"Dizel", "Benzin", "LPG", "Hibrit", "Elektrik", "Diğer"};
            yakitCinsiComboBox.Items.AddRange(yakitCinsi);
            yakitCinsiComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            yakitCinsiComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            string jsonFromFile;
            using(var reader = new StreamReader(Path.Combine(resourcesFolderPath, "json.txt")))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<brandAndModels> jsonData = JsonConvert.DeserializeObject<List<brandAndModels>> (jsonFromFile);
            foreach (var item in jsonData)
            {
                //MessageBox.Show(item.brand);
                markaComboBox.Items.Add(item.brand);
            }

            markaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            markaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            modelComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            modelComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            string[] modelYili = new string[] { "2030", "2029", "2028", "2027", "2026", "2025", "2024", "2023", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002", "2001", "2000", "1999", "1998", "1997", "1996", "1995", "1994", "1993", "1992", "1991", "1990", "1989", "1988", "1987", "1986", "1985", "1984", "1983", "1982", "1981", "1980", "1979", "1978", "1977", "1976", "1975", "1974", "1973", "1972", "1971", "1970", "1969", "1968", "1967", "1966", "1965", "1964", "1963", "1962", "1961", "1960", "1959", "1958", "1957", "1956", "1955", "1954", "1953", "1952", "1951", "1950", "1949", "1948", "1947", "1946", "1945", "1944", "1943", "1942", "1941", "1940", "1939", "1938", "1937", "1936", "1935", "1934", "1933", "1932", "1931", "1930", "1929", "1928", "1927", "1926", "1925", "1924", "1923", "1922", "1921", "1920", "1919", "1918", "1917", "1916", "1915", "1914", "1913", "1912", "1911", "1910", "1909", "1908", "1907", "1906", "1905", "1904", "1903", "1902", "1901", "1900"};
            modelYiliComboBox.Items.AddRange(modelYili);
            modelYiliComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            modelYiliComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            string[] kasaTurleri = new string[] { "Sedan", "Hatchback", "Station wagon", "Cabrio", "Pick Up", "SUV" };
            kasaTipiComboBox.Items.AddRange(kasaTurleri);
            kasaTipiComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            kasaTipiComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("-> " + markaComboBox.SelectedItem.ToString());
            //Marka selected index changed
            modelComboBox.Items.Clear();
            modelComboBox.Text = string.Empty;

            string jsonFromFile;
            using (var reader = new StreamReader(Path.Combine(resourcesFolderPath, "json.txt")))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            List<brandAndModels> jsonData = JsonConvert.DeserializeObject<List<brandAndModels>>(jsonFromFile);
            foreach (var item in jsonData)
            {
                
                if (item.brand.Equals(markaComboBox.SelectedItem.ToString()))
                {
                    foreach(var item2 in item.models)
                    {
                        //MessageBox.Show(item2);
                        modelComboBox.Items.Add(item2);
                    } 
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbMiktar__TextChanged(object sender, EventArgs e)
        {

        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void aracKaydiOlusturButton_Click(object sender, EventArgs e)
        {
            string aracSahibi, marka, model, modelYili, kilometre, plakaNo, motorNo, sasiNo, ruhsatSahibi, kasaTipi, renk, motorHacmi, tescilTarihi,
                   trafigeCikisTarihi, yakitCinsi, netAgirlik, sonBakimTarihi, garantiBitisTarihi, trafikSigortaBaslangicTarihi, trafikSigortaBitisTarihi,
                   kaskoBaslamaTarihi, kaskoBitisTarihi;

            aracSahibi = aracSahibiComboBox.Text;
            marka = markaComboBox.Text;
            model = modelComboBox.Text;
            modelYili = modelYiliComboBox.Text;
            kilometre = kilometreTextBox.Texts;
            plakaNo = plakaNoTextBox.Texts;
            motorNo = motorNoTextBox.Texts;
            sasiNo = sasiNoTextBox.Texts;
            ruhsatSahibi = ruhsatSahibiComboBox.Text;
            kasaTipi = kasaTipiComboBox.Text;
            renk = renkTextBox.Texts;
            motorHacmi = motorHacmiText.Texts;
            tescilTarihi = tescilTarihiTextBox.Texts;
            trafigeCikisTarihi = trafigeCikisTarihiTextBox.Texts;
            yakitCinsi = yakitCinsiComboBox.Text;
            netAgirlik = netAgirlikTextBox.Texts;
            sonBakimTarihi = sonBakimTarihiTextBox.Texts;
            garantiBitisTarihi = garantiBitisTarihiTextBox.Texts;
            trafikSigortaBaslangicTarihi = trafikSigortaBaslamaTarihiTextBox.Texts;
            trafikSigortaBitisTarihi = trafikSigortaBitisTarihiTextBox.Texts;
            kaskoBaslamaTarihi = kaskoBaslamaTarihiTextBox.Texts;
            kaskoBitisTarihi = kaskoBitisTarihiTextBox.Texts;

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            //MessageBox.Show(date.ToString().Split(' ')[0]);

            if (string.IsNullOrEmpty(aracSahibi) || string.IsNullOrEmpty(plakaNo) || string.IsNullOrEmpty(ruhsatSahibi) || string.IsNullOrEmpty(kilometre))
            {
                MessageBox.Show("Araç Sahibi, Kilometre, Plaka No ve Ruhsat Sahibi alanları boş bırakılamaz.");
                return;
            }
            else
            {
                con.Open();
                MySqlCommand cmd0 = new MySqlCommand($"SELECT * FROM cariler where unvan='{aracSahibi}'", con);
                MySqlDataReader dataReader0 = cmd0.ExecuteReader();
                bool eslesme = false;
                while (dataReader0.Read())
                {
                    if (String.Equals(aracSahibi, dataReader0["unvan"].ToString()))
                    {
                        eslesme = true;
                    }
                }
                con.Close();


                if (!eslesme)
                {
                    con.Open();
                    MySqlCommand cmd00 = new MySqlCommand($"INSERT INTO cariler (grup, unvan, telefon, eposta, adres, notlar, eklenmeTarihi) " +
                        $"VALUES('Müşteri', '{aracSahibi}', 'Telefon Belirtilmedi', 'E-Posta Belirtilmedi', 'Adres Belirtilmedi', 'Not Belirtilmedi', '{date.ToString("dd-MM-yyyy")}')", con);
                    cmd00.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Unvan kısmında belirttiğiniz cari yok, sizin yerinize cariler sayfasına ekledim ama eklenen carinin telefon, adres gibi bilgileri belirtilmedi olarak yazıldı. Düzeltmek isterseniz cariler sayfasında yeşil kutucuklara çift tıklayarak ayarlayabilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

                con.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO araclar (aracSahibi, markasi, modeli, modelYili, kilometre, plakaNo, motorNo, sasiNo, ruhsatSahibi, kasaTipi, renk, motorHacmi, tescilTarihi, trafigeCikisTarihi, yakitCinsi, netAgirlik, sonBakimTarihi, garantiBitisTarihi, trafikSigortaBaslamaTarihi, trafikSigortaBitisTarihi, kaskoBaslamaTarihi, kaskoBitisTarihi, eklenmeTarihi) " +
                    $"VALUES('{aracSahibi}', '{marka}', '{model}', '{modelYili}', '{kilometre}', '{plakaNo}', '{motorNo}', '{sasiNo}', '{ruhsatSahibi}', '{kasaTipi}', '{renk}', '{motorHacmi}', '{tescilTarihi}', '{trafigeCikisTarihi}', '{yakitCinsi}', '{netAgirlik}', '{sonBakimTarihi}', '{garantiBitisTarihi}', '{trafikSigortaBaslangicTarihi}', '{trafikSigortaBitisTarihi}', '{kaskoBaslamaTarihi}', '{kaskoBitisTarihi}', '{date.ToString("dd-MM-yyyy")}')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Araç eklendi.");
                //stock_form frm = new stock_form();
                //frm.Refresh();
                
                this.Close();
            }
        }

        private void cariEkleButton_Click(object sender, EventArgs e)
        {

            Form newAracEkleForm = new aracEkle_form();
            cariEkle_form cariEkle = new cariEkle_form(newAracEkleForm);
            cariEkle.ShowDialog();
            this.Close();
        }

        private void aracSahibiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aracSahibiComboBox_Click(object sender, EventArgs e)
        {
            /*
            aracSahibiComboBox.Items.Clear();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cariler where grup='Müşteri'", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                aracSahibiComboBox.Items.Add(dataReader["unvan"].ToString());
                ruhsatSahibiComboBox.Items.Add(dataReader["unvan"].ToString());

            }
            con.Close();
            */
        }
    }

    public class brandAndModels
    {
        public string brand { get; set; }
        public IList<string> models { get; set; }
    }


}
