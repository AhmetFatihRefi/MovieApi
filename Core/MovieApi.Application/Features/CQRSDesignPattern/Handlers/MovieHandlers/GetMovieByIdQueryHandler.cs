using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MoviewContext moviewContext;
        public GetMovieByIdQueryHandler(MoviewContext moviewContext)
        {
            this.moviewContext = moviewContext;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery command)
        {
            var movie = await moviewContext.Movies.FindAsync(command);
            if (movie == null)
            {
                return new();
            }
            return new GetMovieByIdQueryResult
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                CreatedYear = movie.CreatedYear,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Rating = movie.Rating,
                Status = movie.Status,
                CoverImageUrl = movie.CoverImageUrl
            };
        }
    }
}
