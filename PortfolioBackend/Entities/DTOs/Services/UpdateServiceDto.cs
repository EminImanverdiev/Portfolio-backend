namespace PortfolioBackend.Entities.DTOs.Services
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceName { get; set; }
        public string ServiceContent { get; set; }
    }
}
