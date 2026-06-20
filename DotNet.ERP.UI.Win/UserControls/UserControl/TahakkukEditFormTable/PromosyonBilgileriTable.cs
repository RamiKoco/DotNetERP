using System.Linq;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.PromosyonForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class PromosyonBilgileriTable : BaseTablo
    {
        public PromosyonBilgileriTable()
        {
            InitializeComponent();

            Bll = new PromosyonBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((PromosyonBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<PromosyonBilgileriL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<PromosyonBilgileriL>().Where(x => !x.Delete).Select(x => x.PromosyonId).ToList();


            var entities = ShowListForms<PromosyonListForm>.ShowDialogListForm(KartTuru.Promosyon, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<Promosyon>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new PromosyonBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    PromosyonId = entity.Id,
                    Kod = entity.Kod,
                    PromosyonAdi = entity.PromosyonAdi,
                    Insert = true
                };


                source.Add(row);

            }

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKod;

            ButonEnabledDurumu(true);

        }

    }
}
