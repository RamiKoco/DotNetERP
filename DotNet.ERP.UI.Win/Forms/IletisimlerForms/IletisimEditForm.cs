using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.IletisimlerForms
{
    public partial class IletisimEditForm : BaseEditForm
    {
        #region Variables
        private long? _anaKayitId;
        private long? _kayitId;
        private readonly KayitTuru _kayitTuru; 
        #endregion

        public IletisimEditForm()
        {
            InitializeComponent();
        
            DataLayoutControl = myDataLayoutControl;
            Bll = new IletisimBll(myDataLayoutControl);
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
            txtIletisimTurleri.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimTuru>());
            txtIzinDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());
            txtKanallar.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
                        .Cast<string>()
                        .Select(x => new CheckedListBoxItem(x))
                        .ToArray());
            BaseKartTuru = KartTuru.Iletisim;
            txtKayitTuru.SelectedIndexChanged += (s, e) =>
            {               
                txtKayitHesabi.Id = 0;
                txtKayitHesabi.Text = "";
            };
            txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
            tglVoip.EditValueChanged += tglVoip_EditValueChanged;
            EventsLoad();
        }      
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert
                ? new IletisimS()
                : ((IletisimBll)Bll).Single(Functions.FilterFunctions.Filter<Iletisim>(Id));
   
            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                var old = (IletisimS)OldEntity;
                if (_kayitId == null)
                    _kayitId = old.KayitId;
                if (_anaKayitId == null)
                    _anaKayitId = old.AnaKayitId;
            }
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            Expression<Func<Iletisim, bool>> filter = null;

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

            txtKod.Text = ((IletisimBll)Bll).YeniKodVer(filter);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IletisimS)OldEntity;
            var kayitTuru = entity.KayitTuru;

            txtKayitTuru.SelectedIndexChanged -= txtKayitTuru_SelectedIndexChanged;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtWeb.Text = entity.Web;
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
            txtIletisimTurleri.EditValue = entity.IletisimTuru.ToName();
            if (entity.IletisimTuru == IletisimTuru.EPosta)
            {
                txtKanallar.SetEditValue(entity.EPBool ? "E-Posta" : null);
            }
            else
            {
                txtKanallar.SetEditValue(entity.Kanallar);
            }
            txtIzinDurumu.SelectedItem = entity.IzinDurumu.ToName();
            txtIzinTarihi.EditValue = entity.IzinTarihi;
            txtOncelik.Value = entity.Oncelik;
            txtWeb.Text = entity.Web;
            txtUlkeKodu.Text = entity.UlkeKodu;
            txtTelefonVeFax.Text = entity.Numara;
            txtDahili.Text = entity.DahiliNo;
            txtEPosta.Text = entity.EPosta;
            txtKisi.Enabled = (kayitTuru == KayitTuru.Cari || kayitTuru == KayitTuru.CariSube);
            txtKisi.Id = entity.IlgiliKisiId;
            txtKisi.Text = entity.IlgiliKisiAdi;
            txtKullaniciAdi.Text = entity.KullaniciAdi;
            txtSIPKullaniciAdi.Text = entity.SIPKullaniciAdi;
            txtSIPServer.Text = entity.SIPServer;
            txtSosyalMedyaUrl.Text = entity.SosyalMedyaUrl;
            txtSosyalMedyaPlatformu.Id = entity.SosyalMedyaPlatformuId;
            txtSosyalMedyaPlatformu.Text = entity.SosyalMedyaPlatformuAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglVoip.IsOn = entity.VoipMi;
            tglDurum.IsOn = entity.Durum;
            _kayitId = entity.KayitId != null ? entity.KayitId : txtKayitHesabi.Id;
            _anaKayitId = entity.AnaKayitId != null ? entity.AnaKayitId : txtKayitHesabi.Id;
            txtKayitTuru.SelectedIndexChanged += txtKayitTuru_SelectedIndexChanged;
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {           
            var kayitTuru = txtKayitTuru.SelectedItem?.ToString().GetEnum<KayitTuru>() ?? KayitTuru.Kisi;
            var kisiId = kayitTuru == KayitTuru.Kisi
             ? (txtKayitHesabi.Id == 0 ? null : txtKayitHesabi.Id)
             : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;
            var cariId = kayitTuru == KayitTuru.Cari ? txtKayitHesabi.Id : null;
            var cariSubeId = kayitTuru == KayitTuru.CariSube ? txtCariSube.Id : null;
            long? anaKayitId = null;
            long? kayitId = null;

            var eskiEntity = OldEntity as IletisimS;


            var iletisimTuru = txtIletisimTurleri.Text.GetEnum<IletisimTuru>();
            bool kanallarKullanilacak =
              iletisimTuru == IletisimTuru.Telefon ||
              iletisimTuru == IletisimTuru.EPosta;

            var kanalListesi = (txtKanallar.EditValue?.ToString() ?? "")
                               .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => x.Trim())
                               .ToList();

            bool eskiArama = eskiEntity?.Arama ?? false;
            bool eskiSms = eskiEntity?.Sms ?? false;
            bool eskiWhatsapp = eskiEntity?.Whatsapp ?? false;
            bool eskiEposta = eskiEntity?.EPBool ?? false;

            bool yeniArama = false;
            bool yeniSms = false;
            bool yeniWhatsapp = false;
            bool yeniEposta = false;

            if (kanallarKullanilacak)
            {
                yeniArama = kanalListesi.Contains("Arama");
                yeniSms = kanalListesi.Contains("SMS");
                yeniWhatsapp = kanalListesi.Contains("Whatsapp");
                yeniEposta = kanalListesi.Contains("E-Posta");
            }

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
            if (kayitTuru == KayitTuru.Kisi
                || kayitTuru == KayitTuru.Personel
                || kayitTuru == KayitTuru.Cari)
            {
                anaKayitId = 0; // Veritabanına NULL gider
            }
            if (kayitId == 0) kayitId = null;
            //if (anaKayitId == 0) anaKayitId = null;

            CurrentEntity = new Iletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = kayitTuru,
                KisiId = kisiId,
                PersonelId = personelId,
                CariId = cariId,
                CariSubeId = cariSubeId,               
                IletisimTuru = txtIletisimTurleri.Text.GetEnum<IletisimTuru>(),
                IzinDurumu = txtIzinDurumu.Text.GetEnum<IletisimDurumu>(),
                Kanallar = kanallarKullanilacak
                            ? txtKanallar.EditValue?.ToString()
                            : null,
                Arama = yeniArama,
                Sms = yeniSms,
                Whatsapp = yeniWhatsapp,
                EPBool = yeniEposta,
                IzinTarihi = (DateTime?)txtIzinTarihi.EditValue,
                UlkeKodu = txtUlkeKodu.Text,
                Numara = txtTelefonVeFax.Text,
                DahiliNo = txtDahili.Text,
                EPosta = txtEPosta.Text,
                //Ilgili = txtIlgili.Text,
                IlgiliKisiId = txtKisi.Id,
                KullaniciAdi = txtKullaniciAdi.Text,
                SIPServer = txtSIPServer.Text,
                SIPKullaniciAdi = txtSIPKullaniciAdi.Text,
                SosyalMedyaUrl = txtSosyalMedyaUrl.Text,
                SosyalMedyaPlatformuId = txtSosyalMedyaPlatformu.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,           
                VoipMi = tglVoip.IsOn,
                Durum = tglDurum.IsOn,
                AnaKayitId = anaKayitId,
                KayitId = kayitId,
                KayitHesabiAdi = txtKayitHesabi.Text,
                AnaKayitHesabiAdi = kayitTuru == KayitTuru.CariSube ? txtCariSube.Text : null
            };    

            ButonEnabledDurumu();
        }       
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;       
            var tempOld = OldEntity as IletisimS;
            var tempCurrent = CurrentEntity as Iletisim;           
            base.ButonEnabledDurumu();

            if (txtIletisimTurleri.EditValue == null) return;
            IletisimTuru iletisimTuru;

            try
            {
                iletisimTuru = EnumFunctions.GetValueFromDescription<IletisimTuru>(txtIletisimTurleri.EditValue.ToString());
            }
            catch
            {
                return;
            }
        }   
        protected override bool EntityInsert()
        {
            return ((IletisimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        protected override bool EntityUpdate()
        {
            return ((IletisimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
            {
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Iletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Iletisim);
                else if (sender == txtSosyalMedyaPlatformu)
                    sec.Sec(txtSosyalMedyaPlatformu, KartTuru.SosyalMedyaPlatformu);
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
                else if (sender == txtKisi)
                    sec.Sec(txtKisi, KartTuru.Kisi);
            }
        }
        private void txtKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            layoutControlItem6.Visibility = LayoutVisibility.Never;            
            txtKayitHesabi.Id = 0;
            txtKayitHesabi.Text = string.Empty;
            var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
            txtCariSube.Enabled = kayitTuru == KayitTuru.CariSube;

            bool ilgiliGorunsun = (kayitTuru == KayitTuru.Cari || kayitTuru == KayitTuru.CariSube);
          
            txtKisi.Enabled = ilgiliGorunsun;
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtKayitHesabi)
                return;
            else if(sender == txtKayitHesabi)
            {
                var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
                if (kayitTuru == KayitTuru.CariSube)
                    txtKayitHesabi.ControlEnabledChange(txtCariSube);
            }           
        }

        #region İletişim Türleri
        private void tglVoip_EditValueChanged(object sender, EventArgs e)
        {
            bool isVoip = Convert.ToBoolean(tglVoip.EditValue);

            txtSIPKullaniciAdi.Enabled = isVoip;
            txtSIPServer.Enabled = isVoip;
        }
        private void SetKanallarByIletisimTuru(IletisimTuru tur)
        {
            txtKanallar.Properties.Items.Clear();
            txtKanallar.SetEditValue(null);

            if (tur == IletisimTuru.Telefon)
            {
                foreach (var item in EnumFunctions
                         .GetEnumDescriptionList<IletisimKanalTipi>()
                         .Cast<string>())
                {
                    txtKanallar.Properties.Items.Add(
                        new CheckedListBoxItem(item, false)
                    );
                }
            }
            else if (tur == IletisimTuru.EPosta)
            {
                txtKanallar.Properties.Items.Add(
                    new CheckedListBoxItem("E-Posta", true) // ✅ default seçili
                );

                txtKanallar.SetEditValue("E-Posta");       // 🔥 KRİTİK
            }
        }
        private void TxtIletisimTurleri_EditValueChanged(object sender, EventArgs e)
        {
            if (txtIletisimTurleri.EditValue == null) return;

            IletisimTuru iletisimTuru;

            try
            {
                iletisimTuru = EnumFunctions.GetValueFromDescription<IletisimTuru>(txtIletisimTurleri.EditValue.ToString());
            }
            catch
            {
                return;
            }

            txtUlkeKodu.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.Fax;
            txtTelefonVeFax.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.Fax;
            txtDahili.Enabled = iletisimTuru == IletisimTuru.Telefon;
            txtEPosta.Enabled = iletisimTuru == IletisimTuru.EPosta;
            txtWeb.Enabled = iletisimTuru == IletisimTuru.Web;
            txtSosyalMedyaPlatformu.Enabled = iletisimTuru == IletisimTuru.SosyalMedya;
            txtSosyalMedyaUrl.Enabled = iletisimTuru == IletisimTuru.SosyalMedya;
            txtKullaniciAdi.Enabled = iletisimTuru == IletisimTuru.SosyalMedya;
            txtOncelik.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.Fax || iletisimTuru == IletisimTuru.EPosta;
            txtIzinDurumu.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.EPosta;
            txtIzinTarihi.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.EPosta;
            txtKanallar.Enabled = iletisimTuru == IletisimTuru.Telefon || iletisimTuru == IletisimTuru.EPosta;
            tglVoip.Enabled = iletisimTuru == IletisimTuru.Telefon;
            txtSIPServer.Enabled = iletisimTuru == IletisimTuru.Telefon;
            txtSIPKullaniciAdi.Enabled = iletisimTuru == IletisimTuru.Telefon;
            switch (iletisimTuru)
            {
                case IletisimTuru.Telefon:
                    txtSosyalMedyaPlatformu.Id = null;
                    ClearControls(txtEPosta, txtWeb, txtSosyalMedyaPlatformu, txtSosyalMedyaUrl, txtKullaniciAdi);
                    tglVoip.EditValue = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    SetKanallarByIletisimTuru(IletisimTuru.Telefon);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.EPosta:
                    txtSosyalMedyaPlatformu.Id = null;
                    ClearControls(txtUlkeKodu, txtTelefonVeFax, txtDahili, txtWeb, txtSosyalMedyaPlatformu, txtSosyalMedyaUrl, txtKullaniciAdi, txtSIPKullaniciAdi, txtSIPServer, tglVoip);
                    SetKanallarByIletisimTuru(IletisimTuru.EPosta);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.Web:
                    txtSosyalMedyaPlatformu.Id = null;
                    txtKanallar.Enabled = false;
                    ClearControls(txtUlkeKodu, txtTelefonVeFax, txtDahili, txtEPosta, txtOncelik, txtIzinDurumu, txtIzinTarihi, txtSosyalMedyaUrl, txtSosyalMedyaPlatformu, txtKullaniciAdi, txtSIPKullaniciAdi, txtSIPServer);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.SosyalMedya:
                    txtKanallar.Enabled = false;
                    ClearControls(txtUlkeKodu, txtTelefonVeFax, txtDahili, txtEPosta, txtOncelik, txtIzinDurumu, txtIzinTarihi, txtWeb, txtSIPKullaniciAdi, txtSIPServer);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.Fax:
                    txtSosyalMedyaPlatformu.Id = null;
                    txtKanallar.Enabled = false;
                    ClearControls(txtDahili, txtEPosta, txtIzinDurumu, txtIzinTarihi, txtKanallar, txtWeb, txtSosyalMedyaPlatformu, txtSosyalMedyaUrl, txtKullaniciAdi, txtSIPKullaniciAdi, txtSIPServer);
                    txtBaslik.Focus();
                    break;
            }
        }
        private void ClearControls(params Control[] controls)
        {
            foreach (var c in controls)
            {
                if (c is DateEdit de)
                {
                    de.EditValue = null;
                }
                else if (c is ComboBoxEdit ce)
                {
                    ce.EditValue = null;
                }
                else if (c is ButtonEdit be)
                {
                    be.Text = "";
                    if (be.Tag != null) be.Tag = null;
                }
                else if (c is TextEdit te)
                {
                    // TextEdit ama DateEdit veya ComboBoxEdit değil
                    if (!(te is DateEdit) && !(te is ComboBoxEdit))
                        te.Text = "";
                }
                else if (c is CheckedComboBoxEdit cce)
                {
                    cce.SetEditValue(null);
                }
                else if (c is ToggleSwitch ts)
                {
                    ts.EditValue = false;
                }
            }
        }
        #endregion
    }
}