using Etheater.Data.Base;
using Etheater.Data.ViewModel;
using Etheater.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Services
{
    public class MovieServices : EntityBaseRepository<Models.Movie>, IMovieService
    {
        AppDbContext Context;
        public MovieServices(AppDbContext _Context) : base(_Context)
        {
            Context = _Context; ;

        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var NewMovie = new Movie()
            {
                Description = data.Discription,
                Name = data.Name,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategories = data.MovieCategories,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId


            };
            await Context.AddAsync(NewMovie);
            await Context.SaveChangesAsync();
          foreach(var Actorid in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = NewMovie.Id,
                    ActorId = Actorid
                };
                await Context.AddAsync(newActorMovie);
            }
            await Context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var Movie_Detail = Context.Movie.Include(c => c.Cinema)
          .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await Movie_Detail;
            
        }

        public async Task<NewMovieDropDownVM> NewMovieDropDownValue()
        {
            var response = new NewMovieDropDownVM() {
                Cinemas = await Context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await Context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Actors = await Context.Actors.OrderBy(n => n.FullName).ToListAsync()
            };
            
            return response;
        }

     
        
        public async Task UpdateAsync(NewMovieVM data)
        {
            var dbMovie = Context.Movie.FirstOrDefault(n => n.Id == data.Id);
            if (dbMovie != null)
            {

                dbMovie.Description = data.Discription;
                dbMovie.Name = data.Name;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategories = data.MovieCategories;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                await Context.SaveChangesAsync();
            }
            var ExistingActor = Context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
            Context.Actor_Movies.RemoveRange(ExistingActor);
            Context.SaveChanges();

            foreach (var Actorid in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId =data.Id,
                    ActorId = Actorid
                };
                await Context.AddAsync(newActorMovie);
            }
            await Context.SaveChangesAsync();
        }
















     }
    }

