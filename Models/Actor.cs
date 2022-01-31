using Etheater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Models
{
    public class Actor:IEntityBase
    {
        
         [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture" )]
        [Required(ErrorMessage ="Profile Picture is Required")]
        public String ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="FullName must be between 3 and 50 Chars")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "BioGraphy is Required")]
        public String Bio { get; set; }
        //RelationShip
        public List<Actor_Movie> Actor_Movies { get; set; }



    }
}
