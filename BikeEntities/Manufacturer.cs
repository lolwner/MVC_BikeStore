﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeEntities
{
    public class Manufacturer
    {
        [Key]
        public int Manufacturer_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}