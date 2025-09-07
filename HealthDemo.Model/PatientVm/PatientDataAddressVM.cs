using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Model.Model
{
    public class PatientDataAddressVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]

        public string? Name { get; set; }
        [Required(ErrorMessage ="Please Enter Your Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please choose Your Gender")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Please choose Your Medical Conditions")]
        public string? MedicalConditions { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
        public string? Contact { get; set; }
        public string? Symptoms { get; set; }
        public string? Note { get; set; }
        //public string? Problem { get; set; }
        public  int AddressId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your City")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Pincode")]
        
        public int Pincode { get; set; }

    }
}
