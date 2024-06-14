//Eksikler
/*
 Ürün arama mekanizmasını daha iyi yap
 Aynı barkoda veya aynı ürün adına sahip ürün eklemeyi kapat
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using System.Collections;

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
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.PaleGreen;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightCoral;

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
                dataGridView1.Rows.Add(dataReader["marka"].ToString(), dataReader["urunAdi"].ToString(), dataReader["birim"].ToString(), dataReader["miktar"].ToString(), dataReader["fiyat"].ToString(), dataReader["barkod"].ToString(), dataReader["id"].ToString(), dataReader["urunResim"].ToString());
            }
            con.Close();
        }

        


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


        private void Stock_search_box_TextChanged(object sender, EventArgs e)
        {
            string searchValue = Stock_search_box.Text;
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
                    MessageBox.Show("Aradığınız Ürün: " + Stock_search_box.Text, " bulunamadı.");
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

        private void stock_form_SizeChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(ClientSize.Width.ToString() + " " + ClientSize.Height.ToString());
        }

        private void stockEkle_click(object sender, EventArgs e)
        {
            stockEkle_form ac = new stockEkle_form();

            ac.DataAdded += StockEklendi;

            ac.Show();
        }

        private void StockEklendi(object sender, EventArgs e)
        {
            refresh();
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            
            if(rowIndex >= 0)
            {
                string imagePath = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                if(imagePath != "")
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.default_photo1;
                }
            }
        }

        string oldValue = string.Empty;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            oldValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
        }

        private bool IsValidFloatString(string input)
        {
            // Boş giriş kontrolü
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // . veya , ile başlama kontrolü
            if (input.StartsWith(".") || input.StartsWith(","))
                return false;

            // Virgül kontrolü
            int commaCount = input.Split(',').Length - 1;
            if (commaCount != 1)
                return false;

            // Float olarak pars etme denemesi
            if (!float.TryParse(input.Replace(",", "."), out float result))
                return false;

            return true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) { 
                // DataGridView'deki ilgili hücrenin yeni değerini al
                string newValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                if (newValue.Substring(0, 1) == "0")
                {
                    MessageBox.Show("Miktar ve fiyat alanları 0 ile başlayamaz veya 0 olamaz.");
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                    return;
                }

                if (columnIndex == 3)
                {
                    string birimCellValue = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    if (birimCellValue == "adet")
                    {
                        try
                        {
                            int adet = int.Parse(newValue);

                            con.Open();
                            string query = "UPDATE stocks SET miktar = @miktar WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@miktar", adet);
                            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MySqlDataReader dataReader = cmd.ExecuteReader();
                            con.Close();
                        } catch (Exception ex) {
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                            MessageBox.Show("Miktar alanına sadece tam sayı değeri girilebilir. Örnek: 3 veya 5");
                        }
                    }
                    else
                    {
                        try
                        {
                            if(!IsValidFloatString(newValue))
                            {
                                throw new Exception();
                            }

                            con.Open();
                            string query = "UPDATE stocks SET miktar = @miktar WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@miktar", newValue);
                            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MySqlDataReader dataReader = cmd.ExecuteReader();
                            con.Close();
                        }
                        catch (Exception ex)
                         {
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                            MessageBox.Show("Miktar alanına sadece ondalık sayı ve tam sayı girilebilir. Örnek: 3,5 veya 3");
                        }
                    }
                }
                if (columnIndex == 4) {
                    try
                    {
                        if (!IsValidFloatString(newValue))
                        {
                            throw new Exception();
                        }

                        con.Open();
                        string query = "UPDATE stocks SET miktar = @miktar WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@miktar", newValue);
                        cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                        cmd.ExecuteNonQuery();
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        con.Close();
                    } catch (Exception ex) {
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                        MessageBox.Show("Fiyat alanına sadece tam sayı veya ondalık değer girilebilir. Örnek: 335 veya 325,50 veya 3,5");
                    }
                }

                if (columnIndex == 5)
                {
                    try
                    {
                        string barkod = newValue;

                        con.Open();
                        string query = "UPDATE stocks SET barkod = @barkod WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@barkod", barkod);
                        cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                        cmd.ExecuteNonQuery();
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                        MessageBox.Show("Barkod yazılırken bir hata ile karşılaşıldı. Bilinmeyen bir tür girildi.");
                    }
                }
            }
        }

        
    }
}
