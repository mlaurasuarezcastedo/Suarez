using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace suarez.Models
{
    public enum placeType
    {
        micasa,
        ventura,
        lasbrisas,
        burtown,
        laplaza
    }
    public class Suarez
    {
        [Key]
        public int suarezID { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(24,MinimumLength =2)]
        public string Friendofsuarez { get; set; }

        [Required]
        public placeType Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Cumpleanos")]
        [DisplayFormat(DataFormatString ="{0:dd,MM,yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

    }
}