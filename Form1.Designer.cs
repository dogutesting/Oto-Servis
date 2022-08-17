
namespace Oto_Servis
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.aracButton = new System.Windows.Forms.Button();
            this.stokButton = new System.Windows.Forms.Button();
            this.cariButton = new System.Windows.Forms.Button();
            this.kasaButton = new System.Windows.Forms.Button();
            this.isEmriButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Indigo;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.mainPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.98726F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.01274F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1025, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Blue;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(3, 71);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1019, 554);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.63594F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.68102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01472F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.34642F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16879F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91615F));
            this.tableLayoutPanel2.Controls.Add(this.aracButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.stokButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cariButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.kasaButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.isEmriButton, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1019, 62);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // aracButton
            // 
            this.aracButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aracButton.BackColor = System.Drawing.Color.Gainsboro;
            this.aracButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aracButton.Image = ((System.Drawing.Image)(resources.GetObject("aracButton.Image")));
            this.aracButton.Location = new System.Drawing.Point(271, 3);
            this.aracButton.Name = "aracButton";
            this.aracButton.Size = new System.Drawing.Size(147, 56);
            this.aracButton.TabIndex = 3;
            this.aracButton.Text = "Araç Ekle";
            this.aracButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aracButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.aracButton.UseVisualStyleBackColor = false;
            this.aracButton.Click += new System.EventHandler(this.aracButton_Click);
            // 
            // stokButton
            // 
            this.stokButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stokButton.BackColor = System.Drawing.Color.Gainsboro;
            this.stokButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.stokButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.stokButton.Image = ((System.Drawing.Image)(resources.GetObject("stokButton.Image")));
            this.stokButton.Location = new System.Drawing.Point(3, 3);
            this.stokButton.Name = "stokButton";
            this.stokButton.Size = new System.Drawing.Size(123, 56);
            this.stokButton.TabIndex = 0;
            this.stokButton.Text = "Stok";
            this.stokButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stokButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stokButton.UseVisualStyleBackColor = false;
            this.stokButton.Click += new System.EventHandler(this.stokButton_Click);
            // 
            // cariButton
            // 
            this.cariButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cariButton.BackColor = System.Drawing.Color.Gainsboro;
            this.cariButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cariButton.Image = ((System.Drawing.Image)(resources.GetObject("cariButton.Image")));
            this.cariButton.Location = new System.Drawing.Point(132, 3);
            this.cariButton.Name = "cariButton";
            this.cariButton.Size = new System.Drawing.Size(133, 56);
            this.cariButton.TabIndex = 1;
            this.cariButton.Text = "Cari";
            this.cariButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cariButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cariButton.UseVisualStyleBackColor = false;
            this.cariButton.Click += new System.EventHandler(this.cariButton_Click);
            // 
            // kasaButton
            // 
            this.kasaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kasaButton.BackColor = System.Drawing.Color.Gainsboro;
            this.kasaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kasaButton.Image = ((System.Drawing.Image)(resources.GetObject("kasaButton.Image")));
            this.kasaButton.Location = new System.Drawing.Point(560, 3);
            this.kasaButton.Name = "kasaButton";
            this.kasaButton.Size = new System.Drawing.Size(118, 56);
            this.kasaButton.TabIndex = 3;
            this.kasaButton.Text = "Kasa";
            this.kasaButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kasaButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kasaButton.UseVisualStyleBackColor = false;
            this.kasaButton.Click += new System.EventHandler(this.kasaButton_Click);
            // 
            // isEmriButton
            // 
            this.isEmriButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isEmriButton.BackColor = System.Drawing.Color.Gainsboro;
            this.isEmriButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isEmriButton.Image = ((System.Drawing.Image)(resources.GetObject("isEmriButton.Image")));
            this.isEmriButton.Location = new System.Drawing.Point(424, 3);
            this.isEmriButton.Name = "isEmriButton";
            this.isEmriButton.Size = new System.Drawing.Size(130, 56);
            this.isEmriButton.TabIndex = 2;
            this.isEmriButton.Text = "İş Emri";
            this.isEmriButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isEmriButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.isEmriButton.UseVisualStyleBackColor = false;
            this.isEmriButton.Click += new System.EventHandler(this.isEmri_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1025, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oto Servis Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button stokButton;
        private System.Windows.Forms.Button cariButton;
        private System.Windows.Forms.Button isEmriButton;
        private System.Windows.Forms.Button kasaButton;
        private System.Windows.Forms.Button aracButton;
    }
}

