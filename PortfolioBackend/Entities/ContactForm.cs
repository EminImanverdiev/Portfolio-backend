namespace PortfolioBackend.Entities
{
    public class ContactForm
    {
        public int ContactFormId { get; set; }
        public string? ContactFormName { get; set; }
        public string? ContactFormEmail { get; set; }
        public string? ContactFormSubject { get; set; }
        public string? ContactFormMessage { get; set; }
    }
}
