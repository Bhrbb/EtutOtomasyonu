namespace Entities.Concrete
{
    public class Kullanici : IEntity
    {
        public int ID { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Durumu { get; set; }
        public int Yetki { get; set; }
    }
}
