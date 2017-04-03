using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models.Store
{
    public class Type
    {
        [Key]
        public int Type_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}