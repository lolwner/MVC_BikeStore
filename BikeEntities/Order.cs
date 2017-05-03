using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeEntities
{
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }

        [Required]
        public int List_ID { get; set; }

        [Required]
        public int Client_ID { get; set; }

        [Required]
        public double Summary { get; set; }
    }
}
