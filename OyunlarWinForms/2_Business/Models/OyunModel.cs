using System.Collections.Generic;
using System.ComponentModel;

namespace OyunlarWinForms._2_Business.Models
{
    public class OyunModel
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


        [DisplayName("Oyun Kar/Zarar")]
        public string KarZarar { get; set; }



        //public List<string> TurAdlari { get; set; }
        //public List<int> TurIdleri { get; set; }
        public List<TurModel> Turler { get; set; }
    }
}
