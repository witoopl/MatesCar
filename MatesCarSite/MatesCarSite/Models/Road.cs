using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Road
    {
        public string Id { get; set; }
        public float Distance { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
