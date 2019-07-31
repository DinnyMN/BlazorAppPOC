using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProductApp.Client.Common
{
    public class SoftwareProductForm
    {
        [Required]
        public string Version { get; set; }
    }
}
