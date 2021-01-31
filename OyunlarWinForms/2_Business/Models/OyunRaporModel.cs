using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlarWinForms._2_Business.Models
{
    public class OyunRaporModel
    {
        public int Id { get; set; }

        [DisplayName("Oyun Adı")]
        public string Adi { get; set; }

        [DisplayName("Oyun Maliyeti")]
        public double? Maliyeti { get; set; }

        [DisplayName("Oyun Kazanci")]
        public double? Kazanci { get; set; }

        [DisplayName("Oyun Yılı")]
        public int YilId { get; set; }

        [DisplayName("Oyun Türü")]
        public string TurAdi { get; set; }

        public int? TurId { get; set; }
    }
}
