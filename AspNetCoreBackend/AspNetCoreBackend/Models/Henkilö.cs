using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBackend.Models
{
    public class Henkilö
    {
        public string Nimi { get; set; }

        public string Osoite { get; set; }

        public int Ikä { get; set; }
    }
}
