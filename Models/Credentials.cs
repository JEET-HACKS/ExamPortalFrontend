using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examportal.Models
{
    public class Credentials
    {
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public string pswd { get; set; }
        public string Role { get; set; }
        [Key]
        public Guid unqid { get; set; }
        

    }
}