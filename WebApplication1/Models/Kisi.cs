using WebApplication1.Abstract;

namespace WebApplication1.Models
{
    public class Kisi: IEntity
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Mail { get; set; }

        public string? Aciklama { get; set; }

        public byte[] Resim { get; set; }

        public ICollection<Makale> Makaleler { get; set; }

        public Kisi()
        {
            Makaleler = new HashSet<Makale>();
        }

    }
}
   