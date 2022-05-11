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
    public partial class OgretmenGiris : Form
    {
        List<Kullanici> kullan = new List<Kullanici>();
        public OgretmenGiris(List<Kullanici> kullan)
        {
            InitializeComponent();
            this.kullan = kullan;
        }
        EtutManagercs Em = new EtutManagercs();
        OgretmenEtutManager oe = new OgretmenEtutManager();
        DataContext context = new DataContext();
        OgretmenManager om = new OgretmenManager();
        DateTime bugun=DateTime.Now;
        string k = "";
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
        private void OgretmenGiris_Load(object sender, EventArgs e)
        {

            foreach (Kullanici item in kullan)
            {
                k = item.KullaniciAd;
                
            }

            dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);

            SaatleriYukle();
           
        }
        public void KayıtEkle()
        {
            int islem = Em.Add(

         new Etut
         {

             

             DersAd = dataGridView1.Rows[0].Cells[4].Value.ToString(),
             OgrenciAdSoyad = textBox1.Text,
             OgretmenAdSoyad = k,
             Tarih = dateTimePicker1.Value.ToShortDateString().Replace('/','.'),
             Saat = cmbsaat.Text


         });
            if (islem > 0)
            {
                dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);
                cmbsaat.Items.Remove(cmbsaat.SelectedItem);
                MessageBox.Show("Kayıt başarılı!");
            }
            else
                MessageBox.Show("Kayıt başarısız!");
        }//Kayıt ekleme Metot
        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());//secilen ID yi aldık 
            if (id > 0)
            {

                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int islemd = Em.Delete(id);
                    if (islemd > 0)
                    {
                        dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);
                        MessageBox.Show("Kayıt silindi!");
                    }
                    else
                        MessageBox.Show("Kayıt silme  başarısız!");
                }
            }
            else
                MessageBox.Show("Silinecek Kaydı seçiniz...");
        }

        private void btnolustur_Click(object sender, EventArgs e)//daha once aynı saatte alınan randevu var mı dıye bakıyor
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                string tarih = dateTimePicker1.Value.ToShortDateString().Replace('/', '.');
                if (row.Cells[2].Value.ToString()==tarih)
                {
                    
                    if (row.Cells[3].Value.ToString()!=cmbsaat.Text)
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
           
        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (id>0)
            {
                int guncelleislem = Em.Update(
                    new Etut
                    {
                        ID = id,
                        DersAd = dataGridView1.Rows[0].Cells[4].Value.ToString(),
                        OgrenciAdSoyad = textBox1.Text,
                        Tarih = dateTimePicker1.Value.ToShortDateString(),
                        Saat = cmbsaat.Text,
                        OgretmenAdSoyad = k,
                    }
                    );
                if (guncelleislem > 0)
                {
                    cmbsaat.Items.Remove(cmbsaat.SelectedIndex);
                    MessageBox.Show("Güncelleme başarılı");
                }
                else
                    MessageBox.Show("Güncelleme başarısız");
               
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cmbsaat.Items.Clear();
            SaatleriYukle();
           
        }

        private void cmbsaat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
