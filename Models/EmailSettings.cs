using System.ComponentModel.DataAnnotations;

namespace SocialMediaApi.Models
{
    public class EmailSettings
    {
        [Required]
        public string SmtpServer { get; set; }

        [Required]
        [Range(1, 65535)]
        public int Port { get; set; }

        [Required]
        [MaxLength(100)]
        public string SenderName { get; set; }

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
