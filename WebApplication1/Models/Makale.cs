using WebApplication1.Abstract;

namespace WebApplication1.Models
{
    public class Makale : IEntity
    {
        public int Id { get; set; }

        public ICollection<Konu> Konular { get; set; }

        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public Kisi Kisi { get; set; }
        public int KisiId { get; set; }


        public Makale()
        {
            Konular = new HashSet<Konu>();
        }
    }
}
