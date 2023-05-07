using BeerAPI.Interfaces;
using BeerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerAPI.Repository
{
    public class BeerRepository : IBeerRepository
    {
        private ApplicationContext _context;

        public BeerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public OkResponse<IEnumerable<Beer>> GetBeers()
        {
            return new OkResponse<IEnumerable<Beer>> 
            { 
                Data = _context.Beers, 
                Message = "Data fetched successfully!" 
            };
        }

        public OkResponse<IEnumerable<Beer>> FilterBeers(string filter)
        {
            return new OkResponse<IEnumerable<Beer>> 
            { 
                Data = _context.Beers.Where(b => string.IsNullOrWhiteSpace(filter) || b.Name.ToLower().Contains(filter.ToLower()))
                , Message = "Data fetched successfully!" 
            };
        }

        public OkResponse<Beer> AddBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();

            return new OkResponse<Beer>
            {
                Data = beer,
                Message = "Beer has been added successfully!"
            };
        }

        public OkResponse<Beer> UpdateBeer(UpdateBeer model)
        {
            var beer = _context.Beers.FirstOrDefault(b => b.ID == model.ID);

            if (beer is null)
                throw new KeyNotFoundException("Beer not found!");

            var rating = ((beer.Rating is null ? 0 : beer.Rating.Value) + model.Rating) / 2;

            beer.Rating = rating;

            _context.SaveChanges();

            return new OkResponse<Beer>
            {
                Data = beer,
                Message = "Beer has been updated successfully!"
            };
        }
    }
}