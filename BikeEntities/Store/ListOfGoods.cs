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
        public string OrderId { get; set; }

        [Required]
        public string GoodId { get; set; }

        [Required]
        public string Amount { get; set; }
    }
}
