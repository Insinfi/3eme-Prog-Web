using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class FullUser
    {
        public string UserID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string mail { get; set; }
        public string Tel { get; set; }
        public string GSM { get; set; }
        public string NomDeRue { get; set; }
        public string NumeroDeMaison { get; set; }
        public string CodePostal { get; set; }
        public string Localite { get; set; }
        public string Photo { get; set; }
    }
}