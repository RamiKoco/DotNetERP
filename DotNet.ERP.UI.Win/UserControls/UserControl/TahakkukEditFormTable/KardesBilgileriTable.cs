using System.Linq;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Forms.TahakkukForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class KardesBilgileriTable : BaseTablo
    {
        public KardesBilgileriTable()
        {
            InitializeComponent();

            Bll = new KardesBilgileriBll();
            Tablo = tablo;
            EventsLoad();
            ShowItems = new BarItem[] {btnKartDuzenle };
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KardesBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<KardesBilgileriL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KardesBilgileriL>().Where(x => !x.Delete).Select(x => x.KardesTahakkukId).ToList();
            ListeDisiTutulacakKayitlar.Add(OwnerForm.Id);

            var entities = ShowListForms<TahakkukListForm>.ShowDialogListForm(KartTuru.Tahakkuk, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<TahakkukL>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new KardesBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    KardesTahakkukId = entity.Id,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    SinifAdi = entity.SinifAdi,
                    KayitSekli = entity.KayitSekli,
                    KayitDurumu = entity.KayitDurumu,
                    IptalDurumu = entity.Durum?IptalDurumu.DevamEdiyor:IptalDurumu.IptalEdildi,
                    SubeAdi = entity.SubeAdi,
                    Insert = true
                };


                source.Add(row);

            }

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colAdi;

            ButonEnabledDurumu(true);

        }

        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<KardesBilgileriL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.KardesTahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);

        }
    }
}
