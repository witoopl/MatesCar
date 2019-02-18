using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Friend
    {
        [Key]
        public string Id { get; set; }
        public string User { get; set; }
        public string UserFriend { get; set; }
    }
}
