namespace WebApplication1.Models
{
    public class Konu
    {
        public int Id { get; set; }

        public string KonuAdi { get; set; }

        public ICollection<Makale> Makaleler { get; set; }

        public Konu()
        {
            Makaleler = new HashSet<Makale>();
        }
    }
}
