using OyunlarWinForms._1_Entities;
using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace OyunlarWinForms._2_Business.Services
{
    public class OyunService
    {
        private OyunlarDB db = new OyunlarDB();

        public List<OyunModel> GetList()
        {
            try
            {
                // SQL Ortamı
                /*
                select Oyun.Adi, Oyun.Id, Oyun.Kazanci, Oyun.Maliyeti, Oyun.YilId, 
                Tur.Id, Tur.Adi
                from Oyun 
                left outer join OyunTur on Oyun.Id = OyunTur.OyunId
                left outer join Tur on OyunTur.TurId = Tur.Id
                order by Oyun.Adi
                */
                List<OyunModel> oyunlar = db.Oyun.OrderBy(o => o.Adi).Select(o => new OyunModel()
                {
                    Adi = o.Adi,
                    Id = o.Id,
                    Kazanci = o.Kazanci,
                    Maliyeti = o.Maliyeti,
                    YilId = o.YilId,
                    Turler = o.OyunTur.Select(ot => new TurModel()
                    {
                        Id = ot.Tur.Id, // ot.TurId
                        Adi = ot.Tur.Adi
                    }).ToList()
                }).ToList();

                // C# Ortamı
                oyunlar = oyunlar.Select(o => new OyunModel()
                {
                    Adi = o.Adi,
                    Id = o.Id,
                    Kazanci = o.Kazanci,
                    Maliyeti = o.Maliyeti,
                    YilId = o.YilId,
                    Turler = o.Turler,

                    KarZarar = ((o.Kazanci ?? 0) - (o.Maliyeti ?? 0)).ToString(new CultureInfo("tr")) + " TL"
                }).ToList();
                return oyunlar;
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }       

       
        public IQueryable<OyunRaporModel> GetQuery()
        {
            IQueryable<Oyun> oyunQuery = db.Oyun.AsQueryable();
            IQueryable<OyunTur> oyunTurQuery = db.OyunTur.AsQueryable();
            IQueryable<Tur> turQuery = db.Tur.AsQueryable();

            var query = from oyun in oyunQuery
                        join oyunTur in oyunTurQuery
                            on oyun.Id equals oyunTur.OyunId into oyun_oyunTur
                        from sub_oyun_oyunTur in oyun_oyunTur.DefaultIfEmpty()
                        join tur in turQuery
                            on sub_oyun_oyunTur.TurId equals tur.Id into oyun_oyunTur_tur
                        from sub_oyun_oyunTur_tur in oyun_oyunTur_tur.DefaultIfEmpty()
                        select new OyunRaporModel()
                        {
                            Id = oyun.Id,
                            Adi = oyun.Adi,
                            Kazanci = oyun.Kazanci,
                            Maliyeti = oyun.Maliyeti,
                            YilId = oyun.YilId,
                            TurAdi = sub_oyun_oyunTur_tur.Adi,
                            TurId = sub_oyun_oyunTur_tur.Id
                        };
            return query;
        }

        public IQueryable<OyunRaporModel> GetQueryFromView()
        {
            /*
            create view [dbo].[vwOyunRapor]
            as
            select isnull(row_number() over (order by Oyun.Id), 0) as OyunId,
            Oyun.Id, Oyun.Adi, Oyun.Kazanci, Oyun.Maliyeti, Oyun.YilId, 
            Tur.Id as TurId, Tur.Adi as TurAdi
            from Oyun 
            left outer join OyunTur on Oyun.Id = OyunTur.OyunId
            left outer join Tur on OyunTur.TurId = Tur.Id
            */

            IQueryable<vwOyunRapor> vwOyunRaporQuery = db.vwOyunRapor.AsQueryable();
            return vwOyunRaporQuery.Select(vw => new OyunRaporModel()
            {
                Id = vw.Id,
                Adi = vw.Adi,
                Kazanci = vw.Kazanci,
                Maliyeti = vw.Maliyeti,
                YilId = vw.YilId,
                TurAdi = vw.TurAdi,
                TurId = vw.TurId
            });
        }


        public OyunModel GetByID(int id)
        {
            try
            {
                var entity = db.Oyun.Find(id);
                return new OyunModel()
                {
                    Id = entity.Id,
                    Adi = entity.Adi,
                    Kazanci = entity.Kazanci,
                    Maliyeti = entity.Maliyeti,
                    YilId = entity.YilId,
                    Turler = entity.OyunTur.Select(ot => new TurModel()
                    {
                        Id = ot.TurId,
                        Adi = ot.Tur.Adi
                    }).ToList()
                };
            }
            catch (Exception e)
            {
                return null;
                //throw e;
            }
        }
             

        public Islem Add(OyunModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (model.YilId == -1)
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Oyun.Any(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim()))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = new Oyun()
                {
                    Adi = model.Adi.Trim(),
                    Kazanci = model.Kazanci,
                    Maliyeti = model.Maliyeti,
                    YilId = model.YilId,
                    OyunTur = model.Turler.Select(t => new OyunTur()
                    {
                        TurId = t.Id
                    }).ToList()
                };
                db.Oyun.Add(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                return Islem.Hata;
                //throw e;
            }
        }

        public Islem Update(OyunModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (model.YilId == -1)
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Oyun.Any(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim() && o.Id != model.Id))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = db.Oyun.Find(model.Id);
                entity.Adi = model.Adi.Trim();
                entity.Kazanci = model.Kazanci;
                entity.Maliyeti = model.Maliyeti;
                entity.YilId = model.YilId;
                db.OyunTur.RemoveRange(entity.OyunTur);
                entity.OyunTur = model.Turler.Select(t => new OyunTur()
                {
                    OyunId = entity.Id,
                    TurId = t.Id
                }).ToList();
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
                var entity = db.Oyun.Find(id);
                db.OyunTur.RemoveRange(entity.OyunTur);
                db.Oyun.Remove(entity);
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
