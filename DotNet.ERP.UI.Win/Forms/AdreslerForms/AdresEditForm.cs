using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Linq.Expressions;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.AdreslerForms
{
    public partial class AdresEditForm : BaseEditForm
    {
        private long? _anaKayitId;
        private long? _kayitId;
        private readonly KayitTuru _kayitTuru;
        public AdresEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new AdreslerBll(myDataLayoutControl);
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
            txtAdresTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTipi>());
            BaseKartTuru = KartTuru.Adresler;
            txtKayitTuru.SelectedIndexChanged += (s, e) =>
            {
                txtKayitHesabi.Id = 0;
                txtKayitHesabi.Text = "";
            };
            EventsLoad();
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
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            Expression<Func<Adresler, bool>> filter = null;

            switch (_kayitTuru)
            {
                case KayitTuru.Kisi:
                    filter = x => x.KisiId == _anaKayitId;
                    break;
                case KayitTuru.Personel:
                    filter = x => x.PersonelId == _anaKayitId;
                    break;
             
                case KayitTuru.Cari:
                    filter = x => x.CariId == _anaKayitId;
                    break;
                case KayitTuru.CariSube:
                    filter = x => x.CariSubeId == _anaKayitId;
                    break;
            }

            txtKod.Text = ((AdreslerBll)Bll).YeniKodVer(filter);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (AdreslerS)OldEntity;
            txtKayitTuru.SelectedIndexChanged -= txtKayitTuru_SelectedIndexChanged;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtAdresNotu.Text = entity.AdresNotu;
            txtAdresTipi.SelectedItem = entity.AdresTipi.ToName();

            txtKayitTuru.SelectedItem = entity.KayitTuru.ToName();
            if (entity.KayitTuru == KayitTuru.Kisi)
                txtKayitHesabi.Id = entity.KisiId ?? null;
            else if (entity.KayitTuru == KayitTuru.Personel)
                txtKayitHesabi.Id = entity.PersonelId ?? null;
            else if (entity.KayitTuru == KayitTuru.Cari)
                txtKayitHesabi.Id = entity.CariId ?? null;
            else if (entity.KayitTuru == KayitTuru.CariSube)
                txtCariSube.Id = entity.CariSubeId ?? null;
            else
                txtKayitHesabi.Id = null;

            if (entity.KayitTuru == KayitTuru.CariSube)
            {
                txtKayitHesabi.Id = entity.CariId;
                txtKayitHesabi.Text = entity.KayitHesabiAdi;
                txtCariSube.Id = entity.CariSubeId;
                txtCariSube.Text = entity.AnaKayitHesabiAdi;
            }
            else
            {

                txtKayitHesabi.Id =
                   entity.KayitTuru == KayitTuru.Kisi ? entity.KisiId :
                   entity.KayitTuru == KayitTuru.Personel ? entity.PersonelId :
                   entity.KayitTuru == KayitTuru.Cari ? entity.CariId :
                   (long?)null;
                txtKayitHesabi.Text = entity.KayitHesabiAdi;
            }
            txtKayitHesabi.Text = entity.KayitHesabiAdi;
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
            _kayitId = entity.KayitId != null ? entity.KayitId : txtKayitHesabi.Id;
            _anaKayitId = entity.AnaKayitId != null ? entity.AnaKayitId : txtKayitHesabi.Id;
            txtKayitTuru.SelectedIndexChanged += txtKayitTuru_SelectedIndexChanged;
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {
            decimal? enlem = null;
            if (!string.IsNullOrWhiteSpace(txtEnlem.Text))
                enlem = Math.Round(decimal.Parse(txtEnlem.Text, CultureInfo.InvariantCulture), 6);

            decimal? boylam = null;
            if (!string.IsNullOrWhiteSpace(txtBoylam.Text))
                boylam = Math.Round(decimal.Parse(txtBoylam.Text, CultureInfo.InvariantCulture), 6);

            var kayitTuru = txtKayitTuru.SelectedItem?.ToString().GetEnum<KayitTuru>() ?? KayitTuru.Kisi;
            var kisiId = kayitTuru == KayitTuru.Kisi
             ? (txtKayitHesabi.Id == 0 ? null : txtKayitHesabi.Id)
             : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;
            var carilerId = kayitTuru == KayitTuru.Cari ? txtKayitHesabi.Id : null;
            var cariSubeId = kayitTuru == KayitTuru.CariSube ? txtCariSube.Id : null;
            long? anaKayitId = null;
            long? kayitId = null;

            var eskiEntity = OldEntity as AdreslerS;

            if (kayitTuru == KayitTuru.CariSube)
            {
                var yeniKayitId = txtCariSube.Id != 0 ? txtCariSube.Id : null;
                var yeniAnaKayitId = txtKayitHesabi.Id != 0 ? txtKayitHesabi.Id : null;
                kayitId = yeniKayitId ?? _kayitId;
                anaKayitId = yeniAnaKayitId ?? _anaKayitId;

                if ((anaKayitId == null || anaKayitId == kayitId) && _anaKayitId != null)
                    anaKayitId = _anaKayitId;

                if (anaKayitId == null && txtKayitHesabi.Id != 0)
                    anaKayitId = txtKayitHesabi.Id;
            }

            else if (kayitTuru == KayitTuru.Kisi ||
                     kayitTuru == KayitTuru.Personel ||
                     kayitTuru == KayitTuru.Cari)
            {
                kayitId = txtKayitHesabi.Id != 0 ? txtKayitHesabi.Id : _kayitId;
                anaKayitId = (_anaKayitId != null && _anaKayitId != 0)
                    ? _anaKayitId
                    : kayitId;
            }

            else
            {
                kayitId = _kayitId ?? txtKayitHesabi.Id;
                anaKayitId = _anaKayitId ?? kayitId;
            }

            if (kayitId == 0) kayitId = null;
            if (anaKayitId == 0) anaKayitId = null;

            CurrentEntity = new Adresler
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                AdresNotu = txtAdresNotu.Text,            
                AdresTipi = txtAdresTipi.Text.GetEnum<AdresTipi>(),
                KayitTuru = kayitTuru,
                KisiId = kisiId,
                PersonelId = personelId,
                CariId = carilerId,
                CariSubeId = cariSubeId,
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
                AnaKayitId = anaKayitId,
                KayitId = kayitId,
                KayitHesabiAdi = txtKayitHesabi.Text,
                AnaKayitHesabiAdi = kayitTuru == KayitTuru.CariSube ? txtCariSube.Text : null
            };
            ButonEnabledDurumu();
        }
        private void txtKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKayitHesabi.Id = 0;
            txtKayitHesabi.Text = string.Empty;
            var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
            txtCariSube.Enabled = kayitTuru == KayitTuru.CariSube;
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
                else if (sender == txtKayitHesabi)
                {
                    var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();

                    if (kayitTuru == KayitTuru.Kisi)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Kisi);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.Personel)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Personel);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.Cari)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Cari);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.CariSube)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Cari);

                        if (txtKayitHesabi.Id == null || txtKayitHesabi.Id == 0)
                        {
                            Messages.UyariMesaji("Cari seçilmeden şube seçimi yapılamaz.");
                            return;
                        }

                        txtKayitHesabi.ControlEnabledChange(txtCariSube);
                        sec.Sec(txtCariSube, txtKayitHesabi);

                        _anaKayitId = txtKayitHesabi.Id; // Ana cari
                        _kayitId = txtCariSube.Id;       // Şube
                    }               
                    else
                    {
                        sec.Sec(txtKayitHesabi);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                }
                else if (sender == txtCariSube)
                    sec.Sec(txtCariSube, txtKayitHesabi);
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
            if (sender != txtKayitHesabi)
                return;
            else if (sender == txtKayitHesabi)
            {
                var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
                if (kayitTuru == KayitTuru.CariSube)
                    txtKayitHesabi.ControlEnabledChange(txtCariSube);
            }
        }   
    }
}