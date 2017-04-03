using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models.Store
{
    public class ListOfGoods
    {
        [Key]
        public int List_ID { get; set; }

        [Required]
        public int Order_ID { get; set; }

        [Required]
        public int Good_ID { get; set; }

        [Required]
        public int Amount { get; set; }

    }
}