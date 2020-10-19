using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Models
{
    ///<Summary>
    /// Command
    ///</Summary>
    public class Command
    {
        ///<Summary>
        /// Id
        ///</Summary>
        [Key]
        [Required]
        public int Id { get; set; }

        ///<Summary>
        /// HowTo
        ///</Summary>
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        ///<Summary>
        /// Platform
        ///</Summary>
        [Required]
        public string Platform { get; set; }

        ///<Summary>
        /// CommandLine
        ///</Summary>
        [Required]
        public string CommandLine { get; set; }
    }
}
