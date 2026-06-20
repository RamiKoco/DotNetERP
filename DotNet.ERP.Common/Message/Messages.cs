using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DotNet.ERP.Common.Message
{
    public class Messages
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public static void UyariMesaji(string uyariMesaji)
        {
            XtraMessageBox.Show(uyariMesaji, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        public static void BilgiMesaji(string bilgiMesaji)
        {
            XtraMessageBox.Show(bilgiMesaji, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
        {
           return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
        }

        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult EvetSeciliEvetHayirIptal(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult SilMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} Silinecektir. Onaylıyor musunuz?", "Silme Onayı");
        }
        public static DialogResult DosyaSilMesaji()
        {
            return HayirSeciliEvetHayir(
                "Bu dosya kalıcı olarak silinecek. Devam etmek istiyor musunuz?",
                "Dosya Silme Onayı"
            );
        }
        public static DialogResult KapanisMesaj()
        {
            return EvetSeciliEvetHayirIptal("Yapılan Değişiklikler Kayıt Edilsin mi", "Çıkış Onay");
        }

        public static DialogResult KayitMesaj()
        {
            return EvetSeciliEvetHayir("Yapılan Değişiklikler Kayıt Edilsin mi?", "Kayıt Onay");
        }

        public static void KartSecmemeUyariMesaji()
        {
            UyariMesaji("Lütfen Bir Kart Seçiniz.");
        }

        public static void MukerrerKayitHataMesaji(string alanAdi)
        {
            UyariMesaji($"Girmiş Olduğunuz {alanAdi} Daha Önce Kullanılmıştır.");
        }

        public static void HataliVeriMesaji(string alanAdi)
        {
            UyariMesaji($"{alanAdi} Alanına Geçerli Bir Değer Girmelisiniz.");
        }
        public static DialogResult TabloExportMesaj(string dosyaFormati)
        {
            return EvetSeciliEvetHayir($"İlgili Tablo, {dosyaFormati} Olarak Dışarı Aktarılacaktır. Onaylıyor Musunuz?","Aktarım Onay");
        }

        public static void KartBulunamadiMesaji(string kartTuru)
        {
            UyariMesaji($"İşlem Yapılabilecek {kartTuru} Bulunamadı.");
        }

        public static void TabloEksikBilgiMesaji(string tabloAdi)
        {
            UyariMesaji($"{tabloAdi}nda Eksik Bilgi Girişi Var. Lütfen Kontrol Ediniz.");
        }
        public static void IptalHareketSilinemezMesaji()
        {
            HataMesaji("İptal Edilen Hareketler Silinemez.");
        }
        public static DialogResult IptalMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} İptal Edilecektir. Onaylıyor musunuz?", "İptal Onayı");
        }
        public static DialogResult IptalGerialMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} Kartına Uygulanan İptal İşlemi Geri Alınacaktır. Onaylıyor musunuz?", "İptal Gerial Onayı");
        }

        public static void SecimHataMesaji(string alanAdi)
        {
            HataMesaji($"{alanAdi} Seçimi Yapmalısınız.");
        }

        public static void OdemeBelgesiSilinemezMesaj(bool dahaSonra)
        {
            UyariMesaji(dahaSonra
                ? "Ödeme Belgesinin Daha Sonra İşlem Görmüş Hareketleri Var. Ödeme Belgesi Silinemez." 
                : "Ödeme Belgesinin İşlem Görmüş Hareketleri Var. Ödeme Belgesi Silinemez.");
        }

        public static DialogResult RaporTasarimaGonderMesaj()
        {
            return HayirSeciliEvetHayir("Rapor Tasarım Görünümünde Açılacaktır. Onaylıyor Musunuz?", "Onay");
        }
        public static DialogResult RaporKapatmaMesaj()
        {
            return HayirSeciliEvetHayir("Rapor Kapatılacaktır. Onaylıyor Musunuz?", "Onay");
        }
        public static DialogResult EmailGonderimOnayi()
        {
            return HayirSeciliEvetHayir("Kullanıcı Şifresi Sıfırlanarak, Kullanıcı Bilgilerini İçeren Yeni Bir Email Gönderilecektir. Onaylıyor Musunuz?", "Onay");
        }
        public static void KokDizinBulunamadi()
        {
            HataMesaji("Kök dizin bulunamadı.");
        }

        public static void DosyaBulunamadi()
        {
            HataMesaji("Dosya bulunamadı.");
        }

        public static void DosyaAcilamadi(string hata = null)
        {
            var mesaj = "Dosya açılamadı.";
            if (!string.IsNullOrWhiteSpace(hata))
                mesaj += Environment.NewLine + hata;

            HataMesaji(mesaj);
        }
        public static void KokDizinErisilemiyor()
        {
            HataMesaji("Kök dizine erişilemiyor. Sistem yöneticinizle iletişime geçin.");
        }
        public static void FizikselDosyaBulunamadi()
        {
            HataMesaji("Dosya fiziksel olarak bulunamadı.");
        }
        public static void DosyaYoluHatali()
        {
            HataMesaji("Dosya yolu hatalı. Kayıt bozulmuş olabilir.");
        }
        public static void DosyaKilitli()
        {
            UyariMesaji("Dosya şu anda başka bir işlem tarafından kullanılıyor.");
        }
        public static void DosyaYetkisizErisim()
        {
            HataMesaji("Dosyayı açma yetkiniz yok.");
        }
        public static void BeklenmeyenHata(string detay = null)
        {
            var msg = "Dosya açılırken beklenmeyen bir hata oluştu.";
            if (!string.IsNullOrWhiteSpace(detay))
                msg += Environment.NewLine + detay;

            HataMesaji(msg);
        }
        public static DialogResult ZorunluDevamKayitMesaji()
        {
            return EvetSeciliEvetHayir(
                "Devam edebilmek için kaydetmelisiniz.\n\nKaydetmek istiyor musunuz?",
                "Uyarı"
            );
        }
        public static void ZorunluAlanUyariMesaji(string alanAdi)
        {
            UyariMesaji($"{alanAdi} alanı boş bırakılamaz. Lütfen bir değer giriniz.");
        }
    }
}
