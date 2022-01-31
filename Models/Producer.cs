using Etheater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Models
{
    public class Producer:IEntityBase
    {   
        [Key]
       
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        public String ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public String Bio { get; set; }
        public List<Movie> Movie { get; set; }
    }
}
