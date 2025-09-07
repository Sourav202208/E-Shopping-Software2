using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Data.Entities
{
    public class PatientAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Pincode { get; set; }

        // Relationship with the Patient model
     
        public Patient? Patient { get; set; }
        
 
        

    }
}
