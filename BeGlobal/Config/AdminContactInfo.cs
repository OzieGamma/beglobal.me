using System.Net.Mail;

namespace BeGlobal.Config
{
    /// <summary>
    /// Represents the contact information for the website admin
    /// </summary>
    public class AdminContactInfo
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public MailAddress MailAddress => new MailAddress(this.Email, this.Name);
    }
}