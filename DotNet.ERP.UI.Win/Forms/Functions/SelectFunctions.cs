using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Dto.CariDto.CariSubeDto;
using DotNet.ERP.Model.Dto.PersonelDto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.CariEntity.CariTurleri;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.AdresTurleriForms;
using DotNet.ERP.UI.Win.Forms.AvukatForms;
using DotNet.ERP.UI.Win.Forms.BankaForms;
using DotNet.ERP.UI.Win.Forms.BankaHesapForms;
using DotNet.ERP.UI.Win.Forms.BankaSubeForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariGruplariForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariTurleriForms;
using DotNet.ERP.UI.Win.Forms.DepartmanForms;
using DotNet.ERP.UI.Win.Forms.EtiketForms;
using DotNet.ERP.UI.Win.Forms.GorevForms;
using DotNet.ERP.UI.Win.Forms.HizmetTuruForms;
using DotNet.ERP.UI.Win.Forms.IlceForms;
using DotNet.ERP.UI.Win.Forms.IlForms;
using DotNet.ERP.UI.Win.Forms.IndirimTuruForms;
using DotNet.ERP.UI.Win.Forms.IsyeriForms;
using DotNet.ERP.UI.Win.Forms.KasaForms;
using DotNet.ERP.UI.Win.Forms.KayitKaynakForms;
using DotNet.ERP.UI.Win.Forms.KimlikTuruForms;
using DotNet.ERP.UI.Win.Forms.KisiForms;
using DotNet.ERP.UI.Win.Forms.KisiGrubuForms;
using DotNet.ERP.UI.Win.Forms.KontenjanForms;
using DotNet.ERP.UI.Win.Forms.KullaniciForms;
using DotNet.ERP.UI.Win.Forms.KurumTuruForms;
using DotNet.ERP.UI.Win.Forms.MeslekForms;
using DotNet.ERP.UI.Win.Forms.OdemeTuruForms;
using DotNet.ERP.UI.Win.Forms.OkulForms;
using DotNet.ERP.UI.Win.Forms.OzelKodForms;
using DotNet.ERP.UI.Win.Forms.PersonelForms;
using DotNet.ERP.UI.Win.Forms.PozisyonForms;
using DotNet.ERP.UI.Win.Forms.RehberForms;
using DotNet.ERP.UI.Win.Forms.RenkForms;
using DotNet.ERP.UI.Win.Forms.SektorForms;
using DotNet.ERP.UI.Win.Forms.SinifForms;
using DotNet.ERP.UI.Win.Forms.SinifGrupForms;
using DotNet.ERP.UI.Win.Forms.SosyalMedyaForms;
using DotNet.ERP.UI.Win.Forms.SubeForms;
using DotNet.ERP.UI.Win.Forms.TesvikForms;
using DotNet.ERP.UI.Win.Forms.UlkeForms;
using DotNet.ERP.UI.Win.Forms.UyrukForms;
using DotNet.ERP.UI.Win.Forms.VergiDairesiForms;
using DotNet.ERP.UI.Win.Forms.YabancıDilForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace DotNet.ERP.UI.Win.Forms.Functions
{
    public class SelectFunctions : IDisposable
    {
        #region Variables
        private MyButtonEdit _btnEdit;
        private MyButtonEdit _prmEdit;
        private KartTuru _kartTuru;
        private OdemeTipi _odemeTipi;
        private BankaHesapTuru _hesapTuru;

        #endregion

        public void Sec(MyButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, OdemeTipi odemeTipi)
        {
            _btnEdit = btnEdit;
            _odemeTipi = odemeTipi;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, KartTuru kartTuru, BankaHesapTuru hesapTuru)
        {
            _btnEdit = btnEdit;
            _kartTuru = kartTuru;
            _hesapTuru = hesapTuru;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit,KartTuru kartTuru)
        {
            _btnEdit = btnEdit;
            _kartTuru= kartTuru;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, MyButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            SecimYap();
        }
        public void SecCariSube(MyButtonEdit subeEdit, MyButtonEdit cariEdit)
        {
            _btnEdit = subeEdit;
            _prmEdit = cariEdit;
            SecimYap();
        }
        private void SecimYap()
        {
            switch (_btnEdit.Name)
            {
                case "txtUlke":
                    {
                        var entity = (Model.Entities.Ulke)ShowListForms<UlkeListForm>.ShowDialogListForm(KartTuru.Ulke,
                            _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.UlkeAdi;
                        }
                    }
                    break;

                case "txtIl":
                case "txtAdresIl":
                case "txtEvAdresIl":
                case "txtIsAdresIl":
                case "txtKimlikIl":
                {
                    var entity = (Il) ShowListForms<IlListForm>.ShowDialogListForm(KartTuru.Il, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.Ad;
                    }
                }
                    break;

                case "txtIlce":
                case "txtAdresIlce":
                case "txtEvAdresIlce":
                case "txtIsAdresIlce":
                case "txtKimlikIlce":
                    {
                    var entity = (Ilce) ShowListForms<IlceListForm>.ShowDialogListForm(KartTuru.Ilce, _btnEdit.Id,
                        _prmEdit.Id, _prmEdit.Text);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.Ad;
                    }
                }
                    break;

                case "txtGrup":
                {
                    var entity =
                        (SinifGrup) ShowListForms<SinifGrupListForm>.ShowDialogListForm(KartTuru.SinifGrup,
                            _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.GrupAdi;
                    }
                }
                    break;

                case "txtHizmetTuru":
                {
                    var entity =
                        (HizmetTuru) ShowListForms<HizmetTuruListForm>.ShowDialogListForm(KartTuru.HizmetTuru,
                            _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.HizmetTuruAdi;
                    }
                }
                    break;

                case "txtOzelKod1":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod1, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod2":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod2, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod3":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod3, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod4":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod4, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod5":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod5, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;
                    
                    
                        case "txtBanka":
                        {
                            var entity = (BankaL) ShowListForms<BankaListForm>.ShowDialogListForm(KartTuru.Banka, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.BankaAdi;
                            }
                        }
                            break;

                        case "txtBankaSube":
                        {
                            var entity = (BankaSube) ShowListForms<BankaSubeListForm>.ShowDialogListForm(KartTuru.BankaSube, _btnEdit.Id, _prmEdit.Id, _prmEdit.Text);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.SubeAdi;
                            }
                        }
                            break;

                case "txtMeslek":
                {
                    var entity = (MeslekL)ShowListForms<MeslekListForm>.ShowDialogListForm(KartTuru.Meslek, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.Ad;
                    }
                }
                    break;

                case "txtKayitKaynak":
                    {
                        var entity = (Model.Entities.KayitKaynak)ShowListForms<KayitKaynakListForm>.ShowDialogListForm(KartTuru.KayitKaynak, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKisiGrubu":
                    {
                        var entity = (KisiGrubu)ShowListForms<KisiGrubuListForm>.ShowDialogListForm(KartTuru.KisiGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtEtiket":
                    {
                        var entity = (Model.Dto.EtiketL)ShowListForms<EtiketListForm>.ShowDialogListForm(KartTuru.Etiket, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;
                case "txtVergiDairesi":
                    {
                        var entity = (VergiDairesiL)ShowListForms<VergiDairesiListForm>.ShowDialogListForm(
                            KartTuru.VergiDairesi,
                            _btnEdit.Id,
                            frm =>
                            {
                                frm.ShowYeniButton = false;
                                frm.ShowDuzeltButton = false;
                                frm.ShowSilButton = false;
                               
                            }

                        );

                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtCariTuru":
                    {
                        var entity = (CariTuru)ShowListForms<CariTuruListForm>.ShowDialogListForm(KartTuru.CariTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtCariGrubu":
                    {
                        var entity = (CariGrubuL)ShowListForms<CariGrubuListForm>.ShowDialogListForm(KartTuru.CariGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;   
                case "txtCariSubeGrubu":
                    {
                        var entity = (CariSubeGrubuL)ShowListForms<CariSubeGrubuListForm>.ShowDialogListForm(KartTuru.CariSubeGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;   
                    
                case "txtSektor":
                    {
                        var entity = (Sektor)ShowListForms<SektorListForm>.ShowDialogListForm(KartTuru.Sektor, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;                                 

                case "txtRenk":
                    {
                        var entity = (Model.Dto.RenkL)ShowListForms<RenkListForm>.ShowDialogListForm(KartTuru.Renk, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.RenkAdi;
                        }
                    }
                    break;

                case "txtAdresTurleri":
                    {
                        var entity = (Model.Dto.AdresTurleriL)ShowListForms<AdresTurleriListForm>.ShowDialogListForm(KartTuru.AdresTurleri, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtSosyalMedyaPlatformu":
                    {
                        var entity = (Model.Dto.SosyalMedyaPlatformuL)ShowListForms<SosyalMedyaPlatformuListForm>.ShowDialogListForm(KartTuru.SosyalMedyaPlatformu,
                            _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKayitHesabi":
                    {

                        if (_kartTuru == KartTuru.Kisi)
                        {
                            var entity = (Model.Dto.KisiDto.KisiL)ShowListForms<KisiListForm>.ShowDialogListForm(KartTuru.Kisi, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad +" "+ entity.Soyad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Meslek)
                        {
                            var entity = (Meslek)ShowListForms<MeslekListForm>.ShowDialogListForm(KartTuru.Meslek, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Personel)
                        {
                            var entity = (PersonelL)ShowListForms<PersonelListForm>.ShowDialogListForm(KartTuru.Personel, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad + " " + entity.Soyad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Cari)
                        {
                            var entity = (CariL)ShowListForms<CariForms.CarilerForms.CariListForm>.ShowDialogListForm(KartTuru.Cari, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Unvan;
                            }
                        }
                        else if (_kartTuru == KartTuru.CariSube)
                        {
                            var entity = (CariSubeL)ShowListForms<CariSubeListForm>.ShowDialogListForm(KartTuru.CariSube, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        // diğer türler...
                    }
                    break;

                case "txtCariSube":
                {
                        if (_prmEdit == null || _prmEdit.Id == 0)
                        {
                            Messages.UyariMesaji("Lütfen önce cari seçimi yapınız.");
                            return;
                        }

                        var entity = (CariSubeL)ShowListForms<CariSubeListForm>.ShowDialogListForm(
                            KartTuru.CariSube,
                            _btnEdit?.Id ?? 0,
                            _prmEdit.Id,
                            _prmEdit.Text
                        );

                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                }
                break;

                case "txtIsyeri":
                {
                    var entity = (Isyeri)ShowListForms<IsyeriListForm>.ShowDialogListForm(KartTuru.Isyeri, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IsyeriAdi;
                    }
                }
                    break;

                case "txtDepartman":
                    {
                        var entity = (Model.Entities.Departman)ShowListForms<DepartmanListForm>.ShowDialogListForm(KartTuru.Departman, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtPozisyon":
                    {
                        var entity = (Model.Dto.PozisyonL)ShowListForms<PozisyonListForm>.ShowDialogListForm(KartTuru.Pozisyon, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKisi":
                    {
                        var entity = (Model.Dto.KisiDto.KisiL)ShowListForms<KisiListForm>.ShowDialogListForm(KartTuru.Kisi, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad+" "+entity.Soyad;
                        }
                    }
                    break;
                case "txtSorumlu":
                    {
                        var entity = (PersonelL)ShowListForms<PersonelListForm>.ShowDialogListForm(KartTuru.Personel, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtUyruk":
                    {
                        var entity = (Model.Dto.UyrukL)ShowListForms<UyrukListForm>.ShowDialogListForm(KartTuru.Uyruk, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKimlikTuru":
                    {
                        var entity = (Model.Dto.KimlikTuruL)ShowListForms<KimlikTuruListForm>.ShowDialogListForm(KartTuru.KimlikTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;
                case "txtKurumTuru":
                    {
                        var entity = (KurumTuruL)ShowListForms<KurumTuruListForm>.ShowDialogListForm(KartTuru.KurumTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtGorev":
                {
                    var entity = (Gorev)ShowListForms<GorevListForm>.ShowDialogListForm(KartTuru.Gorev, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.GorevAdi;
                    }
                }
                    break;

                case "txtIndirimTuru":
                {
                    var entity = (IndirimTuru)ShowListForms<IndirimTuruListForm>.ShowDialogListForm(KartTuru.IndirimTuru, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IndirimTuruAdi;
                    }
                }
                    break;

                case "txtSinif":
                {
                    var entity = (SinifL)ShowListForms<SinifListForm>.ShowDialogListForm(KartTuru.Sinif, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.SinifAdi;
                    }
                }
                    break;

                case "txtYabanciDil":
                {
                    var entity = (YabanciDil)ShowListForms<YabanciDilListForm>.ShowDialogListForm(KartTuru.YabanciDil, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.DilAdi;
                    }
                }
                    break;

                case "txtGeldigiOkul":
                {
                    var entity = (OkulL)ShowListForms<OkulListForm>.ShowDialogListForm(KartTuru.Okul, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OkulAdi;
                    }
                }
                    break;

                case "txtKontenjan":
                {
                    var entity = (Kontenjan)ShowListForms<KontenjanListForm>.ShowDialogListForm(KartTuru.Kontenjan, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.KontenjanAdi;
                    }
                }
                    break;

                case "txtTesvik":
                {
                    var entity = (Tesvik)ShowListForms<TesvikListForm>.ShowDialogListForm(KartTuru.Tesvik, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.TesvikAdi;
                    }
                }
                    break;

                case "txtRehber":
                {
                    var entity = (Rehber)ShowListForms<RehberListForm>.ShowDialogListForm(KartTuru.Rehber, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.AdiSoyadi;
                    }
                }
                    break;

                case "txtBankaHesap":
                case "txtDefaultBankaHesap":
                {
                    var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, _btnEdit.Id,_odemeTipi);
                    if (entity != null)
                    {
                        _btnEdit.Tag = entity.BlokeGunSayisi;
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.HesapAdi;
                    }
                }
                    break;

                case "txtOdemeTuru":
                {
                    var entity = (OdemeTuru)ShowListForms<OdemeTuruListForm>.ShowDialogListForm(KartTuru.OdemeTuru, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Tag = entity.OdemeTipi;
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OdemeTuruAdi;
                    }
                }
                    break;

                case "txtDefaultAvukatHesap":
                {
                    var entity = (AvukatL)ShowListForms<AvukatListForm>.ShowDialogListForm(KartTuru.Avukat, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.AdiSoyadi;
                    }
                }
                    break;

                case "txtDefaultKasaHesap":
                {
                    var entity = (KasaL)ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.KasaAdi;
                    }
                }
                    break;

                case "txtSube":
                {
                    var entity = (SubeL)ShowListForms<SubeListForm>.ShowDialogListForm(KartTuru.Sube, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.SubeAdi;
                    }
                }
                    break;

                case "txtRol":
                {
                    var entity = (Rol)ShowListForms<RolListForm>.ShowDialogListForm(KartTuru.Rol, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.RolAdi;
                    }
                }
                    break;

                //case "txtDizin":
                //    {
                //        using (var dialog = new XtraFolderBrowserDialog())
                //        {
                //            dialog.Description = "Klasör Seçiniz";
                //            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                //            dialog.ShowNewFolderButton = true;
                //            _btnEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                //            if (_btnEdit.EditValue != null)
                //                dialog.SelectedPath = _btnEdit.EditValue.ToString();

                //            if (dialog.ShowDialog() != DialogResult.OK)
                //                return;

                //            _btnEdit.EditValue = dialog.SelectedPath;
                //        }
                //    }
                //    break;
                case "txtDizin":
                    {
                        using (var dialog = new OpenFileDialog())
                        {
                            dialog.Title = "Klasör Seçiniz";
                            dialog.Filter = "Klasör Seçimi|*.*";
                            dialog.CheckFileExists = false;
                            dialog.CheckPathExists = true;
                            dialog.ValidateNames = false;
                            dialog.FileName = "Klasör Seç";

                            _btnEdit.Properties.TextEditStyle = TextEditStyles.Standard;

                            // Daha önce seçilmiş bir dizin varsa
                            if (_btnEdit.EditValue != null)
                            {
                                var path = _btnEdit.EditValue.ToString();
                                if (Directory.Exists(path))
                                    dialog.InitialDirectory = path;
                            }

                            if (dialog.ShowDialog() != DialogResult.OK)
                                return;

                            // Seçilen klasörü al
                            var selectedPath = Path.GetDirectoryName(dialog.FileName);
                            _btnEdit.EditValue = selectedPath;
                        }
                    }
                    break;

                case "txtHesap":
                {
                    switch (_kartTuru)
                    {
                            case KartTuru.Avukat:
                            {
                                var entity = (AvukatL) ShowListForms<AvukatListForm>.ShowDialogListForm(KartTuru.Avukat, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.AdiSoyadi;
                                }
                                break;
                            }
                            case KartTuru.Kasa:
                            {
                                var entity = (KasaL)ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.KasaAdi;
                                }
                                break;
                            }
                            case KartTuru.BankaHesap:
                            {
                                var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, _btnEdit.Id,_hesapTuru);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.HesapAdi;
                                }
                                break;
                            }

                            case KartTuru.Cari:
                            {
                                var entity = (CariL)ShowListForms<CariForms.CarilerForms.CariListForm>.ShowDialogListForm(KartTuru.Cari, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.Ad;
                                }
                                break;
                            }

                            case KartTuru.Sube:
                                {
                                    var entity = (SubeL)ShowListForms<SubeListForm>.ShowDialogListForm(KartTuru.Sube, _btnEdit.Id, true);
                                    if (entity != null)
                                    {
                                        _btnEdit.Id = entity.Id;
                                        _btnEdit.EditValue = entity.SubeAdi;
                                    }
                                    break;
                                }

                        }
                    }
                    break;

            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
