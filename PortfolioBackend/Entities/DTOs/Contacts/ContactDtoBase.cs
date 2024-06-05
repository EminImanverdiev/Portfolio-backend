namespace PortfolioBackend.Entities.DTOs.Contacts
{
    public class ContactDtoBase
    {
        public int ContactId { get; set; }
        public string? ContactTitle { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactLocation { get; set; }
        public string? ContactNumber { get; set; }
    }
}
