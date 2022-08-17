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
    public partial class cari_form : Form
    {
        MySqlConnection con;

        public cari_form()
        {
            InitializeComponent();
            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();
            refresh();
        }

        bool cariSecimi = false;

        public cari_form(bool cari_secimi)
        {
            InitializeComponent();
            cariSecimi = cari_secimi;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }

        int cariSecimiTek = 0;
        public cari_form(int cariSecimiTek)
        {
            InitializeComponent();
            this.cariSecimiTek = cariSecimiTek;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }

        private void cari_form_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Regular);

            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightCoral;

            dataGridView1.ClearSelection();
        }

        public void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cariler", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader["grup"].ToString(), dataReader["unvan"].ToString(), dataReader["telefon"].ToString(), dataReader["eposta"].ToString(), dataReader["adres"].ToString(), dataReader["notlar"].ToString(), dataReader["eklenmeTarihi"].ToString(), dataReader["id"].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cariEkle_form cariEkle = new cariEkle_form();
            cariEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var data = new List<int>();

            //MessageBox.Show(dataGridView1.SelectedCells.ToString());
            //MessageBox.Show("dataGridView1 = " + dataGridView1.SelectedCells.Count);

            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                //MessageBox.Show();
                if (i == 0)
                {
                    //data.Add(dataGridView1.SelectedCells[i].RowIndex);
                    data.Add(int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[7].Value.ToString()));
                }
                else
                {
                    bool buldu = false;
                    foreach (var d in data)
                    {
                        if (d == int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[7].Value.ToString()))
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
                        data.Add(int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[7].Value.ToString()));
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
                        MySqlCommand cmd = new MySqlCommand($"DELETE FROM stocks where id = {d}", con);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cariSecimiTek == 1)
            {
                int selectedUrunKodu = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                isEmriSayfalari.aracKabul.tekCariSecInt = selectedUrunKodu;
                this.Close();
            }
            else if (!cariSecimi)
            {
                return;
            }
            else
            {
                int selectedUrunKodu = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                isEmri_form.cariId = selectedUrunKodu;
                this.Close();
            }
        }
        private void cari_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(cariSecimiTek == 1)
            {
                isEmriSayfalari.aracKabul.tekCariSecBool = true;
            }
            if (cariSecimi && isEmri_form.cariId != 0)
            {
                isEmri_form.cariKapandi = true;
            }
        }
    }
}
