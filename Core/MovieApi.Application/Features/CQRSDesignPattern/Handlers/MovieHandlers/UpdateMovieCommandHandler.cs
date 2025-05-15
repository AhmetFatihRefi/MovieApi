using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MoviewContext _context;
        public UpdateMovieCommandHandler(MoviewContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            if (movie != null)
            {
                movie.Rating = command.Rating;
                movie.Status = command.Status;
                movie.Duration = command.Duration;
                movie.CoverImageUrl = command.CoverImageUrl;
                movie.CreatedYear = command.CreatedYear;
                movie.Description = command.Description;
                movie.ReleaseDate = command.ReleaseDate;
                movie.Title = command.Title;
                await _context.SaveChangesAsync();
            }
        }
    }
}
