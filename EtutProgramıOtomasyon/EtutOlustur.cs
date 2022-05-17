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
        DateTime bugun = DateTime.Now;




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
                cmbogrenci.Items.Add(new { Text = ogr.OgrenciAdSoyad, Value = ogr.ID });
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    string tarih1 = string.Format("{0:d}", bugun);
            //    string tarih2 = string.Format("{0:d}", dataGridView1.Cells[].Value.ToString());
            //    int sonuc = tarih1.CompareTo(tarih2);
            //    if (sonuc == -1)
            //    {
            //        int ıd = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
            //        int islems = em.Update(

            //    new Etut
            //    {
            //        ID = ıd,

            //        // Adi = cmbders.Text,
            //        DersAd = cmbders.Text,
            //        OgrenciAdSoyad = cmbogrenci.Text,
            //        OgretmenAdSoyad = cmbogretmen.Text,
            //        Durum = checkBox1.Checked,
            //        Tarih = dateTimePicker1.Text,
            //        Saat = cmbsaat.Text


            //    }
            //        );
            //    }
            //}

        }

        private void button1_Click(object sender, EventArgs e)//bırebır ekleme
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                string tarih = dateTimePicker1.Value.ToShortDateString().Replace('/', '.');
                if (row.Cells[2].Value.ToString() == tarih)
                {

                    if (row.Cells[3].Value.ToString() != cmbsaat.Text)
                    {
                        if (dateTimePicker1.Value >= bugun)
                        {

                            KayıtEkle();
                            break;
                        }
                        else
                            MessageBox.Show("Lütfen tarihi kontrol ediniz");

                    }
                    else
                    {
                        MessageBox.Show("Lutfen saati kontrol edin !");
                        break;
                    }
                }
                else
                {
                    if (dateTimePicker1.Value >= bugun)
                    {
                        KayıtEkle();

                        break;
                    }
                    else
                        MessageBox.Show("Lütfen tarihi kontrol ediniz");

                    break;
                }
            }
            int islem = em.Add(
              new Etut
              {

                 // Adi = cmbders.Text,
                  DersAd = cmbders.Text,
                  OgrenciAdSoyad = cmbogrenci.Text,
                  OgretmenAdSoyad = cmbogretmen.Text,
               
                  Tarih = dateTimePicker1.Text,
                  
                  Saat = cmbsaat.Text


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
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbsaat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
        public void SaatleriYukle()
        {

            cmbsaat.Items.Add("08:30");
            cmbsaat.Items.Add("09:30");
            cmbsaat.Items.Add("10:30");
            cmbsaat.Items.Add("11:30");
            cmbsaat.Items.Add("13:30");
            cmbsaat.Items.Add("14:30");
            cmbsaat.Items.Add("15:30");
            cmbsaat.Items.Add("16:30");
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells[3].Value.ToString() == cmbsaat.Contains.)
            //    {
            //        cmbsaat.Items.Remove(cmbsaat.SelectedItem);
            //    }
            //}

        }
        public void KayıtEkle()
        {
            int islem = em.Add(

         new Etut
         {



             DersAd = dataGridView1.Rows[0].Cells[4].Value.ToString(),
             OgrenciAdSoyad = cmbogrenci.Text,
             OgretmenAdSoyad = cmbogretmen.Text,
             Tarih = dateTimePicker1.Value.ToShortDateString().Replace('/', '.'),
             Saat = cmbsaat.Text


         }) ;
            if (islem > 0)
            {
                dataGridView1.DataSource = em.GetAll1(x => x.OgretmenAdSoyad == cmbogretmen.Text);
               cmbsaat.Items.Remove(cmbsaat.SelectedItem);
              
                MessageBox.Show("Kayıt başarılı!");
            }
            else
                MessageBox.Show("Kayıt başarısız!");
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
                     Tarih = dateTimePicker1.Text,
                     Saat = cmbsaat.Text


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
            cmbogretmen.Items.Clear();
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
