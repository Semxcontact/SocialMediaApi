using System.ComponentModel.DataAnnotations;

namespace SocialMediaApi.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)] 
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }


        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
