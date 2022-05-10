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
            Database.SetInitializer(new DataInitializer());//ýntializeri cagýrdýk 
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
            //tablolara s takýsý gelmesýn diye 
        }
        public class DataInitializer:CreateDatabaseIfNotExists<DataContext>//eger databaseým yoksa olustur
        {
            protected override void Seed(DataContext context)
            {
                if (!context.kullanicilar.Any())//eger hýc kullanýcý yoksa yený ekle 
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
                //verýtabaný olustuktan sonra devreye girip iþlem yapar
            }




        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}