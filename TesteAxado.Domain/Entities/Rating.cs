namespace TesteAxado.Domain.Entities
{
    public class Rating
    {
        public long Id { get; set; }

        public int Rate { get; set; }
        public string Comment { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; }
    }
}
