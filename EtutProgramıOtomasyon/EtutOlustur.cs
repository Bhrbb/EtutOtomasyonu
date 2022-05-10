using Business.Concrete;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtutProgramıOtomasyon
{
    public partial class EtutOlustur : Form
    {
        public EtutOlustur()
        {
            InitializeComponent();
        }
        EtutManagercs em = new EtutManagercs();
        DataContext context = new DataContext();
       


       
        
        private void EtutOlustur_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = em.GetAll();
         

            var ders = context.brans.ToList();//cmb bransuı doldurduk dverıtabanından gelen bılgılerle 
            cmbders.DisplayMember = "Text";
            cmbders.ValueMember = "Value";
            foreach (var d in ders)
            {
                cmbders.Items.Add(new { Text = d.DersAd, Value = d.ID });
            }

            var ogrenci = context.ogrenciler.ToList();
            cmbogrenci.DisplayMember = "Text";
            cmbogrenci.ValueMember = "Value";
            foreach (var ogr in ogrenci)
            {
                cmbogrenci.Items.Add(new { Text=ogr.OgrenciAdSoyad, Value=ogr.ID});
            }
          

        }

        private void button1_Click(object sender, EventArgs e)//bırebır ekleme
        {

            int islem = em.Add(
              new Etut
              {

                 // Adi = cmbders.Text,
                  DersAd = cmbders.Text,
                  OgrenciAdSoyad = cmbogrenci.Text,
                  OgretmenAdSoyad = cmbogretmen.Text,
               
                  Tarih = maskedTextBox2.Text,
                  
                  Saat = maskedTextBox3.Text


              }

              ) ; 
            if (islem > 0)
            {
               dataGridView1.DataSource = em.GetAll();
                MessageBox.Show("Kayıt başarılı!");
            }
            else
                MessageBox.Show("Kayıt başarısız!");
        }
        //datagrid e verileri çekmek
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            checkBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmbders.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cmbogretmen.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbogrenci.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (checkBox1.Text=="true")
            {
                checkBox1.Text = "İptal edilmiş";
            }
            else
                checkBox1.Text = "Güncel";




        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            int id=int.Parse(lblID.Text);//secilen ID yi aldık 
            if (id > 0)
            {
                var ders = context.ogrenciler.Where(o => o.ID == cmbders.SelectedIndex);
               
                int islems = em.Update(

                 new Etut
                 {
                     ID = id,

                    // Adi = cmbders.Text,
                     DersAd = cmbders.Text,
                     OgrenciAdSoyad = cmbogrenci.Text,
                     OgretmenAdSoyad = cmbogretmen.Text,
                     Durum=checkBox1.Checked,
                     Tarih = maskedTextBox2.Text,
                     Saat = maskedTextBox3.Text


                 }
                     );
                if (islems > 0)
                {
                    dataGridView1.DataSource = em.GetAll();
                    MessageBox.Show("Kayıt güncellendi!");
                }
                else
                    MessageBox.Show("Kayıt güncelleme  başarısız!");
            }
            else
                MessageBox.Show("Güncellenecek Kaydı seçiniz...");

        }

        private void cmbogretmen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblID.Text);//secilen ID yi aldık 
            if (id > 0)
            {
               
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int islemd = em.Delete(id);
                    if (islemd > 0)
                    {
                        dataGridView1.DataSource = em.GetAll();
                        MessageBox.Show("Kayıt silindi!");
                    }
                    else
                        MessageBox.Show("Kayıt silme  başarısız!");
                }
            }
            else
                MessageBox.Show("Silinecek Kaydı seçiniz...");


        }

        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var ogrtmenler=context.ogretmenler.Where(o=>o.ID ==cmbders.SelectedIndex+1);
            cmbogretmen.DisplayMember = "Text";
            cmbogretmen.ValueMember = "Value";
            foreach (var ogrt in ogrtmenler)
            {
                cmbogretmen.Items.Add(new { Text = ogrt.OgretmenAdSoyad, Value = ogrt.BransAd });
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sekreter1 sekreter = new Sekreter1();
            sekreter.Show();
            this.Hide();
        }
    }

        
}
