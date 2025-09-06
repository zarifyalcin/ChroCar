using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroCar.Models
{
    [Table("Brands", Schema = "ChroCar")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}