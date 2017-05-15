using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeEntities
{
    public class Order : BaseEntity
    {
        [Required]
        public string ListId { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public double Summary { get; set; }
    }
}
