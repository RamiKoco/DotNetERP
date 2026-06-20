using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class RolYetkiKartlariListForm : BaseListForm
    {
        public RolYetkiKartlariListForm()
        {
            InitializeComponent();
            HideItems = new BarItem[]
            {
                btnYeni, btnSil, btnDuzelt, btnKolonlar, barInsert, barInsertAciklama, barDelete, barDeleteAciklama,
                barDuzelt, barDuzeltAciklama, barKolonlar, barKolonlarAciklama
            };
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Yetki;
            Navigator = longNavigator.Navigator;

        }
        protected override void Listele()
        {

            var enumList = Enum.GetValues(typeof(KartTuru)).Cast<KartTuru>().ToList();
            var liste = new List<RolYetki>();

            enumList.ForEach(x =>
            {
                var entity = new RolYetki
                {
                    KartTuru = x
                };
                liste.Add(entity);
            });

            var list = liste.Where(x => !ListeDisiTutulacakKayitlar.Contains((long)x.KartTuru)).OrderBy(x=> x.KartTuru.ToName());
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }

    }
}