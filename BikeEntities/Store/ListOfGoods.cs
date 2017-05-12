using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeEntities
{
    public class ListOfGoods : BaseEntity
    {
        [Required]
        public string Order_ID { get; set; }

        [Required]
        public string Good_ID { get; set; }

        [Required]
        public string Amount { get; set; }
    }
}
