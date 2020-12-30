using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Models
{
    /// <summary>Command</summary>
    public class Command
    {
        /// <summary>Id</summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>HowTo</summary>
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        /// <summary>Platform</summary>
        [Required]
        public string Platform { get; set; }

        /// <summary>CommandLine</summary>
        [Required]
        public string CommandLine { get; set; }
    }
}
