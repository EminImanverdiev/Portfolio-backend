namespace PortfolioBackend.Entities.DTOs.ContactForms
{
    public class ContactFormDtoBase
    {
        public int ContactFormId { get; set; }
        public string? ContactFormName { get; set; }
        public string? ContactFormEmail { get; set; }
        public string? ContactFormSubject { get; set; }
        public string? ContactFormMessage { get; set; }
    }
}
