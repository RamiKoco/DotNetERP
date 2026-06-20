using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DotNet.ERP.Model.Dto;

namespace DotNet.ERP.Bll.General
{
    public class KullaniciBll : BaseGenelBll<Kullanici>, IBaseGenelBll, IBaseCommonBll
    {
        public KullaniciBll() : base(KartTuru.Kullanici) { }
        public KullaniciBll(Control ctrl) : base(ctrl, KartTuru.Kullanici) { }

        public override BaseEntity Single(Expression<Func<Kullanici, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciS
            {
                Id = x.Id,
                Kod = x.Kod,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Email = x.Email,
                RolId = x.RolId,
                RolAdi = x.Rol.RolAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public BaseEntity SingleDetail(Expression<Func<Kullanici, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciS
            {
                Id = x.Id,
                Kod = x.Kod,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Email = x.Email,
                RolId = x.RolId,
                RolAdi = x.Rol.RolAdi,
                Sifre = x.Sifre,
                GizliKelime = x.GizliKelime,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Kullanici, bool>> filter)
        {
            return BaseList(filter, x => new KullaniciL
            {
                Id = x.Id,
                Kod = x.Kod,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Email = x.Email,
                RolAdi = x.Rol.RolAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}