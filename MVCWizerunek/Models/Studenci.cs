using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCWizerunek.Models
{
    public class Studenci
    {
         public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime data_urodzenia { get; set; }
        public char plec { get; set; }
        
        public string miasto { get; set; }
        public int liczba_dzieci { get; set; }

    }
    

}
