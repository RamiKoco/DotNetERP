using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DotNet.ERP.UI.Win.Forms.SubeForms;
using DotNet.ERP.UI.Win.Forms.KullaniciForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.KullaniciBirimYetkileriEditFormTable
{
    public partial class SubeTable : BaseTablo
    {
        public SubeTable()
        {
            InitializeComponent();

            Bll = new KullaniciBirimYetkileriBll();
            Tablo = tablo;
            EventsLoad();

        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBirimYetkileriBll)Bll).List(x => x.KullaniciId == OwnerForm.Id && x.KartTuru == KartTuru.Sube ).ToBindingList<KullaniciBirimYetkileriL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KullaniciBirimYetkileriL>().Select(x => x.SubeId.Value).ToList();


            var entities = ShowListForms<SubeListForm>.ShowDialogListForm(ListeDisiTutulacakKayitlar, true, false).EntityListConvert<SubeL>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new KullaniciBirimYetkileriL
                {
                    Kod = entity.Kod,
                    SubeAdi = entity.SubeAdi,
                    KartTuru = KartTuru.Sube,
                    KullaniciId = OwnerForm.Id,
                    SubeId = entity.Id,
                    Insert = true
                };


                source.Add(row);

            }

            if (!Kaydet()) return;
            Listele();
            tablo.Focus();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;

        }
        protected override void HareketSil()
        {
            if (tablo.DataRowCount == 0) return;
            if (Messages.SilMesaj("Şube Kartı") != DialogResult.Yes) return;

            tablo.GetRow<IBaseHareketEntity>().Delete = true;
            tablo.RefleshDataSource();

            var rowHandle = tablo.FocusedRowHandle;
            if (!Kaydet()) return;
            Listele();
            tablo.FocusedRowHandle = rowHandle;
        }

        protected override void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            btnHareketSil.Enabled = tablo.DataRowCount > 0;
            btnHareketEkle.Enabled = ((KullaniciBirimYetkileriEditForm)OwnerForm).kullaniciTable.Tablo.DataRowCount > 0;
            e.SagMenuGoster(popupMenu);
        }
    }
}
