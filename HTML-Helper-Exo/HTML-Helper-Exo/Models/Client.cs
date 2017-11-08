using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTML_Helper_Exo.Models
{
    public class Client
    {
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="L'email n'est pas valide")]
        [Required(ErrorMessage= "{0} est requit")]
        [Remote("validmail","home")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "L'addresse {0} est requis")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le {0} est requis")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le {0} est requis")]
        [DataType(DataType.Date)]
        public string DateNaissance { get; set; }
    }
}