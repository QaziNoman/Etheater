using Etheater.Data.Base;
using Etheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Services
{
    public class CinemaServices:EntityBaseRepository<Cinema>,ICinemaServices
    {
        public CinemaServices(AppDbContext Context):base(Context)
        {
                
        }
    }
}
