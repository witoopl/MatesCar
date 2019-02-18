﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Debt
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string IdLoanHolder { get; set; }
        public string IdLoanDebtor { get; set; }
        [Required]
        public float Value { get; set; }
        public string RouteId { get; set; }
        


    }
}
