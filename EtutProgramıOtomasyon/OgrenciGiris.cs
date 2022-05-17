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
    public partial class OgrenciGiris : Form
    {
      //  List<Kullanici> kullanc = new List<Kullanici>() ;
        string ogrc = "";
        public OgrenciGiris(string kullanc)
        {
            InitializeComponent();
            ogrc = kullanc;
           
        }
        OgrenciManager om = new OgrenciManager();
        EtutManagercs em = new EtutManagercs();
        DataContext context = new DataContext();
      //  string k = "";
        private void OgrenciGiris_Load(object sender, EventArgs e)
        {
           
            var ders = context.brans.ToList();//bransı doldur
            cmbders.DisplayMember = "Text";
            cmbders.ValueMember = "Value";
            foreach (var d in ders)
            {
                cmbders.Items.Add(new { Text = d.DersAd, Value = d.ID });
            }

            //var ogrenci = context.ogrenciler.ToList();//ogrenciler
            //cmbogrenci.DisplayMember = "Text";
            //cmbogrenci.ValueMember = "Value";
            //foreach (var ogr in ogrenci)
            //{
            //    cmbogrenci.Items.Add(new { Text = ogr.OgrenciAdSoyad, Value = ogr.ID });
            //}
            SaatleriYukle();
           

            dataGridView1.DataSource = em.GetAll1(x => x.OgrenciAdSoyad == ogrc);
        }

        public void SaatleriYukle()
        {

            comboBox1.Items.Add("08:30");
            comboBox1.Items.Add("09:30");
            comboBox1.Items.Add("10:30");
            comboBox1.Items.Add("11:30");
            comboBox1.Items.Add("13:30");
            comboBox1.Items.Add("14:30");
            comboBox1.Items.Add("15:30");

            //var ogretmen = em.Find(x => x.OgretmenAdSoyad == cmbogretmen.Text);
            //if (ogretmen != null)
            //{
            //    var tarih = em.Find(x => x.Tarih == dateTimePicker1.Text);
            //    if (tarih != null)
            //    {
            //        foreach (var d in comboBox1.Items)
            //        {
            //            string[] items = new string[comboBox1.Items.Count];
            //            for (int i = 0; i < comboBox1.Items.Count; i++)
            //            {
            //                items[i] = comboBox1.Items[i].ToString();
            //                if (items[i] == em.Find())
            //                {
            //                    comboBox1.Items.Remove(items[i]);
            //                }
            //            }

            //        }
            //    }
            //}






        }
        private void button1_Click(object sender, EventArgs e)//bırebır olusturmak
        {
            int islem = em.Add(
              new Etut
              {

                  // Adi = cmbders.Text,
                  DersAd = cmbders.Text,
                  OgrenciAdSoyad = ogrc,
                  OgretmenAdSoyad = cmbogretmen.Text,
                  Tarih = dateTimePicker1.Text,
                  Saat = comboBox1.Text


              }

              ) ;
            if (islem > 0)
            {
               
                dataGridView1.DataSource = em.GetAll1(x => x.OgrenciAdSoyad == ogrc);
                MessageBox.Show("Kayıt başarılı!");
            }
            else
                MessageBox.Show("Kayıt başarısız!");
        }

        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretmen.Items.Clear();
            var ogrtmenler = context.ogretmenler.Where(o => o.ID == cmbders.SelectedIndex + 1);
            cmbogretmen.DisplayMember = "Text";
            cmbogretmen.ValueMember = "Value";
            foreach (var ogrt in ogrtmenler)
            {

                cmbogretmen.Items.Add(new { Text = ogrt.OgretmenAdSoyad, Value = ogrt.BransAd });
            }
        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblID.Text);//secilen ID yi aldık 
            if (id > 0)
            {
                var ders = context.ogrenciler.Where(o => o.ID == cmbders.SelectedIndex);

                int islems = em.Update(

                 new Etut
                 {
                     ID = id,

                     // Adi = cmbders.Text,
                     DersAd = cmbders.Text,
                     OgrenciAdSoyad = ogrc,
                     OgretmenAdSoyad = cmbogretmen.Text,

                     Tarih = dateTimePicker1.Text,
                     Saat = comboBox1.Text


                 }
                     );
                if (islems > 0)
                {
                    dataGridView1.DataSource = em.GetAll1(x => x.OgrenciAdSoyad == ogrc);
                    MessageBox.Show("Kayıt güncellendi!");
                }
                else
                    MessageBox.Show("Kayıt güncelleme  başarısız!");
            }
            else
                MessageBox.Show("Güncellenecek Kaydı seçiniz...");
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
                        dataGridView1.DataSource = em.GetAll1(x => x.OgrenciAdSoyad == ogrc);
                        MessageBox.Show("Kayıt silindi!");
                    }
                    else
                        MessageBox.Show("Kayıt silme  başarısız!");
                }
            }
            else
                MessageBox.Show("Silinecek Kaydı seçiniz...");

        }

        private void cmbogretmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SaatleriYukle();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmbders.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cmbogretmen.Text=dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris grs=new Giris();
            grs.Show();
            this.Hide();
        }
    }
}
