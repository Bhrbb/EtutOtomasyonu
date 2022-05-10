namespace EtutProgramıOtomasyon
{
    partial class EtutOlustur
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsil = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btndegistir = new System.Windows.Forms.Button();
            this.cmbogretmen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbders = new System.Windows.Forms.ComboBox();
            this.cmbogrenci = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 231);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EtutListesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(538, 202);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnsil);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.btndegistir);
            this.groupBox1.Controls.Add(this.cmbogretmen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbders);
            this.groupBox1.Controls.Add(this.cmbogrenci);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maskedTextBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maskedTextBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BirebirOlusturma";
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(351, 213);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(140, 37);
            this.btnsil.TabIndex = 17;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(366, 175);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 28);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "İptal";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(510, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(22, 24);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "0";
            this.lblID.Visible = false;
            // 
            // btndegistir
            // 
            this.btndegistir.Location = new System.Drawing.Point(207, 213);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(140, 37);
            this.btndegistir.TabIndex = 13;
            this.btndegistir.Text = "Değiştir";
            this.btndegistir.UseVisualStyleBackColor = true;
            this.btndegistir.Click += new System.EventHandler(this.btndegistir_Click);
            // 
            // cmbogretmen
            // 
            this.cmbogretmen.FormattingEnabled = true;
            this.cmbogretmen.Location = new System.Drawing.Point(205, 67);
            this.cmbogretmen.Name = "cmbogretmen";
            this.cmbogretmen.Size = new System.Drawing.Size(140, 32);
            this.cmbogretmen.TabIndex = 12;
            this.cmbogretmen.SelectedIndexChanged += new System.EventHandler(this.cmbogretmen_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ögretmen:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Oluştur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbders
            // 
            this.cmbders.FormattingEnabled = true;
            this.cmbders.Location = new System.Drawing.Point(205, 29);
            this.cmbders.Name = "cmbders";
            this.cmbders.Size = new System.Drawing.Size(140, 32);
            this.cmbders.TabIndex = 9;
            this.cmbders.SelectedIndexChanged += new System.EventHandler(this.cmbders_SelectedIndexChanged);
            // 
            // cmbogrenci
            // 
            this.cmbogrenci.FormattingEnabled = true;
            this.cmbogrenci.Location = new System.Drawing.Point(205, 175);
            this.cmbogrenci.Name = "cmbogrenci";
            this.cmbogrenci.Size = new System.Drawing.Size(140, 32);
            this.cmbogrenci.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ögrenci:";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(205, 139);
            this.maskedTextBox3.Mask = "00:00";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(140, 30);
            this.maskedTextBox3.TabIndex = 6;
            this.maskedTextBox3.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saat:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(205, 103);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(140, 30);
            this.maskedTextBox2.TabIndex = 4;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tarih:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ders:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 37);
            this.button2.TabIndex = 22;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EtutOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EtutOlustur";
            this.Text = "EtutOlustur";
            this.Load += new System.EventHandler(this.EtutOlustur_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbders;
        private System.Windows.Forms.ComboBox cmbogrenci;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbogretmen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btndegistir;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button button2;
    }
}