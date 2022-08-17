using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Oto_Servis.isEmriSayfalari
{
    public partial class aracKabul : Form
    {
        MySqlConnection con;

        String isEmriDurumu = "";
        bool kaydetMode;
        private int emirId = 0;

        public aracKabul() //Varolan iş emrine çift tıklıyor
        {
            InitializeComponent();

            ConnectionClass conn = new ConnectionClass();
            con = conn.myConnection();
            
            if(String.Equals(isEmriEkle_form.paslananObj.isEmriDurumu, "Açık"))
            {
                acikRadioButton.Checked = true;
                isEmriDurumu = "Açık";
            }
            else
            {
                acikRadioButton.Checked = false;
                isEmriDurumu = "Kapalı";
            }

            kabulTarihi.Text = isEmriEkle_form.paslananObj.kabulTarihi;
            kabulSaati.Text = isEmriEkle_form.paslananObj.kabulSaati;
            girisKm.Text = isEmriEkle_form.paslananObj.kilometresi;
            depoDurumu.Text = isEmriEkle_form.paslananObj.depoDurumu;
            araciTeslimEdenComboBox.Text = isEmriEkle_form.paslananObj.araciTeslimEden;
            araciTeslimAlanComboBox.Text = isEmriEkle_form.paslananObj.araciTeslimAlan;
            sorumluPersonelComboBox.Text = isEmriEkle_form.paslananObj.sorumluPersonel;
            musteriTalep.Text = isEmriEkle_form.paslananObj.musteriTalep;
            personelRapor.Text = isEmriEkle_form.paslananObj.personelRapor;
            ekstraNot.Text = isEmriEkle_form.paslananObj.ekstraNot;

            aracKodu.Text = isEmriEkle_form.paslananObj.aracKodu;
            marka.Text = isEmriEkle_form.paslananObj.marka;
            model.Text = isEmriEkle_form.paslananObj.model;
            modelYili.Text = isEmriEkle_form.paslananObj.modelYili;
            plakaNo.Text = isEmriEkle_form.paslananObj.plakaNo;
            motorNo.Text = isEmriEkle_form.paslananObj.motorNo;
            sasiNo.Text = isEmriEkle_form.paslananObj.sasiNo;
            ruhsatSahibi.Text = isEmriEkle_form.paslananObj.ruhsatSahibi;
            kilometre.Text = isEmriEkle_form.paslananObj.kilometresi;

            cariKodu.Text = isEmriEkle_form.paslananObj.cariKodu;
            grup.Text = isEmriEkle_form.paslananObj.grup;
            unvan.Text = isEmriEkle_form.paslananObj.unvan;
            telefon.Text = isEmriEkle_form.paslananObj.telefon;
            eposta.Text = isEmriEkle_form.paslananObj.eposta;
            adres.Text = isEmriEkle_form.paslananObj.adres;
            notlar.Text = isEmriEkle_form.paslananObj.notlar;

            aracSecButton.Hide();
            cariSecButton.Hide();
            kaydetMode = false; //Çünkü güncelleyecek;
            this.emirId = Int32.Parse(isEmriEkle_form.paslananObj.isEmriNo);
            kaydetButton.Text = "Güncelle";
        }

        public aracKabul(aracKabulObj arckblObj) //yeni iş emri eklemeye tıkladı
        {
            InitializeComponent();

            ConnectionClass conn = new ConnectionClass();
            con = conn.myConnection();

            acikRadioButton.Checked = true;
            isEmriDurumu = "Açık";

            kabulSaati.Text = DateTime.Now.ToString("HH:mm");
            girisKm.Text = arckblObj.kilometresi;

            aracKodu.Text = arckblObj.aracKodu;
            marka.Text = arckblObj.marka;
            model.Text = arckblObj.model;
            modelYili.Text = arckblObj.modelYili;
            plakaNo.Text = arckblObj.plakaNo;
            motorNo.Text = arckblObj.motorNo;
            sasiNo.Text = arckblObj.sasiNo;
            ruhsatSahibi.Text = arckblObj.ruhsatSahibi;
            kilometre.Text = arckblObj.kilometresi;

            cariKodu.Text = arckblObj.cariKodu;
            grup.Text = arckblObj.grup;
            unvan.Text = arckblObj.unvan;
            telefon.Text = arckblObj.telefon;
            eposta.Text = arckblObj.eposta;
            adres.Text = arckblObj.adres;
            notlar.Text = arckblObj.notlar;

            kaydetMode = true; //Çünkü kaydedecek;
        }
        bool duzenle = false;
        public aracKabul(int emirId, aracKabulObj obje, bool duzenle) //İş emrini düzenleme butonuna tıkladı <-> kaydetMode false olmalı çünkü düzenleyecek
        {
            InitializeComponent();
           
            ConnectionClass conn = new ConnectionClass();
            con = conn.myConnection();

            if (String.Equals(obje.isEmriDurumu, "Açık"))
            {
                acikRadioButton.Checked = true;
                isEmriDurumu = "Açık";
            }
            else
            {
                acikRadioButton.Checked = false;
                isEmriDurumu = "Kapalı";
            }

            kabulTarihi.Text = obje.kabulTarihi;
            kabulSaati.Text = obje.kabulSaati;
            girisKm.Text = obje.kilometresi;
            depoDurumu.Text = obje.depoDurumu;
            araciTeslimEdenComboBox.Text = obje.araciTeslimEden;
            araciTeslimAlanComboBox.Text = obje.araciTeslimAlan;
            sorumluPersonelComboBox.Text = obje.sorumluPersonel;
            musteriTalep.Text = obje.musteriTalep;
            personelRapor.Text = obje.personelRapor;
            ekstraNot.Text = obje.ekstraNot;

            aracKodu.Text = obje.aracKodu;
            marka.Text = obje.marka;
            model.Text = obje.model;
            modelYili.Text = obje.modelYili;
            plakaNo.Text = obje.plakaNo;
            motorNo.Text = obje.motorNo;
            sasiNo.Text = obje.sasiNo;
            ruhsatSahibi.Text = obje.ruhsatSahibi;
            kilometre.Text = obje.kilometresi;

            cariKodu.Text = obje.cariKodu;
            grup.Text = obje.grup;
            unvan.Text = obje.unvan;
            telefon.Text = obje.telefon;
            eposta.Text = obje.eposta;
            adres.Text = obje.adres;
            notlar.Text = obje.notlar;

            this.duzenle = duzenle;
            this.emirId = emirId;
            kaydetMode = false;
            kaydetButton.Text = "Güncelle";
        }

        private void aracKabul_Load(object sender, EventArgs e)
        {
            comboBoxSettings();
        }

        private void comboBoxSettings()
        {
            araciTeslimEdenComboBox.Items.Clear();
            araciTeslimAlanComboBox.Items.Clear();
            sorumluPersonelComboBox.Items.Clear();
            
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cariler where grup='Müşteri'", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                araciTeslimEdenComboBox.Items.Add(dataReader["unvan"].ToString());
            }
            con.Close();

            con.Open();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM cariler where grup='Personel'", con);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            while (dataReader2.Read())
            {
                araciTeslimAlanComboBox.Items.Add(dataReader2["unvan"].ToString());
                sorumluPersonelComboBox.Items.Add(dataReader2["unvan"].ToString());
            }

            con.Close();
        }

        public static int tekAracSecInt;
        public static bool tekAracSecBool = false;

        private void aracSecButton_Click(object sender, EventArgs e)
        {
            arac_form aracForm = new arac_form(1);
            aracForm.Show();
            if(tekAracSecBool)
            {
                if (tekAracSecInt == 0)
                {
                    return;
                }

                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM araclar where id='{tekAracSecInt}'", con);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    aracKodu.Text = dataReader["id"].ToString();
                    marka.Text = dataReader["markasi"].ToString();
                    model.Text = dataReader["modeli"].ToString();
                    modelYili.Text = dataReader["modelYili"].ToString();
                    plakaNo.Text = dataReader["plakaNo"].ToString();
                    motorNo.Text = dataReader["motorNo"].ToString();
                    sasiNo.Text = dataReader["sasiNo"].ToString();
                    ruhsatSahibi.Text = dataReader["ruhsatSahibi"].ToString();
                    kilometre.Text = dataReader["kilometre"].ToString();
                }
                con.Close();
                tekAracSecInt = 0;
                tekAracSecBool = false;
            }
        }

        public static int tekCariSecInt;
        public static bool tekCariSecBool = false;

        private void cariSecButton_Click(object sender, EventArgs e)
        {
            cari_form cariForm = new cari_form(1);
            cariForm.ShowDialog();

            if (tekCariSecBool)
            {
                if(tekCariSecInt == 0)
                {
                    return;
                }

                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM cariler where id='{tekCariSecInt}'", con);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    cariKodu.Text = dataReader["id"].ToString();
                    grup.Text = dataReader["grup"].ToString();
                    unvan.Text = dataReader["unvan"].ToString();
                    telefon.Text = dataReader["telefon"].ToString();
                    eposta.Text = dataReader["eposta"].ToString();
                    adres.Text = dataReader["adres"].ToString();
                    notlar.Text = dataReader["notlar"].ToString();
                }
                con.Close();
            }
            tekCariSecInt = 0;
            tekCariSecBool = false;

        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            //MessageBox.Show(date.ToString().Split(' ')[0]);

            if (string.IsNullOrEmpty(kabulTarihi.Text) || string.IsNullOrEmpty(kabulSaati.Text) || string.IsNullOrEmpty(araciTeslimEdenComboBox.Text) || string.IsNullOrEmpty(araciTeslimAlanComboBox.Text) || string.IsNullOrEmpty(girisKm.Text) || string.IsNullOrEmpty(depoDurumu.Text))
            {
                MessageBox.Show("Lütfen iş emri başlığı altındakileri doldurunuz.");
                return;
            }
            else
            {
                if(kaydetMode)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO emirler (marka, model, plakaNo, cari, isEmriDurumu, ruhsatSahibi, girisKM, araciTeslimEden, araciTeslimAlan, kabulTarihi, kabulSaati, depoDurumu, sorumluPersonel, musteriTalep, personelDurum, notlar, aracId, cariId, eklenmeTarihi) " +
                        $"VALUES('{marka.Text}', '{model.Text}', '{plakaNo.Text}', '{unvan.Text}', '{isEmriDurumu}', '{ruhsatSahibi.Text}', '{girisKm.Text}', '{araciTeslimEdenComboBox.Text}', '{araciTeslimAlanComboBox.Text}', '{kabulTarihi.Text}', '{kabulSaati.Text}', '{depoDurumu.Text}', '{sorumluPersonelComboBox.Text}', '{musteriTalep.Text}', '{personelRapor.Text}', '{ekstraNot.Text}', '{aracKodu.Text}', '{cariKodu.Text}', '{date.ToString("dd-MM-yyyy")}')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Emir eklendi.");
                    this.Close();
                }
                else
                {
                    //Güncelleme İşlemi
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE emirler SET marka = '{marka.Text}', model='{model.Text}', plakaNo='{plakaNo.Text}', cari='{unvan.Text}', isEmriDurumu='{isEmriDurumu}', ruhsatSahibi='{ruhsatSahibi.Text}', girisKM='{girisKm.Text}', araciTeslimEden='{araciTeslimEdenComboBox.Text}', araciTeslimAlan='{araciTeslimAlanComboBox.Text}', kabulTarihi='{kabulTarihi.Text}', kabulSaati='{kabulSaati.Text}', depoDurumu='{depoDurumu.Text}', sorumluPersonel='{sorumluPersonelComboBox.Text}', musteriTalep='{musteriTalep.Text}', personelDurum='{personelRapor.Text}', notlar='{notlar.Text}', aracId='{aracKodu.Text}', cariId='{cariKodu.Text}' where id='{emirId}'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Emir güncellendi.");
                    if (duzenle)
                    {
                        this.Close();
                    }   
                }
                
            }
        }

        private void aracKabul_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (kayitVarMi())
            {
                if(!CloseCancel())
                {
                    e.Cancel = true;
                }
                else
                {
                    //MessageBox.Show("what");
                }
            }
        }

        private bool kayitVarMi()
        {
            if (!string.IsNullOrEmpty(kabulTarihi.Text) || !string.IsNullOrEmpty(kabulSaati.Text) || !string.IsNullOrEmpty(araciTeslimEdenComboBox.Text) || !string.IsNullOrEmpty(araciTeslimAlanComboBox.Text) || !string.IsNullOrEmpty(girisKm.Text) || !string.IsNullOrEmpty(depoDurumu.Text))
            {
                //MessageBox.Show("Lütfen iş emri başlığı altındakileri doldurunuz.");
                return true;
            }
            return false;
        }

        public bool CloseCancel()
        {
            const string message = "Kaydet butonuna basmadan çıkmak istediğinize emin misiniz? Kayıt yok olucaktır.";
            const string caption = "Uyarı";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void acikRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isEmriDurumu = "Açık";
        }

        private void kapaliRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isEmriDurumu = "Kapalı";
        }
    }
}
