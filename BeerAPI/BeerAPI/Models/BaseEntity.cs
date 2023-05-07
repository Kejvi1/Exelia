using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerAPI.Models
{
    /// <summary>
    /// Base entity model
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Record ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}