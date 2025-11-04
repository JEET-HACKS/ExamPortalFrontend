using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examportal.Models
{
    public class FormDetails
    {
        public DateTime AcDate { get; set; } = DateTime.Now;
        public string Full_Name { get; set; }
        public string Father_Name { get; set; }
        public string Mother_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string MobileNo { get; set; }
        public string Course { get; set; }
        public string Exam_Type { get; set; }
        public string Semester { get; set; }
        public string Photo { get; set; }
        public string Idproof { get; set; }
        public string signature { get; set; }
        public string subjects { get; set; }

        public string Payment_Method { get; set; }
        public string Payment_Method_Id { get; set; }
        public decimal Amount { get; set; }
        public string caste { get; set; }
        public string Exam_Name { get; set; }


    }
}