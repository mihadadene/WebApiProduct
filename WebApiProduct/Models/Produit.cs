using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProduct.Models
{
    public class Produit
    {
        [Key]
        public int IdProd { get; set; }
        [Required]
        public string NomProd { get; set; }
        [Required]
        public int QtyProd { get; set; }
        [Required]
        public double PrixProd { get; set; }
        //public bool isComplete { get; set; }
    }
}
