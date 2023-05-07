using System;
using System.ComponentModel.DataAnnotations;

namespace BeerAPI.Models
{
    /// <summary>
    /// Model which will be used for updating beer rating
    /// </summary>
    public class UpdateBeer : BaseEntity
    {
        /// <summary>
        /// Beer rating
        /// </summary>
        [Range(1, 5, ErrorMessage = "Rating should be between 1 to 5!")]
        [Required(ErrorMessage = "Rating is required!")]
        public double Rating { get; set; }
    }
}