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

        string k = "";
        
        private void OgretmenGiris_Load(object sender, EventArgs e)
        {

            foreach (Kullanici item in kullan)
            {
                k = item.KullaniciAd;
                
            }

            dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);
           
        }
        public void KayıtEkle()
        {
            int islem = Em.Add(

         new Etut
         {


             DersAd = dataGridView1.Rows[0].Cells[4].Value.ToString(),
             OgrenciAdSoyad = textBox1.Text,
             OgretmenAdSoyad = k,
             Tarih = maskedTextBox1.Text,
             Saat = cmbsaat.Text


         });
            if (islem > 0)
            {
                dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);
                MessageBox.Show("Kayıt başarılı!");
            }
            else
                MessageBox.Show("Kayıt başarısız!");
        }
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

        private void btnolustur_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value.ToString()!=maskedTextBox1.Text)
                {
                    if (row.Cells[3].Value.ToString()!=maskedTextBox2.Text)
                    {
                        KayıtEkle();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Hata");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Hata2");
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
                        Tarih = maskedTextBox1.Text,
                        Saat = maskedTextBox2.Text,
                        OgretmenAdSoyad = k,
                    }
                    );
                if (guncelleislem > 0)
                {
                    MessageBox.Show("Güncelleme başarılı");
                }
                else
                    MessageBox.Show("Güncelleme başarısız");
               
            }
        }
    }
}
