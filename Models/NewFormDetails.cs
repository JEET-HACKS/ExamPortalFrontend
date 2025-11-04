using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examportal.Models
{
    public class NewFormDetails
    {

        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public DateTime LastDate { get; set; }
        public decimal FormFee { get; set; }
        public string Eligibility { get; set; }
        [Key]
        public Guid unqid { get; set; }

    }
}