using Etheater.Data.Base;
using Etheater.Data.ViewModel;
using Etheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Services
{
   public interface IMovieService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownVM> NewMovieDropDownValue();
        Task AddNewMovieAsync(NewMovieVM data);
     Task  UpdateAsync(NewMovieVM movie);
       
    }
}
