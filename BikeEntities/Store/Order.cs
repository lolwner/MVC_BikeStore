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
        public string List_ID { get; set; }

        [Required]
        public string Client_ID { get; set; }

        [Required]
        public double Summary { get; set; }
    }
}
