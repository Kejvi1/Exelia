using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerAPI.Models
{
    /// <summary>
    /// Beer model
    /// </summary>
    [Table("Beers")]
    public class Beer : BaseEntity
    {
        /// <summary>
        /// Name of beer
        /// </summary>
        [Required(ErrorMessage = "Name of beer is required!")]
        public string Name { get; set; }

        /// <summary>
        /// Type of beer
        /// </summary>
        [Required(ErrorMessage = "Type of beer is required!")]
        public string Type { get; set; }

        /// <summary>
        /// Rating of the beer
        /// </summary>
        [Range(1, 5, ErrorMessage = "Beer rating should be between 1 to 5!")]
        public double? Rating { get; set; }
    }
}