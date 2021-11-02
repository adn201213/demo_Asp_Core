using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo.DAL.entities
{

    [Table("Employee")]
    public class Employee
    {
      [Key] 
        public int id { get; set; }


        [StringLength(30)]
        [Required]
        public string firstName { get; set; }


        [StringLength(30)]
        [Required]
        public string lastName { get; set; }

        public double salary { get; set; }

    }
}
