using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Data.Entities
{
    public class Patient
    {
        [Key]

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }

        public string? MedicalConditions  { get; set; }

        public string? Email { get;set; }

        public string? Contact { get; set; }
        public string? Note { get; set; }
        public string? Symptoms { get; set; }
        public int AddressId { get; set; } 
        [ForeignKey("AddressId")]

        // Navigation property to PatientAddress
        public PatientAddress?PatientAddress { get; set; }

    }
}
