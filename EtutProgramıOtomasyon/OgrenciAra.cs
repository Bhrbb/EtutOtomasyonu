using Business.Concrete;
using Entities.Concrete;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Data;

namespace EtutProgramıOtomasyon
{
    public partial class OgrenciAra : Form
    {
        public OgrenciAra()
        {
            InitializeComponent();
        }
        EtutManagercs Em =  new EtutManagercs();
        OgrenciManager om= new OgrenciManager();
        DataContext context = new DataContext();
        public  void ogrencinoyagöre()
        {
            int ıd = int.Parse(txtno.Text);
            var ogrenci = context.ogrenciler.Where(o => o.ID == ıd);//ogrencinin bilgileri geliyor
            
            foreach (var ogr in ogrenci)
            {
                txtadi.Text = ogr.OgrenciAdSoyad.ToString();
                txttelefonu.Text = ogr.TelNo.ToString();
                txtsinifi.Text = ogr.Sinifi.ToString();
                // pictureBox1.Image = ogr. eksik kaldı yap
            }
            var ogrencino = context.etutler.Where(o => o.ID == ıd);//ogrencinin aldıgı etutler
            dataGridView1.DataSource = ogrencino.ToList();

        }
        public void ogrenciadinagöre()
        {
            string ad = (txtad.Text);
            var ogrenci = om.GetAll1(o => o.OgrenciAdSoyad == ad);
            var ogrencibilgi = Em.GetAll1(o => o.OgrenciAdSoyad == ad);
            dataGridView1.DataSource = ogrencibilgi.ToList();

            foreach (var ogr in ogrenci)
            {
                txtadi.Text = ogr.OgrenciAdSoyad.ToString();
                txttelefonu.Text = ogr.TelNo.ToString();
                txtsinifi.Text = ogr.Sinifi.ToString();
                // pictureBox1.Image = ogr. eksik kaldı yap
            }

        }
        public void sinifagöre()
        {
            string sinifi = txtsoyad.Text;
            var sinif = context.ogrenciler.Where(o => o.Sinifi== sinifi);
            dataGridView1.DataSource=sinif.ToList();
        }
        public void istatistikogrenciadinagöre()
        {
            int count1 = context.etutler.Where(x => x.OgrenciAdSoyad == txtad.Text && x.DersAd == "Matematik").Count();
            int count2 = context.etutler.Where(x => x.OgrenciAdSoyad == txtad.Text && x.DersAd == "Fizik").Count();
            int count3 = context.etutler.Where(x => x.OgrenciAdSoyad == txtad.Text && x.DersAd == "Kimya").Count();
            int count4 = context.etutler.Where(x => x.OgrenciAdSoyad == txtad.Text && x.DersAd == "Türkçe").Count();

            foreach (var series in chart1.Series)//chartı temızleme
            {
                series.Points.Clear();
            }
            chart1.Series["Matematik"].Points.Add(count1);
            chart1.Series["Fizik"].Points.Add(count2);
            chart1.Series["Kimya"].Points.Add(count3);
            chart1.Series["Türkçe"].Points.Add(count4);

        }
        public void istatistikogren()
        {
            int no = int.Parse(txtno.Text);
            int count1 = context.etutler.Where(x => x.ID == no&& x.DersAd == "Matematik").Count();
            int count2 = context.etutler.Where(x => x.ID == no && x.DersAd == "Fizik").Count();
            int count3 = context.etutler.Where(x => x.ID == no && x.DersAd == "Kimya").Count();
            int count4 = context.etutler.Where(x => x.ID == no && x.DersAd == "Türkçe").Count();

            foreach (var series in chart1.Series)//chartı temızleme
            {
                series.Points.Clear();
            }
            chart1.Series["Matematik"].Points.Add(count1);
            chart1.Series["Fizik"].Points.Add(count2);
            chart1.Series["Kimya"].Points.Add(count3);
            chart1.Series["Türkçe"].Points.Add(count4);

        }
        private void btnara_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "")
            {
                ogrenciadinagöre();
                istatistikogrenciadinagöre();
            }
            else if (txtno.Text != "")
            {
                ogrencinoyagöre();
                istatistikogren();
            }

            else if (txtsoyad.Text != "")
            {
                sinifagöre();
            }
            else
                MessageBox.Show("Aranacak bilgi giriniz!");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtno.Text);

            if (id > 0)
            {
                int islems = om.Update(
                    new Ogrenci
                    {
                        ID = id,
                        OgrenciAdSoyad = txtadi.Text,
                        Sinifi = txtsinifi.Text,
                        TelNo = txttelefonu.Text,

                    }

                    );
                if (islems > 0)
                {
                    MessageBox.Show("Guncelleme basarılı");
                }
                else
                    MessageBox.Show("Guncelleme başarısız");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label4.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtadi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtsinifi.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttelefonu.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label4.Text);//secilen ID yi aldık 
            if (id > 0)
            {

                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int islemd = om.Delete(id);
                    if (islemd > 0)
                    {
                        dataGridView1.DataSource = om.GetAll();
                        MessageBox.Show("Kayıt silindi!");
                    }
                    else
                        MessageBox.Show("Kayıt silme  başarısız!");
                }
            }
            else
                MessageBox.Show("Silinecek Kaydı seçiniz...");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekreter1 sekreter = new Sekreter1();
            sekreter.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
