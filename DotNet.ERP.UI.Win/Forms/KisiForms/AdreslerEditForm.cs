using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Globalization;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class AdreslerEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _kisiId;
        private readonly string _kisiAdi;
        private readonly string _kisiSoyadi;
        private long? _anaKayitId;
        private long? _kayitId;
        #endregion
        //public AdreslerEditForm(params object[] prm)
        //{
        //    InitializeComponent();
        //    _kisiId = (long)prm[0];
        //    _kisiAdi = prm[1].ToString();
        //    _kisiSoyadi = prm[2].ToString();

        //    DataLayoutControl = myDataLayoutControl;
        //    Bll = new AdreslerBll(myDataLayoutControl);
        //    txtAdresTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTipi>());
        //    BaseKartTuru = KartTuru.Adresler;
        //    EventsLoad();
        //}
        public AdreslerEditForm(params object[] prm)
        {
            InitializeComponent();

            if (prm != null)
            {
                if (prm.Length > 0 && prm[0] != null)
                    _kisiId = Convert.ToInt64(prm[0]);

                if (prm.Length > 1 && prm[1] != null)
                    _kisiAdi = prm[1].ToString();

                if (prm.Length > 2 && prm[2] != null)
                    _kisiSoyadi = prm[2].ToString();

            }

            OrtakKurulum();
        }
        public AdreslerEditForm(long kisiId)
        {
            InitializeComponent();

            _kisiId = kisiId;

            OrtakKurulum();
        }
        private void OrtakKurulum()
        {
            // 🔧 BASE FORM AYARLARI
            DataLayoutControl = myDataLayoutControl;
            Bll = new AdreslerBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni };
            txtAdresTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTipi>());
            BaseKartTuru = KartTuru.Adresler;
            EventsLoad();

            // 🧾 FORM BAŞLIĞI
            var adSoyad = $"{_kisiAdi} {_kisiSoyadi}".Trim();

            if (!string.IsNullOrWhiteSpace(adSoyad))
            {
                Text += $" - ( {adSoyad} )";
            }
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new AdreslerS() : ((AdreslerBll)Bll).Single(Functions.FilterFunctions.Filter<Adresler>(Id));
            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                var old = (AdreslerS)OldEntity;
                if (_kayitId == null)
                    _kayitId = old.KayitId;
                if (_anaKayitId == null)
                    _anaKayitId = old.AnaKayitId;
            }
            NesneyiKontrollereBagla();           
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((AdreslerBll)Bll).YeniKodVer(x => x.KayitId == _kisiId);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (AdreslerS)OldEntity;
            txtKod.Text = entity.Kod;
            entity.KayitTuru = KayitTuru.Kisi;
            txtBaslik.Text = entity.Baslik;
            txtAdresNotu.Text = entity.AdresNotu;
            txtAdresTipi.SelectedItem = entity.AdresTipi.ToName();
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAdresTurleri.Id = entity.AdresTurleriId;
            txtAdresTurleri.Text = entity.AdresTurleriAdi;
            txtPostaKodu.Text = entity.PostaKodu;
            txtAdres.Text = entity.Adres;
            txtAdres.Properties.NullValuePrompt = "Açık adresinizi (semt, mahalle, sokak, no, daire) buraya yazınız…";
            txtAdres.Properties.NullValuePromptShowForEmptyValue = true;
            txtEnlem.Text = (entity.Enlem ?? 0m).ToString("F6", CultureInfo.InvariantCulture);
            txtBoylam.Text = (entity.Boylam ?? 0m).ToString("F6", CultureInfo.InvariantCulture);
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            _kayitId = entity.KayitId;
            _anaKayitId = entity.AnaKayitId;
        }
        protected override void GuncelNesneOlustur()
        {         

            decimal? enlem = null;
            if (!string.IsNullOrWhiteSpace(txtEnlem.Text))
                enlem = Math.Round(decimal.Parse(txtEnlem.Text, CultureInfo.InvariantCulture), 6);

            decimal? boylam = null;
            if (!string.IsNullOrWhiteSpace(txtBoylam.Text))
                boylam = Math.Round(decimal.Parse(txtBoylam.Text, CultureInfo.InvariantCulture), 6);

            CurrentEntity = new Adresler
            {
                Id = Id,
                Kod = txtKod.Text,
                KayitTuru = KayitTuru.Kisi,
                Baslik = txtBaslik.Text,
                AdresNotu = txtAdresNotu.Text,
                AdresTipi = txtAdresTipi.Text.GetEnum<AdresTipi>(),
                UlkeId = txtUlke.Id,
                IlId = txtIl.Id,
                IlceId = txtIlce.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                AdresTurleriId = txtAdresTurleri.Id,
                PostaKodu = txtPostaKodu.Text,
                Adres = txtAdres.Text,              
                Enlem = enlem,
                Boylam = boylam,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
                KisiId = BaseIslemTuru == IslemTuru.EntityInsert ? _kisiId : ((AdreslerS)OldEntity).KisiId,
                AnaKayitId = BaseIslemTuru == IslemTuru.EntityInsert ? _kisiId : ((AdreslerS)OldEntity).KisiId,
                KayitId = BaseIslemTuru == IslemTuru.EntityInsert ? _kisiId : ((AdreslerS)OldEntity).KisiId,
                KayitHesabiAdi = ((AdreslerS)OldEntity).KayitHesabiAdi,
                AnaKayitHesabiAdi = null
            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((AdreslerBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KayitId == _kisiId);  
        }       
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;

            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtUlke)
                    sec.Sec(txtUlke);
                else if (sender == txtIl)
                    sec.Sec(txtIl);
                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.AdresBilgileri);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.AdresBilgileri);
                else if (sender == txtAdresTurleri)
                    sec.Sec(txtAdresTurleri, KartTuru.AdresTurleri);

        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
        }
    }
}