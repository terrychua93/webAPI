namespace WebAPI.Models.DTO
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public long Population { get; set; }

    }
}
