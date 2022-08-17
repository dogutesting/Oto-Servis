//Eksikler
/*
 Ürün arama mekanizmasını daha iyi yap
 Aynı barkoda veya aynı ürün adına sahip ürün eklemeyi kapat
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Oto_Servis
{
    public partial class stock_form : Form
    {
        MySqlConnection con;
        //string imageCollector = "";
        public stock_form()
        {
            InitializeComponent();

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }

        bool stockSecimi = false;

        public stock_form(bool stock_secimi)
        {
            InitializeComponent();
            stockSecimi = stock_secimi;

            ConnectionClass conClass = new ConnectionClass();
            con = conClass.myConnection();

            refresh();
        }

        private void stock_form_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Regular);

            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightCoral;
            //dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightCoral;

            dataGridView1.ClearSelection();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM stocks", con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader["marka"].ToString(), dataReader["urunAdi"].ToString(), dataReader["miktar"].ToString(), dataReader["birim"].ToString(), dataReader["fiyat"].ToString(), dataReader["barkod"].ToString(), dataReader["id"].ToString());
            }
            con.Close();
        }

        int lastE = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lastE == e.RowIndex || e.RowIndex < 0) { return; }
            lastE = e.RowIndex;
            getImageSelectedRow(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        /*
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!stockSecimi)
            {
                return;
            }
            else
            {
                int selectedUrunKodu = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                isEmri_form.stockId = selectedUrunKodu;
                this.Close();
            }
        }
        
        private void stock_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (stockSecimi && isEmri_form.stockId != 0)
            {
                isEmri_form.stockKapandi = true;
            }
        }
        */
        private void getImageSelectedRow(string idOfRow)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM stocks WHERE id='{idOfRow}'", con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    pictureBox1.ImageLocation = read["urunResim"].ToString();
                }
                con.Close();
            } catch (Exception e)
            {
                MessageBox.Show("Error e", e.Message);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;
            if (string.IsNullOrEmpty(searchValue)) { dataGridView1.ClearSelection(); return; }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells[2].Value.ToString()) && stringNearOrTrue(row.Cells[2].Value.ToString(), searchValue))
                    {
                        //dataGridView1.ClearSelection();
                        int rowIndex = row.Index;
                        dataGridView1.Rows[rowIndex].Selected = true;

                        valueResult = true;
                    }
                    else
                    {
                        int rowIndex = row.Index;
                        dataGridView1.Rows[rowIndex].Selected = false;
                        //dataGridView1.Rows.RemoveAt(rowIndex);
                    }

                    if (row.Equals(dataGridView1.Rows.Count))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (!valueResult)
                {
                    dataGridView1.ClearSelection();
                    MessageBox.Show("Aradığınız Ürün: " + textBox1.Text, " bulunamadı.");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool stringNearOrTrue(string string1, string string2)
        {
            //string1'in içerisinde string2 var ise veya yakın ise

            char[] s1 = string1.ToCharArray();
            char[] s2 = string2.ToCharArray();
            bool boolean = false;

            for (int i = 0; i < s2.Length; i++)
            {
                if (s1[i].Equals(s2[i]))
                {
                    boolean = true;
                }
                else
                {
                    boolean = false;
                }
            }
            //MessageBox.Show(boolean.ToString() + " <=> " + string1 + " " + string2);
            return boolean;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stockEkle_form ac = new stockEkle_form();
            ac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private bool notStartWithSpace(char character)
        {
            bool returnedValue = false;
            if (character.Equals(' '))
            {
                returnedValue = true;
                //MessageBox.Show("Boşluk ile başlayamazsınız.");
            }
            return returnedValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            var data = new List<int>();

            //MessageBox.Show(dataGridView1.SelectedCells.ToString());
            //MessageBox.Show("dataGridView1 = " + dataGridView1.SelectedCells.Count);

            for(int i=0; i<dataGridView1.SelectedCells.Count; i++)
            {
                //MessageBox.Show();
                if (i == 0)
                {
                    //data.Add(dataGridView1.SelectedCells[i].RowIndex);
                    data.Add(int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[6].Value.ToString()));
                }
                else
                {
                    bool buldu = false;
                    foreach (var d in data)
                    {
                        if(d == int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[6].Value.ToString()))
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
                        data.Add(int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[6].Value.ToString()));
                    }
                }
            }

            if(data.Count != 0)
            {   

                string message = "Ürün Kodu ";
                foreach (var d in data)
                {
                    message += d + ", ";
                }

                message = message.Remove(message.Length - 2);
                
                if(data.Count != 1)
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
    }
}
