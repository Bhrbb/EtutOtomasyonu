using Entities.Concrete;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class DataContext : DbContext
    {
       
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new DataInitializer());//�ntializeri cag�rd�k 
        }

       
        public virtual DbSet<Dersler>brans { get; set; }
        public virtual DbSet<Kullanici> kullanicilar { get; set; }
        public virtual DbSet<Ogrenci> ogrenciler { get; set; }
        public virtual DbSet<Ogretmen> ogretmenler { get; set; }
        public virtual DbSet<Etut> etutler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //tablolara s tak�s� gelmes�n diye 
        }
        public class DataInitializer:CreateDatabaseIfNotExists<DataContext>//eger database�m yoksa olustur
        {
            protected override void Seed(DataContext context)
            {
                if (!context.kullanicilar.Any())//eger h�c kullan�c� yoksa yen� ekle 
                {
                    context.kullanicilar.Add(new Kullanici
                    {
                        KullaniciAd = "bhr",
                        Sifre="1234",Durumu=true,Yetki=1
                    }
                    ) ;
                    context.SaveChanges();
                    
                }
                base.Seed(context);
                //ver�taban� olustuktan sonra devreye girip i�lem yapar
            }




        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}