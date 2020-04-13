using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgrVAI.Models
{
    public class Usuario
    {
        public int Id{ get; set; }
        [Required]
        public string User{ get; set; }
        [Required]
        public string Senha{ get; set; }
    }
}