using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlarWinForms._1_Entities
{
    [Table("vwOyunRapor")]
    public class vwOyunRapor
    {
        [Key]
        public int OyunId { get; set; }
        public int Id { get; set; }
        public string Adi { get; set; }
        public double?  Kazanci { get; set; }
        public double? Maliyeti { get; set; }
        public int YilId { get; set; }
        public int? TurId { get; set; }
        public string TurAdi { get; set; }
    }
}
