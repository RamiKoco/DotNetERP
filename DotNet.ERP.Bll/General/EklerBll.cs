using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.Bll.General
{
    public class EklerBll : BaseHareketBll<Ekler, ERPContext>, IBaseHareketSelectBll<Ekler>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<Ekler, bool>> filter)
        {
            return List(filter, x => new EklerL
            {
                Id = x.Id,
                KayitTuru = x.KayitTuru,
                KayitId = x.KayitId,            
                Baslik = x.Baslik,
                DosyaYolu = x.DosyaYolu,
                DosyaAdi = x.DosyaAdi,
                DosyaUzantisi = x.DosyaUzantisi,
                DosyaBoyutu = x.DosyaBoyutu,
                BelgeTuruId = x.BelgeTuruId,
                BelgeAdi = x.BelgeTuru.Ad,
                EklemeTarihi = x.EklemeTarihi,
                EkleyenKullaniciId = x.EkleyenKullaniciId,
                EkleyenKullaniciAdi =
                x.EkleyenKullanici != null
                    ? x.EkleyenKullanici.Adi + " " + x.EkleyenKullanici.Soyadi
                    : string.Empty,
                Aciklama = x.Aciklama,
            }).ToList();
        }
        public override bool Insert(IList<BaseHareketEntity> entities)
        {
            var kokDizin = new EklerDepolamaAyarlariBll().GetKokDizin();
            if (string.IsNullOrEmpty(kokDizin))
                return false;

            foreach (var baseEntity in entities)
            {
                var entity = baseEntity as EklerL;
                if (entity == null)
                    continue;

                if (string.IsNullOrEmpty(entity.YeniDosyaTempYolu))
                    continue;

                string ekKlasor = $"EK{(byte)entity.KayitTuru}";
                string klasor = Path.Combine(
                    kokDizin,
                    ekKlasor,
                    entity.KayitId.ToString());

                Directory.CreateDirectory(klasor);

                string hedefYol = Path.Combine(klasor, entity.DosyaAdi);

                try
                {
                    File.Copy(entity.YeniDosyaTempYolu, hedefYol, true);

                    entity.DosyaYolu = Path.Combine(
                        ekKlasor,
                        entity.KayitId.ToString(),
                        entity.DosyaAdi);

                    File.Delete(entity.YeniDosyaTempYolu);
                    entity.YeniDosyaTempYolu = null;
                }
                catch
                {
                    return false;
                }
            }

            return base.Insert(entities);
        }
        public override bool Update(IList<BaseHareketEntity> entities)
        {
            // 1️⃣ Önce fiziksel dosya işlemleri
            foreach (var baseEntity in entities)
            {
                var entity = baseEntity as EklerL;
                if (entity == null)
                    continue;

                if (string.IsNullOrEmpty(entity.YeniDosyaTempYolu))
                    continue;

                var kokDizin = new EklerDepolamaAyarlariBll().GetKokDizin();
                if (string.IsNullOrEmpty(kokDizin))
                    return false;

                string eskiFizikselYol = Path.Combine(kokDizin, entity.DosyaYolu);
                string klasor = Path.GetDirectoryName(eskiFizikselYol);
                string yeniFizikselYol = Path.Combine(klasor, entity.DosyaAdi);

                try
                {
                    if (File.Exists(eskiFizikselYol))
                        File.Delete(eskiFizikselYol);

                    File.Copy(entity.YeniDosyaTempYolu, yeniFizikselYol, true);

                    entity.DosyaYolu = Path.Combine(
                        Path.GetDirectoryName(entity.DosyaYolu),
                        entity.DosyaAdi);

                    File.Delete(entity.YeniDosyaTempYolu);
                    entity.YeniDosyaTempYolu = null;
                }
                catch
                {
                    return false;
                }
            }

            // 2️⃣ DB update (BASE'E BIRAK)
            return base.Update(entities);
        }       
        public override bool Delete(IList<BaseHareketEntity> entities)
        {
            foreach (var baseEntity in entities)
            {
                var entity = baseEntity as EklerL;
                if (entity == null)
                    continue;

                var kokDizin = new EklerDepolamaAyarlariBll().GetKokDizin();
                if (string.IsNullOrEmpty(kokDizin))
                    return false;

                string fizikselYol = Path.Combine(kokDizin, entity.DosyaYolu);

                if (File.Exists(fizikselYol))
                    File.Delete(fizikselYol);
            }          
            return base.Delete(entities);
        }
    }
}