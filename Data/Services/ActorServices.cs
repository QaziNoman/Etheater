using Etheater.Data.Base;
using Etheater.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Services
{
    public class ActorServices : EntityBaseRepository<Actor>, IActorServices
    {
       
        public ActorServices(AppDbContext _Context): base(_Context)
        {
            
        }
       

       
        


        
      
    }
}
