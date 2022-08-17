using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Servis.isEmriSayfalari
{
    public partial class elisciligi : Form
    {
        public elisciligi()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Regular);

        }

        private void servisAsamalari_Load(object sender, EventArgs e)
        {

        }
    }
}
