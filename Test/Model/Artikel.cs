using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Test.Model
{

    public class Artikel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[RegularExpression("[0-9]{3}")]
        public int Id { get; set; }
        [Required]
        [StringLength(6, ErrorMessage ="Judul tidak boleh lebih dari 6 karakter")]
        public string Judul { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create At")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "Nama Kategori")]
        public int ID_Kategori { get; set; }
        [ForeignKey("ID_Kategori")]
        public virtual Kategori Kategori{ get; set; }

        [Display(Name = "Image")]
        public string ImageName { get; set; }

    }
}
