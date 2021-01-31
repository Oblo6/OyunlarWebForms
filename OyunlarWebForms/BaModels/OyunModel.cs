using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OyunlarWebForms.BaModels
{
    /// <summary>
    /// Sayfalarda kullanılmak üzere hem entitiy'den hem de kendi ihtiyacımız olan özellikleri içeren sınıf
    /// </summary>
    public class OyunModel
    {
        #region Entity'de bulunan ve veritabanı sütunlarına karsılık gelen özellikler
        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public int Id { get; set; }
        public string Adi { get; set; }
        //public Nullable<double> Maliyeti { get; set; }
        public double? Maliyeti { get; set; }
        //public Nullable<double> Kazanci { get; set; }
        public double? Kazanci { get; set; }
        public int YilId { get; set; }
        #endregion

        
        #region Entity ile ilişkili entityler için eklediğimiz özellikler
        public List<int> TurIdleri { get; set; }
        //public List<string> TurAdlari { get; set; }

        public string TurAdlari { get; set; }
        #endregion

        #region Kendi ihtiyacımız icin ekledigimiz ozellikler
        /// <summary>
        /// Sayfalarda kullanılmak üzere kendi ihtiyacım olan özellik
        /// </summary>
        public string YilDegeri { get; set; }

        /// <summary>
        /// Sayfalarda kullanılmak üzere kendi ihtiyacım olan özellik
        /// </summary>
        public string KarZarar { get; set; }
        #endregion
    }
}