using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_time_chat_luka_marinkovic.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
    }
}
