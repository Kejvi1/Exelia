using BeerAPI.Models;
using System.Collections.Generic;

namespace BeerAPI.Interfaces
{
    /// <summary>
    /// Beer interface
    /// </summary>
    public interface IBeerRepository
    {
        /// <summary>
        /// Gets all beers from database
        /// </summary>
        /// <returns></returns>
        OkResponse<IEnumerable<Beer>> GetBeers();

        /// <summary>
        /// Filters beers based on filter criteria
        /// </summary>
        /// <param name="filter">Filter object</param>
        /// <returns></returns>
        OkResponse<IEnumerable<Beer>> FilterBeers(string filter);

        /// <summary>
        /// Adds a new beer object to database
        /// </summary>
        /// <param name="beer">Beer object that is going to be added</param>
        /// <returns></returns>
        OkResponse<Beer> AddBeer(Beer beer);

        /// <summary>
        /// Updates beer in database
        /// </summary>
        /// <param name="model">Beer object that is going to be updated</param>
        /// <returns></returns>
        OkResponse<Beer> UpdateBeer(UpdateBeer model);
    }
}