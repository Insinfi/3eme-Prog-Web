using MultiLangue.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultiLangue.Models
{
    public class Personne
    {
        [Display(Name="Nom", ResourceType = typeof(Resource))]
        public String Nom { get; set; }
    }
}