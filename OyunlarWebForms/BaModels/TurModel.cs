namespace OyunlarWebForms.BaModels
{
    /// <summary>
    /// Sayfalarda kullanılmak üzere hem entitiy'den hem de kendi ihtiyacımız olan özellikleri içeren sınıf
    /// </summary>
    public class TurModel
    {
        #region Entity'de bulunan ve veritabanı sütunlarına karsılık gelen özellikler
        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public string Adi { get; set; }
        #endregion
    }
}