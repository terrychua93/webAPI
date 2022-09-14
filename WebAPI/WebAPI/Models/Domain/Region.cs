namespace WebAPI.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public long Population { get; set; }

        // Navigation Property
        public IEnumerable<Walk> Walks { get; set; }

    }
}
