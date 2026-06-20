using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.PersonelForms
{
    public partial class IletisimEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _personelId;
        private readonly string _personelAdi;
        private readonly string _personelSoyadi;
        private long? _anaKayitId;
        private long? _kayitId;
        #endregion

        //public IletisimEditForm(params object[] prm)
        //{
        //    InitializeComponent();
        //    _personelId = (long)prm[0];
        //    _personelAdi = prm[1].ToString();
        //    _personelSoyadi = prm[2].ToString();

        //    DataLayoutControl = myDataLayoutControl;
        //    Bll = new IletisimBll(myDataLayoutControl);
        //    txtIletisimTurleri.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimTuru>());
        //    txtIzinDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());
        //    txtKanallar.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
        //                .Cast<string>()
        //                .Select(x => new CheckedListBoxItem(x))
        //                .ToArray());
        //    BaseKartTuru = KartTuru.Iletisim;// Kontrol Et
        //    txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
        //    tglVoip.EditValueChanged += tglVoip_EditValueChanged;
        //    EventsLoad();
        //    Text = Text + $" - ( {_personelAdi} {_personelSoyadi} )📌";
        //}

        public IletisimEditForm(params object[] prm)
        {
            InitializeComponent();

            if (prm != null)
            {
                if (prm.Length > 0 && prm[0] != null)
                    _personelId = Convert.ToInt64(prm[0]);

                if (prm.Length > 1 && prm[1] != null)
                    _personelAdi = prm[1].ToString();

                if (prm.Length > 2 && prm[2] != null)
                    _personelSoyadi = prm[2].ToString();
            }

            OrtakKurulum();
        }
        public IletisimEditForm(long personelId)
        {
            InitializeComponent();

            _personelId = personelId;

            OrtakKurulum();
        }
        private void OrtakKurulum()
        {
            // 🔧 BASE FORM AYARLARI
            DataLayoutControl = myDataLayoutControl;
            Bll = new IletisimBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni };
            // 📌 ENUM DOLDURMALARI
            txtIletisimTurleri.Properties.Items.AddRange(
                EnumFunctions.GetEnumDescriptionList<IletisimTuru>());

            txtIzinDurumu.Properties.Items.AddRange(
                EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());

            txtKanallar.Properties.Items.AddRange(
                EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
                    .Cast<string>()
                    .Select(x => new CheckedListBoxItem(x))
                    .ToArray());

            BaseKartTuru = KartTuru.Iletisim;

            // 🎯 EVENTLER
            txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
            tglVoip.EditValueChanged += tglVoip_EditValueChanged;

            EventsLoad();

            // 🧾 FORM BAŞLIĞI
            if (!string.IsNullOrWhiteSpace(_personelAdi) ||
                !string.IsNullOrWhiteSpace(_personelSoyadi))
            {
                Text = $"{Text} - ( {_personelAdi} {_personelSoyadi} )";
            }
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new IletisimS() : ((IletisimBll)Bll).Single(Functions.FilterFunctions.Filter<Iletisim>(Id));
            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                var old = (IletisimS)OldEntity;
                if (_kayitId == null)
                    _kayitId = old.KayitId;           
            }
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IletisimBll)Bll).YeniKodVer(x => x.PersonelId == _personelId);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IletisimS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtIletisimTurleri.EditValue = entity.IletisimTuru.ToName();
            if (entity.IletisimTuru == IletisimTuru.EPosta)
            {
                txtKanallar.SetEditValue(entity.EPBool ? "E-Posta" : null);
            }
            else
            {
                txtKanallar.SetEditValue(entity.Kanallar);
            }
            entity.KayitTuru = KayitTuru.Personel;            
            txtIzinDurumu.SelectedItem = entity.IzinDurumu.ToName();
            txtIzinTarihi.EditValue = entity.IzinTarihi;
            txtOncelik.Value = entity.Oncelik;
            txtWeb.Text = entity.Web;
            txtUlkeKodu.Text = entity.UlkeKodu;
            txtTelefonVeFax.Text = entity.Numara;
            txtDahili.Text = entity.DahiliNo;
            txtEPosta.Text = entity.EPosta;
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
            _kayitId = entity.KayitId;         
        }
        protected override void GuncelNesneOlustur()
        {
            var eskiEntity = OldEntity as IletisimS; // Burada cast ediyoruz.

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

            CurrentEntity = new Iletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = KayitTuru.Personel,
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
                PersonelId = BaseIslemTuru == IslemTuru.EntityInsert ? _personelId : ((IletisimS)OldEntity).PersonelId,              
                KayitId = BaseIslemTuru == IslemTuru.EntityInsert ? _personelId : ((IletisimS)OldEntity).PersonelId,
                KayitHesabiAdi = ((IletisimS)OldEntity).KayitHesabiAdi,
                AnaKayitId = 0,
            };           
            ButonEnabledDurumu();
        }    
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
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
            return ((IletisimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.PersonelId == _personelId);
        }
        protected override bool EntityUpdate()
        {
            return ((IletisimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.PersonelId == _personelId);
        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Iletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Iletisim);
                else if (sender == txtSosyalMedyaPlatformu)
                    sec.Sec(txtSosyalMedyaPlatformu, KartTuru.SosyalMedyaPlatformu);
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