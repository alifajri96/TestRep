using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model
{
    public class CreateAtGroup
    {
        //internal int kategoriCount;

        [DataType(DataType.Date)]
        public DateTime? CreateAt { get; set; }

        public int ArtikelCount { get; set; }
        public int kategoriCount { get; set; }
    }
}
