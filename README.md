# DotNetERP

> İleri düzey C# ile geliştirilmiş örnek ERP/CRM uygulaması: Entity Framework, LINQ, katmanlı mimari, OOP ve DevExpress.

![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)
![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.7.2-512BD4.svg)
![Entity Framework](https://img.shields.io/badge/EF-6-512BD4.svg)
![DevExpress](https://img.shields.io/badge/DevExpress-FF7200.svg?logo=devexpress&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927.svg?logo=microsoftsqlserver&logoColor=white)

---

## Hakkında

**DotNetERP**, katmanlı mimari prensipleriyle geliştirilmiş örnek bir **ERP/CRM** masaüstü uygulamasıdır. Amacı; Entity Framework, LINQ, OOP ve DevExpress'in gerçek bir iş uygulamasında nasıl bir arada kullanıldığını göstermektir.

> Bu repo, eğitim ve portföy amaçlı örnek bir uygulamadır.

---

## Mimari

Uygulama, sorumlulukların net biçimde ayrıldığı **katmanlı bir mimari** (layered architecture) izler. Çözüm yedi projeden oluşur:

```text
DotNet.ERP.UI.Win      →  Ana kullanıcı arayüzü (WinForms + DevExpress)
DotNet.ERP.UI.Yonetim  →  Yönetim arayüzü (WinForms + DevExpress)
DotNet.ERP.BLL         →  İş mantığı (Business Logic)
DotNet.ERP.Model       →  Entity'ler, DTO'lar ve attribute'lar
DotNet.ERP.Dal         →  Veri erişimi (Entity Framework, Repository)
DotNet.ERP.Data        →  Veritabanı context ve konfigürasyonlar
DotNet.ERP.Common      →  Ortak yardımcılar ve sabitler
```

Veri akışı: **Model (Entity) → Dal → BLL → UI**; DTO'lar katmanlar arası veriyi taşır. Her katman yalnızca bir altındakini tanır; UI doğrudan veritabanına erişmez, her şey BLL üzerinden yürür.

---

## Modüller

| Modül | Açıklama |
| ----- | -------- |
| **CRM** | Okul ve Öğrenci yönetimi — kişi/tahakkuk kartları, iletişim ve adres bilgileri. |

---

## Teknolojiler

* **C# / .NET Framework 4.7.2**
* **Entity Framework 6** — ORM, Code First
* **LINQ** — sorgulama
* **DevExpress 24.1** — WinForms UI bileşenleri (GridControl, Editors, Scheduler)
* **SQL Server** — veritabanı
* **Katmanlı mimari + OOP** — SOLID prensipleri, Base* sınıf hiyerarşileri

---

## Kurulum

**Gereksinimler:** Visual Studio, SQL Server (veya LocalDB), DevExpress 24.1 (NuGet üzerinden).

1. Depoyu klonla:
   ```bash
   git clone https://github.com/RamiKoco/DotNetERP.git
   ```
2. `DotNet.ERP.UI.Win` projesindeki `App.config` içinde bağlantı dizesini kendi ortamına göre düzenle:
   ```xml
   <connectionStrings>
     <add name="ERPContext"
          connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DotNetERP2025;Integrated Security=True"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
   > Not: Gerçek sunucu adı, kullanıcı adı veya parola **asla** depoya eklenmemelidir. Windows kimlik doğrulaması (Integrated Security) kullanmak en güvenli yoldur.
3. Veritabanını oluştur (migration veya hazır script ile).
4. Çözümü Visual Studio'da aç, başlangıç projesi olarak `DotNet.ERP.UI.Win` (ya da yönetim arayüzü için `DotNet.ERP.UI.Yonetim`) seç ve çalıştır.

---

## Ekran Görüntüleri

> Buraya uygulamanın ekran görüntülerini ekleyebilirsin (CRM kartı, takvim ekranı vb.).
> Görselleri `/docs/screenshots/` klasörüne koyup buradan referans verebilirsin.

---

## Lisans

Bu proje [MIT Lisansı](./LICENSE) ile lisanslanmıştır.
