using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClassModel.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string WebSite{ get; set; }
    }
}
