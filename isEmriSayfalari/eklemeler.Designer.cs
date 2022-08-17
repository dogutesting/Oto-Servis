
namespace Oto_Servis.isEmriSayfalari
{
    partial class eklemeler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toplamFiyatLabel = new System.Windows.Forms.Label();
            this.toplamEklenenlerLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.islemTarihiFiltreDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.barkodFiltreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.barkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunVeyaIslemAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birimFiyati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.eklemeleriYazdirButton = new CustomControls.RJControls.CustomButton();
            this.stoksuzIslemButton = new CustomControls.RJControls.CustomButton();
            this.islemSilButton = new CustomControls.RJControls.CustomButton();
            this.islemEkleButton = new CustomControls.RJControls.CustomButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.41372F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.87942F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.41666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 481);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 80);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(887, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.toplamFiyatLabel);
            this.panel5.Controls.Add(this.toplamEklenenlerLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(446, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(438, 74);
            this.panel5.TabIndex = 1;
            // 
            // toplamFiyatLabel
            // 
            this.toplamFiyatLabel.BackColor = System.Drawing.Color.Red;
            this.toplamFiyatLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toplamFiyatLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toplamFiyatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamFiyatLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toplamFiyatLabel.Location = new System.Drawing.Point(220, 0);
            this.toplamFiyatLabel.Name = "toplamFiyatLabel";
            this.toplamFiyatLabel.Size = new System.Drawing.Size(218, 83);
            this.toplamFiyatLabel.TabIndex = 5;
            this.toplamFiyatLabel.Text = "Toplam Fiyat: ";
            this.toplamFiyatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toplamEklenenlerLabel
            // 
            this.toplamEklenenlerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toplamEklenenlerLabel.BackColor = System.Drawing.Color.Red;
            this.toplamEklenenlerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toplamEklenenlerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamEklenenlerLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toplamEklenenlerLabel.Location = new System.Drawing.Point(0, 0);
            this.toplamEklenenlerLabel.Name = "toplamEklenenlerLabel";
            this.toplamEklenenlerLabel.Size = new System.Drawing.Size(218, 74);
            this.toplamEklenenlerLabel.TabIndex = 4;
            this.toplamEklenenlerLabel.Text = "Toplam Eklenenler: ";
            this.toplamEklenenlerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.islemTarihiFiltreDateTime);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.barkodFiltreTextBox);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(437, 74);
            this.panel4.TabIndex = 0;
            // 
            // islemTarihiFiltreDateTime
            // 
            this.islemTarihiFiltreDateTime.Location = new System.Drawing.Point(221, 33);
            this.islemTarihiFiltreDateTime.Name = "islemTarihiFiltreDateTime";
            this.islemTarihiFiltreDateTime.Size = new System.Drawing.Size(200, 20);
            this.islemTarihiFiltreDateTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(218, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "İşlem Tarihi Filtrele";
            // 
            // barkodFiltreTextBox
            // 
            this.barkodFiltreTextBox.Location = new System.Drawing.Point(16, 33);
            this.barkodFiltreTextBox.Name = "barkodFiltreTextBox";
            this.barkodFiltreTextBox.Size = new System.Drawing.Size(199, 20);
            this.barkodFiltreTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod Filtrele";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barkod,
            this.islemTarihi,
            this.urunVeyaIslemAdi,
            this.miktar,
            this.birim,
            this.birimFiyati});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(887, 286);
            this.dataGridView1.TabIndex = 0;
            // 
            // barkod
            // 
            this.barkod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.barkod.HeaderText = "Barkod";
            this.barkod.Name = "barkod";
            // 
            // islemTarihi
            // 
            this.islemTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.islemTarihi.HeaderText = "İşlem Tarihi";
            this.islemTarihi.Name = "islemTarihi";
            // 
            // urunVeyaIslemAdi
            // 
            this.urunVeyaIslemAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urunVeyaIslemAdi.HeaderText = "Ürün Veya İşlem Adı";
            this.urunVeyaIslemAdi.Name = "urunVeyaIslemAdi";
            // 
            // miktar
            // 
            this.miktar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.miktar.HeaderText = "Miktar";
            this.miktar.Name = "miktar";
            // 
            // birim
            // 
            this.birim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birim.HeaderText = "Birim";
            this.birim.Name = "birim";
            // 
            // birimFiyati
            // 
            this.birimFiyati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birimFiyati.HeaderText = "Birim Fiyatı";
            this.birimFiyati.Name = "birimFiyati";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 97);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.eklemeleriYazdirButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.stoksuzIslemButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.islemSilButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.islemEkleButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(887, 97);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // eklemeleriYazdirButton
            // 
            this.eklemeleriYazdirButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.eklemeleriYazdirButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.eklemeleriYazdirButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.eklemeleriYazdirButton.BorderRadius = 10;
            this.eklemeleriYazdirButton.BorderSize = 0;
            this.eklemeleriYazdirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eklemeleriYazdirButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eklemeleriYazdirButton.FlatAppearance.BorderSize = 0;
            this.eklemeleriYazdirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eklemeleriYazdirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eklemeleriYazdirButton.ForeColor = System.Drawing.Color.White;
            this.eklemeleriYazdirButton.Image = global::Oto_Servis.Properties.Resources.printer;
            this.eklemeleriYazdirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.eklemeleriYazdirButton.Location = new System.Drawing.Point(666, 3);
            this.eklemeleriYazdirButton.Name = "eklemeleriYazdirButton";
            this.eklemeleriYazdirButton.Size = new System.Drawing.Size(218, 91);
            this.eklemeleriYazdirButton.TabIndex = 3;
            this.eklemeleriYazdirButton.Text = "Eklemeleri Yazdır";
            this.eklemeleriYazdirButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.eklemeleriYazdirButton.TextColor = System.Drawing.Color.White;
            this.eklemeleriYazdirButton.UseVisualStyleBackColor = false;
            // 
            // stoksuzIslemButton
            // 
            this.stoksuzIslemButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.stoksuzIslemButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.stoksuzIslemButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.stoksuzIslemButton.BorderRadius = 10;
            this.stoksuzIslemButton.BorderSize = 0;
            this.stoksuzIslemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stoksuzIslemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stoksuzIslemButton.FlatAppearance.BorderSize = 0;
            this.stoksuzIslemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stoksuzIslemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.stoksuzIslemButton.ForeColor = System.Drawing.Color.White;
            this.stoksuzIslemButton.Image = global::Oto_Servis.Properties.Resources.add22;
            this.stoksuzIslemButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stoksuzIslemButton.Location = new System.Drawing.Point(445, 3);
            this.stoksuzIslemButton.Name = "stoksuzIslemButton";
            this.stoksuzIslemButton.Size = new System.Drawing.Size(215, 91);
            this.stoksuzIslemButton.TabIndex = 2;
            this.stoksuzIslemButton.Text = "Stoksuz İşlem";
            this.stoksuzIslemButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stoksuzIslemButton.TextColor = System.Drawing.Color.White;
            this.stoksuzIslemButton.UseVisualStyleBackColor = false;
            // 
            // islemSilButton
            // 
            this.islemSilButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.islemSilButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.islemSilButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.islemSilButton.BorderRadius = 10;
            this.islemSilButton.BorderSize = 0;
            this.islemSilButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.islemSilButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.islemSilButton.FlatAppearance.BorderSize = 0;
            this.islemSilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.islemSilButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.islemSilButton.ForeColor = System.Drawing.Color.White;
            this.islemSilButton.Image = global::Oto_Servis.Properties.Resources.delete;
            this.islemSilButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.islemSilButton.Location = new System.Drawing.Point(224, 3);
            this.islemSilButton.Name = "islemSilButton";
            this.islemSilButton.Size = new System.Drawing.Size(215, 91);
            this.islemSilButton.TabIndex = 1;
            this.islemSilButton.Text = "İşlem Sil";
            this.islemSilButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.islemSilButton.TextColor = System.Drawing.Color.White;
            this.islemSilButton.UseVisualStyleBackColor = false;
            // 
            // islemEkleButton
            // 
            this.islemEkleButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.islemEkleButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.islemEkleButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.islemEkleButton.BorderRadius = 10;
            this.islemEkleButton.BorderSize = 0;
            this.islemEkleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.islemEkleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.islemEkleButton.FlatAppearance.BorderSize = 0;
            this.islemEkleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.islemEkleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.islemEkleButton.ForeColor = System.Drawing.Color.White;
            this.islemEkleButton.Image = global::Oto_Servis.Properties.Resources.plus;
            this.islemEkleButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.islemEkleButton.Location = new System.Drawing.Point(3, 3);
            this.islemEkleButton.Name = "islemEkleButton";
            this.islemEkleButton.Size = new System.Drawing.Size(215, 91);
            this.islemEkleButton.TabIndex = 0;
            this.islemEkleButton.Text = "İşlem Ekle";
            this.islemEkleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.islemEkleButton.TextColor = System.Drawing.Color.White;
            this.islemEkleButton.UseVisualStyleBackColor = false;
            // 
            // eklemeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "eklemeler";
            this.Text = "eklemeler";
            this.Load += new System.EventHandler(this.eklemeler_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomControls.RJControls.CustomButton eklemeleriYazdirButton;
        private CustomControls.RJControls.CustomButton stoksuzIslemButton;
        private CustomControls.RJControls.CustomButton islemSilButton;
        private CustomControls.RJControls.CustomButton islemEkleButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label toplamFiyatLabel;
        private System.Windows.Forms.Label toplamEklenenlerLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker islemTarihiFiltreDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox barkodFiltreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunVeyaIslemAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn birim;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimFiyati;
    }
}