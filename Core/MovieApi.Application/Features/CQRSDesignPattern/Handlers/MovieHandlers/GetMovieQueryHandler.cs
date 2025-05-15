using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MoviewContext _context;

        public GetMovieQueryHandler(MoviewContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(m => new GetMovieQueryResult
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                CreatedYear = m.CreatedYear,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Rating = m.Rating,
                Status = m.Status,
                CoverImageUrl = m.CoverImageUrl
            }).ToList();
        }
    }
}
