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
    public partial class arac_form : Form
    {
        MySqlConnection con;
        public arac_form()
        {
            InitializeComponent();
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }
        private void arac_form_Load(object sender, EventArgs e)
        {
            //ColorTranslator.FromHtml("#ee8b38"); Hex Code olarak eklenebilir

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Regular);

            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[13].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[15].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[17].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[18].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[19].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[20].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[21].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[22].DefaultCellStyle.BackColor = Color.LightCoral;

            dataGridView1.ClearSelection();
        }
        private void aracEkleButton_Click(object sender, EventArgs e)
        {
            aracEkle_form ac = new aracEkle_form();
            ac.Show();
        }
        private void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM araclar", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader["id"], dataReader["aracSahibi"], dataReader["markasi"].ToString(), dataReader["modeli"].ToString(), dataReader["modelYili"].ToString(), dataReader["kilometre"].ToString(), dataReader["plakaNo"].ToString(), dataReader["motorNo"].ToString(), dataReader["sasiNo"].ToString(), dataReader["ruhsatSahibi"].ToString(), dataReader["kasaTipi"].ToString(), dataReader["renk"].ToString(), dataReader["motorHacmi"].ToString(), dataReader["tescilTarihi"].ToString(), dataReader["trafigeCikisTarihi"].ToString(), dataReader["yakitCinsi"].ToString(), dataReader["netAgirlik"].ToString(), dataReader["sonBakimTarihi"].ToString(), dataReader["garantiBitisTarihi"].ToString(), dataReader["trafikSigortaBaslamaTarihi"].ToString(), dataReader["trafikSigortaBitisTarihi"].ToString(), dataReader["kaskoBaslamaTarihi"].ToString(), dataReader["kaskoBitisTarihi"].ToString());
            }
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        bool aracSecimi = false;

        public arac_form(bool arac_secimi)
        {
            InitializeComponent();
            aracSecimi = arac_secimi;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }

        int aracSecimiTek = 0;
        public arac_form(int aracSecimiTek)
        {
            InitializeComponent();
            this.aracSecimiTek = aracSecimiTek;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(aracSecimiTek == 1)
            {
                int selectedAracKodu = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                isEmriSayfalari.aracKabul.tekAracSecInt = selectedAracKodu;
                this.Close();
            }
            else if (!aracSecimi)
            {
                return;
            }
            else
            {
                int selectedAracKodu = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                isEmri_form.aracId = selectedAracKodu;
                this.Close();
            }
        }

        private void arac_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(aracSecimiTek == 1)
            {
                isEmriSayfalari.aracKabul.tekAracSecBool = true;
            }

            if (aracSecimi && isEmri_form.aracId == 0)
            {
                isEmri_form.aracKapandi = false;
            }
            else if(aracSecimi)
            {
                isEmri_form.aracKapandi = true;
            }
            
        }
    }
}
