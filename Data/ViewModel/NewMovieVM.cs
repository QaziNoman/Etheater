
using Etheater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Models
{
    public class NewMovieVM {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        [Display(Name = "Movie Description")]
        public String Discription { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie Poster is required")]
        [Display(Name = "Movie Poster URL")]
        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "Start Date Is Required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date Is Required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Movie Category is Required")]
        [Display(Name = "Select Movie Category")]
        public Data.MovieCategory MovieCategories { get; set; }


        [Required(ErrorMessage = "Movie Actor is Required")]
        [Display(Name = "Select Movie Actor")]
        public List<int> ActorIds{ get; set; }


        [Required(ErrorMessage = "Movie Cinema is Required")]
        [Display(Name = "Select Movie Cinema")]
        public int CinemaId { get; set; }


        [Required(ErrorMessage = "Movie Producer is Required")]
        [Display(Name = "Select Movie Producer")]
        public int ProducerId { get; set; }
     
    }
}
