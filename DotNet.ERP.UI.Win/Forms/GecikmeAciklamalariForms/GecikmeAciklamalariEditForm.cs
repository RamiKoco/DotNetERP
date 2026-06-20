using System;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariEditForm : BaseEditForm
    {
        #region Variables

        private readonly int _portfoyNo;

        #endregion
        public GecikmeAciklamalariEditForm(params object[] prm)
        {
            InitializeComponent();

            _portfoyNo = (int)prm[0];
            DataLayoutControl = myDataLayoutControl;
            Bll = new GecikmeAciklamalariBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Aciklama;
            EventsLoad();

        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert
                ? new GecikmeAciklamalariS()
                : ((GecikmeAciklamalariBll)Bll).Single(Functions.FilterFunctions.Filter<GecikmeAciklamalari>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GecikmeAciklamalariBll)Bll).YeniKodVer(x => x.OdemeBilgileriId == _portfoyNo);
            txtAciklama.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (GecikmeAciklamalariS)OldEntity;

            txtKod.Text = entity.Kod;
            txtKullaniciAdi.Text = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciAdi : entity.KullaniciAdi;
            txtTarihSaat.DateTime = BaseIslemTuru == IslemTuru.EntityInsert ? DateTime.Now : entity.TarihSaat;
            txtAciklama.Text = entity.Aciklama;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new GecikmeAciklamalari
            {
                Id = Id,
                Kod = txtKod.Text,
                OdemeBilgileriId = _portfoyNo,
                KullaniciId = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciId : 0,
                TarihSaat = txtTarihSaat.DateTime,
                Aciklama = txtAciklama.Text,
            };

            ButonEnabledDurumu();

        }

        protected override bool EntityInsert()
        {
            return ((GecikmeAciklamalariBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }

        protected override bool EntityUpdate()
        {
            return ((GecikmeAciklamalariBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }
    }
}