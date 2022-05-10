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
    public partial class Sekreter1 : Form
    {
        public Sekreter1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text== "Etüt Oluşturma")
            {
               EtutOlustur etutOlustur = new EtutOlustur();
                etutOlustur.Show();
                this.Hide();
            }
            else if (comboBox1.Text== "Ögrenci Arama")
            {
                OgrenciAra ogrenciAra = new OgrenciAra();
                ogrenciAra.Show();
                this.Hide();
            }
            else if (comboBox1.Text=="Yeni Kayıt")
            {
                YeniKayıt yeni=new YeniKayıt();
                yeni.Show();

            }

        }

        private void Sekreter1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
