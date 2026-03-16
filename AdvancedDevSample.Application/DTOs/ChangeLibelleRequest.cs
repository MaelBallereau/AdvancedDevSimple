using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.DTOs
{
    public class ChangeLibelleRequest
    {
        [Required]
        public string NewLibelle {  get; set; }

    }
}
