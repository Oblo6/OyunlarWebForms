using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OyunlarWebForms.BaBusiness
{
    /// <summary>
    /// Entity ve modeller üzerinden listeleme, detay, ekleme, güncelleme ve silme işlerimlerini gerçekleştirdiğimiz sınıf
    /// </summary>
    public class TurService
    {
        private OyunlarContext db = new OyunlarContext();
        /// <summary>
        /// Entity listesini modele dönüştürerek geri dönen Listeleme methodu
        /// </summary>
        /// <returns></returns>
        public List<TurModel> GetList()
        {
            return db.Tur.Select(tur => new TurModel()
            {
                Id= tur.Id,
                Adi = tur.Adi
            }).ToList();
        }

        /// <summary>
        /// Herhangi bir id'ye sahip tek bir entity'i modele donusturerek geri donen detay methodu
        /// </summary>
        /// <returns></returns>
        public TurModel GetByID(int id)
        {
            var entity = db.Tur.SingleOrDefault(tur => tur.Id == id);
            return new TurModel()
            {
                Id = entity.Id,
                Adi = entity.Adi
            };
        }

        /// <summary>
        /// Model üzerinden veritabanına modele göre yeni kayıt ekleyen method
        /// </summary>
        /// <param name="model"></param>
        public int Add(TurModel model)
        {
            // 1. yöntem:
            Tur entity;
            entity = db.Tur.SingleOrDefault(tur => tur.Adi.ToUpper() == model.Adi.ToUpper().Trim());
            if (entity != null)
            {
                return 1;
            }
            // 2. yöntem;
            if (db.Tur.Any(tur => tur.Adi.ToUpper() == model.Adi.ToUpper().Trim()))
            {
                return 1;
            }

            entity = new Tur()
            {
                Adi = model.Adi
            };
            db.Tur.Add(entity);
            db.SaveChanges();
            return 0;
        }

        /// <summary>
        /// Modeldeki id üzerinden veritabanındaki bir kaydı önce veritabanından getirerek daha sonra modele göre güncelleyen method
        /// </summary>
        /// <param name="model"></param>
        public bool Update(TurModel model)
        {
            if (db.Tur.Any(tur => tur.Adi.ToUpper() == model.Adi.ToUpper().Trim() && tur.Id != model.Id))
            {
                return false;
            }
            var entity = db.Tur.Find(model.Id);
            entity.Adi = model.Adi;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// id üzerinden veritabanıbdaki bir kaydı önce veritabanından getirerek daha sonra silen method
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var turEntity = db.Tur.FirstOrDefault(tur => tur.Id == id);
            List<OyunTur> oyunTurleriEntity = turEntity.OyunTur.ToList();
            if (oyunTurleriEntity != null && oyunTurleriEntity.Count > 0)
            {
                //1. kötü yöntem:
                //foreach (var oyunTurEntity in oyunTurleriEntity)
                //{
                //    db.OyunTur.Remove(oyunTurEntity);
                //    //db.SaveChanges();
                //}
                //2. iyi yöntem:
                db.OyunTur.RemoveRange(oyunTurleriEntity);
            }
            db.Tur.Remove(turEntity);
            db.SaveChanges();
        }
    }
}