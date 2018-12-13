using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite
{

    /// <summary>
    /// Our Settigs database table representational mnodel
    /// </summary>
    public class SettingsDataModel
    {

        [Key]
        public string Id { get; set; }
        
        /// <summary>
        /// The settings name
        /// </summary>
        /// <remarks>This columnt is indexed</remarks>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Value { get; set; }
    }
}
