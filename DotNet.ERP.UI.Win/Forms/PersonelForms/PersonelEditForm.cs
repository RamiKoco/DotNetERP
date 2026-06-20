using DotNet.ERP.Bll.General.PersonelBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Dto.PersonelDto;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DotNet.ERP.Model.Entities.PersonelEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.UserControls.UserControl.EklerEditFormTable;
using DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.PersonelForms
{
    public partial class PersonelEditForm : BaseEditForm
    {
        #region Variables
        private BaseTablo _adreslerTable;
        private BaseTablo _yorumlarTable;
        private BaseTablo _iletisimBilgileriTable;
        private BaseTablo _personelBelgeTable;
        private BaseTablo _EklerTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private Functions.EtiketHelper _etiketHelper;
        private readonly string _baseTitle;
        private bool _ilkKayitKaydedildi = false;
        #endregion
        public PersonelEditForm()
        {
            InitializeComponent();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler, DataLayoutControlKisiselBilgiler };
            Bll = new PersonelBll(DataLayoutGenelBilgiler);
            HideItems = new BarItem[] { btnYeni };
            BaseKartTuru = KartTuru.Personel;
            EventsLoad();
            txtCinsiyet.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Cinsiyet>());
            txtKanGrubu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KanGrubu>());
            txtAskerlikDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AskerlikDurumu>());
            txtMedeniDurum.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<MedeniDurum>());
            txtCinsiyet.EditValueChanged += TxtCinsiyet_EditValueChanged;

            _etiketHelper = new Functions.EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.Personel);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };
            _baseTitle = Text;
            tabUst.SelectedPageChanging += Tab_SelectedPageChanging;
            tabAlt.SelectedPageChanging += Tab_SelectedPageChanging;
        }  
        private void TxtKimlikTuru_EditValueChanged(object sender, EventArgs e)
        {
            KimlikTuruAyarla(txtKimlikTuru.Id);
        }    
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new PersonelS() : ((PersonelBll)Bll).Single(Functions.FilterFunctions.Filter<Personel>(Id));
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert)
                tabAlt.SelectedPage = pageEkler;
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            _personelBelgeTable?.Temizle();
            _EklerTable?.Temizle();
            _adreslerTable?.Temizle();
            _iletisimBilgileriTable?.Temizle();
            _yorumlarTable?.Temizle();
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((PersonelBll)Bll).YeniKodVer();
            txtAdi.Focus();
        }
        private byte[] _oldResim;
        private bool _resimDegisti;
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (PersonelS)OldEntity;
            _oldResim = entity.Resim;          // orijinal bytes
            _resimDegisti = false;
            if (entity.Id > 0)
                Text = $"{_baseTitle} - ( {entity.Ad} {entity.Soyad} )";
            else
                Text = $"{_baseTitle} - ( Yeni Kayıt )";            
            txtKod.Text = entity.Kod;
            txtKimlikNo.Text = entity.KimlikNo;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;
            txtAnaAdi.Text = entity.AnaAdi;
            txtBabaAdi.Text = entity.BabaAdi;
            txtSGKSicilNo.Text = entity.SGKSicilNo;
            txtCinsiyet.SelectedItem = entity.Cinsiyet.ToName();
            txtKanGrubu.SelectedItem = entity.KanGrubu.ToName();
            txtAskerlikDurumu.SelectedItem = entity.AskerlikDurumu.ToName();
            txtMedeniDurum.SelectedItem = entity.MedeniDurum.ToName();
            txtDogumTarihi.EditValue = entity.DogumTarihi;
            imgResim.EditValueChanged -= ImgResim_EditValueChanged;
            imgResim.EditValue = entity.Resim; // sadece gösterim
            imgResim.EditValueChanged += ImgResim_EditValueChanged;
            txtAciklama.Text = entity.Aciklama;
            txtDepartman.Id = entity.DepartmanId;
            txtDepartman.Text = entity.DepartmanAdi;
            TxtCinsiyet_EditValueChanged(null, null);
            txtMeslek.Id = entity.MeslekId;
            txtMeslek.Text = entity.MeslekAdi;
            txtUyruk.Id = entity.UyrukId;
            txtUyruk.Text = entity.UyrukAdi;
            txtPozisyon.Id = entity.PozisyonId;
            txtPozisyon.Text = entity.PozisyonAdi;
            txtKimlikTuru.Id = entity.KimlikTuruId;
            txtKimlikTuru.Text = entity.KimlikTuruAdi;
            KimlikTuruAyarla(entity.KimlikTuruId);
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;
            EtiketleriYukle();
        }
        private void ImgResim_EditValueChanged(object sender, EventArgs e)
        {
            _resimDegisti = true;
        }
        protected override void GuncelNesneOlustur()
        {
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            var oldBytes = ((Personel)OldEntity).Resim;
            var currentBytes = Functions.ImageHelper.GetBytesFromEditValue(imgResim.EditValue);
            byte[] resimBytes;

            if (currentBytes == null && oldBytes == null)
                resimBytes = null;
            else if (Functions.ImageHelper.ByteArrayEqual(currentBytes, oldBytes))
                resimBytes = oldBytes;  // değişiklik yok
            else
            {
                var img = Functions.ImageHelper.ToImage(currentBytes);
                var resized = Functions.ImageHelper.ResizeHighQuality(img, 250, 250);
                resimBytes = Functions.ImageHelper.ToBytes(resized);
            }

            CurrentEntity = new Personel
            {
                Id = Id,
                Kod = txtKod.Text,
                KimlikNo = txtKimlikNo.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                BabaAdi = txtBabaAdi.Text,
                AnaAdi = txtAnaAdi.Text,
                SGKSicilNo = txtSGKSicilNo.Text,
                Cinsiyet = txtCinsiyet.Text.GetEnum<Cinsiyet>(),
                KanGrubu = txtKanGrubu.Text.GetEnum<KanGrubu>(),
                MedeniDurum = txtMedeniDurum.Text.GetEnum<MedeniDurum>(),
                AskerlikDurumu = txtAskerlikDurumu.Text.GetEnum<AskerlikDurumu>(),
                DogumTarihi = (DateTime?)txtDogumTarihi.EditValue,
                Resim = resimBytes, // ← SADECE BURAYI KULLAN!
                Aciklama = txtAciklama.Text,
                DepartmanId = txtDepartman.Id,
                UyrukId = txtUyruk.Id,
                KimlikTuruId = txtKimlikTuru.Id,
                MeslekId = txtMeslek.Id,
                PozisyonId = txtPozisyon.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            BagliTabloYukle();
            ButonEnabledDurumu();
        }  
        private void TxtCinsiyet_EditValueChanged(object sender, EventArgs e)
        {
            // Eğer kız seçiliyse askerlik durumu görünmesin, değilse görünsün
            if (txtCinsiyet.EditValue != null && txtCinsiyet.EditValue.ToString() == Cinsiyet.Kadin.ToName())
            {               
                txtAskerlikDurumu.SelectedItem = null;
                txtAskerlikDurumu.EditValue = null;
                AskerlikDurumuLbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
                txtAskerlikDurumu.Visible = true;
        }  
        private void EtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Personel && x.KayitId == Id)
                    .Select(x => x.EtiketId)
                    .ToList();

                // Sözlüğü yükle
                var etiketAdlari = db.Etiket
                    .Where(e => seciliEtiketler.Contains(e.Id))
                    .ToDictionary(e => e.Id, e => e.Ad);

                txtContainer.TokenEditControl.EtiketAdlariniYukle(etiketAdlari);

                txtContainer.TokenEditControl.EditValue = string.Join(",", seciliEtiketler);

                _oldEtiketIdListesi = seciliEtiketler;
            }
        }
        public override bool Kaydet(bool kapanis)
        {
            if (txtKimlikTuru.Id != null)
            {
                var bll = new Bll.General.KimlikTuruBll();
                var secilen = bll.Single(x => x.Id == (long)txtKimlikTuru.Id) as Model.Entities.KimlikTuru;
                int istenenUzunluk = secilen?.Uzunluk ?? 0;
                string karakterTipi = secilen?.KarakterTipi;
                string girilen = txtKimlikNo.Text?.Trim();

                // MASK boşluklarını temizle (örn: ____)
                girilen = girilen?.Replace("_", "");

                // Uzunluk kontrolü
                if (girilen.Length != istenenUzunluk)
                {
                    Messages.UyariMesaji($"Kimlik numarası tam {istenenUzunluk} karakter olmalıdır.");
                    return false;
                }

                // Karakter tipi kontrolü
                if (karakterTipi == "Numeric" && !System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^\d+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece sayılardan oluşmalıdır.");
                    return false;
                }

                if (karakterTipi == "AlphaNumeric" && !System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^[a-zA-Z0-9]+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece harf ve rakamlardan oluşmalıdır.");
                    return false;
                }
            }

            //GuncelNesneOlustur();

            bool etiketDegisti = !_oldEtiketIdListesi.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>());
            bool entityDegisti = !OldEntity.Equals(CurrentEntity);

            if (kapanis && !entityDegisti && !etiketDegisti && !FarkliSubeIslemi)
                return true;

            if (kapanis)
            {
                var result = Messages.KapanisMesaj(); // sadece 1 kez sor
                switch (result)
                {
                    case DialogResult.Yes:

                        _oldEtiketIdListesi = _guncelEtiketIdListesi.ToList();

                        // Kayıt işlemini doğrudan yap
                        bool sonuc = BaseIslemTuru == IslemTuru.EntityInsert
                            ? EntityInsert()
                            : EntityUpdate();

                        if (!sonuc) return false;

                        OldEntity = CurrentEntity;
                        RefleshYapilacak = true;

                        return true;

                    case DialogResult.No:
                        return true;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            // Menüden kaydet gibi durumlar
            if (!BagliTabloKaydet()) return false;

            _oldEtiketIdListesi = _guncelEtiketIdListesi.ToList();
            return base.Kaydet(kapanis);
        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;

            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtDepartman)
                    sec.Sec(txtDepartman);
                else if (sender == txtPozisyon)
                    sec.Sec(txtPozisyon);
                else if (sender == txtUyruk)
                    sec.Sec(txtUyruk);
                else if (sender == txtKimlikTuru)
                {
                    sec.Sec(txtKimlikTuru);
                    KimlikTuruAyarla(txtKimlikTuru.Id);
                }              
                else if (sender == txtMeslek)
                    sec.Sec(txtMeslek);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Personel);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Personel);

        }
        protected override void Control_Enter(object sender, EventArgs e)
        {
            if (!(sender is MyPictureEdit resim)) return;
            resim.Sec(resimMenu);

        }
        protected override void BagliTabloYukle()
        {           
            if (_adreslerTable != null && TabloDegisti())
                _adreslerTable.Yukle();
            if (_yorumlarTable != null && TabloDegisti())
                _yorumlarTable.Yukle();
            if (_iletisimBilgileriTable != null && TabloDegisti())
                _iletisimBilgileriTable.Yukle();            
            if (_personelBelgeTable != null && TabloDegisti())
                _personelBelgeTable.Yukle();
            if (_EklerTable != null && TabloDegisti())
                _EklerTable.Yukle();
        }
        protected override bool BagliTabloHataliGirisKontrol()
        {
           
            if (_yorumlarTable != null && _yorumlarTable.HataliGiris())
            {
                tabUst.SelectedPage = pageYorumlar;
                _yorumlarTable.Tablo.GridControl.Focus();
                return true;
            }
        
            if (_personelBelgeTable != null && _personelBelgeTable.HataliGiris())
            {
                tabUst.SelectedPage = pageBelgeler;
                _personelBelgeTable.Tablo.GridControl.Focus();
                return true;
            }
            if (_EklerTable != null && _EklerTable.HataliGiris())
            {
                tabAlt.SelectedPage = pageEkler;
                _EklerTable.Tablo.GridControl.Focus();
                return true;
            }
            return false;
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            bool etiketDegisti = !(_oldEtiketIdListesi?.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>()) ?? true);

            if (FarkliSubeIslemi)
            {
                Functions.GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil);
            }
            else if (TabloDegisti())
            {
                Functions.GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, true);
            }
            else
            {
                Functions.GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, etiketDegisti);
            }
        }
        protected override bool BagliTabloKaydet()
        {
            //if (_yorumlarTable != null && !_yorumlarTable.Kaydet()) return false;
            if (_yorumlarTable != null)
            {
                // Önce hatalı giriş var mı kontrol et
                if (_yorumlarTable.HataliGiris())
                {
                    tabUst.SelectedPage = pageYorumlar;
                    _yorumlarTable.Tablo.GridControl.Focus();
                    return false;
                }

                // Boş Yorum satırlarını listeden çıkar
                var source = _yorumlarTable.Tablo.DataController.ListSource as IList<YorumlarL>;
                if (source != null)
                {
                    for (int i = source.Count - 1; i >= 0; i--)
                    {
                        if (string.IsNullOrWhiteSpace(source[i].Yorum))
                            source.RemoveAt(i);
                    }
                }

                // Şimdi kaydet
                if (!_yorumlarTable.Kaydet())
                    return false;
            }

            if (_personelBelgeTable != null && !_personelBelgeTable.Kaydet()) return false;
            if (_EklerTable != null && !_EklerTable.Kaydet()) return false;

            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.Personel, Id, seciliEtiketIdler);
            _oldEtiketIdListesi = seciliEtiketIdler.ToList();
            return true;
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageGenelBilgiler)
            {
                txtAdi.Focus();
                txtSoyAdi.SelectAll();
            }
            else if (e.Page == pageAdresBilgileri)
            {                
                if (pageAdresBilgileri.Controls.Count == 0)
                {
                    _adreslerTable = new AdreslerTable().AddTable(this);
                    pageAdresBilgileri.Controls.Add(_adreslerTable);
                    _adreslerTable.Yukle();
                    TabloInsertOdakAyarla(_adreslerTable, pageAdresBilgileri);
                }

                _adreslerTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageYorumlar)
            {
                if (pageYorumlar.Controls.Count == 0)
                {
                    _yorumlarTable = new YorumlarTable().AddTable(this);
                    pageYorumlar.Controls.Add(_yorumlarTable);
                    _yorumlarTable.Yukle();
                    TabloInsertOdakAyarla(_yorumlarTable, pageYorumlar);
                }

                _yorumlarTable.Tablo.GridControl.Focus();               
            }
            else if (e.Page == pageIletisimBilgileri)
            {
                if (pageIletisimBilgileri.Controls.Count == 0)
                {
                    _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
                    pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);
                    _iletisimBilgileriTable.Yukle();
                    TabloInsertOdakAyarla(_iletisimBilgileriTable, pageIletisimBilgileri);
                }

                _iletisimBilgileriTable.Tablo.GridControl.Focus();
            }     
            else if (e.Page == pageBelgeler)
            {
                if (pageBelgeler.Controls.Count == 0)
                {
                    _personelBelgeTable = new PersonelBelgeTable().AddTable(this);
                    pageBelgeler.Controls.Add(_personelBelgeTable);
                    _personelBelgeTable.Yukle();
                    TabloInsertOdakAyarla(_personelBelgeTable, pageBelgeler);
                }

                _personelBelgeTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageEkler)
            {
                // Yeni kayıttaysa tabloyu hiç oluşturma!
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                    return;

                if (pageEkler.Controls.Count == 0)
                {
                    _EklerTable = new EklerTable(KayitTuru.Personel, this.Id).AddTable(this);
                    pageEkler.Controls.Add(_EklerTable);
                    _EklerTable.Yukle();
                    TabloInsertOdakAyarla(_EklerTable, pageEkler);
                }

                _EklerTable.Tablo.GridControl.Focus();
            }
        }
        private void KimlikTuruAyarla(long? kimlikTuruId)
        {
            if (kimlikTuruId == null) return;

            var bll = new Bll.General.KimlikTuruBll();
            var secilen = bll.Single(x => x.Id == kimlikTuruId) as Model.Entities.KimlikTuru;
            if (secilen == null) return;

            int yeniUzunluk = secilen.Uzunluk;
            string karakterTipi = secilen.KarakterTipi;

            // MaxLength
            txtKimlikNo.Properties.MaxLength = yeniUzunluk;

            // Maske ayarı
            txtKimlikNo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            txtKimlikNo.Properties.Mask.UseMaskAsDisplayFormat = true;

            if (karakterTipi == "Numeric")
            {
                txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                txtKimlikNo.Properties.Mask.EditMask = $@"\d{{{yeniUzunluk}}}";
            }
            else if (karakterTipi == "AlphaNumeric")
            {
                txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                txtKimlikNo.Properties.Mask.EditMask = $@"[a-zA-Z0-9]{{{yeniUzunluk}}}";
            }
            else
            {
                txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                txtKimlikNo.Properties.Mask.EditMask = null;
            }

            // Uzun girişi kırp
            if (txtKimlikNo.Text.Length > yeniUzunluk)
                txtKimlikNo.Text = txtKimlikNo.Text.Substring(0, yeniUzunluk);
        }
        private bool TabloDegisti()
        {
            bool Degisti(BaseTablo tablo)
            {
                var list = tablo?.Tablo.DataController.ListSource;
                if (list == null)
                    return false;

                var hareketList = list as IEnumerable<IBaseHareketEntity>;
                if (hareketList == null)
                    return false;

                return hareketList.Any(x => x.Insert || x.Update || x.Delete);
            }

            if (Degisti(_yorumlarTable)) return true;       
            if (Degisti(_personelBelgeTable)) return true;       
            if (Degisti(_EklerTable)) return true;       

            return false;
        }
        private void TabloInsertOdakAyarla(BaseTablo tablo, TabNavigationPage sayfa)
        {
            if (tablo == null || sayfa == null) return;

            tablo.Tablo.InitNewRow += (s, e) =>
            {
                tabUst.SelectedPage = sayfa;
                tablo.Tablo.GridControl.Focus();
            };
        }
        private void Tab_SelectedPageChanging(object sender, SelectedPageChangingEventArgs e)
        {
            if (_ilkKayitKaydedildi)
                return;

            // pageGenelBilgiler haricinde geçişleri kontrol et
            if (!ReferenceEquals(e.Page, pageGenelBilgiler))
            {
                e.Cancel = true; // Geçişi iptal et

                if (ZorunluKayitIleDevamEt()) // Validation ve kaydetme
                {
                    _ilkKayitKaydedildi = true;

                    var tab = sender as TabPane; // veya TabNavigationPage tipine göre değiştir
                    if (tab != null)
                    {
                        tab.SelectedPageChanging -= Tab_SelectedPageChanging;
                        tab.SelectedPage = (TabNavigationPage)e.Page;
                        tab.SelectedPageChanging += Tab_SelectedPageChanging;
                    }
                }
            }
        }
    }
}