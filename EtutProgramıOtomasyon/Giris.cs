using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtutProgramıOtomasyon
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        List<Kullanici> kullan = new List<Kullanici>();
        KullaniciManager km = new KullaniciManager();
        Kullanici k= new Kullanici();
        OgretmenManager ogr = new OgretmenManager();
        // DataContext context = new DataContext();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           var kuyllanici=km.Find(k=>k.KullaniciAd==textBox1.Text&& k.Sifre==textBox2.Text && k.Yetki==1);
           var kuyllanici2=km.Find(k=>k.KullaniciAd==textBox1.Text&& k.Sifre==textBox2.Text && k.Yetki==2);
           var kuyllanici3=km.Find(k=>k.KullaniciAd==textBox1.Text&& k.Sifre==textBox2.Text && k.Yetki==3);
          //  var kul = km.GetAll1(k => k.KullaniciAd == textBox1.Text && k.Sifre == textBox2.Text && k.Yetki == 3);
            kullan.Add(kuyllanici3);
            if (string.IsNullOrWhiteSpace(textBox1.Text)||string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve şifre boş geçilemez!");
            }
            else
            {

                if (kuyllanici != null)
                {
                    Sekreter1 sekreter1 = new Sekreter1();
                    sekreter1.Show();
                    this.Hide();
                }
                else if (kuyllanici2 != null)
                {
                    OgrenciGiris ogrenciGiris = new OgrenciGiris();
                    ogrenciGiris.Show();
                    this.Hide();
                }
                else if (kuyllanici3!=null)
                {
                    OgretmenGiris ogretmenGiris = new OgretmenGiris(kullan);
                    ogretmenGiris.Show();

                }
                else
                    MessageBox.Show("Lütfen bilgileri kontrol edniz!");

                //OgretmenGiris o = new OgretmenGiris(kullan);
                //o.Show();
            }




        }
    }
}
