﻿using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MoviewContext _context;
        public RemoveMovieCommandHandler(MoviewContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
