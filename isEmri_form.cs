using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    public partial class isEmri_form : Form
    {
        public static int cariId;
        public static bool cariKapandi = false;

        public static int aracId;
        public static bool aracKapandi = false;

        MySqlConnection con;

        public isEmri_form()
        {
            InitializeComponent();
            this.isEmirleriDataGridView.ClearSelection();
            this.isEmirleriDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.isEmirleriDataGridView.MultiSelect = false;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();

        }

        private void isEmri_form_Load(object sender, EventArgs e)
        {
            this.isEmirleriDataGridView.ClearSelection();

            isEmirleriDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            isEmirleriDataGridView.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Regular);
        }

        private void refresh()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM emirler", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                isEmirleriDataGridView.Rows.Add(dataReader["kabulTarihi"], dataReader["kabulSaati"].ToString(), dataReader["isEmriDurumu"].ToString(), dataReader["id"].ToString(), dataReader["marka"].ToString(), dataReader["model"].ToString(), dataReader["plakaNo"].ToString(), dataReader["cari"].ToString(), dataReader["ruhsatSahibi"].ToString(), dataReader["girisKM"].ToString(), dataReader["araciTeslimEden"].ToString(), dataReader["araciTeslimAlan"].ToString(), dataReader["sorumluPersonel"].ToString(), dataReader["depoDurumu"].ToString(), dataReader["musteriTalep"].ToString(), dataReader["personelDurum"].ToString(), dataReader["notlar"].ToString());
            }
            con.Close();
            colorTable();
        }

        private void colorTable()
        {
            isEmirleriDataGridView.RowHeadersVisible = false;


            foreach (DataGridViewRow myrows in isEmirleriDataGridView.Rows)
            {
                if (myrows.Cells[2].Value.ToString() == "Açık")
                {
                    myrows.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    myrows.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }

            isEmirleriDataGridView.ClearSelection();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cariForm = new cari_form(true);
            cariForm.ShowDialog();
            if (cariKapandi)
            {
                Form aracForm = new arac_form(true);
                aracForm.ShowDialog();
                if (!aracKapandi)
                {
                    reset();
                }
                if (aracKapandi)
                {
                    //cariId - aracId

                    //aracEkle_form ac = new aracEkle_form();
                    //ac.Show();

                    aracKabulObj newObj = new aracKabulObj(aracId.ToString(), cariId.ToString());

                    isEmriSayfalari.aracKabul ac = new isEmriSayfalari.aracKabul(newObj);
                    //isEmriEkle_form ac = new isEmriEkle_form(newObj);
                    ac.Show();

                    reset();
                }
            }
        }

        private void reset()
        {
            cariKapandi = false;
            cariId = 0;

            aracKapandi = false;
            aracId = 0;
        }

        int lastE = -1;
        private void isEmirleriDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            lastE = e.RowIndex;

            aracKabulObj paslanacakObje = new aracKabulObj(isEmirleriDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            Form newForm = new isEmriEkle_form(paslanacakObje);
            newForm.ShowDialog();
        }

        int lastClickedDataGridViewRow = 0;
        private void isEmirleriDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            lastClickedDataGridViewRow = Int32.Parse(isEmirleriDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void secileniDuzenleButton_Click(object sender, EventArgs e)
        {
            if (lastClickedDataGridViewRow == 0)
            {
                MessageBox.Show("Lütfen önce düzenlemek istediğiniz emiri seçin. Ardından düzenle butonuna basın.", "Uyarı");
            }
            else
            {
                /*
                aracKabulObj paslanacakObje = new aracKabulObj(lastClickedDataGridViewRow.ToString());
                Form newForm = new isEmriSayfalari.aracKabul(lastClickedDataGridViewRow, paslanacakObje, true);
                newForm.ShowDialog();
                */
                aracKabulObj paslanacakObje = new aracKabulObj(lastClickedDataGridViewRow.ToString());
                Form newForm = new isEmriEkle_form(paslanacakObje);
                newForm.ShowDialog();
            }
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            var data = new List<int>();

            //MessageBox.Show(dataGridView1.SelectedCells.ToString());
            //MessageBox.Show("dataGridView1 = " + dataGridView1.SelectedCells.Count);

            for (int i = 0; i < isEmirleriDataGridView.SelectedCells.Count; i++)
            {
                //MessageBox.Show();
                if (i == 0)
                {
                    //data.Add(dataGridView1.SelectedCells[i].RowIndex);
                    data.Add(int.Parse(isEmirleriDataGridView.Rows[isEmirleriDataGridView.SelectedCells[i].RowIndex].Cells[3].Value.ToString()));
                }
                else
                {
                    bool buldu = false;
                    foreach (var d in data)
                    {
                        if (d == int.Parse(isEmirleriDataGridView.Rows[isEmirleriDataGridView.SelectedCells[i].RowIndex].Cells[3].Value.ToString()))
                        {
                            buldu = true;
                            break;
                        }
                        else
                        {
                            buldu = false;
                        }
                    }
                    if (!buldu)
                    {
                        data.Add(int.Parse(isEmirleriDataGridView.Rows[isEmirleriDataGridView.SelectedCells[i].RowIndex].Cells[3].Value.ToString()));
                    }
                }
            }

            if (data.Count != 0)
            {

                string message = "Ürün Kodu ";
                foreach (var d in data)
                {
                    message += d + ", ";
                }

                message = message.Remove(message.Length - 2);

                if (data.Count != 1)
                {
                    message += " olan ürünleri silmek istediğinize emin misiniz?";
                }
                else
                {
                    message += " olan ürünü silmek istediğinize emin misiniz?";
                }

                string title = "Silme işlemi";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    foreach (var d in data)
                    {
                        MySqlCommand cmd = new MySqlCommand($"DELETE FROM emirler where id = {d}", con);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    refresh();
                }
                else
                {
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce silmek istediğiniz ürünü veya ürünleri seçin", "Seçim bulunamadı");
            }
        }
    }

    public class aracKabulObj
    {
        private MySqlConnection con;

        //Araç Bilgileri
        public string aracKodu,
               marka,
               model,
               modelYili,
               plakaNo,
               motorNo,
               sasiNo,
               ruhsatSahibi,
               kilometresi;

        //Cari Bilgileri
        public string cariKodu,
               grup,
               unvan,
               telefon,
               eposta,
               adres,
               notlar;

        //İş Emri Bilgileri
        public string isEmriNo,
               girisKm,
               kabulTarihi,
               kabulSaati,
               isEmriDurumu,
               depoDurumu,
               araciTeslimEden,
               araciTeslimAlan,
               sorumluPersonel,
               musteriTalep,
               personelRapor,
               ekstraNot;

        public aracKabulObj(String aracKodu, String cariKodu)
        {
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            this.aracKodu = aracKodu;
            this.cariKodu = cariKodu;

            getAracKodu();
            getCariKodu();
        }

        public aracKabulObj(String isEmriNo)
        {
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            this.isEmriNo = isEmriNo;
            
            gsIsEmri();
        }

        void getAracKodu()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM araclar where id='{aracKodu}'", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                aracKodu = dataReader["id"].ToString();
                marka = dataReader["markasi"].ToString();
                model = dataReader["modeli"].ToString();
                modelYili = dataReader["modelYili"].ToString();
                plakaNo = dataReader["plakaNo"].ToString();
                motorNo = dataReader["motorNo"].ToString();
                sasiNo = dataReader["sasiNo"].ToString();
                ruhsatSahibi = dataReader["ruhsatSahibi"].ToString();
                kilometresi = dataReader["kilometre"].ToString();
            }
            con.Close();
        }
        void getCariKodu()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM cariler where id='{cariKodu}'", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                cariKodu = dataReader["id"].ToString();
                grup = dataReader["grup"].ToString();
                unvan = dataReader["unvan"].ToString();
                telefon = dataReader["telefon"].ToString();
                eposta = dataReader["eposta"].ToString();
                adres = dataReader["adres"].ToString();
                notlar = dataReader["notlar"].ToString();
            }
            con.Close();
        }

        void gsIsEmri()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM emirler where id='{isEmriNo}'", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                this.aracKodu = dataReader["aracId"].ToString();
                this.cariKodu = dataReader["cariId"].ToString();
                girisKm = dataReader["girisKM"].ToString();
                kabulTarihi = dataReader["kabulTarihi"].ToString();
                kabulSaati = dataReader["kabulSaati"].ToString();
                isEmriDurumu = dataReader["isEmriDurumu"].ToString();
                depoDurumu = dataReader["depoDurumu"].ToString();
                araciTeslimEden = dataReader["araciTeslimEden"].ToString();
                araciTeslimAlan = dataReader["araciTeslimAlan"].ToString();
                sorumluPersonel = dataReader["sorumluPersonel"].ToString();
                musteriTalep = dataReader["musteriTalep"].ToString();
                personelRapor = dataReader["personelDurum"].ToString();
                ekstraNot = dataReader["notlar"].ToString();
            }
            con.Close();
            getAracKodu();
            getCariKodu();
        }
    }

}
