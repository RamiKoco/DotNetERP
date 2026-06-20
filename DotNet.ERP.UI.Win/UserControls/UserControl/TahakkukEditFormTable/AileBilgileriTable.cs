using System.Linq;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.AileBilgiForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class AileBilgileriTable : BaseTablo
    {
        public AileBilgileriTable()
        {
            InitializeComponent();

            Bll = new AileBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((AileBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<AileBilgileriL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<AileBilgileriL>().Where(x => !x.Delete).Select(x => x.AileBilgiId).ToList();
            

            var entities = ShowListForms<AileBilgiListForm>.ShowDialogListForm(KartTuru.AileBilgi, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<AileBilgi>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new AileBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    AileBilgiId = entity.Id,
                    BilgiAdi = entity.BilgiAdi,
                    Aciklama = null,
                    Insert = true
                };


                source.Add(row);

            }

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colBilgiAdi;

            ButonEnabledDurumu(true);

        }
    }
}
