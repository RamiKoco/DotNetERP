using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.UserControls.UserControl.EklerEditFormTable;
using DotNet.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class KisiEditForm : BaseEditForm
    {
        #region Variables
        protected internal GridView Tablo;
        private BaseTablo _yorumlarTable;
        private BaseTablo _cariBaglantiTable;
        private BaseTablo _iletisimBilgileriTable;
        private BaseTablo _adreslerTable;
        private BaseTablo _EklerTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private Functions.EtiketHelper _etiketHelper;
        private readonly string _baseTitle;
        private bool _ilkKayitKaydedildi = false;
        public string KisiAdiSoyadi => $"{txtAdi.Text} {txtSoyAdi.Text}".Trim();
        public long KisiIdValue => (OldEntity?.Id ?? 0);
        #endregion
        public KisiEditForm()
        {
            InitializeComponent();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new KisiBll(DataLayoutGenelBilgiler);
            HideItems = new BarItem[] { btnYeni };
            BaseKartTuru = KartTuru.Kisi;          
            txtCinsiyet.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Cinsiyet>());
            _etiketHelper = new Functions.EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.Kisi);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };
            EventsLoad();
            _baseTitle = Text;
            tabUst.SelectedPageChanging += Tab_SelectedPageChanging;
            tabAlt.SelectedPageChanging += Tab_SelectedPageChanging;
        }
        public override void Yukle()
        {           
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.KisiDto.KisiS() : ((KisiBll)Bll).Single(Functions.FilterFunctions.Filter<Kisi>(Id));
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert)            
                      tabAlt.SelectedPage = pageEkler;
            
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            _iletisimBilgileriTable?.Temizle();
            _adreslerTable?.Temizle();
            _cariBaglantiTable?.Temizle();
            _yorumlarTable?.Temizle();
            _EklerTable?.Temizle();
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KisiBll)Bll).YeniKodVer();
            txtAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.KisiDto.KisiS)OldEntity;
            if (entity.Id > 0)           
                Text = $"{_baseTitle} - ( {entity.Ad} {entity.Soyad} )";  
            else
               Text = $"{_baseTitle} - ( Yeni Kayıt )";            
            txtKod.Text = entity.Kod;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;
            txtCinsiyet.SelectedItem = entity.Cinsiyet.ToName();
            txtDogumTarihi.EditValue = entity.DogumTarihi;
            txtAciklama.Text = entity.Aciklama;
            txtSorumlu.Id = entity.PersonelId;
            txtSorumlu.Text = entity.PersonelAdi;
            txtKayitKaynak.Id = entity.KayitKaynakId;
            txtKayitKaynak.Text = entity.KayitKaynakAdi;
            txtMeslek.Id = entity.MeslekId;
            txtMeslek.Text = entity.MeslekAdi;
            txtKisiGrubu.Id = entity.KisiGrubuId;
            txtKisiGrubu.Text = entity.KisiGrubuAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;        
            BagliTabloYukle();
            EtiketleriYukle();
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {            
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            CurrentEntity = new Kisi
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                Cinsiyet = txtCinsiyet.Text.GetEnum<Cinsiyet>(),
                DogumTarihi = (DateTime?)txtDogumTarihi.EditValue,
                Aciklama = txtAciklama.Text,
                PersonelId = txtSorumlu.Id,
                KayitKaynakId = txtKayitKaynak.Id,
                MeslekId = txtMeslek.Id,
                KisiGrubuId = txtKisiGrubu.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            BagliTabloYukle();
            ButonEnabledDurumu();
        }    
        private void EtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Kisi && x.KayitId == Id)
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

                        if (!BagliTabloKaydet())
                            return false;
                        // Kayıt işlemini doğrudan yap
                        bool sonuc = BaseIslemTuru == IslemTuru.EntityInsert
                          ? EntityInsert()
                          : EntityUpdate();

                        if (!sonuc) return false;

                        OldEntity = CurrentEntity;
                        RefleshYapilacak = true;
                        return true;

                    case DialogResult.No:
                        GeriAl(false);
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
                if (sender == txtMeslek)
                    sec.Sec(txtMeslek);
                else if (sender == txtKisiGrubu)
                    sec.Sec(txtKisiGrubu);
                else if (sender == txtSorumlu)
                    sec.Sec(txtSorumlu);
                else if (sender == txtKayitKaynak)
                    sec.Sec(txtKayitKaynak);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Kisi);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Kisi);

        }
        protected override void BagliTabloYukle()
        {
            if (_yorumlarTable != null && TabloDegisti())
                _yorumlarTable.Yukle();
            if (_cariBaglantiTable != null && TabloDegisti())
                _cariBaglantiTable.Yukle();
            if (_iletisimBilgileriTable != null && TabloDegisti())
                _iletisimBilgileriTable.Yukle();
            if (_adreslerTable != null && TabloDegisti())
                _adreslerTable.Yukle();
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
            if (_cariBaglantiTable != null && _cariBaglantiTable.HataliGiris())
            {
                tabUst.SelectedPage = pageBaglantilar;
                _cariBaglantiTable.Tablo.GridControl.Focus();
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

            if (_cariBaglantiTable != null)
            {
                if (_cariBaglantiTable.HataliGiris())
                {
                    tabUst.SelectedPage = pageBaglantilar;
                    _cariBaglantiTable.Tablo.GridControl.Focus();
                    return false;
                }
                var source = _cariBaglantiTable.Tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
                if (source != null)
                {
                    for (int i = source.Count - 1; i >= 0; i--)
                    {
                        if (string.IsNullOrWhiteSpace(source[i].KayitHesabi))
                            source.RemoveAt(i);
                    }
                }
                if (!_cariBaglantiTable.Kaydet())
                    return false;
                
                //var cariTable = _cariBaglantiTable as CariKayitTuruBaglantiTable;
                //if (cariTable != null && !cariTable.KaydetKontrollu())
                //    return false;
            }
            if (_EklerTable != null && !_EklerTable.Kaydet()) return false;
            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.Kisi, Id, seciliEtiketIdler);
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

            else if (e.Page == pageYorumlar)
            {
                //if (BaseIslemTuru == IslemTuru.EntityInsert)
                //    return;
                if (pageYorumlar.Controls.Count == 0)
                {
                    _yorumlarTable = new YorumlarTable().AddTable(this);
                    pageYorumlar.Controls.Add(_yorumlarTable);
                    _yorumlarTable.Yukle();
                    TabloInsertOdakAyarla(_yorumlarTable, pageYorumlar);
                }

                _yorumlarTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageBaglantilar)
            {                
                //if (BaseIslemTuru == IslemTuru.EntityInsert)
                //    return;

                if (pageBaglantilar.Controls.Count == 0)
                {
                    _cariBaglantiTable = new CariKayitTuruBaglantiTable().AddTable(this);
                    pageBaglantilar.Controls.Add(_cariBaglantiTable);
                    _cariBaglantiTable.Yukle();
                    TabloInsertOdakAyarla(_cariBaglantiTable, pageBaglantilar);
                }

                _cariBaglantiTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageIletisimBilgileri)
            {
                //if (BaseIslemTuru == IslemTuru.EntityInsert)
                //    return;
                if (pageIletisimBilgileri.Controls.Count == 0)
                {
                    _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
                    pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);
                    _iletisimBilgileriTable.Yukle();
                    TabloInsertOdakAyarla(_iletisimBilgileriTable, pageIletisimBilgileri);
                }

                _iletisimBilgileriTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageAdresBilgileri)
            {
                //if (BaseIslemTuru == IslemTuru.EntityInsert)
                //    return;
                if (pageAdresBilgileri.Controls.Count == 0)
                {
                    _adreslerTable = new AdreslerTable().AddTable(this);
                    pageAdresBilgileri.Controls.Add(_adreslerTable);
                    _adreslerTable.Yukle();
                    TabloInsertOdakAyarla(_adreslerTable, pageAdresBilgileri);
                }

                _adreslerTable.Tablo.GridControl.Focus();
               
            }
            else if (e.Page == pageEkler)
            {
                // Yeni kayıttaysa tabloyu hiç oluşturma!
                //if (BaseIslemTuru == IslemTuru.EntityInsert)
                //    return;

                if (pageEkler.Controls.Count == 0)
                {
                    _EklerTable = new EklerTable(KayitTuru.Kisi, this.Id).AddTable(this);
                    pageEkler.Controls.Add(_EklerTable);
                    _EklerTable.Yukle();
                    TabloInsertOdakAyarla(_EklerTable, pageEkler);
                }

                _EklerTable.Tablo.GridControl.Focus();
            }
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
            if (Degisti(_cariBaglantiTable)) return true;
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
        protected override void GeriAlCore()
        {
            _yorumlarTable?.GeriAl();
            _cariBaglantiTable?.GeriAl();
            _iletisimBilgileriTable?.GeriAl();
            _adreslerTable?.GeriAl();
            _EklerTable?.GeriAl();

            CurrentEntity = OldEntity;
            ButonEnabledDurumu();
        }

    }
}