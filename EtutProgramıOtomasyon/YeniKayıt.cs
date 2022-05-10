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
    public partial class YeniKayıt : Form
    {
        public YeniKayıt()
        {
            InitializeComponent();
        }
        OgrenciManager om = new OgrenciManager();
        DersManager dm = new DersManager();
       OgretmenManager ogrtm= new OgretmenManager();
         DataContext context = new DataContext();
       

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ogretmen")
            {
                comboBox2.Visible = true;
                label5.Text = "Branş";
                label5.Visible = true;
                txtsınıf.Visible = false;
                label3.Visible = false;
                

            }
            else if (comboBox1.Text == "Ogrenci")
            {
                
                label5.Visible= false;
                comboBox2.Visible = false;
            }
            else if(comboBox1.Text == "Ders")
            {
               comboBox2.Visible = true;
                label5.Visible = true;
                label3.Visible = false;
                txtsınıf.Visible = false;
                label4.Visible = false;
                maskedTextBox1.Visible = false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text=="Ogrenci")
            {
                int islem = om.Add(

                new Ogrenci
                {
                    OgrenciAdSoyad = txtad.Text,
                    Sinifi=txtsınıf.Text,
                    TelNo = maskedTextBox1.Text
                });
                
                if (islem > 0)
                {
                    //dataGridView1.DataSource = em.GetAll();
                    MessageBox.Show("Kayıt başarılı!");
                }
                else
                    MessageBox.Show("Kayıt başarısız!");
            }
            else if (comboBox1.Text == "Ders")
            {
                int islem = dm.Add(
                new Dersler
                {
                   DersAd=comboBox2.Text, 
                   
                   
                }
                );
                if (islem > 0)
                {
                   // dataGridView1.DataSource = dm.GetAll();
                    MessageBox.Show("Kayıt başarılı!");
                }
                else
                    MessageBox.Show("Kayıt başarısız!");
            }
            else if (comboBox1.Text=="Ogretmen")
            {
                int islem = ogrtm.Add(
                    new Ogretmen
                    {
                        OgretmenAdSoyad = txtad.Text,
                        BransAd = comboBox2.Text,

                    });
                     if (islem > 0)
                     {
                       // dataGridView1.DataSource = dm.GetAll();
                      MessageBox.Show("Kayıt başarılı!");
                     }
                     else
                      MessageBox.Show("Kayıt başarısız!");
            }


        }

        private void YeniKayıt_Load(object sender, EventArgs e)
        {
            var ders = context.brans.ToList();
            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";
            foreach (var d in ders)
            {
                comboBox2.Items.Add(new { Text = d.DersAd, Value = d.ID });
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
