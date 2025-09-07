using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Description { get; set; }
        public bool? IsFullDay { get; set; }
        public bool IsActive { get; set; }
      

    }
}
