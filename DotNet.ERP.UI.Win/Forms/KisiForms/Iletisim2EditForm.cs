using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class Iletisim2EditForm : BaseEditForm
    {
        #region Variables
        private readonly long _kisiId;
        private readonly string _kisiAdi;
        private readonly string _kisiSoyadi;
        private long? _anaKayitId;
        private long? _kayitId;
        #endregion
        //public IletisimEditForm(params object[] prm)
        //{
        //    InitializeComponent();
        //    _kisiId = (long)prm[0];
        //    _kisiAdi = prm[1].ToString();
        //    _kisiSoyadi = prm[2].ToString();

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
        //    Text = Text + $" - ( {_kisiAdi} {_kisiSoyadi} )";
        //}
        public Iletisim2EditForm(params object[] prm)
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
        public Iletisim2EditForm(long kisiId)
        {
            InitializeComponent();

            _kisiId = kisiId;

            OrtakKurulum();
        }
        private void OrtakKurulum()
        {
            // 🔧 BASE FORM AYARLARI
            DataLayoutControl = myDataLayoutControl;
            Bll = new IletisimBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni};
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
            if (!string.IsNullOrWhiteSpace(_kisiAdi) ||
                !string.IsNullOrWhiteSpace(_kisiSoyadi))
            {
                Text = $"{Text} - ( {_kisiAdi} {_kisiSoyadi} )";
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
            txtKod.Text = ((IletisimBll)Bll).YeniKodVer(x => x.KisiId == _kisiId);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IletisimS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtIletisimTurleri.EditValue = entity.IletisimTuru.ToName();
            entity.KayitTuru = KayitTuru.Kisi;
            txtKanallar.SetEditValue(entity.Kanallar);
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

            var kanalListesi = (txtKanallar.EditValue?.ToString() ?? "")
                               .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => x.Trim())
                               .ToList();

            bool eskiArama = eskiEntity?.Arama ?? false;
            bool eskiSms = eskiEntity?.Sms ?? false;
            bool eskiWhatsapp = eskiEntity?.Whatsapp ?? false;
            bool eskiEposta = eskiEntity?.EPBool ?? false;
       
            bool yeniArama = kanalListesi.Any() ? kanalListesi.Contains("Arama") : eskiArama;
            bool yeniSms = kanalListesi.Any() ? kanalListesi.Contains("SMS") : eskiSms;
            bool yeniWhatsapp = kanalListesi.Any() ? kanalListesi.Contains("Whatsapp") : eskiWhatsapp;
            bool yeniEposta = kanalListesi.Any() ? kanalListesi.Contains("E-Posta") : eskiEposta;
            CurrentEntity = new Iletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = KayitTuru.Kisi,
                IletisimTuru = txtIletisimTurleri.Text.GetEnum<IletisimTuru>(),
                IzinDurumu = txtIzinDurumu.Text.GetEnum<IletisimDurumu>(),
                Kanallar = txtKanallar.EditValue?.ToString(),
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
                KisiId = BaseIslemTuru == IslemTuru.EntityInsert ? _kisiId : ((IletisimS)OldEntity).KisiId,               
                KayitId = BaseIslemTuru == IslemTuru.EntityInsert ? _kisiId : ((IletisimS)OldEntity).KisiId,
                AnaKayitId = 0,
                KayitHesabiAdi = ((IletisimS)OldEntity).KayitHesabiAdi,               
            };
            //if (tglVarsayilanYap.IsOn)
            //{
            //    using (var context = new ERPContext())
            //    {
            //        var digerKayitlar = context.Iletisim
            //                            .Where(x => x.VarsayilanYap && x.Id != CurrentEntity.Id)
            //                            .ToList();

            //        foreach (var kayit in digerKayitlar)
            //            kayit.VarsayilanYap = false;

            //        context.SaveChanges();
            //    }
            //}
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
            return ((IletisimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KisiId == _kisiId);
        }
        protected override bool EntityUpdate()
        {
            return ((IletisimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KisiId == _kisiId);
        }
        protected override void SecimYap(object sender)
        {
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
            ICollection<string> kanalListesi;
            switch (tur)
            {
                case IletisimTuru.Telefon:
                    kanalListesi = EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>().Cast<string>().ToList();
                    break;
                case IletisimTuru.EPosta:
                    kanalListesi = EnumFunctions.GetEnumDescriptionList<IletisimKanalTipiEposta>().Cast<string>().ToList();
                    break;
                default:
                    kanalListesi = new List<string>();
                    break;
            }

            foreach (var item in kanalListesi)
            {
                var listItem = new CheckedListBoxItem(item);

                if (tur == IletisimTuru.EPosta && item == "E-Posta")
                {
                    listItem.CheckState = CheckState.Checked;
                }
                else
                {
                    listItem.CheckState = CheckState.Unchecked;
                }

                txtKanallar.Properties.Items.Add(listItem);
            }

            // Telefon gibi diğer türlerde seçimleri temizlemek için:
            if (tur != IletisimTuru.EPosta)
            {
                txtKanallar.SetEditValue(null); // Önceki seçimleri temizle
            }
            else
            {
                // E-Posta için default seçili zaten ayarlandı, ekstra işlem yok
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
                    ClearControls(txtUlkeKodu, txtTelefonVeFax, txtDahili, txtEPosta, txtKanallar, txtOncelik, txtIzinDurumu, txtIzinTarihi, txtSosyalMedyaUrl, txtSosyalMedyaPlatformu, txtKullaniciAdi, txtSIPKullaniciAdi, txtSIPServer);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.SosyalMedya:
                    ClearControls(txtUlkeKodu, txtTelefonVeFax, txtDahili, txtEPosta, txtKanallar, txtOncelik, txtIzinDurumu, txtIzinTarihi, txtWeb, txtSIPKullaniciAdi, txtSIPServer);
                    txtBaslik.Focus();
                    break;

                case IletisimTuru.Fax:
                    txtSosyalMedyaPlatformu.Id = null;
                    ClearControls(txtDahili, txtEPosta, txtKanallar, txtIzinDurumu, txtIzinTarihi, txtWeb, txtSosyalMedyaPlatformu, txtSosyalMedyaUrl, txtKullaniciAdi, txtSIPKullaniciAdi, txtSIPServer);
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
                else if (c is ToggleSwitch ts)
                {
                    ts.EditValue = false;
                }
            }
        } 
        #endregion

    }
}