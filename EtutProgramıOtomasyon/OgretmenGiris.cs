using Business.Concrete;
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
        OgretmenEtutManager oe= new OgretmenEtutManager();
        
        private void OgretmenGiris_Load(object sender, EventArgs e)
        {
            string.Join(",", kullan);
            //textBox1.Text=kullan[0].ToString();
            string k = "";
            foreach (Kullanici item in kullan)
            {
                 k= item.KullaniciAd;
                textBox1.Text = k;
            }
            //var kull=kullan.FirstOrDefault(y=>y.KullaniciAd==)

            dataGridView1.DataSource = Em.GetAll1(x => x.OgretmenAdSoyad == k);
        }
    }
}
