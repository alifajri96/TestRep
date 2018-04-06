using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    public class Kategori
    {
        [Key]
        public int ID { get; set; }
        public string Nama { get; set; }        
    }
}
