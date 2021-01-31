using OyunlarWinForms._1_Entities;
using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OyunlarWinForms._2_Business.Services
{
    public class TurService
    {
        private OyunlarDB db = new OyunlarDB();

        public List<TurModel> GetList()
        {
            try
            {
                return db.Tur.OrderBy(t => t.Adi).Select(t => new TurModel()
                {
                    Id = t.Id,
                    Adi = t.Adi
                }).ToList();
            }
            catch (System.Exception)
            {
                return null;
                //throw e;
            }
        }

        public TurModel GetByID(int id)
        {
            try
            {
                var entity = db.Tur.Find(id);
                return new TurModel()
                {
                    Id = entity.Id,
                    Adi = entity.Adi
                };
            }
            catch (System.Exception)
            {
                return null;
                //throw e;
            }
        }

        public Islem Add(TurModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Tur.Any(t => t.Adi.ToUpper() == model.Adi.ToUpper().Trim()))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = new Tur()
                {
                    Adi = model.Adi.Trim()
                };
                db.Tur.Add(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                return Islem.Hata;
                //throw e;
            }
        }

        public Islem Update(TurModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Tur.Any(t => t.Adi.ToUpper() == model.Adi.ToUpper().Trim() && t.Id != model.Id))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = db.Tur.Find(model.Id);
                entity.Adi = model.Adi.Trim();
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception)
            {
                return Islem.Hata;
                //throw e;
            }
        }

        public Islem Delete(int id)
        {
            try
            {
                var entity = db.Tur.Find(id);
                db.OyunTur.RemoveRange(entity.OyunTur);
                db.Tur.Remove(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception)
            {
                return Islem.Hata;
                //throw e;
            }
        }
    }
}
