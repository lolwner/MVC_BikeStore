using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeEntities
{
    public class Good : BaseEntity
    {
        [Required]
        public string ManufacturerId { get; set; }

        [Required]
        public string TypeId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
