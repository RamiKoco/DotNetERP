using System.Linq;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.EvrakForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class EvrakBilgileriTable : BaseTablo
    {
        public EvrakBilgileriTable()
        {
            InitializeComponent();

            Bll = new EvrakBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((EvrakBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<EvrakBilgileriL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<EvrakBilgileriL>().Where(x => !x.Delete).Select(x => x.EvrakId).ToList();


            var entities = ShowListForms<EvrakListForm>.ShowDialogListForm(KartTuru.Evrak, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<Evrak>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new EvrakBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    EvrakId = entity.Id,
                    Kod = entity.Kod,
                    EvrakAdi = entity.EvrakAdi,
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
