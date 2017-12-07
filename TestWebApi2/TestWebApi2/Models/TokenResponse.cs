using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi2.Models
{
    public class TokenResponse
    {
        public int Result { get; set; }
        public Guid Token { get; set; }
    }
}