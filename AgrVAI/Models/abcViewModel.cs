using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgrVAI.Models
{
    public class abcViewModel
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public string Vendedor { get; set; }
        public string Valor { get; set; }
    }
}